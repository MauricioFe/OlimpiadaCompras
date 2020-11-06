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
        public FrmModalSolicitacao(int acao)
        {
            InitializeComponent();
            this.acao = acao;
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (acao == SOLICITACAO_APROVADA)
            {
                FrmEmailAutorizacao form = new FrmEmailAutorizacao();
                form.ShowDialog();
            }
            else if (acao == SOLICITACAO_REPROVADA)
            {
                this.Dispose();
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
