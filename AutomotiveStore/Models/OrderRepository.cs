using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveStore.Models;

namespace AutomotiveStore.Models
{
    public class OrderRepository : IOrderRepository
    {
        private StoreDbContext _storeDbContext;
        private ShoppingCart _shoppingCart;

        public OrderRepository(StoreDbContext storeDbContext, ShoppingCart shoppingCart)
        {
            _storeDbContext = storeDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _storeDbContext.Orders.Add(order);
            _storeDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.shoppingCartItems;

            foreach(var item in shoppingCartItems)
            {
                var orderDetails = new OrderDetail()
                {
                    Amount = item.Amount,
                    ProductID = item.Product.ProductID,
                    OrderId = order.OrderId,
                    Price = item.Product.Price
                };
                _storeDbContext.OrderDetails.Add(orderDetails);
            }

            _storeDbContext.SaveChanges();
        }

    }
}
