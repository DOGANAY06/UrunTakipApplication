using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UrunTakipApplication.Classlar;

namespace UrunTakipApplication
{
    /// <summary>
    /// Interaction logic for winUrunEkle.xaml
    /// </summary>
    public partial class winUrunEkle : Window
    {
        public winUrunEkle()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        //ProductDal classı ile yeni bir nesne ürettim
        private void btn_UrunEkle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_barkod.Text !="" && txtStok.Text !="" && txtKategori.Text !="" &&
                txtUnitPrice.Text !="" && txtSalePrice.Text!="" && txtKdv.Text !="")
            {//bu textboxlar boş değilse ürün eklenecek
                //ekle methoduna ürün oluşturdum
                _productDal.Ekle(new Product
                {//ekle methoduna ürün özelliklerini gönderdim 
                    Barkod = txt_barkod.Text,
                    Stok = Convert.ToInt32(txtStok.Text),
                    Kategori = txtKategori.Text,
                    Name = txtProductName.Text,
                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                    Kdv = Convert.ToDecimal(txtKdv.Text)
                });
                MessageBox.Show("Ekleme İşlemi Başarılı ");
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Ekleme İşlemi Başarısız ");
                this.Close();
            }
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1; //gk eski haline dönecek

        }

        private void btn_UrunEkleBilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_Bilgi); //classdan popupshow popup bilgiyi gönder
            Bonus.SesCal();
        }

        private void btn_UrunKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1; //gk eski haline dönecek
        }

        private void hesapla_Click(object sender, RoutedEventArgs e)
        {//kazancımızı hesaplamak için 
            float satis, alis, kdv;
            int stok=1;
            float kazanc = 0.0f;
            float kazanctoplam = 0.0f;
            satis = (float)Convert.ToDecimal(txtSalePrice.Text);
            alis = (float)Convert.ToDecimal(txtUnitPrice.Text);
            kdv = (float)Convert.ToDecimal(txtKdv.Text);
            stok = Convert.ToInt32(txtStok.Text);
            kazanc = (satis - alis) - (satis * kdv);
            txtKazanc.Text = Convert.ToString(kazanc.ToString()); //kazanç bilgisi ekranda gözükecek 
            //kazanca göre karar verip kaydet buttonuna basılacak 
            kazanctoplam = ((satis - alis) - (satis * kdv)) *stok;
            txtKazanctoplam.Text = Convert.ToString(kazanctoplam.ToString()); //kazanç bilgisi ekranda gözükecek 
        }
    }
}
