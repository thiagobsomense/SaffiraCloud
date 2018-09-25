using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaffiraCloud.ApplicationCore.Interfaces.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace SaffiraCloud.WebApp.Controllers
{
    public class PaisController : Controller
    {
        private readonly IPaisService _pais;

        public PaisController(IPaisService pais)
        {
            _pais = pais;
        }

        // GET: Pais
        public IActionResult Index()
        {
            return View();
        }

        static string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                              UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }

        public async Task<JsonResult> GetPaisAsync()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                string columnOrdered = string.Format("{0} {1}", sortColumn, sortColumnDirection);

                var paises = await _pais.GetAll();

                int recordsTotal = paises.Count;

                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    paises = paises.Where("nome.ToUpper().Contains(@0) OR codigoIBGE.Contains(@0) OR codigoISO.Contains(@0)", RemoveDiacritics(searchValue.ToUpper())).ToList();
                }

                int recordsFiltered = paises.Count;

                if (pageSize == -1)
                    pageSize = recordsTotal;

                var paisesOrdered = paises.OrderBy(columnOrdered).Skip(skip).Take(pageSize);

                return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = paisesOrdered });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pais/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}