using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Proyecto
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["validEmail"] = "NO";
            Session["numConf"] = 0;
            Session["identificado"] = "NO";
            Session["userType"] = "-1"; //1 para alumnos, 0 para profesores
        }

        void Application_End(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
        }



    }
}