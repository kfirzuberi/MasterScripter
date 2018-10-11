using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterScripter.Models
{
    public enum MessageType
    {
        Info = 0,
        Error = 1,
        Success = 2
    }

    public class LogMessage
    {
        public MessageType Type { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; private set; }

        public LogMessage(string message, MessageType type = MessageType.Info)
        {
            Type = type;
            Message = message;
            this.Time = DateTime.Now;
        }
    }
}