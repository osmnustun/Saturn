using Org.BouncyCastle.Asn1.Cmp;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;

namespace Saturn.Core.Desktop.Teacher
{
    public partial class frmMain : Form
    {
        readonly IAttendanceRawService _attendanceRawService;
        private readonly IStudentService _studentService;
        readonly ILessonTimeTableServices _lessonTimeTableServices;
        int LessonId;

        public frmMain(IStudentService studentService, IAttendanceRawService attendanceRawService, ILessonTimeTableServices lessonTimeTableServices)
        {
            InitializeComponent();
            _attendanceRawService = attendanceRawService;
            _studentService = studentService;
            _lessonTimeTableServices = lessonTimeTableServices;
        }
        
        private async void frmMain_Load(object sender, EventArgs e)
        {
            
            ComboBoxFill();           
            dgStudent.DataSource = await _studentService.RemoteGetAll();
            dgvRawData.DataSource = await _attendanceRawService.GetAllRemote();
            dgLessonPlans.DataSource = await _lessonTimeTableServices.GetAllRemote();
            dgLessonPlans.CellClick += dgvLessonPlans_CellClick;
            dgvLessonPlans_HeaderText();
        }

        private async void btnLessonAdd_Click(object sender, EventArgs e)
        {
            var Lesson = new Lesson();

            Lesson.LessonName = txtLessonName.Text;
            Lesson.DayOfLesson = (DayOfWeek)cmbDay.SelectedValue;
            Lesson.EndTime =txtEndTime.Text;
            Lesson.StartTime = txtStartTime.Text;
               
            

           await  _lessonTimeTableServices.AddRemote(Lesson);
           dgLessonPlans.DataSource =await _lessonTimeTableServices.GetAllRemote();
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
            dgLessonPlans.Columns[8].HeaderText = "Baþlama Saati";
            dgLessonPlans.Columns[4].Visible = false;
            dgLessonPlans.Columns[5].Visible = false;
            dgLessonPlans.Columns[6].Visible = false;
            dgLessonPlans.Columns[7].Visible = false;

        }
        #endregion


    }
}
