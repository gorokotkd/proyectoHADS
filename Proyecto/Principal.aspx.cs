using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Proyecto
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList alumnos = ((ArrayList)Application["AlumnoEmailList"]);
            ArrayList profesores = ((ArrayList)Application["ProfesorEmailList"]);

            /*   for (int i = 0; i < profesores.Count; i++)
                   profesoresList.Items.Add(profesores.ToArray()[i].ToString());
               for (int i = 0; i < alumnos.Count; i++)
                   alumnosList.Items.Add(alumnos.ToArray()[i].ToString());*/

            if (profesores.Count > 0)
            {
                profContLabel.Text = profesores.Count.ToString();
                contProfesores.Visible = true;
            }
            else
            {
                contProfesores.Visible = false;
            }

            if (alumnos.Count > 0)
            {
                aluContLabel.Text = alumnos.Count.ToString();
                contAlumnos.Visible = true;
            }
            else
            {
                contAlumnos.Visible = false;
            }

            DataSet profesoresSet = GetDsFromArray(profesores.ToArray());
            profesoresListView.DataSource = profesoresSet.Tables[0];
            profesoresListView.DataBind();

            DataSet alumnosSet = GetDsFromArray(alumnos.ToArray());
            alumnosListView.DataSource = alumnosSet.Tables[0];
            alumnosListView.DataBind();
        }

        private DataSet GetDsFromArray(Object[] list)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("EmailList", Type.GetType("System.String")));
            for (int i = 0; i < list.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["EmailList"] = list[i].ToString();
                dt.Rows.Add(dr);

            }

            ds.Tables.Add(dt);
            return ds;

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}