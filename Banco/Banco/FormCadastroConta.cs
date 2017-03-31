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
    public partial class FormCadastroConta : Form
    {
        private Form1 formPrincipal;
        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            // Exercício 7 opcional, capítulo 12
            if (comboTipoConta.SelectedItem.ToString() == "ContaCorrente")
            {

                Conta novaConta = new ContaCorrente();
                novaConta.Titular = new Cliente(textoTitular.Text);
                //novaConta.Numero = Convert.ToInt32(textoNumero.Text);
                novaConta.Tipo = "ContaCorrente";
                this.formPrincipal.AdicionaConta(novaConta);

            }
            else
            {
                Conta novaConta = new ContaPoupanca();
                novaConta.Titular = new Cliente(textoTitular.Text);
                //novaConta.Numero = Convert.ToInt32(textoNumero.Text);
                novaConta.Tipo = "ContaPopanca";
                this.formPrincipal.AdicionaConta(novaConta);
                
            }

            this.Close();

        }

        private void comboTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            textoNumero.Text = Convert.ToString(Conta.ProximoNumero());
        }
    }
}
