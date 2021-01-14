using ApiSGCOlimpiada.Models;
using OlimpiadaCompras.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Telas.Avaliador
{
    public partial class FrmAreaAvaliador : Form
    {
        Usuario usuarioLogado;
        public FrmAreaAvaliador(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            var nomeSobrenome = usuario.Nome.Split(' ');
            lblNomeUsuarioLogado.Text = $"Olá, {nomeSobrenome[0]} {nomeSobrenome[1]}";
        }

        private void FrmAreaAvaliador_Load(object sender, EventArgs e)
        {
            AtualizaGridSolicitacoesUsuario();
            AtualizaGridSolicitacoesPendentes();
        }

        private async void AtualizaGridSolicitacoesUsuario()
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
            acompanhamentos = await HttpAcompanhamento.GetSolicitacaoAcompanhamento(usuarioLogado.token);
            dgvMinhasSolicitacoes.Rows.Clear();
            foreach (var item in acompanhamentos)
            {
                int n = dgvMinhasSolicitacoes.Rows.Add();
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaIdSolicitacao"].Value = item.SolicitacaoCompra.Id;
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaData"].Value = item.SolicitacaoCompra.Data.ToString("dd/MM/yyyy");
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaUsuario"].Value = $"{item.Usuario.Nome.Split(' ')[0]} {item.Usuario.Nome.Split(' ')[1]}";
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaStatus"].Value = item.Status.Descricao;
            }
        }

        private async void AtualizaGridSolicitacoesPendentes()
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
            acompanhamentos = await HttpAcompanhamento.GetSolicitacaoAcompanhamentoPendente(usuarioLogado.token);
            dgvSolicitacoesPendentes.Rows.Clear();
            foreach (var item in acompanhamentos)
            {
                int n = dgvSolicitacoesPendentes.Rows.Add();
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteIdSolicitacao"].Value = item.SolicitacaoCompra.Id;
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteData"].Value = item.SolicitacaoCompra.Data.ToString("dd/MM/yyyy");
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteUsuario"].Value = $"{item.Usuario.Nome.Split(' ')[0]} {item.Usuario.Nome.Split(' ')[1]}";
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteStatus"].Value = item.Status.Descricao;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmNovaSolicitacao form = new FrmNovaSolicitacao(usuarioLogado);
            form.ShowDialog();
        }

        private void btnNovaSolicitacao_Click(object sender, EventArgs e)
        {
            FrmNovaSolicitacao frm = new FrmNovaSolicitacao(usuarioLogado);
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmEditarUsuarios form = new FrmEditarUsuarios(usuarioLogado);
            form.ShowDialog();
        }

        private void linkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin form = new FrmLogin();
            form.Show();
            this.Dispose();
        }

        private void FrmAreaAvaliador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnVisualizaTodas_Click(object sender, EventArgs e)
        {
            FrmTodasSolicitacoes form = new FrmTodasSolicitacoes(usuarioLogado);
            form.ShowDialog();
        }
    }
}
