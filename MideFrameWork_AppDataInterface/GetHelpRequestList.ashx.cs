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
            context.Response.ContentType = "text/plain";
            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;
            try
            {

                IList<WG_HelpRequestEntity> _HelpRequest = DataProvider.GetInstance().GetWG_HelpRequestList(20, "", " CreateDate Desc ");
                IList<RequestView> requestList = new List<RequestView>();
                foreach (WG_HelpRequestEntity item in _HelpRequest)
                {
                    RequestView rv = new RequestView();
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

}