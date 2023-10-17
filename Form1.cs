using System;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public decimal Resultado { get; set; }
        public decimal Valor { get; set; }
        private Operacao OperacaoSelecionada { get; set; }
        private bool operacaoConcluida;

        private enum Operacao
        {
            Adicao,
            Subtracao,
            Multiplicacao,
            Divisao,
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (!txtResultado.Text.Contains("."))
                txtResultado.Text += ".";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Multiplicacao;
            if (decimal.TryParse(txtResultado.Text, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out decimal valor))
            {
                Valor = valor;
                txtResultado.Text = "";
                lblOperacao.Text = "X";
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "0";
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "1";
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "3";
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "6";
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "7";
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "8";
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "9";
        }

        private void btnAdicao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Adicao;
            if (decimal.TryParse(txtResultado.Text, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out decimal valor))
            {
                Valor = valor;
                txtResultado.Text = "";
                lblOperacao.Text = "+";
            }
            else
            {
                MessageBox.Show("Invalid input value. Please enter a valid number.");
            }
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Subtracao;
            if (decimal.TryParse(txtResultado.Text, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out decimal valor))
            {
                Valor = valor;
                txtResultado.Text = "";
                lblOperacao.Text = "-";
            }
            else
            {
                MessageBox.Show("Invalid input value. Please enter a valid number.");
            }
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            OperacaoSelecionada = Operacao.Divisao;
            if (decimal.TryParse(txtResultado.Text, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out decimal valor))
            {
                Valor = valor;
                txtResultado.Text = "";
                lblOperacao.Text = "/";
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            lblOperacao.Text = "";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (operacaoConcluida)
            {
                txtResultado.Text = Resultado.ToString("F2", CultureInfo.GetCultureInfo("en-US"));
            }
            else
            {
                decimal numeroInserido;
                if (decimal.TryParse(txtResultado.Text, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out numeroInserido))
                {
                    switch (OperacaoSelecionada)
                    {
                        case Operacao.Adicao:
                            Resultado = Valor + numeroInserido;
                            break;
                        case Operacao.Subtracao:
                            Resultado = Valor - numeroInserido;
                            break;
                        case Operacao.Multiplicacao:
                            Resultado = Valor * numeroInserido;
                            break;
                        case Operacao.Divisao:
                            if (numeroInserido != 0)
                            {
                                Resultado = Valor / numeroInserido;
                            }
                            else
                            {
                                MessageBox.Show("It is not possible to divide by zero. Please enter a non-zero divisor.");
                                return;
                            }
                            break;
                    }

                    txtResultado.Text = Resultado.ToString("F2", CultureInfo.GetCultureInfo("en-US"));
                    lblOperacao.Text = "=";
                    operacaoConcluida = true;
                }
                else
                {
                    MessageBox.Show("Invalid input value. Please enter a valid number.");
                }
            }
        }
    }
}
