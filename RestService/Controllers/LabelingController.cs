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
            List<Labeling> Labels = new List<Labeling>();
            return Labels.AsEnumerable<Labeling>();
        }

        // GET: api/Users/kasper
        [Route("api/Users/{processOrdreNr}/{timeOfTest}")]
        public Labeling Get(int processOrdreNr, string timeOfTest)
        {
            string sec = timeOfTest.Substring(4);
            timeOfTest = timeOfTest.Remove(4);
            string min = timeOfTest.Substring(2);
            string hour = timeOfTest.Remove(2);

            //DateTime obj = new DateTime();
            string date = "2019-08-23'3'22 - 40 - 30";

            DateTime createDate = DateTime.ParseExact(date, "yyyy-MM-dd'T'hh-mm-ss", CultureInfo.InvariantCulture);
            return um.Get(processOrdreNr, DateTime.Parse(timeOfTest));
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
