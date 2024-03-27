using BoombaMarket.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace BoombaMarket.Controllers
{
    public class HomeController : Controller
    {

        private MarketplaceDBContext db;

        public HomeController(MarketplaceDBContext context)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

    
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Login == null || model.Password == null)
                {
                    return RedirectToAction("SignIn", "Home");
                }

                User user = await db.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("AuthUser", model.Login);
                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return RedirectToAction("SignIn", "Home");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new[]
                        {
                        new Claim(
                            ClaimTypes.Name, userName
                        )
                    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("AuthUser");
            return RedirectToAction("SignIn");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User person)
        {

            Console.WriteLine(person);
                db.Users.Add(person);
                await db.SaveChangesAsync();
                return RedirectToAction("SignIn");

        }

        public IActionResult Search(string query)
{
    // Ищем продукты с названием, содержащим заданный запрос
    var searchResults = db.Products.Where(p => p.Name.Contains(query)).ToList();
    
    return View(searchResults);
}

        public IActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return View(product);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await db.Products.FirstOrDefaultAsync(p => p.IdProduct == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await db.Products.FirstOrDefaultAsync(p => p.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> EditPost(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]

        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await db.Products.FirstOrDefaultAsync(p => p.IdProduct == id);
            if (product != null)
            {
                return View(product);
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

    }
}

