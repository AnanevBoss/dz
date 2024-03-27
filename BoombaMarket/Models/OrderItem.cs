﻿using System;
using System.Collections.Generic;

namespace BoombaMarket.Models
{
    public partial class OrderItem
    {
        public int IdOrderItem { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
