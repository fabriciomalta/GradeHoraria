using System;
using GradeHoraria.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using CsvHelper;
using ExcelDataReader;

namespace GradeHoraria
{
    public partial class F_CadastroProfessor : Form
    {
        public MySqlConnection objConexao = new MySqlConnection();
        public MySqlCommand objCommand = new MySqlCommand();
        public MySqlDataReader objDados;

        public int indicador;

        public F_CadastroProfessor()
        {
            InitializeComponent();
            lbl_linha1.BackColor = Color.Transparent;
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProfessorModel professor = new ProfessorModel();
            professor.NomeProfessor = tb_nomeprofessor.Text;
            professor.Prontuário = tb_prontuario.Text;
            professor.Area = tb_area.Text;
            MySqlDataReader objDados;
            try
            {
                string strSQL = "insert into tb_professor( NOME_PROFESSOR, PRONTUARIO, AREA) values(";
                strSQL += "'" + professor.NomeProfessor + "',";
                strSQL += "'" + professor.Prontuário + "',";
                strSQL += "'" + professor.Area + "')";

                objCommand.Connection = objConexao;
                objCommand.CommandText = strSQL;

                objCommand.ExecuteNonQuery();
                
                //OBTER O ID DO PROFESSOR QUE ACABOU DE SER INSERIDO
                
                string strSQL3 = "select id_professor from tb_professor where PRONTUARIO =" + professor.Prontuário + "  LIMIT 1 ";
                objCommand.CommandText = strSQL3;
                objDados = objCommand.ExecuteReader();
                

                int idprofessor = 0 ;
                if (objDados.Read())
                {
                     idprofessor = Convert.ToInt32(objDados["id_professor"].ToString());
                }
                objConexao.Close();
                objConexao.Open();
                string strSQL4 = "select id_professor from tb_horarios where ID_PROFESSOR =" + idprofessor;
                objCommand.CommandText = strSQL4;
                objDados = objCommand.ExecuteReader();
                objDados.Read();
                if (!objDados.HasRows)
                {
                    criahorario(idprofessor, 0);
                }
                else
                {
                    criahorario(idprofessor, 1);
                }
                //select* count from tb_professor where ID_PROFESSOR =
                MessageBox.Show("Professor Registrado com sucesso!");
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro ao inserir");
            }
        }

