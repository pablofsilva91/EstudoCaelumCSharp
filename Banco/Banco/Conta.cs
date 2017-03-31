using System;

namespace Banco
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public Cliente Titular { get; set; }
        public string Tipo { get; set; }


        public static int ProximoNumero()
        {
            return Conta.numeroDeConta +1;
        }
        private static int numeroDeConta;

        public Conta()
        {
            Conta.numeroDeConta++;
            this.Numero = Conta.numeroDeConta;
        }

        public abstract void Deposita(double valor);

        public abstract void Saca(double valor);

       
        

    }
}