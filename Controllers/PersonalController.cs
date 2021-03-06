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
    public class PersonalController : Controller
    {
        private readonly DbFarmaciaContext _db;
        public PersonalController(DbFarmaciaContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarPersonal() //
        {
            return View();
        }
        [HttpPost]//implicitamente es get para que sea post al que agregarselo
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarPersonal(Personal personal)
        {
            if (ModelState.IsValid) //valida si el modelo es correcto
            {
                await _db.Personal.AddAsync(personal); //enviamos a la base de datos
                await _db.SaveChangesAsync(); //especie de commit
                return RedirectToAction((nameof(AgregarPersonal))); // que redireccione a la vista crear
            }
            return View(personal); //si los datos estan malos retorna la vista con los datos
        }

        [HttpGet]
        public async Task<IActionResult> MostrarTodos()
        {
            var todas = await _db.Personal.ToListAsync();
            return Json(new { data = todas });
            
        }
    }

}
