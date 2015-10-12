using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using MideFrameWork.Authorization;
using System.Web.Script.Serialization;
namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// AppLogin 的摘要说明
    /// </summary>
    public class AppLogin : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string userName = context.Request["username"];
            string psw = context.Request["psw"];

            //登录
            string userWhere = " Name ='" + userName + "' AND Psw='" + psw + "' " + " AND Status=0 ";

            IList<WG_MenberEntity> userList = DataProvider.GetInstance().GetWG_MenberList(userWhere);
            JsonBaseObject jbo = new JsonBaseObject();
            string result = "";
            if (userList.Count <= 0)
            {
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "该用户不存在！";
                jbo.success = false;
            }
            else
            {
                jbo.code = 0;
                jbo.data = userList[0];
                jbo.message = "成功！";
                jbo.success = true;
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