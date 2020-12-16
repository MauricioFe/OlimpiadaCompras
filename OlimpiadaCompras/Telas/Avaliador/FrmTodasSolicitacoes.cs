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

namespace OlimpiadaCompras.Telas.Avaliador
{
    public partial class FrmTodasSolicitacoes : Form
    {
        private Usuario usuarioLogado;

        public FrmTodasSolicitacoes(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
        }
    }
}
