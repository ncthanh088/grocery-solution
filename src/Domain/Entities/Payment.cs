using Domain.Enums;

namespace Grocery.Domain.Entities
{
    public class Payment
    {
        public long Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool Allowed { get; set; }
    }
}