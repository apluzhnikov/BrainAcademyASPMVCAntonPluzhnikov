using BrainAcademyASPMVCAntonPluzhnikov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrainAcademyASPMVCAntonPluzhnikov.Utils;
using DataObjectsLayer.Models;

namespace BrainAcademyASPMVCAntonPluzhnikov.Controllers
{
    public class BooksController : Controller
    {
        public static IList<Library> Library = new List<Library>();
        // GET: Books
        public ActionResult Index() {
            IEnumerable<Library> library = Library;
            return View(library);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Books/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book) {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View();

                //Books.Add(book.Author, book.Title, book.ISBN);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id) {
            Book book = Books.First(x => x.Id == id);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book) {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                // TODO: Add update logic here
                /*Book b = Books.First(x => x.Id == id);
                b.Author = book.Author;
                b.Title = book.Title;
                b.ISBN = book.ISBN;*/
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id) {
            Book book = Books.First(x => x.Id == id);
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try
            {
                // TODO: Add delete logic here
                Books = Books.Where(x => x.Id != id).ToList();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
