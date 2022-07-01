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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User usr = new User();
            if (username.Text != "" & email.Text != "" & password.Password != "")
            {
                MessageBox.Show("BAGNOS", "Error");

                usr.Name = username.Text;
                usr.Email = email.Text;
                usr.Password = password.Password ;

                if (AddUser(usr) == true)
                {
                    MessageBox.Show("User Added", "Error");

                }
                else
                {
                    MessageBox.Show("Please Retry Later", "Error");

                }
            }
            else
            {
                MessageBox.Show("Please complete data!", "Error");

            }

        }
        public static bool AddUser(User user)
        {
            Context context = new Context();
            try
            {
                context.Add(user);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
