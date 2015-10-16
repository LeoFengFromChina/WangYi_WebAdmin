using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// AddHelpRequest 的摘要说明
    /// </summary>
    public class AddHelp : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");
            context.Response.ContentType = "text/plain";

            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;
            try
            {
                string title = context.Request["title"];
                string type = context.Request["type"];
                string promoterID = context.Request["promoterID"];
                string linkman = context.Request["linkman"];
                string linkphone = context.Request["linkphone"];
                string beginTime = context.Request["beginTime"];
                string region = context.Request["region"];
                string serviceIntention = context.Request["serviceIntention"];
                string duration = context.Request["duration"];
                string detail = context.Request["detail"];
                string status = context.Request["status"];

                if (!string.IsNullOrEmpty(title) 
                    && !string.IsNullOrEmpty(linkphone)
                    && !string.IsNullOrEmpty(promoterID))
                {
                    WG_HelpRequestEntity currEntity = new WG_HelpRequestEntity();
                    currEntity.Title = title;
                    currEntity.Type = int.Parse(type);//1为求助，2为帮助
                    currEntity.PromoterID = int.Parse(promoterID);//提交人的ID
                    currEntity.LinkMan = linkman;
                    currEntity.LinkPhone = linkphone;
                    currEntity.BeginTime = Convert.ToDateTime(beginTime);
                    currEntity.Region = region;
                    currEntity.ServiceIntention = serviceIntention;
                    currEntity.Duration = int.Parse(duration);
                    currEntity.Detail = detail;
                    currEntity.Status = 0;// int.Parse(status);//0待匹配，1已匹配，2，已完成。
                    //注册，所以不用制定undertakerID
                    currEntity.CreateDate = DateTime.Now;
                    currEntity.UpdateDate = DateTime.Now;
                    int addResult = DataProvider.GetInstance().AddWG_HelpRequest(currEntity);
                    if (addResult < 0)
                    {
                        //失败
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "新增过程中失败";
                        jbo.success = false;
                    }
                    else
                    {
                        //成功
                        jbo.code = 0;
                        jbo.data = null;
                        jbo.message = "成功";
                        jbo.success = true;
                    }
                }
                else
                {
                    //最基本必须有标题和联系人电话，否则失败
                    //失败
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "标题或联系电话必须不能为空。";
                    jbo.success = false;
                }
            }
            catch (Exception ex)
            {
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现异常。";
                jbo.success = false;
            }

            #region 返回json

            result = JsonSerializer<JsonBaseObject>(jbo);
            context.Response.Write(result);

            #endregion
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