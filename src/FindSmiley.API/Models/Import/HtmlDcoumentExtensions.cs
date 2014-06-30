using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using HtmlAgilityPack;

namespace FindSmiley.API.Models.Import
{
    public static class HtmlDcoumentExtensions
    {
        public static IEnumerable<VirksomhedData> FindVirksomheder(this HtmlDocument document)
        {
            var rows = document.DocumentNode.SelectNodes("//table[@class='resultTable']/tr");

            if (rows != null)
            {
                foreach (HtmlNode row in rows)
                {
                    VirksomhedData virksomhed = null;

                    try
                    {
                        virksomhed = new VirksomhedData
                        {
                            Id = int.Parse(Regex.Match(row.SelectSingleNode("./td[1]").Attributes["onclick"].Value, "virk=([0-9]*)").Groups[1].Value),
                            Navn = HttpUtility.HtmlDecode(row.SelectSingleNode("./td[1]/div[1]").InnerText),
                            Adresse = HttpUtility.HtmlDecode(row.SelectSingleNode("./td[1]/div[2]").InnerText),
                            Postnummer = Regex.Match(row.SelectSingleNode("./td[1]/div[3]").InnerText, "([0-9]*) (.*)").Groups[1].Value,
                            By = HttpUtility.HtmlDecode(Regex.Match(row.SelectSingleNode("./td[1]/div[3]").InnerText, "([0-9]*) (.*)").Groups[2].Value),
                            HarEliteSmiley = row.SelectSingleNode("./td[2]/img[@title='Elite-Smiley']") != null
                        };
                    }
                    catch
                    {
                        virksomhed = null;
                    }

                    if (virksomhed != null)
                        yield return virksomhed;
                }
            }
        }

        public static IEnumerable<KontrolrapportData> FindKontrolrapporter(this HtmlDocument document)
        {
            var rows = document.DocumentNode.SelectNodes("//table[@class='resultTable']/tr");

            if (rows != null)
            {
                foreach (HtmlNode row in rows)
                {
                    KontrolrapportData kontrolrapport = null;

                    for (int i = 3; i < 7; i++)
                    {
                        try
                        {
                            kontrolrapport = new KontrolrapportData
                            {
                                VirksomhedId = int.Parse(Regex.Match(row.SelectSingleNode("./td[1]").Attributes["onclick"].Value, "virk=([0-9]*)").Groups[1].Value),
                                Akt = int.Parse(Regex.Match(row.SelectSingleNode("./td[" + i + "]/a").Attributes["href"].Value, "akt=([0-9]*)").Groups[1].Value),
                                Kontroldato = DateTime.Parse(row.SelectSingleNode("./td[" + i + "]/a").InnerText),
                                Resultat = int.Parse(Regex.Match(row.SelectSingleNode("./td[" + i + "]/a/img").Attributes["src"].Value, "sm_([0-9]*).gif").Groups[1].Value),
                                Url = row.SelectSingleNode("./td[" + i + "]/a").Attributes["href"].Value
                            };
                        }
                        catch
                        {
                            kontrolrapport = null;
                        }

                        if (kontrolrapport != null)
                            yield return kontrolrapport;
                    }
                }
            }
        }
    }
}