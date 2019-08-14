using System;
using System.Collections.Generic;

namespace DataRepository.Models
{
    public partial class Log4netErrorLog
    {
        public int ErrorLogId { get; set; }
        public string MachineName { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string AppName { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
