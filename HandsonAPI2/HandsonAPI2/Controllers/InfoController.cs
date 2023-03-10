using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsonAPI2.Controllers
{
    public class InfoController : Controller
    {
        // GET: InfoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InfoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InfoController/Create
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

        // GET: InfoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InfoController/Edit/5
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

        // GET: InfoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InfoController/Delete/5
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
