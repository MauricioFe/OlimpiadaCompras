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

namespace OlimpiadaCompras.Telas
{
    public partial class FrmEditarUsuarios : Form
    {
        private Usuario usuarioLogado;
        private long id = 0;

        public FrmEditarUsuarios(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            txtEmail.Text = usuario.Email;
            txtNome.Text = usuario.Nome;
            txtSenha.Text = usuario.Senha;
            id = usuario.Id;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await Update();
        }
        private new async Task Update()
        {

            if (id != 0)
            {
                if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtSenha.Text))
                {
                    Usuario usuarioEditado = new Usuario();
                    usuarioEditado.Email = txtEmail.Text;
                    usuarioEditado.Nome = txtNome.Text;
                    usuarioEditado.Senha = txtSenha.Text;
                    usuarioEditado.FuncaoId = 2;
                    var usuarioCriado = await HttpUsuarios.Update(usuarioEditado, id, usuarioLogado.token);
                    if (usuarioCriado == null)
                    {
                        MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                    }
                    else
                    {
                        MessageBox.Show("Usuário Editado com sucesso");
                    }
                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios");
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário da lista");
            }
        }
    }
}
