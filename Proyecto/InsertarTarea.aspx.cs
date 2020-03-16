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
    public partial class InsertarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            /*  table.Columns.Add("Codigo",typeof(string));
              table.Columns.Add("Descripcion", typeof(string));
              table.Columns.Add("CodAsig", typeof(string));
              table.Columns.Add("HEstimadas", typeof(int));
              table.Columns.Add("Explotacion", typeof(Boolean));
              table.Columns.Add("TipoTarea", typeof(string));*/

            int horas;
            if(int.TryParse(horasEstimadas.Text,out horas))
            {
                SqlConnection connection = new SqlConnection(DataAccess.DataAccess.CONNECTION_STRING);

                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM TareasGenericas", connection);
                sda.InsertCommand = new SqlCommand("INSERT INTO TareasGenericas VALUES(@codigo, @descripcion,@codAsig, @hEstimadas, @explotacion, @tipoTarea)", connection);
                sda.InsertCommand.Parameters.Add("@codigo", SqlDbType.NVarChar, 50, "Codigo");
                sda.InsertCommand.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50, "Descripcion");
                sda.InsertCommand.Parameters.Add("@codAsig", SqlDbType.NVarChar, 50, "CodAsig");
                sda.InsertCommand.Parameters.Add("@hEstimadas", SqlDbType.Int,10, "HEstimadas");
                sda.InsertCommand.Parameters.Add("@explotacion", SqlDbType.Bit, 1, "explotacion");
                sda.InsertCommand.Parameters.Add("@tipoTarea", SqlDbType.NVarChar, 50, "TipoTarea");

                sda.Fill(table);
                table.Rows.Add(codigo.Text, descripcion.Text, asignaturas.SelectedValue, horas, false, tipoTarea.SelectedValue);
                sda.Update(table);
                //Mostrar Mensaje de todo guay.
                todoGuayAlert.Visible = true;
                horasNumero.Visible = false;
            }
            else
            {//Mostrar error de que las horas introducidas son incorrectas
                todoGuayAlert.Visible = false;
                horasNumero.Visible = true;
                
            }

        }
    }
}