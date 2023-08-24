﻿using EcommerceStore.Models;
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
