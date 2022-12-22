using PulseemClientManagementApi.Interfaces.Repository;
using PulseemClientManagementApi.Models;

namespace PulseemClientManagementApi.Implementation
{
    public class TraceManager : IDataRepository<Trace, string>
    {

        private readonly Pulseem_ClientsContext modelContext;
        public TraceManager(Pulseem_ClientsContext context)
        {
            modelContext = context;

        }
        public object Add(Trace b)
        {
            if (b != null)
            {
                
                var xy=modelContext.Traces.Add(b);
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
            throw new NotImplementedException();
        }

        public Trace Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trace> GetAll()
        {
            throw new NotImplementedException();
        }

        public long Update(string id, Trace b)
        {
            throw new NotImplementedException();
        }
    }
}
