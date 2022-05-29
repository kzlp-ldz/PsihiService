using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace CONSOl
{
    public class Program
    {
        static void Main(string[] args)
        {
            LogIn();
        }
        public static void LogIn()
        {
            Console.WriteLine("Введите логин:");
            string login = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите пароль:");
            string password = Convert.ToString(Console.ReadLine());
            IsLoginPasswordCorrect(login, password);
        }
        public static void MessageList()
        {
            Console.WriteLine("Выберите одно:");
            Console.WriteLine("1) Список сотрудников");
            Console.WriteLine("2) Список клиентов");
            Console.WriteLine("3) Просмотреть записи на прием к психологам");
            Console.WriteLine("4) Завершить рабоу");
            Console.WriteLine("Введите цифру команды:");
            var answer = Convert.ToString(Console.ReadLine());
            ShowAnswer(answer);
        }
        public static void IsLoginPasswordCorrect(string login, string password)
        {
            var user = DataManag.GetUsers().Where(a => a.login == login && a.password == password).FirstOrDefault();

            if (user != null)
            {
                var employee = DataManag.GetEmployees().Where(a => a.id_user == user.id_user).FirstOrDefault();
                if (employee != null && employee.id_position == 3)
                    MessageList();
                else
                {
                    Console.WriteLine("Недостаточно прав");
                    LogIn();
                }
            }
            else
            {
                Console.WriteLine("Неверный логин или пароль");
                LogIn();
            }
        }
        public static void ShowAnswer(string answer)
        {
            switch(answer)
            {
                case "1":
                    var employee = DataManag.GetEmployees();
                    foreach (var b in employee)
                    {
                        Console.WriteLine(b.id_employee + " " + b.fio + " " + b.id_position + " " + b.phone + " " + b.id_user);
                    }
                    MessageList();
                    break;
                case "2":
                    var clients = DataManag.GetClients();
                    foreach (var b in clients)
                    {
                        Console.WriteLine(b.id_client + " " + b.fio + " " + b.passport + " " + b.phone + " " + b.id_user);
                    }
                    MessageList();
                    break;
                case "3":
                    var terapy = DataManag.GetTerapiyes();
                    foreach (var b in terapy)
                    {
                        Console.WriteLine(b.id + " " + b.id_client + " " + b.id_employee + " " + b.id_type + " " + b.dateTerapy);
                    }
                    MessageList();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Введена неверная команда");
                    MessageList();
                    break;
            }
        }
    }
}
