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
using Core;
using WPF.DB;
using System.Collections.ObjectModel;

namespace WPF.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeListPage.xaml
    /// </summary>
    public partial class EmployeeListPage : Page
    {
        Core.Client user = new Core.Client();
        public EmployeeListPage(Core.Client client)
        {
            InitializeComponent();
            employee_dg.ItemsSource = bd_connection.connection.Employee.ToList().Where(a => a.id_position == 1);

            user = client;
            this.DataContext = this;
        }

        private void terapylb_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new TerapyPage(user));
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

        private void addTerapylb_Click(object sender, MouseButtonEventArgs e)
        {
            if (employee_dg.SelectedItem != null)
                NavigationService.Navigate(new AddTerapyPage(employee_dg.SelectedItem as DB.Employee, user));
            else
                MessageBox.Show("Выберите психолога к которому хотите записаться на прием");
        }
    }
}
