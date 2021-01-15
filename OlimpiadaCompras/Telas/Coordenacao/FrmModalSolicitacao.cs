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
                var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);


                //FrmEmailAutorizacao form = new FrmEmailAutorizacao();
                //form.ShowDialog();
            }
            else if (acao == SOLICITACAO_REPROVADA)
            {
                //criar lógica para update em acompanhamento
                this.Dispose();
            }
            else
            {
                this.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
