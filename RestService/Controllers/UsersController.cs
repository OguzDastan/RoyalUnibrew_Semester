using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using RestService.Managers;


namespace RestService.Controllers
{
    public class UsersController : ApiController
    {
        private static UserManager um = new UserManager();

        // GET: api/Users - currently returns empty list
        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            return users.AsEnumerable<User>();
        }

        // GET: api/Users/kasper
        [Route ("api/Users/{Uname}")]
        public User Get(string Uname)
        {
            return um.Get(Uname);
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
