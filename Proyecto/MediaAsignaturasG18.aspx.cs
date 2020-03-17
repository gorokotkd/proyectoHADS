using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class MediaAsignaturasG18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = getIntervalosPorCadaTarea(emailTextBox.Text);

            Chart1.Titles.Add("Intervalos de hora por cada tarea");

            foreach(DataRow r in dt.Rows)
            {
                Chart1.Series["Estimadas"].Points.AddXY((string)r[0], (Double)r[1]);
                Chart1.Series["Totales"].Points.AddXY((string)r[0], (Double)r[2]);
            }
        }

        private DataTable getIntervalosPorCadaTarea(string email)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.Open();
                cmd = new SqlCommand("GetIntervaloHoras", conn);
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
    }

    
}