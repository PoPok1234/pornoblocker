using System;
using System.Diagnostics;
using System.IO;

namespace siteBlocker
{
    class Program
    {
        static void Main()
        {
            string[] blockedSites = { "xvideos.com", "porno365.pics", "pornhub.com", "pornhub.ru", "noodlemagazine.com", "ebalovo.xxx", "xxx.com", "xxx.ru", "extoons.com", "t.me", "vk.com", "hentai.com" };

            // Путь к файлу hosts в системной папке
            string hostsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");

            // Перенаправляем каждый заблокированный сайт на localhost в файле hosts
            foreach (string site in blockedSites)
            {
                string entry = $"127.0.0.1 {site}";
                AppendToHostsFile(hostsPath, entry);
            }

            Console.WriteLine("сайты заблокированы");
            Console.ReadKey();
        }

        static void AppendToHostsFile(string filePath, string text)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении записи в файл hosts: {ex.Message}");
            }
        }
    }
}
