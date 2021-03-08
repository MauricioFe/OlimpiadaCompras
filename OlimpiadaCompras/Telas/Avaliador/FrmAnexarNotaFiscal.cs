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
    public partial class FrmAnexarNotaFiscal : Form
    {
        public FrmAnexarNotaFiscal()
        {
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "pdf files | *.pdf";
            openFileDialog1.InitialDirectory = $@"{Environment.SpecialFolder.Desktop}";
            openFileDialog1.FileName = "nota fiscal";
            openFileDialog1.Title = "Selecione o orçamento no formato pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtAnexarPdf.Text = openFileDialog1.FileName;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }
    }
}
