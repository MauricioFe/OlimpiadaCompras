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

namespace OlimpiadaCompras.Telas.Coordenacao
{
    public partial class FrmVisualizarNotaFiscal : Form
    {
        private FrmAreaCoordenacao form;
        private long idSolicitacao;
        private Usuario usuarioLogado;

        public FrmVisualizarNotaFiscal(FrmAreaCoordenacao form, long idSolicitacao, Usuario usuario)
        {
            this.form = form;
            this.idSolicitacao = idSolicitacao;
            this.usuarioLogado = usuario;
            InitializeComponent();
        }


        private async Task<string> dowloadNotaFiscal(long idSolicitacao)
        {
            try
            {
                string fileName = (await HttpSolicitacaoCompras.GetSolicitacaoCompraById(idSolicitacao, usuarioLogado.token)).Anexo;
                var file = await HttpSolicitacaoCompras.DownloadNotaFiscal(fileName, usuarioLogado.token);
                saveFileDialog1.Title = "Salvar PDF";
                saveFileDialog1.Filter = "Pdf File|.pdf";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.DefaultExt = ".pdf";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog1.FileName, file);
                }
                return saveFileDialog1.FileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private async void FrmVisualizarNotaFiscal_Load(object sender, EventArgs e)
        {
            string bacon = await dowloadNotaFiscal(idSolicitacao);
            pdfReader.LoadFile(bacon);
        }

        private async void btnReprovar_Click(object sender, EventArgs e)
        {
            Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            FrmModalSolicitacao modal = new FrmModalSolicitacao(ConstantesProjeto.SOLICITACAO_REPROVADA, acompanhamento, usuarioLogado, form);
            modal.Show();
        }

        private async void btnAprovar_Click(object sender, EventArgs e)
        {
            Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            acompanhamento.StatusId = ConstantesProjeto.STATUS_FINALIZADO;

            var acompanhamentoEditado = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
            if (acompanhamentoEditado != null)
            {
                MessageBox.Show("Solicitação de compras finalizada com sucesso!!", "Mensagem de sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.AtualizaGridSolicitacoes();
                this.Dispose();
            }

        }
    }
}
