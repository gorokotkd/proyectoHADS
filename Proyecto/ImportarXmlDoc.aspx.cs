using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using DataAccess;
using System.IO;

namespace Proyecto
{
    public partial class ImportarXmlDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void cargarTabla()
        {
            try
            {
                errorGeneral.Visible = false;
                errorArchivo.Visible = false;
                todoGuayAlert.Visible = false;
                if (File.Exists(Server.MapPath("App_Data/" + asignaturas.SelectedValue + ".xml")))
                {
                    Xml1.DocumentSource = Server.MapPath("App_Data/" + asignaturas.SelectedValue + ".xml");
                    Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile.xsl");
                }
                else
                {
                    errorArchivo.Visible = true;
                    errorGeneral.Visible = false;
                }
              
            }
            catch(Exception ex)
            {
                errorGeneral.Visible = true;
                errorArchivo.Visible = false;
            }

            
        }

        protected void importar_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xml = new XmlDocument();

                SqlConnection connection = new SqlConnection(DataAccess.DataAccess.CONNECTION_STRING);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TareasGenericas", connection);
                adapter.InsertCommand = new SqlCommand("INSERT INTO TareasGenericas VALUES(@codigo, @descripcion,@codAsig, @hEstimadas, @explotacion, @tipoTarea)", connection);
                adapter.InsertCommand.Parameters.Add("@codigo", SqlDbType.NVarChar, 50, "Codigo");
                adapter.InsertCommand.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50, "Descripcion");
                adapter.InsertCommand.Parameters.Add("@codAsig", SqlDbType.NVarChar, 50, "CodAsig");
                adapter.InsertCommand.Parameters.Add("@hEstimadas", SqlDbType.Int, 10, "HEstimadas");
                adapter.InsertCommand.Parameters.Add("@explotacion", SqlDbType.Bit, 1, "explotacion");
                adapter.InsertCommand.Parameters.Add("@tipoTarea", SqlDbType.NVarChar, 50, "TipoTarea");


                adapter.Fill(table);

                xml.Load(Server.MapPath("App_Data/" + asignaturas.SelectedValue + ".xml"));
                /*TAREAS GENERICAS 
                 * Codigo       : String
                 * Descripcion  : String
                 * CodAsig      : String
                 * HEstimadas   : int
                 * Explotacion  : bit
                 * TipoTarea    : String
                 */

                XmlNodeList listaTareasXml = xml.GetElementsByTagName("tarea");
                for (int i = 0; i < listaTareasXml.Count; i++)
                {
                    table.Rows.Add(
                            listaTareasXml[i].Attributes[0].InnerText,
                            listaTareasXml[i].ChildNodes[0].InnerText,
                            asignaturas.SelectedValue,
                            listaTareasXml[i].ChildNodes[1].InnerText,
                            listaTareasXml[i].ChildNodes[2].InnerText,
                            listaTareasXml[i].ChildNodes[3].InnerText
                        );
                }

                adapter.Update(table);
                errorImportar.Visible = false;
                todoGuayAlert.Visible = true;
                errorGeneral.Visible = false;
                errorArchivo.Visible = false;
            }
            catch(Exception)
            {
                errorImportar.Visible = true;
                todoGuayAlert.Visible = false;
                errorGeneral.Visible = false;
                errorArchivo.Visible = false;
            }
        }

        protected void asignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTabla();
        }
    }
}