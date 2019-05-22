using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using RestService.Managers;

namespace RestService.Controllers
{
    public class WorkerController : ApiController
    {
        private WorkerManager wm = new WorkerManager();
        // GET: api/Worker
        public IEnumerable<Worker> Get()
        {
            return wm.Get();
        }

        // GET: api/Worker/5
        public Worker Get(int id)
        {
            return wm.Get(id);
        }

        // POST: api/Worker
        public bool Post([FromBody]Worker value)
        {
            return wm.Post(value);
        }

        // PUT: api/Worker/5
        public bool Put(int id, [FromBody]Worker value)
        {
            return wm.Put(id, value);
        }

        // DELETE: api/Worker/5
        public bool Delete(int id)
        {
            return wm.Delete(id);
        }
    }
}
