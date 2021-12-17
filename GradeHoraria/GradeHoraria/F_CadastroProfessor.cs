using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeHoraria
{
    public partial class F_CadastroProfessor : Form
    {
        public F_CadastroProfessor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CadastroProfessor f_CadastroProfessor = new F_CadastroProfessor();
            f_CadastroProfessor.ShowDialog();
        }

        private void salaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CadastroSala f_CadastroSala = new F_CadastroSala();
            f_CadastroSala.ShowDialog();
        }

        private void dIsciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CadastroDisciplina f_CadastroDisciplina = new F_CadastroDisciplina();
            f_CadastroDisciplina.ShowDialog();
        }

        private void fPAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CadastroFPA f_CadastroFPA = new F_CadastroFPA();
            f_CadastroFPA.ShowDialog();
        }
    }
}
