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
        public static string GetPrice<T>(T a)
        {
            if (a is Cpu)
            {
                Cpu c = a as Cpu;

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
                    else
                    {
                        var prize = pageDocument.DocumentNode.SelectSingleNode("//div[@class='" + c.Shop.Class + "']");
                        return (prize.InnerHtml.ToString());
                    }
                }
            }
            else
                return "0";
        }
    }
}