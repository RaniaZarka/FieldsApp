using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsApp.Model
{
    public class EventCatalog
    {
        public static ObservableCollection<Events> _EventCollection = new ObservableCollection<Events>
        {
            new Events("H&M","Summer Sale","www.H&M.dk","8-22","Clothes","..\\Assets\\BlackFriday.jpg"),
            new Events("Index","Black Friday","www.Index.dk","8-21","Clothes","..\\Assets\\matas.jpeg"),
            new Events("Elly","Gift Saturday","www.Elly.dk","10-22","Clothes","..\\Assets\\SummerSale.jpg"),
            new Events("Bilka","Friday Lottery","+459687123","8-22","FoodStore","..\\Assets\\Halloween.jpg")
        };

        public ObservableCollection<Events> Events => _EventCollection;


    }
}