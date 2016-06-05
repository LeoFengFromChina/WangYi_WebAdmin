using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// DownloadApp 的摘要说明
    /// </summary>
    public class DownloadApp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string appurl = ConfigurationManager.AppSettings["CurrentAppDownLoadURL"].ToString();
            context.Response.Redirect(appurl);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}