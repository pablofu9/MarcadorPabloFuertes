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

            //AQUI SI ESTUVIERA IMPLEMENTADO QUE SE PUDIERAN JUGAR 5 SETS, HABRIA QUE PONERLE EN EL CONSTRUCTOR LA VARIABLE SETS
            miMarcador = new Marcador(players1, players2, 3);
            txtPlayers1.Content = players1;
            txtPlayers2.Content = players2;

            //SETEAMOS LOS NOMBRES Y LOS BOTONES CON LOS NOMBRES QUE LEE DEL ARCHIVO
            BtnPoinsPlayer1.Content = players1;
            BtnPoinsPlayer2.Content = players2;

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

            //AQUI MIRAMOS SI EL GANADOR ES EL PLAYER 1 O EL 2, ASI LE PASAMOS 1 AL GANADOR Y 0 AL PERDEDOR
            String p1= txtPlayers1.Content.ToString();
            String p2=txtPlayers2.Content.ToString(); 

            //EL FALLO DEL PROGRAMA ES QUE COMO SOLO HAY UNA COLUMNA DEPORTE PARA TODOS LOS PARTIDOS, EN LA BASE DE DATOS ESTARA PUESTO EL DEPORTE
            //ULTIMO SElECCIONADO EN EL ARCHIVO SETTINGS, NO SE PUEDE COMPROBAR SI EL RESTO DE PARTIDOS HAN SIDO PADEL O TENNIS
            if (p1.Equals(e.Ganador)){
                Clases.CRUD.insertar(p1, tipo, 1);
                Clases.CRUD.insertar(p2, tipo, 0);
            }
            else
            {
                Clases.CRUD.insertar(p1, tipo, 0);
                Clases.CRUD.insertar(p2, tipo, 1);
            }
            

            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu m1 = new Menu();
            m1.Show();
            this.Close();
        }
    }
    }

