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

namespace DOOR.Client.Shared.Course
{
    public partial class CourseGrid : TelerikGridCrud
    {
        [Parameter]
        public CoursePage _CoursePage { get; set; }

        [Inject]
        CourseService _CourseService { get; set; }

        [Inject]
        SchoolService _SchoolService { get; set; }

        public TelerikGrid<CourseDTO> _CourseGrid { get; set; }
        public List<int?> PageSizes => true ? new List<int?> { 10, 25, 50, 100 } : null;
        private int PageSize = 10;

        public List<CourseDTO> lstData { get; set; }
        public List<SchoolDTO> lstSchools { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetLookupData();
            await LoadData();
        }

        protected async Task GetLookupData()
        {
            lstSchools = await _SchoolService.Get();

        }

        protected async Task LoadData()
        {
            lstData = await _CourseService.Get();
            this.StateHasChanged();
        }

        private async Task AddItem(GridCommandEventArgs e)
        {
            CourseDTO _CourseDTO = e.Item as CourseDTO;
            //  Placeholder.  Maybe set values
        }
        private async Task EditItem(GridCommandEventArgs e)
        {
            CourseDTO _CourseDTO = e.Item as CourseDTO;
            //  Placeholder.  Maybe set values
        }
        private async Task UpdateItem(GridCommandEventArgs e)
        {
            CourseDTO _CourseDTO = e.Item as CourseDTO;

            var response = await _CourseService.Put(_CourseDTO);
            HandleNotification(response);
            await LoadData();
        }
        private async Task CreateItem(GridCommandEventArgs e)
        {
            CourseDTO _CourseDTO = e.Item as CourseDTO;
            try
            {
                var response = await _CourseService.Post(_CourseDTO);
                HandleNotification(response);
            }
            catch (CustomOraException coe)
            {
                foreach (var err in coe._ValidationResult)
                {
                    HandleNotification($"Database error. {err.OraErrorMsg}",
                    0,
                    eNumTelerikThemeColor.error, "error");
                }
            }



            await LoadData();

        }
        private async Task DeleteItem(GridCommandEventArgs e)
        {
            CourseDTO _CourseDTO = e.Item as CourseDTO;
            var response = await _CourseService.Delete(_CourseDTO.SchoolId,_CourseDTO.CourseNo);
            HandleNotification(response);
            await LoadData();
        }


        public void HandleNotification(string strNotificationText,
int Length,
eNumTelerikThemeColor eNumTelerikThemeColor, string TelerikIcon = "gear")
        {
            _CoursePage.Notification.Show(new NotificationModel()
            {
                Icon = TelerikIcon,
                ShowIcon = true,
                ThemeColor = "primary",
                Text = strNotificationText,
                CloseAfter = Length,
                Closable = Length == 0 ? true : false
            });
        }
        public void HandleNotification(NotificationModel response)
        {
            _CoursePage.Notification.Show(new NotificationModel()
            {
                Icon = response.Icon,
                ShowIcon = true,
                ThemeColor = response.ThemeColor,
                Text = response.Text,
                CloseAfter = response.CloseAfter,
                Closable = response.Closable
            });
        }
    }
}
