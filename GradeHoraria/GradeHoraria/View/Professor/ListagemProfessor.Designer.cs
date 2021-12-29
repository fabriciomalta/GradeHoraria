
namespace GradeHoraria.View.Professor
{
    partial class ListagemProfessor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListaDados = new System.Windows.Forms.DataGridView();
            this.idprofessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.professornome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.professorprontuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.professorarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConsultarLista = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaDados
            // 
            this.dgvListaDados.AllowUserToAddRows = false;
            this.dgvListaDados.AllowUserToDeleteRows = false;
            this.dgvListaDados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvListaDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idprofessor,
            this.professornome,
            this.professorprontuario,
            this.professorarea});
            this.dgvListaDados.Location = new System.Drawing.Point(12, 65);
            this.dgvListaDados.Name = "dgvListaDados";
            this.dgvListaDados.ReadOnly = true;
            this.dgvListaDados.RowHeadersVisible = false;
            this.dgvListaDados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvListaDados.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaDados.Size = new System.Drawing.Size(775, 281);
            this.dgvListaDados.TabIndex = 2;
            this.dgvListaDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaDados_CellClick);
            // 
            // idprofessor
            // 
            this.idprofessor.HeaderText = "Código";
            this.idprofessor.MinimumWidth = 8;
            this.idprofessor.Name = "idprofessor";
            this.idprofessor.ReadOnly = true;
            this.idprofessor.Width = 50;
            // 
            // professornome
            // 
            this.professornome.FillWeight = 150F;
            this.professornome.HeaderText = "Nome";
            this.professornome.Name = "professornome";
            this.professornome.ReadOnly = true;
            this.professornome.Width = 300;
            // 
            // professorprontuario
            // 
            this.professorprontuario.HeaderText = "Prontuário";
            this.professorprontuario.Name = "professorprontuario";
            this.professorprontuario.ReadOnly = true;
            this.professorprontuario.Width = 300;
            // 
            // professorarea
            // 
            this.professorarea.HeaderText = "Área";
            this.professorarea.Name = "professorarea";
            this.professorarea.ReadOnly = true;
            this.professorarea.Width = 120;
            // 
            // btnConsultarLista
            // 
            this.btnConsultarLista.Location = new System.Drawing.Point(632, 352);
            this.btnConsultarLista.Name = "btnConsultarLista";
            this.btnConsultarLista.Size = new System.Drawing.Size(75, 40);
            this.btnConsultarLista.TabIndex = 4;
            this.btnConsultarLista.Text = "&Consultar Lista";
            this.btnConsultarLista.UseVisualStyleBackColor = true;
            this.btnConsultarLista.Click += new System.EventHandler(this.btnConsultarLista_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(713, 352);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 40);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(183, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListagemProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConsultarLista);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dgvListaDados);
            this.Name = "ListagemProfessor";
            this.Text = "ListagemProfessor";
            this.Load += new System.EventHandler(this.ListagemProfessor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaDados;
        private System.Windows.Forms.Button btnConsultarLista;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprofessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn professornome;
        private System.Windows.Forms.DataGridViewTextBoxColumn professorprontuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn professorarea;
    }
}