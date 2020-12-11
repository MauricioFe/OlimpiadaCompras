using ApiSGCOlimpiada.Models;
using OlimpiadaCompras.Data;
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
    public partial class FrmCadastroUsuarios : Form
    {
        Usuario usuarioLogado;
        List<Usuario> usuarios = new List<Usuario>();
        public FrmCadastroUsuarios(Usuario usuario)
        {
            usuarioLogado = usuario;
            InitializeComponent();
        }

        private void FrmCadastroUsuarios_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }


        private async void btnSalvar_ClickAsync(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtSenha.Text))
            {
                usuario.Email = txtEmail.Text;
                usuario.Nome = txtEmail.Text;
                usuario.Senha = txtEmail.Text;
                usuario.FuncaoId = 2;
                var usuarioCriado = await HttpUsuarios.Create(usuario, usuarioLogado.token);
                if (usuarioCriado == null)
                {
                    MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                }
                else
                {
                    AtualizaGrid();
                    MessageBox.Show("Usuário adicionado com sucesso");
                    txtSenha.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtNome.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }
        }

        private async void txtFiltro_TextChangedAsync(object sender, EventArgs e)
        {
            await AtualizaGridByFiltro();
        }

        private async Task AtualizaGridByFiltro()
        {
            usuarios = await HttpUsuarios.GetUsuariosByNome(txtFiltro.Text, usuarioLogado.token);
            dgvUsuarios.Rows.Clear();
            foreach (var usuario in usuarios)
            {
                int n = dgvUsuarios.Rows.Add();
                dgvUsuarios.Rows[n].Cells[0].Value = usuario.Nome;
                dgvUsuarios.Rows[n].Cells[1].Value = usuario.Email;
                dgvUsuarios.Rows[n].Cells[2].Value = usuario.FuncaoId;
                dgvUsuarios.Rows[n].Cells[3].Value = usuario.Id;
            }
        }
        private async void AtualizaGrid()
        {
            usuarios = await HttpUsuarios.GetAllUsuarios(usuarioLogado.token);
            dgvUsuarios.Rows.Clear();
            foreach (var usuario in usuarios)
            {
                int n = dgvUsuarios.Rows.Add();
                dgvUsuarios.Rows[n].Cells[0].Value = usuario.Nome;
                dgvUsuarios.Rows[n].Cells[1].Value = usuario.Email;
                dgvUsuarios.Rows[n].Cells[2].Value = usuario.FuncaoId;
                dgvUsuarios.Rows[n].Cells[3].Value = usuario.Id;
            }

        }
    }
}
