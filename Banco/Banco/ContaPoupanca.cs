﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class ContaPoupanca : Conta
    {
        public override void Saca(double valor)
        {
            base.Saca(valor + 0.10);
        }
    }
}
