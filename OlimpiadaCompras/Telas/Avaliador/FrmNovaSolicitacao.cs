using ApiSGCOlimpiada.Models;
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
    public partial class FrmNovaSolicitacao : Form
    {
        private Usuario usuarioLogado;

        public FrmNovaSolicitacao(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
        }

        public async void PreencheCombobox(ComboBox cbo, string displayMember, string valueMember)
        {
            if (cbo.Name == cboEscola.Name)
            {
                List<Escola> escolas = await HttpEscolas.GetAllEscolas(usuarioLogado.token);
                cbo.DataSource = escolas;
            }
            else if (cbo.Name == cboOcupacao.Name)
            {
                List<Ocupacao> ocupacoes = await HttpOcupacaos.GetAllOcupacaos(usuarioLogado.token);
                cbo.DataSource = ocupacoes;
            }
            else
            {
                List<TipoCompra> tipoCompras = await HttpTipoCompras.GetAllTipoCompras(usuarioLogado.token);
                cbo.DataSource = tipoCompras;
            }
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void FrmNovaSolicitacao_Load(object sender, EventArgs e)
        {

            PreencheCombobox(cboEscola, "Nome", "Id");
            PreencheCombobox(cboOcupacao, "Nome", "Id");
            PreencheCombobox(cboTipoCompra, "Descricao", "Id");
            dtpDataSolicitacao.MinDate = DateTime.Now;
            
            PreencheDadosEscola(1);

        }

        private void cboEscola_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long escolaId = (long)((ComboBox)sender).SelectedValue;
            PreencheDadosEscola(escolaId);
        }

        private async void PreencheDadosEscola(long escolaId)
        {
            Escola escola = await HttpEscolas.GetEscolaById(escolaId, usuarioLogado.token);
            txtCep.Text = escola.Cep;
            txtBairro.Text = escola.Bairro;
            txtCidade.Text = escola.Cidade;
            txtEstado.Text = escola.Estado;
            txtNumero.Text = escola.Numero;
            txtLogradouro.Text = escola.Logradouro;
        }

        private async void btnAdicionarOcupacao_Click(object sender, EventArgs e)
        {
            long ocupacaoId = (long)cboOcupacao.SelectedValue;
            Ocupacao ocupacao = await HttpOcupacaos.GetOcupacaoById(ocupacaoId, usuarioLogado.token);
            dgvOcupacoes.Rows.Add(ocupacao.Numero, ocupacao.Nome, "Remove", ocupacao.Id);
        }

        private void dgvOcupacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOcupacoes.Columns[e.ColumnIndex].Name == "colRemoveOcupacao")
            {
                if (MessageBox.Show("Tem certeza que deseja remover esse registro da lista?", "Remover registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvOcupacoes.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            //lógica para salvar a solicitação, depois a ocupação_solicitações
            CreateSolicitacao();
        }

        private async void CreateSolicitacao()
        {
            if (!string.IsNullOrEmpty(txtResponsavelEntrega.Text) && !string.IsNullOrEmpty(txtJusticativa.Text))
            {
                SolicitacaoCompra solicitacao = new SolicitacaoCompra();
                solicitacao.ResponsavelEntrega = txtResponsavelEntrega.Text;
                solicitacao.Data = dtpDataSolicitacao.Value;
                solicitacao.EscolaId = (long)cboEscola.SelectedValue;
                solicitacao.TipoCompraId = (long)cboTipoCompra.SelectedValue;
                solicitacao.Justificativa = txtJusticativa.Text;
                if (dgvOcupacoes.Rows.Count >= 1)
                {

                    var solicitacaoCriada = await HttpSolicitacaoCompras.Create(solicitacao, usuarioLogado.token);
                    if (solicitacaoCriada == null)
                    {
                        MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                    }
                    else
                    {
                        List<SolicitacaoCompra> solicitacoes = await HttpSolicitacaoCompras.GetAll(usuarioLogado.token);
                        long solicitacaoId = solicitacoes.Last().Id;
                        for (int i = 0; i < dgvOcupacoes.Rows.Count; i++)
                        {
                            long ocupacaoId = (long)dgvOcupacoes.Rows[i].Cells["colIdOcupacao"].Value;
                            OcupacaoSolicitacaoCompra ocupacaoSolicitacao = new OcupacaoSolicitacaoCompra();
                            ocupacaoSolicitacao.OcupacaoId = ocupacaoId;
                            ocupacaoSolicitacao.SolicitacaoId = solicitacaoId;
                            await HttpSolicitacaoOcupacoes.Create(ocupacaoSolicitacao, usuarioLogado.token);
                        }
                        tabContainer.SelectTab("produto");
                        ((Control)tabContainer.TabPages["dadosGerais"]).Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Adicione ao menos uma ocupação na lista");
                }

            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private async void txtCodigoProtheusProduto_TextChanged(object sender, EventArgs e)
        {
            Produto produto = HttpProdutos.GetProdutosByCodigoProtheus(((TextBox)sender).Text, usuarioLogado.token);
        }
    }
}
