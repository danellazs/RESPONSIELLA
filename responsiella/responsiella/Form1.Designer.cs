namespace responsiella
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TbName = new TextBox();
            cbKaryawan = new ComboBox();
            BtnInsert = new Button();
            BtnEdit = new Button();
            BtnDelete = new Button();
            dgvDataTable = new DataGridView();
            cbJabatan = new ComboBox();
            label5 = new Label();
            BtnLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDataTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(44, 18);
            label1.Name = "label1";
            label1.Size = new Size(68, 30);
            label1.TabIndex = 0;
            label1.Text = "LOGO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 66);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 1;
            label2.Text = "Nama Karyawan:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 115);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 2;
            label3.Text = "Dep. Karyawan   :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(493, 34);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 3;
            label4.Text = "label4";
            // 
            // TbName
            // 
            TbName.Location = new Point(134, 63);
            TbName.Name = "TbName";
            TbName.Size = new Size(121, 23);
            TbName.TabIndex = 4;
            // 
            // cbKaryawan
            // 
            cbKaryawan.FormattingEnabled = true;
            cbKaryawan.Location = new Point(134, 112);
            cbKaryawan.Name = "cbKaryawan";
            cbKaryawan.Size = new Size(121, 23);
            cbKaryawan.TabIndex = 5;
            // 
            // BtnInsert
            // 
            BtnInsert.Location = new Point(21, 225);
            BtnInsert.Name = "BtnInsert";
            BtnInsert.Size = new Size(75, 23);
            BtnInsert.TabIndex = 6;
            BtnInsert.Text = "INSERT";
            BtnInsert.UseVisualStyleBackColor = true;
            BtnInsert.Click += BtnInsert_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Location = new Point(134, 225);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(75, 23);
            BtnEdit.TabIndex = 7;
            BtnEdit.Text = "EDIT";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(256, 225);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(75, 23);
            BtnDelete.TabIndex = 8;
            BtnDelete.Text = "DELETE";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // dgvDataTable
            // 
            dgvDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataTable.Location = new Point(21, 274);
            dgvDataTable.Name = "dgvDataTable";
            dgvDataTable.RowTemplate.Height = 25;
            dgvDataTable.Size = new Size(658, 150);
            dgvDataTable.TabIndex = 9;
            dgvDataTable.CellContentClick += dgvDataTable_CellContentClick;
            // 
            // cbJabatan
            // 
            cbJabatan.FormattingEnabled = true;
            cbJabatan.Location = new Point(134, 162);
            cbJabatan.Name = "cbJabatan";
            cbJabatan.Size = new Size(121, 23);
            cbJabatan.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 165);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 11;
            label5.Text = "Dep. Jabatan      :";
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(325, 59);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(75, 23);
            BtnLoad.TabIndex = 12;
            BtnLoad.Text = "Load";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(BtnLoad);
            Controls.Add(label5);
            Controls.Add(cbJabatan);
            Controls.Add(dgvDataTable);
            Controls.Add(BtnDelete);
            Controls.Add(BtnEdit);
            Controls.Add(BtnInsert);
            Controls.Add(cbKaryawan);
            Controls.Add(TbName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDataTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TbName;
        private ComboBox cbKaryawan;
        private Button BtnInsert;
        private Button BtnEdit;
        private Button BtnDelete;
        private DataGridView dgvDataTable;
        private ComboBox cbJabatan;
        private Label label5;
        private Button BtnLoad;
    }
}