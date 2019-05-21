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
        public ProcessOrdre Get(int id)
        {
            return poMan.Get(id);
        }

        // POST: api/ProcessOrder
        public bool Post([FromBody]ProcessOrdre value)
        {
            return poMan.Post(value);
        }

        // PUT: api/ProcessOrder/5
        public bool Put(int id, [FromBody]ProcessOrdre value)
        {
            return poMan.Put(value);
        }

        // DELETE: api/ProcessOrder/5
        public bool Delete(int id)
        {
            return poMan.Delete(id);
        }
    }
}
