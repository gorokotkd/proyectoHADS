using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace proyectoHADS
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //APERTURA DE CONEXION CON LA BD.
            String resul = DataAccess.DataAccess.OpenConnection();

            errorLabel.Text = resul;
            errorLabel.Visible = true;

            DataAccess.DataAccess.CheckUserLogin(loginEmail.Text, loginPass.Text);


            //CIERRE DE CONEXION CON LA BD.
            DataAccess.DataAccess.CloseConnection();
            
        }
    }
}