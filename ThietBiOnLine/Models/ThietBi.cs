using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;using ThietBiOnLine.Models;

namespace ThietBiOnLine.Models
{
    public class ThietBi
    {
        [ScaffoldColumn(false)]
        public int ThietBiID { get; set; }
        [Required, StringLength(100), Display(Name = "Ten")]
        public string TenThietBi { get; set; }
        [Required, StringLength(1000), Display(Name = "MieuTaThietBi"),
        DataType(DataType.MultilineText)]
        public string MieuTa { get; set; }
        public string HinhAnh { get; set; }
        [Display(Name = "Gia")]
        public float? GiaBan { get; set; }
        public int? HangID { get; set; }
        public virtual Hang Hang { get; set; }
    }
}