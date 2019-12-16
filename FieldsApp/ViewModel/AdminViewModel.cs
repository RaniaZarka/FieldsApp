using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldsApp.Model;

namespace FieldsApp.ViewModel
{
    class AdminViewModel
    {
        private Admin admin;

        public AdminViewModel()
        {
            admin = new Admin();
        }

        public bool CanEnter(string username, string password)
        {
            if (admin.CanEnter(username, password))
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
