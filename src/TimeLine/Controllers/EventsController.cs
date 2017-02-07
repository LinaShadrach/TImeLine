using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeLine.Models;
using Microsoft.EntityFrameworkCore;



namespace TimeLine.Controllers
{
    public class EventsController : Controller
    {
        // GET: /<controller>/
        private TimeLineContext db = new TimeLineContext();
        public IActionResult Index()
        {

            return View(db.Events.ToList());
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Event e)
        {
            db.Events.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Update
        public IActionResult Edit(int id)
        {
            var thisEvent = db.Events.FirstOrDefault(events => events.Id == id);
                return View(thisEvent);
        }

        [HttpPost]
        public IActionResult Edit(Event e)
        {
            db.Entry(e).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var thisEvent = db.Events.FirstOrDefault(events => events.Id == id);
            return View(thisEvent);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisEvent = db.Events.FirstOrDefault(events => events.Id == id);
            db.Events.Remove(thisEvent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
