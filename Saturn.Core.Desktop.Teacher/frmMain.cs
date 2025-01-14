using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;

namespace Saturn.Core.Desktop.Teacher
{
    public partial class frmMain : Form
    {
       readonly IAttendanceRawService _attendanceRawService;
        private readonly IStudentService _studentService;

         public frmMain(IStudentService studentService, IAttendanceRawService attendanceRawService)
        {
            InitializeComponent();
            _attendanceRawService = attendanceRawService;
            _studentService = studentService;
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            //await _studentService.RemoteAdd(new Student()
            //{
            //    FullName = "Osman ÜSTÜN",
            //    GroupId = 0,
            //    Username = "osman"
            //});
            dgStudent.DataSource = await _studentService.RemoteGetAll();
        }
    }
}
