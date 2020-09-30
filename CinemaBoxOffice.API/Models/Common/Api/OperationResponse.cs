using System.Collections.Generic;

namespace CinemaBoxOffice.API.Models.Common.Api
{
    public class OperationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}