using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace LightWebNetScraper
{
    public class Scraper
    {
        /// <summary>
        /// Starts Scraping of the given urls.
        /// Timeout is in milliseconds.
        /// </summary>
        public List<T> StartScraping<T>(List<ScrapeInfo<T>> urls, int timeout = 5000)
        {
            var tasks = urls.Select(scrapeInfo => Task.Factory.StartNew(() => Scrape(scrapeInfo, timeout))).ToArray();
            Task.WaitAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        protected virtual T Scrape<T>(ScrapeInfo<T> info, int timeout)
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.Timeout = timeout;
                    var html = client.DownloadString(info.Url);
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);
                    return info.SearchExpression(htmlDoc, info);
                }
                catch (Exception)
                {
                    return default(T);
                }
            }
        }

        private class WebClient : System.Net.WebClient
        {
            public int Timeout { get; set; }

            protected override WebRequest GetWebRequest(Uri uri)
            {
                var lWebRequest = base.GetWebRequest(uri);
                lWebRequest.Timeout = Timeout;
                ((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
                return lWebRequest;
            }
        }
    }
}
