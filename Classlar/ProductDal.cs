using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UrunTakipApplication.Classlar
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\DbProduct.mdf;Integrated Security = True");
        //connection string bağlantısı yaptık Datasouce server name
        public List<Product> UrunLeriGetir()
        {
            BaglantiKontrol();
            SqlCommand command = new SqlCommand("select *from Products", _connection);
            //bağlantı ismi ve çekilecek veriler için isim ister
            SqlDataReader reader = command.ExecuteReader();
            //VERİTABANINDAN veri okuyacağız
            //ürün listesi döndüreceğiz liste tanımladım 
            List<Product> products = new List<Product>();
            while (reader.Read())
            {//reader okunacak read değeri ile döngüye girecek 
                Product product = new Product()
                //burada bi ürün nesnesi oluşturacağız 
                {//kayıtları okuruz 
                    Id = (int)reader[0],
                    Barkod = reader[1].ToString(),
                    Stok  = Convert.ToInt32(reader[2]),
                    Kategori = reader[3].ToString(),
                    Name =reader[4].ToString(),
                    UnitPrice = Convert.ToDecimal(reader[5]),
                    SalePrice = Convert.ToDecimal(reader[6]),
                    Kdv = Convert.ToDecimal(reader[7]),
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            //okuyucu ve bağlantıyı kapattım 
            return products; //listeyi geriye döndürüyoruz
        }

        internal void Sil(int id)
        {
            throw new NotImplementedException();
        }

        //girilen değerleri veritabanını ekleme methodu 
        public void Ekle(Product product) //bu methodu çağırıp cağırırken ürün vermeliyiz EKLE BUTTONUNA TIKLANDIĞINDA
        {//dışarıdan bir ürün nesnesi alıcak 
            BaglantiKontrol();
            SqlCommand command = new SqlCommand("insert into Products values(@barkod,@stok,@kategori,@name,@unitPrice,@salePrice,@kdv)", _connection);
            //eklenecek verilerimiz
            command.Parameters.AddWithValue("@barkod", product.Barkod);
            command.Parameters.AddWithValue("@stok", product.Stok);
            command.Parameters.AddWithValue("@kategori", product.Kategori);
            command.Parameters.AddWithValue("@name", product.Name); //eklenecek parametrenin gelen yeri 
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@salePrice", product.SalePrice);
            command.Parameters.AddWithValue("@kdv", product.Kdv);
            command.ExecuteNonQuery();
            _connection.Close();

        }
        public void Guncelle(Product product)
        {//dışarıdan bir ürün nesnesi alıcak 
            BaglantiKontrol();
            SqlCommand command = new SqlCommand("Update Products set Barkod=@barkod,Stok=@stok,Kategori=@kategori,Name=@name,UnitPrice=@unitPrice,SalePrice=@salePrice,Kdv=@kdv where Id=@id ", _connection);
            //where ile parametre alanı id ile gelenleri güncellesin o ıd özel yani
            //GÜNCELLEME UPDATE işlevidir set ile getiriyoruz her alanı 
            command.Parameters.AddWithValue("@id", product.Id);
            command.Parameters.AddWithValue("@barkod", product.Barkod);
            command.Parameters.AddWithValue("@stok", product.Stok);
            command.Parameters.AddWithValue("@kategori", product.Kategori);
            command.Parameters.AddWithValue("@name", product.Name); 
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@salePrice", product.SalePrice);
            command.Parameters.AddWithValue("@kdv", product.Kdv);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Sil(Product product) //silmek için sadece ıd yeterli bütün veriye silme işlevi uygulanabilir
        {//dışarıdan bir ürün nesnesi alıcak 
            BaglantiKontrol();
            SqlCommand command = new SqlCommand("Delete from Products  where Id=@id ", _connection);
            //id si dışarıdan gelen ürünü sil 
            command.Parameters.AddWithValue("@id",product.Id); //id değerini dışarıdan gelen ıd değerinden alıcak
            command.ExecuteNonQuery();
            _connection.Close();
            //bu methodu mainwindowdan çağıralım
        }



        private void BaglantiKontrol()
        {
            if (_connection.State == ConnectionState.Closed)
            {//BAĞLANTI KAPALIYSA 
                _connection.Open();
                //bağlantıyı aç 
            }
        }
    }
}
