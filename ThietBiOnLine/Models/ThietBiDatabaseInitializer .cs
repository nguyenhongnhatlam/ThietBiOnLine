using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ThietBiOnLine.Models
{
    public class ThietBiDatabaseInitializer : DropCreateDatabaseAlways<ThietBiContext>
    {
        protected override void Seed(ThietBiContext context)
        {
            Hangs().ForEach(c => context.Hangs.Add(c));
            ThietBis().ForEach(p => context.ThietBis.Add(p));
        }
        private static List<Hang> Hangs()
        {
            var Hangs = new List<Hang>

            {
                new Hang
                {
                   HangID = 1,
                    TenHang = "Hàng Mẫu"
                },
                new Hang
        {
                    HangID = 2, TenHang= "Hàng Mới"
        },
                new Hang
        {
                    HangID = 3,
                    TenHang = "Hàng Giảm Giá"
        },
                new Hang
        {
                    HangID = 4, TenHang = "Hàng tặng" } }; return Hangs;
        }
        private static List<ThietBi> ThietBis()
        {
            var ThietBis = new List<ThietBi>
            {                 //book 1 

 new ThietBi
{
    ThietBiID = 1,
   TenThietBi = "combo apple",
    MieuTa  = "Gồm laptop,Máy in, Tv, ipad,...",
  HinhAnh="hinh1.jpg",
  GiaBan = 100.000f,
   HangID = 1
     },                
  //book 2     
     new ThietBi
    {
          ThietBiID = 2,
          TenThietBi = "combo banasonic",
          MieuTa = "các thiết bị chụp hình ,nghe nhạc ",
        HinhAnh ="hinh2.jpg",
 GiaBan = 40.000f,
 HangID = 2
 },                
  //book 3               
  new ThietBi
   {
     ThietBiID = 3,
     TenThietBi = "double kĩ thuật số",
    MieuTa = "bộ đôi điện thoại máy ảnh kĩ thuật số",
                     HinhAnh="images22.jpg",
        GiaBan = 26.730f,
         HangID = 2
  },               
   //book 4        
         new ThietBi
     {
   ThietBiID = 4,
       TenThietBi = "double s6",

               MieuTa = "điện thoại adroi và ios hàng 95%",
             HinhAnh ="iphone-0.jpg",
   GiaBan = 45.000f,
  HangID = 3
 },               
  //book 5               
  new ThietBi
      {
      ThietBiID = 5,
                  TenThietBi = "Bleuchannel",
                  MieuTa = "Hàng tặng không bán",
  HinhAnh="bleuchanel.jpg",
  GiaBan = 0.0f,
  HangID = 4
 },

            };
            return ThietBis;
        }
    }
}
    