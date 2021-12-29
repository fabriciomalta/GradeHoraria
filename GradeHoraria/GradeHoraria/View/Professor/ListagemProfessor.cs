using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeHoraria.View.Professor
{
    public partial class ListagemProfessor : Form
    {
        public MySqlConnection objCnx = new MySqlConnection();
        public MySqlCommand objCmd = new MySqlCommand();
        public MySqlDataReader objDados;
        public ListagemProfessor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opa", "EM CONSTRUÇÃO!");
        }

        private void ListagemProfessor_Load(object sender, EventArgs e)
        {
            try
            {
                objCnx.ConnectionString = "Server=localhost;Database=db_grade;user=root;pwd=";
                objCnx.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro na conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            objCnx.Close();
            Close();
        }

        private void btnConsultarLista_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "select * from tb_professor";

                objCmd.Connection = objCnx;
                objCmd.CommandText = strSQL;
                objDados = objCmd.ExecuteReader();

                if (objDados.HasRows)
                {
                    dgvListaDados.Rows.Clear();

                    while (objDados.Read())
                    {
                        dgvListaDados.Rows.Add(objDados["ID_PROFESSOR"].ToString(), objDados["NOME_PROFESSOR"].ToString(), objDados["PRONTUARIO"].ToString(), objDados["AREA"].ToString());
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvListaDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
