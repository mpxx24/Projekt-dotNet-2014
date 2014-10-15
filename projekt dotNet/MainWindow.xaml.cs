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
            var c = new VideoContext();
            ListaPlikow.Items.Add("Lista plików w bazie danych: ");
            foreach (var x in c.Videos)
            {
                ListaPlikow.Items.Add(x.FilePath);
            }
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
            var fileInfo = new FileInfo(x);

            var vid = new Video()
            {
                FileName = fileInfo.Name,
                AddedTime = DateTime.Now,
                Extension = fileInfo.Extension,
                Lenght = fileInfo.Length,
                FilePath = x
            };

            context.Videos.Add(vid);

            context.SaveChanges();


        }

        private void SZUKAJ_Click(object sender, RoutedEventArgs e)
        {
            var context = new VideoContext();
            WyszukaneDane.Document.Blocks.Clear();
            if (RButtonFileName.IsChecked == true)
            {
                foreach (var item in context.Videos)
                {
                    if (DoWyszukania.Text != null)
                    {
                        if (item.FileName.Contains(DoWyszukania.Text))
                        {
                            WyszukaneDane.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonFileExt.IsChecked == true)
            {
                foreach (var item in context.Videos)
                {
                    if (DoWyszukania.Text != null)
                    {
                        if (item.Extension == DoWyszukania.Text)
                        {
                            WyszukaneDane.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonFileLengthMoreThan.IsChecked == true)
            {
                foreach (var item in context.Videos)
                {
                    if (DoWyszukania.Text != null)
                    {
                        if (item.Lenght >= long.Parse(DoWyszukania.Text))
                        {
                            WyszukaneDane.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonFileLengthLessThan.IsChecked == true)
            {
                foreach (var item in context.Videos)
                {
                    if (DoWyszukania.Text != null)
                    {
                        if (item.Lenght <= long.Parse(DoWyszukania.Text))
                        {
                            WyszukaneDane.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else
            {
                MessageBox.Show("musisz zaznaczyć konkretnego checkboxa!");
            }
        }

        private void ListaPlikow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cont = new VideoContext();
            VideoWindow.Source = new Uri(ListaPlikow.SelectedItem.ToString());
            VideoWindow.Play();
        }
    }
}
