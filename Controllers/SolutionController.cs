using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tanger_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : Controller
    {
        // GET: SolutionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SolutionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SolutionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolutionController/Create
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

        // GET: SolutionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SolutionController/Edit/5
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

        // GET: SolutionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SolutionController/Delete/5
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
