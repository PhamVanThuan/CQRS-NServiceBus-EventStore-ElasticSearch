using System.Collections.Generic;
using System.Web.Http;
using EasyNetQ;
using ElasticSearchReadModel.Documents;
using ElasticSearchReadModel.Repositories;
using Messages.Commands;
using StructureMap;
using UI.Controllers.DTOs;

namespace UI.Controllers
{
    public class ClientsController : ApiController
    {
        // GET: api/Client
        public IEnumerable<ClientInformation> Get()
        {
            var rep = ObjectFactory.GetInstance<IClientInformationRepository>(); 

            return rep.GetClientsBy(null,null);
        }

        // GET: api/Client/pepe
        public IEnumerable<ClientInformation> Get(string clientName,string possiblyStolen=null)
        {
            var rep = new ClientInformationRepository();

            bool? possiblyStolenArgument = string.IsNullOrEmpty(possiblyStolen) || !bool.Parse(possiblyStolen) ? (bool?)null : true ;

            return rep.GetClientsBy(clientName, possiblyStolenArgument);
        }

        // POST: api/Client
        public void Post([FromBody] NewClientDTO newClient)
        {
            MvcApplication.Bus.Publish(new CreateClientCommand() 
                                        {
                                            ClientID=newClient.id,
                                            Name=newClient.name,
                                            InitialDeposit=newClient.initialDeposit
                                        }, "CreateClient");
        }

        // PUT: api/Client/5
        public void Put([FromBody] UpdateClientDTO updateClient)
        {
            if (updateClient.quantity >= 0)
            {
                MvcApplication.Bus.Publish(new DepositMoneyCommand()
                {
                    ClientID = updateClient.id,
                    Quantity = updateClient.quantity,
                    FromATM = bool.Parse(updateClient.inATM?? "False")
                }, "DepositMoney");
            }
            else
            {
                MvcApplication.Bus.Publish(new WithdrawMoneyCommand()
                {
                    ClientID = updateClient.id,
                    Quantity = updateClient.quantity,
                    FromATM = bool.Parse(updateClient.inATM ?? "False")
                }, "WithdrawMoney");
            }
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
