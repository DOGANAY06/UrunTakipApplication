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
using UrunTakipApplication.UKontroller;

namespace UrunTakipApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth; //ekrana görev cubuğunu kaybetme tam ekranda bile dursun diye system parametreleri
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btn_hamburgerMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //tıklayınca gridin boyutunu değiştireceğiz ve hamburger olacak 
            if (btn_hamburgerMenu.Width != 60)// yani hamburger menüye mouse ile dokunulduysa 
            {
                GridLength grd = new GridLength(80, GridUnitType.Pixel); //gridin uzunluğu için yeni griduzunluğu nesnesi yaratıyoruz direk verilmez
                grdClmn_menu.Width = grd; //grd yi konuma veriyoruz
                lbl_menu1.Visibility = Visibility.Hidden;  //bütün menülerimiz görünmez olacak 
                lbl_menu2.Visibility = Visibility.Hidden;

                lbl_logoyazi.Width = 0; //logonun yazısı kaybolacak
                btn_hamburgerMenu.Width = 60;
                menu_border.Visibility = Visibility.Hidden; // versiyon bilgisi yok olacak 
                menu_altpencere_resim.Visibility = Visibility.Hidden;
            }
            else //eski haline dön hamburgermenüden çık 
            {
                GridLength grd = new GridLength(220, GridUnitType.Pixel); //gridin uzunluğu için yeni griduzunluğu nesnesi yaratıyoruz direk verilmez
                grdClmn_menu.Width = grd; //grd yi konuma veriyoruz
                lbl_menu1.Visibility = Visibility.Visible;  //bütün menülerimiz görüncek
                lbl_menu2.Visibility = Visibility.Visible;

                lbl_logoyazi.Width = 150; //logonun yazısı kaybolacak
                btn_hamburgerMenu.Width = 100;
                menu_border.Visibility = Visibility.Visible; //görünür olacak
                menu_altpencere_resim.Visibility = Visibility.Visible;
            }
        }
        private void btn_SimgeDurumu_Click(object sender, RoutedEventArgs e)
        {//icon durumuna küçülecek uygulama
            this.WindowState = WindowState.Minimized;
        }
        private void btn_TamEkran_Click(object sender, RoutedEventArgs e)
        {
            //ekranı büyütecek button
            if (this.WindowState == WindowState.Normal) //normal boyuttaysan
            {
                this.WindowState = WindowState.Maximized;
            }
            else //NORMAL DEĞİLSE normal ekrana geçer
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btn_kapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //pencereyi kapatır
        }
        private void brd_Sagust_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove(); //mouse sola basıldığında hareket ettir
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            uc_cagir.Uc_Ekle(Content_icerik, new ucUrunListesi()); //içerik ve kitap listesini cağiriyoruz
            
        }
        #region menubuttonlar
        int secimdurumu;
        private void menubuton_randevular_Click(object sender, RoutedEventArgs e)
        {
            uc_cagir.Uc_Ekle(Content_icerik, new ucUrunListesi()); //içerik ve kitap listesini cağiriyoruz
            secimdurumu = 1;
            secilendurum(); 
        }

        private void menubuton_hakkinda_Click(object sender, RoutedEventArgs e)
        {
            Hakkinda hakkinda = new Hakkinda();
            hakkinda.ShowDialog();
            secimdurumu = 2;
            secilendurum();
        }
        void secilendurum()
        {
            if (secimdurumu == 1)
            {
                menubuton_randevular.IsChecked = true;
            }
            else
            {
                menubuton_randevular.IsChecked = false;
            }
            if (secimdurumu==2)
            {
               menubuton_hakkinda.IsChecked = true;
            }
            else
            {
                menubuton_hakkinda.IsChecked = false;
            }
        }
    }
    #endregion
}
