using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
        private string _userEmail;
        private string _userPassword;
        private User _loggedInUser;
        private Visibility _loginErrorVisibility = Visibility.Collapsed;
        private Visibility _loginFieldsVisibility = Visibility.Visible;
        private Visibility _userInfoVisibility = Visibility.Collapsed;
        private Visibility _registrationVisibility = Visibility.Collapsed;
        private Visibility _registrationConfirmationVisibility = Visibility.Collapsed;

        private string _registerEmail;
        private string _registerFirstName;
        private string _registerLastName;
        private string _registerPhoneNumber;
        private string _registerPassword;
        private string _registerConfirmPassword;
        private bool _registerAgreement;
        private Visibility _emailErrorVisibility = Visibility.Collapsed;
        private Visibility _firstNameErrorVisibility = Visibility.Collapsed;
        private Visibility _lastNameErrorVisibility = Visibility.Collapsed;
        private Visibility _phoneNumberErrorVisibility = Visibility.Collapsed;
        private Visibility _passwordErrorVisibility = Visibility.Collapsed;
        private Visibility _confirmPasswordErrorVisibility = Visibility.Collapsed;
        private Visibility _agreementErrorVisibility = Visibility.Collapsed;

        private Visibility _editInfoVisibility = Visibility.Collapsed;
        private string _editFirstName;
        private string _editLastName;
        private string _editPhoneNumber;

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
            RegisterCommand = new RelayCommand(RegisterUser);
            OpenRegistrationCommand = new RelayCommand(OpenRegistration);
            OpenEditCommand = new RelayCommand(OpenEditAccount);
            ConfirmEditCommand = new RelayCommand(ConfirmEdit);
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
        public Visibility RegisterVisibility
        {
            get { return _registrationVisibility; }
            set
            {
                _registrationVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility RegisterConfirmationVisibility
        {
            get { return _registrationConfirmationVisibility; }
            set
            {
                _registrationConfirmationVisibility = value;
                OnPropertyChanged();
            }
        }

        public string RegisterFirstName
        {
            get { return _registerFirstName; }
            set
            {
                _registerFirstName = value;
                OnPropertyChanged();
            }
        }
        public string RegisterLastName
        {
            get { return _registerLastName; }
            set
            {
                _registerLastName = value;
                OnPropertyChanged();
            }
        }
        public string RegisterEmail
        {
            get { return _registerEmail; }
            set
            {
                _registerEmail = value;
                OnPropertyChanged();
            }
        }
        public string RegisterPhoneNumber
        {
            get { return _registerPhoneNumber; }
            set
            {
                _registerPhoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string RegisterPassword
        {
            get { return _registerPassword; }
            set
            {
                _registerPassword = value;
                OnPropertyChanged();
            }
        }
        public string RegisterConfirmPassword
        {
            get { return _registerConfirmPassword; }
            set
            {
                _registerConfirmPassword = value;
                OnPropertyChanged();
            }
        }
        public bool RegisterAgreement
        {
            get { return _registerAgreement; }
            set
            {
                _registerAgreement = value;
                OnPropertyChanged();
            }
        }

        public Visibility EmailErrorVisibility
        {
            get { return _emailErrorVisibility; }
            set
            {
                _emailErrorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility FirstNameErrorVisibility
        {
            get { return _firstNameErrorVisibility; }
            set
            {
                _firstNameErrorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility LastNameErrorVisibility
        {
            get { return _lastNameErrorVisibility; }
            set
            {
                _lastNameErrorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility PhoneNumberErrorVisibility
        {
            get { return _phoneNumberErrorVisibility; }
            set
            {
                _phoneNumberErrorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility PasswordErrorVisibility
        {
            get { return _passwordErrorVisibility; }
            set
            {
                _passwordErrorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility PasswordConfirmErrorVisibility
        {
            get { return _confirmPasswordErrorVisibility; }
            set
            {
                _confirmPasswordErrorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility AgreementErrorVisibility
        {
            get { return _agreementErrorVisibility; }
            set
            {
                _agreementErrorVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility EditInfoVisibility
        {
            get { return _editInfoVisibility; }
            set
            {
                _editInfoVisibility = value;
                OnPropertyChanged();
            }
        }
        public string EditFirstName
        {
            get { return _editFirstName; }
            set
            {
                _editFirstName = value;
                OnPropertyChanged();
            }
        }
        public string EditLastName
        {
            get { return _editLastName; }
            set
            {
                _editLastName = value;
                OnPropertyChanged();
            }
        }
        public string EditPhoneNumber
        {
            get { return _editPhoneNumber; }
            set
            {
                _editPhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand OpenRegistrationCommand { get; set; }
        public ICommand OpenEditCommand { get; set; }
        public ICommand ConfirmEditCommand { get; set; }

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
                RegisterConfirmationVisibility = Visibility.Collapsed;
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

        public void RegisterUser()
        {
            CollapseAllErrors();
            //Checks if string only contains letters
            if (Regex.IsMatch(RegisterFirstName, @"^[a-zA-Z]+$"))
            {
                CollapseAllErrors();
                if (Regex.IsMatch(RegisterLastName, @"^[a-zA-Z]+$"))
                {
                    CollapseAllErrors();
                    if (RegisterEmail.Contains('@') && RegisterEmail.Contains('.'))
                    {
                        CollapseAllErrors();
                        if (Regex.IsMatch(RegisterPhoneNumber, @"^[0-9]+$"))
                        {
                            CollapseAllErrors();
                            if (RegisterPassword != null && RegisterPassword.Length >= 6)
                            {
                                CollapseAllErrors();
                                if (RegisterConfirmPassword != null && RegisterConfirmPassword == RegisterPassword)
                                {
                                    CollapseAllErrors();
                                    if (RegisterAgreement)
                                    {
                                        CollapseAllErrors();
                                        UsersCatalog.Instance.RegisterUser(RegisterFirstName, RegisterLastName, RegisterPhoneNumber, RegisterEmail, RegisterPassword);
                                        RegisterVisibility = Visibility.Collapsed;
                                        RegisterFirstName = null;
                                        RegisterLastName = null;
                                        RegisterEmail = null;
                                        RegisterPhoneNumber = null;
                                        RegisterPassword = null;
                                        RegisterConfirmPassword = null;
                                        RegisterAgreement = false;
                                        RegisterConfirmationVisibility = Visibility.Visible;
                                        LoginFieldsVisibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        AgreementErrorVisibility = Visibility.Visible;
                                    }
                                }
                                else
                                {
                                    PasswordConfirmErrorVisibility = Visibility.Visible;
                                }
                            }
                            else
                            {
                                PasswordErrorVisibility = Visibility.Visible;
                            }
                        }
                        else
                        {
                            PhoneNumberErrorVisibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        EmailErrorVisibility = Visibility.Visible;
                    }
                }
                else
                {
                    LastNameErrorVisibility = Visibility.Visible;
                }
            }
            else
            {
                FirstNameErrorVisibility = Visibility.Visible;
            }
        }

        public void OpenRegistration()
        {
            LoginFieldsVisibility = Visibility.Collapsed;
            LoginErrorVisibility = Visibility.Collapsed;
            RegisterVisibility = Visibility.Visible;
        }

        public void OpenEditAccount()
        {
            LoginFieldsVisibility = Visibility.Collapsed;
            RegisterVisibility = Visibility.Collapsed;
            CollapseAllErrors();
            UserInfoVisibility = Visibility.Collapsed;
            EditInfoVisibility = Visibility.Visible;
        }

        public void ConfirmEdit()
        {
            if (EditFirstName != null && Regex.IsMatch(EditFirstName, @"^[a-zA-Z]+$"))
            {
                CollapseAllErrors();
                if (EditLastName != null && Regex.IsMatch(EditLastName, @"^[a-zA-Z]+$"))
                {
                    CollapseAllErrors();
                    if (EditPhoneNumber != null && Regex.IsMatch(EditPhoneNumber, @"^[0-9]+$"))
                    {
                        CollapseAllErrors();
                        UsersCatalog.Instance.EditUser(LoggedInUser, EditFirstName, EditLastName, EditPhoneNumber);
                        EditFirstName = null;
                        EditLastName = null;
                        EditPhoneNumber = null;
                        EditInfoVisibility = Visibility.Collapsed;
                        UserInfoVisibility = Visibility.Visible;
                        //This triggers OnPropertyChanged() to refresh the page, there's probably a better way to do this but this is easy
                        LoggedInUser = LoggedInUser;
                    }
                    else
                    {
                        PhoneNumberErrorVisibility = Visibility.Visible;
                    }
                }
                else
                {
                    LastNameErrorVisibility = Visibility.Visible;
                }
            }
            else
            {
                FirstNameErrorVisibility = Visibility.Visible;
            }
        }

        private void CollapseAllErrors()
        {
            FirstNameErrorVisibility = Visibility.Collapsed;
            LastNameErrorVisibility = Visibility.Collapsed;
            EmailErrorVisibility = Visibility.Collapsed;
            PhoneNumberErrorVisibility = Visibility.Collapsed;
            PasswordErrorVisibility = Visibility.Collapsed;
            PasswordConfirmErrorVisibility = Visibility.Collapsed;
            AgreementErrorVisibility = Visibility.Collapsed;
            LoginErrorVisibility = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

