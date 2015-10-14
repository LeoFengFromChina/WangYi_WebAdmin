using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// AddFeedBack 的摘要说明
    /// </summary>
    public class AddFeedBack : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //todo:加入跨域允许语句
            //context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            //context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");

            context.Response.ContentType = "text/plain";
            JsonBaseObject jbo = new JsonBaseObject();
            string resultStr = string.Empty;
            try
            {
                string menberid = context.Request["menberid"];
                string detail = context.Request["detail"];
                string memo = context.Request["memo"];
                if (string.IsNullOrEmpty(detail)
                    || string.IsNullOrEmpty(menberid))
                {
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "用户ID或反馈明细不能为空";
                    jbo.success = false;
                }
                else
                {
                    WG_FeebackEntity fe = new WG_FeebackEntity();
                    fe.PromoterID = int.Parse(menberid);
                    fe.Detail = detail;
                    fe.Memo = memo;
                    fe.CreateDate = DateTime.Now;
                    if (DataProvider.GetInstance().AddWG_Feeback(fe) > 0)
                    {
                        jbo.code = 0;
                        jbo.data = null;
                        jbo.message = "成功";
                        jbo.success = true;
                    }
                    else
                    {
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "提交反馈信息出错";
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