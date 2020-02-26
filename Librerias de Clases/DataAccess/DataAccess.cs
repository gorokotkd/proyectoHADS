using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataAccess
    {
        private static SqlConnection conexion = new SqlConnection();
        private static SqlCommand comando;

      /*  private static readonly String CONNECTION_STRING = "Server=tcp:hads-g18.database.windows.net,1433;Initial Catalog=HADSG18;" +
            "Persist Security Info=False;User ID=porquiño;Password=>GupX66R;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";*/
        private static readonly String CONNECTION_STRING = "Server=tcp:hads.database.windows.net,1433;" +
            "Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public static String OpenConnection()
        {
            try
            {
                conexion.ConnectionString = CONNECTION_STRING;
                conexion.Open();
            }catch(Exception ex)
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
                                        int confirmado, String tipo, String pass, int codPass)
        {
            String statement = "insert into Usuarios (email, nombre, apellidos, numconfir," +
                "confirmado, tipo, pass, codpass) values(" +
                "'" + email      +"'," +
                "'" + nombre     +"'," +
                "'" + apellidos  + "'," +
                ""  + numCorf    + "," +
                ""  + confirmado + "," +
                "'" + tipo       + "'," +
                "'" + pass       + "'," +
                ""  + codPass    + ")";

            int numregs;

            comando = new SqlCommand(statement, conexion);

            try
            {
                numregs = comando.ExecuteNonQuery();
            }catch(Exception ex)
            {
                comando.Dispose();
                return "Error al insertar el registro en la bd: " + ex.Message;
            }
            comando.Dispose();
            return numregs + " registro(s) insertado(s) en la BD.";
        }

        public static String updateUserPass(String email, String pass)
        {
            String statement = "UPDATE Usuarios SET pass='" + pass + "' WHERE email='" + email + "'";
            return ExecuteNonQuery(statement);
        }
        public static Boolean checkStatus(String email, String numConf)
        {
            String sql = "SELECT * FROM Usuarios WHERE email='"+email+ "' AND numconfir=" + numConf;
            SqlDataReader resultado = ExecuteQuery(sql);
            if (!resultado.HasRows){
                resultado.Close();
                return false;
            }
            else
            {
                resultado.Close();
                
                confirmUser(email);
                return true;
            }
        }

        private static String confirmUser(String email)
        {
            String sql = "UPDATE Usuarios SET confirmado='1' WHERE email = '"+email+"'";
            return ExecuteNonQuery(sql);

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
                comando.Dispose();
                return "Error al eliminar el registrp de la bd: " + ex.Message;
            }
            comando.Dispose();
            return numregs + " registro(s) eliminado(s) correctamente.";
        }

        public static Boolean checkEmail(string email)
        {
            String statement = "SELECT * FROM Usuarios WHERE email='" + email + "'";
            SqlDataReader resul = ExecuteQuery(statement);
            if (!resul.Read())
            {
                resul.Close();
                return false;
            }
            else
            {
                resul.Close();
                return true;
            }
        }

        public static SqlDataReader ExecuteQuery(String statement)
        {
            comando = new SqlCommand(statement, conexion);
            SqlDataReader dr = comando.ExecuteReader();
            comando.Dispose();
            return dr;
        }

        public static String ExecuteNonQuery(String statement)
        {
           // comando = new SqlCommand(statement, conexion);
            SqlCommand comando2 = new SqlCommand(statement, conexion);
            int resul;
            try
            {
                resul = comando2.ExecuteNonQuery();
            }catch(Exception ex)
            {
                return ex.Message;
            }
            

            comando.Dispose();
            return resul + " registro(s) modificado(s) de la BD.";
        }

        public static SqlDataReader CheckUserLogin(String email, String pass)
        {
            String statement = "SELECT * FROM Usuarios WHERE email='"+email+"' AND pass='"+pass+"'";
           // String statement = "select * from Usuarios";
            return ExecuteQuery(statement);
        }
    }
}
