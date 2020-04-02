using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Collections;

namespace Proyecto
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["AlumnoEmailList"] = new ArrayList();
            Application["ProfesorEmailList"] = new ArrayList();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["validEmail"] = "NO";
            Session["numConf"] = 0;
            Session["identificado"] = "NO";
            Session["userType"] = "-1"; //1 para alumnos, 0 para profesores, 01 Vadillo, 10 Admin
        }


        void Application_End(object sender, EventArgs e)
        {
            ((ArrayList)Application["AlumnoEmailList"]).Clear();
            ((ArrayList)Application["ProfesorEmailList"]).Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
        }



    }
}