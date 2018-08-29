using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterScripter.DAL
{
    public static class Consts
    {
        public const string MIN_MAX_ERROR_MSG = "{0} must be between {2} and {1} characters long";

        public const string EMAIL_REGEX = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string IP_REGEX = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
    }
}
