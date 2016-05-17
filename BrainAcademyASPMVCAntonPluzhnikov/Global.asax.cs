﻿using System;
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

namespace BrainAcademyASPMVCAntonPluzhnikov
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            /*PersonsController.Persons.Add("Anton");
            PersonsController.Persons.Add("Vasia");*/


            BooksController.Books.Add("Anton", "My first book", "");
            BooksController.Books.Add("Vasia", "His first book", "");
        }
    }
}