using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class Form1 : Form
    {
        private Conta[] contas;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contas = new Conta[3];

            this.contas[0] = new ContaCorrente();
            this.contas[0].Numero = 1;
            this.contas[0].Titular = new Banco.Cliente("Pablo");

            this.contas[2] = new Conta();
            this.contas[2].Titular = new Cliente("victor");
            this.contas[2].Numero = 3;

            this.contas[1] = new ContaPoupanca();
            this.contas[1].Titular = new Cliente("mauricio");
            this.contas[1].Numero = 2;

            foreach (Conta conta in contas)
            {
                comboContas.Items.Add("titular: " + conta.Titular.Nome);
                comboDestinoTransferencia.Items.Add("titular: " + conta.Titular.Nome);
            }

            
        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            //int indice = Convert.ToInt32(comboContas);
            int indice = comboContas.SelectedIndex;

            Conta selecionada = this.contas[indice];

            double valor = Convert.ToDouble(textoValor.Text);
            selecionada.Deposita(valor);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            //int indice = Convert.ToInt32(comboContas);
            int indice = comboContas.SelectedIndex;

            Conta selecionada = this.contas[indice];

            double valor = Convert.ToDouble(textoValor.Text);
            selecionada.Saca(valor);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = this.contas[indice];
            textoNumero.Text = Convert.ToString(selecionada.Numero);
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void textoSaldo_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboDestinoTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceTransferencia = comboDestinoTransferencia.SelectedIndex;
            Conta selecionada = this.contas[indiceTransferencia];
            textoNumero.Text = Convert.ToString(selecionada.Numero);
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void transferir_Click(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            int indiceTransferir = comboDestinoTransferencia.SelectedIndex;

            Conta selecionadaOrigem = this.contas[indice];
            Conta selecionadaDestino = this.contas[indiceTransferir];

            //saca da conta origem
            double valor = Convert.ToDouble(textoValor.Text);
            selecionadaOrigem.Saca(valor);
            textoSaldo.Text = Convert.ToString(selecionadaOrigem.Saldo);

            //deposita na conta destino
            double valorTransferencia = Convert.ToDouble(textoValor.Text);
            selecionadaDestino.Deposita(valorTransferencia);
            textoSaldo.Text = Convert.ToString(selecionadaDestino.Saldo);
        }
    }

    
}
