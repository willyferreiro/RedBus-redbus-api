using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedBus_api.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return string.Empty;
        }

        public string Get(int id)
        {
            return string.Empty;
        }

        public string GetAll()
        {
            return string.Empty;
        }

        public string GetAll(int id)
        {
            return string.Empty;
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
