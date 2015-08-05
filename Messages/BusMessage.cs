using System;

namespace Messages
{
    public class BusMessage
    {
        public Guid MessageId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
