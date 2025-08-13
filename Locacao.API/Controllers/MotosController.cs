using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.API.Controllers
{
    public class MotosController : Controller
    {
        // GET: MotosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MotosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MotosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotosController/Create
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

        // GET: MotosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MotosController/Edit/5
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

        // GET: MotosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MotosController/Delete/5
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
