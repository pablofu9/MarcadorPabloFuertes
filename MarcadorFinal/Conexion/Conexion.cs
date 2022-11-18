
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;


namespace MarcadorFinal.Conexion
{
    public class Conexion
    {
        private MySqlConnection con = new MySqlConnection();

        static string server = "localhost";
        static string database = "marcador";
        static string user = "root";
        static string password = "pabloygala96";
        static string puerto = "3306";

        string cadenaConexion = "server=" + server + ";" + "port=" + puerto + ";" + "user id=" + user + ";" +
            " password=" + password +";"+"database="+database+";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                con.ConnectionString = cadenaConexion;
                con.Open();
                
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se pudo conectar "+e.ToString());
            }
            return con;
        }

        public void desconectar()
        {
            con.Close();
        }

        
    }
    
}
