using System;
using CrossCutting.Repository;
using EasyNetQ;
using Messages.Commands;
using StructureMap;

namespace CreateClient
{
    class Program
    {
        static readonly IBus Bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true");

        static void Main(string[] args)
        {
            ObjectFactory.Initialize(o => o.For<IDomainRepository>().Use<EventStoreDomainRepository>());
            Bus.Subscribe<CreateClientCommand>("CreateClientCommand", CreateClientHandler.Handle);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
