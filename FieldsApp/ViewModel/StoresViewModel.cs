using System.ComponentModel;
using FieldsApp.Model;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Windows.Storage;
using FieldsApp.Common;


namespace FieldsApp.ViewModel
{
    public class StoresViewModel : INotifyPropertyChanged
    {
        private Stores _domainObject;
        private readonly StoresCatalog _storesCatalog;
        private Stores _selectedStore;
        private readonly DeleteCommand _deletionCommand;
        private string _imageSource;

        public StoresViewModel()
        {
            _storesCatalog = new StoresCatalog();
            GetDomainObjects();
            _selectedStore = null;
            AddStoreCommand = new RelayCommand(AddStore);
            _deletionCommand = new DeleteCommand(_storesCatalog, this);
        }

        public ICommand AddStoreCommand { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Category { get; set; }
        public string OpeningHours { get; set; }

        public string ImageSource
        {
            get => _imageSource;
            //  set => _imageSource = "..\\Assets\\" + value;
            set => _imageSource = ApplicationData.Current.LocalFolder.Path + "\\" + value;
        }



        public void GetDomainObjects()
        {
            foreach (var c in _storesCatalog.Stores)
            {
                _domainObject = c;
            }
        }

        public Stores SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;
                OnPropertyChanged();
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }

        public DeleteCommand DeletionCommand => _deletionCommand;

        public ObservableCollection<Stores> StoreCollection => _storesCatalog.Stores;

        public void AddStore()
        {
           // _storesCatalog.AddStoreAsync(new Stores (Name, Phone, Website, Category, OpeningHours, ImageSource));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


