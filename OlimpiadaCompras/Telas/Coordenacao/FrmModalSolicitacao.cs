using OlimpiadaCompras.Models;
using OlimpiadaCompras.Requests;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Telas.Coordenacao
{
    public partial class FrmModalSolicitacao : Form
    {
        public FrmModalSolicitacao()
        {
            InitializeComponent();
        }


        int acao = 0;
        Acompanhamento acompanhamento;
        private Usuario usuarioLogado;
        FrmAreaCoordenacao frmAreaCoordenacao;

        public FrmModalSolicitacao(int acao, Acompanhamento acompanhamento, Usuario usuario, FrmAreaCoordenacao frmAreaCoordenacao)
        {
            InitializeComponent();
            this.acao = acao;
            this.acompanhamento = acompanhamento;
            this.usuarioLogado = usuario;
            this.frmAreaCoordenacao = frmAreaCoordenacao;
        }
        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            if (acao == ConstantesProjeto.SOLICITACAO_APROVADA)
            {
                acompanhamento.StatusId = ConstantesProjeto.STATUS_APROVADO;
                acompanhamento.Observacao = txtObservacao.Text;
                var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                if (acompanhamentoUpdate != null)
                {
                    MessageBox.Show("Operação realizada com sucesso", "Mensagem de sucesso", MessageBoxButtons.OK);
                    this.Dispose();
                    frmAreaCoordenacao.AtualizaGridSolicitacoes();
                    FrmEmailAutorizacao form = new FrmEmailAutorizacao();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar aprovação");
                }

            }
            else if (acao == ConstantesProjeto.SOLICITACAO_REPROVADA)
            {
                if (!string.IsNullOrEmpty(txtObservacao.Text))
                {
                    acompanhamento.StatusId = ConstantesProjeto.STATUS_REPROVADO;
                    acompanhamento.Observacao = txtObservacao.Text;
                    var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                    if (acompanhamentoUpdate != null)
                    {
                        MessageBox.Show("Operação realizada com sucesso", "Mensagem de sucesso", MessageBoxButtons.OK);
                        this.Dispose();
                        frmAreaCoordenacao.AtualizaGridSolicitacoes();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar reprovação");
                    }
                }
                else
                {
                    MessageBox.Show("Para conseguir prosseguir com essa ação preencha o campo observação", "Preencha o campo observação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtObservacao.Text))
                {
                    acompanhamento.StatusId = ConstantesProjeto.STATUS_PENDENTE_ALTERACAO;
                    acompanhamento.Observacao = txtObservacao.Text;
                    var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                    if (acompanhamentoUpdate != null)
                    {
                        MessageBox.Show("Operação realizada com sucesso", "Mensagem de sucesso", MessageBoxButtons.OK);
                        this.Dispose();
                        frmAreaCoordenacao.AtualizaGridSolicitacoes();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar solicitação de alteração");
                    }
                }
                else
                {
                    MessageBox.Show("Para conseguir prosseguir com essa ação preencha o campo observação", "Preencha o campo observação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
