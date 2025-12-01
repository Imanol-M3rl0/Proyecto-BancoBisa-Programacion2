using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfProyectoBancoP2C
{
    public class Cuenta : INotifyPropertyChanged
    {
        // Evento para notificar cambios (para que el ListBox se refresque).
        public event PropertyChangedEventHandler PropertyChanged;
        private double saldo;
        public string Nombre { get; set; }
        public double Saldo
        {
            get { return saldo; }
            set
            {
                saldo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Saldo)));
            }
        }

        // Lista de transacciones
        public ObservableCollection<Transaccion> Movimientos { get; set; }

        // Constructores
        public Cuenta(string nombre, double saldoInicial)
        {
            Nombre = nombre;
            Saldo = saldoInicial;
            Movimientos = new ObservableCollection<Transaccion>();
        }

        // Metodos 
        public void RegistrarDeposito(double monto)
        {
            Saldo += monto;
            Movimientos.Add(new Transaccion
            {
                Fecha = DateTime.Now,
                Tipo = "Depósito",
                Monto = monto,
                SaldoFinal = Saldo
            });
        }

        public void RegistrarRetiro(double monto)
        {
            Saldo -= monto;
            Movimientos.Add(new Transaccion
            {
                Fecha = DateTime.Now,
                Tipo = "Retiro",
                Monto = monto,
                SaldoFinal = Saldo
            });
        }
    }
}
