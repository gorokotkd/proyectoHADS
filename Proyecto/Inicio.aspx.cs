using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace Proyecto
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alert.Visible = false;
            alert2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //APERTURA DE CONEXION CON LA BD.
            String resul = DataAccess.DataAccess.OpenConnection();

            SqlDataReader dr = DataAccess.DataAccess.CheckUserLogin(emailL.Text, passL.Text);


            //Compruebo si la combinacion user+pass es corecta.
            if (!dr.Read())
            {

                alert.Visible = true;
                //Cierro el DataReader
                dr.Close();

                //CIERRE DE CONEXION CON LA BD.
                DataAccess.DataAccess.CloseConnection();
                return;
            }
            //El usuario aun no ha confirmado el correo electronico.
            else if (!dr.GetBoolean(dr.GetOrdinal("confirmado")))
            {
                alert2.Visible = true;

                //Cierro el DataReader
                dr.Close();

                //CIERRE DE CONEXION CON LA BD.
                DataAccess.DataAccess.CloseConnection();

                return;
            }
            if(dr.GetString(dr.GetOrdinal("tipo")) == "Docente")
            {
                Session["userType"] = "0";
            }
            else
            {
                Session["userType"] = "1";
            }
            //Cierro el DataReader
            dr.Close();

            //CIERRE DE CONEXION CON LA BD.
            DataAccess.DataAccess.CloseConnection();

            Session["email"] = emailL.Text;
            Session["identificado"] = "SI";
            Response.Redirect("Principal.aspx");

        }
    }
}