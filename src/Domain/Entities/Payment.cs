using Domain.Enums;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Payment : IEntity<int>
    {
        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool Allowed { get; set; }
    }
}