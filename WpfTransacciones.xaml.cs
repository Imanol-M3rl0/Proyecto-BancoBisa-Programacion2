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
    /// Lógica de interacción para WpfTransacciones.xaml
    /// </summary>
    public partial class WpfTransacciones : Window
    {
        public WpfTransacciones(Cuenta cuenta)
        {
            InitializeComponent();

            if (cuenta != null && cuenta.Movimientos != null)
            {
                lstTransacciones.ItemsSource = cuenta.Movimientos;
            }
            else
            {
                MessageBox.Show("No hay transacciones para esta cuenta", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }

}
