CQRS-EasynetQ-EventStore-ElasticSearch
=========================================

Prototipe showing a CQRS architecture using EasynetQ EventStore and ElasticSearch. 

Originally created using NServiceBus as event dispatcher. 
I implemented the same behaviours using EasynetQ and RabbitMq as Bus infrastructure.

More info on my blog: http://dinuzzouk.azurewebsites.net/cqrs-with-event-sourcing-using-easynetq-event-store-elastic-search-angularjs-and-asp-net-mvc/ 

Based on Pablo Castilla blog post:
http://pablocastilla.wordpress.com/2014/09/22/cqrs-with-event-sourcing-using-nservicebus-event-store-elastic-search-angularjs-and-asp-net-mvc/


To run it you need to:

– Download event store and run it. For example: “.\EventStore.ClusterNode.exe -db .\ESData --run-projections=ALL”

– Load the projections in the .NET solution (EventStore/Projections) on event store. Create them as continuous. Make sure that every projection in the system is running.

– Download ElasticSearch

– Run the services, UI and the synchronicers.
