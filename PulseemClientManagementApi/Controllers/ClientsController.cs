using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PulseemClientManagementApi.Commands;
using System.Text;

namespace PulseemClientManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {

            _mediator = mediator;

        }

        [HttpPost]
        public async Task<object> ValidationRequest([FromBody] CreateClientCommand paymentNotificationCommand)
        {
           
            var result = await _mediator.Send(paymentNotificationCommand);

            return result;

        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(UpdateClientComand updateClientComand)
        {
            var result = await _mediator.Send(updateClientComand);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
