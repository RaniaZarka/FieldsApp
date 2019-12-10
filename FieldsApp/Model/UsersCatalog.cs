﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.PointOfService;

namespace FieldsApp.Model
{
    class UsersCatalog
    {
        //Singleton code
        private static UsersCatalog _instance = null;
        private UsersCatalog() { }
        public static UsersCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsersCatalog();
                }
                return _instance;
            }
        }

        private ObservableCollection<User> _users = new ObservableCollection<User>
        {
            new User("Sven", "Svensson", "+46 11 111 11 11", "asd@gmail.com", "1234")
        };
        public ObservableCollection<User> Users => _users;

        public User CurrentUser { get; set; }

        public void RegisterUser(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            _users.Add(new User(firstName, lastName, phoneNumber, email, password));
        }

        public User LogInEmail(string email, string password)
        {
            if (UsersCatalog.Instance.Users.FirstOrDefault(data => data.Email == email && data.Password == password) != null)
            {
                return UsersCatalog.Instance.Users.FirstOrDefault(data =>
                    data.Email == email && data.Password == password);
            }
            else
            {
                return null;
            }
        }

        public User LogInPhone(string phoneNumber, string password)
        {
            if (UsersCatalog.Instance.Users.FirstOrDefault(data => data.PhoneNumber == phoneNumber && data.Password == password) != null)
            {
                CurrentUser = UsersCatalog.Instance.Users.FirstOrDefault(data =>
                    data.Email == phoneNumber && data.Password == password);
                return UsersCatalog.Instance.Users.FirstOrDefault(data =>
                    data.Email == phoneNumber && data.Password == password);
            }
            else
            {
                return null;
            }
        }

        public void LogOut()
        {
            CurrentUser = null;
        }
    }
}

