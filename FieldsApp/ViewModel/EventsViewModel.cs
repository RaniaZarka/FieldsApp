using FieldsApp.Model;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FieldsApp.ViewModel
{
    public class EventsViewModel : INotifyPropertyChanged
    {
        private Events _domainObject;
        private readonly EventCatalog _eventCatalog;
        private Events _selectedEvents;
        private string _imageSource;

        public EventsViewModel()
        {
            _eventCatalog = new EventCatalog();
            _selectedEvents = null;
        }

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
            foreach (var c in _eventCatalog.Events)
            {
                _domainObject = c;
            }
        }



        public Events SelectedEvents
        {
            get => _selectedEvents;
            set
            {
                _selectedEvents = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Events> Events => _eventCatalog.Events;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
