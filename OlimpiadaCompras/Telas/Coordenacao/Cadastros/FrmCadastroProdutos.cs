using ApiSGCOlimpiada.Models;
using OlimpiadaCompras.Requests;
using OlimpiadaCompras.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Telas.Coordenacao.Cadastros
{
    public partial class FrmCadastroProdutos : Form
    {
        private Usuario usuarioLogado;
        List<Produto> produtos = new List<Produto>();
        private long id = 0;

        public FrmCadastroProdutos(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            PreencheCombobox();
            txtCodigoProtheus.Select(9, 0);
        }
        private async void AtualizaGridByFiltro()
        {
            produtos = await HttpProdutos.GetProdutosBySearch(txtFiltro.Text, usuarioLogado.token);
            dgvProduto.Rows.Clear();
            foreach (var produto in produtos)
            {
                int n = dgvProduto.Rows.Add();
                dgvProduto.Rows[n].Cells[0].Value = "000000000" + produto.CodigoProtheus;
                dgvProduto.Rows[n].Cells[1].Value = produto.Descricao;
                dgvProduto.Rows[n].Cells[2].Value = produto.Grupo.Descricao;
                dgvProduto.Rows[n].Cells[3].Value = produto.Id;
            }
        }
        private async void AtualizaGrid()
        {
            produtos = await HttpProdutos.GetAllProdutos(usuarioLogado.token);
            dgvProduto.Rows.Clear();
            foreach (var produto in produtos)
            {
                int n = dgvProduto.Rows.Add();
                dgvProduto.Rows[n].Cells[0].Value = "000000000" + produto.CodigoProtheus;
                dgvProduto.Rows[n].Cells[1].Value = produto.Descricao;
                dgvProduto.Rows[n].Cells[2].Value = produto.GrupoId;
                dgvProduto.Rows[n].Cells[3].Value = produto.Id;
            }

        }

        private void FrmCadastroProdutos_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AtualizaGridByFiltro();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                await Update();
            }
            else
            {
                await Create();
            }
        }

        private async Task Create()
        {
            Produto produto = new Produto();
            if (!string.IsNullOrEmpty(txtCodigoProtheus.Text) && !string.IsNullOrEmpty(txtDescricao.Text))
            {
                produto.CodigoProtheus = long.Parse(txtCodigoProtheus.Text);
                produto.Descricao = txtDescricao.Text;
                produto.GrupoId = Convert.ToInt64(cboGrupo.SelectedValue);
                var produtoCriado = await HttpProdutos.Create(produto, usuarioLogado.token);
                if (produtoCriado == null)
                {
                    MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                }
                else
                {
                    AtualizaGrid();
                    MessageBox.Show("Produto adicionado com sucesso");
                    ManipulaFormGenericoUtil.LimpaCampos(this);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }
        }
        private new async Task Update()
        {
            Produto produto = new Produto();
            if (id != 0)
            {

                if (!string.IsNullOrEmpty(txtCodigoProtheus.Text) && !string.IsNullOrEmpty(txtDescricao.Text))
                {
                    produto.CodigoProtheus = long.Parse(txtCodigoProtheus.Text);
                    produto.Descricao = txtDescricao.Text;
                    produto.GrupoId = Convert.ToInt64(cboGrupo.SelectedValue);
                    var produtoUpdate = await HttpProdutos.Update(produto, id, usuarioLogado.token);
                    if (produtoUpdate == null)
                    {
                        MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                    }
                    else
                    {
                        AtualizaGrid();
                        MessageBox.Show("Produto adicionado com sucesso");
                        ManipulaFormGenericoUtil.LimpaCampos(this);
                        id = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios");
                }
            }
            else
            {
                MessageBox.Show("Selecione ao menos um produto da lista");
            }
        }
        private async void PreencheCombobox()
        {
            List<Grupo> grupos = await HttpGrupos.GetAllGrupos(usuarioLogado.token);
            cboGrupo.DataSource = grupos;
            cboGrupo.DisplayMember = "Descricao";
            cboGrupo.ValueMember = "Id";
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você realmente deseja excluir esse registro?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    await HttpProdutos.Delete(id, usuarioLogado.token);
                    AtualizaGrid();
                    MessageBox.Show("Produto excluído com sucesso");
                    ManipulaFormGenericoUtil.LimpaCampos(this);
                    id = 0;
                }
                else
                {
                    MessageBox.Show("Selecione um produto da lista");
                }
            }
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                id = Convert.ToInt64(dgvProduto.Rows[e.RowIndex].Cells["colIdProduto"].Value);
                txtCodigoProtheus.Text = dgvProduto.Rows[e.RowIndex].Cells["colCodigoProtheusProduto"].Value.ToString();
                txtDescricao.Text = dgvProduto.Rows[e.RowIndex].Cells["colDescricaoProduto"].Value.ToString();
                cboGrupo.SelectedValue = dgvProduto.Rows[e.RowIndex].Cells["colGrupo"].Value;
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            await Update();
        }
    }
}
