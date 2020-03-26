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
using Newtonsoft.Json;

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

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Tareas");
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
                {//El archivo no existe, creo el archivo.
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

            DataTable dt = ds.Tables[0];
                
            for (int k = 0; k < dt.Rows.Count; k++) {
                xr.WriteStartElement("tarea");
                xr.WriteAttributeString("codigo", dt.Rows[k][0].ToString());
                xr.WriteElementString("descripcion", dt.Rows[k][1].ToString());
                xr.WriteElementString("hestimadas", dt.Rows[k][3].ToString());
                xr.WriteElementString("explotacion", dt.Rows[k][4].ToString());
                xr.WriteElementString("tipotarea", dt.Rows[k][5].ToString());
                xr.WriteEndElement();
            }
            xr.WriteEndElement();
            xr.Flush();
            xr.Close();
        }

        protected void exportarJson_Click(object sender, EventArgs e)
        {
            if (asignaturas.SelectedValue != "-1")
            {
                string path = "App_Data/" + asignaturas.SelectedValue + ".json";

                DataSet ds = (DataSet)Session["tablaTareas"];
                try {
                    File.WriteAllText(Server.MapPath(path), GetDSJSon(ds.Tables[0]));
                    infoSeleccionarAsig.Visible = false;
                    errorCrearArchivoJson.Visible = false;
                    archicoCreadoJson.Visible = true;
                }
                catch(Exception)
                {
                    infoSeleccionarAsig.Visible = false;
                    errorCrearArchivoJson.Visible = true;
                    archicoCreadoJson.Visible = false;
                }

            }
            else
            {
                infoSeleccionarAsig.Visible = true;
                errorCrearArchivoJson.Visible = false;
                archicoCreadoJson.Visible = false;
            }
           
        }
        private String GetDSJSon(DataTable tabla_origen)
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add(new DataColumn("codigo", tabla_origen.Columns[0].DataType));
            tabla.Columns.Add(new DataColumn("descripcion", tabla_origen.Columns[1].DataType));
            tabla.Columns.Add(new DataColumn("hestimadas", tabla_origen.Columns[3].DataType));
            tabla.Columns.Add(new DataColumn("explotacion", tabla_origen.Columns[4].DataType));
            tabla.Columns.Add(new DataColumn("tipotarea", tabla_origen.Columns[5].DataType));

            for (int i = 0; i < tabla_origen.Rows.Count; i++)
            {
                DataRow newRow = tabla.NewRow();
                newRow["codigo"] = tabla_origen.Rows[i][0];
                newRow["descripcion"] = tabla_origen.Rows[i][1];
                newRow["hestimadas"] = tabla_origen.Rows[i][3];
                newRow["explotacion"] = tabla_origen.Rows[i][4];
                newRow["tipotarea"] = tabla_origen.Rows[i][5];
                tabla.Rows.Add(newRow);
            }
            string json = JsonConvert.SerializeObject(tabla, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
    }
}