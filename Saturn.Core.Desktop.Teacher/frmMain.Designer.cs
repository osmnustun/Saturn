namespace Saturn.Core.Desktop.Teacher
{
    partial class frmMain
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
            tabControl1 = new TabControl();
            tpStudents = new TabPage();
            dbStudents = new GroupBox();
            dgStudent = new DataGridView();
            tpRawData = new TabPage();
            groupBox1 = new GroupBox();
            dgvRawData = new DataGridView();
            tpAttendance = new TabPage();
            groupBox2 = new GroupBox();
            dgAttendance = new DataGridView();
            tpLessonPlans = new TabPage();
            btnLessonUpdate = new Button();
            btnLessonRemove = new Button();
            btnLessonAdd = new Button();
            cmbDay = new ComboBox();
            label4 = new Label();
            txtEndTime = new TextBox();
            label3 = new Label();
            txtStartTime = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtLessonName = new TextBox();
            groupBox3 = new GroupBox();
            dgLessonPlans = new DataGridView();
            tabControl1.SuspendLayout();
            tpStudents.SuspendLayout();
            dbStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgStudent).BeginInit();
            tpRawData.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRawData).BeginInit();
            tpAttendance.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAttendance).BeginInit();
            tpLessonPlans.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgLessonPlans).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpStudents);
            tabControl1.Controls.Add(tpRawData);
            tabControl1.Controls.Add(tpAttendance);
            tabControl1.Controls.Add(tpLessonPlans);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1081, 723);
            tabControl1.TabIndex = 0;
            // 
            // tpStudents
            // 
            tpStudents.Controls.Add(dbStudents);
            tpStudents.Location = new Point(4, 24);
            tpStudents.Name = "tpStudents";
            tpStudents.Padding = new Padding(3);
            tpStudents.Size = new Size(1073, 695);
            tpStudents.TabIndex = 0;
            tpStudents.Text = "Öğrenciler";
            tpStudents.UseVisualStyleBackColor = true;
            // 
            // dbStudents
            // 
            dbStudents.Controls.Add(dgStudent);
            dbStudents.Dock = DockStyle.Left;
            dbStudents.Location = new Point(3, 3);
            dbStudents.Name = "dbStudents";
            dbStudents.Size = new Size(614, 689);
            dbStudents.TabIndex = 0;
            dbStudents.TabStop = false;
            // 
            // dgStudent
            // 
            dgStudent.AllowUserToAddRows = false;
            dgStudent.AllowUserToDeleteRows = false;
            dgStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgStudent.Dock = DockStyle.Fill;
            dgStudent.Location = new Point(3, 19);
            dgStudent.Name = "dgStudent";
            dgStudent.ReadOnly = true;
            dgStudent.Size = new Size(608, 667);
            dgStudent.TabIndex = 0;
            // 
            // tpRawData
            // 
            tpRawData.Controls.Add(groupBox1);
            tpRawData.Location = new Point(4, 24);
            tpRawData.Name = "tpRawData";
            tpRawData.Padding = new Padding(3);
            tpRawData.Size = new Size(1073, 695);
            tpRawData.TabIndex = 1;
            tpRawData.Text = "Ham Veriler";
            tpRawData.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvRawData);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(614, 689);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // dgvRawData
            // 
            dgvRawData.AllowUserToAddRows = false;
            dgvRawData.AllowUserToDeleteRows = false;
            dgvRawData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRawData.Dock = DockStyle.Fill;
            dgvRawData.Location = new Point(3, 19);
            dgvRawData.Name = "dgvRawData";
            dgvRawData.ReadOnly = true;
            dgvRawData.Size = new Size(608, 667);
            dgvRawData.TabIndex = 0;
            // 
            // tpAttendance
            // 
            tpAttendance.Controls.Add(groupBox2);
            tpAttendance.Location = new Point(4, 24);
            tpAttendance.Name = "tpAttendance";
            tpAttendance.Padding = new Padding(3);
            tpAttendance.Size = new Size(1073, 695);
            tpAttendance.TabIndex = 2;
            tpAttendance.Text = "Yoklamalar";
            tpAttendance.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgAttendance);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(614, 689);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // dgAttendance
            // 
            dgAttendance.AllowUserToAddRows = false;
            dgAttendance.AllowUserToDeleteRows = false;
            dgAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAttendance.Dock = DockStyle.Fill;
            dgAttendance.Location = new Point(3, 19);
            dgAttendance.Name = "dgAttendance";
            dgAttendance.ReadOnly = true;
            dgAttendance.Size = new Size(608, 667);
            dgAttendance.TabIndex = 0;
            // 
            // tpLessonPlans
            // 
            tpLessonPlans.Controls.Add(btnLessonUpdate);
            tpLessonPlans.Controls.Add(btnLessonRemove);
            tpLessonPlans.Controls.Add(btnLessonAdd);
            tpLessonPlans.Controls.Add(cmbDay);
            tpLessonPlans.Controls.Add(label4);
            tpLessonPlans.Controls.Add(txtEndTime);
            tpLessonPlans.Controls.Add(label3);
            tpLessonPlans.Controls.Add(txtStartTime);
            tpLessonPlans.Controls.Add(label2);
            tpLessonPlans.Controls.Add(label1);
            tpLessonPlans.Controls.Add(txtLessonName);
            tpLessonPlans.Controls.Add(groupBox3);
            tpLessonPlans.Location = new Point(4, 24);
            tpLessonPlans.Name = "tpLessonPlans";
            tpLessonPlans.Padding = new Padding(3);
            tpLessonPlans.Size = new Size(1073, 695);
            tpLessonPlans.TabIndex = 3;
            tpLessonPlans.Text = "Ders Programı";
            tpLessonPlans.UseVisualStyleBackColor = true;
            // 
            // btnLessonUpdate
            // 
            btnLessonUpdate.Location = new Point(653, 292);
            btnLessonUpdate.Name = "btnLessonUpdate";
            btnLessonUpdate.Size = new Size(393, 23);
            btnLessonUpdate.TabIndex = 6;
            btnLessonUpdate.Text = "GÜNCELLE";
            btnLessonUpdate.UseVisualStyleBackColor = true;
            // 
            // btnLessonRemove
            // 
            btnLessonRemove.Location = new Point(653, 263);
            btnLessonRemove.Name = "btnLessonRemove";
            btnLessonRemove.Size = new Size(393, 23);
            btnLessonRemove.TabIndex = 5;
            btnLessonRemove.Text = "SİL";
            btnLessonRemove.UseVisualStyleBackColor = true;
            // 
            // btnLessonAdd
            // 
            btnLessonAdd.Location = new Point(653, 234);
            btnLessonAdd.Name = "btnLessonAdd";
            btnLessonAdd.Size = new Size(393, 23);
            btnLessonAdd.TabIndex = 4;
            btnLessonAdd.Text = "EKLE";
            btnLessonAdd.UseVisualStyleBackColor = true;
            btnLessonAdd.Click += btnLessonAdd_Click;
            // 
            // cmbDay
            // 
            cmbDay.FormattingEnabled = true;
            cmbDay.Location = new Point(779, 87);
            cmbDay.Name = "cmbDay";
            cmbDay.Size = new Size(267, 23);
            cmbDay.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(653, 179);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 3;
            label4.Text = "BİTİŞ SAATİ :";
            // 
            // txtEndTime
            // 
            txtEndTime.Location = new Point(779, 171);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.Size = new Size(267, 23);
            txtEndTime.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(653, 137);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 3;
            label3.Text = "BAŞLAMA SAATİ :";
            // 
            // txtStartTime
            // 
            txtStartTime.Location = new Point(779, 129);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.Size = new Size(267, 23);
            txtStartTime.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(653, 95);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 3;
            label2.Text = "GÜNÜ :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(653, 53);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 3;
            label1.Text = "DERS ADI :";
            // 
            // txtLessonName
            // 
            txtLessonName.Location = new Point(779, 45);
            txtLessonName.Name = "txtLessonName";
            txtLessonName.Size = new Size(267, 23);
            txtLessonName.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgLessonPlans);
            groupBox3.Dock = DockStyle.Left;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(614, 689);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            // 
            // dgLessonPlans
            // 
            dgLessonPlans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgLessonPlans.Dock = DockStyle.Fill;
            dgLessonPlans.Location = new Point(3, 19);
            dgLessonPlans.Name = "dgLessonPlans";
            dgLessonPlans.Size = new Size(608, 667);
            dgLessonPlans.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 723);
            Controls.Add(tabControl1);
            Name = "frmMain";
            Text = "Saturn Teacher";
            Load += frmMain_Load;
            tabControl1.ResumeLayout(false);
            tpStudents.ResumeLayout(false);
            dbStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgStudent).EndInit();
            tpRawData.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRawData).EndInit();
            tpAttendance.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAttendance).EndInit();
            tpLessonPlans.ResumeLayout(false);
            tpLessonPlans.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgLessonPlans).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpStudents;
        private TabPage tpRawData;
        private GroupBox dbStudents;
        private DataGridView dgStudent;
        private GroupBox groupBox1;
        private DataGridView dgvRawData;
        private TabPage tpAttendance;
        private GroupBox groupBox2;
        private DataGridView dgAttendance;
        private TabPage tpLessonPlans;
        private GroupBox groupBox3;
        private DataGridView dgLessonPlans;
        private ComboBox cmbDay;
        private Label label4;
        private TextBox txtEndTime;
        private Label label3;
        private TextBox txtStartTime;
        private Label label2;
        private Label label1;
        private TextBox txtLessonName;
        private Button btnLessonAdd;
        private Button btnLessonUpdate;
        private Button btnLessonRemove;
    }
}
