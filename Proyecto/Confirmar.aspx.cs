using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

namespace Proyecto
{
    public partial class Confirmar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataAccess.DataAccess.OpenConnection();

            DataAccess.DataAccess.checkStatus(Request["mbr"], Request["numConf"]);

            DataAccess.DataAccess.CloseConnection();
        }
    }
}