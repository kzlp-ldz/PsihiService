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

namespace WPF.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для TerapyPage.xaml
    /// </summary>
    public partial class TerapyPage : Page
    {
        Core.Client user = new Core.Client();
        public TerapyPage(Core.Client client)
        {
            InitializeComponent();

            user = client;
            employee_dg.ItemsSource = bd_connection.connection.Client_Employee.ToList().Where(a => a.id_client == user.id_client && a.dateTerapy >= DateTime.Now);
        }
        private void psihologlb_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EmployeeListPage(user));
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
