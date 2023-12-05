using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Contexto;
using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace SistemaVendas.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginAppService _loginAppService;

        private readonly IEmailAppService _emailAppService;

        public LoginController(ILoginAppService loginAppService, IEmailAppService emailAppService)
        {
            _loginAppService = loginAppService;
            _emailAppService = emailAppService;
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
        public IActionResult QueryLogin(string email, string? Senha)
        {
			try
            {
                    var user = _loginAppService.GetLogin(email, Senha);
                
                return RedirectToRoute(new { controller = "Main", action = "ListSales" /*id = 1 */});
			}
			catch (InvalidOperationException te)
			{
				
				TempData["InfoMessage"] = te.Message;
				return RedirectToAction("Login");
			}
            catch(NullReferenceException ex) 
            {
			
				TempData["InfoMessage"] = ex.Message;
				return RedirectToAction("UpdateLogin", new { Email = email });
                
			}
	
        }


 
        // GET: LoginController/Edit/5
        public IActionResult UpdateLogin(string email)
        {
            var teste = new LoginViewModel();
            try
            {
				var login = _loginAppService.GetLogin(email, null);

				    _emailAppService.EmailPassword(login.Email, login.Nome);

                teste = login;
				
				return View(login);
			}
            catch (InvalidOperationException ex)
            {
				TempData.Clear();
				TempData["InfoMessage"] = ex.Message;
				return RedirectToAction("Login");
			}
			catch (NullReferenceException ex)
			{

				TempData["InfoMessage"] = ex.Message;
				return View(teste);

			}


		}

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLogin(int id, LoginViewModel loginViewModel)
        {
            try
            {
               
                _loginAppService.UpdateLogin(id, loginViewModel);

                return RedirectToAction("Login");
            }
			catch (ArgumentNullException te)
			{
		
				TempData["InfoMessage"] = te.Message;
				return RedirectToAction("UpdateLogin");
			}
            catch (InvalidOperationException ex)
            {
				
				TempData["InfoMessage"] = ex.Message;
				return RedirectToAction("UpdateLogin", new { Email = loginViewModel.Email });
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
