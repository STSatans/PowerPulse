using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SharpCompress.Archives.Rar;

namespace PowerPulseUpdater
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (!IsAdmin())
            {
                RestartWithAdminPrivileges();
                return;
            }

            string powerPulseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;

            string owner = "STSatans";
            string repo = "PowerPulse";
            string downloadPath = Path.Combine(powerPulseDirectory, "PowerPulse.rar");
            string logFilePath = Path.Combine(powerPulseDirectory, "updater_log.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"Log started at: {DateTime.Now}");

                    TerminatePowerPulseProcess(writer);

                    writer.WriteLine($"Downloading the latest release of PowerPulse from GitHub...");
                    await DownloadLatestReleaseAsync(owner, repo, downloadPath, writer);

                    writer.WriteLine($"Extracting files from the downloaded archive...");
                    List<string> extractedFiles = await ExtractRarArchiveAsync(downloadPath, powerPulseDirectory, writer);

                    writer.WriteLine($"PowerPulse has been successfully updated.");

                    // Inicia o processo PowerPulse.exe
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
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
        static void RestartWithAdminPrivileges()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = Assembly.GetExecutingAssembly().Location,
                Verb = "runas"
            };
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
                try
                {
                    process.Kill();
                    process.WaitForExit();
                    writer.WriteLine($"Terminated PowerPulse.exe process (PID: {process.Id}).");
                }
                catch (Exception ex)
                {
                    writer.WriteLine($"Failed to terminate PowerPulse.exe process (PID: {process.Id}): {ex.Message}");
                }
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
            }
            return extractedFiles;
        }
    }
}

