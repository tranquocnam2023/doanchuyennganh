using Microsoft.AspNetCore.Mvc;
using OpDT.Models; 

namespace OpDT.Controllers
{
    public class OpDTController : Controller
    {
        OpDTContext db = new OpDTContext();
        public IActionResult Index()
        {
                

                ViewBag.nsx = db.Nhasanxuat;
                return View();
            
        }
        [HttpGet]
        public ActionResult them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them(Nhasanxuat n)
        {
            if (ModelState.IsValid)
            {
                if (db.Nhasanxuat.Find(n.Mansx) != null)
                {
                    ModelState.AddModelError("Mansx", "Mã nhà sản xuất bị trùng!");
                    //ModelState.AddModelError("", "Mã nhà sản xuất bị trùng!");
                    return View(n);
                }
                else
                {
                    db.Nhasanxuat.Add(n);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(n);
            }
        }
        [HttpGet]
        public ActionResult sua(string id)
        {
            Nhasanxuat nsx = db.Nhasanxuat.Find(id);
            ViewBag.nsx = nsx;
            return View(nsx);
        }
        [HttpPost]
        public ActionResult sua(Nhasanxuat n)
        {
            if (ModelState.IsValid)
            {
                Nhasanxuat nsx = db.Nhasanxuat.Find(n.Mansx);
                nsx.Tennsx = n.Tennsx;
                nsx.Diachi = n.Diachi;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View(n);
            }
        }
        [HttpGet]
        public ActionResult xoa(string id)
        {
            var a = db.Hanghoa.Where(k => k.Mansx == id).ToList().Count;
            //var a = (from h in db.Hanghoa
            //        where h.Mansx == id
            //        select h).ToList().Count;
            if (a <= 0)
                ViewBag.flagDelete = true;
            else
                ViewBag.flagDelete = false;
            Nhasanxuat n = db.Nhasanxuat.Find(id);
            ViewBag.nsx = n;
            return View(n);
        }
        [HttpPost, ActionName("xoa")]
        public ActionResult xoa_Post(string id)
        {
            Nhasanxuat n = db.Nhasanxuat.Find(id);
            if (n != null)
            {
                db.Nhasanxuat.Remove(n);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
