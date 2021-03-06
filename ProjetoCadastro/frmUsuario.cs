﻿using System;
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
    public partial class frmUsuario : Form
    {
        int atual = 0;
        char flag = ' ';

        private void Mostrar()
        {
            lblCodigo.Text = frmPrincipal.cdUsuario[atual].ToString();
            txtNome.Text = frmPrincipal.nomeUsuario[atual];
            txtLogin.Text = frmPrincipal.loginUsuario[atual];
            txtNivel.Text = frmPrincipal.nivelUsuario[atual];
            txtSenha.Text = frmPrincipal.senhaUsuario[atual];
        }

        public void habilitar()
        {
            txtNome.Enabled = true;
            txtLogin.Enabled = true;
            txtNivel.Enabled = true;
            txtSenha.Enabled = true;
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
            txtLogin.Enabled = false;
            txtNivel.Enabled = false;
            txtSenha.Enabled = false;
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

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xablau(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar)8)
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            desabilitar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            desabilitar();
            if (flag == 'N')
            {
                frmPrincipal.cdUsuario[frmPrincipal.indiceUsuario] = frmPrincipal.indiceUsuario + 1;
                frmPrincipal.nomeUsuario[frmPrincipal.indiceUsuario] = txtNome.Text;
                frmPrincipal.loginUsuario[frmPrincipal.indiceUsuario] = txtLogin.Text;
                frmPrincipal.nivelUsuario[frmPrincipal.indiceUsuario] = txtNivel.Text;
                frmPrincipal.senhaUsuario[frmPrincipal.indiceUsuario] = txtSenha.Text;
                atual = frmPrincipal.indiceUsuario;
                frmPrincipal.indiceUsuario++;
            }
            else
            {
                frmPrincipal.nomeUsuario[atual] = txtNome.Text;
                frmPrincipal.loginUsuario[atual] = txtLogin.Text;
                frmPrincipal.nivelUsuario[atual] = txtNivel.Text;
                frmPrincipal.senhaUsuario[atual] = txtSenha.Text;
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = (frmPrincipal.indiceUsuario + 1).ToString();
            txtNome.Text = "";
            txtLogin.Text = "";
            txtNivel.Text = "";
            txtSenha.Text = "";
            if (frmPrincipal.indiceUsuario < 10)
            habilitar();
            flag = 'N';
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(frmPrincipal.indiceUsuario > 0)
            habilitar();
            flag = 'A';
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitar();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if(atual > 0)
            {
                atual--;
                Mostrar();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if(atual < frmPrincipal.indiceUsuario - 1)
            {
                atual++;
                Mostrar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
            frmPrincipal.nomeUsuario[atual] = "";
            frmPrincipal.loginUsuario[atual] = "";
            frmPrincipal.nivelUsuario[atual] = "";
            frmPrincipal.senhaUsuario[atual] = "";
            Mostrar();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPesquisa.Text != "")
            {
                for (int x = 0; x < frmPrincipal.indiceUsuario; x++)
                {
                    if (txtPesquisa.Text == frmPrincipal.nomeUsuario[x])
                    {
                        atual = x;
                        break;
                    }
                }
            }
            pnlPesquisar.Visible = false;
            Mostrar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            pnlPesquisar.Visible = true;
            txtPesquisa.Focus();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics objImpressao = e.Graphics;

            string strDados;

            //(char)10 para pular linha
            strDados = "                               Ficha de Usuário\n" + (char)10;
            objImpressao.DrawString(strDados, new System.Drawing.Font("Times New Roman", 22, FontStyle.Bold), Brushes.Black, 50, 50);
            strDados = "Código: " + lblCodigo.Text + "\nNome: " + txtNome.Text + "\nLogin: " + txtLogin.Text + "\nNível: " + txtNivel.Text;
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
