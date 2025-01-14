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
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tpStudents.SuspendLayout();
            dbStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgStudent).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpStudents);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1410, 723);
            tabControl1.TabIndex = 0;
            // 
            // tpStudents
            // 
            tpStudents.Controls.Add(dbStudents);
            tpStudents.Location = new Point(4, 24);
            tpStudents.Name = "tpStudents";
            tpStudents.Padding = new Padding(3);
            tpStudents.Size = new Size(1402, 695);
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
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1402, 695);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1410, 723);
            Controls.Add(tabControl1);
            Name = "frmMain";
            Text = "Saturn Teacher";
            Load += frmMain_Load;
            tabControl1.ResumeLayout(false);
            tpStudents.ResumeLayout(false);
            dbStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgStudent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpStudents;
        private TabPage tabPage2;
        private GroupBox dbStudents;
        private DataGridView dgStudent;
    }
}
