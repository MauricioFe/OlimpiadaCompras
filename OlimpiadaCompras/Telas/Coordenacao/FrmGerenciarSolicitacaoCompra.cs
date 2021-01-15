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
        public async void PreencheDadosEscola(long escolaId)
        {
            Escola escola = await HttpEscolas.GetEscolaById(escolaId, usuarioLogado.token);
            txtCep.Text = escola.Cep;
            txtBairro.Text = escola.Bairro;
            txtCidade.Text = escola.Cidade;
            txtEstado.Text = escola.Estado;
            txtNumero.Text = escola.Numero;
            txtLogradouro.Text = escola.Logradouro;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            ToggleHabilitaInputs(true);
        }

        private void btnSolicitarAlteracao_Click(object sender, EventArgs e)
        {
            //FrmModalSolicitacao form = new FrmModalSolicitacao(1);
            //form.ShowDialog();
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            //FrmModalSolicitacao form = new FrmModalSolicitacao(2);
            //form.ShowDialog();
        }

        private void btnReprvar_Click(object sender, EventArgs e)
        {
            //FrmModalSolicitacao form = new FrmModalSolicitacao(3);
            //form.ShowDialog();
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

            foreach (var item in produtosSolicitacao)
            {
                Produto produto = item.Produto;
                int n = dgvProduto.Rows.Add();
                dgvProduto.Rows[n].Cells[0].Value = produto.CodigoProtheus;
                dgvProduto.Rows[n].Cells[1].Value = produto.Grupo.Descricao;
                dgvProduto.Rows[n].Cells[2].Value = produto.Descricao;
                dgvProduto.Rows[n].Cells[3].Value = "Remover";
            }
            int i = 1;
            foreach (var item in orcamentoSolicitacao)
            {
                ((TextBox)tabContainer.Controls.Find($"txtFornecedor{i}", true)[0]).Text = item.Orcamento.Fornecedor;
                ((TextBox)tabContainer.Controls.Find($"txtCnpj{i}", true)[0]).Text = item.Orcamento.Cnpj;
                ((DateTimePicker)tabContainer.Controls.Find($"dtpDataOrcamento{i}", true)[0]).Value = item.Orcamento.Data;
                ((TextBox)tabContainer.Controls.Find($"txtTotalProdutos{i}", true)[0]).Text = item.Orcamento.TotalProdutos.ToString();
                ((TextBox)tabContainer.Controls.Find($"txtTotalIPI{i}", true)[0]).Text = item.Orcamento.TotalIpi.ToString();
                ((TextBox)tabContainer.Controls.Find($"txtValorFinal{i}", true)[0]).Text = item.Orcamento.ValorTotal.ToString();
                ((ComboBox)tabContainer.Controls.Find($"cboFormaPagamento{i}", true)[0]).Text = item.Orcamento.FormaPagamento;
                ((TextBox)tabContainer.Controls.Find($"txtValorFrete{i}", true)[0]).Text = item.Orcamento.ValorFrete.ToString();
                ((TextBox)tabContainer.Controls.Find($"txtAnexarPdf{i}", true)[0]).Text = item.Orcamento.Anexo;
                i++;
            }
            i = 0;
            int row = 0;
            for (int j = 0; j < orcamentoSolicitacao.Count; j++)
            {
                foreach (var item in orcamentoProdutoSolicitacao)
                {
                    if (item.OrcamentoId == orcamentoSolicitacao[j].OrcamentoId)
                    {
                        row = ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows.Add();
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[0].Value = item.Produto.CodigoProtheus;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[1].Value = item.Produto.Grupo.Descricao;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[2].Value = item.Produto.Descricao;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[3].Value = item.Quantidade;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[4].Value = item.valor;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[5].Value = item.Desconto;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[6].Value = item.Ipi;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[7].Value = item.Icms;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{j + 1}", true)[0]).Rows[row].Cells[8].Value = item.Quantidade * (item.valor - (item.valor * (item.Desconto / 100)));
                    }
                }
            }
        }

        private async void PreencheDadosVisualizacaoSolicitacao()
        {
            List<OcupacaoSolicitacaoCompra> ocupacaoSolicitacaoCompras = await HttpSolicitacaoOcupacoes.GetSolicitacao(idSolicitacao, usuarioLogado.token);
            dgvOcupacoes.Rows.Clear();
            foreach (var item in ocupacaoSolicitacaoCompras)
            {
                Ocupacao ocupacao = item.Ocupacao;
                int n = dgvOcupacoes.Rows.Add();
                dgvOcupacoes.Rows[n].Cells[0].Value = ocupacao.Numero;
                dgvOcupacoes.Rows[n].Cells[1].Value = ocupacao.Nome;
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

        private void FrmGerenciarSolicitacaoCompra_Load(object sender, EventArgs e)
        {


            PreencheCombobox(cboEscola, "Nome", "Id");
            PreencheCombobox(cboOcupacao, "Nome", "Id");
            PreencheCombobox(cboTipoCompra, "Descricao", "Id");
            PreencheDadosEscola(1);
            if (idSolicitacao > 0)
            {
                PreencheDadosVisualizacaoSolicitacao();
                PreencheDadosVisualizacaoSolicitacaoProdutos();
            }
        }
        private void cboEscola_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long escolaId = (long)((ComboBox)sender).SelectedValue;
            PreencheDadosEscola(escolaId);
        }
    }
}
