using MediatR;
using Microsoft.AspNetCore.Mvc;
using PulseemClientManagementApi.Commands;
using PulseemClientManagementApi.Dtos.Response;
using PulseemClientManagementApi.Interfaces.Repository;
using PulseemClientManagementApi.Logic;
using PulseemClientManagementApi.Models;

namespace PulseemClientManagementApi.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response>
    {
        private readonly IDataRepository<Client, string> _iRepo;
        private readonly IDataRepository<Trace, string> _iRepo2;
        Response response = new Response();
        Common common = new Common();
        public CreateClientCommandHandler(IDataRepository<Client, string> REpo, IDataRepository<Trace, string> iRepo2)
        {
            _iRepo = REpo;
            _iRepo2 = iRepo2;

        }
  
        public async Task<Response> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            //log request
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            Trace requestTraces = new Trace();
            requestTraces.Request = jsonString;
            requestTraces.DateIn = DateTime.Now;
            requestTraces.Action = "Create Client";

            _iRepo2.Add(requestTraces);

            var clients = _iRepo.GetAll().Distinct();
         
            Client client = clients.Where(u=>u.Email==request.client.Email).FirstOrDefault();
            Client client1 = clients.Where(u => u.Email == request.client.Email && u.Cellphone==request.client.Cellphone).FirstOrDefault();

            if (common.EmailIsValid(request.client.Email))
            {
                if (client == null || client1 == null)
                {

                    var st = _iRepo.Add(request.client);

                    if (st != null)
                    {

                        response.status = true;
                        response.Description = "Success";
                        response.code = 55;
                  
                    }
                    else
                    {
                        response.status = false;
                        response.Description = "Internal server Error";
                        response.code = 400;

                        var jsonString1 = Newtonsoft.Json.JsonConvert.SerializeObject(response);


             

                    }



                }
                else
                {
                    response.status = false;
                    response.Description = "Email already exists";
                    response.code = 400;

      
                }
            }
            else {
                response.status = false;
                response.Description = "Email is not valid";
                response.code = 400;
            }
            return response;

        }
    }
}

