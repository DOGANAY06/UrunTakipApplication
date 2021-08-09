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

namespace UrunTakipApplication
{
    /// <summary>
    /// Interaction logic for Hakkinda.xaml
    /// </summary>
    public partial class Hakkinda : Window
    {
        public Hakkinda()
        {
            InitializeComponent();
        }

        private void btn_UrunKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            gk.Opacity = 1; //gk eski haline dönecek
        }
    }
}
