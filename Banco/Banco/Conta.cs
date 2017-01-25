using System;

namespace Banco
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public Cliente Titular { get; set; }


        public abstract void Deposita(double valor);

        public abstract void Saca(double valor);

    }
}