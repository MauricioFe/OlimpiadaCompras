using OlimpiadaCompras.Models;
using OlimpiadaCompras.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Telas.Avaliador
{
    public partial class FrmAnexarNotaFiscal : Form
    {
        private long idSolicitacao;
        private Usuario usuarioLogado;
        private FrmAreaAvaliador form;

        public FrmAnexarNotaFiscal(long idSolicitacao, Usuario usuario, FrmAreaAvaliador form)
        {
            this.idSolicitacao = idSolicitacao;
            this.usuarioLogado = usuario;
            this.form = form;
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "pdf files | *.pdf";
            openFileDialog1.InitialDirectory = $@"{Environment.SpecialFolder.Desktop}";
            openFileDialog1.FileName = "nota fiscal";
            openFileDialog1.Title = "Selecione o orçamento no formato pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtAnexarPdf.Text = openFileDialog1.FileName;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            if (VerificaCamposVazios())
            {
                if (await HttpSolicitacaoCompras.AnexarNotaFiscal(openFileDialog1.FileName, idSolicitacao, usuarioLogado.token))
                {
                    Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
                    acompanhamento.StatusId = ConstantesProjeto.STATUS_EM_ANALISE_NF;
                    var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                    if (acompanhamentoUpdate != null)
                    {
                        MessageBox.Show("Nota fiscal anexada com sucesso");
                        form.AtualizaGridSolicitacoesPendentes();
                        form.AtualizaGridSolicitacoesUsuario();
                        this.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }
        private bool VerificaCamposVazios()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)item;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
