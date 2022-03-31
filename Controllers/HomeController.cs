using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StringAnalyzer.Models;

namespace StringAnalyzer.Controllers
{
    public class HomeController : Controller
    {

        //     private const StringStatistics defaultString = StringStatistics ("Toto je defaultni string pro testovani. Kdyz vsechno selze pouzij tento.");
       // public const String defaultString = "Toto je defaultni string pro testovani. Kdyz vsechno selze pouzij tento.";
       
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TextInput()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult ShowResults(StringStatistics newString)
        {
            try
            {
                if (newString != null && newString.Text != null)
                    {
                    
                        return View("AnalyzeThis", newString);
                    }
                else
                {
                    return View("CantAnalyse");
                }

            }
            catch (Exception ex)
            {
                return View("CantAnalyse", ex);
            }
        }

        public ActionResult GraphAnalysis(StringStatistics newString)
        {
            //var zkusim = new StringStatistics();
            //zkusim = newString;
            //ViewBag.POKUS = zkusim.Alpabetize();
            //ViewBag.DELKA = zkusim.Delky();

            try
            {
                if (newString != null && newString.Text != null)
                {
                    return View("GraphAnalysis", newString);
                }
                else
                {
                    return View("CantAnalyse");
                }
            }
            catch (Exception ex)
            {
                return View("CantAnalyse", ex);
            }      
        }


        /**

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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

        **/
    }
}
