using System;
using Grocery.Domain.Common;
using Grocery.Domain.Enums;

namespace Grocery.Domain.Entities
{
    public class Payment : IEntity<long>
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LatestUpdatedOn { get; set; }
        public decimal Amount { get; set; }
        public decimal PaymentFee { get; set; }
        public string PaymentMethod { get; set; }
        public string GatewayTransactionId { get; set; }
        public PaymentStatus Status { get; set; }
        public string FailureMessage { get; set; }
    }
}