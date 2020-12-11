using ApiSGCOlimpiada.Models;
using OlimpiadaCompras.Data;
using OlimpiadaCompras.Telas.Avaliador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnEntrar_ClickAsync(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;
            var usuarioLogado = await HttpUsuarios.Login(usuario);
            if (usuarioLogado != null)
            {
                if (usuarioLogado.FuncaoId == 1)
                {
                    FrmAreaCoordenacao form = new FrmAreaCoordenacao(usuarioLogado);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    FrmAreaAvaliador form = new FrmAreaAvaliador(usuarioLogado);
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Usuário e senha incorretos");
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
