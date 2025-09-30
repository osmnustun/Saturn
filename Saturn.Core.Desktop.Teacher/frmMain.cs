using Saturn.Core.Entity;
using Saturn.Core.Entity.ComplexTypes;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Entity.Enums;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.Report;
using Saturn.Core.Logic.Tools;
using System.Collections.Generic;
using System.Globalization;

namespace Saturn.Core.Desktop.Teacher
{
    public partial class frmMain : Form
    {
        readonly IAttendanceRawService _attendanceRawService;
        private readonly IStudentService _studentService;
        readonly ILessonTimeTableServices _lessonTimeTableServices;
        int LessonId;
        private readonly ReportTools _reportTools;
        Student student = new Student();
        Lesson lesson = new Lesson();
        DateTime AttendanceDate;
        List<AttendanceRaw> attendanceRaws = new List<AttendanceRaw>();
        List<Lesson> lessonList = new List<Lesson>();
        public frmMain(IStudentService studentService, IAttendanceRawService attendanceRawService, ILessonTimeTableServices lessonTimeTableServices, ReportTools reportTools)
        {
            InitializeComponent();
            _attendanceRawService = attendanceRawService;
            _studentService = studentService;
            _lessonTimeTableServices = lessonTimeTableServices;
            _reportTools = reportTools;
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await wVReport.EnsureCoreWebView2Async(null);
            ComboBoxFill();
            dgStudent.DataSource = await _studentService.RemoteGetAll();
            attendanceRaws = (List<AttendanceRaw>)await _attendanceRawService.GetAllRemote();
            dgvRawData.DataSource = attendanceRaws;
            lessonList = (List<Lesson>)await _lessonTimeTableServices.GetAllRemote();
            dgLessonPlans.DataSource =lessonList;
            dgLessonPlans.CellClick += dgvLessonPlans_CellClick;
            dgvLessonPlans_HeaderText();
            GetGroups();
            var reportPath = _reportTools.GeneratePdfReport<AttendanceRaw>(new List<AttendanceRaw>(), ["Id", "Username", "FullName", "PcName"]);
            wVReport.Source = new Uri(reportPath);
            AttendanceInitializing();
        }

        

        #region Functions

        private void Lesson_txt_Read()
        {
            lesson.Clear();
            lesson.LessonName = txtLessonName.Text;
            lesson.DayOfLesson = (DayOfWeek)cmbDay.SelectedValue;
            lesson.EndTime = txtEndTime.Text;
            lesson.StartTime = txtStartTime.Text;
        }
        private void AttendanceInitializing()
        {
            var st = new DateTime(2025, 9, 7);
            var et = new DateTime(2026, 6, 25);
            var liste = new List<Attendance>();
            List<DayOfWeek> dayOfWeeks = new List<DayOfWeek>();
            dayOfWeeks.Add(DayOfWeek.Monday);
            dayOfWeeks.Add(DayOfWeek.Sunday);

            foreach (var item in TimeTools.GetDatesBetween(st, et, dayOfWeeks))
            {
                var LessonNames = "";
                foreach (var lessonItem in lessonList.Where(x => x.DayOfLesson == item.DayOfWeek).ToList())
                {
                    LessonNames += lessonItem.LessonName + ",";
                }
                var count = attendanceRaws.Where(x => x.AttendanceTime.ToShortDateString() == item.ToShortDateString()).DistinctBy(x => x.Username).Count();
                liste.Add(new Attendance
                {
                    Date = item,
                    StudentCount = count,
                    LessonNames = LessonNames
                });
            }

            dgAttendance.DataSource = liste;
            dgAttendance.Columns[0].Visible = false;
            dgAttendance.Columns[1].HeaderText = "Tarih";
            dgAttendance.Columns[2].Visible = false;
            dgAttendance.Columns[3].HeaderText = "Öðrenci Sayýsý";
        }
        void ClearLesson()
        {
            txtLessonName.Text = "";
            txtStartTime.Text = "";
            txtEndTime.Text = "";
        }
    
