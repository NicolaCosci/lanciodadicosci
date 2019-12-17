using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace lancioDadi
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

        private void Btn_lanciodadi_Click(object sender, RoutedEventArgs e)
        {
            int dado1 = 0;
            int dado2 = 0;
            Random r1;
            Random r2;

            var Dado1 = new Thread((currentIndex) =>
            {
                r1 = new Random();
                dado1 = r1.Next(1, 7);


            });
            var Dado2 = new Thread((currentIndex) =>
            {
                r2 = new Random();
                dado2 = r2.Next(1, 7);


            });

            Dado1.Start();
            Dado2.Start();

            Dado1.Join(400);
            Dado2.Join(400);

            int tiro = dado1 + dado2;
            Lbl_risultato.Content = tiro; 

            Img_dado1.Source=new BitmapImage(new Uri($"{dado1}.jpg", UriKind.Relative)); 
             
            Img_dado2.Source = new BitmapImage(new Uri($"{dado2}.jpg", UriKind.Relative));

        }
        
    }
}
