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
using Project.Entities;

namespace Project.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AddNewDevices.xaml
    /// </summary>
    public partial class AddNewDevices : Window
    {
        public string user;
        public AddNewDevices(string username)
        {
            user = username;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Devices device = new Devices();
            device.DevicesName = name.Text;
            device.Category = Category.Text;
            device.DevicesUser = user;
            device.Image = "C:/product.png";

            Context ct = new Context();
            ct.Add(device);
            ct.SaveChanges();
            devices dc = new devices(user);
            dc.LoadData();
            this.Close();


        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
