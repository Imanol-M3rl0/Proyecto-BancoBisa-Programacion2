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
using System.IO;

namespace WpfProyectoBancoP2C
{
    /// <summary>
    /// Lógica de interacción para WpfAdmin.xaml
    /// </summary>
    public partial class WpfAdmin : Window
    {
        private readonly string rutaArchLogin = "C:\\signupPrueba\\proyectoBancoBisaProgra2Definitivo.txt";

        public WpfAdmin()
        {
            InitializeComponent();
        }

        private void BtnVerUsuarios_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(rutaArchLogin))
            {
                MessageBox.Show("No hay archivo de usuarios");
                return;
            }

            var contenido = File.ReadAllText(rutaArchLogin);
            MessageBox.Show(contenido, "Usuarios (archivo)");
        }

        

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            WpfSeleccionRol rol = new WpfSeleccionRol();
            rol.Show();
            this.Close();
        }
    }
}
