using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetNoticeList 的摘要说明
    /// </summary>
    public class GetNoticeList : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //todo:加入跨域允许语句
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");

            context.Response.ContentType = "text/plain";
            JsonBaseObject jbo = new JsonBaseObject();
            string resultStr = string.Empty;

            try
            {
                string menberid = context.Request["menberid"];

                string PageIndex = "1";
                if (!string.IsNullOrEmpty(context.Request["PageIndex"]))
                    PageIndex = context.Request["PageIndex"];

                if (string.IsNullOrEmpty(menberid))
                {
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "用户ID不能为空";
                    jbo.success = false;
                }
                else
                {
                    string whereStr = " toUserID= " + menberid;
                    //IList<NoticeEntity> noticeList = DataProvider.GetInstance().GetNoticeList(whereStr);

                    int recordCount = -1;
                    int pageCount = -1;
                    // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                    IList<NoticeEntity> noticeList = DataProvider.GetInstance().GetNoticeList(20, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                    //如果所有数据分页后的总页数比请求的页数小，则返回空。
                    if (int.Parse(PageIndex) > pageCount)
                        noticeList.Clear();
                    if (noticeList != null && noticeList.Count > 0)
                    {
                        jbo.code = 0;
                        jbo.data = noticeList;
                        jbo.message = "成功";
                        jbo.success = true;
                    }
                    else
                    {
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "数据为空";
                        jbo.success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //没有任何数据
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现其他错误。";
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