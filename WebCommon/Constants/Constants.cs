using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommon.Constants
{
    public class Constants
    {
        public class AppSettingKeys
        {
            public const string DEFAULT_CONNECTION = "DefaultConnection";
        }

        public class Controller
        {
            public const string DEFAULT_ROUTE_CONTROLLER = "api/[controller]/[action]";
        }

        public class Commons
        {
            public const string EMAIL_INVALID = "Email invalid !";
            public const string FIELD_REQUIRED = "This field is required";
        }
    }
}
