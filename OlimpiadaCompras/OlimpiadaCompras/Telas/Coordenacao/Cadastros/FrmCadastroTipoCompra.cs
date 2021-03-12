using OlimpiadaCompras.Models;
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
    public partial class FrmCadastroTipoCompra : Form
    {
        private Usuario usuarioLogado;
        List<TipoCompra> tipoCompras = new List<TipoCompra>();
        private long id = 0;

        public FrmCadastroTipoCompra(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            AtualizaGrid();
        }

        private async void AtualizaGridByFiltro()
        {
            tipoCompras = await HttpTipoCompras.GetTipoComprasBySearch(txtFiltro.Text, usuarioLogado.token);
            dgvTipoCompra.Rows.Clear();
            foreach (var grupo in tipoCompras)
            {
                int n = dgvTipoCompra.Rows.Add();
                dgvTipoCompra.Rows[n].Cells[0].Value = grupo.Descricao;
                dgvTipoCompra.Rows[n].Cells[1].Value = grupo.Id;
            }
        }
        private async void AtualizaGrid()
        {
            tipoCompras = await HttpTipoCompras.GetAllTipoCompras(usuarioLogado.token);
            dgvTipoCompra.Rows.Clear();
            foreach (var grupo in tipoCompras)
            {
                int n = dgvTipoCompra.Rows.Add();
                dgvTipoCompra.Rows[n].Cells[0].Value = grupo.Descricao;
                dgvTipoCompra.Rows[n].Cells[1].Value = grupo.Id;
            }

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AtualizaGridByFiltro();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
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

        private void dgvTipoCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                id = Convert.ToInt64(dgvTipoCompra.Rows[e.RowIndex].Cells[1].Value);
                txtDescricao.Text = dgvTipoCompra.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
        private async Task Create()
        {
            TipoCompra tipoCompra = new TipoCompra();
            if (!string.IsNullOrEmpty(txtDescricao.Text))
            {
                tipoCompra.Descricao = txtDescricao.Text;
                var tipoCompraCriado = await HttpTipoCompras.Create(tipoCompra, usuarioLogado.token);
                if (tipoCompraCriado == null)
                {
                    MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                }
                else
                {
                    AtualizaGrid();
                    MessageBox.Show("Tipo de compra adicionada com sucesso");
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
            if (id != 0)
            {

                TipoCompra tipoCompra = new TipoCompra();
                if (!string.IsNullOrEmpty(txtDescricao.Text))
                {
                    tipoCompra.Descricao = txtDescricao.Text;
                    var tipoCompraCriado = await HttpTipoCompras.Update(tipoCompra, id, usuarioLogado.token);
                    if (tipoCompraCriado == null)
                    {
                        MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                    }
                    else
                    {
                        AtualizaGrid();
                        MessageBox.Show("Tipo de compra editada com sucesso");
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
                MessageBox.Show("Selecione um tipo de compra da lista");
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Você realmente deseja excluir esse registro?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    await HttpTipoCompras.Delete(id, usuarioLogado.token);
                    MessageBox.Show("Tipo de compra excluída com sucesso");
                    AtualizaGrid();
                    ManipulaFormGenericoUtil.LimpaCampos(this);
                    id = 0;
                }
                else
                {
                    MessageBox.Show("Selecione um tipo de compra da lista");
                }
            }
        }
    }
}
