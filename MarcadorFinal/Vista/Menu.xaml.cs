using System;
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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
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

        private void btnAjustes_Click(object sender, RoutedEventArgs e)
        {
            Ajustes a1 = new Ajustes();
            a1.Show();
            this.Close();
        }

        private void btnMarcador_Click(object sender, RoutedEventArgs e)
        {
            VentanaMarcador m1 = new VentanaMarcador();
            m1.Show();
            this.Close();
        }

        private void btnResultados_Click(object sender, RoutedEventArgs e)
        {
            Resultados r = new Resultados();
            r.Show();
            this.Close();
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
