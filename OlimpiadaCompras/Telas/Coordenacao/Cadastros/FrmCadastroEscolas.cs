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

        public FrmCadastroEscolas(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent(); AtualizaGrid();
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

        }

        private async Task CreateEscola()
        {
            Escola escola = new Escola();
            if (!string.IsNullOrEmpty(txtNomeEscola.Text) && !string.IsNullOrEmpty(txtCep.Text) && !string.IsNullOrEmpty(txtLogradouro.Text)
                && !string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty(cboEstado.Text)
                && !string.IsNullOrEmpty(txtCidade.Text))
            {
                escola.Nome = txtNomeEscola.Text;
                escola.Cep = txtCep.Text;
                escola.Logradouro = txtLogradouro.Text;
                escola.Bairro = txtBairro.Text;
                escola.Numero = txtNumero.Text;
                escola.Estado = cboEstado.Text;
                escola.Cidade = txtCidade.Text;
                var escolaCriado = await HttpEscolas.Create(escola, usuarioLogado.token);
                if (escolaCriado == null)
                {
                    MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                }
                else
                {
                    AtualizaGrid();
                    MessageBox.Show("Escola adicionada com sucesso");
                    txtFiltro.Text = string.Empty;
                    ManipulaFormGenericoUtil.LimpaCampos(this);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await CreateEscola();
        }
    }
}
