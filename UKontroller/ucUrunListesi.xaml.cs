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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UrunTakipApplication.Classlar;

namespace UrunTakipApplication.UKontroller
{
    /// <summary>
    /// Interaction logic for ucUrunListesi.xaml
    /// </summary>
    public partial class ucUrunListesi : UserControl
    {
        public ucUrunListesi()
        {
            InitializeComponent();
            UrunleriYukle();
        }
        ProductDal _productDal = new ProductDal();
        //ProductDal classı ile yeni bir nesne ürettim

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // ürünleri getirmek için çağrı yapıcaz
            UrunleriYukle();
        }
        private void UrunleriYukle()
        {//gelen ürünleri gridin üzerine yüklememiz gerekiyor
            dtgProducts.ItemsSource = _productDal.UrunLeriGetir();
            //GELEN ürünleri datagridinin itemsSource bağladım
        }
        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);        //bu pencereden başka bir pencerenin elemanına erişmek için
        private void btnEkle_Click(object sender, RoutedEventArgs e)
        {
            winUrunEkle ekle = new winUrunEkle();
            ekle.Owner = gk; //eklenin sahibi gk
            gk.Opacity = 0.3; //gk saydam olsun
            ekle.ShowDialog();
            UrunleriYukle();
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            new winUrunGuncelle(this, (Product)dtgProducts.SelectedItem).ShowDialog(); //güncelleme modunda açılacak
            UrunleriYukle();
            //secilmiş olan bölüm datagridde çekilecek 
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {//butona tıklandığında sil methodu çalışsın
            new winUrunSil(this, (Product)dtgProducts.SelectedItem).ShowDialog(); //güncelleme modunda açılacak
            UrunleriYukle();
            //secilmiş olan bölüm datagridde çekilecek 

        }

        private void txtAra_SelectionChanged(object sender, RoutedEventArgs e)
        {
            dtgProducts.ItemsSource = _productDal.UrunLeriGetir().Where(x => x.Name.ToLower().Contains(txtAra.Text.ToLower())).ToList();
            //döndürülen kayıtları datagrid atarız = //ürünleri getirip onları süzmek için nereden aramam gerektiğini yapıyorum büyük küçük harft duyarlılığı için tolower toupper kullandım contains içeriyosa demektir
            //yani gelmiş ürünlerden aranan ürünü içeren varsa bu koşula uyan kayıtları listeye çevirerek döndürürüz
        }

        private void btnTemizle_Click(object sender, RoutedEventArgs e)
        {//temizle buttonuna basınca ürün arama kısmı temizlenir
            txtAra.Text = string.Empty;
        }
        //çekeceğim veriler
        int stok=1; 
        string urunadi;
        decimal satisfiyati;
        private void dtgProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            stok = Convert.ToInt32(((TextBlock)dtgProducts.Columns[2].GetCellContent(dtgProducts.SelectedItem)).Text);
            //stok çektim önce textblock yaparak textini aldım stok column burada integer çevirip aldım 
            urunadi = ((TextBlock)dtgProducts.Columns[4].GetCellContent(dtgProducts.SelectedItem)).Text;
            satisfiyati= (Convert.ToDecimal(((TextBlock)dtgProducts.Columns[6].GetCellContent(dtgProducts.SelectedItem)).Text)/10000);
            MessageBox.Show(stok+ " adet "+urunadi+ " vardır. Birim satış fiyatı " +satisfiyati+ " ₺");

        }
    }
}
