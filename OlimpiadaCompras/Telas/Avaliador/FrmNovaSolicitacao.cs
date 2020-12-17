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
                        MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
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

        private void btnProximoProduto_Click(object sender, EventArgs e)
        {
            List<Produto> produtosCompras = new List<Produto>();

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
            PreencheGridProdutoCompra(produtosCompras);
            tabContainer.SelectTab(2);
            ((Control)tabContainer.TabPages[1]).Enabled = false;

        }
        //Parei aqui... Criar método para preencher a parte do produto no grid de orçamentos
        private void PreencheGridProdutoCompra(List<Produto> produtosCompras)
        {
            dgvProdutoCompra1.Rows.Clear();
            foreach (var item in produtosCompras)
            {
                int n = dgvProdutoCompra1.Rows.Add();
                dgvProdutoCompra1.Rows[n].Cells[0].Value = item.CodigoProtheus;
                dgvProdutoCompra1.Rows[n].Cells[1].Value = item.Grupo.Descricao;
                dgvProdutoCompra1.Rows[n].Cells[2].Value = item.Descricao;
                dgvProdutoCompra1.Rows[n].Cells["colRemover1"].Value = "Remover";
            }
        }

        List<double> totalIpiList = new List<double>();
        private void dgvProdutoCompra1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int quantidade = Convert.ToInt32(dgvProdutoCompra1.Rows[e.RowIndex].Cells["colQuantidade1"].Value);
            double valorUnitario = Convert.ToDouble(dgvProdutoCompra1.Rows[e.RowIndex].Cells["colUnitario1"].Value);
            double desconto = Convert.ToDouble(dgvProdutoCompra1.Rows[e.RowIndex].Cells["colDesconto1"].Value);
            double total = quantidade * (valorUnitario - (valorUnitario * (desconto / 100)));
            if (dgvProdutoCompra1.Rows[e.RowIndex].Cells["colQuantidade1"].Value != null &&
                dgvProdutoCompra1.Rows[e.RowIndex].Cells["colUnitario1"].Value != null)
            {
                dgvProdutoCompra1.Rows[e.RowIndex].Cells["colTotal1"].Value = total;
            }
            if (dgvProdutoCompra1.Columns[e.ColumnIndex].Name == "colIpi1")
            {
                double ipi = Convert.ToDouble(dgvProdutoCompra1.Rows[e.RowIndex].Cells["colIpi1"].Value);
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
            openFileDialog1.Filter = "Png files | *.png";
            openFileDialog1.InitialDirectory = $@"{Environment.SpecialFolder.Desktop}";
            openFileDialog1.Title = "Selecione o orçamento no formato pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtAnexarPdf1.Text = openFileDialog1.FileName;
            }
        }

        private void btnProximo1_Click(object sender, EventArgs e)
        {
            CreateOrcamento1();
        }

        private async void CreateOrcamento1()
        {
            if (string.IsNullOrEmpty(txtFornecedor1.Text) && string.IsNullOrEmpty(txtCnpj1.Text) && string.IsNullOrEmpty(txtTotalProdutos1.Text)
                && string.IsNullOrEmpty(txtTotalIPI1.Text) && string.IsNullOrEmpty(txtValorFrete1.Text) && string.IsNullOrEmpty(txtAnexarPdf1.Text))
            {
                Orcamento orcamento1 = new Orcamento();
                orcamento1.Anexo = txtAnexarPdf1.Text;
                orcamento1.Fornecedor= txtFornecedor1.Text;
                orcamento1.Data= dtpDataOrcamento1.Value;
                orcamento1.Cnpj= txtCnpj1.Text;
                orcamento1.FormaPagamento= cboFormaPagamento1.Text;
                orcamento1.TotalProdutos = double.Parse(cboFormaPagamento1.Text);
                orcamento1.TotalIpi = double.Parse(txtTotalIPI1.Text);
                orcamento1.ValorFrete = double.Parse(txtValorFrete1.Text);
                orcamento1.ValorTotal = double.Parse(txtValorFinal1.Text);

                var orcamentoCriado = HttpOrcamentos.Create(orcamento1, usuarioLogado.token);
                if (orcamentoCriado == null)
                {
                    MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
                }
            }
            else
            {
                MessageBox.Show("Todos campos são obrigatórios. Lembre-se de anexar o orçamento em pdf para continuar");
            }
        }
    }
}
