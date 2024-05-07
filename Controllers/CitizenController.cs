using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tanger_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : Controller
    {
        // GET: CitizenController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CitizenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CitizenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CitizenController/Create
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

        // GET: CitizenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CitizenController/Edit/5
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

        // GET: CitizenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CitizenController/Delete/5
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
