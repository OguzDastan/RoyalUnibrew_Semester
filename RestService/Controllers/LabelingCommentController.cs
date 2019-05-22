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
        LabelingCommentManager labelingCommentManager = new LabelingCommentManager();


        // GET: api/LabelingComment
        public IEnumerable<LabelingComment> Get()
        {
            return labelingCommentManager.Get();
        }

        // GET: api/LabelingComment/5
        [Route("api/LabelingComment/{id}")]
        public LabelingComment Get(int id)
        {
            return labelingCommentManager.Get(id);
        }

        // POST: api/LabelingComment
        public bool Post([FromBody]LabelingComment value)
        {
            return labelingCommentManager.Post(value);
        }

        // PUT: api/LabelingComment/5 
        [Route("api/LabelingComment/{id}")]
        public bool Put(int id, [FromBody]LabelingComment value)
        {
            return labelingCommentManager.Put(id, value);
        }

        // DELETE: api/LabelingComment/5 
        [Route("api/LabelingComment/{id}")]
        public bool Delete(int id)
        {
            return labelingCommentManager.Delete(id);
        }
    }
}
