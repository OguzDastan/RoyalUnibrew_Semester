﻿using System;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/PalletCheck/{id}/{hour}/{min}")]
        public PalletCheck Get(int id, int hour, int min)
        {
            return palletCheckManager.Get(id, new TimeSpan(hour, min, 0));
        }

        // POST: api/PalletCheck
        public bool Post([FromBody]PalletCheck value)
        {
            return palletCheckManager.Post(value);
        }

        // PUT: api/PalletCheck/5
        [Route("api/Activity/{id}")]
        public bool Put(int id, [FromBody]PalletCheck value)
        {
            return palletCheckManager.Put(id, value);
        }

        // DELETE: api/PalletCheck/5
        [Route("api/Activity/{id}")]
        public bool Delete(int id)
        {
            return palletCheckManager.Delete(id);
        }
    }
}
