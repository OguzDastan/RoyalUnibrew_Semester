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
        public static Session Current {
            get
            {
                if (_activeSession == null)
                {
                    _activeSession = new Session();
                    return _activeSession;
                }

                return _activeSession;
            } }
        public static User CurrentUser
        {
            get { return _currUser; }
        }
        public Session()
        {
        }

        private static User _currUser;
         
        private List<User> getUsersInDb()
        {
            List<User> users = new List<User>();

            using (HttpClient client = new HttpClient())
            {
                Task<string> result = client.GetStringAsync(new Uri("http://localhost:54926/api/Users/"));
                string jsonString = result.Result;
                users = JsonConvert.DeserializeObject<List<User>>(jsonString);
            }

            return users;
        }
       


        public bool Login(string UserName, string Password)
        {
            _currUser = new User(){UserName = UserName, Password = Password, AccessLevel = User.AccessLevels.USER};

            if (CurrentUser.UserName == "admin")
            {
                CurrentUser.AccessLevel = User.AccessLevels.ADMIN;
            }

            return true;
        }
    }
}
