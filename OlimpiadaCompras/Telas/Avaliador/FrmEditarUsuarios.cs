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

namespace OlimpiadaCompras.Telas
{
    public partial class FrmEditarUsuarios : Form
    {
        private Usuario usuarioLogado;

        public FrmEditarUsuarios(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
        }
    }
}
