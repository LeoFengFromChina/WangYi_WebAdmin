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
    public class GetMyTeamList : BaseForm, IHttpHandler
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
                string menberID = context.Request["menberid"];
                string teamName = context.Request["teamname"];
                string PageIndex = "1";
                if (!string.IsNullOrEmpty(context.Request["PageIndex"]))
                    PageIndex = context.Request["PageIndex"];
                if (string.IsNullOrEmpty(menberID) && string.IsNullOrEmpty(teamName))
                {
                    //失败
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "参数必须有用户ID或者团队名称";
                    jbo.success = false;
                }
                else
                {
                    int recordCount = -1;
                    int pageCount = -1;
                    string whereStr = " 1=1 ";
                    if (!string.IsNullOrEmpty(menberID))
                    {
                        //MenberID不为空，则说明是获取用户已经加入的团队
                        whereStr += " AND MenberID=" + menberID;
                        // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                        IList<WG_OnGoingTeamEntity> OnGoingTeamList = DataProvider.GetInstance().GetWG_OnGoingTeamList(20, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                        //如果所有数据分页后的总页数比请求的页数小，则返回空。
                        if (int.Parse(PageIndex) > pageCount)
                            OnGoingTeamList.Clear();

                        if (OnGoingTeamList != null && OnGoingTeamList.Count > 0)
                        {
                            List<WG_TeamEntity> teList = new List<WG_TeamEntity>();
                            foreach (WG_OnGoingTeamEntity item in OnGoingTeamList)
                            {
                                WG_TeamEntity team = DataProvider.GetInstance().GetWG_TeamEntity(item.TeamID);
                                if (team != null)
                                {
                                    teList.Add(team);
                                }
                            }

                            jbo.code = 0;
                            jbo.data = teList;
                            jbo.success = true;
                            jbo.message = "成功获取用户所加入的团队列表。";
                        }
                        else
                        {
                            //不存在
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.success = false;
                            jbo.message = "你还没有加入任何团队。";
                        }
                    }
                    else if (!string.IsNullOrEmpty(teamName))
                    {
                        //teamName不为空，按团队名称模糊搜索
                        whereStr += " AND name like '%" + teamName + "%' ";
                        // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                        IList<WG_TeamEntity> teList = DataProvider.GetInstance().GetWG_TeamList(20, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                        //如果所有数据分页后的总页数比请求的页数小，则返回空。
                        if (int.Parse(PageIndex) > pageCount)
                            teList.Clear();

                        if (teList != null && teList.Count > 0)
                        {
                            jbo.code = 0;
                            jbo.data = teList;
                            jbo.success = true;
                            jbo.message = "成功获取查询的团队列表。";
                        }
                        else
                        {
                            //不存在
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.success = false;
                            jbo.message = "查询的团队列表失败。";
                        }
                    }
                    else
                    {

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

    public class TeamView
    {
        public WG_MenberEntity Captitan { get; set; }
        public WG_TeamEntity Team { get; set; }
    }
}