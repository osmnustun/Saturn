using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;

namespace Saturn.Core.Desktop.Teacher
{
    public partial class frmMain : Form
    {
       readonly IAttendanceRawService _attendanceRawService;
        public frmMain(IStudentService studentService, IAttendanceRawService attendanceRawService)
        {
            InitializeComponent();
            _attendanceRawService = attendanceRawService;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _attendanceRawService.Add(
                new AttendanceRaw()
                {
                    AttendanceTime = DateTime.Now,
                    FullName = "test",
                    PcName = "test",
                    Username = "test"
                });
        }
    }
}
