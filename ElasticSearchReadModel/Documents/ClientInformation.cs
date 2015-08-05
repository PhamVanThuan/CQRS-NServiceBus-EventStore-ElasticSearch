﻿using System;
using Nest;

namespace ElasticSearchReadModel.Documents
{
    public class ClientInformation
    {
        public string ID { get; set; }

        public string Name { get; set; }

        [ElasticProperty(Type = FieldType.Double)]
        public double Balance { get; set; }

        [ElasticProperty(Type = FieldType.Date)]
        public DateTime LastMovement { get; set; }

        public bool PossiblyStolen { get; set; }
    }
}
