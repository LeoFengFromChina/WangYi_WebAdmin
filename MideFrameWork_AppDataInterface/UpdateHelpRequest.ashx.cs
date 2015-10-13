using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// UpdateHelpRequest 的摘要说明
    /// </summary>
    public class UpdateHelpRequest : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //1.承接
            //2.完成操作
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");
            context.Response.ContentType = "text/plain";
            JsonBaseObject jbo = new JsonBaseObject();
            string resultStr = string.Empty;
            string helpRequestStr = context.Request["helpRequestID"];//请求单号
            string underTakerStr = context.Request["underTakerID"]; //接单者ID
            string status = context.Request["status"]; //动作状态
            int helpRequestID = int.Parse(helpRequestStr);
            int underTakerID = int.Parse(underTakerStr);
            WG_HelpRequestEntity currEntity = DataProvider.GetInstance().GetWG_HelpRequestEntity(helpRequestID);
            if (currEntity != null)
            {
                //避免同时多个人接单，如果已经为1，则返回失败。
                //更新状态:0为初建，1为已承接，2为已完成
                currEntity.Status = currEntity.Status + 1;
                if (currEntity.Status == 2)
                {
                    //这个就是完成操作。
                    //给承接人加入服务时常
                    //1.找到承接人
                    WG_MenberEntity underTaker = DataProvider.GetInstance().GetWG_MenberEntity(currEntity.UnderTakerID);

                    //2.更新承接人服务时常
                    if (underTaker != null)
                    {
                        underTaker.ServiceHours += currEntity.Duration;
                    }
                    //3.完成更新
                    bool utakerResult = DataProvider.GetInstance().UpdateWG_Menber(underTaker);
                    if(!utakerResult)
                    {
                        //更新承接人服务时常出错。
                    }
                }
                else
                {
                    //更新承接人ID
                    currEntity.UnderTakerID = underTakerID;
                }
                //更新更改时间
                currEntity.UpdateDate = DateTime.Now;

                bool result = DataProvider.GetInstance().UpdateWG_HelpRequest(currEntity);

                if (result)
                {
                    //成功
                    jbo.code = 0;
                    jbo.data = null;
                    jbo.message = "成功。";
                    jbo.success = true;
                }
                else
                {
                    //失败
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "数据更新失败";
                    jbo.success = false;
                }
            }
            else
            {
                //失败
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "所更新的记录不存在。";
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