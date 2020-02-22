using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;
using System.Data.SqlClient;

namespace proyectoHADS
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //APERTURA DE CONEXION CON LA BD.
            String resul = DataAccess.DataAccess.OpenConnection();

            errorLabel.Text = resul;
            errorLabel.Visible = true;

            SqlDataReader dr = DataAccess.DataAccess.CheckUserLogin(loginEmail.Text, loginPass.Text);

            //Compruebo si la combinacion user+pass es corecta.
            if (!dr.HasRows)
            {
                errorLabel.Text = "Usuario o contraseña incorrectos.";
                errorLabel.Visible = true;
            }
            //El usuario aun no ha confirmado el correo electronico.
            else if (!dr.GetBoolean(dr.GetOrdinal("confirmado")))
            {
                errorLabel.Text = "Aun no se ha confirmado el correo electronico.";
                errorLabel.Visible = true;
            }

            //Cierro el DataReader
            dr.Close();

            //CIERRE DE CONEXION CON LA BD.
            DataAccess.DataAccess.CloseConnection();
            
        }
    }
}