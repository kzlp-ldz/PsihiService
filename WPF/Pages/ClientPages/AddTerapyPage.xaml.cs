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
    /// Логика взаимодействия для AddTerapyPage.xaml
    /// </summary>
    public partial class AddTerapyPage : Page
    {
        DB.Employee emp = new DB.Employee();
        Core.Client user = new Core.Client();
        DB.TypeTerapy type = new DB.TypeTerapy();
        DB.Client_Employee terapy = new DB.Client_Employee();
        public string time;
        public DateTime tim = new DateTime();
        public AddTerapyPage(DB.Employee employee, Core.Client client)
        {
            InitializeComponent();
            emp = employee;
            user = client;

            fio_lb.Content = emp.fio;
            type_lb.ItemsSource = emp.Emp_Type.ToList();

            data_dp.BlackoutDates.AddDatesInPast();
            data_dp.BlackoutDates.Add(new CalendarDateRange(DateTime.Now, DateTime.Now.AddDays(7)));
            

        }

        private void btnSafe(object sender, RoutedEventArgs e)
        {
            terapy.id_client = user.id_client;
            terapy.id_employee = emp.id_employee;
            terapy.id_type = type_lb.SelectedIndex + 1;

                terapy.dateTerapy = tim;

                bd_connection.connection.Client_Employee.Add(terapy);
                bd_connection.connection.SaveChanges();
            NavigationService.Navigate(new TerapyPage(user));
        }

        private void type_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (type_lb.SelectedIndex + 1 == 1)
                price_lb.Content = 2500;
            else
                price_lb.Content = 5000;
        }

        private void time_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = data_dp.SelectedDate;
            
            if (data != null)
            {
                var dataString = data.Value.ToShortDateString();
                time = (time_lb.SelectedItem as TextBlock).Text + ":00";
                
                var datatime = dataString + " " + time;
                if (IsDataCorrect(datatime))
                    tim = DateTime.Parse(datatime);
            }
            else
                MessageBox.Show("Выберите дату записи");
            
        }
        public bool IsDataCorrect(string datatime)
        {
            var datater = bd_connection.connection.Client_Employee.ToList();
            bool data = true;
            foreach (var a in datater)
            {
                if (a.dateTerapy.ToString() == datatime)
                    data = false;
            }
            if (data)
            {
                safe_btn.Visibility = Visibility.Visible;
                return true;
            }
            else
            {
                MessageBox.Show("Такая дата уже занята", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                safe_btn.Visibility = Visibility.Hidden;
                return false;

            }
        }
    }
}
