using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccess;
using System.IO;
using System.Text;
using System.Xml;
using System.Data.Common;

namespace Proyecto
{
    public partial class ExportarTareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void asignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoSeleccionarAsig.Visible = false;
            errorCrearArchivo.Visible = false;
            archicoCreado.Visible = false;
            string sql = "SELECT * FROM TareasGenericas WHERE CodAsig='"+asignaturas.SelectedValue+"'";
            SqlConnection connection = new SqlConnection(DataAccess.DataAccess.CONNECTION_STRING);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
    /*        DataTableMapping tableMapping =
                    adapter.TableMappings.Add("TareasGenericas", "tarea");
            tableMapping.ColumnMappings.Add("Descripcion", "descripcion");
            tableMapping.ColumnMappings.Add("HEstimadas", "hestimadas");
            tableMapping.ColumnMappings.Add("Explotacion", "explotacion");
            tableMapping.ColumnMappings.Add("TipoTarea", "tipotarea");*/


            //    DataTable table = new DataTable();
            //   adapter.Fill(table);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tarea");
            Session["tablaTareas"] = ds;
            Session["adapterTareas"] = adapter;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void exportarXml_Click(object sender, EventArgs e)
        {
           if(asignaturas.SelectedValue != "-1")
            {
                string path = "App_Data/" + asignaturas.SelectedValue + ".xml";
                if (!File.Exists(Server.MapPath(path)))
                {//El archivo no existe, creo el archivo y escribo en él
                    try
                    {
                        File.Create(Server.MapPath(path)).Close();
                                             
                    }
                    catch (IOException ex)
                    {//Error al crear el archivo
                        errorCrearArchivo.Visible = true;
                        archicoCreado.Visible = false;
                    }
                }
                try
                {
                    createXmlFile(path);
                    errorCrearArchivo.Visible = false;
                    archicoCreado.Visible = true;
                    infoSeleccionarAsig.Visible = false;
                }
                catch(Exception ex)
                {
                    errorCrearArchivo.Visible = true;
                    archicoCreado.Visible = false;
                    infoSeleccionarAsig.Visible = false;
                }

            }
            else
            {//Ventana selecciona una asignatura valida.
                infoSeleccionarAsig.Visible = true;
                errorCrearArchivo.Visible = false;
                archicoCreado.Visible = false;
            }

        }

        private void createXmlFile(String path)
        {
            
            DataSet ds = (DataSet)Session["tablaTareas"];
            SqlDataAdapter adapter = (SqlDataAdapter)Session["adapterTareas"];

            XmlWriter xr = XmlWriter.Create(Server.MapPath(path));
            xr.WriteStartElement("tareas");
            xr.WriteAttributeString("xmlns", "has", null, "http://ji.ehu.es/has");

            for(int i = 0; i < ds.Tables.Count; i++)
            {//Cada tabla es un elemento tarea
                DataTable dt = ds.Tables[i];
                
                 for (int k = 0; k < dt.Rows.Count; k++) {
                    xr.WriteStartElement("tarea");
                    xr.WriteAttributeString("codigo", dt.Rows[k][0].ToString());
                    xr.WriteElementString("descripcion", dt.Rows[k][1].ToString());
                    xr.WriteElementString("hestimadas", dt.Rows[k][3].ToString());
                    xr.WriteElementString("explotacion", dt.Rows[k][4].ToString());
                    xr.WriteElementString("tipotarea", dt.Rows[k][5].ToString());
                    xr.WriteEndElement();
                }
                
            }
            xr.WriteEndElement();
            xr.Flush();
            xr.Close();
        }
    }
}