namespace SystemQuiche
{
    partial class frmVendasRecord1
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFaturaDateDe = new System.Windows.Forms.DateTimePicker();
            this.dtpFaturaDateAte = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDados = new System.Windows.Forms.Button();
            this.btnResetar = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnVerRelatorio = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1312, 665);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1304, 635);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Por data do Pedido";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.groupBox10);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1304, 635);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Por Valor Devido";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFaturaDateAte);
            this.groupBox1.Controls.Add(this.dtpFaturaDateDe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 87);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "De";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Até";
            // 
            // dtpFaturaDateDe
            // 
            this.dtpFaturaDateDe.CustomFormat = "dd/MM/yyyy";
            this.dtpFaturaDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFaturaDateDe.Location = new System.Drawing.Point(24, 42);
            this.dtpFaturaDateDe.Name = "dtpFaturaDateDe";
            this.dtpFaturaDateDe.Size = new System.Drawing.Size(120, 24);
            this.dtpFaturaDateDe.TabIndex = 106;
            // 
            // dtpFaturaDateAte
            // 
            this.dtpFaturaDateAte.CustomFormat = "dd/MM/yyyy";
            this.dtpFaturaDateAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFaturaDateAte.Location = new System.Drawing.Point(190, 42);
            this.dtpFaturaDateAte.Name = "dtpFaturaDateAte";
            this.dtpFaturaDateAte.Size = new System.Drawing.Size(120, 24);
            this.dtpFaturaDateAte.TabIndex = 107;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 99);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1017, 540);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVerRelatorio);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.btnResetar);
            this.groupBox2.Controls.Add(this.btnDados);
            this.groupBox2.Location = new System.Drawing.Point(354, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 87);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // btnDados
            // 
            this.btnDados.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDados.Location = new System.Drawing.Point(7, 26);
            this.btnDados.Name = "btnDados";
            this.btnDados.Size = new System.Drawing.Size(94, 40);
            this.btnDados.TabIndex = 0;
            this.btnDados.Text = "&Dados";
            this.btnDados.UseVisualStyleBackColor = true;
            this.btnDados.Click += new System.EventHandler(this.btnDados_Click);
            // 
            // btnResetar
            // 
            this.btnResetar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetar.Location = new System.Drawing.Point(106, 26);
            this.btnResetar.Name = "btnResetar";
            this.btnResetar.Size = new System.Drawing.Size(94, 40);
            this.btnResetar.TabIndex = 1;
            this.btnResetar.Text = "&Resetar";
            this.btnResetar.UseVisualStyleBackColor = true;
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(205, 26);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(129, 40);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "&Exportar p/ Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnVerRelatorio
            // 
            this.btnVerRelatorio.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRelatorio.Location = new System.Drawing.Point(337, 26);
            this.btnVerRelatorio.Name = "btnVerRelatorio";
            this.btnVerRelatorio.Size = new System.Drawing.Size(120, 40);
            this.btnVerRelatorio.TabIndex = 23;
            this.btnVerRelatorio.Text = "&Ver Relatório";
            this.btnVerRelatorio.UseVisualStyleBackColor = true;
            this.btnVerRelatorio.Click += new System.EventHandler(this.btnVerRelatorio_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1126, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(1031, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 142);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total";
            this.groupBox3.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Valor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Valor Pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Valor Devido";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 24);
            this.textBox1.TabIndex = 24;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 24);
            this.textBox2.TabIndex = 25;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(127, 99);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(124, 24);
            this.textBox3.TabIndex = 25;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 87);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "De";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(186, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Até";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(24, 42);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker2.TabIndex = 106;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker1.TabIndex = 107;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Location = new System.Drawing.Point(356, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(474, 87);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(18, 26);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 40);
            this.button5.TabIndex = 0;
            this.button5.Text = "&Dados";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(118, 26);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 40);
            this.button6.TabIndex = 1;
            this.button6.Text = "&Resetar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(218, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 40);
            this.button4.TabIndex = 2;
            this.button4.Text = "&Exportar p/ Excel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(347, 26);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(112, 40);
            this.button11.TabIndex = 24;
            this.button11.Text = "&Ver Relatórios";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.textBox10);
            this.groupBox10.Controls.Add(this.textBox11);
            this.groupBox10.Controls.Add(this.textBox12);
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(this.label17);
            this.groupBox10.Location = new System.Drawing.Point(1031, 92);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(265, 142);
            this.groupBox10.TabIndex = 22;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Total";
            this.groupBox10.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(18, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 18);
            this.label17.TabIndex = 22;
            this.label17.Text = "Valor";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 18);
            this.label14.TabIndex = 23;
            this.label14.Text = "Valor Devido";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 18);
            this.label15.TabIndex = 23;
            this.label15.Text = "Valor Pago";
            this.label15.Click += new System.EventHandler(this.label11_Click);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(127, 26);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(123, 24);
            this.textBox12.TabIndex = 24;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(127, 62);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(123, 24);
            this.textBox11.TabIndex = 25;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(127, 99);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(123, 24);
            this.textBox10.TabIndex = 26;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 99);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1017, 540);
            this.dataGridView2.TabIndex = 21;
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
            // 
            // frmVendasRecord1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1311, 664);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmVendasRecord1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Vendas";
            this.Load += new System.EventHandler(this.frmVendasRecord1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker dtpFaturaDateDe;
        internal System.Windows.Forms.DateTimePicker dtpFaturaDateAte;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnDados;
        internal System.Windows.Forms.Button btnResetar;
        internal System.Windows.Forms.Button btnVerRelatorio;
        internal System.Windows.Forms.Button btnExcel;
        public System.Windows.Forms.Label label9;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dateTimePicker2;
        internal System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Button button6;
        internal System.Windows.Forms.Button button5;
        internal System.Windows.Forms.Button button11;
        internal System.Windows.Forms.Button button4;
        internal System.Windows.Forms.GroupBox groupBox10;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox textBox12;
        internal System.Windows.Forms.TextBox textBox10;
        internal System.Windows.Forms.TextBox textBox11;
        internal System.Windows.Forms.DataGridView dataGridView2;
    }
}