        void ComboBoxFill()
        {
           //cmbDay.DataSource = Enum.GetValues(typeof(DayOfWeek));            
          cmbDay.DataSource = DateNames.DayOfWeekNames.ToList();
            cmbDay.DisplayMember = "Value";
            cmbDay.ValueMember = "Key";



        }
        void dgvLessonPlans_HeaderText()
        {
            string[] headerText = {"Id", "Ders Adý", "Gün-System","Ders Günü", "Baþlama Saati", "Bitiþ Saati","Öðretmen","Kullanýcý Id" };
            bool[] visible =      { false, true,        false,       true,       true,               true,       false,       false };
            foreach (DataGridViewColumn item in dgLessonPlans.Columns)
            {
                item.HeaderText = headerText[item.Index];
                item.Visible = visible[item.Index];
            }
        }
        async void GetGroups()
        {

            var groups = await _lessonTimeTableServices.GetAllGroups();
            var x = 5;
            var y = 15;
            var i = 20;
            foreach (var item in groups)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item.LessonName;
                checkBox.Tag = item.LessonId;
                checkBox.AutoSize = true;
                checkBox.Location = new Point(x, y);
                checkBox.Checked = false;
                checkBox.Name = item.LessonId.ToString();
                gbGroups.Controls.Add(checkBox);
                y += i;

            }
        }
        void GetStudentFromDatagrid()
        {
            student.Clear();
            student.StudentId = Convert.ToInt32(dgStudent.CurrentRow.Cells[0].Value);
            student.BilsemNo = dgStudent.CurrentRow.Cells[1].Value == null ? "" : dgStudent.CurrentRow.Cells[1].Value.ToString();
            student.Username = dgStudent.CurrentRow.Cells[2].Value.ToString();
            student.FullName = dgStudent.CurrentRow.Cells[3].Value.ToString();
            student.Class = dgStudent.CurrentRow.Cells[4].Value == null ? "" : dgStudent.CurrentRow.Cells[4].Value.ToString();
            var groups = new List<StudentsLessons>();
            List<Student> DataSourceValues = (List<Student>)dgStudent.DataSource;
            groups = DataSourceValues[dgStudent.SelectedCells[0].RowIndex].Groups;
            student.Groups = groups;

            foreach (var item in gbGroups.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    cb.Checked = false;
                }
            }

            foreach (var item in groups)
            {
                CheckBox cb = (CheckBox)gbGroups.Controls.Find(item.LessonId.ToString(), false).FirstOrDefault();
                if (cb != null)
                {
                    cb.Checked = true;
                }
            }

