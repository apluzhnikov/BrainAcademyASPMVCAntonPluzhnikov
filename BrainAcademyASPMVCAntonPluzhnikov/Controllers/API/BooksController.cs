using BrainAcademyASPMVCAntonPluzhnikov.App_Start;
using DataObjectsLayer;
using DataObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using BrainAcademyASPMVCAntonPluzhnikov.Utils;

namespace BrainAcademyASPMVCAntonPluzhnikov.Controllers.API
{
    public class BooksController : ApiController
    {
        readonly private IDataObjectsManager<Book> _booksManager;

        public BooksController() {
            _booksManager = UnityConfig.GetConfiguredContainer().Resolve<IDataObjectsManager<Book>>("ef");
        }

        [HttpGet]
        [Route("api/charts/hits/{id}")]
        public HttpResponseMessage Hits(int id) {
            var book = _booksManager.GetById(id);
            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Book is missed");
            }
            var hitsData = book.Hits.GetHitsStatistics();
            return Request.CreateResponse(HttpStatusCode.OK, hitsData);
        }
    }
}
