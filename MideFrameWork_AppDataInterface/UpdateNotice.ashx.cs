using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using System.Data;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// UpdateActivity 的摘要说明
    /// </summary>
    public class UpdateNotice : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // todo: [KnownType(typeof(List<WG_ActivitiesEntity>))]

            //todo:加入跨域允许语句
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");

            JsonBaseObject jbo = new JsonBaseObject();
            string resultStr = string.Empty;

            try
            {
                string IDstr = context.Request["ID"];
                int ID = -1;
                int.TryParse(IDstr, out ID);
                if (ID < 0)
                {
                    //参数空
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "ID不合法";
                    jbo.success = false;
                }
                else
                {
                    //当前活动，ae.Status，0等待报名...，1活动正在进行(禁止报名),2,活动已结束
                    NoticeEntity ne = DataProvider.GetInstance().GetNoticeEntity(ID);

                    if (ne != null)
                    {
                        try
                        {
                            ne.AlreadyRead = 1;//已读
                            DataProvider.GetInstance().UpdateNotice(ne);

                            //成功
                            jbo.code = 0;
                            jbo.data = null;
                            jbo.message = "更新消息状态成功";
                            jbo.success = true;
                        }
                        catch (Exception ex)
                        {
                            //失败
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.message = "更新消息状态失败";
                            jbo.success = false;
                        }
                    }
                    else
                    {                            
                        //失败
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "找不到指定id的消息内容";
                        jbo.success = false;
                    }
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

            resultStr = JsonSerializer<JsonBaseObject>(jbo);
            context.Response.Write(resultStr);

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