using System;
using System.Collections.Generic;

namespace BoombaMarket.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderShops = new HashSet<OrderShop>();
        }

        public int IdOrder { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Status Status { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderShop> OrderShops { get; set; }
    }
}
