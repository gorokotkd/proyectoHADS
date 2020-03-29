using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private String getMD5Hash(string input)
        {
            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();

            //Aplico el hash a la pass introducida por el usuario
            byte[] hashedPass = hash.ComputeHash(Encoding.Default.GetBytes(input));

            //Convierto la cadena de bytes a string.
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashedPass.Length; i++)
                stringBuilder.Append(hashedPass[i].ToString("x2"));
            return stringBuilder.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //APERTURA DE CONEXION CON LA BD.
            String resul = DataAccess.DataAccess.OpenConnection();


            String hashOfInput = getMD5Hash(passL.Text);

            SqlDataReader dr = DataAccess.DataAccess.getUserData(emailL.Text);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (!dr.Read())
            {//El email no esta registrado.
                alert.Visible = false;
                alert2.Visible = false;
                errorEmailRegitrado.Visible = true;
                return;
            }
           String userPass = dr.GetString(dr.GetOrdinal("pass"));
            if(0 != comparer.Compare(hashOfInput, userPass))
            {//La contraseña es incorrecta.

                alert.Visible = true;
                alert2.Visible = false;
                errorEmailRegitrado.Visible = false;
                //Cierro el DataReader
                dr.Close();

                //CIERRE DE CONEXION CON LA BD.
                DataAccess.DataAccess.CloseConnection();
                return;
            }
            //El usuario aun no ha confirmado el correo electronico.
            else if (!dr.GetBoolean(dr.GetOrdinal("confirmado")))
            {
                alert.Visible = false;
                alert2.Visible = true;
                errorEmailRegitrado.Visible = false;

                //Cierro el DataReader
                dr.Close();

                //CIERRE DE CONEXION CON LA BD.
                DataAccess.DataAccess.CloseConnection();

                return;
            }


            if(dr.GetString(dr.GetOrdinal("tipo")) == "Profesor")
            {
                
                if(emailL.Text == "vadillo@ehu.es")
                {
                    FormsAuthentication.SetAuthCookie("Vadillo", false);
                    Session["userType"] = "01";
                }
                else
                {
                    FormsAuthentication.SetAuthCookie("Profesor", false);
                    Session["userType"] = "0";
                }
            }
            else if (dr.GetString(dr.GetOrdinal("tipo")) == "Admin")
            {
                FormsAuthentication.SetAuthCookie("Admin", false);
                Session["userType"] = "11";
            }
            else
            {
                Session["userType"] = "1";
                FormsAuthentication.SetAuthCookie("Alumno", false);
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