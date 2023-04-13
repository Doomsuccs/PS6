using DOOR.Client.eNums;
using DOOR.Client.Services.Common;
using DOOR.Shared.DTO;
using DOOR.Shared.Exceptions;
using DOOR.Shared.Utils;
using Newtonsoft.Json;
using Telerik.Blazor.Components;

namespace DOOR.Client.Services.Core
{
    public class CourseService : BaseService<CourseDTO>
    {
        public CourseService(HttpClient client) 
            : base(client, "Course")
        {
        }

        public async Task<NotificationModel> Delete(int _SchoolID, int _CourseNo)
        {
            HttpResponseMessage response = await Http.DeleteAsync($"{RestAPI}/Delete{BaseObject}/{_SchoolID}/{_CourseNo}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var NotificationModel = MakeNotificationModel($"{BaseObject} Deleted",
                1000,
                eNumTelerikThemeColor.success, "save");
                return NotificationModel;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.ExpectationFailed)
            {
                //  I'm using 'ExpectionFailed' to pass back Oracle Errors
                List<OraError> _ValidationResult = JsonConvert.DeserializeObject<List<OraError>>(response.Content.ReadAsStringAsync().Result);
                throw new CustomOraException(_ValidationResult, response.StatusCode);
            }

            throw new Exception($"The service returned with status {response.StatusCode}");
        }
    }
}
