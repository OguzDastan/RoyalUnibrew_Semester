using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestService.Controllers
{
    public class LabelingCommentController : ApiController
    {
        // GET: api/LabelingComment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LabelingComment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LabelingComment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LabelingComment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LabelingComment/5
        public void Delete(int id)
        {
        }
    }
}
