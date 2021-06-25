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
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarInventario() //
        {
            return View();
        }
        [HttpPost]//implicitamente es get para que sea post al que agregarselo
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarInventario(Inventario inventario)
        {
            if (ModelState.IsValid) //valida si el modelo es correcto
            {
                await _db.Inventario.AddAsync(inventario); //enviamos a la base de datos
                await _db.SaveChangesAsync(); //especie de commit
                return RedirectToAction((nameof(AgregarInventario))); // que redireccione a la vista crear
            }
            return View(inventario); //si los datos estan malos retorna la vista con los datos
        }

        [HttpGet]
        public async Task<IActionResult> MostrarTodos()
        {
            var todas = await _db.Inventario.ToListAsync();
            return Json(new { data = todas });
        }
    }

}
