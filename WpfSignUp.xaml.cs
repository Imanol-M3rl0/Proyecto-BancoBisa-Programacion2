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
using System.Text.RegularExpressions;


namespace WpfProyectoBancoP2C
{
    /// <summary>
    /// Lógica de interacción para WpfSignUp.xaml
    /// </summary>
    public partial class WpfSignUp : Window
    {
        private readonly string rutaArchLogin = "C:\\signupPrueba\\proyectoBancoBisaProgra2Definitivo.txt";

        public WpfSignUp()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtCelular.Text = "";
            TxtEmail.Text = "";
            txtañoNac.Text = "";
            pwdContra.Password = "";
            txtResultado.Text = "";
            lblMensaje.Content = "";
            MessageBox.Show("Limpio Joven");
        }

        private void GenerarCorreo(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TxtNombre.Text.Length > 0 && txtApPaterno.Text.Length > 0)
            {
                string nom = TxtNombre.Text.ToLower();
                string ap = txtApPaterno.Text.ToLower();
                string apm = txtApMaterno.Text.Length > 0 ? txtApMaterno.Text.ToLower() : "x";
                string sugerido = $"{nom[0]}{ap}{apm[0]}@gmail.com";
                TxtEmail.Text = sugerido;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNombre.Text == "" || TxtEmail.Text == "" || pwdContra.Password == "" || txtApPaterno.Text == "" || txtCelular.Text == "" || txtañoNac.Text == "")
            {
                lblMensaje.Content = "Debe llenar todos los campos obligatorios >:(";
                lblMensaje.Foreground = Brushes.Red;
                return;
            }

            string apMaterno = txtApMaterno.Text == "" ? "Sin Apellido Materno" : txtApMaterno.Text;
            string letterPattern = "^[A-Za-z]+$";
            string numericPattern = "^[0-9]{8}$";
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string yearPattern = @"^(19|20)\d{2}$";

            if (!Regex.IsMatch(TxtNombre.Text, letterPattern))
            {
                MessageBox.Show("Nombre NO valido");
                return; 
            }
            if (!Regex.IsMatch(txtApPaterno.Text, letterPattern)) 
            { 
                MessageBox.Show("Apellido Paterno NO valido");
                return; 
            }
            if (txtApMaterno.Text != "" && !Regex.IsMatch(txtApMaterno.Text, letterPattern))
            { 
                MessageBox.Show("Apellido Materno NO valido"); 
                return; 
            }
            if (!Regex.IsMatch(txtCelular.Text, numericPattern))
            {
                MessageBox.Show("Nro de celular NO valido (8 dígitos)");
                return; 
            }
            if (!Regex.IsMatch(TxtEmail.Text, emailPattern))
            { 
                MessageBox.Show("Email NO válido");
                return; 
            }
            if (!Regex.IsMatch(txtañoNac.Text, yearPattern)) 
            { 
                MessageBox.Show("Año de nacimiento NO valido");
                return;
            }
            if (pwdContra.Password.Length < 8) 
            { 
                MessageBox.Show("Contraseña demasiado corta (mínimo 8 caracteres)");
                return; 
            }

            string role = "User";
            string DatosConComas = $"{TxtNombre.Text},{txtApPaterno.Text},{apMaterno},{TxtEmail.Text},{txtCelular.Text},{txtañoNac.Text},{pwdContra.Password},{role}\n";

            try
            {
                File.AppendAllText(rutaArchLogin, DatosConComas, Encoding.UTF8);
                lblMensaje.Foreground = Brushes.Aqua;
                lblMensaje.Content = "Bienvenido/a " + TxtNombre.Text + "!!!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }

            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }
    }

}

