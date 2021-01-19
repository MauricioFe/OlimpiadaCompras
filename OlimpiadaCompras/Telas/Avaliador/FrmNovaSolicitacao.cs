using OlimpiadaCompras.Models;
using OlimpiadaCompras.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        long idGrupo = 0;
        long idSolicitacao = 0;
        List<OcupacaoSolicitacaoCompra> ocupacoesSolicitacaoEditList = new List<OcupacaoSolicitacaoCompra>();
        List<ProdutoPedidoOrcamento> produtoPedidoOrcamentosList = new List<ProdutoPedidoOrcamento>();
        List<Produto> produtosCompras = new List<Produto>();
        List<double> totalIpiList = new List<double>();
        int acao;
        public FrmNovaSolicitacao(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
        }
        public FrmNovaSolicitacao(Usuario usuario, long idSolicitacao, int acao)
        {
            this.usuarioLogado = usuario;
            this.idSolicitacao = idSolicitacao;
            this.acao = acao;
            InitializeComponent();
        }
        private void FrmNovaSolicitacao_Load(object sender, EventArgs e)
        {
            PreencheCombobox(cboEscola, "Nome", "Id");
            PreencheCombobox(cboOcupacao, "Nome", "Id");
            PreencheCombobox(cboTipoCompra, "Descricao", "Id");
            PreencheDadosEscola(1);
            if (idSolicitacao > 0 && acao == ConstantesProjeto.VISUALIZAR)
            {
                PreencheDadosVisualizacaoSolicitacao();
                PreencheDadosVisualizacaoSolicitacaoProdutos();
                DisabilitaInputs();
            }
            else if (idSolicitacao > 0 && acao == ConstantesProjeto.EDITAR)
            {
                PreencheDadosVisualizacaoSolicitacao();
                PreencheDadosVisualizacaoSolicitacaoProdutos();

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
                dgvProduto.Rows[n].Cells[4].Value = produto.Id;
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
                ((TextBox)tabContainer.Controls.Find($"txtIdOrcamento{i}", true)[0]).Text = item.Orcamento.Id.ToString();
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
                        produtoPedidoOrcamentosList.Add(item);
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
                dgvOcupacoes.Rows[n].Cells["colIdOcupacao"].Value = ocupacao.Id;
                dgvOcupacoes.Rows[n].Cells[2].Value = "Remover";
                OcupacaoSolicitacaoCompra ocupacaoSolicitacaoCompra = new OcupacaoSolicitacaoCompra();
                ocupacaoSolicitacaoCompra.OcupacaoId = ocupacao.Id;
                ocupacaoSolicitacaoCompra.SolicitacaoId = idSolicitacao;
                ocupacoesSolicitacaoEditList.Add(ocupacaoSolicitacaoCompra);

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
                txtIdSolicitacao.Text = inputs.SolicitacaoCompra.Id.ToString();
                break;
            }
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

                    if (acao == ConstantesProjeto.SALVAR)
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
        private void PreencheGridProdutoCompra(List<Produto> produtosCompras, DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (var item in produtosCompras)
            {
                int n = dgv.Rows.Add();
                dgv.Rows[n].Cells[0].Value = item.CodigoProtheus;
                dgv.Rows[n].Cells[1].Value = item.Grupo.Descricao;
                dgv.Rows[n].Cells[2].Value = item.Descricao;
                dgv.Rows[n].Cells[10].Value = item.Id;
            }
        }
        private void RealizaCalculoValoresFinais(DataGridViewCellEventArgs e, DataGridView dataGrid)
        {
            try
            {
                totalIpiList.Clear();
                int quantidade = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells[3].Value);
                double valorUnitario = Convert.ToDouble(dataGrid.Rows[e.RowIndex].Cells[4].Value);
                double desconto = Convert.ToDouble(dataGrid.Rows[e.RowIndex].Cells[5].Value);
                double total = quantidade * (valorUnitario - (valorUnitario * (desconto / 100)));
                if (dataGrid.Rows[e.RowIndex].Cells[3].Value != null &&
                    dataGrid.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    dataGrid.Rows[e.RowIndex].Cells[8].Value = total;
                }
                if (dataGrid.Columns[e.ColumnIndex].Index == 6)
                {
                    double ipi = Convert.ToDouble(dataGrid.Rows[e.RowIndex].Cells[6].Value);
                    double totalIpi = (ipi / 100) * valorUnitario;
                    totalIpiList.Add(totalIpi);
                }
            }
            catch (Exception)
            {


            }

        }
        private void PreencheValoresCalculados(DataGridView dataGrid, List<Double> totalIpiList, TextBox txtTotalProdutos, TextBox txtTotalIpi, TextBox txtValorFinal)
        {
            double valorTotalProduto = dataGrid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[8].Value));
            double valorTotalIpi = totalIpiList.Sum(item => item);
            txtTotalProdutos.Text = valorTotalProduto.ToString("F2");
            txtTotalIpi.Text = valorTotalIpi.ToString("F2");
            txtValorFinal.Text = (valorTotalProduto + valorTotalIpi).ToString("F2");
        }
        private void CalculaFrete(TextBox txtFrete, TextBox txtValorFinal)
        {
            double valorFinal = 0;
            if (valorFinal == 0)
            {
                valorFinal = double.Parse(txtValorFinal.Text);
            }
            if (!string.IsNullOrEmpty(txtFrete.Text))
            {
                double frete = double.Parse(txtFrete.Text);
                double resultado = valorFinal + frete;
                txtValorFinal1.Text = (resultado).ToString("F2");
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
        private async void SalvarOrcamento1()
        {
            if (!string.IsNullOrEmpty(txtFornecedor1.Text) && !string.IsNullOrEmpty(txtCnpj1.Text) && !string.IsNullOrEmpty(txtTotalProdutos1.Text)
                && !string.IsNullOrEmpty(txtTotalIPI1.Text) && !string.IsNullOrEmpty(txtValorFrete1.Text) && !string.IsNullOrEmpty(txtAnexarPdf1.Text))
            {
                Orcamento orcamento1 = new Orcamento();
                orcamento1.Anexo = txtAnexarPdf1.Text;
                orcamento1.Fornecedor = txtFornecedor1.Text;
                orcamento1.Data = dtpDataOrcamento1.Value;
                orcamento1.Cnpj = txtCnpj1.Text;
                orcamento1.FormaPagamento = cboFormaPagamento1.Text;
                orcamento1.TotalProdutos = double.Parse(txtTotalProdutos1.Text);
                orcamento1.TotalIpi = double.Parse(txtTotalIPI1.Text);
                orcamento1.ValorFrete = double.Parse(txtValorFrete1.Text);
                orcamento1.ValorTotal = double.Parse(txtValorFinal1.Text);
                if (string.IsNullOrEmpty(txtIdOrcamento1.Text))
                {
                    var orcamentoCriado = await HttpOrcamentos.Create(orcamento1, usuarioLogado.token);
                    if (orcamentoCriado == null)
                    {
                        MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
                    }
                    else
                    {
                        List<Orcamento> produtoPedidoOrcamentoList = new List<Orcamento>();
                        var orcamentoList1 = await HttpOrcamentos.GetAll(usuarioLogado.token);
                        long orcamentoId1 = orcamentoList1.Last().Id;
                        for (int i = 0; i < dgvProdutoCompra1.Rows.Count; i++)
                        {
                            ProdutoPedidoOrcamento produtoPedidoOrcamento = new ProdutoPedidoOrcamento();
                            produtoPedidoOrcamento.OrcamentoId = orcamentoId1;
                            produtoPedidoOrcamento.ProdutoId = Convert.ToInt64(dgvProdutoCompra1.Rows[i].Cells["colProdutoId1"].Value);
                            produtoPedidoOrcamento.SolicitacaoComprasId = idSolicitacao;
                            produtoPedidoOrcamento.Quantidade = Convert.ToInt32(dgvProdutoCompra1.Rows[i].Cells["colQuantidade1"].Value);
                            produtoPedidoOrcamento.valor = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colUnitario1"].Value);
                            produtoPedidoOrcamento.Desconto = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colDesconto1"].Value);
                            produtoPedidoOrcamento.Ipi = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colIpi1"].Value);
                            produtoPedidoOrcamento.Icms = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colICMS1"].Value);
                            var ProdutopedidoOrcamentoCriado = await HttpProdutoPedidoOrcamentos.Create(produtoPedidoOrcamento, usuarioLogado.token);
                            if (ProdutopedidoOrcamentoCriado == null)
                            {
                                MessageBox.Show("Deu pau");
                                return;
                            }
                        }

                        if (float.Parse(txtValorFinal1.Text) < 5000)
                        {
                            if (MessageBox.Show("O seu primeiro orçamento ficou abaixo de R$5.000,00. Deseja encerrar a solicitação de compras?", "Finalizar solicitação de compras", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                MessageBox.Show("Orçamento cadastrado com sucesso e sua solicitação foi enviada para a coordenação e ficará em análise.");
                                var acompanhamento = await CadastrarAcompanhamento();
                                if (acompanhamento == null)
                                {
                                    MessageBox.Show("Erro no acompanhamento");
                                }
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Orçamento cadastrado com sucesso");
                                PreencheGridProdutoCompra(produtosCompras, dgvProdutoCompra2);
                                tabContainer.SelectTab(3);
                                ((Control)tabContainer.TabPages[2]).Enabled = false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Orçamento cadastrado com sucesso");
                            PreencheGridProdutoCompra(produtosCompras, dgvProdutoCompra2);
                            tabContainer.SelectTab(3);
                            ((Control)tabContainer.TabPages[2]).Enabled = false;
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show($"{ConstantesProjeto.MENSAGEM_PREENCHER_CAMPOS}, Lembre-se de anexar o orçamento em pdf para continuar");
            }
        }
        private async void CreateOrcamento2()
        {
            if (!string.IsNullOrEmpty(txtFornecedor2.Text) && !string.IsNullOrEmpty(txtCnpj2.Text) && !string.IsNullOrEmpty(txtTotalProdutos2.Text)
                && !string.IsNullOrEmpty(txtTotalIpi2.Text) && !string.IsNullOrEmpty(txtValorFrete2.Text) && !string.IsNullOrEmpty(txtAnexarPdf2.Text))
            {
                Orcamento orcamento = new Orcamento();
                orcamento.Anexo = txtAnexarPdf2.Text;
                orcamento.Fornecedor = txtFornecedor2.Text;
                orcamento.Data = dtpDataOrcamento2.Value;
                orcamento.Cnpj = txtCnpj2.Text;
                orcamento.FormaPagamento = cboFormaPagamento2.Text;
                orcamento.TotalProdutos = double.Parse(txtTotalProdutos2.Text);
                orcamento.TotalIpi = double.Parse(txtTotalIpi2.Text);
                orcamento.ValorFrete = double.Parse(txtValorFrete2.Text);
                orcamento.ValorTotal = double.Parse(txtValorFinal2.Text);

                var orcamentoCriado = await HttpOrcamentos.Create(orcamento, usuarioLogado.token);
                if (orcamentoCriado == null)
                {
                    MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
                }
                else
                {
                    List<Orcamento> produtoPedidoOrcamentoList = new List<Orcamento>();
                    var orcamentoList1 = await HttpOrcamentos.GetAll(usuarioLogado.token);
                    long orcamentoId1 = orcamentoList1.Last().Id;
                    for (int i = 0; i < dgvProdutoCompra2.Rows.Count; i++)
                    {
                        ProdutoPedidoOrcamento produtoPedidoOrcamento = new ProdutoPedidoOrcamento();
                        produtoPedidoOrcamento.OrcamentoId = orcamentoId1;
                        produtoPedidoOrcamento.ProdutoId = Convert.ToInt64(dgvProdutoCompra2.Rows[i].Cells["colProdutoId2"].Value);
                        produtoPedidoOrcamento.SolicitacaoComprasId = idSolicitacao;
                        produtoPedidoOrcamento.Quantidade = Convert.ToInt32(dgvProdutoCompra2.Rows[i].Cells["colQuantidade2"].Value);
                        produtoPedidoOrcamento.valor = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colUnitario2"].Value);
                        produtoPedidoOrcamento.Desconto = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colDesconto2"].Value);
                        produtoPedidoOrcamento.Ipi = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colIpi2"].Value);
                        produtoPedidoOrcamento.Icms = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colICMS2"].Value);
                        var ProdutopedidoOrcamentoCriado = await HttpProdutoPedidoOrcamentos.Create(produtoPedidoOrcamento, usuarioLogado.token);
                        if (ProdutopedidoOrcamentoCriado == null)
                        {
                            MessageBox.Show("Deu pau");
                            return;
                        }
                    }

                    MessageBox.Show("Orçamento cadastrado com sucesso");
                    PreencheGridProdutoCompra(produtosCompras, dgvProdutoCompra3);
                    tabContainer.SelectTab(4);
                    ((Control)tabContainer.TabPages[3]).Enabled = false;
                }
            }
            else
            {
                MessageBox.Show($"{ConstantesProjeto.MENSAGEM_PREENCHER_CAMPOS}, Lembre-se de anexar o orçamento em pdf para continuar");
            }
        }
        private async void CreateOrcamento3()
        {
            if (!string.IsNullOrEmpty(txtFornecedor3.Text) && !string.IsNullOrEmpty(txtCnpj3.Text) && !string.IsNullOrEmpty(txtTotalProdutos3.Text)
                && !string.IsNullOrEmpty(txtTotalIpi3.Text) && !string.IsNullOrEmpty(txtValorFrete3.Text) && !string.IsNullOrEmpty(txtAnexarPdf3.Text))
            {
                Orcamento orcamento = new Orcamento();
                orcamento.Anexo = txtAnexarPdf3.Text;
                orcamento.Fornecedor = txtFornecedor3.Text;
                orcamento.Data = dtpDataOrcamento3.Value;
                orcamento.Cnpj = txtCnpj3.Text;
                orcamento.FormaPagamento = cboFormaPagamento3.Text;
                orcamento.TotalProdutos = double.Parse(txtTotalProdutos3.Text);
                orcamento.TotalIpi = double.Parse(txtTotalIpi3.Text);
                orcamento.ValorFrete = double.Parse(txtValorFrete3.Text);
                orcamento.ValorTotal = double.Parse(txtValorFinal3.Text);

                var orcamentoCriado = await HttpOrcamentos.Create(orcamento, usuarioLogado.token);
                if (orcamentoCriado == null)
                {
                    MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
                }
                else
                {
                    List<Orcamento> produtoPedidoOrcamentoList = new List<Orcamento>();
                    var orcamentoList1 = await HttpOrcamentos.GetAll(usuarioLogado.token);
                    long orcamentoId1 = orcamentoList1.Last().Id;
                    for (int i = 0; i < dgvProdutoCompra3.Rows.Count; i++)
                    {
                        ProdutoPedidoOrcamento produtoPedidoOrcamento = new ProdutoPedidoOrcamento();
                        produtoPedidoOrcamento.OrcamentoId = orcamentoId1;
                        produtoPedidoOrcamento.ProdutoId = Convert.ToInt64(dgvProdutoCompra3.Rows[i].Cells["colProdutoId3"].Value);
                        produtoPedidoOrcamento.SolicitacaoComprasId = idSolicitacao;
                        produtoPedidoOrcamento.Quantidade = Convert.ToInt32(dgvProdutoCompra3.Rows[i].Cells["colQuantidade3"].Value);
                        produtoPedidoOrcamento.valor = Convert.ToDouble(dgvProdutoCompra3.Rows[i].Cells["colUnitario3"].Value);
                        produtoPedidoOrcamento.Desconto = Convert.ToDouble(dgvProdutoCompra3.Rows[i].Cells["colDesconto3"].Value);
                        produtoPedidoOrcamento.Ipi = Convert.ToDouble(dgvProdutoCompra3.Rows[i].Cells["colIpi3"].Value);
                        produtoPedidoOrcamento.Icms = Convert.ToDouble(dgvProdutoCompra3.Rows[i].Cells["colICMS3"].Value);
                        var ProdutopedidoOrcamentoCriado = await HttpProdutoPedidoOrcamentos.Create(produtoPedidoOrcamento, usuarioLogado.token);
                        if (ProdutopedidoOrcamentoCriado == null)
                        {
                            MessageBox.Show("Deu pau");
                            return;
                        }
                    }

                    MessageBox.Show("Orçamento cadastrado com sucesso e sua solicitação foi enviada para a coordenação e ficará em análise.");
                    var acompanhamento = await CadastrarAcompanhamento();
                    if (acompanhamento == null)
                    {
                        MessageBox.Show("Erro no acompanhamento");
                    }
                    this.Dispose();

                }
            }
            else
            {
                MessageBox.Show($"{ConstantesProjeto.MENSAGEM_PREENCHER_CAMPOS}, Lembre-se de anexar o orçamento em pdf para continuar");
            }
        }

        //Eventos do formulário
        private async Task<Acompanhamento> CadastrarAcompanhamento()
        {
            Acompanhamento acompanhamento = new Acompanhamento();
            acompanhamento.Observacao = null;
            acompanhamento.SolicitacaoCompraId = idSolicitacao;
            acompanhamento.StatusId = 1;
            acompanhamento.UsuarioId = usuarioLogado.Id;
            acompanhamento.Date = DateTime.Now;
            return await HttpAcompanhamento.Create(acompanhamento, usuarioLogado.token);
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
            
        }
        private async void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduto.Columns[e.ColumnIndex].Name == "colRemover")
            {
                long produtoId = (long)dgvProduto.Rows[e.RowIndex].Cells["colIdProduto"].Value;
                if (acao == ConstantesProjeto.EDITAR && produtoId > 0)
                {
                    bool foiExcluido = false;
                    for (int i = 0; i < 3; i++)
                    {

                        if (await HttpProdutoPedidoOrcamentos.Delete(idSolicitacao, produtoId,
                            long.Parse(((TextBox)tabContainer.Controls.Find($"txtIdOrcamento{i + 1}", true)[0]).Text), usuarioLogado.token))
                        {
                            foiExcluido = true;
                        }
                        else
                        {
                            MessageBox.Show("Erro ao realizar remoção");
                            foiExcluido = false;
                            break;
                        }
                    }
                    if (foiExcluido)
                    {
                        PreencheDadosVisualizacaoSolicitacaoProdutos();
                    }
                }
                else
                {
                    if (MessageBox.Show("Tem certeza que deseja remover esse registro da lista?", "Remover registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dgvProduto.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
        private void btnProximoProduto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < dgvProduto.Rows.Count; i++)
                {
                    Produto produto = new Produto();
                    produto.CodigoProtheus = Convert.ToInt64(dgvProduto.Rows[i].Cells[0].Value);
                    produto.Descricao = dgvProduto.Rows[i].Cells[2].Value.ToString();
                    produto.GrupoId = Convert.ToInt64(dgvProduto.Rows[i].Cells["colGrupoId"].Value);
                    produto.Grupo = new Grupo();
                    produto.Grupo.Descricao = dgvProduto.Rows[i].Cells[1].Value.ToString();
                    produto.Id = Convert.ToInt64(dgvProduto.Rows[i].Cells["colIdProduto"].Value);
                    produtosCompras.Add(produto);
                }
                tabContainer.SelectTab(2);
                ((Control)tabContainer.TabPages[1]).Enabled = false;
            }
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
            CalculaFrete((TextBox)sender, txtValorFinal1);
        }
        private void btnSelecionar1_Click(object sender, EventArgs e)
        {
            AnexarOrcamento(txtAnexarPdf1);
        }
        private void btnProximo1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SalvarOrcamento1();
            }
        }
        private void btnProximo2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CreateOrcamento2();
            }
        }
        private void btnProximo3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CreateOrcamento3();
            }
        }
        private void dgvProdutoCompra1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e, dgvProdutoCompra1);
        }
        private void dgvProdutoCompra2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e, dgvProdutoCompra2);
        }
        private void dgvProdutoCompra3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e, dgvProdutoCompra3);
        }
        private void txtFornecedor1_Enter(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra1, totalIpiList, txtTotalProdutos1, txtTotalIPI1, txtValorFinal1);
        }
        private void txtFornecedor2_Enter(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra2, totalIpiList, txtTotalProdutos2, txtTotalIpi2, txtValorFinal2);
        }
        private void txtFornecedor3_Enter(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra3, totalIpiList, txtTotalProdutos3, txtTotalIpi3, txtValorFinal3);
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
            CalculaFrete((TextBox)sender, txtValorFinal2);
        }
        private void txtValorFrete3_TextChanged(object sender, EventArgs e)
        {
            CalculaFrete((TextBox)sender, txtValorFinal3);
        }
    }
}
