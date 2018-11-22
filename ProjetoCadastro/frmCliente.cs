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
    public partial class frmCliente : Form
    {
        int atual = 0;
        char flag = ' ';

        private void Mostrar()
        {
            lblCodigo.Text = frmPrincipal.cdCliente[atual].ToString();
            txtNome.Text = frmPrincipal.nomeCliente[atual];
            txtEndereco.Text = frmPrincipal.enderecoCliente[atual];
            txtBairro.Text = frmPrincipal.bairroCliente[atual];
            txtEstado.Text = frmPrincipal.estadoCliente[atual];
            txtCPF.Text = frmPrincipal.cpfCliente[atual];
            txtCidade.Text = frmPrincipal.cidadeCliente[atual];
            txtCEP.Text = frmPrincipal.cepCliente[atual];
            txtRG.Text = frmPrincipal.rgCliente[atual];
        }

        public void habilitar()
        {
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtEstado.Enabled = true;
            txtCPF.Enabled = true;
            txtCidade.Enabled = true;
            txtCEP.Enabled = true;
            txtRG.Enabled = true;
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
            txtCPF.Enabled = false;
            txtCidade.Enabled = false;
            txtCEP.Enabled = false;
            txtRG.Enabled = false;
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

        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            desabilitar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            desabilitar();
            if (flag == 'N')
            {
                frmPrincipal.cdCliente[frmPrincipal.indiceCliente] = frmPrincipal.indiceCliente + 1;
                frmPrincipal.nomeCliente[frmPrincipal.indiceCliente] = txtNome.Text;
                frmPrincipal.enderecoCliente[frmPrincipal.indiceCliente] = txtEndereco.Text;
                frmPrincipal.estadoCliente[frmPrincipal.indiceCliente] = txtEstado.Text;
                frmPrincipal.cpfCliente[frmPrincipal.indiceCliente] = txtCPF.Text;
                frmPrincipal.cidadeCliente[frmPrincipal.indiceCliente] = txtCidade.Text;
                frmPrincipal.bairroCliente[frmPrincipal.indiceCliente] = txtBairro.Text;
                frmPrincipal.cepCliente[frmPrincipal.indiceCliente] = txtCEP.Text;
                frmPrincipal.rgCliente[frmPrincipal.indiceCliente] = txtRG.Text;
                atual = frmPrincipal.indiceCliente;
                frmPrincipal.indiceCliente++;
            }
            else
            {
                frmPrincipal.nomeCliente[atual] = txtNome.Text;
                frmPrincipal.enderecoCliente[atual] = txtEndereco.Text;
                frmPrincipal.estadoCliente[atual] = txtEstado.Text;
                frmPrincipal.cpfCliente[atual] = txtCPF.Text;
                frmPrincipal.cidadeCliente[atual] = txtCidade.Text;
                frmPrincipal.cepCliente[atual] = txtCEP.Text;
                frmPrincipal.rgCliente[atual] = txtRG.Text;
                frmPrincipal.bairroCliente[atual] = txtBairro.Text;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = (frmPrincipal.indiceCliente + 1).ToString();
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtEstado.Text = "";
            txtBairro.Text = "";
            txtCPF.Text = "";
            txtCidade.Text = "";
            txtCEP.Text = "";
            txtRG.Text = "";
            if (frmPrincipal.indiceCliente < 10)
            habilitar();
            flag = 'N';
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (frmPrincipal.indiceCliente > 0)
            habilitar();
            flag = 'A';
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitar();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (atual < frmPrincipal.indiceCliente - 1)
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
            frmPrincipal.nomeCliente[atual] ="";
            frmPrincipal.enderecoCliente[atual]="";
            frmPrincipal.bairroCliente[atual]="";
            frmPrincipal.estadoCliente[atual]="";
            frmPrincipal.cpfCliente[atual]="";
            frmPrincipal.cidadeCliente[atual]="";
            frmPrincipal.cepCliente[atual]="";
            frmPrincipal.rgCliente[atual]="";
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
                for (int x = 0; x < frmPrincipal.indiceCliente; x++)
                {
                    if (txtPesquisa.Text == frmPrincipal.nomeCliente[x])
                    {
                        atual = x;
                        break;
                    }
                }
            }
            pnlPesquisar.Visible = false;
            Mostrar();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;

            string strDados;

            //(char)10 para pular linha
            strDados = "                               Ficha de Cliente\n" + (char)10;
            objImpressao.DrawString(strDados, new System.Drawing.Font("Times New Roman", 22, FontStyle.Bold), Brushes.Black, 50, 50);
            strDados = "Código: " + lblCodigo.Text + "\nNome: " + txtNome.Text + "\nEndereço: " + txtEndereco.Text + "\nBairro: " + txtBairro.Text + "\nEstado: " + txtEstado.Text + "\nCPF: " + txtCPF.Text + "\nCidade: " + txtCidade.Text + "\nCEP: " + txtCEP.Text + "\nRG: " + txtRG.Text;
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
