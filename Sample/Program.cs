using LightWebNetScraper;
using System;
using System.Collections.Generic;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var scraper = new Scraper();

            var result = scraper.StartScraping(new List<ScrapeInfo<string>>()
                {
                    new ScrapeInfo<string>(
                        "https://www.nuget.org/packages/LightWebNetScraper",
                        (htmlDoc, scrapeInfo) =>  htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class='package-title']/h1").InnerHtml)
                    });
            Console.WriteLine(result[0]);
            Console.ReadLine();
        }
    }
}
