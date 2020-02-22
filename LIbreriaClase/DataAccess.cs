using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataAccess
    {
        private static SqlConnection conexion = new SqlConnection();
        private static SqlCommand comando;

        private static readonly String CONNECTION_STRING = "Server=tcp:hads-g18.database.windows.net,1433;Initial Catalog=HADSG18;" +
            "Persist Security Info=False;User ID=porquiño;Password=>GupX66R;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public static String OpenConnection()
        {
            try
            {
                conexion.ConnectionString = CONNECTION_STRING;
                conexion.Open();
            }
            catch (Exception ex)
            {
                return "Error de conexion: " + ex.Message;
            }

            return "Conexion realizada correctamente.";
        }

        public static void CloseConnection()
        {
            conexion.Close();
        }

        public static String InsertUser(String email, String nombre, String apellidos, int numCorf,
                                        Boolean confirmado, String tipo, String pass, int codPass)
        {
            String statement = "INSERT INTO Usuarios (email, nombre, apellidos, numconfir," +
                "confirmado, tipo, pass, codpass) VALUES(" +
                "'" + email + "'," +
                "'" + nombre + "'," +
                "'" + apellidos + "'," +
                "" + numCorf + "," +
                "" + confirmado + "," +
                "'" + tipo + "'," +
                "'" + pass + "'," +
                "" + codPass + ")";

            int numregs;

            comando = new SqlCommand(statement, conexion);

            try
            {
                numregs = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return "Error al insertar el registro en la bd: " + ex.Message;
            }

            return numregs + " registro(s) insertado(s) en la BD.";
        }

        public static String DeleteUserByEmail(String email)
        {
            String statement = "DELETE FROM Usuarios WHERE email='" + email + "'";

            int numregs;

            comando = new SqlCommand(statement, conexion);

            try
            {
                numregs = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return "Error al eliminar el registrp de la bd: " + ex.Message;
            }

            return numregs + " registro(s) eliminado(s) correctamente.";
        }

        public static SqlDataReader ExecuteQuery(String statement)
        {
            comando = new SqlCommand(statement, conexion);
            return comando.ExecuteReader();
        }

        public static String ExecuteNonQuery(String statement)
        {
            comando = new SqlCommand(statement, conexion);
            int resul;
            try
            {
                resul = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return resul + " registro(s) modificado(s) de la BD.";
        }

        public static SqlDataReader CheckUserLogin(String email, String pass)
        {
            String statement = "SELECT * FROM Usuarios WHERE email='" + email + "' AND pass='" + pass + "'";
            comando = new SqlCommand(statement, conexion);

            return comando.ExecuteReader();
        }
    }
}