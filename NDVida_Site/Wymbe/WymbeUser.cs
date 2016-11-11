using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NDVida_Site.Wymbe
{
    public class WymbeUser
    {
        public WymbeUserData data { get; set; }

        public string userName { get; set; }

        public string password { get; set; }
    }

    public class WymbeUserData
    {
        public string U_NAME { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }

        public string U_LANGUAGE { get; set; }

        public string U_GROUP { get; set; }
    }
}