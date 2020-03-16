using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataAccess;

namespace Proyecto
{
    public partial class IntervaloMedias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private DataTable getIntervalosPorCadaTarea(string email)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DataAccess.DataAccess.CONNECTION_STRING);

            try
            {
                conn.Open();
                cmd = new SqlCommand("getIntervaloHorasG18", conn);
                cmd.Parameters.Add(new SqlParameter("@EMAIL", email));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return dt;
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = getIntervalosPorCadaTarea(emailList.SelectedValue);

            Chart1.Titles.Add("Intervalos de hora por cada tarea");

            foreach (DataRow r in dt.Rows)
            {
                Chart1.Series["Estimadas"].Points.AddXY((string)r[0], (int)r[1]);
                Chart1.Series["Totales"].Points.AddXY((string)r[0], (int)r[2]);
            }
        }
    }
}