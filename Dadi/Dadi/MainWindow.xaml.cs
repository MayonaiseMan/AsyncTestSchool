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
using System.Threading;


namespace Dadi
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      

        Random rnd;
        bool brek = false;
        public MainWindow()
        {
            InitializeComponent();
            rnd = new Random();
            Sorteggio();
        }


        int sorteggiato1, sorteggiato2;

        private void stop_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dado: " + (sorteggiato1 + sorteggiato2));
        }

        private void Break_btn_Click(object sender, RoutedEventArgs e)
        {
            if (brek == false)
            {
                brek = true;
            }
            else
            {
                brek = false;
                Sorteggio();
            }

        }

        private async void Sorteggio()
        {
            await Task.Run(() =>
            {

                while (!brek)
                {
                    sorteggiato1 = rnd.Next(1, 7);
                    sorteggiato2 = rnd.Next(1, 7);
                    int sorteggiato = sorteggiato1 + sorteggiato2;
                    string s1 = "" + sorteggiato1 + ".png";
                    string s2 = "" + sorteggiato2 + ".png";
                    BitmapImage image1 = new BitmapImage();
                    image1.BeginInit();
                    image1.UriSource = new Uri(s1, UriKind.Relative);
                    image1.EndInit();
                    BitmapImage image2 = new BitmapImage();
                    image2.BeginInit();
                    image2.UriSource = new Uri(s2, UriKind.Relative);
                    image2.EndInit();
                    image1.Freeze();
                    image2.Freeze();
                    this.Dispatcher.BeginInvoke(new Action(() => {
                        lbl.Content = sorteggiato;
                        img1.Source = image1;
                        img2.Source = image2;
                    }));

                    Thread.Sleep(500);
                }

            });
        }



    }
}
