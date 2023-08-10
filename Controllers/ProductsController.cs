using EcommerceStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStore.Controllers
{


    public class ProductsController : Controller
    {





        private readonly ecommerce_appContext _ecommerce_appContext;

        public ProductsController(ecommerce_appContext ecommerce_appContext)
       {

            _ecommerce_appContext = ecommerce_appContext;


             }






        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Add(Product pr )
        {
            _ecommerce_appContext.Products.Add( pr );
            _ecommerce_appContext.SaveChanges();


            return View();


        }


        public IActionResult List(int id) {

            IList<Product> productslist = _ecommerce_appContext.Products.ToList();
    





            return View(productslist);

        }





        public IActionResult Detail(int id)
        {
           var ui=  _ecommerce_appContext.Products.Find(id);
           


            return View(ui);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
           var yy= _ecommerce_appContext.Products.Find(id);

            
            return View(yy);
        }
        [HttpPost]

        public IActionResult Edit(Product pr)
        {

            _ecommerce_appContext.Products.Update(pr);
            _ecommerce_appContext.SaveChanges();
                



            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

          var yu =  _ecommerce_appContext.Products.Find(id);
            return View(yu);



        }

        [HttpPost]
        public IActionResult Delete(Product pr)
        {
          var tg = _ecommerce_appContext.Products.Find(pr.Id);
            _ecommerce_appContext.Remove(tg);

            _ecommerce_appContext.SaveChanges();

            RedirectToAction("List");



            return RedirectToAction(nameof(List));

          



        }









    }
}
