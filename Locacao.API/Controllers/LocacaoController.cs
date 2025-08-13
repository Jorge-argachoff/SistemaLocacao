using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.API.Controllers
{
    public class LocacaoController : Controller
    {
        // GET: LocacaoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LocacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocacaoController/Create
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

        // GET: LocacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocacaoController/Edit/5
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

        // GET: LocacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocacaoController/Delete/5
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
