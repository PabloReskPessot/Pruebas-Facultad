using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    public class Mascotas : Controller
    {
        public BaseDatos _DB = new BaseDatos();

        // GET: Mascotas
        public ActionResult Index()
        {
            return View(_DB.ListadoMascotas());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mascotas/Create
        public ActionResult Create()
        {

            ViewBag.Razas = _DB.ListadoRazas();
            ViewBag.Dueños = _DB.ListadoDueños();

            return View();
        }

        // POST: Mascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Mascota mascota = new Mascota()
                {
                    nombre = collection["nombre"],
                    edad = int.Parse(collection["edad"]),
                    id_raza = int.Parse(collection["id_raza"]),
                    id_dueño = int.Parse(collection["id_dueño"])
                };

                _DB.CrearMascota(mascota);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mascotas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mascotas/Delete/5
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
