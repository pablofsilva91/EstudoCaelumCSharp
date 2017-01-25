﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class ContaCorrente : Conta
    {
        
        public override void Saca(double valor)
        {
            this.Saldo -= (valor + 0.10);  
        }

        public override void Deposita(double valor)
        {
            this.Saldo += (valor - 0.05);
        }
    }
}
