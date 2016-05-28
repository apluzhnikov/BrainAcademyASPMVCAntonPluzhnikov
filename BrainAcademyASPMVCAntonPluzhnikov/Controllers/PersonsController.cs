using BrainAcademyASPMVCAntonPluzhnikov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainAcademyASPMVCAntonPluzhnikov.Utils;

namespace BrainAcademyASPMVCAntonPluzhnikov.Controllers
{
    public class PersonsController : Controller
    {
        public static IList<Person> Persons = new List<Person>();
        // GET: Persons
        public ActionResult Index() {
            IEnumerable<Person> persons = Persons;
            return View(persons);
        }

        // GET: Persons/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Persons/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Persons/Create
        [HttpPost]
        public ActionResult Create(Person person) {
            try
            {
                // TODO: Add insert logic here

                Persons.Add(person.Name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(int id) {
            Person person = Persons.First(x => x.Id == id);
            return View(person);
        }

        // POST: Persons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person person) {
            try
            {
                // TODO: Add update logic here
                Person p = Persons.First(x => x.Id == id);
                p.Name = person.Name;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Persons/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person person) {
            try
            {
                // TODO: Add delete logic here
                Persons = Persons.Where(x => x.Id != id).ToList();
                //Persons.Remove(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
