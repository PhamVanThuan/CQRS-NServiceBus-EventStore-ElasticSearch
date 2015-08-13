using System;
using CrossCutting.Repository;
using EasyNetQ;
using Messages.Commands;
using StructureMap;

namespace DepositMoney
{
    class Program
    {
        public static IBus Bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true");

        static void Main(string[] args)
        {
            Console.WriteLine("Start console...");
            ObjectFactory.Initialize(o => o.For<IDomainRepository>().Use<EventStoreDomainRepository>());
            Bus.Subscribe<DepositMoneyCommand>("DepositMoneyCommand", DepositMoneyHandler.Handle);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
