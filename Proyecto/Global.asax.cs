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
            Application["AlumnoEmailList"] = new ArrayList();   //Lista de alumnos que estan conectados
            Application["ProfesorEmailList"] = new ArrayList(); //Lista de profesores que estan conectados.
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["emailRValido"] = false; //utilizado para ver si el email es VIP en el registro.
            Session["validEmail"] = "NO";
            Session["numConf"] = 0;
            Session["identificado"] = "NO";
            Session["userType"] = "-1"; //1 para alumnos, 0 para profesores, 01 Vadillo, 10 Admin.
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