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
using WPF.DB;

namespace WPF.Pages.EmployeePages
{
    /// <summary>
    /// Логика взаимодействия для ClientsListPage.xaml
    /// </summary>
    public partial class ClientsListPage : Page
    {
        Core.Employee user = new Core.Employee();
        public ClientsListPage(Core.Employee employee)
        {
            InitializeComponent();
            user = employee;

            
            if(user.id_position == 3)
                client_dg.ItemsSource = bd_connection.connection.Client_Employee.ToList();
            else
                client_dg.ItemsSource = bd_connection.connection.Client_Employee.ToList().Where(a => a.id_employee == user.id_employee && a.dateTerapy >= DateTime.Now);
        }
        private void gooutlb_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Точно выйти?", "Выйти",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
