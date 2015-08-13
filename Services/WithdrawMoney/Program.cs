using System;
using CrossCutting.Repository;
using EasyNetQ;
using Messages.Commands;
using StructureMap;

namespace WithdrawMoney
{
    class Program
    {
        static readonly IBus Bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true");

        static void Main(string[] args)
        {
            Console.WriteLine("Start console...");
            ObjectFactory.Initialize(o => o.For<IDomainRepository>().Use<EventStoreDomainRepository>());
            Bus.Subscribe<WithdrawMoneyCommand>("WithdrawMoneyCommand", WithdrawMoneyHandler.Handle);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
