using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SaffiraCloud.ApplicationCore.Entities;
using SaffiraCloud.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
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
        public async Task<IActionResult> Index(int page = 1, string sort = "Nome", string sortOrder = "", string searchPhrase = "")
        {
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = await GetPaisAsync(searchPhrase, sort, sortOrder, skip, pageSize, totalRecord);

            return View(data);
        }

        public async Task<List<Pais>> GetPaisAsync(string searchPhrase, string sort, string sortOrder, int skip, int pageSize, int totalRecord)
        {
            try
            {
                ViewBag.SortOrder = String.IsNullOrEmpty(sortOrder) ? "desc" : "";

                var paises = await _pais.GetAll();

                totalRecord = paises.Count;
                ViewBag.TotalRecord = totalRecord;

                SelectList pageSizeItems = new SelectList(new object[]
                {
                    new { Name = "10", Value = 10 },
                    new { Name = "25", Value = 25 },
                    new { Name = "50", Value = 50 },
                    new { Name = "100", Value = 100 },
                    new { Name = "Todos", Value = totalRecord }
                }, "Value", "Name");

                ViewBag.PageSize = pageSizeItems;

                if (!string.IsNullOrWhiteSpace(searchPhrase))
                    paises = paises.Where("nome.Contains(@0) OR codigoIBGE == @0 OR codigoISO.Contains(@0)", searchPhrase).ToList();

                if (pageSize > 0)
                    paises = paises.OrderBy(string.Format("{0} {1}", sort, sortOrder)).Skip(skip).Take(pageSize).ToList();

                return paises.ToList();
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