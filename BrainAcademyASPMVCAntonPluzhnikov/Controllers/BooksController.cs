using BooksEntityApproach;
using BrainAcademyASPMVCAntonPluzhnikov.App_Start;
using DataObjectsLayer;
using DataObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace BrainAcademyASPMVCAntonPluzhnikov.Controllers
{
    public class BooksController : Controller
    {
        readonly private IDataObjectsManager<Book> _booksManager;
        
        public BooksController() {
            _booksManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Book>>("ef");
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _booksManager.GetAll();
            return View(books);
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

                _booksManager.Add(book);
                _booksManager.SaveChanges();
                return RedirectToAction("Create", "Authors", new { bookId = book.Id });

            }
            catch
            {
                return View();
            }
        }

        public string GetAuthors(Book book) {
            var b = _booksManager[book.Id];
            List<Author> authors = new List<Author>();
            if (book.Library != null)
            {
                authors = book.Library.Where(arg => arg.AuthorId > 0).Select(arg=> arg.Author).ToList();                
            }
            return string.Join(", ", authors);
        }
    }
}