        private void criahorario(int idprofessor, int method)
        {
            int[] horarios = new int[90];
            int flag;
            for (int i = 0; i <=89; i++)
            {
                PictureBox leitura;
                flag = i + 1;
                leitura = (PictureBox)this.Controls.Find("pcbfpa" + flag, true).First();
                if(leitura.Size == pcbdisp.Size)
                {
                    horarios[i] = 1;
                }
                else
                {
                    horarios[i] = 0;
                }
            }


            if (method == 0)
            {
                try
                {
                    //CASO NÃO TENHA REGISTRO DO PROFESSOR NA TABELA HORÁRIOS, IREMOS INSERIR
                    string concatenatesql = "";

                    string strSQL = "insert into tb_horarios( M1,M2,M3,M4,M5,M6,T1,T2,T3,T4,N1,N2,N3,N4,N5,DIAS_SEMANA,ID_PROFESSOR,ID_CURSO)values(";

                    for (int i = 0; i < 15; i++)
                    {
                        concatenatesql += "'" + horarios[i] + "',";
                    }
                    strSQL += concatenatesql;
                    strSQL += "'" + "SEGUNDA" + "',";
                    strSQL += "'" + idprofessor + "',";
                    strSQL += "'" + "0" + "')";
                    concatenatesql = "";
                    ////////////////////////////////////////////////////////////////
                    objCommand.CommandText = strSQL;
                    objConexao.Close();
                    objConexao.Open();
                    objCommand.ExecuteNonQuery();

                    strSQL = "insert into tb_horarios( M1,M2,M3,M4,M5,M6,T1,T2,T3,T4,N1,N2,N3,N4,N5,DIAS_SEMANA,ID_PROFESSOR,ID_CURSO)values(";

                    for (int i = 15; i < 30; i++)
                    {
                        concatenatesql += "'" + horarios[i] + "',";
                    }
                    strSQL += concatenatesql;
                    strSQL += "'" + "TERCA" + "',";
                    strSQL += "'" + idprofessor + "',";
                    strSQL += "'" + "0" + "')";
                    concatenatesql = "";
                    objCommand.CommandText = strSQL;
                    ////////////////////////////////////////////////////////////////
                    objConexao.Close();
                    objConexao.Open();
                    objCommand.ExecuteNonQuery();

                    strSQL = "insert into tb_horarios( M1,M2,M3,M4,M5,M6,T1,T2,T3,T4,N1,N2,N3,N4,N5,DIAS_SEMANA,ID_PROFESSOR,ID_CURSO)values(";

                    for (int i = 30; i < 45; i++)
                    {
                        concatenatesql += "'" + horarios[i] + "',";
                    }
                    strSQL += concatenatesql;
                    strSQL += "'" + "QUARTA" + "',";
                    strSQL += "'" + idprofessor + "',";
                    strSQL += "'" + "0" + "')";
                    concatenatesql = "";
                    ////////////////////////////////////////////////////////////////
                    ///
                    objCommand.CommandText = strSQL;
                    objConexao.Close();
                    objConexao.Open();
                    objCommand.ExecuteNonQuery();

                    strSQL = "insert into tb_horarios( M1,M2,M3,M4,M5,M6,T1,T2,T3,T4,N1,N2,N3,N4,N5,DIAS_SEMANA,ID_PROFESSOR,ID_CURSO)values(";
                    for (int i = 45; i < 60; i++)
                    {
                        concatenatesql += "'" + horarios[i] + "',";
                    }
                    strSQL += concatenatesql;
                    strSQL += "'" + "QUINTA" + "',";
                    strSQL += "'" + idprofessor + "',";
                    strSQL += "'" + "0" + "')";
                    concatenatesql = "";
                    ////////////////////////////////////////////////////////////////
                    objCommand.CommandText = strSQL;
                    objConexao.Close();
                    objConexao.Open();
                    objCommand.ExecuteNonQuery();

                    strSQL = "insert into tb_horarios( M1,M2,M3,M4,M5,M6,T1,T2,T3,T4,N1,N2,N3,N4,N5,DIAS_SEMANA,ID_PROFESSOR,ID_CURSO)values(";
                    for (int i = 60; i < 75; i++)
                    {
                        concatenatesql += "'" + horarios[i] + "',";
                    }
                    strSQL += concatenatesql;
                    strSQL += "'" + "SEXTA" + "',";
                    strSQL += "'" + idprofessor + "',";
                    strSQL += "'" + "0" + "')";
                    concatenatesql = "";
                    ////////////////////////////////////////////////////////////////
                    objCommand.CommandText = strSQL;
                    objConexao.Close();
                    objConexao.Open();
                    objCommand.ExecuteNonQuery();

                    strSQL = "insert into tb_horarios( M1,M2,M3,M4,M5,M6,T1,T2,T3,T4,N1,N2,N3,N4,N5,DIAS_SEMANA,ID_PROFESSOR,ID_CURSO)values(";
                    for (int i = 75; i < 90; i++)
                    {
                        concatenatesql += "'" + horarios[i] + "',";
                    }
                    strSQL += concatenatesql;
                    strSQL += "'" + "SABADO" + "',";
                    strSQL += "'" + idprofessor + "',";
                    strSQL += "'" + "0" + "')";
                    objCommand.CommandText = strSQL;
                    objConexao.Close();
                    objConexao.Open();
                    objCommand.ExecuteNonQuery();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Erro inserção FPA");
                }
                
            }
            else
            {

            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void abrirconexao()
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
        private void F_CadastroProfessor_Load(object sender, EventArgs e)
        {
            abrirconexao();
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void lbl_53_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            if (pcbdisp.ImageLocation.Equals(pcbdisp.ImageLocation))
            {
                MessageBox.Show("TESTE");
            }
        }

        private void pcbdisp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(pcbdisp.Image));

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa16);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (pcbdisp.Image == pcbdisp.Image) {
                pcbdisp.Image = pcbindisp.Image;
                indicador = 1;
            }
            else
            {
                pcbdisp.Image = pcbdisp.Image;
                indicador = 0;
            }
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox77_Click(object sender, EventArgs e)
        {

            inverterobjeto(pcbfpa1);
        }

        private void inverterobjeto(PictureBox inverter)
        {
            if (inverter.Size.Equals(pcbindisp.Size))
            {
                inverter.Image = pcbdisp.Image;
                inverter.Size = pcbdisp.Size;
            }
            else if (inverter.Size.Equals(pcbdisp.Size))
            {
                inverter.Image = pcbindisp.Image;
                inverter.Size = pcbindisp.Size;
            }
        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa46);
        }

        private void backuplixo()
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = FD.FileName;

