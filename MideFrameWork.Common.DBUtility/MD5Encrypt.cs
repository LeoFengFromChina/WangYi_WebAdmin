using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MideFrameWork.Common.DBUtility
{
    public static class MD5Encrypt
    {
        public static string MD5Hash(string SourceStr)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(SourceStr, "MD5");
        }
    }
}
