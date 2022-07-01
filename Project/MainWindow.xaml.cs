using Project.Pages;
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
using Project.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User usr = new User();
            if (username.Text != "" & password.Password != "")
            {
                usr.Name = username.Text;
                usr.Password = password.Password;
                if (CheckUser(usr) == true)
                {

                }
                else
                {
                    MessageBox.Show("Check Your data!");

                }

            }
            else
            {
                MessageBox.Show("Please complete data!", "Error");
            }
        }
        public static bool CheckUser(User user)
        {
            Context context = new Context();

            var usrFromServer = context.user
                 .Where(B => B.Name == user.Name)
                 .First();
            if (usrFromServer.Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
