using System;
using System.Collections.Generic;

namespace BoombaMarket.Models
{
    public partial class OrderShop
    {
        public int IdOrderShop { get; set; }
        public int OrderId { get; set; }
        public int ShopId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Shop Shop { get; set; } = null!;
    }
}
