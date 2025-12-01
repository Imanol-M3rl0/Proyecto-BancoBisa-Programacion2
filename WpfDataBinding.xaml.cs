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
using System.Collections.ObjectModel;


namespace WpfProyectoBancoP2C
{
    /// <summary>
    /// Lógica de interacción para WpfDataBinding.xaml
    /// </summary>
    public partial class WpfDataBinding : Window
    {
        public ObservableCollection<Cuenta> ListaCuentas { get; set; }
        public Cuenta cuentaSel { get; set; }
        public WpfDataBinding()
        {
            InitializeComponent();
            ListaCuentas = new ObservableCollection<Cuenta>
            {
                new Cuenta("Cuenta N°1", 5300),
                new Cuenta("Cuenta N°2", 10000),
                new Cuenta("Cuenta N°3", 8900),
                new Cuenta("Cuenta N°4", 4900),
                new Cuenta("Cuenta N°5", 2500)
            };

            DataContext = this;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNumCta.Text;
            if (!double.TryParse(txtSaldo.Text, out double precio))
            {
                MessageBox.Show("Saldo inválido");
                return;
            }

            if (precio > 0 && !string.IsNullOrWhiteSpace(nombre))
            {
                ListaCuentas.Add(new Cuenta(nombre, precio));
                txtSaldo.Clear();
                txtNumCta.Clear();
            }
            else
            {
                MessageBox.Show("Error en el ingreso de datos!!");
            }
        }

        private void lstBCuentas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cuentaSel = lstBCuentas.SelectedItem as Cuenta;

            if (cuentaSel != null)
            {
                txtNumCta.Text = cuentaSel.Nombre;
                txtSaldo.Text = cuentaSel.Saldo.ToString();
            }
            else
            {
                txtNumCta.Clear();
                txtSaldo.Clear();
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (cuentaSel != null)
            {
                ListaCuentas.Remove(cuentaSel);
                cuentaSel = null;
                txtSaldo.Clear();
                txtNumCta.Clear();
            }
        }

        private void btnDeposito_Click(object sender, RoutedEventArgs e)
        {
            if (cuentaSel == null)
            {
                MessageBox.Show("Seleccione una cuenta primero");
                return;
            }

            if (!double.TryParse(txtMontoDeposito.Text, out double monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido (mayor que 0)");
                txtMontoDeposito.Clear();
                txtMontoDeposito.Focus();
                return;
            }

            cuentaSel.RegistrarDeposito(monto);
            MessageBox.Show($"Depósito realizado con éxito. Saldo actual: {cuentaSel.Saldo}");
            txtMontoDeposito.Clear();
        }

        private void btnRetiro_Click(object sender, RoutedEventArgs e)
        {
            if (cuentaSel == null)
            {
                MessageBox.Show("Seleccione una cuenta primero");
                return;
            }

            if (!double.TryParse(txtMontoDeposito.Text, out double monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido (mayor que 0)");
                txtMontoDeposito.Clear();
                txtMontoDeposito.Focus();
                return;
            }

            if (monto > cuentaSel.Saldo)
            {
                MessageBox.Show($"Saldo insuficiente. Su saldo actual es: {cuentaSel.Saldo}");
                txtMontoDeposito.Clear();
                txtMontoDeposito.Focus();
                return;
            }

            cuentaSel.RegistrarRetiro(monto);

            MessageBox.Show($"Retiro realizado con exito bro, tu saldo actual es: {cuentaSel.Saldo}");
            txtMontoDeposito.Clear();
        }

        private void btnSaldoActual_Click(object sender, RoutedEventArgs e)
        {
            if (cuentaSel == null)
            {
                MessageBox.Show("Seleccione una cuenta");
                return;
            }

            MessageBox.Show($"El saldo actual de la cuenta \"{cuentaSel.Nombre}\" es: {cuentaSel.Saldo}", "Saldo Actual", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnTransacciones_Click(object sender, RoutedEventArgs e)
        {
            if (cuentaSel == null)
            {
                MessageBox.Show("Seleccione una cuenta primero");
                return;
            }

            WpfTransacciones winTransacciones = new WpfTransacciones(cuentaSel);
            winTransacciones.ShowDialog();
        }
    }
}
