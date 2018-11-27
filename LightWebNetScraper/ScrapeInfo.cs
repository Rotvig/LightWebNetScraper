using System;
using HtmlAgilityPack;

namespace LightWebNetScraper
{
    public class ScrapeInfo<T>
    {
        public ScrapeInfo(string url, Func<HtmlDocument, ScrapeInfo<T>, T> searchExpression)
        {
            Url = url;
            SearchExpression = searchExpression;
        }

        public string Url { get; private set; }
        public Func<HtmlDocument, ScrapeInfo<T>, T> SearchExpression { get; private set; }
    }
}