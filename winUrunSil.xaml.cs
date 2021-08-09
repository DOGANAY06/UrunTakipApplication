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
    /// Interaction logic for winUrunSil.xaml
    /// </summary>
    public partial class winUrunSil : Window
    {
        public winUrunSil(UKontroller.ucUrunListesi ucUrunListesi, Product product)
        {
            InitializeComponent();
            this.DataContext = product; //ürün referansını aktarıcaz buraya
        }

        private void btn_Sil_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ProductDal _productDal = new ProductDal();
            //güncelle methoduna ürün oluşturdum
            _productDal.Sil(new Product
            {//ekle methoduna ürün özelliklerini gönderdim 
                Id = Convert.ToInt32(txtId.Text),
            });
            MessageBox.Show("Ürün Silme işlemi Başarılı ");
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            
            
        }

        private void btn_UrunClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            
        }

        private void btn_UrunBilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_Bilgi); //classdan popupshow popup bilgiyi gönder
            Bonus.SesCal();
        }
    }
}
