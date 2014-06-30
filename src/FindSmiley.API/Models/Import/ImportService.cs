using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace FindSmiley.API.Models.Import
{
    public class ImportService
    {
        private FindSmileyDbContext context;

        public ImportService(FindSmileyDbContext context)
        {
            this.context = context;
        }

        public void ImportAll()
        {
            ImportRaw(Enumerable.Range(1, 50).Select(sidenummer => string.Format("http://www.findsmiley.dk/da-DK/Searching/TableSearch.htm?searchstring=%25&vtype=detail&searchtype=all&mode=simple&display=table&dato1=&dato2=&sort=0&SearchExact=false&mapNElng=&mapNElat=&mapSWlng=&mapSWlat=&pagesz=1000&&page={0}", sidenummer)).ToArray());
        }

        public void ImportYesterday()
        {
            ImportDate(DateTime.Today.AddDays(-1));

        }
        public void ImportToday()
        {
            ImportDate(DateTime.Today);            
        }

        public void ImportDate(DateTime date)
        {
            ImportRaw(string.Format("http://www.findsmiley.dk/da-DK/Searching/TableSearch.htm?searchstring=%25&vtype=detail&searchtype=all&mode=adv&display=table&branche=0&region=0&Kaede=0&dato1={0}&dato2={0}&pagesz=1000&sort=0&SearchExact=false&mapNElng=&mapNElat=&mapSWlng=&mapSWlat=", date.ToString("dd-MM-yyyy")));
        }

        public string HttpGet(string url)
        {
            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var content = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return content;
        }

        public void Import(params string[] urls)
        {
            foreach(var url in urls)
            {
                var html = HttpGet(url);
            
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                foreach(var virksomhedData in doc.FindVirksomheder())
                {
                    var virksomhed = context.Virksomheder.Find(virksomhedData.Id);

                    var postadresse = new Postadresse { Vejadresse = virksomhedData.Adresse, By = virksomhedData.By, Postnummer = virksomhedData.Postnummer };

                    if (virksomhed == null)
                    {
                        virksomhed = new Virksomhed.Virksomhed(virksomhedData.Id, virksomhedData.Navn, postadresse, virksomhedData.HarEliteSmiley);

                        context.Virksomheder.Add(virksomhed);
                    }
                    else
                    {
                        virksomhed.Navn = virksomhedData.Navn;
                        virksomhed.Postadresse = postadresse;
                        virksomhed.HarEliteSmiley = virksomhedData.HarEliteSmiley;
                    }

                    context.SaveChanges();
                }

                foreach (var kontrolrapportData in doc.FindKontrolrapporter())
                {
                    var kontrolrapport = context.Kontrolrapporter
                        .Where(o => o.VirksomhedId == kontrolrapportData.VirksomhedId)
                        .Where(o => o.Kontroldato == kontrolrapportData.Kontroldato)
                        .FirstOrDefault();

                    if (kontrolrapport == null)
                    {
                        kontrolrapport = new Kontrolrapport.Kontrolrapport(Guid.NewGuid(), kontrolrapportData.Akt, kontrolrapportData.VirksomhedId, kontrolrapportData.Kontroldato, kontrolrapportData.Resultat, kontrolrapportData.Url);

                        context.Kontrolrapporter.Add(kontrolrapport);
                    }
                    else
                    {
                        kontrolrapport.Akt = kontrolrapportData.Akt;
                        kontrolrapport.Kontroldato = kontrolrapportData.Kontroldato;
                        kontrolrapport.Resultat = kontrolrapportData.Resultat;
                        kontrolrapport.Url = kontrolrapportData.Url;
                    }

                    context.SaveChanges();
                }
            }
        }

        public void ImportRaw(params string[] urls)
        {
            foreach (var url in urls)
            {
                var sqlConnection = new SqlConnection(context.Database.Connection.ConnectionString);
                
                sqlConnection.Open();

                var html = HttpGet(url);
                
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                foreach (var virksomhed in doc.FindVirksomheder())
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO Virksomhed (Id, Navn, Postadresse_Vejadresse, Postadresse_Postnummer, Postadresse_By, HarEliteSmiley) VALUES (@0,@1,@2,@3,@4,@5)", sqlConnection);
                        command.Parameters.AddWithValue("@0", virksomhed.Id);
                        command.Parameters.AddWithValue("@1", virksomhed.Navn);
                        command.Parameters.AddWithValue("@2", virksomhed.Adresse);
                        command.Parameters.AddWithValue("@3", virksomhed.Postnummer);
                        command.Parameters.AddWithValue("@4", virksomhed.By);
                        command.Parameters.AddWithValue("@5", virksomhed.HarEliteSmiley);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }

                foreach (var kontrolrapport in doc.FindKontrolrapporter())
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO Kontrolrapport (Id, VirksomhedId, Akt, Kontroldato, Resultat, Url) VALUES (@0,@1,@2,@3,@4,@5)", sqlConnection);
                        command.Parameters.AddWithValue("@0", Guid.NewGuid());
                        command.Parameters.AddWithValue("@1", kontrolrapport.VirksomhedId);
                        command.Parameters.AddWithValue("@2", kontrolrapport.Akt);
                        command.Parameters.AddWithValue("@3", kontrolrapport.Kontroldato);
                        command.Parameters.AddWithValue("@4", kontrolrapport.Resultat);
                        command.Parameters.AddWithValue("@5", kontrolrapport.Url);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}