using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaClase;
using DataAccess;
using System.Text;
using System.Security.Cryptography;

namespace Proyecto
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (!comprobarDatos())
                return;
          
            LibreriaClase.EnviarCorreo correoSender = new EnviarCorreo();

            var random = new Random();
            int NumConf = int.Parse(Math.Round((random.NextDouble() * 9000000) + 1000000).ToString());

            string enlace = Convert.ToString("https://hads1920-g18.azurewebsites.net/Confirmar.aspx?mbr=" + emailR.Text + "&numconf=" + NumConf);
            string msg = "EL ENLACE PARA CONFIRMAR TU CORREO ELECTRONICO ESTÁ LISTO :" + enlace;

            String subject = "Confirmacion de correo electronico.";

            correoSender.enviarCorreo(emailR.Text, msg, subject);
            //   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Correo enviado')", true);

            guardarRegistroEnBd(NumConf);
    }

        /**
         * comprueba los datos introducidos. En caso de que haya algo incorrecto, muestra mensaje de error y devuelve false.
         */
        private Boolean comprobarDatos()
        {
            DataAccess.DataAccess.OpenConnection();

            emailNoVip.Visible = false;
            alertPass.Visible = false;
            alertUserType.Visible = false;
            alertEmailRepeat.Visible = false;
            Boolean vip = Boolean.Parse(Session["emailRValido"].ToString());
            if (!vip)
            {//el email no es vip
                emailNoVip.Visible = true;
                DataAccess.DataAccess.CloseConnection();
                return false;
            }
            else if (!passR.Text.Equals(passR2.Text))
            {//las contraseñas no coinciden
                alertPass.Visible = true;
                DataAccess.DataAccess.CloseConnection();
                return false;
            }
            else if (userType.SelectedValue != "Alumno" && userType.SelectedValue != "Profesor")
            {//el tipo de usuario seleccionado no es valido o no se ha seleccionado ninguno.
                alertUserType.Visible = true;
                DataAccess.DataAccess.CloseConnection();
                return false;
            }
            else if (DataAccess.DataAccess.checkEmail(emailR.Text))
            {//El email ya esta registrado
                alertEmailRepeat.Visible = true;
                DataAccess.DataAccess.CloseConnection();
                return false;
            }
            else
            {
                DataAccess.DataAccess.CloseConnection();
                return true;
            }
        }

        private void guardarRegistroEnBd(int numConrf)
        {
            DataAccess.DataAccess.OpenConnection();

            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();

            //Aplico el hash a la pass introducida por el usuario
            byte[] hashedPass = hash.ComputeHash(Encoding.Default.GetBytes(passR.Text));

            //Convierto la cadena de bytes a string.
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashedPass.Length; i++)
                stringBuilder.Append(hashedPass[i].ToString("x2"));


            DataAccess.DataAccess.InsertUser(emailR.Text, nombre.Text, apellido.Text,
                numConrf, 0, userType.SelectedValue, stringBuilder.ToString(), 0);

            DataAccess.DataAccess.CloseConnection();

            todoGuayAlert.Visible = true;
        }

        protected void emailR_TextChanged(object sender, EventArgs e)
        {
            matricula.Matriculas matr = new matricula.Matriculas();
            String resul = matr.comprobar(emailR.Text);
            if (resul.Equals("SI"))
            {//el email es VIP
                Session["emailRValido"] = true;
                alertEmail.Visible = false;
                emailValido.Visible = true;
            }
            else
            {//El email no es VIP.
                Session["emailRValido"] = false;
                alertEmail.Visible = true;
                emailValido.Visible = false;
            }
        }
    }
}