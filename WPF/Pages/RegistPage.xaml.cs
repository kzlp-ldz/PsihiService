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
using Core.ViewModels;

namespace WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistPage.xaml
    /// </summary>
    public partial class RegistPage : Page
    {
        List<TypeTerapy> typeTerapy = new List<TypeTerapy>();
        TypeTerapy type = new TypeTerapy();
        
        public RegistPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnRegist(object sender, RoutedEventArgs e)
        {
            
            Client client = new Client();
            User user = new User();
            
            user.login = tbx_login.Text;
            user.password = tbx_password.Text;
            if (IsLoginCorrect())
            {
                DataManag.AddUser(user);

                var users = DataManag.GetUsers().Where(a => a.login == tbx_login.Text && a.password == tbx_password.Text).FirstOrDefault();

                client.fio = tbx_fio.Text;
                client.passport = tbx_passport.Text;
                client.phone = tbx_phone.Text;
                client.id_user = users.id_user;
                DataManag.AddClient(client);

                MessageBox.Show("ДОБАВЛЕНО!!!");
                NavigationService.Navigate(new AutoPage());
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }
        public bool IsLoginCorrect()
        {
            var users = DataManag.GetUsers();
            bool login = true;
            foreach (var a in users)
            {
                if (a.login == tbx_login.Text)
                    login = false;
            }
            if (login)
                return true;
            else
            {
                MessageBox.Show("Такой логин уже занят, придумайте другой", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