                System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);

                //OR

                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                //etc
                var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
                var records = csv.GetRecords<LeituraFPA>();
            }
        }

        DataTableCollection dataTableCollection;
        DataTable dt;
        private void btnuploadFPA_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //lblfpa.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            dataTableCollection = result.Tables;

                            //foreach (DataTable table in dataTableCollection)
                            //{

                            //}
                            //cboData.DataSource = null;
                            //cboSheet.Items.Clear();
                            List<string> diasSegunda = new List<string>();
                            List<string> diasTerca = new List<string>();
                            List<string> diasQua = new List<string>();
                            List<string> diasQui = new List<string>();
                            List<string> diasSexta = new List<string>();
                            List<string> diasSab = new List<string>();

                            //jose = dataTableCollection.Cast<DataTable>().Select(t => t.tableName).ToArray<string>();
                            //jose = dataTableCollection[0].Rows[15]["Column8"].ToString();
                            for (int i = 16; i <= 36; i++)
                            {
                                diasSegunda.Add(dataTableCollection[0].Rows[i]["Column8"].ToString());
                                diasTerca.Add(dataTableCollection[0].Rows[i]["Column12"].ToString());
                                diasQua.Add(dataTableCollection[0].Rows[i]["Column16"].ToString());
                                diasQui.Add(dataTableCollection[0].Rows[i]["Column20"].ToString());
                                diasSexta.Add(dataTableCollection[0].Rows[i]["Column24"].ToString());
                                diasSab.Add(dataTableCollection[0].Rows[i]["Column28"].ToString());
                            }
                            AtualizaVisual(diasSegunda, diasTerca, diasQua, diasQui, diasSexta, diasSab);
                            //MessageBox.Show("Oi");
                            //cboSheet.Items.AddRange(dataTableCollection.Cast<DataTable>()
                            //  .Select(t => t.TableName).ToArray<string>());
                        }
                    }
                }
            }
        }

        private void attdia(int oi)
        {
            PictureBox leitura;
            leitura = (PictureBox)this.Controls.Find("pcbfpa" + oi, true).First();
            leitura.Image = pcbdisp.Image;
            leitura.Size = pcbdisp.Size;
        }
        private void AtualizaVisual(List<string> diasSegunda, List<string> diasTerca, 
                                    List<string> diasQua, List<string> diasQui, 
                                    List<string> diasSexta, List<string> diasSab)
        {
            //leituraColumn(0, 5);
            //leituraColumn(0, 3);
            //leituraColumn(0, 5);
            //ATUALIZAR MANHÃ
            int oi = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (diasSegunda[i].Equals('X'))
                {
                    oi = i;
                    attdia(oi);
                }
                if (diasTerca[i]=="X")
                {                                      
                    oi = i + 16;
                    attdia(oi);
                }
                if (diasQua[i] == "X")
                {
                    oi = i + 31;
                    attdia(oi);
                }
                if (diasQui[i] == "X")
                {
                    oi = i + 46;
                    attdia(oi);
                }
                if (diasSexta[i] == "X")
                {
                    oi = i + 61;
                    attdia(oi);
                }
                if (diasSab[i] == "X")
                {
                    oi = i + 76;
                    attdia(oi);
                }
            }
            //ATUALIZAR TARDE
            for (int i = 0; i <= 3; i++)
            {
                if (diasSegunda[i + 10].Equals('X'))
                {
                    oi = i+7;
                    attdia(oi);
                }
                if (diasTerca[i + 10] == "X")
                {
                    oi = i + 22;
                    attdia(oi);
                }
                if (diasQua[i + 10] == "X")
                {
                    oi = i + 37;
                    attdia(oi);
                }
                if (diasQui[i + 10] == "X")
                {
                    oi = i + 52;
                    attdia(oi);
                }
                if (diasSexta[i + 10] == "X")
                {
                    oi = i + 67;
                    attdia(oi);
                }
                if (diasSab[i + 10] == "X")
                {
                    oi = i + 82;
                    attdia(oi);
                }
            }
            //ATUALIZAR NOITE
            for (int i = 0; i <= 4; i++)
            {
                if (diasSegunda[i+16].Equals('X'))
                {
                    oi = i + 11;
                    attdia(oi);
                }
                if (diasTerca[i + 16] == "X")
                {
                    oi = i + 26;
                    attdia(oi);
                }
                if (diasQua[i + 16] == "X")
                {
                    oi = i + 41;
                    attdia(oi);
                }
                if (diasQui[i + 16] == "X")
                {
                    oi = i + 56;
                    attdia(oi);
                }
                if (diasSexta[i + 16] == "X")
                {
                    oi = i + 71;
                    attdia(oi);
                }
                if (diasSab[i + 16] == "X")
                {
                    oi = i + 86;
                    attdia(oi);
                }
            }
        }

        private void leituraColumn(int inicio, int fim) {
            for (int i = inicio; i <= fim; i++)
            {

            }

        }

        public class LeituraFPA
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void pcbfpa8_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa8);
        }

        private void pcbfpa9_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa9);
        }

        private void pcbfpa10_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa10);
        }

        private void pcbfpa11_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa11);
        }

        private void pcbfpa12_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa12);
        }

        private void pcbfpa13_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa13);
        }

        private void pcbfpa14_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa14);
        }

        private void pcbfpa15_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa15);
        }

        private void pcbfpa30_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa30);
        }

        private void pcbfpa29_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa29);
        }

        private void pcbfpa28_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa28);
        }

        private void pcbfpa27_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa27);
        }

        private void pcbfpa26_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa26);
        }

        private void pcbfpa25_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa25);
        }

        private void pcbfpa24_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa24);
        }

        private void pcbfpa23_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa23);
        }

        private void pcbfpa22_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa22);
        }

        private void pcbfpa21_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa21);
        }

        private void pcbfpa20_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa20);
        }

        private void pcbfpa19_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa19);
        }

        private void pcbfpa18_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa18);
        }

        private void pcbfpa17_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa17);
        }

        private void pcbfpa31_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa31);
        }

        private void pcbfpa32_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa32);
        }

        private void pcbfpa33_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa33);
        }

        private void pcbfpa34_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa34);
        }

        private void pcbfpa35_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa35);
        }

        private void pcbfpa36_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa36);
        }

        private void pcbfpa37_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa37);
        }

        private void pcbfpa38_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa38);
        }

        private void pcbfpa39_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa39);
        }

        private void pcbfpa40_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa40);
        }

        private void pcbfpa41_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa41);
        }

        private void pcbfpa42_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa42);
        }

        private void pcbfpa43_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa43);
        }

        private void pcbfpa44_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa44);
        }

        private void pcbfpa45_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa45);
        }

        private void pcbfpa60_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa60);
        }

        private void pcbfpa59_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa59);
        }

        private void pcbfpa58_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa58);
        }

        private void pcbfpa57_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa57);
        }

        private void pcbfpa56_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa56);
        }

        private void pcbfpa55_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa55);
        }

        private void pcbfpa53_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa53);
        }

        private void pcbfpa54_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa54);
        }

        private void pcbfpa51_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa51);
        }

        private void pcbfpa52_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa52);
        }

        private void pcbfpa50_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa50);
        }

        private void pcbfpa49_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa49);
        }

        private void pcbfpa48_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa48);
        }

        private void pcbfpa47_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa47);
        }

        private void pcbfpa61_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa61);
        }

        private void pcbfpa62_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa62);
        }

        private void pcbfpa63_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa63);
        }

        private void pcbfpa64_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa64);
        }

        private void pcbfpa65_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa65);
        }

        private void pcbfpa66_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa66);
        }

        private void pcbfpa67_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa67);
        }

        private void pcbfpa68_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa68);
        }

        private void pcbfpa69_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa69);
        }

        private void pcbfpa70_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa70);
        }

        private void pcbfpa71_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa71);
        }

        private void pcbfpa72_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa72);
        }

        private void pcbfpa73_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa73);
        }

        private void pcbfpa2_Click(object sender, EventArgs e)
        {
          inverterobjeto(pcbfpa2);
        }

        private void pcbfpa1_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa1);
        }

        private void pcbfpa2_Click_1(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa2);
        }

        private void pcbfpa3_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa3);
        }

        private void pcbfpa4_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa4);
        }

        private void pcbfpa5_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa5);
        }

        private void pcbfpa6_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa6);
        }

        private void pcbfpa7_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa7);
        }

        private void pcbfpa74_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa74);
        }

        private void pcbfpa75_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa75);
        }

        private void pcbfpa76_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa76);
        }

        private void pcbfpa77_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa77);
        }

        private void pcbfpa78_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa78);
        }

        private void pcbfpa79_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa79);
        }

        private void pcbfpa80_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa80);
        }

        private void pcbfpa81_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa81);
        }

        private void pcbfpa82_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa82);
        }

        private void pcbfpa83_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa83);
        }

        private void pcbfpa84_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa84);
        }

        private void pcbfpa85_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa85);
        }

        private void pcbfpa86_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa86);
        }

        private void pcbfpa87_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa87);
        }

        private void pcbfpa88_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa88);
        }

        private void pcbfpa89_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa89);
        }

        private void pcbfpa90_Click(object sender, EventArgs e)
        {
            inverterobjeto(pcbfpa90);
        }
    }
}
