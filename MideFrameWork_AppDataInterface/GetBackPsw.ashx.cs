using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Common.DailyUtility;
using MideFrameWork.Common.DBUtility;
using System.Configuration;

using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
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
                    string whereStr = " name='" + userName + "' and Email='" + email + "'";

                    IList<WG_MenberEntity> menberList = DataProvider.GetInstance().GetWG_MenberList(whereStr);
                    if (menberList == null || menberList.Count <= 0)
                    {
                        //账号与邮箱不匹配
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "邮箱与账号不匹配，请确认";
                        jbo.success = false;

                    }
                    else
                    {
                        List<string> emailTo = new List<string>() { email };
                        string fromAddress = DESEncrypt.Decrypt(ConfigurationManager.AppSettings["EmailAccount"].ToString(), "WYGY_BQGZS");
                        string fromName = ConfigurationManager.AppSettings["FromName"].ToString();
                        string subject = ConfigurationManager.AppSettings["Subject"].ToString();
                        string account = DESEncrypt.Decrypt(ConfigurationManager.AppSettings["EmailAccount"].ToString(), "WYGY_BQGZS");
                        string psw = DESEncrypt.Decrypt(ConfigurationManager.AppSettings["EmailPsw"].ToString(), "WYGY_BQGZS"); ;
                        string decUserName = DESEncrypt.Encrypt(userName, "WYGY_BQGZS");
                        string body = ConfigurationManager.AppSettings["GetBackUrl"].ToString() + decUserName;
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