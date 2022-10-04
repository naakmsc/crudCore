using Microsoft.AspNetCore.Mvc;

using crudCore.Datos;
using crudCore.Models;

namespace crudCore.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //Mostrar una lista de contacto

            var olista = _contactoDatos.Listar();

            return View(olista);
        }

        public IActionResult Guardar()
        {
            //Metodo solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Recibir un objeto y guardar una base de datos

            if (!ModelState.IsValid)
                return View();

            var respuesta = _contactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int Id) {
            var oContacto = _contactoDatos.Obtener(Id);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto) {

            if (!ModelState.IsValid)
                return View();

            var respuesta = _contactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Id) 
        {
            var oContacto = _contactoDatos.Obtener(Id);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto) 
        {

            var respuesta = _contactoDatos.Eliminar(oContacto.Id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
