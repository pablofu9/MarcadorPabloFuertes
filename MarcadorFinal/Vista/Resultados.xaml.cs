using MarcadorFinal.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MarcadorFinal.Vista
{
    /// <summary>
    /// Lógica de interacción para Resultados.xaml
    /// </summary>
    public partial class Resultados : Window
    {
        public Resultados()
        {
            
            InitializeComponent();
        }
        private void Window_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
        private void btnMinimizar_Click(Object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu m1 = new Menu();
            m1.Show();
            this.Close();
        }

        

       

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
        private void tabla_Loaded(object sender, RoutedEventArgs e)
        {
            tabla.DataContext = muestraJugadores();
        }

        private void btnVolverMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu m1 = new Menu();
            m1.Show();
            this.Close();
        }
    }
}
