using PulseemClientManagementApi.Interfaces.Repository;
using PulseemClientManagementApi.Models;

namespace PulseemClientManagementApi.Implementation
{
    public class ErrologManager : IDataRepository<ErrorLog, string>
    {

        public object Add(ErrorLog b)
        {
            throw new NotImplementedException();
        }

        public long Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ErrorLog Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ErrorLog> GetAll()
        {
            throw new NotImplementedException();
        }

        public long Update(string id, ErrorLog b)
        {
            throw new NotImplementedException();
        }
    }
}
