using System;
using System.Collections.Generic;

namespace BoombaMarket.Models
{
    public partial class PhotoProduct
    {
        
        public int IdPhotoProducts { get; set; }
        public int ProductId { get; set; }
        public byte[] Photo { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
