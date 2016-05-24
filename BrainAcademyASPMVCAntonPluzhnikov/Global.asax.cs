using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using BrainAcademyASPMVCAntonPluzhnikov.Controllers;
using BrainAcademyASPMVCAntonPluzhnikov.Utils;
using DataObjectsLayer;
using BooksEntityApproach;
using DataObjectsLayer.Models;
using BrainAcademyASPMVCAntonPluzhnikov.App_Start;

namespace BrainAcademyASPMVCAntonPluzhnikov
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e) {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            /*PersonsController.Persons.Add("Anton");
            PersonsController.Persons.Add("Vasia");*/
            
            /*IDataObjectsManager<Library> dataManager = new LibraryDataManager();

            foreach (var library in dataManager.GetAll())
                BooksTestController.Books.Add(library);*/


            /*IDataObjectsManager<Book> dataManager = new BooksDataManager();
            BooksController.Books = dataManager.GetAll();*/
            /*BooksController.Books.Add("Anton", "My first book", "");
            BooksController.Books.Add("Vasia", "His first book", "");*/
        }
    }
}
