using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBus_api;
using RedBus_api.Controllers;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System;
using System.Text;

namespace RedBus_api.Tests.Controllers
{
    [TestClass]
    public class FilhosControllerTest
    {
        [TestMethod]
        public void Get()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/");
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StramReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.Write(conteudo);
            Console.Read();
        }
        
    }
}
