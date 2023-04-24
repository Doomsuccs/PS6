using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using DOOR.Client.Helper;
using DOOR.Client.Pages.Course;
using Telerik.Blazor.Components;
using DOOR.Shared.DTO;
using DOOR.Client.Services.Core;
using DOOR.Client.eNums;
using static Telerik.Blazor.ThemeConstants;
using Telerik.Blazor;
using DOOR.Shared.Exceptions;
using DOOR.Client.Pages.Student;

namespace DOOR.Client.Shared.Student
{
    public partial class StudentGradesGrid : TelerikGridCrud
    {
        [Parameter]
        public StudentGrades _StudentGrades { get; set; }

        [Inject]
        CourseService _CourseService { get; set; }

        [Inject]
        SchoolService _SchoolService { get; set; }
        [Inject]
        GradeService _GradeService { get; set; }

        public TelerikGrid<GradeDTO> _GradeGrid { get; set; }
        public List<int?> PageSizes => true ? new List<int?> { 10, 25, 50, 100 } : null;
        private int PageSize = 10;

        public List<GradeDTO> lstData { get; set; }
        public List<SchoolDTO> lstSchools { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //await GetLookupData();
            await LoadData();
        }

        protected async Task GetLookupData()
        {
            lstSchools = await _SchoolService.Get();

        }

        protected async Task LoadData()
        {
            lstData = await _GradeService.Get();
            this.StateHasChanged();
        }
    }
}
