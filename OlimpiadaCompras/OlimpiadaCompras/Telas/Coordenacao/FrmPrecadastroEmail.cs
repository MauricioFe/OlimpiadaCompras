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

namespace OlimpiadaCompras.Telas.Coordenacao
{
    public partial class FrmPrecadastroEmail : Form
    {
        private Usuario usuarioLogado;
        private long idSolicitacao;
        private FrmAreaCoordenacao frmAreaCoordenacao;
        public FrmPrecadastroEmail(Usuario usuario, long idSolicitacao, FrmAreaCoordenacao frmAreaCoordenacao)
        {
            this.usuarioLogado = usuario;
            this.idSolicitacao = idSolicitacao;
            this.frmAreaCoordenacao = frmAreaCoordenacao;
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificaCamposVazios())
            {
                EmailModel data = new EmailModel();
                data.CentroResponsabilidade = txtCentroResponsabilidade.Text;
                data.CodUnidadeOrganizacional = txtCodUnidadeOrganizacional.Text;
                data.projeto = txtProjeto.Text;
                data.ContaContabil = txtContaContabil.Text;
                FrmEmailAutorizacao form = new FrmEmailAutorizacao(data, usuarioLogado, frmAreaCoordenacao, idSolicitacao, this);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
