using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsApp.Model
{
    public class Admin
    {
        private string Username;
        private string Password;

        public Admin()
        {
            Username = "IAmAdmin";
            Password = "1234";
        }

        public bool CanEnter(string username, string password)
        {
            if (username==Username&&password==Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
