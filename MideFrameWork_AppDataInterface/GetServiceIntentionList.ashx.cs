using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetServiceIntentionList 的摘要说明
    /// </summary>
    public class GetServiceIntentionList : BaseForm, IHttpHandler
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
                IList<WG_ServiceIntentionEntity> serviceList = DataProvider.GetInstance().GetWG_ServiceIntentionList("1=1");
                var parentIdDataSource = from parentIdTabels in serviceList where parentIdTabels.ParentID == 0 select parentIdTabels;
                List<ServiceIntentionView> sivList = new List<ServiceIntentionView>();
                foreach (WG_ServiceIntentionEntity item in parentIdDataSource)
                {
                    ServiceIntentionView siv = new ServiceIntentionView();
                    siv.label = item.Content;
                    var childDataSource = from childTabels in serviceList where childTabels.ParentID == item.ID select childTabels;
                    List<ServiceIntentionView> sivListChild = new List<ServiceIntentionView>();
                    foreach (WG_ServiceIntentionEntity item2 in childDataSource)
                    {
                        ServiceIntentionView sivChild = new ServiceIntentionView();
                        sivChild.label = item2.Content;
                        sivListChild.Add(sivChild);
                    }
                    siv.childrens = sivListChild;
                    sivList.Add(siv);
                }

                jbo.code = 0;
                jbo.data = sivList;
                jbo.success = true;
                jbo.message = "成功获取服务意愿列表。";
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

    public class ServiceIntentionView
    {
        public string label { get; set; }

        public List<ServiceIntentionView> childrens { get; set; }
    }
}