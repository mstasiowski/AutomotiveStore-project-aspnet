using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveStore.Models;

namespace AutomotiveStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;

            if(_shoppingCart.shoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Koszyk jest pusty!");
            }

            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("ConfirmCheckout");
            }
            return View(order);
        }

        public IActionResult ConfirmCheckout()
        {
            ViewBag.CheckoutCompleteMessage = "Dziękujemy za złożenie zamówienia.";
            return View();
        }

    }
}
