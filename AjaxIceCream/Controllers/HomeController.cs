using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxIceCream.Data;

namespace AjaxIceCream.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrders()
        {
            var repo = new IceCreamRepository();
            IEnumerable<IceCream> orders = repo.GetOrders();
            return View(orders);
        }
        public ActionResult GetOrdersAjax()
        {
            var repo = new IceCreamRepository();
            IEnumerable<IceCream> orders = repo.GetOrders();
            return Json(orders,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(IceCream ice)
        {
            var repo = new IceCreamRepository();
            repo.Add(ice);
            return RedirectToAction("/index");
        }

        [HttpPost]
        public ActionResult Update(IceCream ice)
        {
            var repo = new IceCreamRepository();
            repo.Update(ice);
            return RedirectToAction("/getorders");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var repo = new IceCreamRepository();
            repo.Delete(id);
            return RedirectToAction("/getorders");
        }

    }
}