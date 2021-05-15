using System;
using System.Collections.Generic;
using Grocery.Domain.Common;
using Grocery.Domain.Enums;

namespace Grocery.Domain.Entities
{
    public class Order : IEntity<long>
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public User Customer { get; set; }
        public DateTimeOffset LatestUpdatedOn { get; set; }
        public long LatestUpdatedById { get; set; }
        public User LatestUpdatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public long? VendorId { get; set; }
        public string CouponCode { get; set; }
        public string CouponRuleName { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SubTotalWithDiscount { get; set; }
        public long ShippingAddressId { get; set; }
        public OrderAddress ShippingAddress { get; set; }
        public long BillingAddressId { get; set; }
        public OrderAddress BillingAddress { get; set; }
        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderStatus OrderStatus { get; set; }
        public string OrderNote { get; set; }
        public long? ParentId { get; set; }
        public Order Parent { get; set; }
        public bool IsMasterOrder { get; set; }
        public string ShippingMethod { get; set; }
        public decimal ShippingFeeAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal OrderTotal { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PaymentFeeAmount { get; set; }
        public IList<Order> Children { get; protected set; } = new List<Order>();
    }
}