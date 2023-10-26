using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Application.Interface;
using SistemaVendas.ViewModels;

namespace SistemaVendas.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        // GET: LoginController
        [Route("")]
        [Route("Login")]
        [Route("[controller]/[action]")]
        [HttpGet("login")]
        public ActionResult Login()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult QueryLogin(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var user = _loginAppService.QueryLogin(loginViewModel);
                }

                return RedirectToRoute(new { controller = "Main", action = "ListSales" /*id = 1 */});
            }
            catch(Exception ex)
            {
                TempData["InfoMessage"] = ex.Message;
                return RedirectToAction("Login");
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
