using GradeHoraria.View.Professor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeHoraria.View
{
    public partial class HomeDashboard : Form
    {
        public HomeDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void salasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void professorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListagemProfessor listprofessor = new ListagemProfessor();
            listprofessor.ShowDialog();

        }
    }
}
