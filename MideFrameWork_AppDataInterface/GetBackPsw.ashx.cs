using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Common.DailyUtility;
using MideFrameWork.Common.DBUtility;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetBackPsw 的摘要说明
    /// </summary>
    public class GetBackPsw : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //todo:加入跨域允许语句
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");
            context.Response.ContentType = "text/plain";

            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;
            try
            {
                string userName = context.Request["menberName"];
                string email = context.Request["email"];
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email))
                {
                    //失败
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "用户名称或邮箱地址不能为空";
                    jbo.success = false;
                }
                else
                {
                    List<string> emailTo = new List<string>() { email };
                    string fromAddress = "mide_2008@126.com";
                    string fromName = "管理员";
                    string subject = "[网益公益]---找回密码";
                    string account = "mide_2008@126.com";
                    string psw = "mide022196183";
                    string decUserName = DESEncrypt.Encrypt(userName, "WYGY_BQGZS");
                    string body = "http://localhost:5918/GetBackPsw.aspx?key=" + decUserName;
                    string errorStr = "";
                    int count = SendEmail.SendEmailnonAnonymous(fromAddress, fromName, subject, body, emailTo, emailTo, out errorStr, account, psw);
                    if (count > 0)
                    {
                        jbo.code = 0;
                        jbo.data = null;
                        jbo.message = "邮件发送成功，请登陆邮件并根据链接重置密码";
                        jbo.success = true;
                    }
                    else
                    {
                        //失败
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "邮件发送失败";
                        jbo.success = false;
                    }
                }

            }
            catch (Exception ex)
            {
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现异常。";
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