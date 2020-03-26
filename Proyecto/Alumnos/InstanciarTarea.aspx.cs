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
    public partial class InstanciarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            emailT.Text = Session["email"].ToString();
            tareaT.Text = Request.QueryString["cod"];
            hEstimadas.Text = Request.QueryString["hEstimadas"];
            initializeGridView();
        }

        private void initializeGridView()
        {
            string sql = "SELECT Email, CodTarea, HEstimadas AS Horas_Estimadas, HReales AS Horas_Reales FROM EstudiantesTareas WHERE Email='" + Session["email"] + "'";
            SqlConnection connection = new SqlConnection(DataAccess.DataAccess.CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        private Boolean tareaCreada()
        {
            Boolean result = false;

            DataAccess.DataAccess.OpenConnection();

            string sql = "SELECT * FROM EstudiantesTareas WHERE Email='" + Session["email"] + "' AND CodTarea='" + tareaT.Text + "'";
            SqlDataReader dr = DataAccess.DataAccess.ExecuteQuery(sql);
            if (dr.Read())
            {
                result = true;
            }
            else
            {
                result = false;
            }

            DataAccess.DataAccess.CloseConnection();

            return result;
        }

        protected void crearTareaButton_Click(object sender, EventArgs e)
        {
            string horasString = hReales.Text;
            int horas;
            if (int.TryParse(horasString, out horas))
            {
                if (!tareaCreada())
                {
                    DataAccess.DataAccess.OpenConnection();
                    String sql = "INSERT INTO EstudiantesTareas VALUES('" + Session["email"] + "', '" + tareaT.Text + "'," + hEstimadas.Text + " ," + horas + " )";
                    String resul = DataAccess.DataAccess.ExecuteNonQuery(sql);

                    DataAccess.DataAccess.CloseConnection();
                    int numRegs = int.Parse(resul);
                    if (numRegs == 1)
                    {//Todo guay
                        todoGuayAlert.Visible = true;
                        errorInsertar.Visible = false;
                        horasNumero.Visible = false;
                        tareaInstanciada.Visible = false;
                        initializeGridView();
                    }
                    else
                    {//algo ha ido mal
                        errorInsertar.Visible = true;
                        horasNumero.Visible = false;
                        tareaInstanciada.Visible = false;
                        todoGuayAlert.Visible = false;
                    }
                }
                else
                {//Error tarea ya instanciada
                    tareaInstanciada.Visible = true;
                    errorInsertar.Visible = false;
                    horasNumero.Visible = false; 
                    todoGuayAlert.Visible = false;
                }
            }
            else
            {//Mostrar error de que las horas introducidas no son correctas.
                horasNumero.Visible = true;
                errorInsertar.Visible = false;
                tareaInstanciada.Visible = false;
                todoGuayAlert.Visible = false;
            }
        }
    }
}