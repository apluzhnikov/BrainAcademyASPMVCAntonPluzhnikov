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

        private Book _book;
        private Author _author;

        public AuthorsController()
        {
            _authorsManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Author>>("ef");
            _libraryManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Library>>("ef");
            _booksManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Book>>("ef");
        }

        // GET: Authors
        public ActionResult Index(int bookId = 0)
        {
            var authors = _authorsManager.GetAll();
            ViewData["bookId"] = bookId;
            return View(authors);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            _author = _authorsManager.GetById(id);
            return View(_author);
        }

        public ActionResult AddAuthorToBook(int id, int bookId = 0)
        {
            if (bookId != 0)
            {
                _book = _booksManager.GetById(bookId);
                ViewData["bookId"] = bookId;
            }
            if (id != 0)
                _author = _authorsManager.GetById(id);
            if (_book != null && _author != null)
            {
                var library = _libraryManager.GetAll();
                if (!library.Any(arg => arg.AuthorId == _author.Id && arg.BookId == _book.Id))
                {
                    _libraryManager.Add(new Library() { BookId = _book.Id, AuthorId = _author.Id });
                    _libraryManager.SaveChanges();
                }
            }
            //return RedirectToAction("Index", new { bookId = bookId });
            return RedirectToAction("Edit", "Books", new { id = bookId });
        }


        // GET: Authors/Create
        public ActionResult Create(int bookId = 0)
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View();

                _authorsManager.Add(author);
                _authorsManager.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var author = _authorsManager.GetById(id);
            return View(author);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                var a = _authorsManager.GetById(id);
                a.FirstName = author.FirstName;
                a.LastName = author.LastName;
                _authorsManager.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var author = _authorsManager.GetById(id);
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                var a = _authorsManager.GetById(id);
                _authorsManager.Remove(a);
                _authorsManager.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}