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
        public FrmCadastroUsuarios()
        {
            InitializeComponent();
        }

        private void FrmCadastroUsuarios_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private async void AtualizaGrid()
        {
            var usuarios = await HttpUsuarios.GetAllUsuarios();
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
