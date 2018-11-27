# LightWebNetScraper
Lightweight .NET web scraper

# README Version 0.0.2 #

LightWebNetScraper is a .NET project for doing simple scraping tasks.

The project consist of a libary.

Supports plain XPATH or XSLT.

### How do I get set up? ###

* Include the nuget package and checkout the code example.
* Nuget link https://www.nuget.org/packages/LightWebNetScraper

### Code example ###
```cs
var scraper = new Scraper();

var result = scraper.StartScraping(new List<ScrapeInfo<string>>()
    {
        new ScrapeInfo<string>(
            "https://www.nuget.org/packages/LightWebNetScraper",
            (htmlDoc, scrapeInfo) =>  htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class='package-title']/h1").InnerHtml)
        });
Console.WriteLine(result[0]);
Console.ReadLine();
```
The InnerHtml in this case is "Renerotvig"

License
====

LightWebNetScraper is licensed under [The MIT License (MIT)][1]. Basically, this license grants you the right to use LightWebNetScraper in any way you see fit. See [License.md](/License.md) for more info.

[1]: https://opensource.org/licenses/MIT
