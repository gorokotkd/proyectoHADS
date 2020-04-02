using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;

namespace Proyecto
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((ArrayList)Application["AlumnoEmailList"]).Contains(Session["email"].ToString()))
            {
                ((ArrayList)Application["AlumnoEmailList"]).Remove(Session["email"].ToString());
            }
            else
            {
                ((ArrayList)Application["ProfesorEmailList"]).Remove(Session["email"].ToString());
            }
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("Principal.aspx");
        }
    }
}