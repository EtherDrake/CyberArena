using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CyberArena.DAL;
using CyberArena.Models;
using CyberArena.Repository;

namespace CyberArena.Controllers
{
    public class TeamsController : Controller
    {
        //private ArenaContext db = new ArenaContext();
        //private TeamRepository TeamRepo = new TeamRepository(new ArenaContext());
        UnitOfWork unit = new UnitOfWork();

        // GET: Teams
        public ActionResult Index()
        {
            //return View(db.Teams.ToList());
            return View(unit.TeamRepository.getAll());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = unit.TeamRepository.FindByID(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamID,Name,Rating")] Team team)
        {
            if (ModelState.IsValid)
            {
                //db.Teams.Add(team);
                //db.SaveChanges();
                unit.TeamRepository.Add(team);
                unit.Save();
                return RedirectToAction("Index");
            }

            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = unit.TeamRepository.FindByID(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamID,Name,Rating")] Team team)
        {
            if (ModelState.IsValid)
            {
                unit.TeamRepository.Edit(team);
                unit.Save();
                //db.Entry(team).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = unit.TeamRepository.FindByID(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = unit.TeamRepository.FindByID(id);
            unit.TeamRepository.Delete(team);
            unit.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
