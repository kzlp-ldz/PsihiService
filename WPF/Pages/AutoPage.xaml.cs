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
using WPF.Pages;
using WPF.Pages.ClientPages;
using WPF.Pages.EmployeePages;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        
        User user = new User();
        Employee employee = new Employee();
        Client client = new Client();
        public AutoPage()
        {
            InitializeComponent();
        }
        private void btnConnect(object sender, RoutedEventArgs e)
        {
            if (login.Text != "" && password.Password != "")
            {
                var user = DataManag.GetUsers().Where(a => a.login == login.Text && a.password == password.Password).FirstOrDefault();
                
                if (user != null)
                {
                    var client = DataManag.GetClients().Where(a => a.id_user == user.id_user).FirstOrDefault();
                    var employee = DataManag.GetEmployees().Where(a => a.id_user == user.id_user).FirstOrDefault();
                    if (client != null)
                        NavigationService.Navigate(new EmployeeListPage(client));
                    else if(employee != null)
                        NavigationService.Navigate(new ClientsListPage(employee));
                }
                else
                    MessageBox.Show("Неверный пароль или логин");
            }
            else
                MessageBox.Show("Введите логин и пароль!!!!!");
        }
        private void btnRegist(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistPage());
        }
    }
}
