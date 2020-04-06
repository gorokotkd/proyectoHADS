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
                else if(Session["userType"].ToString() == "01")    //El 01 es vadillo
                {
                    tareasProfesor.Visible = true;
                    mediasAlumnos.Visible = true;
                    importarXml.Visible = true;
                    exportarTareas.Visible = true;
                    importarDataSet.Visible = true;
                }
                else if (Session["userType"].ToString() == "11") //El 11 es el admin
                {
                    gestionarUsuarios.Visible = true;
                }
                else
                {
                    tareasProfesor.Visible = true;
                    mediasAlumnos.Visible = true;
                    
                }
                logOut.Visible = true;
            }
            else
            {
                logIn.Visible = true;
                registro.Visible = true;
                cambiarPass.Visible = true;

                tareasAlumno.Visible = false;

                gestionarUsuarios.Visible = false;

                tareasProfesor.Visible = false;
                mediasAlumnos.Visible = false;
                importarXml.Visible = false;
                exportarTareas.Visible = false;
                importarDataSet.Visible = false;

                logOut.Visible = false;


            }
        }
    }
}