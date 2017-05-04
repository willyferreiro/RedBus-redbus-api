using System.IO;

namespace RedBus_api.Tests.Controllers
{
    internal class StramReader : StreamReader
    {
        private Stream responseStream;
        private object uTF8;

        public StramReader(Stream responseStream, object uTF8)
        {
            this.responseStream = responseStream;
            this.uTF8 = uTF8;
        }
    }
}