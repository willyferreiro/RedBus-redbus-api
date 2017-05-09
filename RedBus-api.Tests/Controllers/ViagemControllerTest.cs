using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBus_api.Controllers;
using RedBus_api.Models;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Results;
using System.Web.Mvc;
using Moq;

namespace RedBus_api.Tests.Controllers
{
    [TestClass]
    public class ViagemControllerTest
    {
        [TestMethod]
        public void TestaPostInicioDaViagem()
        {
            Viagem viagem = new Viagem();

            viagem.idViagem = 10;
            viagem.dataInicioViagem = DateTime.Now;
            viagem.idMotorista = 1;
            viagem.posicaoInicio_latitude = 23.1;
            viagem.posicaoInicio_longitude = 10.2;
            viagem.statusViagem = (int)StatusViagem.Andamento;


            // Arrange
            var mockRepository = new Mock<redbusdb>();
            ViagemController controller = new ViagemController(mockRepository.Object);

            IHttpActionResult actionResult = controller.PostViagem(viagem);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Viagem>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(10, createdResult.RouteValues["id"]);
        }
    }
}
