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
        String players1;
        String players2;
        String numeroSets;
        string tipo;

        public Ajustes()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\DAM\INTERFACES\ENTREGAS\MarcadorFinal\MarcadorFinal\MarcadorFinal\ajustes.txt");
            tipo = lines[0];
            numeroSets = lines[1];
            players1 = lines[2];
            players2 = lines[3];
            
            InitializeComponent();

            player1.Text = players1;
            player2.Text = players2;

            if (tipo.Equals("padel"))
            {
                ItemPadel.IsSelected=true;
            }
            else
            {
                ItemTennis.IsSelected = true;
            }

            if (numeroSets.Equals("3"){
                
            }
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
                    tipo
                    + "\n"+
                    numeroSets
                    + "\n"+
                    player1.Text
                    +"\n"+
                    player2.Text
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
