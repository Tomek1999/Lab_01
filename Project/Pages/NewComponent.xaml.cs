using Project.Entities;
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
    /// Logika interakcji dla klasy NewComponent.xaml
    /// </summary>
    public partial class NewComponent : Window
    {
        string user;
        string nam;
        public NewComponent(string usr, string na)
        {
            nam = na;
            user = usr;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Component component = new Component();
            component.DevicesName = nam;
            component.ComponentName = name.Text;
            component.Category = Category.Text;
            component.DevicesUser = user;
            component.Image = "C:/component.png";

            Context ct = new Context();
            ct.Add(component);
            ct.SaveChanges();

            this.Close();
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
