using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThietBiOnLine.Models;

namespace ThietBiOnLine.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }
        private ThietBiContext _db = new ThietBiContext();
        public const string CartSessionKey = "CartId";
        public void AddToCart(int id)
        {
            // Retrieve the product from the database.
            ShoppingCartId = GetCartId();
            var cartItem = _db.GioHangs.SingleOrDefault(
            c => c.CartId == ShoppingCartId
            && c.ThietBiId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.
                cartItem = new GioHang
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ThietBiId = id,
                    CartId = ShoppingCartId,
                    ThietBi = _db.ThietBis.SingleOrDefault(
               p => p.ThietBiID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                _db.GioHangs.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,
                // then add one to the quantity.
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }
        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }
        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] =
                   HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }
        public List<GioHang> GetCartItems()
        {
            ShoppingCartId = GetCartId();
            return _db.GioHangs.Where(
            c => c.CartId == ShoppingCartId).ToList();
        }
        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
            // Tổng tiền mỗi cuốn sách (Item Total) = đơn giá (UnitPrice) nhân
            // số lượng (Quantity). Tổng của các tổng tiền chính là
            // số tiền mà người dùng phải trả (Order Total)
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _db.GioHangs
                               where cartItems.CartId == ShoppingCartId
                               select (int?)cartItems.Quantity *
                                cartItems.ThietBi.GiaBan).Sum();
            return total ?? decimal.Zero;
        }
        public ShoppingCartActions GetCart(HttpContext context)
        {
            using (var cart = new ShoppingCartActions())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

      
        public void UpdateItem(string updateCartID, int updateBookID, int
        quantity)
        {
            using (var _db = new ThietBiOnLine.Models.ThietBiContext())
            {
                try
                {
                    var myItem = (from c in _db.GioHangs
                                  where c.CartId == updateCartID && c.ThietBi.ThietBiID == updateBookID
                                  select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantity = quantity;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " +
                    exp.Message.ToString(), exp);
                }
            }
        }
        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = _db.GioHangs.Where(
            c => c.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                _db.GioHangs.Remove(cartItem);
            }
            // cập nhật
            _db.SaveChanges();
        }
        public int GetCount()
        {
            ShoppingCartId = GetCartId();
            // Đếm và tính tổng
            int? count = (from cartItems in _db.GioHangs
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Quantity).Sum();
            // Trả về 0 nếu rỗng
            return count ?? 0;

        }
        public struct ShoppingCartUpdates
        {
            public int ThietBiID;
            public int PurchaseQuantity;
        }
    }

}