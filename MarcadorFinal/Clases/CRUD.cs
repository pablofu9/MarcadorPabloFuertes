using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MarcadorFinal.Clases
{
    public class CRUD
    {
        

        public static List<Jugadores> muestraJugadores()
        {
            List<Jugadores> listaJugadores = new List<Jugadores>();

            Conexion.Conexion con = new Conexion.Conexion();
            string sentencia = "SELECT * FROM resultados";

            MySqlCommand c = new MySqlCommand(sentencia, con.establecerConexion());


            MySqlDataReader r = c.ExecuteReader();

            if (r.HasRows)
            {
                while (r.Read())
                {

                    Jugadores jugador = new Jugadores();

                    jugador.nombre = r["nombre"].ToString();
                    jugador.deporte = r["deporte"].ToString();
                    jugador.jugados = int.Parse(r["jugados"].ToString());
                    jugador.ganados = int.Parse(r["ganados"].ToString());
                    listaJugadores.Add(jugador);

                }
            }
            return listaJugadores;
        }

        public static void insertar(String nombre, String deporte, int ganar)
        {
            Conexion.Conexion con = new Conexion.Conexion();
            Boolean encontrado=false;
            String queryBuscar = "SELECT * FROM resultados WHERE nombre= '" + nombre+"'";

            MySqlCommand mycomand = new MySqlCommand(queryBuscar, con.establecerConexion());
            MySqlDataReader myreader = mycomand.ExecuteReader();

            
            //LO QUE HACE SI ENCUENTRA EL USUARIO
            if (myreader.Read())
            {
                encontrado = true;
                
            }
            con.desconectar();
            if (encontrado)
            {
                String queryUserExiste = "";
                if (ganar == 0)
                {
                    queryUserExiste = "update resultados SET jugados=jugados+" + 1 + " where nombre='" + nombre + "'";

                }
                else
                {
                    queryUserExiste = "update resultados SET jugados=jugados+" + 1 + ", ganados=ganados+" + 1 + " where nombre='" + nombre + "'";
                }
                MySqlCommand c1 = new MySqlCommand(queryUserExiste, con.establecerConexion());
                c1.ExecuteNonQuery();
                con.desconectar();
            }
            else
            {
                
                //SI NO ENCUENRTA AL USUARIO, ES DECIR, NO HA JUGADO TODAVIA, AÑADE UNO NUEVO
                string queryUserNuevo = "INSERT INTO resultados (nombre, deporte, jugados, ganados) VALUES(@Nombre,@Deporte,@Jugados,@Ganados)";
                MySqlCommand cmd = new MySqlCommand(queryUserNuevo, con.establecerConexion());
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Deporte", deporte);
                cmd.Parameters.AddWithValue("@Jugados", +1);

                if (ganar == 1)
                {
                    cmd.Parameters.AddWithValue("@Ganados", +1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Ganados", 0);
                }

                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User insertado");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    con.desconectar();
                }
            }
            
            
        }

        
    }

    
}
