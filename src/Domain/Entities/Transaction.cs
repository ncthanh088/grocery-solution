using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Transaction : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime TransactionTime { get; set; }
        public Guid ExternalTransactionId { get; set; }
        public int Amount { get; set; }
        public float Fee { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Provider { get; set; }
    }
}