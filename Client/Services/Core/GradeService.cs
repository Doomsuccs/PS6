using DOOR.Client.eNums;
using DOOR.Client.Services.Common;
using DOOR.Shared.DTO;
using DOOR.Shared.Exceptions;
using DOOR.Shared.Utils;
using Newtonsoft.Json;
using Telerik.Blazor.Components;

namespace DOOR.Client.Services.Core
{
    public class GradeService : BaseService<GradeDTO>
    {
        public GradeService(HttpClient client)
    : base(client, "Grade")
        {
        }
    }
}
