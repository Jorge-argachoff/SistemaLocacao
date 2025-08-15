using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.API.Controllers
{
    public class EntregadoresController : Controller
    {
        // GET: EntregadoresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EntregadoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntregadoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntregadoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EntregadoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntregadoresController/Edit/5
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

        // GET: EntregadoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntregadoresController/Delete/5
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
