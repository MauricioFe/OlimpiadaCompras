using ApiSGCOlimpiada.Models;
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

namespace OlimpiadaCompras.Telas.Coordenacao.Cadastros
{
    public partial class FrmCadastroOcupacoes : Form
    {
        private Usuario usuarioLogado;
        List<Ocupacao> ocupacoes = new List<Ocupacao>();
        private long id = 0;
        public FrmCadastroOcupacoes(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            AtualizaGrid();
        }

        private async void AtualizaGridByFiltro()
        {
            ocupacoes = await HttpOcupacaos.GetOcupacaosBySearch(txtFiltro.Text, usuarioLogado.token);
            dgvOcupacoes.Rows.Clear();
            foreach (var ocupacao in ocupacoes)
            {
                int n = dgvOcupacoes.Rows.Add();
                dgvOcupacoes.Rows[n].Cells[0].Value = ocupacao.Numero;
                dgvOcupacoes.Rows[n].Cells[1].Value = ocupacao.Nome;
                dgvOcupacoes.Rows[n].Cells[2].Value = ocupacao.Id;
            }
        }
        private async void AtualizaGrid()
        {
            ocupacoes = await HttpOcupacaos.GetAllOcupacaos(usuarioLogado.token);
            dgvOcupacoes.Rows.Clear();
            foreach (var ocupacao in ocupacoes)
            {
                int n = dgvOcupacoes.Rows.Add();
                dgvOcupacoes.Rows[n].Cells[0].Value = ocupacao.Numero;
                dgvOcupacoes.Rows[n].Cells[1].Value = ocupacao.Nome;
                dgvOcupacoes.Rows[n].Cells[2].Value = ocupacao.Id;
            }

        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await Create();
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você realmente deseja excluir esse registro?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    await HttpOcupacaos.Delete(id, usuarioLogado.token);
                    AtualizaGrid();
                    MessageBox.Show("Ocupação excluída com sucesso");
                    txtNumero.Text = string.Empty;
                    txtOcupacao.Text = string.Empty;
                    txtFiltro.Text = string.Empty;
                    id = 0;
                }
                else
                {
                    MessageBox.Show("Selecione uma ocupação da lista");
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            await Update();
        }

        private void dgvOcupacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNumero.Text = dgvOcupacoes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOcupacao.Text = dgvOcupacoes.Rows[e.RowIndex].Cells[1].Value.ToString();
            id = Convert.ToInt64(dgvOcupacoes.Rows[e.RowIndex].Cells[2].Value);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AtualizaGridByFiltro();
        }

        private async Task Create()
        {
            Ocupacao ocupacao = new Ocupacao();
            if (!string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty(txtOcupacao.Text))
            {
                ocupacao.Numero = txtNumero.Text;
                ocupacao.Nome = txtOcupacao.Text;
                var ocupacaoCriado = await HttpOcupacaos.Create(ocupacao, usuarioLogado.token);
                if (ocupacaoCriado == null)
                {
                    MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                }
                else
                {
                    AtualizaGrid();
                    MessageBox.Show("Ocupação adicionada com sucesso");
                    txtNumero.Text = string.Empty;
                    txtOcupacao.Text = string.Empty;
                    txtFiltro.Text = string.Empty;
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
                Ocupacao ocupacao = new Ocupacao();
                if (!string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty(txtOcupacao.Text))
                {
                    ocupacao.Numero = txtNumero.Text;
                    ocupacao.Nome = txtOcupacao.Text;
                    var ocupacaoCriado = await HttpOcupacaos.Update(ocupacao, id,usuarioLogado.token);
                    if (ocupacaoCriado == null)
                    {
                        MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                    }
                    else
                    {
                        AtualizaGrid();
                        MessageBox.Show("Ocupação editada com sucesso");
                        txtNumero.Text = string.Empty;
                        txtOcupacao.Text = string.Empty;
                        txtFiltro.Text = string.Empty;
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
                MessageBox.Show("Selecione ao menos uma ocupação da lista");
            }
        }
    }
}
