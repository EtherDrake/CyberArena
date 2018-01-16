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
using AutoMapper;
using CyberArena.CustomExtensions;

namespace CyberArena.Controllers
{
    public class PlayersController : Controller
    {
        private ArenaContext db = new ArenaContext();

        
        // GET: Players
        public ActionResult Index(string searchString)
        {

            var players = from m in db.Players
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.Nickname.Contains(searchString));
            }

            List<PlayerView> playersViews = players.ToList().Map();

            return View(playersViews);
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            
               
            if (player == null)
            {
                return HttpNotFound();
            }

            PlayerView playerView = player.Map();
            return View(playerView);          
            
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Team> teams = db.Teams.ToList();
            for (int i=0;i<teams.Count;i++)
            {
                items.Add(new SelectListItem { Text = teams[i].Name, Value = teams[i].TeamID.ToString() });
            }
            ViewBag.Teams = items;
            return View();
        }

        // POST: Players/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,LastName,FirstName,Nickname,Discipline,MMR,TeamID")] PlayerView playerModel)
        {
            Player player=new Player();
            if (ModelState.IsValid)
            {
                player = playerModel.Map();
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            PlayerView playerModel=player.Map();

            List<SelectListItem> items = new List<SelectListItem>();
            List<Team> teams = db.Teams.ToList();
            for (int i = 0; i < teams.Count; i++)
            {
                items.Add(new SelectListItem { Text = teams[i].Name, Value = teams[i].TeamID.ToString() });
            }
            ViewBag.Teams = items;

            return View(playerModel);
        }

        // POST: Players/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,LastName,FirstName,Nickname,Discipline,MMR,TeamID")] PlayerView playerModel)
        {
            Player player = new Player();
            if (ModelState.IsValid)
            {
                player = playerModel.Map();
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            PlayerView playerView = player.Map();

            return View(playerView);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
