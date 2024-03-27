using System;
using System.Collections.Generic;

namespace BoombaMarket.Models
{
    public partial class Shop
    {
        public Shop()
        {
            OrderShops = new HashSet<OrderShop>();
        }

        public int IdShop { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderShop> OrderShops { get; set; }
    }
}
