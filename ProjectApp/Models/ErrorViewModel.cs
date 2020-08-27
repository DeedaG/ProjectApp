using System;
using Newtonsoft.Json;

namespace ProjectApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        //public string Message { get; internal set; }

        //public DateTime? ProjectDate { get; set; }

        //public string Title {get; set;}

        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}
    }
}
