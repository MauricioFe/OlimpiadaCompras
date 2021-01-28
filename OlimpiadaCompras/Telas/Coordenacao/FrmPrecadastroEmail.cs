using OlimpiadaCompras.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Telas.Coordenacao
{
    public partial class FrmPrecadastroEmail : Form
    {
        private Usuario usuarioLogado;
        private long idSolicitacao;

        public FrmPrecadastroEmail(Usuario usuario, long idSolicitacao)
        {
            this.usuarioLogado = usuario;
            this.idSolicitacao = idSolicitacao;
            InitializeComponent();
        }
    }
}
