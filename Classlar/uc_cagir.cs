using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UrunTakipApplication.UKontroller;

namespace UrunTakipApplication.Classlar
{
    public class uc_cagir
    {
        //usercontrol çağırmamız lazım 
        public static void Uc_Ekle(Grid grd, UserControl uc)
        {
            if (grd.Children.Count > 0)
            {//grid sayısı 0 dan büyükse 
                grd.Children.Clear(); //SİL
                grd.Children.Add(uc);
            }
            else
            { //hiç çağrılmamızsa 
                grd.Children.Add(uc);
            }
        }
    }
}
