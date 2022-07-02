﻿using Project.Entities;
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

namespace Project.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy devices.xaml
    /// </summary>
    public partial class devices : Page
    {
        public string user;
        public List<Devices> dev;
        public devices(string username)
        {
            user = username;
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            dev = new List<Devices>();
            Context context = new Context();

            dev = context.devices
                 .Where(B => B.DevicesUser == user)
                 .ToList();
            
            if (dev.Count > 0)
                ListViewProducts.ItemsSource = dev;

        }

        private void addNew_Click(object sender, RoutedEventArgs e)
        {
            AddNewDevices and = new AddNewDevices(user);
            and.Show();
        }

        private void ButtonItemClick(object sender, RoutedEventArgs e)
        {

           component comp = new component(user, (string)((Button)sender).Tag);
           Component.Content = comp;

        }
    }
}
