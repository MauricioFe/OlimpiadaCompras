using OlimpiadaCompras.Models;
using OlimpiadaCompras.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Telas.Avaliador
{
    public partial class FrmNovaSolicitacao : Form
    {
        private Usuario usuarioLogado;
        long idProduto = 0;
        long idSolicitacao = 0;
        long idGrupo = 0;
        List<OcupacaoSolicitacaoCompra> ocupacoesSolicitacaoEditList = new List<OcupacaoSolicitacaoCompra>();
        List<ProdutoSolicitacao> produtosCompras = new List<ProdutoSolicitacao>();
        List<decimal> totalIpiList = new List<decimal>();
        int acao;
        private FrmAreaAvaliador frmAreaAvaliador;
        bool orcamentoCadastrado1 = false;
        bool orcamentoCadastrado2 = false;
        bool orcamentoCadastrado3 = false;
        public FrmNovaSolicitacao(Usuario usuario, FrmAreaAvaliador frmAreaAvaliador)
        {
            this.usuarioLogado = usuario;
            this.frmAreaAvaliador = frmAreaAvaliador;
            InitializeComponent();
        }
        public FrmNovaSolicitacao(Usuario usuario, long idSolicitacao, int acao, FrmAreaAvaliador frmAreaAvaliador)
        {
            this.usuarioLogado = usuario;
            this.idSolicitacao = idSolicitacao;
            this.acao = acao;
            this.frmAreaAvaliador = frmAreaAvaliador;
            InitializeComponent();
            VerificaObservacoes(idSolicitacao);
        }

        private async void VerificaObservacoes(long idSolicitacao)
        {
            Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            if (!string.IsNullOrEmpty(acompanhamento.Observacao))
            {
                MessageBox.Show(acompanhamento.Observacao, "Observação para continuar com o processo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmNovaSolicitacao_Load(object sender, EventArgs e)
        {
            PreencheCombobox(cboEscola, "Nome", "Id");
            PreencheCombobox(cboOcupacao, "Nome", "Id");
            PreencheCombobox(cboTipoCompra, "Descricao", "Id");
            PreencheDadosEscola(1);
            if (idSolicitacao > 0 && acao == ConstantesProjeto.VISUALIZAR)
            {
                PreencheDadosSolicitacao();
                DisabilitaInputs();
                btnVisualizarArquivo1.Visible = true;
                btnVisualizarArquivo1.Enabled = true;
                btnVisualizarArquivo2.Visible = true;
                btnVisualizarArquivo2.Enabled = true;
                btnVisualizarArquivo3.Visible = true;
                btnVisualizarArquivo3.Enabled = true;
            }
            else if (idSolicitacao > 0 && acao == ConstantesProjeto.SALVAR)
            {
                PreencheDadosSolicitacao();
            }
            else if (idSolicitacao > 0 && acao == ConstantesProjeto.EDITAR)
            {
                PreencheDadosSolicitacao();
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
                txtIdSolicitacao.Text = item.SolicitacaoCompra.Id.ToString();
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
                        if (i == 0)
                        {
                            orcamentoCadastrado1 = true;
                        }
                        if (i == 1)
                        {
                            orcamentoCadastrado2 = true;
                        }
                        if (i == 2)
                        {
                            orcamentoCadastrado3 = true;
                        }
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
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[11].Value = item.Id;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[9].Value = "Remover";
                        ((TextBox)tabContainer.Controls.Find($"txtFornecedor{i + 1}", true)[0]).Text = orcamento.Fornecedor;
                        ((TextBox)tabContainer.Controls.Find($"txtCnpj{i + 1}", true)[0]).Text = orcamento.Cnpj;
                        ((DateTimePicker)tabContainer.Controls.Find($"dtpDataOrcamento{i + 1}", true)[0]).Value = orcamento.Data;
                        ((TextBox)tabContainer.Controls.Find($"txtTotalProdutos{i + 1}", true)[0]).Text = orcamento.TotalProdutos.ToString("F2");
                        ((TextBox)tabContainer.Controls.Find($"txtTotalIPI{i + 1}", true)[0]).Text = orcamento.TotalIpi.ToString("F2");
                        ((TextBox)tabContainer.Controls.Find($"txtValorFinal{i + 1}", true)[0]).Text = orcamento.ValorTotal.ToString("F2");
                        ((TextBox)tabContainer.Controls.Find($"txtValorFrete{i + 1}", true)[0]).Text = orcamento.ValorFrete.ToString("F2");
                        ((TextBox)tabContainer.Controls.Find($"txtAnexarPdf{i + 1}", true)[0]).Text = orcamento.Anexo;
                        ((TextBox)tabContainer.Controls.Find($"txtIdOrcamento{i + 1}", true)[0]).Text = orcamento.Id.ToString();
                        if (orcamento.FormaPagamento == "Crédito em conta")
                        {
                            ((ComboBox)tabContainer.Controls.Find($"cboFormaPagamento{i + 1}", true)[0]).SelectedIndex = 0;
                        }
                        else
                        {
                            ((ComboBox)tabContainer.Controls.Find($"cboFormaPagamento{i + 1}", true)[0]).SelectedIndex = 1;
                        }
                    }
                }
            }
            PreencheValoresCalculados(dgvProdutoCompra1, totalIpiList, txtTotalProdutos1, txtTotalIpi1, txtValorFinal1);
            PreencheValoresCalculados(dgvProdutoCompra2, totalIpiList, txtTotalProdutos2, txtTotalIpi2, txtValorFinal2);
            PreencheValoresCalculados(dgvProdutoCompra3, totalIpiList, txtTotalProdutos3, txtTotalIpi3, txtValorFinal3);
        }
        private void DisabilitaInputs()
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
                            dgv.Enabled = false;
                        }
                        if (tab.GetType() == typeof(Button))
                        {
                            var btn = (Button)tab;
                            btn.Enabled = false;
                        }
                        if (tab.GetType() == typeof(GroupBox))
                        {
                            GroupBox box = (GroupBox)tab;
                            foreach (var group in box.Controls)
                            {
                                if (group.GetType() == typeof(TextBox))
                                {
                                    var txt = (TextBox)group;
                                    txt.Enabled = false;
                                }
                                if (group.GetType() == typeof(ComboBox))
                                {
                                    var combo = (ComboBox)group;
                                    combo.Enabled = false;
                                }
                                if (group.GetType() == typeof(DateTimePicker))
                                {
                                    var dateTimePicker = (DateTimePicker)group;
                                    dateTimePicker.Enabled = false;
                                }
                                if (group.GetType() == typeof(DataGridView))
                                {
                                    var dgv = (DataGridView)group;
                                    dgv.Enabled = false;
                                }
                                if (group.GetType() == typeof(Button))
                                {
                                    var btn = (Button)group;
                                    btn.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
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
        private async void SalvarSolicitacao(int acao)
        {
            if (!string.IsNullOrEmpty(txtResponsavelEntrega.Text) && !string.IsNullOrEmpty(txtJusticativa.Text))
            {
                SolicitacaoCompra solicitacao = new SolicitacaoCompra();
                solicitacao.ResponsavelEntrega = txtResponsavelEntrega.Text;
                solicitacao.Data = dtpDataSolicitacao.Value;
                solicitacao.EscolaId = Convert.ToInt64(cboEscola.SelectedValue);
                solicitacao.TipoCompraId = Convert.ToInt64(cboTipoCompra.SelectedValue);
                solicitacao.Justificativa = txtJusticativa.Text;
                if (dgvOcupacoes.Rows.Count >= 1)
                {

                    if (acao == ConstantesProjeto.SALVAR && idSolicitacao == 0)
                    {
                        var solicitacaoCriada = await HttpSolicitacaoCompras.Create(solicitacao, usuarioLogado.token);
                        if (solicitacaoCriada == null)
                        {
                            MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                        }
                        else
                        {
                            var solicitacaoComprasList = await HttpSolicitacaoCompras.GetAll(usuarioLogado.token);
                            idSolicitacao = solicitacaoComprasList.Last().Id;
                            for (int i = 0; i < dgvOcupacoes.Rows.Count; i++)
                            {
                                long ocupacaoId = (long)dgvOcupacoes.Rows[i].Cells["colIdOcupacao"].Value;
                                OcupacaoSolicitacaoCompra ocupacaoSolicitacao = new OcupacaoSolicitacaoCompra();
                                ocupacaoSolicitacao.OcupacaoId = ocupacaoId;
                                ocupacaoSolicitacao.SolicitacaoId = idSolicitacao;
                                await HttpSolicitacaoOcupacoes.Create(ocupacaoSolicitacao, usuarioLogado.token);
                            }
                            await CadastrarAcompanhamento();
                            tabContainer.SelectTab("produto");
                            ((Control)tabContainer.TabPages["dadosGerais"]).Enabled = false;
                        }
                    }
                    else
                    {
                        var solicitacaoEditada = await HttpSolicitacaoCompras.Update(solicitacao, Convert.ToInt64(txtIdSolicitacao.Text), usuarioLogado.token);
                        if (solicitacaoEditada == null)
                        {
                            MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                        }
                        else
                        {

                            for (int i = 0; i < dgvOcupacoes.Rows.Count; i++)
                            {
                                long ocupacaoId = 0;
                                if (ocupacoesSolicitacaoEditList.Count > i)
                                    ocupacaoId = ocupacoesSolicitacaoEditList[i].OcupacaoId;
                                else
                                    ocupacaoId = (long)dgvOcupacoes.Rows[i].Cells["colIdOcupacao"].Value;
                                long solicitacaoId = Convert.ToInt64(txtIdSolicitacao.Text);
                                OcupacaoSolicitacaoCompra ocupacaoSolicitacao = new OcupacaoSolicitacaoCompra();
                                ocupacaoSolicitacao.OcupacaoId = (long)dgvOcupacoes.Rows[i].Cells["colIdOcupacao"].Value;
                                ocupacaoSolicitacao.SolicitacaoId = solicitacaoId;
                                var ocupacaoSolicitacaoEditada = await HttpSolicitacaoOcupacoes.Update(ocupacaoSolicitacao, ocupacaoId, solicitacaoId, usuarioLogado.token);
                                if (ocupacaoSolicitacaoEditada == null)
                                {
                                    await HttpSolicitacaoOcupacoes.Create(ocupacaoSolicitacao, usuarioLogado.token);
                                }
                            }
                            tabContainer.SelectTab("produto");
                            ((Control)tabContainer.TabPages["dadosGerais"]).Enabled = false;
                        }
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
        private async Task<Acompanhamento> CadastrarAcompanhamento()
        {
            Acompanhamento acompanhamento = new Acompanhamento();
            acompanhamento.Observacao = null;
            acompanhamento.SolicitacaoCompraId = idSolicitacao;
            acompanhamento.StatusId = 4;
            acompanhamento.UsuarioId = usuarioLogado.Id;
            acompanhamento.Date = DateTime.Now;
            return await HttpAcompanhamento.Create(acompanhamento, usuarioLogado.token);
        }
        private async void PreencheGridProdutoCompra(DataGridView dgv, TextBox txtIdOrcamento)
        {
            List<ProdutoPedidoOrcamento> produtosCompras = await HttpProdutoPedidoOrcamentos.GetByIdSolicitacao(idSolicitacao, usuarioLogado.token);
            dgv.Rows.Clear();
            foreach (var item in produtosCompras.FindAll(o => o.OrcamentoId == long.Parse(txtIdOrcamento.Text == "" ? "0" : txtIdOrcamento.Text)))
            {
                int n = dgv.Rows.Add();
                dgv.Rows[n].Cells[0].Value = item.ProdutoSolicitacao.Produto.CodigoProtheus;
                dgv.Rows[n].Cells[1].Value = item.ProdutoSolicitacao.Produto.Grupo.Descricao;
                dgv.Rows[n].Cells[2].Value = item.ProdutoSolicitacao.Produto.Descricao;
                dgv.Rows[n].Cells[3].Value = item.Quantidade;
                dgv.Rows[n].Cells[4].Value = item.valor;
                dgv.Rows[n].Cells[5].Value = item.Desconto;
                dgv.Rows[n].Cells[6].Value = item.Ipi;
                dgv.Rows[n].Cells[7].Value = item.Icms;
                dgv.Rows[n].Cells[8].Value = (item.Quantidade * (item.valor - (item.valor * (item.Desconto / 100)))).ToString("F2");
                dgv.Rows[n].Cells[10].Value = item.ProdutoSolicitacoesId;
                dgv.Rows[n].Cells[11].Value = item.Id;
                dgv.Rows[n].Cells[9].Value = "Remover";
            }
        }
        private void RealizaCalculoValoresFinais(DataGridViewCellEventArgs e, DataGridView dataGrid)
        {
            try
            {
                totalIpiList.Clear();
                decimal quantidade = Convert.ToDecimal(dataGrid.Rows[e.RowIndex].Cells[3].Value);
                decimal valorUnitario = Convert.ToDecimal(dataGrid.Rows[e.RowIndex].Cells[4].Value);
                decimal desconto = Convert.ToDecimal(dataGrid.Rows[e.RowIndex].Cells[5].Value);
                decimal total = quantidade * (valorUnitario - (valorUnitario * (desconto / 100)));
                if (dataGrid.Rows[e.RowIndex].Cells[3].Value != null &&
                    dataGrid.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    dataGrid.Rows[e.RowIndex].Cells[8].Value = total.ToString("F2");
                }
                if (dataGrid.Columns[e.ColumnIndex].Index == 6)
                {
                    decimal ipi = Convert.ToDecimal(dataGrid.Rows[e.RowIndex].Cells[6].Value);
                    decimal totalIpi = (ipi / 100) * valorUnitario;
                    totalIpiList.Add(totalIpi);
                }
            }
            catch (Exception)
            {


            }

        }
        private void PreencheValoresCalculados(DataGridView dataGrid, List<Decimal> totalIpiList, TextBox txtTotalProdutos, TextBox txtTotalIpi, TextBox txtValorFinal)
        {
            decimal valorTotalProduto = dataGrid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells[8].Value));
            decimal valorTotalIpi = totalIpiList.Sum(item => item);
            txtTotalProdutos.Text = valorTotalProduto.ToString("F2");
            txtTotalIpi.Text = valorTotalIpi.ToString("F2");
            txtValorFinal.Text = (valorTotalProduto + valorTotalIpi).ToString("F2");
        }
        private void CalculaFrete(TextBox txtFrete, TextBox txtValorFinal, DataGridView dgv)
        {
            decimal valorFinal = dgv.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells[8].Value)); ;
            if (!string.IsNullOrEmpty(txtFrete.Text))
            {
                decimal frete = decimal.Parse(txtFrete.Text);
                decimal resultado = valorFinal + frete;
                txtValorFinal.Text = (resultado).ToString("F2");
            }
        }
        private void AnexarOrcamento(TextBox txtAnexarpdf)
        {
            openFileDialog1.Filter = "pdf files | *.pdf";
            openFileDialog1.InitialDirectory = $@"{Environment.SpecialFolder.Desktop}";
            openFileDialog1.FileName = "orcamento";
            openFileDialog1.Title = "Selecione o orçamento no formato pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtAnexarpdf.Text = openFileDialog1.FileName;
            }
        }

        private async Task CriarOrcamentoDefault1()
        {
            Orcamento orcamento = new Orcamento();
            orcamento.Anexo = null;
            orcamento.Fornecedor = "Fornecerdor1";
            orcamento.Data = dtpDataOrcamento1.Value;
            orcamento.Cnpj = "0000000000001";
            orcamento.FormaPagamento = "formaPagamento1";
            orcamento.TotalProdutos = 0;
            orcamento.TotalIpi = 0;
            orcamento.ValorFrete = 0;
            orcamento.ValorTotal = 0;
            orcamento.OrderFlag = '1';
            var orcamentoCriado = await HttpOrcamentos.Create(orcamento, usuarioLogado.token);
            if (orcamentoCriado == null)
            {
                MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
            }
            else
                txtIdOrcamento1.Text = (await HttpOrcamentos.GetAll(usuarioLogado.token)).Last().Id.ToString();
        }
        private async Task CriarOrcamentoDafault2()
        {
            Orcamento orcamento = new Orcamento();
            orcamento.Anexo = null;
            orcamento.Fornecedor = "Fornecerdor2";
            orcamento.Data = dtpDataOrcamento1.Value;
            orcamento.Cnpj = "0000000000002";
            orcamento.FormaPagamento = "formaPagamento2";
            orcamento.TotalProdutos = 0;
            orcamento.TotalIpi = 0;
            orcamento.ValorFrete = 0;
            orcamento.ValorTotal = 0;
            orcamento.OrderFlag = '2';
            var orcamentoCriado = await HttpOrcamentos.Create(orcamento, usuarioLogado.token);
            if (orcamentoCriado == null)
            {
                MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
            }
            else
                txtIdOrcamento2.Text = (await HttpOrcamentos.GetAll(usuarioLogado.token)).Last().Id.ToString();
        }
        private async Task CriarOrcamentoDafault3()
        {
            Orcamento orcamento = new Orcamento();
            orcamento.Anexo = null;
            orcamento.Fornecedor = "Fornecerdor3";
            orcamento.Data = dtpDataOrcamento1.Value;
            orcamento.Cnpj = "0000000000003";
            orcamento.FormaPagamento = "formaPagamento3";
            orcamento.TotalProdutos = 0;
            orcamento.TotalIpi = 0;
            orcamento.ValorFrete = 0;
            orcamento.ValorTotal = 0;
            orcamento.OrderFlag = '3';
            var orcamentoCriado = await HttpOrcamentos.Create(orcamento, usuarioLogado.token);
            if (orcamentoCriado == null)
            {
                MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
            }
            else
                txtIdOrcamento3.Text = (await HttpOrcamentos.GetAll(usuarioLogado.token)).Last().Id.ToString();
        }
        private async void txtCodigoProtheusProduto_TextChanged(object sender, EventArgs e)
        {
            var codigoProduto = ((TextBox)sender).Text;
            Regex regex = new Regex("^[0-9]*$");
            if (!string.IsNullOrEmpty(codigoProduto))
            {
                if (regex.IsMatch(codigoProduto))
                {
                    Produto produto = await HttpProdutos.GetProdutosByCodigoProtheus(Convert.ToInt64(codigoProduto), usuarioLogado.token);
                    if (produto != null)
                    {
                        txtGrupo.Text = produto.Grupo.Descricao;
                        txtDescricao.Text = produto.Descricao;
                        idProduto = produto.Id;
                        idGrupo = produto.GrupoId;
                    }
                    else
                    {
                        txtGrupo.Text = "";
                        txtDescricao.Text = "";
                        idProduto = 0;
                    }
                }
            }
        }
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            CadastrarProdutoSolicitacao();
        }

        private async void AtualizaGridProdutos()
        {
            produtosCompras = await HttpProdutoSolicitacoes.GetByIdSolicitacao(idSolicitacao, usuarioLogado.token);
            dgvProduto.Rows.Clear();
            foreach (var item in produtosCompras)
            {
                int n = dgvProduto.Rows.Add();
                dgvProduto.Rows[n].Cells[0].Value = item.Produto.CodigoProtheus;
                dgvProduto.Rows[n].Cells[1].Value = item.Produto.Grupo.Descricao;
                dgvProduto.Rows[n].Cells[2].Value = item.Produto.Descricao;
                dgvProduto.Rows[n].Cells[3].Value = "Remover";
                dgvProduto.Rows[n].Cells[4].Value = item.Produto.Id;
                dgvProduto.Rows[n].Cells[6].Value = item.Id;
            }
        }

        private async void CadastrarProdutoSolicitacao()
        {
            ProdutoSolicitacao produtoSolicitacao = new ProdutoSolicitacao();
            produtoSolicitacao.SolicitacaoComprasId = idSolicitacao;
            produtoSolicitacao.ProdutosId = idProduto;
            var produtoSolicitacaoCriado = await HttpProdutoSolicitacoes.Create(produtoSolicitacao, usuarioLogado.token);
            if (produtoSolicitacaoCriado != null)
            {
                AtualizaGridProdutos();
            }
            else
            {
                MessageBox.Show("Erro ao salvar produto na solicitação de compras");
            }

        }

        private async void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduto.Columns[e.ColumnIndex].Name == "colRemover")
            {
                long produtoSolicitacaoId = (long)dgvProduto.Rows[e.RowIndex].Cells["colProdutoSolicitacaoId"].Value;
                if (MessageBox.Show("Tem certeza que deseja remover esse registro da lista?", "Remover registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (await HttpProdutoSolicitacoes.Delete(produtoSolicitacaoId, usuarioLogado.token))
                    {
                        AtualizaGridProdutos();
                        PreencheGridProdutoCompra(dgvProdutoCompra1, txtIdOrcamento1);
                        PreencheGridProdutoCompra(dgvProdutoCompra2, txtIdOrcamento2);
                        PreencheGridProdutoCompra(dgvProdutoCompra3, txtIdOrcamento3);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar exclusão, tente novamente mais tarde", "Erro ao tentar excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private async void btnProximoProduto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (!orcamentoCadastrado1)
                {
                    await CriarOrcamentoDefault1();
                    if (!(await CriarProdutoPedidoOrcamentoDefault(txtIdOrcamento1)))
                    {
                        MessageBox.Show("Erro interno no servidor tente mais tarde novamente");
                        return;
                    }
                    else
                    {
                        PreencheGridProdutoCompra(dgvProdutoCompra1, txtIdOrcamento1);
                    }
                    tabContainer.SelectTab(2);
                    ((Control)tabContainer.TabPages[1]).Enabled = false;
                }
                else
                {
                    if (!(await CriarProdutoPedidoOrcamentoDefault(txtIdOrcamento1)))
                    {
                        MessageBox.Show("Erro interno no servidor tente mais tarde novamente");
                        return;
                    }
                    else
                    {
                        PreencheGridProdutoCompra(dgvProdutoCompra1, txtIdOrcamento1);
                    }
                    tabContainer.SelectTab(2);
                    ((Control)tabContainer.TabPages[1]).Enabled = false;
                }
            }
        }

        private async Task<bool> CriarProdutoPedidoOrcamentoDefault(TextBox txtIdOrcamento)
        {
            List<ProdutoSolicitacao> produtosCompras = await HttpProdutoSolicitacoes.GetByIdSolicitacao(idSolicitacao, usuarioLogado.token);
            foreach (var item in produtosCompras)
            {
                ProdutoPedidoOrcamento produtoPedidoOrcamento = new ProdutoPedidoOrcamento();
                produtoPedidoOrcamento.OrcamentoId = long.Parse(txtIdOrcamento.Text);
                produtoPedidoOrcamento.ProdutoSolicitacoesId = item.Id;
                produtoPedidoOrcamento.Quantidade = 0;
                produtoPedidoOrcamento.valor = 0;
                produtoPedidoOrcamento.Desconto = 0;
                produtoPedidoOrcamento.Ipi = 0;
                produtoPedidoOrcamento.Icms = 0;
                var produtoPedidoCriado = await HttpProdutoPedidoOrcamentos.Create(produtoPedidoOrcamento, usuarioLogado.token);
                if (produtoPedidoCriado == null)
                {
                    MessageBox.Show("Error");
                    return false;
                }
            }
            return true;
        }

        private async void btnProximo1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (!orcamentoCadastrado2)
                {
                    if (!VerificaCamposVaziosOrcamentos(1))
                    {
                        Orcamento orcamento = PreencheObjetoDosInputs(1);
                        if (await UpdateOrcamento(orcamento))
                        {
                            await CriarOrcamentoDafault2();
                            if (!(await CriarProdutoPedidoOrcamentoDefault(txtIdOrcamento2)))
                            {
                                return;
                            }
                            if (decimal.Parse(txtValorFinal1.Text) < 5000)
                            {
                                if (MessageBox.Show("O valor final desse orçamento é menor ou igual a 5000, deseja encerrar a solicitação de compras", "Deseja finalizar solicaitação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    await FinalizaSolicitacao();
                                    return;
                                }

                            }
                            PreencheGridProdutoCompra(dgvProdutoCompra2, txtIdOrcamento2);
                            tabContainer.SelectTab(3);
                            ((Control)tabContainer.TabPages[2]).Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Todos os campos são obrigatórios", "Cadastro do orcamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (decimal.Parse(txtValorFinal1.Text) < 5000)
                    {
                        if (MessageBox.Show("O valor final desse orçamento é menor ou igual a 5000, deseja encerrar a solicitação de compras", "Deseja finalizar solicaitação",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            await FinalizaSolicitacao();
                            return;
                        }

                    }
                    if (!(await CriarProdutoPedidoOrcamentoDefault(txtIdOrcamento2)))
                    {
                        MessageBox.Show("Erro interno no servidor tente mais tarde novamente");
                        return;
                    }
                    else
                    {
                        PreencheGridProdutoCompra(dgvProdutoCompra2, txtIdOrcamento2);
                    }
                    tabContainer.SelectTab(3);
                    ((Control)tabContainer.TabPages[2]).Enabled = false;
                }
            }
        }
        private async void btnProximo2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (!orcamentoCadastrado3)
                {
                    if (!VerificaCamposVaziosOrcamentos(2))
                    {
                        Orcamento orcamento = PreencheObjetoDosInputs(2);
                        if (await UpdateOrcamento(orcamento))
                        {
                            await CriarOrcamentoDafault3();
                            if (!(await CriarProdutoPedidoOrcamentoDefault(txtIdOrcamento3)))
                            {
                                return;
                            }
                            if (decimal.Parse(txtValorFinal2.Text) < 5000)
                            {
                                if (MessageBox.Show("O valor final desse orçamento é menor ou igual a 5000, deseja encerrar a solicitação de compras", "Deseja finalizar solicaitação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    await FinalizaSolicitacao();
                                    return;
                                }

                            }
                            PreencheGridProdutoCompra(dgvProdutoCompra3, txtIdOrcamento3);
                            tabContainer.SelectTab(4);
                            ((Control)tabContainer.TabPages[3]).Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Todos os campos são obrigatórios", "Cadastro do orcamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (decimal.Parse(txtValorFinal2.Text) < 5000)
                    {
                        if (MessageBox.Show("O valor final desse orçamento é menor ou igual a 5000, deseja encerrar a solicitação de compras", "Deseja finalizar solicaitação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            await FinalizaSolicitacao();
                            return;
                        }

                    }
                    if (!(await CriarProdutoPedidoOrcamentoDefault(txtIdOrcamento3)))
                    {
                        MessageBox.Show("Erro interno no servidor tente mais tarde novamente");
                        return;
                    }
                    else
                    {
                        PreencheGridProdutoCompra(dgvProdutoCompra3, txtIdOrcamento3);
                    }
                    tabContainer.SelectTab(4);
                    ((Control)tabContainer.TabPages[3]).Enabled = false;
                }
            }
        }
        private async void btnProximo3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!VerificaCamposVaziosOrcamentos(3))
                {
                    Orcamento orcamento = PreencheObjetoDosInputs(3);
                    if (await UpdateOrcamento(orcamento))
                    {
                        await FinalizaSolicitacao();
                    }
                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios", "Cadastro do orcamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private async Task FinalizaSolicitacao()
        {
            var acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            acompanhamento.StatusId = 1;
            acompanhamento.Observacao = null;
            await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
            MessageBox.Show("Você finalizou a primeira etapa para realizar sua compra com sucesso!!\n" +
                "A coordenação irá analisar sua solicitação e irá dar um retorno assim que possível.",
                "Finalizar processo de compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
            frmAreaAvaliador.AtualizaGridSolicitacoesPendentes();
            frmAreaAvaliador.AtualizaGridSolicitacoesUsuario();
        }

        private async void btnAdicionarOcupacao_Click(object sender, EventArgs e)
        {
            long ocupacaoId = (long)cboOcupacao.SelectedValue;
            Ocupacao ocupacao = await HttpOcupacaos.GetOcupacaoById(ocupacaoId, usuarioLogado.token);
            dgvOcupacoes.Rows.Add(ocupacao.Numero, ocupacao.Nome, "Remove", ocupacao.Id);
        }
        private void cboEscola_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long escolaId = (long)((ComboBox)sender).SelectedValue;
            PreencheDadosEscola(escolaId);
        }
        private async void dgvOcupacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOcupacoes.Columns[e.ColumnIndex].Name == "colRemoveOcupacao")
            {
                if (acao == ConstantesProjeto.EDITAR)
                {
                    if (MessageBox.Show("Tem certeza que deseja remover esse registro do banco de dados?", "Remover registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (await HttpSolicitacaoOcupacoes.Delete((long)dgvOcupacoes.Rows[e.RowIndex].Cells[3].Value, idSolicitacao, usuarioLogado.token))
                        {
                            dgvOcupacoes.Rows.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao remover ocupação, tente novamente mais tarde");
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Tem certeza que deseja remover esse registro da lista?", "Remover registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dgvOcupacoes.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (acao == ConstantesProjeto.EDITAR)
                {
                    SalvarSolicitacao(ConstantesProjeto.EDITAR);
                }
                else
                {
                    SalvarSolicitacao(ConstantesProjeto.SALVAR);
                }
            }
        }
        private void txtValorFrete1_TextChanged(object sender, EventArgs e)
        {
            CalculaFrete((TextBox)sender, txtValorFinal1, dgvProdutoCompra1);
        }
        private void btnSelecionar1_Click(object sender, EventArgs e)
        {
            AnexarOrcamento(txtAnexarPdf1);
        }
        private bool VerificaCamposVaziosOrcamentos(int index)
        {
            return string.IsNullOrEmpty(((TextBox)tabContainer.Controls.Find("txtIdOrcamento" + index, true)[0]).Text)
                && string.IsNullOrEmpty(((TextBox)tabContainer.Controls.Find("txtTotalIpi" + index, true)[0]).Text)
                && string.IsNullOrEmpty(((TextBox)tabContainer.Controls.Find("txtTotalProdutos" + index, true)[0]).Text)
                && string.IsNullOrEmpty(((TextBox)tabContainer.Controls.Find("txtValorFinal" + index, true)[0]).Text)
                && string.IsNullOrEmpty(((TextBox)tabContainer.Controls.Find("txtValorFrete" + index, true)[0]).Text)
                && string.IsNullOrEmpty(((TextBox)tabContainer.Controls.Find("txtAnexarPdf" + index, true)[0]).Text)
                && string.IsNullOrEmpty(((TextBox)tabContainer.Controls.Find("txtCnpj" + index, true)[0]).Text)
                && string.IsNullOrEmpty(((TextBox)tabContainer.Controls.Find("txtFornecedor" + index, true)[0]).Text);
        }
        private Orcamento PreencheObjetoDosInputs(int index)
        {
            Orcamento orcamento = new Orcamento();
            orcamento.Id = long.Parse(((TextBox)tabContainer.Controls.Find("txtIdOrcamento" + index, true)[0]).Text);
            orcamento.TotalIpi = decimal.Parse(((TextBox)tabContainer.Controls.Find("txtTotalIpi" + index, true)[0]).Text);
            orcamento.TotalProdutos = decimal.Parse(((TextBox)tabContainer.Controls.Find("txtTotalProdutos" + index, true)[0]).Text);
            orcamento.ValorTotal = decimal.Parse(((TextBox)tabContainer.Controls.Find("txtValorFinal" + index, true)[0]).Text);
            orcamento.ValorFrete = decimal.Parse(((TextBox)tabContainer.Controls.Find("txtValorFrete" + index, true)[0]).Text);
            orcamento.Anexo = ((TextBox)tabContainer.Controls.Find("txtAnexarPdf" + index, true)[0]).Text;
            orcamento.Cnpj = ((TextBox)tabContainer.Controls.Find("txtCnpj" + index, true)[0]).Text;
            orcamento.Fornecedor = ((TextBox)tabContainer.Controls.Find("txtFornecedor" + index, true)[0]).Text;
            orcamento.FormaPagamento = ((ComboBox)tabContainer.Controls.Find("cboFormaPagamento" + index, true)[0]).Text;
            orcamento.Data = ((DateTimePicker)tabContainer.Controls.Find("dtpDataOrcamento" + index, true)[0]).Value;
            return orcamento;
        }
        private async Task<bool> UpdateOrcamento(Orcamento orcamento)
        {
            if (orcamento != null)
            {
                var orcamentoEditado = await HttpOrcamentos.Update(orcamento, orcamento.Id, usuarioLogado.token);
                if (orcamentoEditado == null)
                {
                    MessageBox.Show("Erro interno no sistema tente novamente mais tarde", "Erro interno Servidor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            MessageBox.Show("Erro interno no sistema tente novamente mais tarde", "Erro interno Servidor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        private async void dgvProdutoCompra1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e, dgvProdutoCompra1);
            PreencheValoresCalculados(dgvProdutoCompra1, totalIpiList, txtTotalProdutos1, txtTotalIpi1, txtValorFinal1);
            await EditarProdutoPedidoOrcamento(e, 1);
        }
        private async void dgvProdutoCompra2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e, dgvProdutoCompra2);
            PreencheValoresCalculados(dgvProdutoCompra2, totalIpiList, txtTotalProdutos2, txtTotalIpi2, txtValorFinal2);
            await EditarProdutoPedidoOrcamento(e, 2);
        }
        private async void dgvProdutoCompra3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e, dgvProdutoCompra3);
            PreencheValoresCalculados(dgvProdutoCompra3, totalIpiList, txtTotalProdutos3, txtTotalIpi3, txtValorFinal3);
            await EditarProdutoPedidoOrcamento(e, 3);
        }
        private void btnSelecionar2_Click(object sender, EventArgs e)
        {
            AnexarOrcamento(txtAnexarPdf2);
        }
        private void btnSelecionar3_Click(object sender, EventArgs e)
        {
            AnexarOrcamento(txtAnexarPdf3);
        }
        private void txtValorFrete2_TextChanged(object sender, EventArgs e)
        {
            CalculaFrete((TextBox)sender, txtValorFinal2, dgvProdutoCompra2);
        }
        private void txtValorFrete3_TextChanged(object sender, EventArgs e)
        {
            CalculaFrete((TextBox)sender, txtValorFinal3, dgvProdutoCompra3);
        }


        private async Task EditarProdutoPedidoOrcamento(DataGridViewCellEventArgs e, int index)
        {
            ProdutoPedidoOrcamento produtoPedidoOrcamento = new ProdutoPedidoOrcamento();
            produtoPedidoOrcamento.OrcamentoId = long.Parse(((TextBox)tabContainer.Controls.Find("txtIdOrcamento" + index, true)[0]).Text);
            produtoPedidoOrcamento.ProdutoSolicitacoesId = Convert.ToInt64(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colProdutoSolicitacaoId" + index].Value);
            produtoPedidoOrcamento.Quantidade = Convert.ToDecimal(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colQuantidade" + index].Value);
            produtoPedidoOrcamento.valor = Convert.ToDecimal(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colUnitario" + index].Value);
            produtoPedidoOrcamento.Desconto = Convert.ToDecimal(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colDesconto" + index].Value);
            produtoPedidoOrcamento.Ipi = Convert.ToDecimal(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colIpi" + index].Value);
            produtoPedidoOrcamento.Icms = Convert.ToDecimal(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colICMS" + index].Value);
            produtoPedidoOrcamento.Id = Convert.ToInt64(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colProdutoPedidoOrcamentoId" + index].Value);
            var ProdutopedidoOrcamentoCriado = await HttpProdutoPedidoOrcamentos.Update(produtoPedidoOrcamento, produtoPedidoOrcamento.Id, usuarioLogado.token);
            if (ProdutopedidoOrcamentoCriado == null)
            {
                MessageBox.Show("Deu pau");
                return;
            }

        }

        private void FrmNovaSolicitacao_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAreaAvaliador.AtualizaGridSolicitacoesPendentes();
            frmAreaAvaliador.AtualizaGridSolicitacoesUsuario();
        }
        private async void btnVisualizarArquivo_Click(object sender, EventArgs e)
        {
            await BaixarPdf(txtAnexarPdf1);
        }

        private async Task BaixarPdf(TextBox txtAnexarPdf)
        {
            var file = await HttpOrcamentos.DownloadPdfOrcamentos(txtAnexarPdf.Text, usuarioLogado.token);
            //define o titulo
            saveFileDialog1.Title = "Salvar Arquivo Texto";
            //Define as extensões permitidas
            saveFileDialog1.Filter = "Pdf File|.pdf";
            //define o indice do filtro
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.FileName = txtAnexarPdf.Text;
            //Define a extensão padrão como .txt
            saveFileDialog1.DefaultExt = ".pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog1.FileName, file);
                Process.Start(saveFileDialog1.FileName);
            }
        }

        private async void btnVisualizarArquivo2_Click(object sender, EventArgs e)
        {
            await BaixarPdf(txtAnexarPdf2);
        }

        private async void btnVisualizarArquivo3_Click(object sender, EventArgs e)
        {
            await BaixarPdf(txtAnexarPdf3);
        }

        private async void dgvProdutoCompra1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutoCompra1.Columns[e.ColumnIndex].Name == "colRemover1")
            {
                long produtoPedidoOrcamentoId = (long)dgvProdutoCompra1.Rows[e.RowIndex].Cells["colProdutoPedidoOrcamentoId1"].Value;
                if (MessageBox.Show("Tem certeza que deseja remover esse registro da lista?", "Remover registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (await HttpProdutoPedidoOrcamentos.Delete(produtoPedidoOrcamentoId, usuarioLogado.token))
                    {
                        dgvProdutoCompra1.Rows.Remove(dgvProdutoCompra1.Rows[e.RowIndex]);
                        MessageBox.Show("Removido com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar exclusão, tente novamente mais tarde", "Erro ao tentar excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void dgvProdutoCompra2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutoCompra2.Columns[e.ColumnIndex].Name == "colRemover2")
            {
                long produtoPedidoOrcamentoId = (long)dgvProdutoCompra2.Rows[e.RowIndex].Cells["colProdutoPedidoOrcamentoId2"].Value;
                if (MessageBox.Show("Tem certeza que deseja remover esse registro da lista?", "Remover registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (await HttpProdutoPedidoOrcamentos.Delete(produtoPedidoOrcamentoId, usuarioLogado.token))
                    {
                        dgvProdutoCompra2.Rows.Remove(dgvProdutoCompra2.Rows[e.RowIndex]);
                        MessageBox.Show("Removido com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar exclusão, tente novamente mais tarde", "Erro ao tentar excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void dgvProdutoCompra3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutoCompra3.Columns[e.ColumnIndex].Name == "colRemover3")
            {
                long produtoPedidoOrcamentoId = (long)dgvProdutoCompra3.Rows[e.RowIndex].Cells["colProdutoPedidoOrcamentoId3"].Value;
                if (MessageBox.Show("Tem certeza que deseja remover esse registro da lista?", "Remover registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (await HttpProdutoPedidoOrcamentos.Delete(produtoPedidoOrcamentoId, usuarioLogado.token))
                    {
                        dgvProdutoCompra3.Rows.Remove(dgvProdutoCompra3.Rows[e.RowIndex]);
                        MessageBox.Show("Removido com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar exclusão, tente novamente mais tarde", "Erro ao tentar excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvProdutoCompra1_Leave(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra1, totalIpiList, txtTotalProdutos1, txtTotalIpi1, txtValorFinal1);
        }

        private void dgvProdutoCompra2_Leave(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra2, totalIpiList, txtTotalProdutos2, txtTotalIpi2, txtValorFinal2);
        }

        private void dgvProdutoCompra3_Leave(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra3, totalIpiList, txtTotalProdutos3, txtTotalIpi3, txtValorFinal3);
        }
    }
}
