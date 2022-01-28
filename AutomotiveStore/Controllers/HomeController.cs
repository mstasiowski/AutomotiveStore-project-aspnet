using Microsoft.AspNetCore.Mvc;
using AutomotiveStore.Models;
using System.Linq;



namespace AutomotiveStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int AmountOfPageElement = 4;

        public HomeController(IStoreRepository _repository)
        {
            repository = _repository;
        }


        public ViewResult Index(int productPage = 1) => View(new ProductListView
        {
            Products = repository.Products
            .OrderBy(p=>p.ProductID)
            .Skip((productPage - 1) * AmountOfPageElement)
            .Take(AmountOfPageElement),

            PagingNumInfo = new PagingNumInfo
            {
                CurrentPage = productPage,
                ProductPerPage = AmountOfPageElement,
                AllElement = repository.Products.Count()
            }

        });

        public IActionResult Privacy()
        {
            return View();
        }

    }   


}

