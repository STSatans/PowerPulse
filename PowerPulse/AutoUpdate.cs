using Octokit;
using System;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;

public class GitHubAutoUpdater
{
    private readonly GitHubClient _githubClient;
    private readonly string _owner;
    private readonly string _repoName;

    public GitHubAutoUpdater(string accessToken, string owner, string repoName)
    {
        _githubClient = new GitHubClient(new ProductHeaderValue("PowerPulse"));
        _githubClient.Credentials = new Credentials(accessToken);
        _owner = owner;
        _repoName = repoName;
    }

    public async Task<bool> CheckForUpdates(string currentVersion)
    {
        try
        {
            var releases = await _githubClient.Repository.Release.GetAll(_owner, _repoName);
            var latestRelease = releases[0];
            return latestRelease.TagName != currentVersion;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking for updates: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DownloadUpdate(string releaseTag, string downloadPath)
    {
        try
        {
            var release = await _githubClient.Repository.Release.Get(_owner, _repoName, releaseTag);
            var asset = release.Assets[0]; // Assuming there's only one asset

            using (var client = new WebClient())
            {
                client.DownloadFile(asset.BrowserDownloadUrl, downloadPath);
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading update: {ex.Message}");
            return false;
        }
    }

    public void ExtractUpdate(string zipFilePath, string destinationDirectory)
    {
        try
        {
            ZipFile.ExtractToDirectory(zipFilePath, destinationDirectory);
            Console.WriteLine("Update extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error extracting update: {ex.Message}");
        }
    }
}
