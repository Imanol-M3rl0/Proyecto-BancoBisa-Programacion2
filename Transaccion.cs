using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProyectoBancoP2C
{
    public class Transaccion
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // "Depósito" o "Retiro"
        public double Monto { get; set; }
        public double SaldoFinal { get; set; } // Saldo después de la transacción

        public Transaccion() { }

        public Transaccion(DateTime fecha, string tipo, double monto, double saldoFinal)
        {
            Fecha = fecha;
            Tipo = tipo;
            Monto = monto;
            SaldoFinal = saldoFinal;
        }

        public override string ToString()
        {
            return $"{Fecha:dd/MM/yyyy HH:mm} - {Tipo} - {Monto} Bs. - Saldo: {SaldoFinal} Bs.";
        }
    }
}
