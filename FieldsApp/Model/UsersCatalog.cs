using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.PointOfService;
using Windows.Storage;
using FieldsApp.Common;
using Newtonsoft.Json;

namespace FieldsApp.Model
{
    public class UsersCatalog
    {
        private const string _fileName = "Accounts.Json";
        private readonly StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;

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

        public async Task RegisterUser(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            _users.Add(new User(firstName, lastName, phoneNumber, email, password));
            await SaveToFile();
        }

        //Checks if the entered information matches with one of the accounts
        public User LogInEmailCheck(string email, string password)
        {
            try
            {
                return Users.FirstOrDefault(data => data.Email == email && data.Password == password);
            }
            catch
            {
                return null;
            }
        }

        //Actual logging in, only used after the method above checks for the existence of the account
        public void LogInEmail(string email, string password)
        {
            CurrentUser = Users.FirstOrDefault(data => data.Email == email && data.Password == password);
        }

        public async Task SaveToFile()
        {
            string json = JsonConvert.SerializeObject(_users);
            await FileIO.WriteTextAsync(await _storageFolder.CreateFileAsync(_fileName, CreationCollisionOption.ReplaceExisting), json);
        }

        public async Task LoadDomainObjects()
        {
            string loadedUsers = await FileIO.ReadTextAsync(await _storageFolder.CreateFileAsync(_fileName, CreationCollisionOption.OpenIfExists));
            //Only loads the contents of the file if it isn't empty, otherwise it would set the collection as null and break the program
            if (loadedUsers != "")
            {
                _users = JsonConvert.DeserializeObject<ObservableCollection<User>>(loadedUsers);
            }
        }

        public async Task EditUser(User loggedInUser, string newFirstName, string newLastName, string newNumber)
        {
            loggedInUser.FirstName = newFirstName;
            loggedInUser.LastName = newLastName;
            loggedInUser.PhoneNumber = newNumber;
            await SaveToFile();
        }

        public void LogOut()
        {
            CurrentUser = null;
        }
    }
}

