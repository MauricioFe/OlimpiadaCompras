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
    public partial class FrmTodasSolicitacoes : Form
    {
        private Usuario usuarioLogado;

        public FrmTodasSolicitacoes(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            AtualizaGridSolicitacoesUsuario();
        }
        public async void AtualizaGridSolicitacoesUsuario()
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
            acompanhamentos = await HttpAcompanhamento.GetSolicitacaoAcompanhamento(usuarioLogado.token);
            dgvSolicitacoes.Rows.Clear();
            foreach (var item in acompanhamentos.Where(a => a.StatusId != 4))
            {
                int n = dgvSolicitacoes.Rows.Add();
                dgvSolicitacoes.Rows[n].Cells["colMinhaIdSolicitacao"].Value = item.SolicitacaoCompra.Id;
                dgvSolicitacoes.Rows[n].Cells["colMinhaData"].Value = item.SolicitacaoCompra.Data.ToString("dd/MM/yyyy");
                dgvSolicitacoes.Rows[n].Cells["colMinhaJustificativa"].Value = item.SolicitacaoCompra.Justificativa;
                dgvSolicitacoes.Rows[n].Cells["colMinhaStatus"].Value = item.Status.Descricao;
                dgvSolicitacoes.Rows[n].Cells["colMinhaStatusID"].Value = item.Status.Id;
            }
        }
    }
}
