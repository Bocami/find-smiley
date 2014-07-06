using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            // 

            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://www.findsmiley.dk/xml/allekontrolresultater.xml", @"c:\temp\allekontrolresultater.txt");
        }
    }
}
