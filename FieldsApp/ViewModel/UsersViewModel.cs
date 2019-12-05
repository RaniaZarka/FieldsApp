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
using FieldsApp.Common;
using FieldsApp.Model;

namespace FieldsApp.ViewModel
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private UsersCatalog _usersCatalog;
        private readonly DeleteCommand _deletionCommand;


        private User _loggedInUser = UsersCatalog.Instance.CurrentUser;
        private bool _showUserData;
        private string _userEmail;
        private string _userPassword;
        private bool _wasLoginSuccessful = false;

        public UsersViewModel()
        {
            _usersCatalog = UsersCatalog.Instance;
            LogInCommand = new RelayCommand(LogIn);
        }

        public ICommand AddStoreCommand { get; set; }

        public User LoggedInUser
        {
            get { return _loggedInUser; }
        }

        public bool ShowUserData { get; set; }
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
        public bool WasLoginUnsuccessful { get; set; }

        public ICommand LogInCommand { get; set; }

        public void LogIn()
        {
            if (UsersCatalog.Instance.LogInEmail(UserEmail, UserPassword) != null)
            {
                UsersCatalog.Instance.LogInEmail(UserEmail, UserPassword);
                WasLoginUnsuccessful = false;
            }
            else
            {
                WasLoginUnsuccessful = true;
                OnPropertyChanged();
            }
        }


        public DeleteCommand DeletionCommand => _deletionCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

