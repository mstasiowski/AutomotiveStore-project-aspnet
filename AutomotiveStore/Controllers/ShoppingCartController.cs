using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveStore.Models;

namespace AutomotiveStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IStoreRepository _storeRepository;
        private ShoppingCart _shoppingCart;

        public ShoppingCartController(IStoreRepository storeRepository, ShoppingCart shoppingCart)
        {
            _storeRepository = storeRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _storeRepository.Products.FirstOrDefault(p => p.ProductID == productId );
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _storeRepository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }

    }
}
