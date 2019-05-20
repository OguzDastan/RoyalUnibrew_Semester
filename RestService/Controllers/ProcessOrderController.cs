using RestService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;

namespace RestService.Controllers
{
    public class ProcessOrderController : ApiController
    {
        static ProcessOrderManager poMan = new ProcessOrderManager();
        // GET: api/ProcessOrder
        public IEnumerable<ProcessOrdre> Get()
        {
            return poMan.Get();
        }

        // GET: api/ProcessOrder/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProcessOrder
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProcessOrder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProcessOrder/5
        public void Delete(int id)
        {
        }
    }
}
