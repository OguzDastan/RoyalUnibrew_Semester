using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestService.Managers;
using Models;

namespace RestService.Controllers
{
    public class ActivityController : ApiController
    {

        ActivitiesManager activitiesManager = new ActivitiesManager();
        

        // GET: api/Activity
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Activity/5
        [Route ("api/Activity/{id}")]
        public Activity Get(int id)
        {
            return activitiesManager.Get(id);
        }

        // POST: api/Activity
        public bool Post([FromBody]Activity value)
        {
            return activitiesManager.Post(value);
        }

        // PUT: api/Activity/5 //Problemer med PUT
        [Route("api/Activity/{id}")]
        public bool Put(int id, [FromBody]Activity value)
        {
            return activitiesManager.Put(id, value);
        }

        // DELETE: api/Activity/5 // prob
        [Route("api/Activity/{id}")]
        public bool Delete(int id)
        {
            return activitiesManager.Delete(id);
        }
    }
}
