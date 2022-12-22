using PulseemClientManagementApi.Interfaces.Repository;
using PulseemClientManagementApi.Models;

namespace PulseemClientManagementApi.Implementation
{
    public class ClientManager : IDataRepository<Client, string>
    {
        private readonly Pulseem_ClientsContext modelContext;
        public ClientManager(Pulseem_ClientsContext context)
        {
            modelContext = context;

        }
        public object Add(Client b)
        {
            if (b != null)
            {
                b.EmailStatus = "Active";
                b.SmsStatus = "Active";
                b.CreateTime = DateTime.Now;
                modelContext.Clients.Add(b);
                modelContext.SaveChanges();

                return b;
            }
            else
            {
                return b;
            }

        }

        public long Delete(string id)
        {
            long vs = 0;
            Client client = modelContext.Clients.FirstOrDefault(b => b.Id == Convert.ToInt32(id));
            if (client != null)
            {
                modelContext.Clients.Remove(client);
                vs = modelContext.SaveChanges();
            }
            return vs;
        }

        public Client Get(string id)
        {
            int cy = Convert.ToInt32(id);
            Client client = modelContext.Clients.FirstOrDefault(b => b.Id == cy);
            return client;
        }

        public IEnumerable<Client> GetAll()
        {
            var clients = modelContext.Clients;
            return clients;
        }

        public long Update(string id, Client b)
        {

            long v = 0;
            Client client = modelContext.Clients.FirstOrDefault(b => b.Id == Convert.ToInt32(id));

            if (client != null)
            {
                client.Name = b.Name;
                client.Email = b.Email;
                client.Cellphone = b.Cellphone;
                v = modelContext.SaveChanges();

            }
            List<Client> clients = modelContext.Clients.Where(b => b.Cellphone == b.Cellphone).ToList();
            foreach (var cli in clients)
            {
                Client clien2t = modelContext.Clients.FirstOrDefault(b => b.Id == cli.Id);

                if (clien2t != null)
                {
                    clien2t.Name = b.Name;
                    clien2t.Email = b.Email;
                    clien2t.Cellphone = b.Cellphone;
                    clien2t.EmailStatus = b.EmailStatus;
                    clien2t.SmsStatus = b.SmsStatus;

                    v = modelContext.SaveChanges();

                }
            }
            return v;

        }
    }
}
