using EcommerceStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Mail;

namespace EcommerceStore.Controllers
{
    public class SellerController : Controller
    {


        private readonly ecommerce_appContext _ecommerce_appContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SellerController(ecommerce_appContext ecommerce_appContext, IWebHostEnvironment webHostEnvironment)
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
        public IActionResult Add(Seller se , IFormFile? img)
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
                se.Image = FinalPath;
            }

            MailMessage mail = new MailMessage();
            mail.Subject = "Ecommerce Store";
            mail.Body = "HI Thanks for joining to Ecommerce Store";
            mail.To.Add("Usman@gmail.com");
            mail.Bcc.Add("usman2@gmail.com");
            mail.CC.Add("Usman3@gmail.com");

            mail.From = new MailAddress("Ecommerce@gmail.com", "Ecommerce Store");

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 456;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("emailName", "password");
            smtp.EnableSsl = true;

            smtp.Send(mail);

            _ecommerce_appContext.Sellers.Add(se);
            _ecommerce_appContext.SaveChanges();











            return View();
        }
        public IActionResult Detail(int id) {



            var va = _ecommerce_appContext.Sellers.Find(id);
            



        return View(va);
        
        
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var va = _ecommerce_appContext.Sellers.Find(id);


            return View(va);


        }


        [HttpPost]
        public IActionResult Edit(Seller se) {

            _ecommerce_appContext.Sellers.Add(se);
            _ecommerce_appContext.SaveChanges();

            return View();


        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var va = _ecommerce_appContext.Sellers.Find(id);
            return View(va);

        }
        [HttpPost]
        public IActionResult Delete(Seller se)
        {
            var tg = _ecommerce_appContext.Sellers.Find(se.Id);
            _ecommerce_appContext.Remove(tg);

            _ecommerce_appContext.SaveChanges();

            RedirectToAction("List");



            return RedirectToAction(nameof(List));





        }

       public IActionResult List(int id)
        {


            IList<Seller>sellerslist = _ecommerce_appContext.Sellers.ToList();

            return View(sellerslist);




        }






    }
}
