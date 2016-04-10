using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using System.Data;
using System.Configuration;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetNoticeList 的摘要说明
    /// </summary>
    public class GetUpdate : BaseForm, IHttpHandler
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
                string jsonData= "[{\"appversion\":\"{#version#}\",\"appurl\":\"{#url#}\"}]";
                string appversion = ConfigurationManager.AppSettings["CurrentAppVirson"].ToString();
                string appurl = ConfigurationManager.AppSettings["CurrentAppDownLoadURL"].ToString();
                if(!string.IsNullOrEmpty(appversion)
                    && !string.IsNullOrEmpty(appurl))
                {
                    jsonData = jsonData.Replace("{#version#}", appversion).Replace("{#url#}", appurl);
                    jbo.code = 0;
                    jbo.data = jsonData;
                    jbo.message = "成功";
                    jbo.success = true;
                }
                else
                {
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "没有相关版本信息";
                    jbo.success = false;
                }
            }
            catch (Exception ex)
            {
                //没有任何数据
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现其他错误：" + ex;
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