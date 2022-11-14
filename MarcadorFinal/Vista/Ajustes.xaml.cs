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

namespace MarcadorFinal.Vista
{
    /// <summary>
    /// Lógica de interacción para Ajustes.xaml
    /// </summary>
    public partial class Ajustes : Window
    {

        int numeroSets;
        string tipo;

        public Ajustes()
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
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (numSets3.IsPressed)
            {
                numeroSets = 3;
            }
            else
            {
                numeroSets = 5;
            }

            if (ItemTennis.IsSelected)
            {
                tipo = "tenis";
            }
            else { 
                tipo = "padel";
            }

            //PARA SOBREESCRIBIR EL ARCHIVO
            using (StreamWriter archivo = new StreamWriter(@"C:\DAM\INTERFACES\ENTREGAS\MarcadorFinal\MarcadorFinal\MarcadorFinal\ajustes.txt", false))
            {
                
                archivo.WriteLine(
                    "Tipo de Juego:" + tipo
                    + "\n"
                    + "Sets:" + numeroSets
                    + "\n"
                    + "Jugador1 :" + player1.Text
                    +"\n"
                     + "Jugador 2: " + player2.Text
                    );

            }
        }



        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Menu m1 = new Menu();
            m1.Show();
            this.Close();
        }
    }
}
