using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsApp.Model
{
   public class Stores
    {
        public Stores()
        {
        }

        public Stores(string name, string phone, string website, string openingHours,string category, string picture)
        {
            Name = name;
            Phone = phone;
            Website = website;
            OpeningHours = openingHours;
            Category = category;
            ImageSource = picture;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string OpeningHours { get; set; }
        public string Category { get; set; }
        public string ImageSource { get; set; }
    }
}
