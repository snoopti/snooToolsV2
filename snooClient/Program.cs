﻿using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace snooClient
{
    internal class Program
    {
        // ---------------------------------------- config ----------------------------------------
        private const string Version = "2.1";
        private const string Name = "snooTools";
        private const string Author = "snoopti";
        private const string ContinueMessage = "Press any button to continue";
        private const string Title = " | " + Name + " v" + Version + " by " + Author;

        // ---------------------------------------- menu ----------------------------------------
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Title = "Home" + Title;
                Console.WriteLine($"--- Welcome to {Name} ---");
                Console.WriteLine("");
                Console.WriteLine("--- Tools");
                Console.WriteLine("[1] Systemoptimizer");
                Console.WriteLine("[2] Webhooksender");
                Console.WriteLine("[3] IPAdressviewer");
                Console.WriteLine("[4] Speedtest");
                Console.WriteLine("");
                Console.WriteLine("--- Informations");
                Console.WriteLine("[#] About");
                Console.WriteLine("[?] Discord");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.Title = "Systemoptimizer" + Title;
                         SystemOptimizer();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Title = " Webhooksender" + Title;
                        await WebhookSender();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Title = "IPAdressviewer" + Title;
                        showIpAdress();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Title = "Speedtest" + Title;
                        await CheckInternetSpeed();
                        break;
                    case "#":
                        Console.Clear();
                        Console.Title = "Informations" + Title;
                        Console.WriteLine("Version: " + Version);
                        break;
                    case "?":
                        Console.Clear();
                        InfoDiscord();
                        break;
                    case "0":
                        Console.Clear();
                        Console.Title = "Exit" + Title;
                        Countdown(3);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.Title = "Error" + Title;
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // ---------------------------------------- info: discord ----------------------------------------
        static void InfoDiscord()
        {
            Console.WriteLine(ContinueMessage);
            Console.ReadKey();
            Console.WriteLine("Opening Discord...");
            System.Diagnostics.Process.Start("https://snoopti.de/discord");
        }

        // ---------------------------------------- tool: SystemOptimizer ----------------------------------------
        static void SystemOptimizer()
        {
            Console.WriteLine("--- Systemoptimizer ---");
            Console.WriteLine("Click any button to continue");
            Console.ReadKey();
            try
            {
                string user = Environment.UserName;
                string LOCALAPPDATA = Environment.GetEnvironmentVariable("LOCALAPPDATA");
                string SYSTEMROOT = Environment.GetEnvironmentVariable("SYSTEMROOT");
                string TEMP = Environment.GetEnvironmentVariable("TEMP");
                string AllUsersProfile = Environment.GetEnvironmentVariable("AllUsersProfile");
                string[] foldersToEmpty =
                {
                    // programdata
                    // $@"C:\ProgramData\"
                    $@"C:\ProgramData\Microsoft\Windows Defender\Scans\History\Results\Resource",
                    $@"C:\ProgramData\Microsoft\Windows Defender\Scans\History\Results\Quick",
                    $@"C:\ProgramData\Microsoft\Windows Defender\Support",
                    $@"C:\ProgramData\Microsoft\Windows Defender\Scans\MetaStore",
                    $@"C:\ProgramData\Microsoft\Windows Defender\Scans\History\ReportLatency\Latency",
                    $@"C:\ProgramData\Microsoft\Windows Defender\Scans\History\CacheManager",
                    $@"C:\ProgramData\Microsoft\Windows\WER\Temp",
                    $@"C:\ProgramData\Microsoft\Windows\WER\ReportQueue",
                    $@"C:\ProgramData\Microsoft\Windows\WER\ReportArchive",
                    $@"C:\ProgramData\temp",
                    $@"C:\ProgramData\Microsoft\Windows\WER\ReportArchive",

                    // windows
                    // $@"C:\Windows\"
                    $@"C:\Windows\pchealth\helpctr\OfflineCache",
                    $@"C:\Windows\pchealth\ERRORREP",
                    $@"C:\Windows\System32\Winevt\Logs",
                    $@"C:\Windows\SysNative\Winevt\Logs",
                    $@"C:\Windows\LiveKernelReports",
                    $@"C:\Windows\ServiceProfiles\NetworkService\AppData\Local\Microsoft\Windows\DeliveryOptimization",
                    $@"C:\Windows\system32\catroot2",
                    $@"C:\Windows\SoftwareDistribution\Download",
                    $@"C:\Windows\Temp",
                    $@"C:\Windows\Minidump",
                    $@"C:\Windows\Prefetch",
                    $@"C:\Windows\Temp",
                    $@"C:\Windows\SoftwareDistribution\download",
                    $@"C:\Windows\Downloaded Program Files",

                    // user
                    // $@"C:\Users\{user}\"
                    $@"C:\Users\{user}\.cache",

                    // roaming
                    // $@"C:\Users\{user}\AppData\"
                    $@"C:\Users\{user}\AppData\Roaming\discord\Code Cache",
                    $@"C:\Users\{user}\AppData\Roaming\Microsoft\Teams\Code Cache\js",
                    $@"C:\Users\{user}\AppData\Roaming\discord\Code Cache\js",
                    $@"C:\Users\{user}\AppData\Microsoft\Windows\Recent\AutomaticDestinations",
                    $@"C:\Users\{user}\AppData\Microsoft\Windows\Recent\CustomDestinations",

                    // local
                    // $@"C:\Users\{user}\AppData\Local\"
                    $@"C:\Users\{user}\AppData\Local\PCHealth\ErrorRep\QSignoff",
                    $@"C:\Users\{user}\AppData\Local\D3DSCache",
                    $@"C:\Users\{user}\AppData\Local\Microsoft\Windows\AppCache",
                    $@"C:\Users\{user}\AppData\Local\Microsoft\Windows\WebCache",
                    $@"C:\Users\{user}\AppData\Local\Microsoft\Windows\Temporary Internet Files",
                    $@"C:\Users\{user}\AppData\Local\Microsoft\Windows\INetCache\IE\",
                    $@"C:\Users\{user}\AppData\Local\D3DSCache",
                    $@"C:\Users\{user}\AppData\Local\Temp",
                    $@"C:\Users\{user}\AppData\Local\NVIDIA\DXCache",
                    $@"C:\Users\{user}\AppData\Local\NVIDIA\GLCache",
                    $@"C:\Users\{user}\AppData\Local\CapCut\User Data\Cache",
                    $@"C:\Users\{user}\AppData\Local\pip\cache",
                    $@"C:\Users\{user}\AppData\Local\Microsoft\Edge\User Data\BrowserMetrics",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Default\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Default\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 1\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 1\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 2\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 2\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 3\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 3\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 4\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 4\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 5\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 5\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 6\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 6\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 7\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 7\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 8\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 8\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 9\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 9\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 10\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Google\Chrome\User Data\Profile 10\Service Worker\CacheStorage",
                    $@"C:\Users\{user}\AppData\Local\Opera Software\Opera Stable\Default\Cache\Cache_Data",
                    $@"C:\Users\{user}\AppData\Local\Opera Software\Opera Stable\Default\System Cache\Cache_Data",

                    // locallow
                    // $@"C:\Users\{user}\AppData\LocalLow\"
                    $@"C:\Users\{user}\AppData\LocalLow\Temp",
                    $@"C:\Users\{user}\AppData\LocalLow\Microsoft\CryptnetUrlCache\Content",
                    $@"C:\Users\{user}\AppData\LocalLow\Microsoft\CryptnetUrlCache\MetaData"
                };

                foreach (string folder in foldersToEmpty)
                {
                    EmptyFolder(folder);
                }

                Console.WriteLine("");
                Console.WriteLine("finished.");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        static void EmptyFolder(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, recursive: true);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(path);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(path);
                    Console.ResetColor();
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(path);
                Console.ResetColor();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(path);
                Console.ResetColor();
            }
        }

        // ---------------------------------------- tool: webhook sender ----------------------------------------
        static async Task WebhookSender()
        {
            Console.WriteLine("Enter Webhook URL:");
            string webhookUrl = Console.ReadLine();

            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out Uri validUri))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }

            Console.WriteLine("Enter Message:");
            string messageText = Console.ReadLine();

            await SendMessageToDiscordWebhook(webhookUrl, messageText);
        }

        static async Task SendMessageToDiscordWebhook(string webhookUrl, string messageText)
        {
            using (HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    content = messageText
                };

                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(webhookUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("send.");
                    }
                    else
                    {
                        Console.WriteLine($"failed: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"error: {ex.Message}");
                }
            }
        }

        // ---------------------------------------- tool: showip ----------------------------------------
        static void showIpAdress()
        {
            try
            {
                string ipAddress = new WebClient().DownloadString("http://icanhazip.com").Trim();
                Console.WriteLine($"IP: {ipAddress}");

                string apiUrl = $"http://ip-api.com/json/{ipAddress}?fields=country,regionName,city,isp,lat,lon,timezone,as";
                string jsonResult = new WebClient().DownloadString(apiUrl);

                dynamic locationInfo = JsonConvert.DeserializeObject(jsonResult);
                string country = locationInfo.country;
                string region = locationInfo.regionName;
                string city = locationInfo.city;
                string isp = locationInfo.isp;
                double latitude = locationInfo.lat;
                double longitude = locationInfo.lon;
                string timezone = locationInfo.timezone;

                Console.WriteLine($"Location: {city}, {region}, {country}");
                Console.WriteLine($"ISP: {isp}");
                Console.WriteLine($"Latitude: {latitude}");
                Console.WriteLine($"Longitude: {longitude}");
                Console.WriteLine($"Timezone: {timezone}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        // ---------------------------------------- tool: speedtest ----------------------------------------
        static async Task CheckInternetSpeed()
        {
            try
            {
                string ipAddress = new WebClient().DownloadString("http://icanhazip.com").Trim();

                const int numTests = 5;
                var results = new List<double>();
                var url = "https://snoopti.de/download/speedtest1mb.zip";

                Console.WriteLine($"IP Adress: {ipAddress}");
                Console.WriteLine($"Server: Berlin/Karlsruhe | Germany");
                Console.WriteLine($"Running {numTests} times...");

                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(30);

                    for (int i = 1; i <= numTests; i++)
                    {
                        var stopwatch = Stopwatch.StartNew();

                        try
                        {
                            var response = await httpClient.GetAsync(url);
                            response.EnsureSuccessStatusCode();
                            await response.Content.ReadAsByteArrayAsync();
                        }
                        catch (HttpRequestException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            continue;
                        }
                        catch (TaskCanceledException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            continue;
                        }

                        stopwatch.Stop();

                        double speedInMbps = CalculateSpeed(stopwatch.Elapsed);
                        Console.WriteLine($"Test {i}: {speedInMbps:F2} Mbps");
                        results.Add(speedInMbps);

                        await Task.Delay(5000);
                    }
                }

                double averageSpeed = results.Any() ? results.Average() : 0;
                Console.WriteLine($"\nAverage speed over {results.Count} tests: {averageSpeed:F2} Mbps");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static double CalculateSpeed(TimeSpan elapsed)
        {
            const int fileSizeInBytes = 1024 * 1024;
            const int bitsInByte = 8;
            double seconds = elapsed.TotalSeconds;
            double bytesPerSecond = fileSizeInBytes / seconds;
            double bitsPerSecond = bytesPerSecond * bitsInByte;
            double speedInMbps = bitsPerSecond / 1024 / 1024;
            return speedInMbps;
        }
        // ---------------------------------------- tool: webhook sender ----------------------------------------
        static void WingetUpdater()
        {
            // TODO: winget upgrade --all --include-unkown
        }
        // -------------------- system: countdown --------------------
        static void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine($"Exiting in {i} seconds...");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}