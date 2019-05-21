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
    public class LabelingCommentController : ApiController
    {
        LabelingCommentManager LabelingCommentManager = new LabelingCommentManager();


        // GET: api/LabelingComment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET: api/LabelingComment/5
        [Route("api/LabelingComment/{id}")]
        public LabelingComment Get(int id)
        {
            return LabelingCommentManager.Get(id);
        }

        // POST: api/LabelingComment
        public bool Post([FromBody]LabelingComment value)
        {
            return LabelingCommentManager.Post(value);
        }

        // PUT: api/LabelingComment/5 
        [Route("api/LabelingComment/{id}")]
        public bool Put(int id, [FromBody]LabelingComment value)
        {
            return LabelingCommentManager.Put(id, value);
        }

        // DELETE: api/LabelingComment/5 
        [Route("api/LabelingComment/{id}")]
        public bool Delete(int id)
        {
            return LabelingCommentManager.Delete(id);
        }
    }
}
