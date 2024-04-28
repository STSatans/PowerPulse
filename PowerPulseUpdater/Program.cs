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
    static async Task Main()
    {
        string owner = "STSatans";
        string repo = "PowerPulse";
        string downloadPath = "../PowerPulse.rar"; // Path to download the release archive in the parent folder
        string logFilePath = "updater_log.txt";
             
        try
        {
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine($"Log started at: {DateTime.Now}");

                // Terminate PowerPulse.exe process if running
                TerminatePowerPulseProcess(writer);

                Console.WriteLine($"Downloading the latest release of PowerPulse from GitHub...");
                await DownloadLatestReleaseAsync(owner, repo, downloadPath, writer);

                string updaterDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string powerPulseDirectory = Directory.GetParent(updaterDirectory).FullName;

                Console.WriteLine($"Extracting files from the downloaded archive...");
                List<string> extractedFiles = await ExtractRarArchiveAsync(downloadPath, powerPulseDirectory, writer);

                Console.WriteLine($"PowerPulse has been successfully updated.");
                Process.Start(Path.Combine(powerPulseDirectory, "PowerPulse.exe"));

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during the update: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    static void TerminatePowerPulseProcess(StreamWriter writer)
    {
        Process[] processes = Process.GetProcessesByName("PowerPulse");
        foreach (Process process in processes)
        {
            process.Kill();
            writer.WriteLine($"Terminated PowerPulse.exe process (PID: {process.Id}).");
        }
    }

    static async Task DownloadLatestReleaseAsync(string owner, string repo, string downloadPath, StreamWriter writer)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "request");

            HttpResponseMessage response = await client.GetAsync($"https://api.github.com/repos/{owner}/{repo}/releases/latest");
            response.EnsureSuccessStatusCode(); // Throw on error status code

            dynamic release = Newtonsoft.Json.JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            string downloadUrl = release.assets[0].browser_download_url;

            using (Stream contentStream = await client.GetStreamAsync(downloadUrl))
            using (FileStream fileStream = new FileStream(downloadPath, FileMode.Create))
            {
                await contentStream.CopyToAsync(fileStream);
            }
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
        }

        return extractedFiles;
    }
}
