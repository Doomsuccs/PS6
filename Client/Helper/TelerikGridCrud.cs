using DOOR.Client.eNums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Telerik.Blazor.ThemeConstants;
using Telerik.Blazor.Components;

namespace DOOR.Client.Helper

{
    public class TelerikGridCrud : ComponentBase
    {
        public JsonSerializerOptions options = new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            PropertyNameCaseInsensitive = true
        };
        [Inject]
        IAuthorizationService AuthorizationService { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        protected IJSRuntime Js { get; set; }

        [Inject]
        protected NavigationManager NavManager { get; set; }

        protected bool IsLoading { get; set; }
        protected int Total { get; set; } = 0;
        protected bool ExportAllPages { get; set; }

        public string GetTooltipContent(Dictionary<string, string> targetMetadata, string targetTitle, string targetMessage)
        {

            string result = $"<strong>{targetTitle}</strong>";
            result += "<br>";
            result += targetMessage;

            return result;
        }



    }
}
