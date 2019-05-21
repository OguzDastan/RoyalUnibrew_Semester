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
    public class PalletCheckController : ApiController
    {

        PalletCheckManager palletCheckManager = new PalletCheckManager();

        // GET: api/PalletCheck
        public IEnumerable<PalletCheck> Get()
        {
            return palletCheckManager.Get();
        }

        [Route("api/PalletCheck/{id}/")]
        public IEnumerable<PalletCheck> Get(int id)
        {
            return palletCheckManager.Get(id);
        }

        [Route("api/PalletCheck/{id}/{hour}/{min}")]
        public PalletCheck Get(int id, int hour, int min)
        {
            TimeSpan ts = new TimeSpan(hour, min, 0);
            return palletCheckManager.Get(id, ts);
        }

        // POST: api/PalletCheck
        public bool Post([FromBody]PalletCheck value)
        {
            return palletCheckManager.Post(value);
        }

        // PUT: api/PalletCheck/5
        [Route("api/PalletCheck/{id}")]
        public bool Put(int id, [FromBody]PalletCheck value)
        {
            return palletCheckManager.Put(id, value);
        }

        // DELETE: api/PalletCheck/5
        [Route("api/PalletCheck/{id}")]
        public bool Delete(int id)
        {
            return palletCheckManager.Delete(id);
        }
        [Route("api/PalletCheck/{id}/{hour}/{min}")]
        public bool Delete(int id, int hour, int min)
        {
            TimeSpan ts = new TimeSpan(hour, min, 0);
            return palletCheckManager.Delete(id, ts);
        }
    }
}