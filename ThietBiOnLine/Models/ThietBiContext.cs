using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ThietBiOnLine.Models
{
    public class ThietBiContext : DbContext
    {
        public ThietBiContext() : base("ThietBiOnline")
        { }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<ThietBi> ThietBis { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
    }
}