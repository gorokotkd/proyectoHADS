using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaClase;
using DataAccess;

namespace proyectoHADS
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LibreriaClase.EnviarCorreo correoSender = new EnviarCorreo();

            var random = new Random();
            Double NumConf = Math.Round((random.NextDouble() * 9000000) + 1000000);

            string enlace = Convert.ToString("https://localhost/Confirmar.aspx?mbr=" + TextBox1.Text + "&numconf=" + NumConf);
            string msg = "EL ENLACE PARA RESTABLECER TU CONTRASEÑA YA ESTÁ LISTO :" + enlace;

            String subject = "Confirmacion de correo electronico.";

            correoSender.enviarCorreo(TextBox1.Text, msg, subject);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Correo enviado')", true);

            guardarRegistroEnBd(NumConf);
        }

        private void guardarRegistroEnBd(Double numConrf)
        {
            DataAccess.DataAccess.OpenConnection();

            DataAccess.DataAccess.InsertUser(TextBox1.Text, TextBox2.Text, TextBox3.Text,
                numConrf,0, RadioButtonList1.SelectedValue,TextBox4.Text,0);

            DataAccess.DataAccess.CloseConnection();
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}