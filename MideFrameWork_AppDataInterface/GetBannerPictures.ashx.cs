using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetBannerPictures 的摘要说明
    /// </summary>
    public class GetBannerPictures : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");
            context.Response.ContentType = "text/plain";
            string GroupID = context.Request["GroupID"];
            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(GroupID))
                {
                    string whereStr = " IsEnable=0 AND GroupID=" + GroupID;
                    IList<GlobalPictureEntity> pictureList = DataProvider.GetInstance().GetGlobalPictureList(5,whereStr, " DisplayIndex ASC");
                    if (pictureList != null && pictureList.Count > 0)
                    {
                        //数据
                        jbo.code = 0;
                        jbo.data = pictureList;
                        jbo.message = "成功。";
                        jbo.success = true;
                    }
                    else
                    {
                        //没有任何数据
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "没有任何数据。";
                        jbo.success = false;
                    }
                }
                else
                {
                    //没有任何数据
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "必须指定分组ID以获取图片列表。";
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