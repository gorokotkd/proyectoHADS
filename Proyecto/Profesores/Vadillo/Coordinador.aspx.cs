using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Profesores.Vadillo
{
    public partial class Coordinador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void asignaturasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WCFCoordinador.Service1Client coordinador = new WCFCoordinador.Service1Client();
            horasLabel.Text = coordinador.obtenerDedicacionMedia(asignaturasList.SelectedValue).ToString();
            alert.Visible = true;
        }
    }
}