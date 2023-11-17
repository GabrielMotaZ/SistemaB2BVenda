using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;

namespace SistemaVendas.Controllers
{
    public class ClientController : Controller
    {

        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;

        }


        
        // GET: ClientController
        public IActionResult GetClient()
        {
            var client = _clientAppService.getClient();

            return View(client);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult CreatClient()
        {
            var sexo = new List<SelectListItem>
            {
                new SelectListItem {Value ="F", Text = "F"},
                new SelectListItem {Value ="M", Text = "M"},
                new SelectListItem {Value ="OU", Text = "OU"}
            };
            ViewBag.sexo = sexo;

            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatClient(ClientViewModel collection)
        {
            try
            {
                if (ModelState.IsValid) { }

                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult UpdatClient(int id)
        {
            var client = _clientAppService.getClientId(id);

            var sexo = new List<SelectListItem>
            {
                new SelectListItem {Value =client.Sexo, Text = client.Sexo},
                new SelectListItem {Value ="F", Text = "F"},
                new SelectListItem {Value ="M", Text = "M"},
                new SelectListItem {Value ="OU", Text = "OU"}
            };
            ViewBag.sexo = sexo;
            return View(client);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatClient(int id, ClientViewModel collection)
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
