using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetGiftList 的摘要说明
    /// </summary>
    public class ModifyPsw : BaseForm, IHttpHandler
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
                string OldPsw = context.Request["oldPsw"];//旧用户密码MD5值
                string NewPsw = context.Request["newPsw"];//新用户密码MD5值
                string UserIDStr = context.Request["menberID"];//用户ID

                int userID = -1;

                if (!string.IsNullOrEmpty(OldPsw)
                    && !string.IsNullOrEmpty(NewPsw)
                    && !string.IsNullOrEmpty(UserIDStr)
                    && int.TryParse(UserIDStr, out userID))
                {
                    //1.判断用户是否存在
                    WG_MenberEntity curMenber = DataProvider.GetInstance().GetWG_MenberEntity(userID);
                    if (curMenber == null)
                    {
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.success = false;
                        jbo.message = "用户不存在.";
                    }
                    else
                    {
                        IList<WG_MenberEntity> menberList = DataProvider.GetInstance().GetWG_MenberList(" ID=" + userID + "  AND Psw='" + OldPsw + "'");
                        if (menberList == null || menberList.Count <= 0)
                        {
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.success = false;
                            jbo.message = "旧密码有误.";
                        }
                        else
                        {
                            curMenber.Psw = NewPsw;
                            if (DataProvider.GetInstance().UpdateWG_Menber(curMenber))
                            {
                                jbo.code = 0;
                                jbo.data = null;
                                jbo.success = true;
                                jbo.message = "成功.";
                            }
                            else
                            {
                                jbo.code = -1;
                                jbo.data = null;
                                jbo.success = false;
                                jbo.message = "数据更新是出错.";
                            }
                        }
                    }

                }
                else
                {
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.success = false;
                    jbo.message = "参数有误.";
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