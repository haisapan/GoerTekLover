using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoerTekLover.Models;

namespace GoerTekLover.Controllers
{
    public class MenuController : Controller
    {
        private DbContextFactory db = new DbContextFactory();

        //
        // GET: /Menu/

        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        //
        // GET: /Menu/Details/5
        public ActionResult Details(int id = 0)
        {
            MenuModel menumodel = db.Menus.Find(id);
            if (menumodel == null)
            {
                return HttpNotFound();
            }
            return View(menumodel);
        }

        //
        // GET: /Menu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Menu/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuModel menumodel)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menumodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menumodel);
        }

        //
        // GET: /Menu/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MenuModel menumodel = db.Menus.Find(id);
            if (menumodel == null)
            {
                return HttpNotFound();
            }
            return View(menumodel);
        }

        //
        // POST: /Menu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuModel menumodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menumodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menumodel);
        }

        //
        // GET: /Menu/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MenuModel menumodel = db.Menus.Find(id);
            if (menumodel == null)
            {
                return HttpNotFound();
            }
            return View(menumodel);
        }

        //
        // POST: /Menu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuModel menumodel = db.Menus.Find(id);
            db.Menus.Remove(menumodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}