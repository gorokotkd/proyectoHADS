using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace Proyecto
{
    public partial class ImportarDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void asignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                errorGeneral.Visible = false;
                errorArchivo.Visible = false;
                todoGuayAlert.Visible = false;
                tareasYaImportadas.Visible = false;
                if (File.Exists(Server.MapPath("App_Data/" + asignaturas.SelectedValue + ".xml")))
                {
                    Xml1.DocumentSource = Server.MapPath("App_Data/" + asignaturas.SelectedValue + ".xml");
                    Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile.xsl");
                }
                else
                {
                    errorArchivo.Visible = true;
                    errorGeneral.Visible = false;
                    tareasYaImportadas.Visible = false;
                }

            }
            catch (Exception ex)
            {
                errorGeneral.Visible = true;
                errorArchivo.Visible = false;
                tareasYaImportadas.Visible = false;
            }
        }

        protected void importar_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("App_Data/" + asignaturas.SelectedValue + ".xml")))
            {//Existe el fichero seleccionado
                DataSet ds = new DataSet();
                DataSet xmlDs = new DataSet();

                SqlConnection connection = new SqlConnection(DataAccess.DataAccess.CONNECTION_STRING);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TareasGenericas", connection);
                adapter.InsertCommand = new SqlCommand("INSERT INTO TareasGenericas VALUES(@codigo, @descripcion,@codAsig, @hEstimadas, @explotacion, @tipoTarea)", connection);
                adapter.InsertCommand.Parameters.Add("@codigo", SqlDbType.NVarChar, 50, "Codigo");
                adapter.InsertCommand.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50, "Descripcion");
                adapter.InsertCommand.Parameters.Add("@codAsig", SqlDbType.NVarChar, 50, "CodAsig");
                adapter.InsertCommand.Parameters.Add("@hEstimadas", SqlDbType.Int, 10, "HEstimadas");
                adapter.InsertCommand.Parameters.Add("@explotacion", SqlDbType.Bit, 1, "Explotacion");
                adapter.InsertCommand.Parameters.Add("@tipoTarea", SqlDbType.NVarChar, 50, "TipoTarea");
                adapter.Fill(ds, "Tareas");

                xmlDs.ReadXml(Server.MapPath(("App_Data/" + asignaturas.SelectedValue + ".xml")));

                for (int i = 0; i < xmlDs.Tables["tarea"].Rows.Count; i++)
                {//Compruebo si existen los registros que quiero insertar
                    String str = "Codigo = '" + xmlDs.Tables["tarea"].Rows[i]["codigo"] + "'";
                    DataRow[] foundRows = ds.Tables["Tareas"].Select(str);
                    if (foundRows.Length > 0)
                    {//Ya existe el registro

                        tareasYaImportadas.Visible = true;
                        errorImportar.Visible = false;
                        todoGuayAlert.Visible = false;
                        errorGeneral.Visible = false;
                        errorArchivo.Visible = false;
                        return;
                    }
                }

                for (int i = 0; i < xmlDs.Tables["tarea"].Rows.Count; i++)
                {//Meto las rows del xmlDs en el DataSet que quiero actualizar.
                    DataRow row = xmlDs.Tables["tarea"].Rows[i];
                    ds.Tables["Tareas"].Rows.Add(
                            row["codigo"],
                            row["descripcion"],
                            asignaturas.SelectedValue,
                            row["hestimadas"],
                            row["explotacion"],
                            row["tipotarea"]
                        );
                }

                adapter.Update(ds, "Tareas");
                todoGuayAlert.Visible = true;
                errorArchivo.Visible = false;
                errorGeneral.Visible = false;
                errorImportar.Visible = false;
                tareasYaImportadas.Visible = false;

            }
            else
            {
                errorArchivo.Visible = true;
                todoGuayAlert.Visible = false;
                errorGeneral.Visible = false;
                errorImportar.Visible = false;
                tareasYaImportadas.Visible = false;
            }
        }
    }
}