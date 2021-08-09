using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace UrunTakipApplication.Classlar
{
    public class Bonus
    {
        public static void SesCal()
        {//ses tonu koyma 
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri("music/sfx-pop.mp3", UriKind.Relative));
            mplayer.Play();
        }
        public static void PopupShow(System.Windows.Controls.Primitives.Popup popup)
        { //popup gösterimi için timer yaptım
            SesCal(); //metodu çağırdık
            popup.IsOpen = true;
            //popup açılsın süre baslasın 
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(6)
                //6  saniye sonra kapansın interval zaman aralığiı
            }; //timer bir thread olduğu için süslü parantezin sonuna ; konur
            timer.Tick += delegate (object sender, EventArgs e)
            { //timer_Tick artıralan timer durdurup pencereyi kapatır
                ((DispatcherTimer)timer).Stop();
                if (popup.IsOpen) SesCal(); popup.IsOpen = false;

            };
            timer.Start();
        }
    }
}
