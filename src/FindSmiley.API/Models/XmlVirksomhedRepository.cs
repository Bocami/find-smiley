using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace FindSmiley.API.Models
{
    public class XmlVirksomhedRepository : IVirksomhedRepository
    {
        private readonly string filename;

        public XmlVirksomhedRepository(string filename)
        {
            this.filename = filename;
        }

        private IEnumerable<Virksomhed> Virksomheder
        {
            get
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);

                foreach (XmlNode row in xmlDocument.GetElementsByTagName("row"))
                {
                    var id = Convert.ToInt32(row.Attributes["navnelbnr"].Value);

                    var type = row.Attributes["virksomhedstype"].Value == "Detail" ? Virksomhedstyper.Detail : Virksomhedstyper.Engros;
                    var navn = row.Attributes["navn1"].Value;

                    Geo geo = Geo.Empty;

                    if (row.Attributes["Geo_Lat"] != null && row.Attributes["Geo_Lng"] != null)
                    {
                        geo = new Geo(Double.Parse(row.Attributes["Geo_Lat"].Value, CultureInfo.InvariantCulture), Double.Parse(row.Attributes["Geo_Lng"].Value, CultureInfo.InvariantCulture));
                    }

                    Postadresse postadresse = new Postadresse(string.Empty, string.Empty, string.Empty);

                    if (row.Attributes["adresse1"] != null && row.Attributes["postnr"] != null && row.Attributes["By"] != null)
                    {
                        postadresse = new Postadresse(row.Attributes["adresse1"].Value, row.Attributes["postnr"].Value, row.Attributes["By"].Value);
                    }

                    Uri url = null;

                    if (row.Attributes["URL"] != null)
                    {
                        url = new Uri(row.Attributes["URL"].Value);
                    }

                    bool harEliteSmiley = false;

                    if (row.Attributes["Elite_Smiley"] != null)
                    {
                        harEliteSmiley = row.Attributes["Elite_Smiley"].Value == "1" ? true : false;
                    }

                    List<Kontrolrapport> kontrolrapporter = new List<Kontrolrapport>();

                    if (row.Attributes["seneste_kontrol"] != null && row.Attributes["seneste_kontrol_dato"] != null)
                    {
                        kontrolrapporter.Add(new Kontrolrapport(id, 1, Convert.ToDateTime(row.Attributes["seneste_kontrol_dato"].Value), Convert.ToInt32(row.Attributes["seneste_kontrol"].Value)));
                    }

                    if (row.Attributes["naestseneste_kontrol"] != null && row.Attributes["naestseneste_kontrol_dato"] != null)
                    {
                        kontrolrapporter.Add(new Kontrolrapport(id, 2, Convert.ToDateTime(row.Attributes["naestseneste_kontrol_dato"].Value), Convert.ToInt32(row.Attributes["naestseneste_kontrol"].Value)));
                    }

                    if (row.Attributes["tredjeseneste_kontrol"] != null && row.Attributes["tredjeseneste_kontrol_dato"] != null)
                    {
                        kontrolrapporter.Add(new Kontrolrapport(id, 3, Convert.ToDateTime(row.Attributes["tredjeseneste_kontrol_dato"].Value), Convert.ToInt32(row.Attributes["tredjeseneste_kontrol"].Value)));
                    }

                    if (row.Attributes["fjerdeseneste_kontrol"] != null && row.Attributes["fjerdeseneste_kontrol_dato"] != null)
                    {
                        kontrolrapporter.Add(new Kontrolrapport(id, 4, Convert.ToDateTime(row.Attributes["fjerdeseneste_kontrol_dato"].Value), Convert.ToInt32(row.Attributes["fjerdeseneste_kontrol"].Value)));
                    }

                    yield return new Virksomhed(id, navn, type, postadresse, geo, harEliteSmiley, kontrolrapporter.ToArray());

                }
            }
        }

        public IEnumerator<Virksomhed> GetEnumerator()
        {
            return Virksomheder.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}