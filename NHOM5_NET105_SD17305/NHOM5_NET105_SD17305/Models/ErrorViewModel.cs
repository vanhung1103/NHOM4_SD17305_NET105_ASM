using System;

namespace NHOM5_NET105_SD17305.Models
{ 
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
