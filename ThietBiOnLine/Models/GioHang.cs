using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ThietBiOnLine.Models
{
    public class GioHang
    {
        [Key]
        public string ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int ThietBiId { get; set; }
        public virtual ThietBi ThietBi { get; set; }
    }
}