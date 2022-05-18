using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsihiService
{
    public class Client
    {
        public int id_client { get; set; }
        public string fio { get; set; }
        public string passport { get; set; }
        public string phone { get; set; }
        public int id_type { get; set; }
        public int id_employee { get; set; }
        public int id_user { get; set; }
        public void AddClient(Client client, List<TypeTerapy> types)
        {
            var model = new ClientModel() { client = client, type = types };
            DataManag.AddClient(model);
        }
        public void RemoveClient(Client client)
        {
            DataManag.RemoveClient(client.id_client);
        }
    }
}
