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
            tpAttendance = new TabPage();
            gbReport = new GroupBox();
            wVReport = new Microsoft.Web.WebView2.WinForms.WebView2();
            groupBox2 = new GroupBox();
            dgAttendance = new DataGridView();
            groupBox4 = new GroupBox();
            tpStudents = new TabPage();
            webViewStudentReport = new Microsoft.Web.WebView2.WinForms.WebView2();
            dbStudents = new GroupBox();
            dgStudent = new DataGridView();
            txtSearchStudent = new TextBox();
            groupBox5 = new GroupBox();
            btnStudentUpdate = new Button();
            btnStudentRemove = new Button();
            btnStudentAdd = new Button();
            gbGroups = new GroupBox();
            label8 = new Label();
            txtClass = new TextBox();
            label7 = new Label();
            txtBilsemNo = new TextBox();
            label9 = new Label();
            txtUserName = new TextBox();
            label6 = new Label();
            txtFullName = new TextBox();
            label5 = new Label();
            tpRawData = new TabPage();
            groupBox1 = new GroupBox();
            dgvRawData = new DataGridView();
            tpLessonPlans = new TabPage();
            groupBox3 = new GroupBox();
            dgLessonPlans = new DataGridView();
            groupBox6 = new GroupBox();
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
            tabControl1.SuspendLayout();
            tpAttendance.SuspendLayout();
            gbReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wVReport).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAttendance).BeginInit();
            tpStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewStudentReport).BeginInit();
            dbStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgStudent).BeginInit();
            groupBox5.SuspendLayout();
            tpRawData.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRawData).BeginInit();
            tpLessonPlans.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgLessonPlans).BeginInit();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpAttendance);
            tabControl1.Controls.Add(tpStudents);
            tabControl1.Controls.Add(tpRawData);
            tabControl1.Controls.Add(tpLessonPlans);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1167, 723);
            tabControl1.TabIndex = 0;
            // 
            // tpAttendance
            // 
            tpAttendance.Controls.Add(gbReport);
            tpAttendance.Controls.Add(groupBox2);
            tpAttendance.Controls.Add(groupBox4);
            tpAttendance.Location = new Point(4, 24);
            tpAttendance.Name = "tpAttendance";
            tpAttendance.Padding = new Padding(3);
            tpAttendance.Size = new Size(1159, 695);
            tpAttendance.TabIndex = 2;
            tpAttendance.Text = "Yoklamalar";
            tpAttendance.UseVisualStyleBackColor = true;
            // 
            // gbReport
            // 
            gbReport.Controls.Add(wVReport);
            gbReport.Dock = DockStyle.Fill;
            gbReport.Location = new Point(559, 3);
            gbReport.Name = "gbReport";
            gbReport.Size = new Size(329, 689);
            gbReport.TabIndex = 2;
            gbReport.TabStop = false;
            gbReport.Text = "Rapor";
            // 
            // wVReport
            // 
            wVReport.AllowExternalDrop = true;
            wVReport.CreationProperties = null;
            wVReport.DefaultBackgroundColor = Color.White;
            wVReport.Dock = DockStyle.Fill;
            wVReport.Location = new Point(3, 19);
            wVReport.Name = "wVReport";
            wVReport.Size = new Size(323, 667);
            wVReport.TabIndex = 2;
            wVReport.ZoomFactor = 1D;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgAttendance);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(556, 689);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Yoklama Listesi";
            // 
            // dgAttendance
            // 
            dgAttendance.AllowUserToAddRows = false;
            dgAttendance.AllowUserToDeleteRows = false;
            dgAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAttendance.Dock = DockStyle.Fill;
            dgAttendance.Location = new Point(3, 19);
            dgAttendance.Name = "dgAttendance";
            dgAttendance.ReadOnly = true;
            dgAttendance.Size = new Size(550, 667);
            dgAttendance.TabIndex = 0;
            dgAttendance.CellMouseClick += dgAttendance_CellMouseClick;
            // 
            // groupBox4
            // 
            groupBox4.Dock = DockStyle.Right;
            groupBox4.Location = new Point(888, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(268, 689);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Rapor İşlemleri";
            // 
            // tpStudents
            // 
            tpStudents.Controls.Add(webViewStudentReport);
            tpStudents.Controls.Add(dbStudents);
            tpStudents.Controls.Add(groupBox5);
            tpStudents.Location = new Point(4, 24);
            tpStudents.Name = "tpStudents";
            tpStudents.Padding = new Padding(3);
            tpStudents.Size = new Size(1159, 695);
            tpStudents.TabIndex = 0;
            tpStudents.Text = "Öğrenciler";
            tpStudents.UseVisualStyleBackColor = true;
            // 
            // webViewStudentReport
            // 
            webViewStudentReport.AllowExternalDrop = true;
            webViewStudentReport.CreationProperties = null;
            webViewStudentReport.DefaultBackgroundColor = Color.White;
            webViewStudentReport.Dock = DockStyle.Fill;
            webViewStudentReport.Location = new Point(574, 3);
            webViewStudentReport.Name = "webViewStudentReport";
            webViewStudentReport.Size = new Size(129, 689);
            webViewStudentReport.TabIndex = 2;
            webViewStudentReport.ZoomFactor = 1D;
            // 
            // dbStudents
            // 
            dbStudents.Controls.Add(dgStudent);
            dbStudents.Controls.Add(txtSearchStudent);
            dbStudents.Dock = DockStyle.Left;
            dbStudents.Location = new Point(3, 3);
            dbStudents.Name = "dbStudents";
            dbStudents.Size = new Size(571, 689);
            dbStudents.TabIndex = 0;
            dbStudents.TabStop = false;
            // 
            // dgStudent
            // 
            dgStudent.AllowUserToAddRows = false;
            dgStudent.AllowUserToDeleteRows = false;
            dgStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgStudent.Dock = DockStyle.Fill;
            dgStudent.Location = new Point(3, 42);
            dgStudent.Name = "dgStudent";
            dgStudent.ReadOnly = true;
            dgStudent.Size = new Size(565, 644);
            dgStudent.TabIndex = 1;
            dgStudent.CellClick += dgStudent_CellClick;
            // 
            // txtSearchStudent
            // 
            txtSearchStudent.BackColor = SystemColors.Info;
            txtSearchStudent.Dock = DockStyle.Top;
            txtSearchStudent.Location = new Point(3, 19);
            txtSearchStudent.Name = "txtSearchStudent";
            txtSearchStudent.Size = new Size(565, 23);
            txtSearchStudent.TabIndex = 2;
            txtSearchStudent.TextChanged += txtSearchStudent_TextChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnStudentUpdate);
            groupBox5.Controls.Add(btnStudentRemove);
            groupBox5.Controls.Add(btnStudentAdd);
            groupBox5.Controls.Add(gbGroups);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(txtClass);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(txtBilsemNo);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(txtUserName);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(txtFullName);
            groupBox5.Controls.Add(label5);
            groupBox5.Dock = DockStyle.Right;
            groupBox5.Location = new Point(703, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(453, 689);
            groupBox5.TabIndex = 1;
            groupBox5.TabStop = false;
            // 
            // btnStudentUpdate
            // 
            btnStudentUpdate.Location = new Point(53, 575);
            btnStudentUpdate.Name = "btnStudentUpdate";
            btnStudentUpdate.Size = new Size(371, 23);
            btnStudentUpdate.TabIndex = 20;
            btnStudentUpdate.Text = "ÖĞRENCİ GÜNCELLE";
            btnStudentUpdate.UseVisualStyleBackColor = true;
            btnStudentUpdate.Click += btnStudentUpdate_Click;
            // 
            // btnStudentRemove
            // 
            btnStudentRemove.Location = new Point(53, 525);
            btnStudentRemove.Name = "btnStudentRemove";
            btnStudentRemove.Size = new Size(371, 23);
            btnStudentRemove.TabIndex = 21;
            btnStudentRemove.Text = "ÖĞRENCİ SİL";
            btnStudentRemove.UseVisualStyleBackColor = true;
            btnStudentRemove.Click += btnStudentRemove_Click;
            // 
            // btnStudentAdd
            // 
            btnStudentAdd.Location = new Point(53, 475);
            btnStudentAdd.Name = "btnStudentAdd";
            btnStudentAdd.Size = new Size(371, 23);
            btnStudentAdd.TabIndex = 22;
            btnStudentAdd.Text = "ÖĞRENCİ EKLE";
            btnStudentAdd.UseVisualStyleBackColor = true;
            btnStudentAdd.Click += btnStudentAdd_Click_1;
            // 
            // gbGroups
            // 
            gbGroups.Location = new Point(143, 267);
            gbGroups.Name = "gbGroups";
            gbGroups.Size = new Size(285, 150);
            gbGroups.TabIndex = 19;
            gbGroups.TabStop = false;
            gbGroups.Text = "Gruplar";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 267);
            label8.Name = "label8";
            label8.Size = new Size(102, 15);
            label8.TabIndex = 18;
            label8.Text = "KAYITLI DERSLER :";
            // 
            // txtClass
            // 
            txtClass.Location = new Point(139, 190);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(285, 23);
            txtClass.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 193);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 16;
            label7.Text = "SINIFI :";
            // 
            // txtBilsemNo
            // 
            txtBilsemNo.Location = new Point(139, 96);
            txtBilsemNo.Name = "txtBilsemNo";
            txtBilsemNo.Size = new Size(285, 23);
            txtBilsemNo.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 99);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 12;
            label9.Text = "BİLSEM NO :";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(139, 143);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(285, 23);
            txtUserName.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 146);
            label6.Name = "label6";
            label6.Size = new Size(93, 15);
            label6.TabIndex = 13;
            label6.Text = "KULLANICI ADI :";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(139, 49);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(285, 23);
            txtFullName.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 52);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 10;
            label5.Text = "ADI SOYADI :";
            // 
            // tpRawData
            // 
            tpRawData.Controls.Add(groupBox1);
            tpRawData.Location = new Point(4, 24);
            tpRawData.Name = "tpRawData";
            tpRawData.Padding = new Padding(3);
            tpRawData.Size = new Size(1159, 695);
            tpRawData.TabIndex = 1;
            tpRawData.Text = "Ham Veriler";
            tpRawData.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvRawData);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1153, 689);
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
            dgvRawData.Size = new Size(1147, 667);
            dgvRawData.TabIndex = 0;
            // 
            // tpLessonPlans
            // 
            tpLessonPlans.Controls.Add(groupBox3);
            tpLessonPlans.Controls.Add(groupBox6);
            tpLessonPlans.Location = new Point(4, 24);
            tpLessonPlans.Name = "tpLessonPlans";
            tpLessonPlans.Padding = new Padding(3);
            tpLessonPlans.Size = new Size(1159, 695);
            tpLessonPlans.TabIndex = 3;
            tpLessonPlans.Text = "Ders Programı";
            tpLessonPlans.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgLessonPlans);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(602, 689);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            // 
            // dgLessonPlans
            // 
            dgLessonPlans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgLessonPlans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgLessonPlans.Dock = DockStyle.Fill;
            dgLessonPlans.Location = new Point(3, 19);
            dgLessonPlans.Name = "dgLessonPlans";
            dgLessonPlans.Size = new Size(596, 667);
            dgLessonPlans.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnLessonUpdate);
            groupBox6.Controls.Add(btnLessonRemove);
            groupBox6.Controls.Add(btnLessonAdd);
            groupBox6.Controls.Add(cmbDay);
            groupBox6.Controls.Add(label4);
            groupBox6.Controls.Add(txtEndTime);
            groupBox6.Controls.Add(label3);
            groupBox6.Controls.Add(txtStartTime);
            groupBox6.Controls.Add(label2);
            groupBox6.Controls.Add(label1);
            groupBox6.Controls.Add(txtLessonName);
            groupBox6.Dock = DockStyle.Right;
            groupBox6.Location = new Point(605, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(551, 689);
            groupBox6.TabIndex = 2;
            groupBox6.TabStop = false;
            // 
            // btnLessonUpdate
            // 
            btnLessonUpdate.Location = new Point(87, 302);
            btnLessonUpdate.Name = "btnLessonUpdate";
            btnLessonUpdate.Size = new Size(393, 23);
            btnLessonUpdate.TabIndex = 17;
            btnLessonUpdate.Text = "GÜNCELLE";
            btnLessonUpdate.UseVisualStyleBackColor = true;
            btnLessonUpdate.Click += btnLessonUpdate_Click;
            // 
            // btnLessonRemove
            // 
            btnLessonRemove.Location = new Point(87, 273);
            btnLessonRemove.Name = "btnLessonRemove";
            btnLessonRemove.Size = new Size(393, 23);
            btnLessonRemove.TabIndex = 16;
            btnLessonRemove.Text = "SİL";
            btnLessonRemove.UseVisualStyleBackColor = true;
            btnLessonRemove.Click += btnLessonRemove_Click;
            // 
            // btnLessonAdd
            // 
            btnLessonAdd.Location = new Point(87, 244);
            btnLessonAdd.Name = "btnLessonAdd";
            btnLessonAdd.Size = new Size(393, 23);
            btnLessonAdd.TabIndex = 14;
            btnLessonAdd.Text = "EKLE";
            btnLessonAdd.UseVisualStyleBackColor = true;
            btnLessonAdd.Click += btnLessonAdd_Click;
            // 
            // cmbDay
            // 
            cmbDay.FormattingEnabled = true;
            cmbDay.Location = new Point(213, 97);
            cmbDay.Name = "cmbDay";
            cmbDay.Size = new Size(267, 23);
            cmbDay.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 189);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 9;
            label4.Text = "BİTİŞ SAATİ :";
            // 
            // txtEndTime
            // 
            txtEndTime.Location = new Point(213, 181);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.Size = new Size(267, 23);
            txtEndTime.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 147);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 11;
            label3.Text = "BAŞLAMA SAATİ :";
            // 
            // txtStartTime
            // 
            txtStartTime.Location = new Point(213, 139);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.Size = new Size(267, 23);
            txtStartTime.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 105);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 12;
            label2.Text = "GÜNÜ :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 63);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 13;
            label1.Text = "DERS ADI :";
            // 
            // txtLessonName
            // 
            txtLessonName.Location = new Point(213, 55);
            txtLessonName.Name = "txtLessonName";
            txtLessonName.Size = new Size(267, 23);
            txtLessonName.TabIndex = 7;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 723);
            Controls.Add(tabControl1);
            Name = "frmMain";
            Text = "Saturn Teacher";
            Load += frmMain_Load;
            Resize += frmMain_Resize;
            tabControl1.ResumeLayout(false);
            tpAttendance.ResumeLayout(false);
            gbReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wVReport).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAttendance).EndInit();
            tpStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webViewStudentReport).EndInit();
            dbStudents.ResumeLayout(false);
            dbStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgStudent).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            tpRawData.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRawData).EndInit();
            tpLessonPlans.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgLessonPlans).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpStudents;
        private TabPage tpRawData;
        private GroupBox dbStudents;
        private GroupBox groupBox1;
        private DataGridView dgvRawData;
        private TabPage tpAttendance;
        private GroupBox groupBox2;
        private DataGridView dgAttendance;
        private TabPage tpLessonPlans;
        private GroupBox groupBox3;
        private DataGridView dgLessonPlans;
        private DataGridView dgStudent;
        private GroupBox gbReport;
        private Microsoft.Web.WebView2.WinForms.WebView2 wVReport;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Button btnStudentUpdate;
        private Button btnStudentRemove;
        private Button btnStudentAdd;
        private GroupBox gbGroups;
        private Label label8;
        private TextBox txtClass;
        private Label label7;
        private TextBox txtBilsemNo;
        private Label label9;
        private TextBox txtUserName;
        private Label label6;
        private TextBox txtFullName;
        private Label label5;
        private GroupBox groupBox6;
        private Button btnLessonUpdate;
        private Button btnLessonRemove;
        private Button btnLessonAdd;
        private ComboBox cmbDay;
        private Label label4;
        private TextBox txtEndTime;
        private Label label3;
        private TextBox txtStartTime;
        private Label label2;
        private Label label1;
        private TextBox txtLessonName;
        private TextBox txtSearchStudent;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewStudentReport;
    }
}
