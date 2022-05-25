using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Client
    {
        public int id_client { get; set; }
        public string fio { get; set; }
        public string passport { get; set; }
        public string phone { get; set; }
        public int id_user { get; set; }
        public void AddClient(Client client)
        {
            DataManag.AddClient(client);
        }
        public void RemoveClient(Client client)
        {
            DataManag.RemoveClient(client.id_client);
        }
    }
}
