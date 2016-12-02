using System;
using HtmlAgilityPack;

namespace LightWebNetScraper
{
    public class ScrapeInfo<T>
    {
        public string Url { get; set; }
        public Func<HtmlDocument, ScrapeInfo<T>, T> SearchExpression { get; set; }
    }
}