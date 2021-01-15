using ApiSGCOlimpiada.Models;
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

        private const int SOLICITAR_ALTERACAO = 1;
        private const int SOLICITACAO_APROVADA = 2;
        private const int SOLICITACAO_REPROVADA = 3;
        int acao = 0;
        Acompanhamento acompanhamento;
        private Usuario usuarioLogado;

        public FrmModalSolicitacao(int acao, Acompanhamento acompanhamento, Usuario usuario)
        {
            InitializeComponent();
            this.acao = acao;
            this.acompanhamento = acompanhamento;
            this.usuarioLogado = usuario;
        }
        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            if (acao == SOLICITACAO_APROVADA)
            {
                acompanhamento.StatusId = ConstantesProjeto.APROVADO;
                var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                if (acompanhamentoUpdate != null)
                {
                    //FrmEmailAutorizacao form = new FrmEmailAutorizacao();
                    //form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar aprovação");
                }

            }
            else if (acao == SOLICITACAO_REPROVADA)
            {
                acompanhamento.StatusId = ConstantesProjeto.REPROVADO;
                var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                if (acompanhamentoUpdate != null)
                {
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar reprovação");
                }
            }
            else
            {
                acompanhamento.StatusId = ConstantesProjeto.PENDENTE_ALTERACAO;
                var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                if (acompanhamentoUpdate != null)
                {
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar solicitação de alteração");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
