using System;
using CrossCutting.Repository;
using Domain.Aggregates;
using Messages.Commands;
using StructureMap;

namespace CreateClient
{
    public static class CreateClientHandler
    {
        public static void Handle(CreateClientCommand message)
        {
            Console.WriteLine("Received command: ClientId {0}", message.ClientID);
            var domainRepository = ObjectFactory.GetInstance<IDomainRepository>();
            var client = Client.CreateClient(message.ClientID, message.Name);
            client.Deposit(message.InitialDeposit, DateTime.UtcNow, message.TransactionId);
            domainRepository.Save(client, true);
        }
    }
}
