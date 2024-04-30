using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;

class Program
{
    static async Task Main(string[] args)
    {
        // Check if running with elevated privileges
        if (!IsAdmin())
        {
            // Restart with elevated privileges
            RestartWithAdminPrivileges();
            return;
        }

        string owner = "STSatans";
        string repo = "PowerPulse";
        string downloadPath = "../PowerPulse.rar"; // Path to download the release archive in the parent folder
        string logFilePath = "updater_log.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Log started at: {DateTime.Now}");

                // Check if PowerPulse.exe is running and terminate the process
                TerminatePowerPulseProcess(writer);

                writer.WriteLine($"Downloading the latest release of PowerPulse from GitHub...");
                await DownloadLatestReleaseAsync(owner, repo, downloadPath, writer);

                string updaterDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string powerPulseDirectory = Directory.GetParent(updaterDirectory).FullName;

                writer.WriteLine($"Extracting files from the downloaded archive...");
                List<string> extractedFiles = await ExtractRarArchiveAsync(downloadPath, powerPulseDirectory, writer);

                writer.WriteLine($"PowerPulse has been successfully updated.");
                Process.Start(Path.Combine(powerPulseDirectory, "PowerPulse.exe"));

                writer.WriteLine("Press any key to exit...");
                writer.Flush();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during the update: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    static bool IsAdmin()
    {
        using (var identity = System.Security.Principal.WindowsIdentity.GetCurrent())
        {
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }
    }

    static void RestartWithAdminPrivileges()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
        startInfo.Verb = "runas"; // Run as administrator
        try
        {
            Process.Start(startInfo);
        }
        catch (System.ComponentModel.Win32Exception)
        {
            // User canceled the UAC prompt or it failed for some reason
        }
        Environment.Exit(0);
    }

    static void TerminatePowerPulseProcess(StreamWriter writer)
    {
        Process[] processes = Process.GetProcessesByName("PowerPulse");
        foreach (Process process in processes)
        {
            process.Kill();
            writer.WriteLine($"Terminated PowerPulse.exe process (PID: {process.Id}).");
        }
        writer.Flush();
    }

    static async Task DownloadLatestReleaseAsync(string owner, string repo, string downloadPath, StreamWriter writer)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "request");

            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync($"https://api.github.com/repos/{owner}/{repo}/releases/latest");
                response.EnsureSuccessStatusCode(); // Throw on error status code
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message.Contains("404"))
                {
                    writer.WriteLine($"Error: The specified repository or release does not exist.");
                    return;
                }
                else
                {
                    writer.WriteLine($"Error: {ex.Message}");
                    return;
                }
            }

            dynamic release = Newtonsoft.Json.JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            string downloadUrl = release.assets[0].browser_download_url;

            using (Stream contentStream = await client.GetStreamAsync(downloadUrl))
            using (FileStream fileStream = new FileStream(downloadPath, FileMode.Create))
            {
                await contentStream.CopyToAsync(fileStream);
            }
            writer.Flush();
        }
    }


    static async Task<List<string>> ExtractRarArchiveAsync(string archivePath, string extractDirectory, StreamWriter writer)
    {
        List<string> extractedFiles = new List<string>();

        using (var archive = RarArchive.Open(archivePath))
        {
            foreach (var entry in archive.Entries)
            {
                string entryPath = Path.Combine(extractDirectory, entry.Key.Replace("/", Path.DirectorySeparatorChar.ToString()));

                if (entryPath.StartsWith(Path.Combine(extractDirectory, "Updater"), StringComparison.OrdinalIgnoreCase) && Directory.Exists(Path.Combine(extractDirectory, "Updater")))
                {
                    // Skip extraction if the "Updater" folder already exists
                    continue;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(entryPath));

                using (Stream entryStream = entry.OpenEntryStream())
                using (FileStream fileStream = File.Create(entryPath))
                {
                    await entryStream.CopyToAsync(fileStream);
                    extractedFiles.Add(entryPath);
                }
            }
            writer.Flush();
        }

        return extractedFiles;
    }
}
