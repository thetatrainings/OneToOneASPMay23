using EcommerceStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStore.Controllers
{
    public class AdminController : Controller
    {




        private readonly ecommerce_appContext _ecommerce_appContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        CookieOptions _options = new CookieOptions();
        public AdminController(ecommerce_appContext ecommerce_appContext, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, CookieOptions options)
        {

            _ecommerce_appContext = ecommerce_appContext;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _options = options;
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            return View();
        }


        [HttpPost]
        public IActionResult Add(Admin am, IFormFile? img)
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
                am.Image = FinalPath;
            }
            am.CreatedDate = DateTime.Now;
            am.CreatedBy = "System";
            _ecommerce_appContext.Admins.Add(am);
            _ecommerce_appContext.SaveChanges();











            return View();
        }
        public IActionResult Detail(int id)
        {



            var va = _ecommerce_appContext.Admins.Find(id);




            return View(va);


        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var va = _ecommerce_appContext.Admins.Find(id);


            return View(va);


        }


        [HttpPost]
        public IActionResult Edit(Admin se)
        {
            se.ModifiedDate = DateTime.Now;
            se.ModifyBy = "Edit System";
            _ecommerce_appContext.Admins.Add(se);
            _ecommerce_appContext.SaveChanges();

            return View();


        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var va = _ecommerce_appContext.Admins.Find(id);
            return View(va);

        }
        [HttpPost]
        public IActionResult Delete(Admin se)
        {
            var tg = _ecommerce_appContext.Sellers.Find(se.Id);
            _ecommerce_appContext.Remove(tg);

            _ecommerce_appContext.SaveChanges();

            RedirectToAction("List");



            return RedirectToAction(nameof(List));





        }

        public IActionResult List(int id)
        {


            IList<Admin> Adminslist = _ecommerce_appContext.Admins.ToList();

            return View(Adminslist);




        }

        [HttpGet]
        public IActionResult Login()
        {
            //get Key
            var username = Request.Cookies["Username"];
            if(username != null)
            {
                return View(nameof(Add));
            }

            Response.Cookies.Delete("Username");
            return View(); 
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var adminExist = _ecommerce_appContext.Admins.Where(m => m.UserName == admin.UserName && m.Password == admin.Password).FirstOrDefault();
            if(adminExist != null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Username", adminExist.UserName);
                _options.Expires = DateTime.Now.AddDays(4);
                HttpContext.Session.SetString("Name", adminExist.UserName);
                HttpContext.Session.SetString("Role", adminExist.Role);
                return RedirectToAction(nameof(List));
            }
            ViewBag.NotFound = "Not Found";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View(nameof(Login));
        }
    }
}








