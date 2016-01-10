using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetHelpRequestList 的摘要说明
    /// </summary>
    public class GetHelpRequestList : BaseForm, IHttpHandler
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
                string ID = context.Request["ID"];
                string region = context.Request["Region"];
                int count = 20;
                string countStr = context.Request["Count"];
                if (!string.IsNullOrEmpty(countStr))
                    int.TryParse(countStr, out count);
                string menberID = context.Request["menberID"];//求助者ID
                string Type = context.Request["Type"];//1求助，2帮助
                string serviceIntention = context.Request["ServiceIntention"];
                string PageIndex = "1";
                if (!string.IsNullOrEmpty(context.Request["PageIndex"]))
                    PageIndex = context.Request["PageIndex"];
                string whereStr = " 1 = 1 ";

                if (!string.IsNullOrEmpty(region))
                    whereStr += "  AND Region Like '%" + region + "%'";
                if (!string.IsNullOrEmpty(serviceIntention))
                {
                    //加入服务意愿查询
                    whereStr += "  AND ServiceIntention Like '%" + serviceIntention + "%'";
                }
                if (!string.IsNullOrEmpty(menberID))
                {
                    if (Type == "1")
                    {
                        whereStr += " AND ((Type=1 AND PromoterID=" + menberID + ") OR (Type=2 AND UnderTakerID=" + menberID + "))";
                    }
                    else if (Type == "2")
                    {
                        whereStr += " AND ((Type=2 AND PromoterID=" + menberID + ") OR (Type=1 AND UnderTakerID=" + menberID + "))";
                    }
                }
                else
                {
                    //不传用用户ID时，选择指定类型即可
                    if (!string.IsNullOrEmpty(Type))
                        whereStr += "AND Type= " + Type;
                }
                whereStr += " ";//加多一个空格，避免sql的语法问题

                //如果传了ID，就只有一条
                if (!string.IsNullOrEmpty(ID))
                {
                    whereStr = " ID=" + ID;
                }


                int recordCount = -1;
                int pageCount = -1;
                // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                IList<WG_HelpRequestEntity> _HelpRequest = DataProvider.GetInstance().GetWG_HelpRequestList(count, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                //如果所有数据分页后的总页数比请求的页数小，则返回空。
                if (int.Parse(PageIndex) > pageCount)
                    _HelpRequest.Clear();


                IList<RequestView> requestList = new List<RequestView>();
                foreach (WG_HelpRequestEntity item in _HelpRequest)
                {
                    RequestView rv = new RequestView();
                    rv.ID = item.ID;
                    rv.HelpRequest = item;
                    requestList.Add(rv);
                }
                if (requestList.Count > 0)
                {
                    for (int i = 0; i < requestList.Count; i++)
                    {

                        WG_MenberEntity author = DataProvider.GetInstance().GetWG_MenberEntity(requestList[i].HelpRequest.PromoterID);
                        if (null != author)
                        {
                            requestList[i].Author = author;
                        }
                        WG_MenberEntity underTaker = DataProvider.GetInstance().GetWG_MenberEntity(requestList[i].HelpRequest.UnderTakerID);
                        if (null != underTaker)
                        {
                            requestList[i].Helper = underTaker;
                        }
                    }

                    //没有任何数据
                    jbo.code = 0;
                    jbo.data = requestList;
                    jbo.message = "成功。";
                    jbo.success = true;

                }
                else
                {
                    //没有任何数据
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "没有找到任何数据。";
                    jbo.success = false;
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



    public class RequestView
    {
        public int ID { get; set; }

        public WG_HelpRequestEntity HelpRequest { get; set; }

        public WG_MenberEntity Author { get; set; }

        public WG_MenberEntity Helper { get; set; }
    }
}