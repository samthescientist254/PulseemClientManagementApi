using MediatR;
using PulseemClientManagementApi.Dtos.Response;

namespace PulseemClientManagementApi.Queries
{

    public class DeleteClientQuery : IRequest<Response>
    {
        public string ClientId { get; set; }
        public DeleteClientQuery(string ClientId_)
        {
            ClientId = ClientId_;


        }
    }
}
