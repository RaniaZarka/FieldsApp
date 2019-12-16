using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsApp.Model
{
    class Admin: User
    {
        public Admin(string firstName, string lastName, string phoneNumber, string email, string password):base(firstName, lastName, phoneNumber, email, password)
        {

        }
    }
}
