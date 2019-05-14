using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Models;

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
        public Session()
        {
        }

        private static User _currUser;

        public static User CurrentUser
        {
            get { return _currUser; }
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
