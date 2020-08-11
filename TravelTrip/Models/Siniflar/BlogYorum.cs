using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTrip.Models.Siniflar
{
    public class BlogYorum
    {//IEnumerable belli sayıdaki değerleri koleksiyon formatında toplayan yapıdır
     //IEnumerable sayesinde bir VİEW içerisinde birden fazla değer çekebileceğiz

        public IEnumerable<Blog> Deger1 { get; set; }
        public IEnumerable<Yorumlar> Deger2 { get; set;}
        public IEnumerable<Blog> Deger3 { get; set; }
             
    }
}