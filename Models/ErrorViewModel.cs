using System;

namespace HelloInWorld.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Header {get;set;}

        public string Message {get; set;}

        public string ExtraInformation {get; set;}
    }
}
