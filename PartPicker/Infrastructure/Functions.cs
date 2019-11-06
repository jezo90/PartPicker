using HtmlAgilityPack;
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PartPicker.Infrastructure
{
    public class Functions
    {
        public static string GetPrice(Cpu c)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(c.Link);

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(html);
                if (c.Shop.Name == "Sferis")
                {
                    if (html.ToString().Contains("Produkt chwilowo niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        return (prize.InnerHtml.ToString());
                    }
                }
                else if (c.Shop.Name == "Media Expert")
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//p[@class='" + c.Shop.Class + "']");
                    var prizeMod = prize.InnerHtml.ToString().Replace("<span>", ",").Replace("</span>", "") + " zł";
                    return (prizeMod);
                }
                else if (c.Shop.Name == "Vobis")
                {
                    if (html.ToString().Contains("Produkt niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        var prizeMod = prize.InnerHtml.ToString().Replace("PLN", "zł");
                        return (prizeMod);
                    }
                }
                else
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']");
                    return (prize.InnerHtml.ToString());
                }
            }
        }

        public static string GetPrice(Gpu c)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(c.Link);

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(html);
                if (c.Shop.Name == "Sferis")
                {
                    if (html.ToString().Contains("Produkt chwilowo niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        return (prize.InnerHtml.ToString());
                    }
                }
                else if (c.Shop.Name == "Media Expert")
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//p[@class='" + c.Shop.Class + "']");
                    var prizeMod = prize.InnerHtml.ToString().Replace("<span>", ",").Replace("</span>", "") + " zł";
                    return (prizeMod);
                }
                else if (c.Shop.Name == "Vobis")
                {
                    if (html.ToString().Contains("Produkt niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        var prizeMod = prize.InnerHtml.ToString().Replace("PLN", "zł");
                        return (prizeMod);
                    }
                }
                else
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']");
                    return (prize.InnerHtml.ToString());
                }
            }
        }

        public static string GetPrice(Ram c)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(c.Link);

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(html);
                if (c.Shop.Name == "Sferis")
                {
                    if (html.ToString().Contains("Produkt chwilowo niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        return (prize.InnerHtml.ToString());
                    }
                }
                else if (c.Shop.Name == "Media Expert")
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//p[@class='" + c.Shop.Class + "']");
                    var prizeMod = prize.InnerHtml.ToString().Replace("<span>", ",").Replace("</span>", "") + " zł";
                    return (prizeMod);
                }
                else if (c.Shop.Name == "Vobis")
                {
                    if (html.ToString().Contains("Produkt niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        var prizeMod = prize.InnerHtml.ToString().Replace("PLN", "zł");
                        return (prizeMod);
                    }
                }
                else
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']");
                    return (prize.InnerHtml.ToString());
                }
            }
        }


        public static string GetPrice(Storage c)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(c.Link);

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(html);
                if (c.Shop.Name == "Sferis")
                {
                    if (html.ToString().Contains("Produkt chwilowo niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        return (prize.InnerHtml.ToString());
                    }
                }
                else if (c.Shop.Name == "Media Expert")
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//p[@class='" + c.Shop.Class + "']");
                    var prizeMod = prize.InnerHtml.ToString().Replace("<span>", ",").Replace("</span>", "") + " zł";
                    return (prizeMod);
                }
                else if (c.Shop.Name == "Vobis")
                {
                    if (html.ToString().Contains("Produkt niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        var prizeMod = prize.InnerHtml.ToString().Replace("PLN", "zł");
                        return (prizeMod);
                    }
                }
                else
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']");
                    return (prize.InnerHtml.ToString());
                }
            }
        }

        public static string GetPrice(Case c)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(c.Link);

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(html);
                if (c.Shop.Name == "Sferis")
                {
                    if (html.ToString().Contains("Produkt chwilowo niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        return (prize.InnerHtml.ToString());
                    }
                }
                else if (c.Shop.Name == "Media Expert")
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//p[@class='" + c.Shop.Class + "']");
                    var prizeMod = prize.InnerHtml.ToString().Replace("<span>", ",").Replace("</span>", "") + " zł";
                    return (prizeMod);
                }
                else if (c.Shop.Name == "Vobis")
                {
                    if (html.ToString().Contains("Produkt niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        var prizeMod = prize.InnerHtml.ToString().Replace("PLN", "zł");
                        return (prizeMod);
                    }
                }
                else
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']");
                    return (prize.InnerHtml.ToString());
                }
            }
        }


        public static string GetPrice(Psu c)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(c.Link);

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(html);
                if (c.Shop.Name == "Sferis")
                {
                    if (html.ToString().Contains("Produkt chwilowo niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        return (prize.InnerHtml.ToString());
                    }
                }
                else if (c.Shop.Name == "Media Expert")
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//p[@class='" + c.Shop.Class + "']");
                    var prizeMod = prize.InnerHtml.ToString().Replace("<span>", ",").Replace("</span>", "") + " zł";
                    return (prizeMod);
                }
                else if (c.Shop.Name == "Vobis")
                {
                    if (html.ToString().Contains("Produkt niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        var prizeMod = prize.InnerHtml.ToString().Replace("PLN", "zł");
                        return (prizeMod);
                    }
                }
                else
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']");
                    return (prize.InnerHtml.ToString());
                }
            }
        }

        public static string GetPrice(Mobo c)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(c.Link);

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(html);
                if (c.Shop.Name == "Sferis")
                {
                    if (html.ToString().Contains("Produkt chwilowo niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        return (prize.InnerHtml.ToString());
                    }
                }
                else if (c.Shop.Name == "Media Expert")
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//p[@class='" + c.Shop.Class + "']");
                    var prizeMod = prize.InnerHtml.ToString().Replace("<span>", ",").Replace("</span>", "") + " zł";
                    return (prizeMod);
                }
                else if (c.Shop.Name == "Vobis")
                {
                    if (html.ToString().Contains("Produkt niedostępny"))
                    {
                        return ("Produkt niedostępny");
                    }
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']/span");
                        var prizeMod = prize.InnerHtml.ToString().Replace("PLN", "zł");
                        return (prizeMod);
                    }
                }
                else
                {
                    var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']");
                    return (prize.InnerHtml.ToString());
                }
            }

        }

    }
}