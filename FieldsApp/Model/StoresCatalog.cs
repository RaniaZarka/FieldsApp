using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsApp.Model
{
     public class StoresCatalog
    {
        public static ObservableCollection<Stores> _StoresCollection = new ObservableCollection<Stores>
        {
            new Stores("Bolia","30368964", "www.bolia.com","10.00-20.00","Home","..\\Assets\\bolia.jpeg"),
            new Stores("Bounce", "78700900","www.bounceinc.dk","10.00-20.00","Entertainment", "..\\Assets\\bounce.jpeg"),
            new Stores("BR", "","www.br.dk","10.00-20.00","Kids","..\\Assets\\BR.jpg"),
            new Stores("Dalle Valle", "32204200","www.cafedallevalle.dk","10.00-20.00","Restaurant","..\\Assets\\Dalle-Valle.jpeg"),
            new Stores("H&M", "70212200","www.hm.com","10.00-20.00","Men, Women, Kids", "..\\Assets\\hm.png"),
            new Stores("Magasin", "32470600","www.magasin.dk","10.00-20.00","Men, Women, Kids, Home","..\\Assets\\magasin.png"),
            new Stores("Matas", "32626264", "www.matas.dk","10.00-20.00", "Cosmetic, Health", "..\\Assets\\matas.jpeg"),
            new Stores("Burger King","32624262", "www.burgerking.dk", "10.00-22.00", "Restaurant", "..\\Assets\\burgerking.jpeg"),
            new Stores("Name it","32621242", "www.name-it.com", "10.00-20.00", "kids", "..\\Assets\\nameit.png" ),
            new Stores("Kaufmann", "32620034","www.kaufmann.dk","10.00-20.00", "Men", "..\\Assets\\kaufmann.jpeg")
            
            
        };

        public ObservableCollection<Stores> Stores => _StoresCollection;
        

        public void AddStore(Stores s)
        {
            _StoresCollection.Add(s);
        }

        public void Delete(string phone)
        {
             
            var Stores = _StoresCollection.FirstOrDefault(s => s.Phone == phone);
            _StoresCollection.Remove(Stores);
        }

    }
}
