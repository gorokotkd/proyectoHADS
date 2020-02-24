using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using LibreriaClase;

namespace proyectoHADS
{
    public partial class cambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["validEmail"].ToString()=="SI")
            {
                confirmarPassButton.Visible = true;
                pass1Box.Visible = true;
                pass2Box.Visible = true;
                pass1Text.Visible = true;
                pass2Text.Visible = true;
                pass1Box.CausesValidation = true;
                pass2Box.CausesValidation = true;

                Label1.Visible = false;
                Label2.Visible = false;
                emailBox.Visible = false;
                Button1.Visible = false;
                emailBox.CausesValidation = false;
                emailRequieredValidator.Enabled = false;
            }
            else
            {
                confirmarPassButton.Visible = false;
                pass1Box.Visible = false;
                pass2Box.Visible = false;
                pass1Text.Visible = false;
                pass2Text.Visible = false;
                pass1Box.CausesValidation = false;
                pass2Box.CausesValidation = false;

                Label1.Visible = true;
                Label2.Visible = true;
                emailBox.Visible = true;
                Button1.Visible = true;
                emailBox.CausesValidation = true;
                emailRequieredValidator.Enabled = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String email = emailBox.Text;

            DataAccess.DataAccess.OpenConnection();

            if (DataAccess.DataAccess.checkEmail(email))
            {//El email es valido

                var random = new Random();
                int NumConf = int.Parse(Math.Round((random.NextDouble() * 9000000) + 1000000).ToString());

                string enlace = Convert.ToString("https://localhost/CambiarPassword.aspx");
                string msg = "EL ENLACE PARA RESTABLECER TU CONTRASEÑA YA ESTÁ LISTO :" + enlace+"\n"+
                    "Tu codigo de recuperacion es: "+NumConf;

                String subject = "Recuperacion de contraseña";
                EnviarCorreo emailSender = new LibreriaClase.EnviarCorreo();
                emailSender.enviarCorreo(email, msg, subject);
                Session["validEmail"] = "SI";
            }
            else
            {
                Session["validEmail"] = "NO";
            }

            Label3.Text = "Email enviado correctamente, si este es correcto recibira un mensaje en su bandeja de entrada.";
            Label3.Visible = true;

            DataAccess.DataAccess.CloseConnection();

        }
    }
}