using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class UserAdmin : UserBL
    {
        public UserAdmin(string userName, string firstName, string lastName, string password)
            : base(userName, password, firstName, lastName)
        {

        }
    }
}
