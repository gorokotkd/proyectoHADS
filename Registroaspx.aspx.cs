using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaClase;

namespace proyectoHADS
{
    public partial class Registroaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Correo enviado')", true);
            EnviarCorreo correoSender = new EnviarCorreo();
            correoSender.enviarCorreo(TextBox1.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Correo enviado')", true);
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}