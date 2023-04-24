using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using DOOR.Client.Helper;
using Telerik.Blazor.Components;
using DOOR.Client.Shared.Course;
using DOOR.Client.Shared.Student;

namespace DOOR.Client.Pages.Student
{
    public partial class StudentGrades : TelerikGridCrud
    {

        private StudentGradesGrid _StudentGradesGrid { get; set; }
        public TelerikNotification Notification { get; set; } = new TelerikNotification();
    }
}
