using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using RestService.Managers;

namespace RestService.Controllers
{
    public class LabelingController : ApiController
    {
        private static LabelingManager um = new LabelingManager();

        // GET: api/Users - currently returns empty list
        public IEnumerable<Labeling> Get()
        {
            return um.Get();
        }

        [Route("api/Labeling/{ProcessOrderNR}")]
        public IEnumerable<Labeling> Get(int ProcessOrderNR)
        {
            return um.Get(ProcessOrderNR);
        }
        
        [Route("api/Labeling/{processOrdreNr}/{hour}/{min}")]
        public Labeling Get(int processOrdreNr, int hour, int min)
        {
            TimeSpan ts = new TimeSpan(hour, min, 0);
            return um.Get(processOrdreNr, ts);
        }
        
        public bool Post([FromBody]Labeling value)
        {
            return um.Post(value);
        }
        
        public bool Put(int id, [FromBody]Labeling value)
        {
            return um.Put(id, value);
        }
        [Route("api/Labeling/{processOrdreNr}/{hour}/{min}")]
        public bool Delete(int id)
        {
            return um.Delete(id);
        }
        public bool Delete(int id, int hour, int min)
        {
            TimeSpan ts = new TimeSpan(hour, min, 0);

            return um.Delete(id, ts);
        }
    }
}
