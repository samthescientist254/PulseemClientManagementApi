using MediatR;
using PulseemClientManagementApi.Dtos.Response;
using PulseemClientManagementApi.Models;

namespace PulseemClientManagementApi.Commands
{
    public class UpdateClientComand : IRequest<Response>
    {
        public Client client { get; set; }
    }
}
