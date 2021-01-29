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
    public partial class FrmGerenciarSolicitacaoCompra : Form
    {
        private Usuario usuarioLogado;
        private long idSolicitacao = 0;
        long idProduto;
        long idGrupo;
        List<ProdutoSolicitacao> produtosCompras = new List<ProdutoSolicitacao>();
        List<OcupacaoSolicitacaoCompra> ocupacoesSolicitacaoEditList = new List<OcupacaoSolicitacaoCompra>();
        List<double> totalIpiList = new List<double>();
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
        }
        private async void PreencheDadosSolicitacao()
        {
            List<OcupacaoSolicitacaoCompra> ocupacaoSolicitacaoCompras = await HttpSolicitacaoOcupacoes.GetSolicitacao(idSolicitacao, usuarioLogado.token);
            dgvOcupacoes.Rows.Clear();
            dgvProduto.Rows.Clear();
            foreach (var item in ocupacaoSolicitacaoCompras)
            {
                Ocupacao ocupacao = item.Ocupacao;
                int n = dgvOcupacoes.Rows.Add();
                dgvOcupacoes.Rows[n].Cells[0].Value = ocupacao.Numero;
                dgvOcupacoes.Rows[n].Cells[1].Value = ocupacao.Nome;
                dgvOcupacoes.Rows[n].Cells["colIdOcupacao"].Value = ocupacao.Id;
                dgvOcupacoes.Rows[n].Cells[2].Value = "Remover";
                OcupacaoSolicitacaoCompra ocupacaoSolicitacaoCompra = new OcupacaoSolicitacaoCompra();
                ocupacaoSolicitacaoCompra.OcupacaoId = ocupacao.Id;
                ocupacaoSolicitacaoCompra.SolicitacaoId = idSolicitacao;
                ocupacoesSolicitacaoEditList.Add(ocupacaoSolicitacaoCompra);

            }
            List<ProdutoSolicitacao> produtoSolicitacoes = await HttpProdutoSolicitacoes.GetByIdSolicitacao(idSolicitacao, usuarioLogado.token);
            foreach (var inputs in produtoSolicitacoes)
            {
                cboEscola.SelectedValue = inputs.SolicitacaoCompra.Escola.Id;
                txtResponsavelEntrega.Text = inputs.SolicitacaoCompra.ResponsavelEntrega;
                txtJusticativa.Text = inputs.SolicitacaoCompra.Justificativa;
                dtpDataSolicitacao.Value = inputs.SolicitacaoCompra.Data;
                cboTipoCompra.SelectedValue = inputs.SolicitacaoCompra.TipoCompraId;
                txtCep.Text = inputs.SolicitacaoCompra.Escola.Cep;
                txtLogradouro.Text = inputs.SolicitacaoCompra.Escola.Logradouro;
                txtBairro.Text = inputs.SolicitacaoCompra.Escola.Bairro;
                txtNumero.Text = inputs.SolicitacaoCompra.Escola.Numero;
                txtCidade.Text = inputs.SolicitacaoCompra.Escola.Cidade;
                txtEstado.Text = inputs.SolicitacaoCompra.Escola.Estado;
                txtIdSolicitacao.Text = inputs.SolicitacaoCompra.Id.ToString();
                int n = dgvProduto.Rows.Add();
                dgvProduto.Rows[n].Cells[0].Value = inputs.Produto.CodigoProtheus;
                dgvProduto.Rows[n].Cells[1].Value = inputs.Produto.Grupo.Descricao;
                dgvProduto.Rows[n].Cells[2].Value = inputs.Produto.Descricao;
                dgvProduto.Rows[n].Cells[3].Value = "Remover";
                dgvProduto.Rows[n].Cells[4].Value = inputs.Produto.Id;
                dgvProduto.Rows[n].Cells[5].Value = inputs.Produto.Grupo.Id;
                dgvProduto.Rows[n].Cells[6].Value = inputs.Id;
            }
            List<ProdutoPedidoOrcamento> produtoPedidoOrcamentos = await HttpProdutoPedidoOrcamentos.GetByIdSolicitacao(idSolicitacao, usuarioLogado.token);
            List<Orcamento> orcamentos = await HttpOrcamentos.GetByIdSolicitacao(idSolicitacao, usuarioLogado.token);
            for (int i = 0; i < orcamentos.Count; i++)
            {
                Orcamento orcamento = orcamentos[i];
                foreach (var item in produtoPedidoOrcamentos)
                {
                    if (orcamento.Id == item.Orcamento.Id)
                    {
                        int row = ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows.Add();
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[0].Value = item.ProdutoSolicitacao.Produto.CodigoProtheus;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[1].Value = item.ProdutoSolicitacao.Produto.Grupo.Descricao;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[2].Value = item.ProdutoSolicitacao.Produto.Descricao;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[3].Value = item.Quantidade;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[4].Value = item.valor;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[5].Value = item.Desconto;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[6].Value = item.Ipi;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[7].Value = item.Icms;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[8].Value = item.Quantidade * (item.valor - (item.valor * (item.Desconto / 100)));
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[10].Value = item.ProdutoSolicitacao.Id;
                        ((TextBox)tabContainer.Controls.Find($"txtFornecedor{i + 1}", true)[0]).Text = orcamento.Fornecedor;
                        ((TextBox)tabContainer.Controls.Find($"txtCnpj{i + 1}", true)[0]).Text = orcamento.Cnpj;
                        ((DateTimePicker)tabContainer.Controls.Find($"dtpDataOrcamento{i + 1}", true)[0]).Value = orcamento.Data;
                        ((TextBox)tabContainer.Controls.Find($"txtTotalProdutos{i + 1}", true)[0]).Text = orcamento.TotalProdutos.ToString();
                        ((TextBox)tabContainer.Controls.Find($"txtTotalIPI{i + 1}", true)[0]).Text = orcamento.TotalIpi.ToString();
                        ((TextBox)tabContainer.Controls.Find($"txtValorFinal{i + 1}", true)[0]).Text = orcamento.ValorTotal.ToString();
                        if (orcamento.FormaPagamento == "Crédito em conta")
                        {
                            ((ComboBox)tabContainer.Controls.Find($"cboFormaPagamento{i + 1}", true)[0]).SelectedIndex = 0;
                        }
                        else
                        {
                            ((ComboBox)tabContainer.Controls.Find($"cboFormaPagamento{i + 1}", true)[0]).SelectedIndex = 1;
                        }
                        ((TextBox)tabContainer.Controls.Find($"txtValorFrete{i + 1}", true)[0]).Text = orcamento.ValorFrete.ToString();
                        ((TextBox)tabContainer.Controls.Find($"txtAnexarPdf{i + 1}", true)[0]).Text = orcamento.Anexo;
                        ((TextBox)tabContainer.Controls.Find($"txtIdOrcamento{i + 1}", true)[0]).Text = orcamento.Id.ToString();
                    }
                }

            }
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
        private async void btnSolicitarAlteracao_Click(object sender, EventArgs e)
        {
            Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            FrmModalSolicitacao form = new FrmModalSolicitacao(ConstantesProjeto.SOLICITAR_ALTERACAO, acompanhamento, usuarioLogado);
            form.ShowDialog();
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            FrmPrecadastroEmail form = new FrmPrecadastroEmail(usuarioLogado, idSolicitacao);
            form.ShowDialog();
            this.Dispose();
        }

        private async void btnReprovar_Click(object sender, EventArgs e)
        {

            Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            FrmModalSolicitacao form = new FrmModalSolicitacao(ConstantesProjeto.SOLICITACAO_REPROVADA, acompanhamento, usuarioLogado);
            form.ShowDialog();
        }
    }
}
