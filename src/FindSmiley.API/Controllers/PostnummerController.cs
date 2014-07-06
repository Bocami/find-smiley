using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Hosting;
using System.Web.Http;
using System.Xml;

namespace FindSmiley.API.Controllers
{
    [RoutePrefix("Postnummer")]
    public class PostnummerController : ApiController
    {
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(HostingEnvironment.MapPath("~/App_Data/allepostnumredk.kml"));

            XmlElement documentElement = xmlDocument.DocumentElement;
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
            xmlNamespaceManager.AddNamespace("default", documentElement.NamespaceURI);

            var styleUrls = documentElement.SelectNodes("//default:styleUrl", xmlNamespaceManager);

            foreach (XmlNode styleUrl in styleUrls)
            {
                var name = styleUrl.ParentNode["name"].InnerText;
                Debug.WriteLine(name);

                styleUrl.InnerText = "#bad";
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(xmlDocument.OuterXml, Encoding.Unicode);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.google-earth.kml+xml");

            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            
            return response;
        }
    }
}
