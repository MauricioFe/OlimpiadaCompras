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
    public partial class FrmEmailAutorizacao : Form
    {
        private EmailModel data;
        private Usuario usuarioLogado;
        private FrmAreaCoordenacao frmAreaCoordenacao;
        private readonly long idSolicitacao;
        private readonly FrmPrecadastroEmail frmPrecadastroEmail;

        public FrmEmailAutorizacao(EmailModel data, Usuario usuarioLogado, FrmAreaCoordenacao frmAreaCoordenacao, long idSolicitacao, FrmPrecadastroEmail frmPrecadastroEmail)
        {
            this.data = data;
            this.usuarioLogado = usuarioLogado;
            this.frmAreaCoordenacao = frmAreaCoordenacao;
            this.idSolicitacao = idSolicitacao;
            this.frmPrecadastroEmail = frmPrecadastroEmail;
            InitializeComponent();
        }

        private async void FrmEmailAutorizacao_Load(object sender, EventArgs e)
        {
            BloqueiaCampos();
            this.Cursor = Cursors.WaitCursor;
            string bacon = await DowloadEmail(idSolicitacao);
            pdfReader.LoadFile(bacon);
            DesbloqueiaCampos();
            this.Cursor = Cursors.Arrow;
        }
        private async Task<string> DowloadEmail(long idSolicitacao)
        {
            try
            {
                var file = await HttpEmail.DownloadEmail(data, idSolicitacao, usuarioLogado.token);
                string fileName = "email" + DateTime.Now.ToString("yyyyMMddHHmm");
                string fileSavePcName = $@"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";
                File.WriteAllBytes(fileSavePcName, file);
                return fileSavePcName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private void btnReprovar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnAprovar_Click(object sender, EventArgs e)
        {
            Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            BloqueiaCampos();
            this.Cursor = Cursors.WaitCursor;
            if (await HttpEmail.EnviarEmail(data, idSolicitacao, usuarioLogado.token))
            {
                acompanhamento.StatusId = ConstantesProjeto.STATUS_ANEXAR_NF;
                var acompanhamentoUpdate = await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                DesbloqueiaCampos();
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Envio de e-mail feito com sucesso");
                if (acompanhamentoUpdate != null)
                {
                    this.Dispose();
                    frmPrecadastroEmail.Dispose();
                    frmAreaCoordenacao.AtualizaGridSolicitacoes();
                }
            }
            else
            {
                MessageBox.Show("Erro ao enviar e-mail");
                this.Dispose();
            }

        }

        private void BloqueiaCampos()
        {
            foreach (var item in this.Controls)
            {
                ((Control)item).Enabled = false;
            }
        }
        private void DesbloqueiaCampos()
        {
            foreach (var item in this.Controls)
            {
                ((Control)item).Enabled = true;
            }
        }
    }
}
