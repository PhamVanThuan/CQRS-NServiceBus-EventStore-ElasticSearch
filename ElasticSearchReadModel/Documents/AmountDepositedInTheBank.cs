using System;
using Nest;

namespace ElasticSearchReadModel.Documents
{
    public class AmountDepositedInTheBank
    {        
        public Guid TransactionId { get; set; }

        [ElasticProperty(Type = FieldType.Double)]
        public double Quantity { get; set; }

        [ElasticProperty(Type = FieldType.Date)]
        public DateTime TimeStamp { get; set; }

        [ElasticProperty(Type = FieldType.Date)]
        public string ID { get; set; }
    }
}
