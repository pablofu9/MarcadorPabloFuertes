using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {

            try
            {


                Conexion.Conexion con = new Conexion.Conexion();
                string sentencia = "SELECT * FROM usuarios WHERE user =@User AND password =@Password";
                con.establecerConexion();
                MySqlCommand c = new MySqlCommand(sentencia);

                c.Parameters.AddWithValue("@User", txtUser.Text);
                c.Parameters.AddWithValue("@Password", txtPass.ToString());

                MySqlDataReader r = c.ExecuteReader();
                if (r.Read())
                {
                    MessageBox.Show("Bienvenido");
                }
                else
                {
                    MessageBox.Show("Usuario no reconocido");
                }

            }catch(Exception ex)
            {
                Menu m1 = new Menu();
                m1.Show();
                this.Close();
                MessageBox.Show("Fallo al conectar "+ex.Message);
            }
        }
    }
}
