using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCadastro
{
    public partial class frmFornecedor : Form
    {
        int atual = 0;
        char flag = ' ';
        private void Mostrar()
        {
            lblCodigo.Text = frmPrincipal.cdFornecedor[atual].ToString();
            txtNome.Text = frmPrincipal.nomeFornecedor[atual];
            txtEndereco.Text = frmPrincipal.enderecoFornecedor[atual];
            txtBairro.Text = frmPrincipal.bairroFornecedor[atual];
            txtEstado.Text = frmPrincipal.estadoFornecedor[atual];
            txtCNPJ.Text = frmPrincipal.cnpjFornecedor[atual];
            txtCidade.Text = frmPrincipal.cidadeFornecedor[atual];
            txtCEP.Text = frmPrincipal.cepFornecedor[atual];
            txtIE.Text = frmPrincipal.ieFornecedor[atual];
        }
        public void habilitar()
        {
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtEstado.Enabled = true;
            txtCNPJ.Enabled = true;
            txtCidade.Enabled = true;
            txtCEP.Enabled = true;
            txtIE.Enabled = true;
            ////////////////////////////
            btnAnterior.Enabled = false;
            btnProximo.Enabled = false;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnPesquisar.Enabled = false;
            btnImprimir.Enabled = false;
            btnSair.Enabled = false;
        }

        public void desabilitar()
        {
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtEstado.Enabled = false;
            txtCNPJ.Enabled = false;
            txtCidade.Enabled = false;
            txtCEP.Enabled = false;
            txtIE.Enabled = false;
            ///////////////////////////
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnPesquisar.Enabled = true;
            btnImprimir.Enabled = true;
            btnSair.Enabled = true;
        }

        public frmFornecedor()
        {
            InitializeComponent();
        }
        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            desabilitar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = (frmPrincipal.indiceFornecedor + 1).ToString();
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtEstado.Text = "";
            txtBairro.Text = "";
            txtCNPJ.Text = "";
            txtCidade.Text = "";
            txtCEP.Text = "";
            txtIE.Text = "";
            if (frmPrincipal.indiceFornecedor < 10)
            habilitar();
            flag = 'N';
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            desabilitar();
            if (flag == 'N')
            {
                frmPrincipal.cdFornecedor[frmPrincipal.indiceFornecedor] = frmPrincipal.indiceFornecedor + 1;
                frmPrincipal.nomeFornecedor[frmPrincipal.indiceFornecedor] = txtNome.Text;
                frmPrincipal.enderecoFornecedor[frmPrincipal.indiceFornecedor] = txtEndereco.Text;
                frmPrincipal.estadoFornecedor[frmPrincipal.indiceFornecedor] = txtEstado.Text;
                frmPrincipal.bairroFornecedor[frmPrincipal.indiceFornecedor] = txtBairro.Text;
                frmPrincipal.cnpjFornecedor[frmPrincipal.indiceFornecedor] = txtCNPJ.Text;
                frmPrincipal.cidadeFornecedor[frmPrincipal.indiceFornecedor] = txtCidade.Text;
                frmPrincipal.cepFornecedor[frmPrincipal.indiceFornecedor] = txtCEP.Text;
                frmPrincipal.ieFornecedor[frmPrincipal.indiceFornecedor] = txtIE.Text;
                atual = frmPrincipal.indiceFornecedor;
                frmPrincipal.indiceFornecedor++;
            }
            else
            {
                frmPrincipal.nomeFornecedor[atual] = txtNome.Text;
                frmPrincipal.enderecoFornecedor[atual] = txtEndereco.Text;
                frmPrincipal.estadoFornecedor[atual] = txtEstado.Text;
                frmPrincipal.bairroFornecedor[atual] = txtBairro.Text;
                frmPrincipal.cnpjFornecedor[atual] = txtCNPJ.Text;
                frmPrincipal.cidadeFornecedor[atual] = txtCidade.Text;
                frmPrincipal.cepFornecedor[atual] = txtCEP.Text;
                frmPrincipal.ieFornecedor[atual] = txtIE.Text;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (frmPrincipal.indiceFornecedor < 10)
            habilitar();
            flag = 'A';
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitar();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (atual < frmPrincipal.indiceFornecedor - 1)
            {
                atual++;
                Mostrar();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (atual > 0)
            {
                atual--;
                Mostrar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            frmPrincipal.nomeFornecedor[atual] ="";
            frmPrincipal.enderecoFornecedor[atual]="";
            frmPrincipal.bairroFornecedor[atual]="";
            frmPrincipal.estadoFornecedor[atual]="";
            frmPrincipal.cnpjFornecedor[atual]="";
            frmPrincipal.cidadeFornecedor[atual]="";
            frmPrincipal.cepFornecedor[atual]="";
            frmPrincipal.ieFornecedor[atual]="";
            Mostrar();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            pnlPesquisar.Visible = true;
            txtPesquisa.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPesquisa.Text != "")
            {
                for (int x = 0; x < frmPrincipal.indiceFornecedor; x++)
                {
                    if (txtPesquisa.Text == frmPrincipal.nomeFornecedor[x])
                    {
                        atual = x;
                        break;
                    }
                }
            }
            pnlPesquisar.Visible = false;
            Mostrar();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;

            string strDados;

            //(char)10 para pular linha
            strDados = "                               Ficha do Fornecedor\n" + (char)10;
            objImpressao.DrawString(strDados, new System.Drawing.Font("Times New Roman", 22, FontStyle.Bold), Brushes.Black, 50, 50);
            strDados = "Código: " + lblCodigo.Text + "\nNome: " + txtNome.Text + "\nEndereço: " + txtEndereco.Text + "\nBairro: " + txtBairro.Text + "\nEstado: " + txtEstado.Text + "\nCNPJ: " + txtCNPJ.Text + "\nCidade: " + txtCidade.Text + "\nCEP: " + txtCEP.Text + "\nIE: " + txtIE.Text;
            objImpressao.DrawString(strDados, new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, 50, 250);
            objImpressao.DrawLine(new System.Drawing.Pen(Brushes.Black, 3), 50, 150, 780, 150);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.Show();
        }
    }
}
