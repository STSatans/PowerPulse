using System;
using System.IO;
using System.Net;
using System.Diagnostics;

public class AutoUpdater
{
    private string serverUrl; // URL of the server where updates are hosted
    private string localFilePath; // Local path where the updater should save the downloaded file
    private string executablePath; // Path of the main executable

    public AutoUpdater(string serverUrl, string localFilePath, string executablePath)
    {
        this.serverUrl = serverUrl;
        this.localFilePath = localFilePath;
        this.executablePath = executablePath;
    }

    public bool CheckForUpdates()
    {
        try
        {
            using (var client = new WebClient())
            {
                string updateUrl = $"{serverUrl}/latest_version.txt";
                string latestVersionStr = client.DownloadString(updateUrl);
                Version latestVersion = new Version(latestVersionStr.Trim());

                Version currentVersion = GetCurrentAppVersion();

                return latestVersion > currentVersion;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking for updates: {ex.Message}");
            return false;
        }
    }

    public void DownloadUpdate()
    {
        try
        {
            using (var client = new WebClient())
            {
                string updateUrl = $"{serverUrl}/latest_app.exe";
                client.DownloadFile(updateUrl, localFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading update: {ex.Message}");
        }
    }

    public void ApplyUpdate()
    {
        try
        {
            Process.Start(localFilePath);
            Environment.Exit(0); // Exit the current application
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error applying update: {ex.Message}");
        }
    }

    private Version GetCurrentAppVersion()
    {
        return new Version(FileVersionInfo.GetVersionInfo(executablePath).FileVersion);
    }
}