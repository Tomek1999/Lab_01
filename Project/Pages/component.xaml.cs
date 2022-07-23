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
    /// Component page- Load components
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
            ///<summary>
            ///Load data from MSSQL using entityFramework and Lambda
            ///</summary>
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
            ///<summary>
            ///Open new window for add a new component into devices
            ///</summary>
            NewComponent and = new NewComponent(user, dev);
            and.Show();
        }
    }
}
