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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
namespace WpfProyectoBancoP2C
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string rutaArchLogin = "C:\\signupPrueba\\proyectoBancoBisaProgra2Definitivo.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtEmail.Text = "";
            pwdContra.Password = "";
            lblMensaje.Content = "";
            MessageBox.Show("Limpio Joven");
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtEmail.Text == "" || pwdContra.Password == "")
            {
                lblMensaje.Content = "Debe llenar todos los campos obligatorios >:(";
                lblMensaje.Foreground = Brushes.Red;
                return;
            }

            try
            {
                bool acceso = false;
                string rolUsuario = "User";

                string[] lineas = File.Exists(rutaArchLogin) ? File.ReadAllLines(rutaArchLogin) : new string[0];

                foreach (var linea in lineas)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 7)
                    {
                        string emailGuardado = datos[3].Trim();
                        string pwdGuardado = datos[6].Trim(); // contraseña en texto
                        string rolGuardado = datos.Length >= 8 ? datos[7].Trim() : "User";

                        if (emailGuardado.Equals(TxtEmail.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
                            pwdGuardado == pwdContra.Password)
                        {
                            acceso = true;
                            rolUsuario = rolGuardado;
                            break;
                        }
                    }
                }

                if (acceso)
                {
                    lblMensaje.Foreground = Brushes.Aqua;
                    lblMensaje.Content = "Bienvenido/a !!!";
                    WpfSeleccionRol rol = new WpfSeleccionRol();
                    rol.Show();
                    this.Close();
                }
                else
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "Correo o contraseña incorrectos D:";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de leer los datos: " + ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            WpfSignUp winSignUp = new WpfSignUp();
            winSignUp.Show();
            this.Close();
        }
    }
}
