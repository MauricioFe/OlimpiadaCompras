using ApiSGCOlimpiada.Models;
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
        long solicitacaoComprasId = 0;
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
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CreateSolicitacao();
            }
        }

        private async void CreateSolicitacao()
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
                        var solicitacaoComprasList = await HttpSolicitacaoCompras.GetAll(usuarioLogado.token);
                        solicitacaoComprasId = solicitacaoComprasList.Last().Id;
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
            dgvProduto.Rows.Add(txtCodigoProtheusProduto.Text, txtGrupo.Text, txtDescricao.Text, "Remove", idProduto, idGrupo);
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduto.Columns[e.ColumnIndex].Name == "colRemover")
            {
                dgvProduto.Rows.RemoveAt(e.RowIndex);
            }
        }

        List<Produto> produtosCompras = new List<Produto>();
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
                PreencheGridProdutoCompra(produtosCompras, dgvProdutoCompra1);
                tabContainer.SelectTab(2);
                ((Control)tabContainer.TabPages[1]).Enabled = false;
            }
        }
        //Parei aqui... Criar método para preencher a parte do produto no grid de orçamentos
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
               // dgv.Rows[n].Cells["colRemover1"].Value = "Remover";
            }
        }

        List<double> totalIpiList = new List<double>();
        private void dgvProdutoCompra1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e,dgvProdutoCompra1);
        }

        private void RealizaCalculoValoresFinais(DataGridViewCellEventArgs e, DataGridView dataGrid)
        {
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

        private void txtFornecedor1_Enter(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra1, totalIpiList, txtTotalProdutos1, txtTotalIPI1, txtValorFinal1);
        }

        private void PreencheValoresCalculados(DataGridView dataGrid, List<Double> totalIpiList, TextBox txtTotalProdutos, TextBox txtTotalIpi, TextBox txtValorFinal)
        {
            double valorTotalProduto = dataGrid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells["colTotal1"].Value));
            double valorTotalIpi = totalIpiList.Sum(item => item);
            txtTotalProdutos.Text = valorTotalProduto.ToString("F2");
            txtTotalIpi.Text = valorTotalIpi.ToString("F2");
            txtValorFinal.Text = (valorTotalProduto + valorTotalIpi).ToString("F2");
        }

        private void txtValorFrete1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                double valorFinal = double.Parse(txtValorFinal1.Text);
                double frete = double.Parse(((TextBox)sender).Text);
                valorFinal += frete;
                txtValorFinal1.Text = valorFinal.ToString("F2");
            }
        }

        private void btnSelecionar1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "pdf files | *.pdf";
            openFileDialog1.InitialDirectory = $@"{Environment.SpecialFolder.Desktop}";
            openFileDialog1.FileName = "orcamento";
            openFileDialog1.Title = "Selecione o orçamento no formato pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtAnexarPdf1.Text = openFileDialog1.FileName;
            }
        }

        private void btnProximo1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CreateOrcamento1();
            }
        }

        private async void CreateOrcamento1()
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
                        produtoPedidoOrcamento.SolicitacaoComprasId = solicitacaoComprasId;
                        produtoPedidoOrcamento.Quantidade = Convert.ToInt32(dgvProdutoCompra1.Rows[i].Cells["colQuantidade1"].Value);
                        produtoPedidoOrcamento.valor = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colUnitario1"].Value);
                        produtoPedidoOrcamento.Desconto = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colDesconto1"].Value);
                        produtoPedidoOrcamento.Ipi = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colIpi1"].Value);
                        produtoPedidoOrcamento.Icms = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colICMS1"].Value);
                        //produtoPedidoOrcamento. = Convert.ToDouble(dgvProdutoCompra1.Rows[i].Cells["colUnitario"].Value);
                        var ProdutopedidoOrcamentoCriado = await HttpProdutoPedidoOrcamentos.Create(produtoPedidoOrcamento, usuarioLogado.token);
                    }

                    if (float.Parse(txtValorFinal1.Text) < 5000)
                    {
                        if (MessageBox.Show("O seu primeiro orçamento ficou abaixo de R$5.000,00. Deseja encerrar a solicitação de compras?", "Finalizar solicitação de compras", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show("Orçamento cadastrado com sucesso");
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
                MessageBox.Show($"{ConstantesProjeto.MENSAGEM_PREENCHER_CAMPOS}, Lembre-se de anexar o orçamento em pdf para continuar");
            }
        }

        private void btnProximo2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CreateOrcamento2();
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
                        produtoPedidoOrcamento.SolicitacaoComprasId = solicitacaoComprasId;
                        produtoPedidoOrcamento.Quantidade = Convert.ToInt32(dgvProdutoCompra2.Rows[i].Cells["colQuantidade2"].Value);
                        produtoPedidoOrcamento.valor = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colUnitario2"].Value);
                        produtoPedidoOrcamento.Desconto = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colDesconto2"].Value);
                        produtoPedidoOrcamento.Ipi = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colIpi2"].Value);
                        produtoPedidoOrcamento.Icms = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colICMS2"].Value);
                        //produtoPedidoOrcamento. = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colUnitario"].Value);
                        var ProdutopedidoOrcamentoCriado = await HttpProdutoPedidoOrcamentos.Create(produtoPedidoOrcamento, usuarioLogado.token);
                    }

                    MessageBox.Show("Orçamento cadastrado com sucesso");
                    PreencheGridProdutoCompra(produtosCompras, dgvProdutoCompra2);
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
                    for (int i = 0; i < dgvProdutoCompra2.Rows.Count; i++)
                    {
                        ProdutoPedidoOrcamento produtoPedidoOrcamento = new ProdutoPedidoOrcamento();
                        produtoPedidoOrcamento.OrcamentoId = orcamentoId1;
                        produtoPedidoOrcamento.ProdutoId = Convert.ToInt64(dgvProdutoCompra2.Rows[i].Cells["colProdutoId3"].Value);
                        produtoPedidoOrcamento.SolicitacaoComprasId = solicitacaoComprasId;
                        produtoPedidoOrcamento.Quantidade = Convert.ToInt32(dgvProdutoCompra2.Rows[i].Cells["colQuantidade3"].Value);
                        produtoPedidoOrcamento.valor = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colUnitario3"].Value);
                        produtoPedidoOrcamento.Desconto = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colDesconto3"].Value);
                        produtoPedidoOrcamento.Ipi = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colIpi3"].Value);
                        produtoPedidoOrcamento.Icms = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colICMS3"].Value);
                        //produtoPedidoOrcamento. = Convert.ToDouble(dgvProdutoCompra2.Rows[i].Cells["colUnitario"].Value);
                        var ProdutopedidoOrcamentoCriado = await HttpProdutoPedidoOrcamentos.Create(produtoPedidoOrcamento, usuarioLogado.token);
                    }

                    MessageBox.Show("Orçamento cadastrado com sucesso e sua solicitação foi enviada para a coordenação e ficará em análise.");
                    this.Dispose();
                    
                }
            }
            else
            {
                MessageBox.Show($"{ConstantesProjeto.MENSAGEM_PREENCHER_CAMPOS}, Lembre-se de anexar o orçamento em pdf para continuar");
            }
        }

        private void btnProximo3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CreateOrcamento3();
            }
        }

        private void dgvProdutoCompra2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e, dgvProdutoCompra2);
        }

        private void dgvProdutoCompra3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(e, dgvProdutoCompra3);
        }
    }
}
