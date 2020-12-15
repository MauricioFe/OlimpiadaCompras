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
    public partial class FrmCadastroEscolas : Form
    {
        private Usuario usuarioLogado;
        List<Escola> escolas = new List<Escola>();
        List<Responsavel> responsaveis = new List<Responsavel>();
        long idEscola = 0;
        long idResponsavel = 0;
        public FrmCadastroEscolas(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            AtualizaGrid();
        }

        private async void AtualizaGridByFiltro()
        {
            responsaveis = await HttpResponsaveis.GetResponsavelsBySearch(txtFiltro.Text, usuarioLogado.token);
            dgvEscolas.Rows.Clear();
            foreach (var responsavel in escolas)
            {
                int n = dgvEscolas.Rows.Add();
            }
        }
        private async void AtualizaGrid()
        {
            escolas = await HttpEscolas.GetAllEscolas(usuarioLogado.token);
            dgvEscolas.Rows.Clear();
            foreach (var escola in escolas)
            {
                int n = dgvEscolas.Rows.Add();
                dgvEscolas.Rows[n].Cells["colIdEscola"].Value = escola.Id;
                dgvEscolas.Rows[n].Cells["colNomeEscola"].Value = escola.Nome;
                dgvEscolas.Rows[n].Cells["colLogradouro"].Value = escola.Logradouro;
                dgvEscolas.Rows[n].Cells["colBairro"].Value = escola.Bairro;
                dgvEscolas.Rows[n].Cells["colCep"].Value = escola.Cep;
                dgvEscolas.Rows[n].Cells["colNumero"].Value = escola.Numero;
                dgvEscolas.Rows[n].Cells["colCidade"].Value = escola.Cidade;
                dgvEscolas.Rows[n].Cells["colEstado"].Value = escola.Estado;
            }

        }

        private void FrmCadastrarEscolas_Load(object sender, EventArgs e)
        {
            dgvResponsavel.Rows.Add("Mauricio Lacerda", "mauricio@gmail.com", "bacon", "remove");
            dgvResponsavel.Rows.Add("Fernada Leal", "fefe@gmail.com", "bacon Vegano", "remove");
            dgvResponsavel.Rows.Add("Maria Paula", "mariapaula@gmail.com", "bacon picadinho", "remove");
        }

        private async Task CreateEscola()
        {
            Escola escola = new Escola();
            if (isCampoVazio())
            {
                escola.Nome = txtNomeEscola.Text;
                escola.Cep = txtCep.Text;
                escola.Logradouro = txtLogradouro.Text;
                escola.Bairro = txtBairro.Text;
                escola.Numero = txtNumero.Text;
                escola.Estado = cboEstado.Text;
                escola.Cidade = txtCidade.Text;
                if (hasResponsavelNaLista())
                {

                    var escolaCriado = await HttpEscolas.Create(escola, usuarioLogado.token);
                    if (escolaCriado == null)
                    {
                        MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                    }
                    else
                    {
                        AtualizaGrid();
                        for (int i = 0; i < dgvResponsavel.Rows.Count - 1; i++)
                        {
                            Responsavel responsavel = new Responsavel();
                            responsavel.EscolaId = escolas.Last().Id;
                            responsavel.Nome = dgvResponsavel.Rows[i].Cells[0].Value.ToString();
                            responsavel.Email = dgvResponsavel.Rows[i].Cells[1].Value.ToString();
                            responsavel.Cargo = dgvResponsavel.Rows[i].Cells[2].Value.ToString();
                            var responsavelCriado = await HttpResponsaveis.Create(responsavel, usuarioLogado.token);
                        }
                        MessageBox.Show("Escola adicionada com sucesso");
                        ManipulaFormGenericoUtil.LimpaCampos(this);
                    }
                }
                else
                {
                    MessageBox.Show("Coloque pelo menos 3 responsáveis para a escola");
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }
        }

        private bool isCampoVazio()
        {
            return !string.IsNullOrEmpty(txtNomeEscola.Text) && !string.IsNullOrEmpty(txtCep.Text) && !string.IsNullOrEmpty(txtLogradouro.Text)
                            && !string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty(cboEstado.Text)
                            && !string.IsNullOrEmpty(txtCidade.Text);
        }
        private bool hasResponsavelNaLista()
        {
            return (dgvResponsavel.Rows.Count != -1 && dgvResponsavel.Rows.Count >= 4);
        }

        private async Task UpdateEscola()
        {
            Escola escola = new Escola();
            if (isCampoVazio())
            {
                escola.Nome = txtNomeEscola.Text;
                escola.Cep = txtCep.Text;
                escola.Logradouro = txtLogradouro.Text;
                escola.Bairro = txtBairro.Text;
                escola.Numero = txtNumero.Text;
                escola.Estado = cboEstado.Text;
                escola.Cidade = txtCidade.Text;
                if (hasResponsavelNaLista())
                {
                    var escolaCriado = await HttpEscolas.Update(escola, idEscola, usuarioLogado.token);
                    if (escolaCriado == null)
                    {
                        MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                    }
                    else
                    {
                        AtualizaGrid();
                        MessageBox.Show("Escola editada com sucesso");
                        ManipulaFormGenericoUtil.LimpaCampos(this);
                        idEscola = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Coloque pelo menos 3 responsáveis para a escola");
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (idEscola > 0)
            {
                await UpdateEscola();
            }
            else
            {
                await CreateEscola();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeResponsavel.Text) && !string.IsNullOrEmpty(txtCargo.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text))
            {
                dgvResponsavel.Rows.Add(txtNomeResponsavel.Text, txtEmail.Text, txtCargo.Text, "Remover");
            }
            else
            {
                MessageBox.Show("Preencha todos campos de responsáveis");
            }
        }

        private void dgvResponsavel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResponsavel.Columns[e.ColumnIndex].Name == "colRemove")
            {
                if (MessageBox.Show("TesTem certeza que deseja remover este item?", "Remover item", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvResponsavel.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
