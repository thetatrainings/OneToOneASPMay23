using EcommerceStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EcommerceStore.Controllers
{
    public class OrderController : Controller
    {
        readonly private ecommerce_appContext _ecommerce_appContext;
            public OrderController (ecommerce_appContext ecommerce_appContext)
           {


            _ecommerce_appContext = ecommerce_appContext;

             }


        [HttpGet]
        public IActionResult Add()
        {





            return View();
        }

        [HttpPost]
        public IActionResult Add(Order or)
        {
            _ecommerce_appContext.Orders.Add(or);
            _ecommerce_appContext.SaveChanges();
            return View();
           }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ui = _ecommerce_appContext.Orders.Find(id);
            return View(ui);

        }



        [HttpPost]
        public IActionResult Edit(Order or)
        {
            _ecommerce_appContext.Orders.Add(or);
            _ecommerce_appContext.SaveChanges();
            return View();
        }

        public IActionResult Detail(int id)
        {

            var ui = _ecommerce_appContext.Orders.Find(id);
            return View(ui);
        }


        public IActionResult List(int id)
        {


            IList<Order>orderslist = _ecommerce_appContext.Orders.ToList();

            return View(orderslist);


        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ui = _ecommerce_appContext.Orders.Find(id);
            return View(ui);

          }
        [HttpPost]

        public IActionResult Delete(Order obj)
        {

          var vr=  _ecommerce_appContext.Orders.Find(obj.Id);
            _ecommerce_appContext.Orders.Remove(vr);
            RedirectToAction("List");

            return RedirectToAction(nameof(List));



          

        }





















        public IActionResult Index()
        {
            return View();
        }
    }
}
