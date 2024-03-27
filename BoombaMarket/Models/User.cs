using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoombaMarket.Models
{
    public partial class User
    {
        
            


            public User()
            {
                Feedbacks = new HashSet<Feedback>();
                Orders = new HashSet<Order>();
                Products = new HashSet<Product>();
                Profiles = new HashSet<Profile>();
                Shops = new HashSet<Shop>();
            }

            public int IdUser { get; set; }
            public int RoleId { get; set; }
            public string? Login { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }

            public virtual Role Role { get; set; } = null!;
            public virtual ICollection<Feedback> Feedbacks { get; set; }
            public virtual ICollection<Order> Orders { get; set; }
            public virtual ICollection<Product> Products { get; set; }
            public virtual ICollection<Profile> Profiles { get; set; }
            public virtual ICollection<Shop> Shops { get; set; }
        }
    

}

