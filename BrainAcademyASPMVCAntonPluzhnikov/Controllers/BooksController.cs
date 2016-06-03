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
using BrainAcademyASPMVCAntonPluzhnikov.Utils;

namespace BrainAcademyASPMVCAntonPluzhnikov.Controllers
{
    public class BooksController : Controller
    {
        readonly private IDataObjectsManager<Author> _authorsManager;
        readonly private IDataObjectsManager<Library> _libraryManager;
        readonly private IDataObjectsManager<Book> _booksManager;

        public BooksController()
        {
            _authorsManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Author>>("ef");
            _libraryManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Library>>("ef");
            _booksManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Book>>("ef");
        }

        // GET: Books
        [OutputCache(Duration = 120, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var books = _booksManager.GetAll();
            return View(books);
        }

        public ActionResult AddAuthor(int id)
        {
            return RedirectToAction("Index", "Authors", new { bookId = id });
        }

        public ActionResult IndexRemoveCache()
        {
            var path = Url.Action("Index", "Books");
            Response.RemoveOutputCacheItem(path);
            return RedirectToAction("Index");
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var book = _booksManager.GetById(id);
            var hit = book.Hits.Find(arg => arg.Date == DateTime.UtcNow.Date);
            var random = new Random();
            if (hit == null)
            {
                for (int i = 0; i < 8; i++)
                {
                    hit = new Hit()
                    {
                        Date = DateTime.UtcNow.Date.AddDays(i * (-1))
                    };
                    hit.Count = random.Next(0, 100);
                    book.Hits.Add(hit);
                }
            }

            hit.Count++;

            _booksManager.SaveChanges();

            return View(book);
        }

        public string GetHitsStatistics(int id)
        {
            List<Hit> hits = _booksManager.GetById(id).Hits;
            var statistic = string.Empty;

            var dt = new Google.DataTable.Net.Wrapper.DataTable();
            dt.AddColumn(new Google.DataTable.Net.Wrapper.Column(Google.DataTable.Net.Wrapper.ColumnType.String, "Date", "Date"));
            dt.AddColumn(new Google.DataTable.Net.Wrapper.Column(Google.DataTable.Net.Wrapper.ColumnType.Number, "Count", "Count"));
            hits.Sort((a, b) => a.Date.CompareTo(b.Date));
            foreach (var hit in hits)
            {
                var row = dt.NewRow();
                row
                    .AddCellRange(new Google.DataTable.Net.Wrapper.Cell[]
                    {
                        new Google.DataTable.Net.Wrapper.Cell(hit.Date),
                        new Google.DataTable.Net.Wrapper.Cell(hit.Count)
                    }
                    );
                dt.AddRow(row);
            }

            statistic = dt.GetJson();

            return statistic;
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View();

                book.Hits = new List<Hit>();
                var random = new Random();
                for (int i = 0; i < 8; i++)
                {
                    var hit = new Hit()
                    {
                        Date = DateTime.UtcNow.Date.AddDays(i * (-1))
                    };
                    hit.Count = random.Next(0, 100);
                    book.Hits.Add(hit);
                }


                _booksManager.Add(book);
                _booksManager.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            var book = _booksManager.GetById(id);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // TODO: Add update logic here
                var b = _booksManager.GetById(id);
                b.ISBN = book.ISBN;
                b.Title = book.Title;
                _booksManager.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            var book = _booksManager.GetById(id);
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                var b = _booksManager.GetById(id);
                _booksManager.Remove(b);
                _booksManager.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public string GetAuthors(Book book)
        {
            var b = _booksManager.GetById(book.Id);
            List<Author> authors = new List<Author>();
            if (book.Library != null)
            {
                authors = book.Library.Where(arg => arg.AuthorId > 0).Select(arg => arg.Author).ToList();
            }
            return string.Join(", ", authors);
        }
        public ActionResult UnlinkAuthor(int id, int authorId = 0)
        {
            if (authorId > 0)
            {
                var libraryItem = _libraryManager.GetAll().FirstOrDefault(arg => arg.BookId == id && arg.AuthorId == authorId);
                if (libraryItem != null && libraryItem.Id > 0)
                {
                    _libraryManager.Remove(libraryItem);
                    _libraryManager.SaveChanges();
                    return RedirectToAction("Edit", new { id = id });

                }
                else
                    return View();
            }
            else
                return View();
        }

    }
}