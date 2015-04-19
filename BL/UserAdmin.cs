using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class UserAdmin : UserBL
    {
        public UserAdmin(string username, string firstName, string lastName = "", string password = "")
            : base(username, password, firstName, lastName)
        {

        }
    }
}
