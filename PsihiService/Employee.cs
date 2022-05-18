using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsihiService
{
    public class Employee
    {
        public int id_employee { get; set; }
        public string fio { get; set; }
        public string phone { get; set; }
        public int id_position { get; set; }
        public List<Problems> problems { get; set; }
        public List<TypeTerapy> types { get; set; }
        public int id_user { get; set; }
        public void FillEmployee()
        {
            problems = DataManag.GetEmployeesWithProblems(id_employee);
            types = DataManag.GetEmployeesWithTerapy(id_employee);
        }
        public List<Problems> GetProblems()
        {
            return problems;
        }
        public List<TypeTerapy> GetTypes()
        {
            return types;
        }
    }
}
