using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTSWebUI.Classes
{
    public static class ClassGetUserName
    {
        public static string getuserName = "Default";

        public static void setUserName(string userName)
        {
            getuserName = userName;
        }
    }
}