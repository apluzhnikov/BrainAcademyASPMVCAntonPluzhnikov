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
    public class AuthorsController : Controller
    {
        readonly private IDataObjectsManager<Author> _authorsManager;
        readonly private IDataObjectsManager<Library> _libraryManager;
        readonly private IDataObjectsManager<Book> _booksManager;

        public AuthorsController() {
            _authorsManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Author>>("ef");
            _libraryManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Library>>("ef");
            _booksManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Book>>("ef");
        }

        // GET: Authors
        public ActionResult Index() {
            var authors = _authorsManager.GetAll();
            return View(authors);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        private int currentBookId = 0;
        // GET: Authors/Create
        public ActionResult Create(int bookId = 0) {
            currentBookId = bookId;
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public ActionResult Create(Author author) {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View();

                if (currentBookId > 0)
                {
                    var book = _booksManager.GetAll().First(arg => arg.Id == currentBookId);
                    if (book != null)
                        _libraryManager.Add(new Library { Author = author, Book = book });
                    else
                        _authorsManager.Add(author);
                } else
                {
                    _authorsManager.Add(author);                    
                }
                _authorsManager.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}