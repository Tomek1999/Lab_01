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

    public partial class MainPage : Window
    {
        public string user;
        public MainPage(string username)
        {
            user = username;
            InitializeComponent();
        }
        ///<summary>
        /// Close button
        /// </summary>
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        ///<summary>
        ///Open new page for component
        /// </summary>
        private void devices_Click(object sender, RoutedEventArgs e)
        {
            devices dc = new devices(user);
            MainPageFrame.Content = dc;

        }
    }
}
