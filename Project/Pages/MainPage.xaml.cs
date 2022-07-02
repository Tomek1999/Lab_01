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

namespace Project.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public string user;
        public MainPage(string username)
        {
            user = username;
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void devices_Click(object sender, RoutedEventArgs e)
        {
            devices dc = new devices(user);
            MainPageFrame.Content = dc;

        }
    }
}
