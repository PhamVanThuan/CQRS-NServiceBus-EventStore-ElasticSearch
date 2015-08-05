using System;
using CrossCutting.Repository;
using Domain.Aggregates;
using Messages.Commands;
using StructureMap;

namespace WithdrawMoney
{
    public static class WithdrawMoneyHandler
    {
        public static void Handle(WithdrawMoneyCommand message)
        {
            Console.WriteLine("Received WithdrawMoneyCommand: ClientId {0}", message.ClientID);
            var domainRepository = ObjectFactory.GetInstance<IDomainRepository>();
            var client = domainRepository.GetById<Client>(message.ClientID);
            client.Withdraw(message.Quantity, DateTime.UtcNow, message.TransactionId, message.FromATM);
            domainRepository.Save(client);
        }
    }
}
