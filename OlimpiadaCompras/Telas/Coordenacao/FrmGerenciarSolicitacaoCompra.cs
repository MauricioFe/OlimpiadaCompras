using ApiSGCOlimpiada.Models;
using OlimpiadaCompras.Requests;
using OlimpiadaCompras.Telas.Avaliador;
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
    public partial class FrmGerenciarSolicitacaoCompra : Form
    {
        private Usuario usuarioLogado;
        FrmNovaSolicitacao form;
        private long idSolicitacao = 0;

        public FrmGerenciarSolicitacaoCompra(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
        }
        public FrmGerenciarSolicitacaoCompra(Usuario usuario, long idSolicitacao)
        {
            this.usuarioLogado = usuario;
            this.idSolicitacao = idSolicitacao;
            InitializeComponent();
            ToggleHabilitaInputs(false);
           form = new FrmNovaSolicitacao(usuarioLogado);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ToggleHabilitaInputs(true);
        }

        private void btnSolicitarAlteracao_Click(object sender, EventArgs e)
        {
            FrmModalSolicitacao form = new FrmModalSolicitacao(1);
            form.ShowDialog();
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            FrmModalSolicitacao form = new FrmModalSolicitacao(2);
            form.ShowDialog();
        }

        private void btnReprvar_Click(object sender, EventArgs e)
        {
            FrmModalSolicitacao form = new FrmModalSolicitacao(3);
            form.ShowDialog();
        }

        private void ToggleHabilitaInputs(bool estaHabilitado)
        {
            foreach (var item in tabContainer.Controls)
            {

                if (item.GetType() == typeof(TabPage))
                {

                    TabPage tabPage = (TabPage)item;
                    foreach (var tab in tabPage.Controls)
                    {
                        if (tab.GetType() == typeof(DataGridView))
                        {
                            var dgv = (DataGridView)tab;
                            dgv.Enabled = estaHabilitado;
                        }
                        if (tab.GetType() == typeof(Button))
                        {
                            var btn = (Button)tab;
                            btn.Enabled = estaHabilitado;
                        }
                        if (tab.GetType() == typeof(GroupBox))
                        {
                            GroupBox box = (GroupBox)tab;
                            foreach (var group in box.Controls)
                            {
                                if (group.GetType() == typeof(TextBox))
                                {
                                    var txt = (TextBox)group;
                                    txt.Enabled = estaHabilitado;
                                }
                                if (group.GetType() == typeof(ComboBox))
                                {
                                    var combo = (ComboBox)group;
                                    combo.Enabled = estaHabilitado;
                                }
                                if (group.GetType() == typeof(DateTimePicker))
                                {
                                    var dateTimePicker = (DateTimePicker)group;
                                    dateTimePicker.Enabled = estaHabilitado;
                                }
                                if (group.GetType() == typeof(DataGridView))
                                {
                                    var dgv = (DataGridView)group;
                                    dgv.Enabled = estaHabilitado;
                                }
                                if (group.GetType() == typeof(Button))
                                {
                                    var btn = (Button)group;
                                    btn.Enabled = estaHabilitado;
                                }
                            }
                        }
                    }
                }
            }
            if (estaHabilitado)
            {
                button1.Visible = true;
                btnSolicitarAlteracao.Location = new Point(btnSolicitarAlteracao.Location.X + 173, btnSolicitarAlteracao.Location.Y);
            }


        }

        private async void PreencheDadosVisualizacaoSolicitacaoProdutos()
        {
            List<ProdutoPedidoOrcamento> produtosSolicitacao = await HttpProdutoPedidoOrcamentos.GetSolicitacao(idSolicitacao, usuarioLogado.token, "produtoSolicitacao");
            List<ProdutoPedidoOrcamento> orcamentoSolicitacao = await HttpProdutoPedidoOrcamentos.GetSolicitacao(idSolicitacao, usuarioLogado.token, "orcamentoSolicitacao");
            List<ProdutoPedidoOrcamento> orcamentoProdutoSolicitacao = await HttpProdutoPedidoOrcamentos.GetSolicitacao(idSolicitacao, usuarioLogado.token, "produtoOrcamentoSolicitacao");
            dgvProduto.Rows.Clear();

            List<Produto> produtos = new List<Produto>();
            foreach (var item in produtosSolicitacao)
            {
                Produto produto = item.Produto;
                produtos.Add(produto);
            }
            foreach (var produto in produtos)
            {
                int n = dgvProduto.Rows.Add();
                dgvProduto.Rows[n].Cells[0].Value = produto.CodigoProtheus;
                dgvProduto.Rows[n].Cells[1].Value = produto.Grupo.Descricao;
                dgvProduto.Rows[n].Cells[2].Value = produto.Descricao;
                dgvProduto.Rows[n].Cells[3].Value = "Remover";
            }
            int i = 0;
            foreach (var item in orcamentoSolicitacao)
            {
                switch (i)
                {
                    case 0:
                        txtFornecedor1.Text = item.Orcamento.Fornecedor;
                        txtCnpj1.Text = item.Orcamento.Cnpj;
                        dtpDataOrcamento1.Value = item.Orcamento.Data;
                        txtTotalProdutos1.Text = item.Orcamento.TotalProdutos.ToString();
                        txtTotalIPI1.Text = item.Orcamento.TotalIpi.ToString();
                        txtValorFinal1.Text = item.Orcamento.ValorTotal.ToString();
                        cboFormaPagamento1.Text = item.Orcamento.FormaPagamento;
                        txtValorFrete1.Text = item.Orcamento.ValorFrete.ToString();
                        txtAnexarPdf1.Text = item.Orcamento.Anexo;
                        break;
                    case 1:
                        txtFornecedor2.Text = item.Orcamento.Fornecedor;
                        txtCnpj2.Text = item.Orcamento.Cnpj;
                        dtpDataOrcamento2.Value = item.Orcamento.Data;
                        txtTotalProdutos2.Text = item.Orcamento.TotalProdutos.ToString();
                        txtTotalIpi2.Text = item.Orcamento.TotalIpi.ToString();
                        txtValorFinal2.Text = item.Orcamento.ValorTotal.ToString();
                        cboFormaPagamento2.Text = item.Orcamento.FormaPagamento;
                        txtValorFrete2.Text = item.Orcamento.ValorFrete.ToString();
                        txtAnexarPdf2.Text = item.Orcamento.Anexo;
                        break;
                    case 2:
                        txtFornecedor3.Text = item.Orcamento.Fornecedor;
                        txtCnpj3.Text = item.Orcamento.Cnpj;
                        dtpDataOrcamento3.Value = item.Orcamento.Data;
                        txtTotalProdutos3.Text = item.Orcamento.TotalProdutos.ToString();
                        txtTotalIpi3.Text = item.Orcamento.TotalIpi.ToString();
                        txtValorFinal3.Text = item.Orcamento.ValorTotal.ToString();
                        txtValorFrete3.Text = item.Orcamento.ValorFrete.ToString();
                        cboFormaPagamento3.Text = item.Orcamento.FormaPagamento;
                        txtAnexarPdf3.Text = item.Orcamento.Anexo;
                        break;
                    default:
                        break;
                }
                i++;
            }
            i = 0;
            for (int j = 0; j < orcamentoSolicitacao.Count; j++)
            {
                switch (j)
                {
                    case 0:
                        foreach (var item in orcamentoProdutoSolicitacao)
                        {
                            if (item.OrcamentoId == orcamentoSolicitacao[j].OrcamentoId)
                            {
                                int n = dgvProdutoCompra1.Rows.Add();
                                dgvProdutoCompra1.Rows[n].Cells[0].Value = item.Produto.CodigoProtheus;
                                dgvProdutoCompra1.Rows[n].Cells[1].Value = item.Produto.Grupo.Descricao;
                                dgvProdutoCompra1.Rows[n].Cells[2].Value = item.Produto.Descricao;
                                dgvProdutoCompra1.Rows[n].Cells[3].Value = item.Quantidade;
                                dgvProdutoCompra1.Rows[n].Cells[4].Value = item.valor;
                                dgvProdutoCompra1.Rows[n].Cells[5].Value = item.Desconto;
                                dgvProdutoCompra1.Rows[n].Cells[6].Value = item.Ipi;
                                dgvProdutoCompra1.Rows[n].Cells[7].Value = item.Icms;
                                dgvProdutoCompra1.Rows[n].Cells[8].Value = item.Quantidade * (item.valor - (item.valor * (item.Desconto / 100)));
                            }

                        }
                        break;
                    case 1:
                        foreach (var item in orcamentoProdutoSolicitacao)
                        {
                            if (item.OrcamentoId == orcamentoSolicitacao[j].OrcamentoId)
                            {
                                int n = dgvProdutoCompra2.Rows.Add();
                                dgvProdutoCompra2.Rows[n].Cells[0].Value = item.Produto.CodigoProtheus;
                                dgvProdutoCompra2.Rows[n].Cells[1].Value = item.Produto.Grupo.Descricao;
                                dgvProdutoCompra2.Rows[n].Cells[2].Value = item.Produto.Descricao;
                                dgvProdutoCompra2.Rows[n].Cells[3].Value = item.Quantidade;
                                dgvProdutoCompra2.Rows[n].Cells[4].Value = item.valor;
                                dgvProdutoCompra2.Rows[n].Cells[5].Value = item.Desconto;
                                dgvProdutoCompra2.Rows[n].Cells[6].Value = item.Ipi;
                                dgvProdutoCompra2.Rows[n].Cells[7].Value = item.Icms;
                                dgvProdutoCompra2.Rows[n].Cells[8].Value = item.Quantidade * (item.valor - (item.valor * (item.Desconto / 100)));
                            }

                        }
                        break;
                    case 2:
                        foreach (var item in orcamentoProdutoSolicitacao)
                        {
                            if (item.OrcamentoId == orcamentoSolicitacao[j].OrcamentoId)
                            {
                                int n = dgvProdutoCompra3.Rows.Add();
                                dgvProdutoCompra3.Rows[n].Cells[0].Value = item.Produto.CodigoProtheus;
                                dgvProdutoCompra3.Rows[n].Cells[1].Value = item.Produto.Grupo.Descricao;
                                dgvProdutoCompra3.Rows[n].Cells[2].Value = item.Produto.Descricao;
                                dgvProdutoCompra3.Rows[n].Cells[3].Value = item.Quantidade;
                                dgvProdutoCompra3.Rows[n].Cells[4].Value = item.valor;
                                dgvProdutoCompra3.Rows[n].Cells[5].Value = item.Desconto;
                                dgvProdutoCompra3.Rows[n].Cells[6].Value = item.Ipi;
                                dgvProdutoCompra3.Rows[n].Cells[7].Value = item.Icms;
                                dgvProdutoCompra3.Rows[n].Cells[8].Value = item.Quantidade * (item.valor - (item.valor * (item.Desconto / 100)));
                            }

                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private async void PreencheDadosVisualizacaoSolicitacao()
        {
            List<OcupacaoSolicitacaoCompra> ocupacaoSolicitacaoCompras = await HttpSolicitacaoOcupacoes.GetSolicitacao(idSolicitacao, usuarioLogado.token);
            dgvOcupacoes.Rows.Clear();
            if (ocupacaoSolicitacaoCompras.Count > 1)
            {
                List<Ocupacao> ocupacoes = new List<Ocupacao>();
                foreach (var item in ocupacaoSolicitacaoCompras)
                {
                    Ocupacao ocupacao = item.Ocupacao;
                    ocupacoes.Add(ocupacao);

                }
                foreach (var oc in ocupacoes)
                {
                    int n = dgvOcupacoes.Rows.Add();
                    dgvOcupacoes.Rows[n].Cells[0].Value = oc.Numero;
                    dgvOcupacoes.Rows[n].Cells[1].Value = oc.Nome;
                    dgvOcupacoes.Rows[n].Cells[2].Value = "Remover";
                }
                foreach (var inputs in ocupacaoSolicitacaoCompras)
                {
                    cboEscola.SelectedValue = inputs.SolicitacaoCompra.Escola.Id;
                    txtResponsavelEntrega.Text = inputs.SolicitacaoCompra.ResponsavelEntrega;
                    txtJusticativa.Text = inputs.SolicitacaoCompra.Justificativa;
                    dtpDataSolicitacao.Value = inputs.SolicitacaoCompra.Data.Date;
                    cboTipoCompra.SelectedValue = inputs.SolicitacaoCompra.TipoCompraId;
                    txtCep.Text = inputs.SolicitacaoCompra.Escola.Cep;
                    txtLogradouro.Text = inputs.SolicitacaoCompra.Escola.Logradouro;
                    txtBairro.Text = inputs.SolicitacaoCompra.Escola.Bairro;
                    txtNumero.Text = inputs.SolicitacaoCompra.Escola.Numero;
                    txtCidade.Text = inputs.SolicitacaoCompra.Escola.Cidade;
                    txtEstado.Text = inputs.SolicitacaoCompra.Escola.Estado;
                    break;
                }
            }
            else
            {
                foreach (var item in ocupacaoSolicitacaoCompras)
                {
                    cboEscola.SelectedValue = item.SolicitacaoCompra.Escola.Id;
                    txtResponsavelEntrega.Text = item.SolicitacaoCompra.ResponsavelEntrega;
                    txtJusticativa.Text = item.SolicitacaoCompra.Justificativa;
                    dtpDataSolicitacao.Value = item.SolicitacaoCompra.Data;
                    cboTipoCompra.SelectedValue = item.SolicitacaoCompra.TipoCompraId;
                    txtCep.Text = item.SolicitacaoCompra.Escola.Cep;
                    txtLogradouro.Text = item.SolicitacaoCompra.Escola.Logradouro;
                    txtBairro.Text = item.SolicitacaoCompra.Escola.Bairro;
                    txtNumero.Text = item.SolicitacaoCompra.Escola.Numero;
                    txtCidade.Text = item.SolicitacaoCompra.Escola.Cidade;
                    txtEstado.Text = item.SolicitacaoCompra.Escola.Estado;
                    int n = dgvOcupacoes.Rows.Add();
                    dgvOcupacoes.Rows[n].Cells[0].Value = item.Ocupacao.Numero;
                    dgvOcupacoes.Rows[n].Cells[1].Value = item.Ocupacao.Nome;
                    dgvOcupacoes.Rows[n].Cells[2].Value = "Remover";

                }
            }
        }

        private void FrmGerenciarSolicitacaoCompra_Load(object sender, EventArgs e)
        {


            form.PreencheCombobox(cboEscola, "Nome", "Id");
            form.PreencheCombobox(cboOcupacao, "Nome", "Id");
            form.PreencheCombobox(cboTipoCompra, "Descricao", "Id");
            form.PreencheDadosEscola(1);
            if (idSolicitacao > 0)
            {
                PreencheDadosVisualizacaoSolicitacao();
                PreencheDadosVisualizacaoSolicitacaoProdutos();
            }
        }
        private void cboEscola_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long escolaId = (long)((ComboBox)sender).SelectedValue;
            form.PreencheDadosEscola(escolaId);
        }
    }
}
