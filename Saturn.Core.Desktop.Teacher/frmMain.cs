using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.Report;
using System.Collections.Generic;

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
            ComboBoxFill();
            dgStudent.DataSource = await _studentService.RemoteGetAll();
            var attendanceRaws = await _attendanceRawService.GetAllRemote();
            dgvRawData.DataSource = attendanceRaws;
            dgLessonPlans.DataSource = await _lessonTimeTableServices.GetAllRemote();
            dgLessonPlans.CellClick += dgvLessonPlans_CellClick;
            dgvLessonPlans_HeaderText();
            GetGroups();
            var reportPath = _reportTools.GeneratePdfReport<AttendanceRaw>(attendanceRaws, ["Id", "username", "FullName", "PcName"]);
            wVReport.Source = new Uri(reportPath);
        }
        private async void btnLessonAdd_Click(object sender, EventArgs e)
        {
            var Lesson = new Lesson();

            Lesson.LessonName = txtLessonName.Text;
            Lesson.DayOfLesson = (DayOfWeek)cmbDay.SelectedValue;
            Lesson.EndTime = txtEndTime.Text;
            Lesson.StartTime = txtStartTime.Text;



            await _lessonTimeTableServices.AddRemote(Lesson);
            dgLessonPlans.DataSource = await _lessonTimeTableServices.GetAllRemote();
            ClearLesson();
        }


        #region Functions
        void ClearLesson()
        {
            txtLessonName.Text = "";
            txtStartTime.Text = "";
            txtEndTime.Text = "";
        }
        void dgvLessonPlans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLessonName.Text = dgLessonPlans.CurrentRow.Cells[1].Value.ToString();
            txtStartTime.Text = dgLessonPlans.CurrentRow.Cells[2].Value.ToString();
            txtEndTime.Text = dgLessonPlans.CurrentRow.Cells[3].Value.ToString();
            LessonId = Convert.ToInt32(dgLessonPlans.CurrentRow.Cells[0].Value);

        }
        void ComboBoxFill()
        {
            cmbDay.DataSource = Enum.GetValues(typeof(DayOfWeek));
        }
        void dgvLessonPlans_HeaderText()
        {
            //  dgLessonPlans.Columns[0].HeaderText = "Ders Id";
            dgLessonPlans.Columns[1].HeaderText = "Ders Adý";
            dgLessonPlans.Columns[2].HeaderText = "Gün";
            dgLessonPlans.Columns[3].HeaderText = "Bitiþ Saati";
            dgLessonPlans.Columns[6].HeaderText = "Baþlama Saati";
            dgLessonPlans.Columns[4].Visible = false;
            dgLessonPlans.Columns[5].Visible = false;



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
        #endregion


        private void frmMain_Resize(object sender, EventArgs e)
        {
            //gbReport.Width = this.Width - 700;
        }

        private void btnStudentAdd_Click(object sender, EventArgs e)
        {
            student.Class = txtClass.Text;
            student.FullName = txtFullName.Text;
            student.Username = txtUserName.Text;
            student.BilsemNo = txtBilsemNo.Text;


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
            await _studentService.RemoteUpdate(student);
            dgStudent.DataSource = await _studentService.RemoteGetAll();
        }

        private async void btnLessonAdd_Click_1(object sender, EventArgs e)
        {
           await  _lessonTimeTableServices.AddRemote(lesson);
        }
    }
}
