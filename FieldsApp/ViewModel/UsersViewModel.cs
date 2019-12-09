using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using FieldsApp.Common;
using FieldsApp.Model;
using FieldsApp.View;

namespace FieldsApp.ViewModel
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private UsersCatalog _usersCatalog;
        private readonly DeleteCommand _deletionCommand;
        private string _userEmail;
        private string _userPassword;
        private User _loggedInUser;
        private Visibility _loginErrorVisibility = Visibility.Collapsed;
        private Visibility _loginFieldsVisibility = Visibility.Visible;
        private Visibility _userInfoVisibility = Visibility.Collapsed;

        public UsersViewModel()
        {
            //Checks if there is a logged in user to make sure that you don't see the login page again after changing pages
            if(LoggedInUser != null)
            {
                LoginFieldsVisibility = Visibility.Collapsed;
                UserInfoVisibility = Visibility.Visible;
            }
            _usersCatalog = UsersCatalog.Instance;
            LogInCommand = new RelayCommand(LogIn);
            LogOutCommand = new RelayCommand(LogOut);
        }

        public User LoggedInUser {
            get { return UsersCatalog.Instance.CurrentUser; }
            set
            {
                _loggedInUser = value;
                OnPropertyChanged();
            }
        }

        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged();
            }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoginErrorVisibility
        {
            get { return _loginErrorVisibility; }
            set
            {
                _loginErrorVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoginFieldsVisibility
        {
            get { return _loginFieldsVisibility; }
            set
            {
                _loginFieldsVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility UserInfoVisibility
        {
            get { return _userInfoVisibility; }
            set
            {
                _userInfoVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        /*First calls a method with the User return type to check if the user exists, then calls a method which logs the user in in the
         UsersCatalog class
        */
        public void LogIn()
        {
            if (UsersCatalog.Instance.LogInEmailCheck(UserEmail, UserPassword) != null)
            {
                UsersCatalog.Instance.LogInEmail(UserEmail, UserPassword);
                LoggedInUser = UsersCatalog.Instance.CurrentUser;
                LoginErrorVisibility = Visibility.Collapsed;
                UserEmail = null;
                UserPassword = null;
                LoginFieldsVisibility = Visibility.Collapsed;
                UserInfoVisibility = Visibility.Visible;
            }
            else
            {
                LoginErrorVisibility = Visibility.Visible;
                UserEmail = null;
                UserPassword = null;
            }
        }

        public void LogOut()
        {
            UsersCatalog.Instance.LogOut();
            LoggedInUser = null;
            LoginFieldsVisibility = Visibility.Visible;
            UserInfoVisibility = Visibility.Collapsed;
        }


        public DeleteCommand DeletionCommand => _deletionCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

