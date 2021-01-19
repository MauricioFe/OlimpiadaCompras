
using OlimpiadaCompras.Models;
using OlimpiadaCompras.Requests;
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
        long idSolicitacao = 0;
        List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
        public FrmAreaCoordenacao(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            var nomeSobrenome = usuario.Nome.Split(' ');
            lblNomeUsuarioLogado.Text = $"Olá, {nomeSobrenome[0]} {nomeSobrenome[1]}";
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
            AtualizaGridSolicitacoes();
        }
        private async void AtualizaGridSolicitacoes()
        {
            acompanhamentos = await HttpAcompanhamento.GetSolicitacaoAcompanhamento(usuarioLogado.token);
            dgvSolicitacoes.Rows.Clear();
            foreach (var item in acompanhamentos.OrderBy(ac => ac.StatusId))
            {
                int n = dgvSolicitacoes.Rows.Add();
                dgvSolicitacoes.Rows[n].Cells["colIdSolicitacao"].Value = item.SolicitacaoCompra.Id;
                dgvSolicitacoes.Rows[n].Cells["colData"].Value = item.SolicitacaoCompra.Data.ToString("dd/MM/yyyy");
                dgvSolicitacoes.Rows[n].Cells["colUsuario"].Value = $"{item.Usuario.Nome.Split(' ')[0]} {item.Usuario.Nome.Split(' ')[1]}";
                dgvSolicitacoes.Rows[n].Cells["colStatus"].Value = item.Status.Descricao;
            }
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

        private void dgvSolicitacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idSolicitacao = Convert.ToInt64(dgvSolicitacoes.Rows[e.RowIndex].Cells[0].Value);
            FrmGerenciarSolicitacaoCompra form = new FrmGerenciarSolicitacaoCompra(usuarioLogado, idSolicitacao);
            form.ShowDialog();
        }
    }
}
