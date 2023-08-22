using EcommerceStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStore.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ecommerce_appContext _ecommerce_appContext;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CustomerController(ecommerce_appContext ecommerce_appContext, IWebHostEnvironment webHostEnvironment)
        {


            _ecommerce_appContext = ecommerce_appContext;
               _webHostEnvironment = webHostEnvironment;


        }



        [HttpGet]
        public IActionResult Add()
        {
          
            
            
            return View();
        }



        [HttpPost]
        public IActionResult Add(Customer cu, IFormFile? img)
        {
            if (img != null)
            {
                string Name = Guid.NewGuid().ToString();
                string fileExtention = Path.GetExtension(img.FileName);
                string FinalPath = "/data/" + Name + fileExtention;
                using (FileStream FS = new FileStream(_webHostEnvironment.WebRootPath + FinalPath, FileMode.Create))
                {
                    img.CopyTo(FS);
                }
                cu.Image = FinalPath;
            }

            _ecommerce_appContext.Customers.Add(cu);
            _ecommerce_appContext.SaveChanges();



            return View();
        }


        public IActionResult Detail(int id) {

            var de = _ecommerce_appContext.Customers.Find(id);
            _ecommerce_appContext.SaveChanges();



            return View(de);


        }


        public IActionResult List(int id)
        {

            IList<Customer> customerslist = _ecommerce_appContext.Customers.ToList();


            return View(customerslist);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var de = _ecommerce_appContext.Customers.Find(id);
            _ecommerce_appContext.SaveChanges();



            return View(de);

        }

        [HttpPost]
        public IActionResult Edit(Customer cu)
        {
            
            _ecommerce_appContext.Customers.Update(cu);
            _ecommerce_appContext.SaveChanges();



            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id) {

            var de = _ecommerce_appContext.Customers.Find(id);
            _ecommerce_appContext.SaveChanges();



            return View(de);




        }


        [HttpPost]
        public IActionResult Delete(Customer cu)
        {

           var fg = _ecommerce_appContext.Customers.Find(cu.Id);
            _ecommerce_appContext.Customers.Remove(fg);
            _ecommerce_appContext.SaveChanges();
            RedirectToAction("List");



            return View();
        }









    }
}
