﻿using System;
using CrossCutting.DomainBase;

namespace Domain.Events
{
    public class MoneyDeposited : IDomainEvent
    {
        public Guid TransactionId { get; set; }

        public string ClientID { get; set; }

        public double Quantity { get; set; }

        public DateTime TimeStamp { get; set; }
        public bool FromATM { get; set; }


        public MoneyDeposited(double quantity, DateTime timeStamp, string id, Guid transactionId, bool fromATM)
        {
            Quantity = quantity;

            TimeStamp = timeStamp;

            ClientID = id;

            TransactionId = transactionId;

            FromATM = fromATM;
        }
    }
}
