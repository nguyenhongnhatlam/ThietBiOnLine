using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ThietBiOnLine.Models
{
    public class Hang
    {
        [ScaffoldColumn(false)]
        public int HangID { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string TenHang { get; set; }
        public virtual ICollection<Hang> Hangs { get; set; }
    }
}