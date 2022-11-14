using System;
using System.Collections.Generic;
using System.IO;
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
using MarcadorFinal.Clases;

namespace MarcadorFinal.Vista
{
    /// <summary>
    /// Lógica de interacción para VentanaMarcador.xaml
    /// </summary>
    public partial class VentanaMarcador : Window
    {
       
        String tipo;
        String players1;
        String players2;
        int sets;
        Marcador miMarcador;


        private bool estadoEdicion;
        public VentanaMarcador()
        {
            
            InitializeComponent();

            //GUARDA LAS LINEAS DEL ARCHIVO EN UN ARAY
            string[] lines = System.IO.File.ReadAllLines(@"D:\DAM\INTERFACES\MarcadorDefinitivoGIT\MarcadorFinal\ajustes.txt");
            tipo = lines[0];
            sets = Int16.Parse(lines[1]);
            players1 = lines[2];
            players2 = lines[3];
            estadoEdicion = false;

            miMarcador = new Marcador(players1, players2, sets);
            txtPlayers1.Content = players1;
            txtPlayers2.Content = players2;
            miMarcador.PartidoFinalizado += OnPartidoFinalizado;
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
        private void ActualizaMarcador()
        {
            TextPointsPlayer1.Text = miMarcador.PuntosLocal;
            TextPointsPlayer2.Text = miMarcador.PuntosVisitante;
            TextSet1Player1.Text = miMarcador.MarcadorLocal[0].ToString();
            TextSet2Player1.Text = miMarcador.MarcadorLocal[1].ToString();
            TextSet3Player1.Text = miMarcador.MarcadorLocal[2].ToString();
            TextSet1Player2.Text = miMarcador.MarcadorVisitante[0].ToString();
            TextSet2Player2.Text = miMarcador.MarcadorVisitante[1].ToString();
            TextSet3Player2.Text = miMarcador.MarcadorVisitante[2].ToString();
        }
        private void btnPoinsPlayer1_Click(object sender, RoutedEventArgs e)
        {
            miMarcador.PuntoLocal();
            ActualizaMarcador();
        }

        private void btnPoinsPlayer2_Click(object sender, RoutedEventArgs e)
        {
            miMarcador.PuntoVisitante();
            ActualizaMarcador();
        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {
            estadoEdicion = !estadoEdicion;
            if (estadoEdicion)
            {
                BtnPoinsPlayer1.IsEnabled = false;
                BtnPoinsPlayer2.IsEnabled = false;
                BtnEdit.Content = "Edición on";
                BtnEdit.Background = new SolidColorBrush(Colors.DarkGreen);

            }
            else
            {
                BtnPoinsPlayer1.IsEnabled = true;
                BtnPoinsPlayer2.IsEnabled = true;
                BtnEdit.Content = "Edición off";
                BtnEdit.Background = new SolidColorBrush(Colors.DarkRed);
                
               
            }
            TextSet1Player1.IsEnabled = estadoEdicion;
            TextSet2Player1.IsEnabled = estadoEdicion;
            TextSet3Player1.IsEnabled = estadoEdicion;
            TextSet1Player2.IsEnabled = estadoEdicion;
            TextSet2Player2.IsEnabled = estadoEdicion;
            TextSet3Player2.IsEnabled = estadoEdicion;
            TextPointsPlayer1.IsEnabled = estadoEdicion;
            TextPointsPlayer2.IsEnabled = estadoEdicion;

        }
        private void OnPartidoFinalizado(object fuente, PartidoEventArgs e)
        {
            BtnEdit.IsEnabled = false;
            BtnPoinsPlayer1.IsEnabled = false;
            BtnPoinsPlayer2.IsEnabled = false;
            MessageBox.Show("El ganador del partido es: " + e.Ganador);
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu m1 = new Menu();
            m1.Show();
            this.Close();
        }
    }
    }

