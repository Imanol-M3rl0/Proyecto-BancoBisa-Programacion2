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
    /// Lógica de interacción para WpfPrincipal.xaml
    /// </summary>
    public partial class WpfPrincipal : Window
    {
        public WpfPrincipal()
        {
            InitializeComponent();
        }

        private void btnDataBinding_Click(object sender, RoutedEventArgs e)
        {
            WpfDataBinding winDataBinding = new WpfDataBinding();
            winDataBinding.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow winLogin = new MainWindow();
            winLogin.Show();
            this.Close();
        }

    
    }
}
