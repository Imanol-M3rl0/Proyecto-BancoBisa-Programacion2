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

namespace WpfProyectoBancoP2C
{
    /// <summary>
    /// Lógica de interacción para WpfSeleccionRol.xaml
    /// </summary>
    public partial class WpfSeleccionRol : Window
    {
        public WpfSeleccionRol()
        {
            InitializeComponent();
        }

        private void BtnUsuario_Click(object sender, RoutedEventArgs e)
        {
            WpfPrincipal principal = new WpfPrincipal();
            principal.Show();
            this.Close();
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            WpfAdmin admin = new WpfAdmin();
            admin.Show();
            this.Close();
        }
    }
}
