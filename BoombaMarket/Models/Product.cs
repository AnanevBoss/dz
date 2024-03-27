using System;
using System.Collections.Generic;

namespace BoombaMarket.Models
{
    public partial class Product
    {
        public Product()
        {
            Feedbacks = new HashSet<Feedback>();
            OrderItems = new HashSet<OrderItem>();
            PhotoProducts = new HashSet<PhotoProduct>();
        }

        public int IdProduct { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? Sale { get; set; }



        public virtual Category Category { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<PhotoProduct> PhotoProducts { get; set; }
    }
}
