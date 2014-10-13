using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace projekt_dotNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            VideoWindow.Volume = 100;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            VideoWindow.Source = new Uri(TextBoxFileDirectory.Text);
            VideoWindow.Play();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.InitialDirectory = @"C:\Users\Mariusz\Desktop\dotNet";
            fdialog.ShowDialog();
            TextBoxFileDirectory.Text = fdialog.FileName;
            var film = new MojPlik()
            {
                CzasDodania = DateTime.Now,
                NazwaPliku = fdialog.FileName,
            };
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            VideoWindow.Pause();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            VideoWindow.Stop();
        }

        private void DBButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new VideoContext();
            var x = TextBoxFileDirectory.Text;
            var fName = x.Substring(x.LastIndexOf("\\")+1).ToString();

            var vid = new Video()
            {
                FileName = fName,
                AddedTime = DateTime.Now,
            };

            context.Videos.Add(vid);

            context.SaveChanges();


        }

        private void SZUKAJ_Click(object sender, RoutedEventArgs e)
        {
            var context = new VideoContext();
            foreach (var item in context.Videos)
            {
                if (item.FileName.Contains("test"))
                {
                    WyszukaneDane.AppendText("\n" + item.FileName);
                }
            }
        }
    }
}
