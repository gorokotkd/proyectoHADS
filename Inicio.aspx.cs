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

        protected void loginPass_TextChanged(object sender, EventArgs e)
        {
            loginPass.PassWordChar = '\u25CF';
        }
    }
}