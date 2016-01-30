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
                string opc = context.Request["opc"];//1为加入团队，2为退出团队,3解散团队，4获取团队成员，5.创建团队
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
                    string whereStr = " 1=1 ";
                    if ("1".Equals(opc.Trim()))
                    {
                        #region 加入团队

                        whereStr += " and menberid=" + menberid + " AND teamid=" + teamid;
                        IList<WG_OnGoingTeamEntity> ogteList = DataProvider.GetInstance().GetWG_OnGoingTeamList(whereStr);
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

                            #region 通知创建团队的那个人 add by frde 20160130

                            WG_TeamEntity te = DataProvider.GetInstance().GetWG_TeamEntity(ogte.TeamID);
                            if(te!= null)
                            {
                                AddNoticeToWG("新队员加入信息", "您好，ID为: "+ menberid.ToString()+" 的用户加入了您创建的团队：[ "+te.Name+" ]", te.CaptainID.ToString());
                            }


                            #endregion

                            jbo.code = 0;
                            jbo.data = null;
                            jbo.success = true;
                            jbo.message = "成功加入团队";
                        }
                        #endregion
                    }
                    else if ("2".Equals(opc.Trim()))
                    {
                        #region 退出团队

                        whereStr += " and menberid=" + menberid + " AND teamid=" + teamid;
                        IList<WG_OnGoingTeamEntity> ogteList = DataProvider.GetInstance().GetWG_OnGoingTeamList(whereStr);
                        if (ogteList != null && ogteList.Count > 0)
                        {
                            foreach (WG_OnGoingTeamEntity item in ogteList)
                            {
                                DataProvider.GetInstance().DeleteWG_OnGoingTeam(item.ID);
                            }

                            #region 通知创建团队的那个人 add by frde 20160130

                            WG_TeamEntity te = DataProvider.GetInstance().GetWG_TeamEntity(int.Parse(teamid));
                            if (te != null)
                            {
                                AddNoticeToWG("队友退出团队信息", "您好，ID为: " + menberid.ToString() + " 的用户退出了您创建的团队：[ " + te.Name + " ]", te.CaptainID.ToString());
                            }


                            #endregion
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
                        #endregion
                    }
                    else if ("3".Equals(opc))
                    {
                        #region 解散团队
                        //1删除团队信息
                        DataProvider.GetInstance().DeleteWG_Team(int.Parse(teamid));

                        //2.删除所有已经加入团队的关系
                        whereStr += " And Teamid=" + teamid;
                        IList<WG_OnGoingTeamEntity> ote = DataProvider.GetInstance().GetWG_OnGoingTeamList(whereStr);
                        if (ote != null && ote.Count > 0)
                        {
                            WG_TeamEntity te = DataProvider.GetInstance().GetWG_TeamEntity(int.Parse(teamid));
                            foreach (WG_OnGoingTeamEntity item in ote)
                            {
                                DataProvider.GetInstance().DeleteWG_OnGoingTeam(item.ID);

                                #region 通知创建团队的那个人 add by frde 20160130

                                if (te != null)
                                {
                                    AddNoticeToWG("团队解散通知","你加入的团队：[ " + te.Name + " ]已 被解散，请知悉。", item.MenberID.ToString());
                                }


                                #endregion
                            }
                        }

                        jbo.code = 0;
                        jbo.data = null;
                        jbo.message = "团队解散成功";
                        jbo.success = true;
                        #endregion
                    }
                    else if ("4".Equals(opc))
                    {
                        #region 获取团队成员列表

                        whereStr += " And Teamid=" + teamid;
                        IList<WG_OnGoingTeamEntity> ote = DataProvider.GetInstance().GetWG_OnGoingTeamList(whereStr);
                        IList<WG_MenberEntity> meList = new List<WG_MenberEntity>();
                        if (ote != null && ote.Count > 0)
                        {
                            foreach (WG_OnGoingTeamEntity item in ote)
                            {
                                WG_MenberEntity me = DataProvider.GetInstance().GetWG_MenberEntity(item.MenberID);
                                meList.Add(me);
                            }
                        }
                        jbo.code = 0;
                        jbo.data = meList;
                        jbo.message = "获取团队成员列表成功";
                        jbo.success = true;

                        #endregion
                    }
                    else if ("5".Equals(opc))
                    {
                        //创建团队。判断权限
                        string name = context.Request["name"];
                        string captainid = context.Request["captainid"];
                        string linkman = context.Request["linkman"];
                        string linkphone = context.Request["linkphone"];
                        string linkaddress = context.Request["linkaddress"];
                        string teamaim = context.Request["teamaim"];
                        string serviceintention = context.Request["serviceintention"];
                        string region = context.Request["region"];


                        if (!string.IsNullOrEmpty(name)
                            && !string.IsNullOrEmpty(linkman)
                            && !string.IsNullOrEmpty(linkphone))
                        {
                            WG_TeamEntity te = new WG_TeamEntity();
                            te.Name = name;
                            te.CaptainID = int.Parse(menberid);
                            te.LinkAddress = linkaddress;
                            te.LinkMan = linkman;
                            te.LinkPhone = linkphone;
                            te.TeamAim = teamaim;
                            te.ServiceIntention = serviceintention;
                            te.Region = region;
                            te.CreateDate = DateTime.Now;
                            te.UpdateDate = DateTime.Now;
                            int newTeamid = DataProvider.GetInstance().AddWG_Team(te);

                            //创建完成，自己立马加入团队

                            WG_OnGoingTeamEntity ogte = new WG_OnGoingTeamEntity();
                            ogte.MenberID = int.Parse(menberid);
                            ogte.TeamID = newTeamid;
                            ogte.CreateDate = DateTime.Now;
                            DataProvider.GetInstance().AddWG_OnGoingTeam(ogte);

                            AddNoticeToWG("团队创建成功", "你的：[ " + te.Name + " ]团队已成功创建，请担当起团队责任。", te.CaptainID.ToString());
                            //创建成功
                            jbo.code = 0;
                            jbo.data = null;
                            jbo.message = "团队创建成功";
                            jbo.success = true;
                        }
                        else
                        {
                            //缺少必要信息，不能创建
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.message = "标题，联系方式，联系人不能为空";
                            jbo.success = false;
                        }
                    }
                    else
                    {
                        #region 非法操作

                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "非法操作";
                        jbo.success = false;

                        #endregion
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
