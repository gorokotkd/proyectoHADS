using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace Proyecto
{
    public partial class TareasAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                initializeGridView();
        }


        private void initializeGridView()
        {
            valor.InnerText = asignaturas.SelectedValue;

             string sql = "SELECT Codigo, Descripcion, HEstimadas, TipoTarea FROM TareasGenericas WHERE CodAsig='"+asignaturas.SelectedValue+"' AND Explotacion=1";
        // string sql = "SELECT Codigo, Descripcion, HEstimadas, TipoTarea FROM TareasGenericas WHERE CodAsig='EDA1' AND Explotacion='1'";
            SqlConnection connection = new SqlConnection(DataAccess.DataAccess.CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String cod = GridView1.SelectedRow.Cells[1].Text;
            String hor = GridView1.SelectedRow.Cells[3].Text;

            Response.Redirect("InstanciarTarea.aspx?cod=" + cod + "&hEstimadas=" + hor + "");
        }
    }
}