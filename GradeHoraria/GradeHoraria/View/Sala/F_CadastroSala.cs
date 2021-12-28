using GradeHoraria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GradeHoraria
{
    public partial class F_CadastroSala : Form 
    {

        public MySqlConnection objConexao = new MySqlConnection();
        public MySqlCommand objCommand = new MySqlCommand();
        public MySqlDataReader objDados;

        public F_CadastroSala()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }


        private void button1_Click(object sender, EventArgs e)
        {

            SalaModel sala = new SalaModel();
            sala.NomeSala = tb_nomesala.Text;
            sala.SiglaSala = tb_siglasala.Text;
            sala.Tipo = Convert.ToInt32(tb_tipo.Text);

            /*var sqlDB = DbConnect.SqlDB();

            var cmd = sqlDB.GetStoredProcCommand("PR_SALA");
            sqlDB.AddInParameter(cmd, "@NOME_SALA", DbType.String, sala.NomeSala);
            sqlDB.AddInParameter(cmd, "@TIPO_SALA", DbType.Int32, sala.Tipo);
            sqlDB.AddInParameter(cmd, "@SIGLA", DbType.String, sala.SiglaSala);
            */



            try
            {
                string strSQL = "insert into tb_sala( NOME_SALA, TIPO_SALA, SIGLA) values(";
                strSQL += "'" + sala.NomeSala + "',";
                strSQL += "'" + sala.SiglaSala + "',";
                strSQL += "'" + sala.Tipo + "')";


                objCommand.Connection = objConexao;
                objCommand.CommandText = strSQL;
                objCommand.ExecuteNonQuery();

                MessageBox.Show("Registrado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro ao inserir");
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void F_CadastroSala_Load(object sender, EventArgs e)
        {
            try
            {
                objConexao.ConnectionString = "Server=localhost;Database=db_grade;user=root;password=";
                objConexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                objConexao.Close();
            }
        }
    }
}
