using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using DOOR.Client.Helper;
using Telerik.Blazor.Components;
using DOOR.Client.Shared.Course;

namespace DOOR.Client.Pages.Course
{
    public partial  class CoursePage: TelerikGridCrud
    {

        private CourseGrid _CourseGrid { get; set; }
        public TelerikNotification Notification { get; set; } = new TelerikNotification();
    }
}

