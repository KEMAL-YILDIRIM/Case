using Case.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace Case.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RssParser" in both code and config file together.
    public class RssParser : IRssParser
    {
        public List<RssPage> ParseFromPage(string _uri)
        {

            List<RssPage> rssFeeds = new List<RssPage>();

            using (var client = new WebClient())
            {
                HtmlAgilityPack.HtmlDocument dochtml = new HtmlAgilityPack.HtmlDocument();
                string html = client.DownloadString(_uri);
                //byte[] data = client.DownloadData(_uri);
                //string html = Encoding.UTF8.GetString(data);
                dochtml.LoadHtml(html);

                var rssLinks = dochtml.DocumentNode.Descendants("link")
                    .Where(n => n.Attributes["type"] != null && n.Attributes["type"].Value == "application/rss+xml")
                    .Select(n => n.Attributes["href"].Value)
                    .ToList();


                foreach (var item in rssLinks)
                {
                    string xml = client.DownloadString(item);
                    if (xml != "")
                    {
                        RssPage feeds = new RssPage();
                        XDocument doc = XDocument.Parse(xml);
                        feeds.RssLink = item;
                        feeds.ContentXml = doc.ToString();
                        rssFeeds.Add(feeds);
                    }
                }

            }

            return rssFeeds;
        }
    }
}
