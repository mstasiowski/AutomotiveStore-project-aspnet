using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveStore.Models;

namespace AutomotiveStore.Controllers
{
    public class ProductController : Controller
    {
                private ICRUDStoreRepository repository;
                private IStoreRepository storeRepository;

                public ProductController(ICRUDStoreRepository _repository, IStoreRepository _storeRepository)
                {
                     repository = _repository;
                      storeRepository = _storeRepository;
                }


                public IActionResult Index()
                {
                    return View();
                }

                public IActionResult AddProduct()
                {
                    return View();
                }
                [HttpPost]
                public IActionResult Add(Product product)
                {
                    if (ModelState.IsValid)
                    {
                        return View("ConfirmProduct", repository.Add(product));
                    }
                    else
                    {
                        return View("AddProduct");
                    }
                }

                public IActionResult ProductList()
                {
                    return View(repository.FindAll());
                }

                public IActionResult Delete(int id)
                {
                    repository.Delete(id);
                    return View("ProductList", repository.FindAll());
                }

                public IActionResult EditProduct(int id)
                {
                    return View(repository.FindById(id));
                }

                public IActionResult Edit(Product product)
                {
                    repository.Update(product);
                    return View("ProductList", repository.FindAll());
                }
    }
}
   

