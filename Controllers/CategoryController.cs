using EcommerceStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStore.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ecommerce_appContext _ecommerce_appContext;

        public CategoryController(ecommerce_appContext ecommerce_appContext)
        {


            _ecommerce_appContext = ecommerce_appContext;

        }

        [HttpGet]
        public IActionResult  Add()
        { return View(); }
        

        [HttpPost]
        public IActionResult Add(Category ct)
        {
            _ecommerce_appContext.Categories.Add( ct );
            _ecommerce_appContext.SaveChanges();
    
             return View();
  }

        public IActionResult Detail(int id)
        {

            var ca =_ecommerce_appContext.Categories.Find(id);

             return View(ca);

        }
        public IActionResult List(int id) {


            IList<Category> categorieslist = _ecommerce_appContext.Categories.ToList();

            return View(categorieslist);


            }


        [HttpGet]
        public IActionResult Edit(int id) {





            var cab = _ecommerce_appContext.Categories.Find(id);

            return View(cab);



           }


        [HttpPost]

        public IActionResult Edit(Category cat)
        {

            _ecommerce_appContext.Categories.Update(cat);
            _ecommerce_appContext.SaveChanges(); 
               return View();



        }


        [HttpGet]
        public IActionResult Delete(int id)
        {

            var cabe = _ecommerce_appContext.Categories.Find(id);

            return View(cabe);

        }


        [HttpPost]

        public IActionResult Delete(Category cat) {


            var tu = _ecommerce_appContext.Categories.Find(cat.Id);


            _ecommerce_appContext.Categories.Remove(tu);

            _ecommerce_appContext.SaveChanges();

            RedirectToAction("List");



            return RedirectToAction(nameof(List));



        
        }



     
       public IActionResult Index()
        {
            return View();
        }
    }
}
