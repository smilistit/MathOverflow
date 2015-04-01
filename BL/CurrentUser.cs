using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BL
{
    public class CurrentUser
    {
        private static CurrentUser _instance = null;
        private UserBL _user;

        //ADD USER ID
        public string CurrUserName { get { return _user.Username; } }

        private CurrentUser(UserBL user)
        {
            _user = user;
        }

        public static CurrentUser CreateCurrentUser(UserBL user)
        {
            if (_instance == null)
                _instance = new CurrentUser(user);
            return _instance;
        }

        public static CurrentUser GetCurrentUserInstance()
        {
            return _instance;
        }

        public static int GetUserID(string username)
        {
            return DAL.UserDAL.GetUserIdByUserName(username);
        }
    }
}
