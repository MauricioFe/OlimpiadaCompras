﻿using OlimpiadaCompras.Models;
using OlimpiadaCompras.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        List<decimal> totalIpiList = new List<decimal>();
        FrmAreaCoordenacao frmAreaCoordenacao;
        public FrmGerenciarSolicitacaoCompra(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");
            InitializeComponent();
        }
        public FrmGerenciarSolicitacaoCompra(Usuario usuario, long idSolicitacao, FrmAreaCoordenacao frmAreaCoordenacao)
        {
            this.usuarioLogado = usuario;
            this.idSolicitacao = idSolicitacao;
            this.frmAreaCoordenacao = frmAreaCoordenacao;
            InitializeComponent();
            ToggleHabilitaInputs(false);
            btnVisualizarArquivo1.Enabled = true;
            btnVisualizarArquivo2.Enabled = true;
            btnVisualizarArquivo3.Enabled = true;
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
                        int row = ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows.Add();
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[0].Value = item.ProdutoSolicitacao.Produto.CodigoProtheus;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[1].Value = item.ProdutoSolicitacao.Produto.Grupo.Descricao;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[2].Value = item.ProdutoSolicitacao.Produto.Descricao;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[3].Value = item.Quantidade;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[4].Value = item.valor;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[5].Value = item.Desconto;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[6].Value = item.Ipi;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[7].Value = item.Icms;
                        ((DataGridView)tabContainer.Controls.Find($"dgvProdutoCompra{i + 1}", true)[0]).Rows[row].Cells[8].Value = (item.Quantidade * (item.valor - (item.valor * (item.Desconto / 100)))).ToString("F2");
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
            RealizaCalculoValoresFinais(dgvProdutoCompra1);
            PreencheValoresCalculados(dgvProdutoCompra1, totalIpiList, txtTotalProdutos1, txtTotalIpi1, txtValorFinal1);
            RealizaCalculoValoresFinais(dgvProdutoCompra2);
            PreencheValoresCalculados(dgvProdutoCompra2, totalIpiList, txtTotalProdutos2, txtTotalIpi2, txtValorFinal2);
            RealizaCalculoValoresFinais(dgvProdutoCompra3);
            PreencheValoresCalculados(dgvProdutoCompra3, totalIpiList, txtTotalProdutos3, txtTotalIpi3, txtValorFinal3);
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
            FrmModalSolicitacao form = new FrmModalSolicitacao(ConstantesProjeto.SOLICITAR_ALTERACAO, acompanhamento, usuarioLogado, frmAreaCoordenacao);
            form.ShowDialog();
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            FrmPrecadastroEmail form = new FrmPrecadastroEmail(usuarioLogado, idSolicitacao, frmAreaCoordenacao);
            form.ShowDialog();
        }

        private async void btnReprovar_Click(object sender, EventArgs e)
        {

            Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            FrmModalSolicitacao form = new FrmModalSolicitacao(ConstantesProjeto.SOLICITACAO_REPROVADA, acompanhamento, usuarioLogado, frmAreaCoordenacao);
            form.ShowDialog();
        }

        private async void FrmGerenciarSolicitacaoCompra_Load(object sender, EventArgs e)
        {
            PreencheCombobox(cboEscola, "Nome", "Id");
            PreencheCombobox(cboOcupacao, "Nome", "Id");
            PreencheCombobox(cboTipoCompra, "Descricao", "Id");
            PreencheDadosEscola(1);
            if (idSolicitacao > 0)
            {
                PreencheDadosSolicitacao();
            }
            Acompanhamento acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
            if (acompanhamento.StatusId == ConstantesProjeto.STATUS_EM_ANALISE_NF)
            {
                btnVisualizarNF.Visible = true;
            }
        }

        private void cboEscola_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long escolaId = (long)((ComboBox)sender).SelectedValue;
            PreencheDadosEscola(escolaId);
        }
        private async void btnAdicionarOcupacao_Click(object sender, EventArgs e)
        {
            long ocupacaoId = (long)cboOcupacao.SelectedValue;
            Ocupacao ocupacao = await HttpOcupacaos.GetOcupacaoById(ocupacaoId, usuarioLogado.token);
            dgvOcupacoes.Rows.Add(ocupacao.Numero, ocupacao.Nome, "Remover", ocupacao.Id);
        }
        private async void dgvOcupacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOcupacoes.Columns[e.ColumnIndex].Name == "colRemoveOcupacao")
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
        }
        private async void SalvarSolicitacao()
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

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SalvarSolicitacao();
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
                        await PreencheGridProdutoCompra(dgvProdutoCompra1, txtIdOrcamento1);
                        await PreencheGridProdutoCompra(dgvProdutoCompra2, txtIdOrcamento2);
                        await PreencheGridProdutoCompra(dgvProdutoCompra3, txtIdOrcamento3);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar exclusão, tente novamente mais tarde", "Erro ao tentar excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            CadastrarProdutoSolicitacao();
        }
        private async Task PreencheGridProdutoCompra(DataGridView dgv, TextBox txtIdOrcamento)
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
                dgv.Rows[n].Cells[8].Value = item.Quantidade * (item.valor - (item.valor * (item.Desconto / 100)));
                dgv.Rows[n].Cells[10].Value = item.ProdutoSolicitacoesId;
                dgv.Rows[n].Cells[11].Value = item.Id;
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
        private async void btnProximoProduto_Click(object sender, EventArgs e)
        {
            if (!(await CriarProdutoPedidoOrcamentoDefault(txtIdOrcamento1)))
            {
                MessageBox.Show("Erro interno no servidor tente mais tarde novamente");
                return;
            }
            else
            {
                await PreencheGridProdutoCompra(dgvProdutoCompra1, txtIdOrcamento1);
            }
            tabContainer.SelectTab(2);
            ((Control)tabContainer.TabPages[1]).Enabled = false;
        }
        private void RealizaCalculoValoresFinais(DataGridView dataGrid)
        {
            totalIpiList.Clear();
            try
            {
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    decimal quantidade = Convert.ToDecimal(dataGrid.Rows[i].Cells[3].Value);
                    decimal valorUnitario = Convert.ToDecimal(dataGrid.Rows[i].Cells[4].Value);
                    decimal desconto = Convert.ToDecimal(dataGrid.Rows[i].Cells[5].Value);
                    decimal total = quantidade * (valorUnitario - (valorUnitario * (desconto / 100)));
                    if (dataGrid.Rows[i].Cells[3].Value != null &&
                        dataGrid.Rows[i].Cells[4].Value != null)
                    {
                        dataGrid.Rows[i].Cells[8].Value = total.ToString("F2");
                    }
                    decimal ipi = Convert.ToDecimal(dataGrid.Rows[i].Cells[6].Value);
                    decimal totalIpi = ((ipi / 100) * Convert.ToDecimal(dataGrid.Rows[i].Cells[4].Value)) * Convert.ToDecimal(dataGrid.Rows[i].Cells[3].Value);
                    totalIpiList.Add(totalIpi);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro ao realizar cálculo", e.Message);
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
        private async Task EditarProdutoPedidoOrcamento(DataGridViewCellEventArgs e, int index)
        {
            ProdutoPedidoOrcamento produtoPedidoOrcamento = new ProdutoPedidoOrcamento();
            produtoPedidoOrcamento.OrcamentoId = long.Parse(((TextBox)tabContainer.Controls.Find("txtIdOrcamento" + index, true)[0]).Text);
            produtoPedidoOrcamento.ProdutoSolicitacoesId = Convert.ToInt64(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colProdutoSolicitacaoId" + index].Value);
            produtoPedidoOrcamento.Quantidade = Convert.ToInt32(((DataGridView)tabContainer.Controls.Find("dgvProdutoCompra" + index, true)[0]).Rows[e.RowIndex].Cells["colQuantidade" + index].Value);
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
        private async void dgvProdutoCompra1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(dgvProdutoCompra1);
            PreencheValoresCalculados(dgvProdutoCompra1, totalIpiList, txtTotalProdutos1, txtTotalIpi1, txtValorFinal1);
            await EditarProdutoPedidoOrcamento(e, 1);
        }
        private void dgvProdutoCompra1_Leave(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra1, totalIpiList, txtTotalProdutos1, txtTotalIpi1, txtValorFinal1);
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
        private async void btnProximo1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!VerificaCamposVaziosOrcamentos(1))
                {
                    Orcamento orcamento = PreencheObjetoDosInputs(1);
                    if (await UpdateOrcamento(orcamento))
                    {
                        if (decimal.Parse(txtValorFinal1.Text) < 5000)
                        {
                            if (MessageBox.Show("O valor final desse orçamento é menor ou igual a 5000, deseja encerrar a solicitação de compras", "Deseja finalizar solicaitação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
                            await PreencheGridProdutoCompra(dgvProdutoCompra2, txtIdOrcamento2);
                        }
                        tabContainer.SelectTab(3);
                        ((Control)tabContainer.TabPages[2]).Enabled = false;
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
            frmAreaCoordenacao.AtualizaGridSolicitacoes();
        }

        private async void dgvProdutoCompra2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(dgvProdutoCompra2);
            PreencheValoresCalculados(dgvProdutoCompra2, totalIpiList, txtTotalProdutos2, txtTotalIpi2, txtValorFinal2);
            await EditarProdutoPedidoOrcamento(e, 2);
        }

        private void dgvProdutoCompra2_Leave(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra2, totalIpiList, txtTotalProdutos2, txtTotalIpi2, txtValorFinal2);
        }
        private void txtValorFrete2_TextChanged(object sender, EventArgs e)
        {
            CalculaFrete((TextBox)sender, txtValorFinal2, dgvProdutoCompra2);
        }
        private void btnSelecionar2_Click(object sender, EventArgs e)
        {
            AnexarOrcamento(txtAnexarPdf2);
        }
        private async void btnProximo2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja proseguir? Caso selecione sim você não poderá alterar as informações colocadas nessa aba. ", "Confirmação de sequência", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!VerificaCamposVaziosOrcamentos(2))
                {
                    Orcamento orcamento = PreencheObjetoDosInputs(2);
                    if (await UpdateOrcamento(orcamento))
                    {
                        if (decimal.Parse(txtValorFinal1.Text) < 5000)
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
                            await PreencheGridProdutoCompra(dgvProdutoCompra3, txtIdOrcamento3);
                        }
                        tabContainer.SelectTab(4);
                        ((Control)tabContainer.TabPages[3]).Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios", "Cadastro do orcamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private async void dgvProdutoCompra3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RealizaCalculoValoresFinais(dgvProdutoCompra3);
            PreencheValoresCalculados(dgvProdutoCompra3, totalIpiList, txtTotalProdutos3, txtTotalIpi3, txtValorFinal3);
            await EditarProdutoPedidoOrcamento(e, 1);
        }

        private void dgvProdutoCompra3_Leave(object sender, EventArgs e)
        {
            PreencheValoresCalculados(dgvProdutoCompra3, totalIpiList, txtTotalProdutos3, txtTotalIpi3, txtValorFinal3);
        }

        private void txtValorFrete3_TextChanged(object sender, EventArgs e)
        {
            CalculaFrete((TextBox)sender, txtValorFinal3, dgvProdutoCompra3);
        }

        private void btnSelecionar3_Click(object sender, EventArgs e)
        {
            AnexarOrcamento(txtAnexarPdf3);
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
                        var acompanhamento = await HttpAcompanhamento.GetBySolicitacaoId(idSolicitacao, usuarioLogado.token);
                        acompanhamento.StatusId = 1;
                        await HttpAcompanhamento.Update(acompanhamento, acompanhamento.Id, usuarioLogado.token);
                        MessageBox.Show("Solicitação de compras editada com sucesso",
                            "Editando solicitação de compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios", "Cadastro do orcamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
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

        private async void btnVisualizarArquivo_Click(object sender, EventArgs e)
        {
            await BaixarPdf(txtAnexarPdf1);
        }
        private async void btnVisualizarArquivo2_Click(object sender, EventArgs e)
        {
            await BaixarPdf(txtAnexarPdf2);
        }

        private async void btnVisualizarArquivo3_Click(object sender, EventArgs e)
        {
            await BaixarPdf(txtAnexarPdf3);
        }

        private void btnVisualizarNF_Click(object sender, EventArgs e)
        {
            FrmVisualizarNotaFiscal form = new FrmVisualizarNotaFiscal(frmAreaCoordenacao, idSolicitacao, usuarioLogado);
            form.ShowDialog();
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
    }
}
