using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        string cadenaConexion = "server=" + server + ";" + "port=" + puerto + ";" + "user_id=" + user + ";" +
            " password=" + password +";"+"database="+database+";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                con.ConnectionString = cadenaConexion;
                con.Open();
                MessageBox.Show("Se pudo conextar a la base");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se pudo conectar "+e.ToString());
            }
            return con;
        }
    }
    
}
