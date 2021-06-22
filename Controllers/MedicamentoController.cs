﻿using System;
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
    public class MedicamentoController : Controller
    {
        private readonly DbFarmaciaContext _db;

        public MedicamentoController(DbFarmaciaContext db)
        {
            _db = db;
        }
        // GET: Medicamento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Medicamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medicamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearMedicamento(Medicamentos Med)
        {
            if (ModelState.IsValid) // valida si el modelo es correcto
            {
                await _db.Medicamentos.AddAsync(Med); //  con esto se envía a la base de datos
                await _db.SaveChangesAsync(); //  Guarda de forma asincrónica todos los cambios realizados en este contexto en la base de datos subyacente.
                return RedirectToAction((nameof(CrearMedicamento))); //  esto redirecciona a la vista correspondiente
            }
            return View(Med); //  si los datos están malos retorna la vista con los datos
        }

        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Medicamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medicamento/Edit/5
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

        // GET: Medicamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medicamento/Delete/5
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