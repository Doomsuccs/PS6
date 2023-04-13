using DOOR.Client.Services.Common;
using DOOR.Shared.DTO;

namespace DOOR.Client.Services.Core
{
    public class SchoolService : BaseService<SchoolDTO>
    {
        public SchoolService(HttpClient client)
    : base(client, "School")
        {
        }
    }
}
