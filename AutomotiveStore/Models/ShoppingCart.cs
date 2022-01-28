using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AutomotiveStore.Models
{
    public class ShoppingCart
    {
        private StoreDbContext context;

        private ShoppingCart(StoreDbContext _context)
        {
            context = _context;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<StoreDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem =
                   context.shoppingCartItems.SingleOrDefault(
                       s => s.Product.ProductID == product.ProductID && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                context.shoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            context.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                    context.shoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductID == product.ProductID && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    context.shoppingCartItems.Remove(shoppingCartItem);
                }
            }

            context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ??
                   (shoppingCartItems =
                       context.shoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = context
                .shoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            context.shoppingCartItems.RemoveRange(cartItems);

            context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = context.shoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }


    }
}
