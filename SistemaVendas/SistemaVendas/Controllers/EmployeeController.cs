using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Application.Interface;

using SistemaVendas.ViewModels;

namespace SistemaVendas.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeAppService _employeeAppService;

		public EmployeeController(IEmployeeAppService employeeAppService)
		{
			_employeeAppService = employeeAppService;
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
			var turno = new List<SelectListItem>
			{
				new SelectListItem { Value = "Manhan", Text = "Manhan" },
				new SelectListItem { Value = "Tarde" , Text = "Tarde"  },
				new SelectListItem { Value = "Noite" , Text = "Noite"  }
			};
			ViewBag.turno = turno;

			var sexo = new List<SelectListItem>
			{
				new SelectListItem {Value ="F", Text = "F"},
				new SelectListItem {Value ="M", Text = "M"},
				new SelectListItem {Value ="OU", Text = "OU"}
			};
			ViewBag.sexo = sexo;

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
				else
				{
					throw new Exception("preencha todos os campos!!");
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

			var turno = new List<SelectListItem>
			{
				new SelectListItem { Value = editEmployee.turno, Text = editEmployee.turno },
				new SelectListItem { Value = "Manhan", Text = "Manhan" },
				new SelectListItem { Value = "Tarde" , Text = "Tarde"  },
				new SelectListItem { Value = "Noite" , Text = "Noite"  }
			};
			ViewBag.turno = turno;

			var sexo = new List<SelectListItem>
			{
				new SelectListItem {Value =editEmployee.sexo, Text = editEmployee.sexo},
				new SelectListItem {Value ="F", Text = "F"},
				new SelectListItem {Value ="M", Text = "M"},
				new SelectListItem {Value ="OU", Text = "OU"}
			};
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
