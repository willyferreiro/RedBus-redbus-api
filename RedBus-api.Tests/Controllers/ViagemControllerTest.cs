using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBus_api.Controllers;
using RedBus_api.Models;

namespace RedBus_api.Tests.Controllers
{
    [TestClass]
    public class ViagemControllerTest
    {
        [TestMethod]
        public void GravaDadosIniciaisViagem()
        {
            ViagemController controller = new ViagemController();
            Viagem viagem = new Viagem();

            viagem.dataInicioViagem = DateTime.Now;
            viagem.idMotorista = 1;
            viagem.posicaoInicio_latitude = 23.1;
            viagem.posicaoInicio_longitude = 10.2;
            viagem.statusViagem = (int) StatusViagem.Andamento;

            controller.PostViagem(viagem);
        }
    }
}
