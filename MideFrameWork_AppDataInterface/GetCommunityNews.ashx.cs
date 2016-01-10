using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetMyTeamList 的摘要说明
    /// </summary>
    public class GetCommunityNews : BaseForm, IHttpHandler
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
                //string menberID = context.Request["menberid"];
                //string teamName = context.Request["teamname"];
                string PageIndex = "1";
                if (!string.IsNullOrEmpty(context.Request["PageIndex"]))
                    PageIndex = context.Request["PageIndex"];

                int recordCount = -1;
                int pageCount = -1;
                string whereStr = " 1=1 ";

                // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                IList<WG_CommunityNewsEntity> NewsList = DataProvider.GetInstance().GetWG_CommunityNewsList(20, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                //如果所有数据分页后的总页数比请求的页数小，则返回空。
                if (int.Parse(PageIndex) > pageCount)
                    NewsList.Clear();

                if (NewsList != null && NewsList.Count > 0)
                {
                    jbo.code = 0;
                    jbo.data = NewsList;
                    jbo.success = true;
                    jbo.message = "成功获取社区动态列表列表。";
                }
                else
                {
                    //不存在
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.success = false;
                    jbo.message = "没有任何数据";

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