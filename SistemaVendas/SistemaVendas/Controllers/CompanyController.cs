using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;

namespace SistemaVendas.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ICompanyAppService _companyAppService;
        public CompanyController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }




        // GET: CompanyController
        public IActionResult GetCompany()
        {

            var company = _companyAppService.GetCompany();

            return View(company);
        }

        // GET: CompanyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyController/Create
        public ActionResult CreateCompany()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompany(CompanyViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _companyAppService.CreateCompany(collection);

                    TempData["SuccessMessage"] = "Salvo com sucesso!!";
                }

                return RedirectToAction("GetCompany", "Company");
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Edit/5
        public ActionResult UpdateCompany(int id)
        {
            var update = _companyAppService.GetCompanyId(id);

            return View(update);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCompany(int id, CompanyViewModel collection)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    _companyAppService.UpdateCompany(id, collection);

                    TempData["SuccessMessage"] = "Atualizado com sucesso!";

                }
                return RedirectToAction("GetCompany", "Company");

            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyController/Delete/5
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
