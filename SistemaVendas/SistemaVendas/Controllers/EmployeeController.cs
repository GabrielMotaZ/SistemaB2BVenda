using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;

namespace SistemaVendas.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly ICompanyAppService _companyAppService;

        public EmployeeController(IEmployeeAppService employeeAppService, ICompanyAppService companyAppService)
        {
            _employeeAppService = employeeAppService;
            _companyAppService = companyAppService;
        }

        //[Authorize]
        public IActionResult ListEmployee(string nome)
        {
            var clientList = _employeeAppService.GetEmployee(nome);

            return View(clientList);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateEmployee()
        {

            var turno = new List<SelectListItem>();

            foreach (var valorEnum in Enum.GetValues(typeof(enumViewModel.turno)))
            {
                turno.Add(new SelectListItem
                {
                    Text = valorEnum.ToString(),
                    Value = ((int)valorEnum).ToString()
                });
            }
            ViewBag.turno = turno;


            var sexo = new List<SelectListItem>();

            foreach (var valorEnum in Enum.GetValues(typeof(enumViewModel.genero)))
            {
                sexo.Add(new SelectListItem
                {
                    Text = valorEnum.ToString(),
                    Value = ((int)valorEnum).ToString()
                });
            }
            ViewBag.sexo = sexo;

            var company = new List<SelectListItem>();
            foreach (var comp in _companyAppService.GetCompany())
            {
                company.Add(new SelectListItem
                {
                    Text = comp.Nome,
                    Value = ((int)comp.Id).ToString()
                });
            }
            ViewBag.company = company;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee([FromForm] EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeAppService.CreateEmployee(employeeViewModel);

                    TempData["SuccessMessage"] = "Salvo com sucesso!!";
                }

                return RedirectToAction("ListEmployee", "Employee");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return PartialView("_ViewAll", employeeViewModel);

            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult UpdateEmployee(int id)
        {

            var editEmployee = _employeeAppService.GetEmployeeId(id);

            var turno = new List<SelectListItem>();

            foreach (var valorEnum in Enum.GetValues(typeof(enumViewModel.turno)))
            {
                turno.Add(new SelectListItem
                {
                    Text = valorEnum.ToString(),
                    Value = ((int)valorEnum).ToString()
                });
            }
            ViewBag.turno = turno;


            var sexo = new List<SelectListItem>();

            foreach (var valorEnum in Enum.GetValues(typeof(enumViewModel.genero)))
            {
                sexo.Add(new SelectListItem
                {
                    Text = valorEnum.ToString(),
                    Value = ((int)valorEnum).ToString()
                });
            }
            ViewBag.sexo = sexo;


            return View(editEmployee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(int id, [FromForm] EmployeeViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _employeeAppService.UpdateEmployee(id, collection);

                    TempData["SuccessMessage"] = "Atualizado com sucesso!";
                    return RedirectToAction("ListEmployee", "Employee");
                }
                else
                {

                    collection.IdFunc = id;

                    throw new Exception("preencha todos os campos!!");
                }



            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                //return View();
                return PartialView("_ViewAll", collection);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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
