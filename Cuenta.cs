using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;


namespace WpfProyectoBancoP2C
{
    public class Cuenta : INotifyPropertyChanged
    {
        // Evento para refrescar el ListBox
        public event PropertyChangedEventHandler PropertyChanged;

        private double saldo;

        public string Nombre { get; set; }

        public double Saldo
        {
            get { return saldo; }
            set{
                saldo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Saldo)));
            }
        }

        // Lista de transacciones
        public ObservableCollection<Transaccion> Movimientos { get; set; }

        // Constructor
        public Cuenta(string nombre, double saldoInicial)
        {
            Nombre = nombre;
            Saldo = saldoInicial;
            Movimientos = new ObservableCollection<Transaccion>();
        }

        //Guardar CSV
        private void GuardarTransaccionEnArchivo(Transaccion t)
        {
            string ruta = "transacciones_banco.csv";
            string linea = $"{t.Fecha};{t.Tipo};{t.Monto};{t.SaldoFinal};{this.Nombre}";

            File.AppendAllText(ruta, linea + Environment.NewLine);
        }

        //         MÉTODOS DE NEGOCIO
        public void RegistrarDeposito(double monto)
        {
            Saldo += monto;

            var t = new Transaccion
            {
                Fecha = DateTime.Now,
                Tipo = "Depósito",
                Monto = monto,
                SaldoFinal = Saldo
            };

            Movimientos.Add(t);
            GuardarTransaccionEnArchivo(t);
        }

        public void RegistrarRetiro(double monto)
        {
            Saldo -= monto;

            var t = new Transaccion
            {
                Fecha = DateTime.Now,
                Tipo = "Retiro",
                Monto = monto,
                SaldoFinal = Saldo
            };

            Movimientos.Add(t);
            GuardarTransaccionEnArchivo(t);
        }
    }

}
