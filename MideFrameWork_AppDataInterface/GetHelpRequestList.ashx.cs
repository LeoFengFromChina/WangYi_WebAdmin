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

            string PromoterIDstr = context.Request["PromoterID"];//求助者ID
            string UnderTakerIDstr = context.Request["UnderTakerID"];//帮助者ID
            string TypeID = context.Request["TypeID"];//1求助，2帮助
            string whereStr = " 1= 1 ";
            if (!string.IsNullOrEmpty(TypeID))
            {
                whereStr += " AND TypeID=" + TypeID;
            }
            if (!string.IsNullOrEmpty(PromoterIDstr))
            {
                whereStr += " AND PromoterID=" + PromoterIDstr;
            }
            if (!string.IsNullOrEmpty(UnderTakerIDstr))
            {
                whereStr += " AND UnderTakerID=" + UnderTakerIDstr;
            }
            whereStr += " ";//加多一个空格，避免sql的语法问题

            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;
            try
            {
                // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                IList<WG_HelpRequestEntity> _HelpRequest = DataProvider.GetInstance().GetWG_HelpRequestList(20, whereStr, " CreateDate Desc ");
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