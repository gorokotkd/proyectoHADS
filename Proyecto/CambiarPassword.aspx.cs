using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using LibreriaClase;

namespace Proyecto
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["validEmail"].ToString() == "SI" && Request["numConf"] == Session["numConf"].ToString())
            {//el correo es válido
                passInfoAlert.Visible = true;
                passGroup.Visible = true;
                passSubmit.Visible = true;
          //      correctPassAlert.Visible = false;

                passR.CausesValidation = true;
                passR2.CausesValidation = true;
                emailL.CausesValidation = false;

                emailInfoAlert.Visible = false;
                emailGroup.Visible = false;
                emailSubmit.Visible = false;
           //     correctEmailAlert.Visible = false;
             //   alertPass.Visible = false;

            }
            else
            {
                passInfoAlert.Visible = false;
                passGroup.Visible = false;
                passSubmit.Visible = false;
             //   correctPassAlert.Visible = false;

                passR.CausesValidation = false;
                passR2.CausesValidation = false;
                emailL.CausesValidation = true;

                emailInfoAlert.Visible = true;
                emailGroup.Visible = true;
                emailSubmit.Visible = true;
          //      correctEmailAlert.Visible = false;
            //    alertPass.Visible = false;
            }

        }

        protected void emailSubmit_Click(object sender, EventArgs e)
        {
            String email = emailL.Text;

            DataAccess.DataAccess.OpenConnection();

            if (DataAccess.DataAccess.checkEmail(email))
            {//El email es valido

                var random = new Random();
                int NumConf = int.Parse(Math.Round((random.NextDouble() * 9000000) + 1000000).ToString());
                Session["numConf"] = NumConf;
                string enlace = Convert.ToString("https://hads1920-g18.azurewebsites.net/CambiarPassword.aspx?numConf=" + NumConf);
                string msg = "EL ENLACE PARA RESTABLECER TU CONTRASEÑA YA ESTÁ LISTO :" + enlace + "\n" +
                    "Tu codigo de recuperacion es: " + NumConf;

                String subject = "Recuperacion de contraseña";
                EnviarCorreo emailSender = new EnviarCorreo();
                emailSender.enviarCorreo(email, msg, subject);
                Session["validEmail"] = "SI";
                Session["email"] = email;
            }
            else
            {
                Session["validEmail"] = "NO";
            }

            emailInfoAlert.Visible = true;

            DataAccess.DataAccess.CloseConnection();


        }

        protected void passSubmit_Click(object sender, EventArgs e)
        {
            if (passR.Text == passR2.Text)
            {
                DataAccess.DataAccess.OpenConnection();

                DataAccess.DataAccess.updateUserPass(Session["email"].ToString(), passR.Text);

                DataAccess.DataAccess.CloseConnection();
            }
            else
            {
                alertPass.Visible = true;
            }

        }
    }
}