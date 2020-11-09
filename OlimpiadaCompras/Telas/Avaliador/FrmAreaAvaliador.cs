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
        public FrmAreaAvaliador()
        {
            InitializeComponent();
        }

        private void FrmAreaAvaliador_Load(object sender, EventArgs e)
        {
            dgvSolicitacoesPendentes.Rows.Add(0913154, "Descrição do item", 2, "Curso", "Pendente Nota fiscal");
            dgvSolicitacoesUsuario.Rows.Add(0913154, "Descrição do item", 2, "Curso", "Pendente Nota fiscal");
        }

        private void dgvSolicitacoesPendentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSolicitacoesPendentes.Columns[e.ColumnIndex].Name == "Status")
            {
                FrmAnexarNotaFiscal form = new FrmAnexarNotaFiscal();
                form.ShowDialog();
            }
        }

        private void dgvSolicitacoesUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmNovaSolicitacao form = new FrmNovaSolicitacao();
            form.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmNovaSolicitacao form = new FrmNovaSolicitacao();
            form.ShowDialog();
        }

        private void btnNovaSolicitacao_Click(object sender, EventArgs e)
        {
            FrmNovaSolicitacao frm = new FrmNovaSolicitacao();
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmEditarUsuarios form = new FrmEditarUsuarios();
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
            FrmTodasSolicitacoes form = new FrmTodasSolicitacoes();
            form.ShowDialog();
        }
    }
}
