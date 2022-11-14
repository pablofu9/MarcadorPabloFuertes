
using System;
using System.Collections.Generic;
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
                MessageBox.Show("Conexion a la base correcta");
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

        public void buscarUsuario(string user, string pass)
        {
            try
            {
                establecerConexion();
                string sentencia = "SELECT * FROM usuarios WHERE user =@User AND password =@Password";
                var cmd = new MySqlCommand(sentencia, con);
                cmd.Parameters.AddWithValue("@User", user);
                cmd.Parameters.AddWithValue("@Password", pass);
                cmd.ExecuteReader();
                MessageBox.Show("Login correcto, bienvenido " + user);

            }catch(Exception ex)
            {
                MessageBox.Show("Login failed");
            }
           
        }
    }
    
}
