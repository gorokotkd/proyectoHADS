using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["identificado"].ToString() == "SI")
            {//el usuario ha iniciado sesion correctamente
                logIn.Visible = false;
                registro.Visible = false;
                cambiarPass.Visible = false;

                if(Session["userType"].ToString() == "1") //1 para alumnos, 0 para profesores
                {
                    tareasAlumno.Visible = true;
                }
                else
                {
                    tareasProfesor.Visible = true;
                    mediasAlumnos.Visible = true;
                }
            }
            else
            {
                logIn.Visible = true;
                registro.Visible = true;
                cambiarPass.Visible = true;

                tareasAlumno.Visible = false;

                tareasProfesor.Visible = false;
                mediasAlumnos.Visible = false;


            }
        }
    }
}