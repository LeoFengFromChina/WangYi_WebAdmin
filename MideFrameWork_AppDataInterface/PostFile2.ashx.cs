using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// PostFile2 的摘要说明
    /// </summary>
    public class PostFile2 : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;

            try
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpPostedFile f = context.Request.Files[0];
                    //string path = ConfigurationManager.AppSettings["UserLogo"].ToString() + f.FileName;
                    f.SaveAs(ConfigurationManager.AppSettings["UserLogo"].ToString()+f.FileName);

                    //失败
                    jbo.code = 0;
                    jbo.data = null;
                    jbo.message = "文件上传成功";
                    jbo.success = true;
                }
                else
                {
                    //失败
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "没有任何文件";
                    jbo.success = false;
                }
            }
            catch (Exception ex)
            {
                //失败
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现其他错误";
                jbo.success = false;
            }

            result = JsonSerializer<JsonBaseObject>(jbo);
            context.Response.Write(result);


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