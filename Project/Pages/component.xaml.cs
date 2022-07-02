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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy component.xaml
    /// </summary>
    public partial class component : Page
    {
        public List<Component> CompList;
        public string user;
        public string dev;

        public component(string username, string device)
        {
            user = username;
            dev = device;

            InitializeComponent();
            LoadData();


        }


        public void LoadData()
        {
            CompList = new List<Component>();
            Context context = new Context();

            CompList = context.component
                 .Where(B => B.DevicesUser == user)
                 .Where(B=>B.DevicesName==dev)
                 .ToList();

            if (CompList.Count > 0)
                ListViewComponent.ItemsSource = CompList;

        }
        private void addNew_Click(object sender, RoutedEventArgs e)
        {
            NewComponent and = new NewComponent(user, dev);
            and.Show();
        }
    }
}
