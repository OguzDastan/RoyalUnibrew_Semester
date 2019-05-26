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
    public class ProcessActivityController : ApiController
    {
        ProcessActivityManager processActivityManager = new ProcessActivityManager();

        // GET: api/ProcessActivity
        public IEnumerable<ProcessActivity> Get()
        {
            return processActivityManager.Get();
        }

        // GET: api/ProcessActivity/{ProcessOrderNR}
        [Route("api/ProcessActivity/{id}")]
        public ProcessActivity Get(int id)
        {
            return processActivityManager.Get(id);
        }

        // POST: api/ProcessActivity
        public bool Post([FromBody]ProcessActivity value)
        {
            return processActivityManager.Post(value);
        }

        // DELETE: api/ProcessActivity/5
        [Route("api/ProcessActivity/{PONR}/{ActivityID}")]
        public bool Delete(int PONR, int ActivityID)
        {
            return processActivityManager.Delete(PONR, ActivityID);
        }
    }
}
