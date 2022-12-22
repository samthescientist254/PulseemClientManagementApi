using MediatR;
using PulseemClientManagementApi.Commands;
using PulseemClientManagementApi.Dtos.Response;
using PulseemClientManagementApi.Interfaces.Repository;
using PulseemClientManagementApi.Models;

namespace PulseemClientManagementApi.Handlers
{
    public class UpdateClientComandHandler : IRequestHandler<UpdateClientComand, Response>
    {
        private readonly IDataRepository<Client, string> _iRepo;
        private readonly Response response = new Response();

        public UpdateClientComandHandler(IDataRepository<Client, string> REpo)
        {
            _iRepo = REpo;

        }
        public async Task<Response> Handle(UpdateClientComand request, CancellationToken cancellationToken)
        {


            long y = _iRepo.Update(request.client.Id.ToString(), request.client);
            if (y == 1)
            {
                response.Description = "Success Update.";
                response.code = Convert.ToInt32(y);
                response.status = true;
                return response;
            }
            else
            {
                response.Description = "Failed update.";
                response.code = Convert.ToInt32(y);
                response.status = false;
                return response;
            }
        }
    }

}
