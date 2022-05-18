using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsihiService.ViewModels
{
    public class EmployeeModel
    {
        public Employee employee { get; set; }
        public List<Problems> problems { get; set; }
        public Position position { get; set; }
        public List<TypeTerapy> types { get; set; }
        public List<Client> clients { get; set; }
    }
}
