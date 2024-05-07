using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tanger_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirPollutionController : Controller
    {
        // GET: AirPollutionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AirPollutionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AirPollutionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirPollutionController/Create
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

        // GET: AirPollutionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AirPollutionController/Edit/5
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

        // GET: AirPollutionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AirPollutionController/Delete/5
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
