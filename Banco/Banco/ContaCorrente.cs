﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class ContaCorrente : Conta, ITributavel
    {
        
        public override void Saca(double valor)
        {
            if(valor + 0.10 > this.Saldo)
            {
                throw new Exception("Valor do saque maior que o saldo");
            }
            else
            {
                this.Saldo -= (valor + 0.10);
            }
        }

        public override void Deposita(double valor)
        {
            this.Saldo += (valor - 0.05);
        }

        public double CalculaTributos()
        {
            return this.Saldo *0.05;
        }
    }
}