            txtBilsemNo.Text = student.BilsemNo;
            txtUserName.Text = student.Username;
            txtFullName.Text = student.FullName;
            txtClass.Text = student.Class;
        }
        private ICollection<StudentsLessons>? GetStudentGroupsFromCheckBox()
        {
            var resault = new List<StudentsLessons>();
            foreach (var item in gbGroups.Controls)
            {
                if (item is CheckBox)
                {
                    var checkBox = item as CheckBox;
                    if (checkBox.Checked)
                    {
                        resault.Add(new StudentsLessons
                        {
                            StudentId = 0,
                            LessonId = Convert.ToInt32(checkBox.Tag)
                        });
                    }
                }
            }

            return resault;
        }

        private void Get_Student_Txt()
        {
            student.Class = txtClass.Text;
            student.FullName = txtFullName.Text;
            student.Username = txtUserName.Text;
            student.BilsemNo = txtBilsemNo.Text;
        }
        #endregion


        private void frmMain_Resize(object sender, EventArgs e)
        {
            //gbReport.Width = this.Width - 700;
            wVReport.Reload();
        }

        private void btnStudentAdd_Click(object sender, EventArgs e)
        {
            Get_Student_Txt();

        }


        private void dgStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetStudentFromDatagrid();
        }

        private async void btnStudentRemove_Click(object sender, EventArgs e)
        {
            await _studentService.RemoteDelete(student);
            dgStudent.DataSource = await _studentService.RemoteGetAll();
        }

        private async void btnStudentAdd_Click_1(object sender, EventArgs e)
        {
            student.Clear();
            student.BilsemNo = txtBilsemNo.Text;
            student.Username = txtUserName.Text;
            student.FullName = txtFullName.Text;
            student.Class = txtClass.Text;
            student.Groups = (List<StudentsLessons>?)GetStudentGroupsFromCheckBox();
            await _studentService.RemoteAdd(student);
            var resault = await _studentService.RemoteGetAll();
            dgStudent.DataSource = resault;
        }

        private async void btnStudentUpdate_Click(object sender, EventArgs e)
        {
            student.Groups = (List<StudentsLessons>?)GetStudentGroupsFromCheckBox();
            Get_Student_Txt();
            await _studentService.RemoteUpdate(student);
            dgStudent.DataSource = await _studentService.RemoteGetAll();
        }

        private async void btnLessonAdd_Click(object sender, EventArgs e)
        {
            Lesson_txt_Read();

            await _lessonTimeTableServices.AddRemote(lesson);
            dgLessonPlans.DataSource = await _lessonTimeTableServices.GetAllRemote();
            ClearLesson();
           
        }

        private async void dgAttendance_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgAttendance.CurrentRow != null)
            {
                CultureInfo ci = new CultureInfo("tr-TR");
                AttendanceDate = (DateTime)dgAttendance.CurrentRow.Cells[2].Value;
                var attendanceList = attendanceRaws.Where(x => x.AttendanceTime.ToShortDateString() == AttendanceDate.ToShortDateString()).DistinctBy(x => x.Username).ToList();
                var studentList= await _studentService.RemoteGetAll();
                var studentLessonList = studentList.SelectMany(x => x.Groups).ToList();
                var lessonTableList = await _lessonTimeTableServices.GetAllRemote();
                var resault= new List<List<AttendanceReport>>();
                foreach (var lesson in lessonTableList)
                {
                    var r= attendanceList.Where(x=>x.AttendanceTime.DayOfWeek== lesson.DayOfLesson 
                    && TimeSpan.Parse(x.AttendanceTime.ToString("HH:mm"))>TimeSpan.Parse(lesson.StartTime).Add(new TimeSpan(0, -30, 0))
                    && TimeSpan.Parse(x.AttendanceTime.ToString("HH:mm")) < TimeSpan.Parse(lesson.EndTime)).ToList();
                    if(r.Count > 0)
                    {
                        var attendanceReport = new List<AttendanceReport>();
                        foreach (var attendanceRaw in r)
                        {
                           
                           attendanceReport.Add(new AttendanceReport
                            {
                                FullName = attendanceRaw.FullName,
                                PcName = attendanceRaw.PcName,
                                BilsemNo = studentList.FirstOrDefault(x => x.Username == attendanceRaw.Username)?.BilsemNo,
                                AttendanceDateTime = attendanceRaw.AttendanceTime.ToString("dd MMM yyyy ddd HH:mm",ci),
                                username = attendanceRaw.Username

                           });
                        }
                        var lessonStudents=studentList.Where(studentList => studentList.Groups.Any(x => x.LessonId == lesson.LessonId)).ToList();
                        foreach (var student in lessonStudents)
                        {
                            if (!attendanceReport.Any(x => x.username == student.Username))
                            {
                                attendanceReport.Add(new AttendanceReport
                                {
                                    FullName = student.FullName,
                                    PcName = "Yok",
                                    BilsemNo = student.BilsemNo,
                                    AttendanceDateTime = "Yok"
                                });
                            }
                        }

                        resault.Add(attendanceReport);
                    }
                        

                }

                //var reportPath = _reportTools.GeneratePdfReport<AttendanceRaw>(attendanceList, ["FullName", "PcName", "GetDateString"]);
                var reportPath = _reportTools.CreatePdfWithDynamicTables(resault, ["BilsemNo", "FullName", "PcName","AttendanceDateTime"],
                                                                                   ["No","Ad Soyad","Bilgisayar","Tarih Saat"],
                                                                                   $"{AttendanceDate.ToString("dd MMM yyyy ddd")}-Yoklama Listesi");
                wVReport.Source = new Uri(reportPath);
                //wVReport.Reload();
            }


        }

        private async void btnLessonRemove_Click(object sender, EventArgs e)
        {
            await _lessonTimeTableServices.DeleteRemote(lesson);
            dgLessonPlans.DataSource=await _lessonTimeTableServices.GetAllRemote();
        }

        private async void btnLessonUpdate_Click(object sender, EventArgs e)
        {
            Lesson_txt_Read();
            lesson.LessonId = LessonId;
            await _lessonTimeTableServices.UpdateRemote(lesson);
            dgLessonPlans.DataSource = await _lessonTimeTableServices.GetAllRemote();
        }
        void dgvLessonPlans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lesson.Clear();
            var selectedLesson = dgLessonPlans.Rows[e.RowIndex].DataBoundItem as Lesson;
            LessonId = selectedLesson.LessonId;
            lesson.LessonId = selectedLesson.LessonId;
            lesson.LessonName = selectedLesson.LessonName;
            lesson.StartTime = selectedLesson.StartTime;
            lesson.EndTime = selectedLesson.EndTime;
            lesson.DayOfLesson = selectedLesson.DayOfLesson;


            txtLessonName.Text = lesson.LessonName;
            txtStartTime.Text = lesson.StartTime;
            txtEndTime.Text = lesson.EndTime;
            cmbDay.SelectedValue = lesson.DayOfLesson;



        }
    }
}
