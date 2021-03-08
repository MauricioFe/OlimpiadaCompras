using OlimpiadaCompras.Models;
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
        long idSolicitacao;
        long idStatus = 0;
        int acoes = 0;
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

        public async void AtualizaGridSolicitacoesUsuario()
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
            acompanhamentos = await HttpAcompanhamento.GetSolicitacaoAcompanhamento(usuarioLogado.token);
            dgvMinhasSolicitacoes.Rows.Clear();
            foreach (var item in acompanhamentos.Where(u => u.UsuarioId == usuarioLogado.Id))
            {
                int n = dgvMinhasSolicitacoes.Rows.Add();
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaIdSolicitacao"].Value = item.SolicitacaoCompra.Id;
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaData"].Value = item.SolicitacaoCompra.Data.ToString("dd/MM/yyyy");
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaJustificativa"].Value = item.SolicitacaoCompra.Justificativa;
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaStatus"].Value = item.Status.Descricao;
                dgvMinhasSolicitacoes.Rows[n].Cells["colMinhaStatusID"].Value = item.Status.Id;

            }
        }

        public async void AtualizaGridSolicitacoesPendentes()
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
            acompanhamentos = await HttpAcompanhamento.GetSolicitacaoAcompanhamentoPendente(usuarioLogado.token);
            dgvSolicitacoesPendentes.Rows.Clear();
            foreach (var item in acompanhamentos.Where(u => u.UsuarioId == usuarioLogado.Id))
            {
                int n = dgvSolicitacoesPendentes.Rows.Add();
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteIdSolicitacao"].Value = item.SolicitacaoCompra.Id;
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteData"].Value = item.SolicitacaoCompra.Data.ToString("dd/MM/yyyy");
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteJustificativa"].Value = item.SolicitacaoCompra.Justificativa;
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteStatus"].Value = item.Status.Descricao;
                dgvSolicitacoesPendentes.Rows[n].Cells["colPendenteStatusID"].Value = item.Status.Id;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idStatus == ConstantesProjeto.STATUS_PENDENTE_ALTERACAO)
            {
                acoes = ConstantesProjeto.EDITAR;
                FrmNovaSolicitacao form = new FrmNovaSolicitacao(usuarioLogado, idSolicitacao, acoes, this);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para editar uma solicitação ela precisa ter o status pendente para alteração",
                    "Confirmação de edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNovaSolicitacao_Click(object sender, EventArgs e)
        {
            FrmNovaSolicitacao frm = new FrmNovaSolicitacao(usuarioLogado, this);
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

        private void dgvSolicitacoesPendentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idStatus = Convert.ToInt64(dgvSolicitacoesPendentes.Rows[e.RowIndex].Cells["colPendenteStatusID"].Value);
            if (idStatus == ConstantesProjeto.STATUS_FINALIZAR_CADASTRO)
            {
                acoes = ConstantesProjeto.SALVAR;
            }
            else
            {
                acoes = ConstantesProjeto.VISUALIZAR;
            }
            btnEditar.Enabled = false;
            idSolicitacao = Convert.ToInt64(dgvSolicitacoesPendentes.Rows[e.RowIndex].Cells[0].Value);
            FrmNovaSolicitacao form = new FrmNovaSolicitacao(usuarioLogado, idSolicitacao, acoes, this);
            form.ShowDialog();

        }

        private void dgvMinhasSolicitacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            acoes = ConstantesProjeto.VISUALIZAR;
            idSolicitacao = Convert.ToInt64(dgvMinhasSolicitacoes.Rows[e.RowIndex].Cells[0].Value);
            FrmNovaSolicitacao form = new FrmNovaSolicitacao(usuarioLogado, idSolicitacao, acoes, this);
            form.ShowDialog();
        }

        private void dgvSolicitacoesPendentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                idStatus = Convert.ToInt64(dgvSolicitacoesPendentes.Rows[e.RowIndex].Cells["colPendenteStatusID"].Value);
                idSolicitacao = Convert.ToInt64(dgvSolicitacoesPendentes.Rows[e.RowIndex].Cells[0].Value);
                if (idStatus == ConstantesProjeto.STATUS_PENDENTE_ALTERACAO)
                {
                    btnEditar.Enabled = true;
                }
                else
                {
                    btnEditar.Enabled = false;
                }
                if (idStatus == ConstantesProjeto.STATUS_ANEXAR_NF)
                {
                    FrmAnexarNotaFiscal form = new FrmAnexarNotaFiscal(idSolicitacao, usuarioLogado, this);
                    form.ShowDialog();
                }
            }
        }
    }
}
