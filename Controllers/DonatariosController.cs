using Microsoft.AspNetCore.Mvc;
using SisDoBem.Models;

namespace SisDoBem.Controllers
{
    public class DonatarioController : Controller
    {
        private static List<Donatario> ListaDonatarios = new List<Donatario>();

        public IActionResult Index()
        {
            return View(ListaDonatarios);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Donatario model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = ListaDonatarios.Count + 1;
            ListaDonatarios.Add(model);

            return RedirectToAction("Index");
        }
    }
}
