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
        private int numeroDeContas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contas = new Conta[10];

            Conta c1 = new ContaCorrente();
            c1.Numero = 1;
            c1.Titular = new Banco.Cliente("Pablo");
            this.AdicionaConta(c1);

            Conta c2 = new ContaCorrente();
            c2.Numero = 2;
            c2.Titular = new Banco.Cliente("Lucas");
            this.AdicionaConta(c2);

            foreach (Conta conta in contas)
            {
                comboContas.Items.Add("titular: " + conta.Titular.Nome);
                comboDestinoTransferencia.Items.Add("titular: " + conta.Titular.Nome);
            }

            
        }

        public void AdicionaConta(Conta conta)
        {
            this.contas[this.numeroDeContas] = conta;
            this.numeroDeContas++;
            comboContas.Items.Add("titular: " + conta.Titular.Nome);

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
            try
            {
                selecionada.Saca(valor);
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
                MessageBox.Show("Dinheiro liberado");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Saldo insuficiente");
            }
            
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

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);
            formularioDeCadastro.ShowDialog();
        }

        private void botaoImpostos_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = new ContaCorrente();
            conta.Deposita(200.0);

            ContaCorrente outraConta = new ContaCorrente();
            outraConta.Deposita(200.0);

            TotalizadosDeTributos totalizador = new TotalizadosDeTributos();
            totalizador.Adiciona(conta);
            MessageBox.Show("Total: " + totalizador.Total);

            totalizador.Adiciona(outraConta);
            MessageBox.Show("Total: " + totalizador.Total);

           
        }
    }

    
}
