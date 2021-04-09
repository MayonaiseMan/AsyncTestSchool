using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace LetturaAsync
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            InitializeComponent();       
        }

        private void start_btn_Click(object sender, RoutedEventArgs e)
        {
            ContaChar();
            Progresso();
        }

        private async void Progresso()
        {
            await Task.Run(() => {
                progres_bar.Dispatcher.BeginInvoke(new Action(() =>
                {
                    progres_bar.IsIndeterminate = true;
                }));
            });
        }

        private async void ContaChar()
        {
            
            await Task.Run(() => {
                int counter = 0;
                using(StreamReader reader = new StreamReader("Data.txt"))
                {
                    
                    while (reader.EndOfStream == false)
                    {
                        reader.Read();
                        counter++;
                        
                    }
                }

                progres_bar.Dispatcher.BeginInvoke(new Action(() =>
                {
                    progres_bar.IsIndeterminate = false;
                }));
            
                MessageBox.Show("il file ha: " + counter +" caratteri");
            });
            
        }
    }
}
