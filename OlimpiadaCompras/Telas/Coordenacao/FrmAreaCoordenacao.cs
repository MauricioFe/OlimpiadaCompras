
using ApiSGCOlimpiada.Models;
using OlimpiadaCompras.Telas;
using OlimpiadaCompras.Telas.Coordenacao;
using OlimpiadaCompras.Telas.Coordenacao.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras
{
    public partial class FrmAreaCoordenacao : Form
    {
        Usuario usuarioLogado;
        public FrmAreaCoordenacao(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
        }

        private void btnCadastros_Click(object sender, EventArgs e)
        {
            if (pnlCadastros.Visible == true)
            {
                pnlCadastros.Visible = false;
            }
            else
            {
                pnlCadastros.Visible = true;
            }
        }

        private void FrmAreaCoordenacao_Load(object sender, EventArgs e)
        {
        }

        private void dgvSolicitacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmGerenciarSolicitacaoCompra form = new FrmGerenciarSolicitacaoCompra(usuarioLogado);
            form.ShowDialog();
        }

        private void btnCadastroProdutos_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos form = new FrmCadastroProdutos(usuarioLogado);
            form.ShowDialog();
        }

        private void btnCadastroOcupacoes_Click(object sender, EventArgs e)
        {
            FrmCadastroOcupacoes form = new FrmCadastroOcupacoes(usuarioLogado);
            form.ShowDialog();
        }

        private void btnCadastroGrupos_Click(object sender, EventArgs e)
        {
            FrmCadastroGrupos form = new FrmCadastroGrupos(usuarioLogado);
            form.ShowDialog();
        }

        private void btnCadastroTipoCompra_Click(object sender, EventArgs e)
        {
            FrmCadastroTipoCompra form = new FrmCadastroTipoCompra(usuarioLogado);
            form.ShowDialog();
        }

        private void btnCadastroUsuarios_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuarios form = new FrmCadastroUsuarios(usuarioLogado);
            form.ShowDialog();
        }

        private void btnCadastroEscolas_Click(object sender, EventArgs e)
        {
            FrmCadastroEscolas form = new FrmCadastroEscolas(usuarioLogado);
            form.ShowDialog();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            FrmRelatorios form = new FrmRelatorios(usuarioLogado);
            form.ShowDialog();
        }

        private void linkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin form = new FrmLogin();
            form.Show();
            this.Dispose();

        }

        private void FrmAreaCoordenacao_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
