using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakipApplication.Classlar
{
    public class Product
    {//bu class Products tablomuza erişecek veritabanındaki 
        //her bir alanını tanımlıcaz
        public int Id { get; set; }
        public String Barkod { get; set; }
        public int Stok { get; set; }
        public string Kategori { get; set; }
        public String Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Kdv { get; set; }



    }
}
