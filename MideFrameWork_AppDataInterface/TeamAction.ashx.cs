using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// TeamAtion 的摘要说明
    /// </summary>
    public class TeamAction : BaseForm, IHttpHandler
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
                string opc = context.Request["opc"];//1为加入团队，2为退出团队
                string menberid = context.Request["menberid"];
                string teamid = context.Request["teamid"];
                string PageIndex = "1";
                if (!string.IsNullOrEmpty(context.Request["PageIndex"]))
                    PageIndex = context.Request["PageIndex"];
                if (string.IsNullOrEmpty(menberid)
                    || string.IsNullOrEmpty(teamid)
                    || string.IsNullOrEmpty(opc))
                {
                    //失败
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "参数:用户ID,团队ID和操作代码都不能为空";
                    jbo.success = false;
                }
                else
                {
                    string whereStr = " menberid=" + menberid + " AND teamid=" + teamid;
                    IList<WG_OnGoingTeamEntity> ogteList = DataProvider.GetInstance().GetWG_OnGoingTeamList(whereStr);
                    if ("1".Equals(opc.Trim()))
                    {
                        if (ogteList != null && ogteList.Count > 0)
                        {
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.success = false;
                            jbo.message = "你已经加入了团队，无需重复加入";
                        }
                        else
                        {
                            //加入团队
                            WG_OnGoingTeamEntity ogte = new WG_OnGoingTeamEntity();
                            ogte.MenberID = int.Parse(menberid);
                            ogte.TeamID = int.Parse(teamid);
                            ogte.CreateDate = DateTime.Now;
                            DataProvider.GetInstance().AddWG_OnGoingTeam(ogte);

                            jbo.code = 0;
                            jbo.data = null;
                            jbo.success = true;
                            jbo.message = "成功加入团队";
                        }
                    }
                    else if ("2".Equals(opc.Trim()))
                    {
                        //退出团队

                        if (ogteList != null && ogteList.Count > 0)
                        {
                            foreach (WG_OnGoingTeamEntity item in ogteList)
                            {
                                DataProvider.GetInstance().DeleteWG_OnGoingTeam(item.ID);
                            }
                            //成功
                            jbo.code = 0;
                            jbo.data = null;
                            jbo.success = true;
                            jbo.message = "成功退出团队";

                        }
                        else
                        {
                            //还未加入团队
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.message = "你尚未加入团队";
                            jbo.success = false;
                        }
                    }
                    else
                    {
                        //非法操作
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "非法操作";
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