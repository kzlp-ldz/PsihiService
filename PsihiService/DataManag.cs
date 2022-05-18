using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PsihiService.ViewModels;

namespace PsihiService
{
    public static class DataManag
    {
        private static string connect = ConfigurationManager.ConnectionStrings["Psihi"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connect);

        public static List<Problems> GetProblems()
        {
            return connection.Query<Problems>("select id_problems, name from Problems where [isDeleted] = 'false'").AsList();
        }
        public static Problems GetProblem(int id)
        {
            try
            {
                return connection.Query<Problems>($"select * from [dbo].[Problems]" +
                    $"where [id_problems] = {id}").AsList()[0];
            }
            catch
            {
                { return null; }
            }
        }
        public static void AddProblem(Problems problems)
        {
            connection.Query($"insert into [dbo].[Problems] ([name]) values ('{problems.name}')");
        }
        public static void RemoveProblem(int id)
        {
            connection.Query($"update [dbo].[Problems] set [isDeleted] = 'true' where [id_problems] = {id}");
        }
        public static void UpdateProblems(int id, Problems problems)
        {
            connection.Query($"update [dbo].[Problems] set [name] = '{problems.name}' where [id_problems] = {id}");
        }
        public static List<TypeTerapy> GetTypes()
        {
            return connection.Query<TypeTerapy>("select * from TypeTerapy").AsList();
        }
        public static List<Position> GetPositions()
        {
            return connection.Query<Position>("select * from Position").AsList();
        }
        public static string GetPositionName(int id)
        {
            return ((Position)connection.Query($"select name from Position p where p.id_position = {id}")).name;
        }
        public static List<Employee> GetEmployees()
        {
            return connection.Query<Employee>("select * from Employee").AsList();
        }
        public static List<Problems> GetEmployeesWithProblems(int id_employee)
        {
            return connection.Query<Problems>("select e.id_employee, p.name from [dbo].[Employee] e" +
                " join [dbo].[Empl_Prob] epp on epp.id_employee = e.id_employee join [dbo].[Problems] p" +
                $" on epp.id_problems = p.id_problems where epp.id_employee = {id_employee}").AsList();
        }
        public static List<TypeTerapy> GetEmployeesWithTerapy(int id_employee)
        {
            return connection.Query<TypeTerapy>("select e.id_employee, e.name from [dbo].[Employee] e" +
                                              " join [dbo].[Emp_Type] et" +
                                              " on et.id_employee = e.id_employee" +
                                              " join [dbo].[TypeTerapy] t" +
                                              " on ep.id_type = t.id_type" +
                                              $" where ep.id_employee = {id_employee}").AsList();
        }
        public static void AddClient(ClientModel model)
        {
            connection.Query($"insert into [dbo].[Client] ([fio], [passport]," +
                $" [phone], [id_type], [id_employee]) values" +
                $"('{model.client.fio}, {model.client.passport}, {model.client.phone}, {model.client.id_type}, {model.client.id_employee}')");
        }
        public static void RemoveClient(int id)
        {
            connection.Query($"delete [dbo].[Client] where [id_client] = {id}");
        }
        public static TypeTerapy GetTypeName(int id)
        {
            return connection.Query($"select name from TypeTerapy t where t.id_type = {id}").AsList()[0];
        }
        public static List<Client> GetClients()
        {
            return connection.Query<Client>("select * from Client").AsList();
        }
        public static Client GetClient(int id)
        {
            try
            {
                return connection.Query<Client>($"select * from [dbo].[Client]" +
                    $"where [id_client] = {id}").AsList()[0];
            }
            catch
            {
                { return null; }
            }
        }
        public static Employee GetEmployee(int id)
        {
            try
            {
                return connection.Query<Employee>($"select * from [dbo].[Employee]" +
                    $"where [id_employee] = {id}").AsList()[0];
            }
            catch
            {
                { return null; }
            }
        }
        public static void UpdateClient(int id, Client client)
        {
            connection.Query($"update [dbo].[Client] set [fio] = '{client.fio}' where [id_client] = {id}");
        }
    }
}
