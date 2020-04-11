using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace WcfServiciosWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public static readonly String CONNECTION_STRING = "Server=tcp:hads.database.windows.net,1433;" +
           "Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;" +
           "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public double obtenerDedicacionMedia(String codAsig)
        {
            String sql = "SELECT HReales " +
                            "FROM EstudiantesTareas " +
                            "INNER JOIN TareasGenericas ON TareasGenericas.Codigo=EstudiantesTareas.CodTarea " +
                            "WHERE TareasGenericas.CodAsig='" + codAsig + "'";
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);    //Aqui uso el connection string definido arriba, xq al
                                                                                //usar el del DataAccess me peta por todos lados.
            
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            double media = 0.0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                media += Double.Parse(table.Rows[i][0].ToString());
            }

            return media / table.Rows.Count;
        }

    }
}
