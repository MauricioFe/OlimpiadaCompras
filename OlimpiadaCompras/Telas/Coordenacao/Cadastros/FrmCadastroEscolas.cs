using ApiSGCOlimpiada.Models;
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

        public FrmCadastroEscolas(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
        }

        private void FrmCadastrarEscolas_Load(object sender, EventArgs e)
        {

        }
    }
}
