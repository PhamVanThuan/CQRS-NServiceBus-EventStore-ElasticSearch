using System;
using CrossCutting.Repository;
using Domain.Aggregates;
using Messages.Commands;
using StructureMap;

namespace DepositMoney
{
    public static class DepositMoneyHandler
    {
        public static void Handle(DepositMoneyCommand message)
        {
            Console.WriteLine("Received DepositMoneyCommand: ClientId {0}", message.ClientID);
            var domainRepository = ObjectFactory.GetInstance<IDomainRepository>();
            var client = domainRepository.GetById<Client>(message.ClientID);
            client.Deposit(message.Quantity, DateTime.UtcNow, message.TransactionId, message.FromATM);
            domainRepository.Save<Client>(client);
        }
    }
}
