using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeFarmacia.Data;
using SistemaDeFarmacia.Models;

namespace SistemaDeFarmacia.Controllers
{
    public class InventarioController : Controller
    {
        private readonly DbFarmaciaContext _db;
        public InventarioController(DbFarmaciaContext db)
        {
            _db = db;
        }

        // GET: Inventario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Inventario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearInventario(Inventario Inv)
        {
            if (ModelState.IsValid) // valida si el modelo es correcto
            {
                await _db.Inventario.AddAsync(Inv); //  con esto se envía a la base de datos
                await _db.SaveChangesAsync(); //  Guarda de forma asincrónica todos los cambios realizados en este contexto en la base de datos subyacente.
                return RedirectToAction((nameof(CrearInventario))); //  esto redirecciona a la vista correspondiente
            }
            return View(Inv); //  si los datos están malos retorna la vista con los datos
        }

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

        // GET: Inventario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventario/Edit/5
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

        // GET: Inventario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventario/Delete/5
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
        [HttpGet]
        public async Task<IActionResult> MostrarTodos()
        {
            var todas = await _db.CategoriaMedicamento.ToListAsync();
            return Json(new { data = todas });
        }

    }
}