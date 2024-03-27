using System;
using System.Collections.Generic;

namespace BoombaMarket.Models
{
    public partial class Profile
    {
        public int IdProfile { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
