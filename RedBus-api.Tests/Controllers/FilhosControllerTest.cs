using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBus_api;
using RedBus_api.Controllers;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System;
using System.Text;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using RedBus_api.Models;
using Newtonsoft.Json;
using System.Web.Http.Results;

namespace RedBus_api.Tests.Controllers
{
    [TestClass]
    public class FilhosControllerTest
    {
        [TestMethod]
        public void GetFilho()
        {
            var controller = new FilhoController();
            var actionResult = controller.GetFilhos(2);
            var response = actionResult as OkNegotiatedContentResult<List<Filho>>;

            Assert.IsNotNull(response);
            var livros = response.Content;
            Assert.AreEqual(2, livros.Count);
        }
        
    }
}
