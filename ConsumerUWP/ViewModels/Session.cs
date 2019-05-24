using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsumerUWP.ViewModels
{
    class Session
    {
        private static Session _activeSession;
        public static Session Current
        {
            get
            {
                if (_activeSession == null)
                {
                    _activeSession = new Session();
                    return _activeSession;
                }

                return _activeSession;
            }
        }
        public static User CurrentUser
        {
            get { return _currUser; }
            set { _currUser = value; }
        }
        public Session()
        {
        }

        private static User _currUser;

        public User LookupUser(string UserName)
        {
            User u = null;

            //Ask the API for a User object, look up by Username (Primary Key)
            using (HttpClient client = new HttpClient())
            {
                //httpGet the api (Ask the rest service)
                Task<string> result = client.GetStringAsync(new Uri("http://localhost:54926/api/Users/" + UserName));
                string jsonString = result.Result;
                //Convert the resulting JsonString, into a "User" described in the Model.dll lib.
                u = JsonConvert.DeserializeObject<User>(jsonString);
            }
            return u;
        }



        public bool Login(string UserName, string Password)
        {
            //get the user login credentials from ui, and look for a match in database
            _currUser = new User() { UserName = UserName, Password = Password };

            User DBUser = LookupUser(UserName); //Chance of null value
            if (DBUser == null) return false;

            //if the password and username matches the database, return true (login success)
            if (_currUser.UserName == DBUser.UserName
                && _currUser.Password == DBUser.Password)
            {
                //Set the logged in user, to have the acceslevel denoted in the database
                _currUser = DBUser;
                return true;
            }
            //else return false (Login not possible)
            return false;
        }
    }
}
