using EcommerceStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStore.Controllers
{


    public class ProductsController : Controller
    {





        private readonly ecommerce_appContext _ecommerce_appContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(ecommerce_appContext ecommerce_appContext, IWebHostEnvironment webHostEnvironment)
       {

            _ecommerce_appContext = ecommerce_appContext;
            _webHostEnvironment = webHostEnvironment;

             }






        [HttpGet]
        public IActionResult Add()
        {
            
            ViewBag.Catagory = _ecommerce_appContext.Products.ToList();
            return View();
        }



        [HttpPost]
        public IActionResult Add(Product pr, List<IFormFile>? img)
        {
            var CommaSeperated = "";
            if(img != null)
            {
                foreach(var SingleImg in img)
                {
                    string Name = Guid.NewGuid().ToString();
                    string fileExtention = Path.GetExtension(SingleImg.FileName);
                    string FinalPath = "/data/" + Name + fileExtention;
                    using (FileStream FS = new FileStream(_webHostEnvironment.WebRootPath + FinalPath, FileMode.Create))
                    {
                        SingleImg.CopyTo(FS);
                    }
                    CommaSeperated += "," + FinalPath;
                }
            }
            if (CommaSeperated.StartsWith(","))
            {
                CommaSeperated = CommaSeperated.Remove(0, 1);
            }
            pr.Image = CommaSeperated;
            _ecommerce_appContext.Products.Add( pr );
            _ecommerce_appContext.SaveChanges();
            ViewBag.Catagory = _ecommerce_appContext.Products.ToList();

            return RedirectToAction(nameof(Lists));


        }


        public IActionResult Lists() {

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


            return RedirectToAction(nameof(Lists));

          



        }




        public IActionResult Index()
        {
            return View();
        }


        public string GetProducts()
        {
            var pro = _ecommerce_appContext.Products.Take(4).ToList();
            var productString = "<div class='row row-cols-1 row-cols-md-3 g-4'>";
            foreach(var item in pro)
            {
                if(item.Image != null)
                {
                    productString += "<div class='col'><div class='card h-100'> <img src='" + item.Image.Split(",")[0] + "' class='card-img-top' alt='...'><div class='card-body'><h5 class='card-title'>" + item.Description + "</p></div></div></div>";
                }
            }
            productString += "</div>";
           return productString;
        }

    }
}
