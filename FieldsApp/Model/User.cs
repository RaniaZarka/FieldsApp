using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsApp.Model
{
    public class User
    {
        public User(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            UserID = firstName.ToLower() + lastName.ToLower() + phoneNumber;
            FavouriteStores = new List<Stores>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; }
        public string UserID { get; }
        public List<Stores> FavouriteStores { get; set; }

    }
}
