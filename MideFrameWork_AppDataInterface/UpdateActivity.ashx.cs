using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using System.Data;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// UpdateActivity 的摘要说明
    /// </summary>
    public class UpdateActivity : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // todo: [KnownType(typeof(List<WG_ActivitiesEntity>))]

            //todo:加入跨域允许语句
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");

            JsonBaseObject jbo = new JsonBaseObject();
            string resultStr = string.Empty;

            try
            {
                string menberID = context.Request["menberID"];
                string activityID = context.Request["activityID"];
                string opc = context.Request["opc"];//1参加活动，2退出活动，3完成活动（发起人权利),4撤销活动,5.获取活动参与者列表，6发布活动


                if (string.IsNullOrEmpty(menberID)
                    || string.IsNullOrEmpty(activityID)
                    || string.IsNullOrEmpty(opc))
                {
                    //参数空
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "用户ID/活动ID/状态都不能为空";
                    jbo.success = false;
                }
                else
                {
                    //当前活动，ae.Status，0等待报名...，1活动正在进行(禁止报名),2,活动已结束
                    WG_ActivitiesEntity ae = new WG_ActivitiesEntity();
                    if (!string.IsNullOrEmpty(activityID))
                        ae = DataProvider.GetInstance().GetWG_ActivitiesEntity(int.Parse(activityID));
                    
                    if (opc == "6")
                    {
                        //发布活动，需要权限
                        string title = context.Request["title"];
                        string promoterid = context.Request["promoterid"];
                        string linkman = context.Request["linkman"];
                        string linkphone = context.Request["linkphone"];
                        string linkaddress = context.Request["linkaddress"];
                        string activitytype = context.Request["activitytype"];
                        string region = context.Request["region"];
                        string begintime = context.Request["begintime"];
                        string needmenbercount = context.Request["needmenbercount"];
                        string detail = context.Request["detail"];

                        if (!string.IsNullOrEmpty(title)
                            && !string.IsNullOrEmpty(linkman)
                            && !string.IsNullOrEmpty(linkphone))
                        {
                            WG_ActivitiesEntity aee = new WG_ActivitiesEntity();
                            aee.Title = title;
                            aee.PromoterID = int.Parse(menberID);
                            aee.LinkMan = linkman;
                            aee.LinkPhone = linkphone;
                            aee.Address = linkaddress;
                            aee.ActivityType = activitytype;
                            aee.Region = region;
                            aee.NeedMenberCount = int.Parse(needmenbercount);
                            aee.Detail = detail;
                            aee.BeginTime = Convert.ToDateTime(begintime);
                            aee.Status = 0;//正在报名中
                            aee.CreateDate = DateTime.Now;
                            aee.UpdateDate = DateTime.Now;

                            DataProvider.GetInstance().AddWG_Activities(aee);
                            //成功
                            jbo.code = 0;
                            jbo.data = null;
                            jbo.message = "创建活动成功";
                            jbo.success = false;

                        }
                        else
                        {
                            //信息不够，不能创建
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.message = "标题，联系人、联系电话不能为空";
                            jbo.success = false;
                        }
                    }
                    else if (null == ae)
                    {
                        //活动不存在
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "活动不存在";
                        jbo.success = false;
                    }
                    else if (opc == "5")
                    {
                        #region 获取活动参与者列表
                        string whereStr = " activityID=" + activityID;
                        IList<WG_OnGoingActivitiesEntity> ogaeList = DataProvider.GetInstance().GetWG_OnGoingActivitiesList(whereStr);

                        IList<WG_MenberEntity> meList = new List<WG_MenberEntity>();
                        if (ogaeList != null && ogaeList.Count > 0)
                        {
                            foreach (WG_OnGoingActivitiesEntity item in ogaeList)
                            {
                                WG_MenberEntity me = DataProvider.GetInstance().GetWG_MenberEntity(item.MenberID);
                                meList.Add(me);
                            }
                        }
                        jbo.code = 0;
                        jbo.data = meList;
                        jbo.message = "成功获取活动参与者列表";
                        jbo.success = true;

                        #endregion
                    }
                    else if (ae.Status == 2)
                    {
                        //活动已经结束
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "活动已经结束";
                        jbo.success = false;
                    }
                    else if (ae.Status == 1 && opc != "3")
                    {
                        //活动已经开始
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "活动已经开始了";
                        jbo.success = false;
                    }
                    else if (ae.Status == 0 && opc == "4" && ae.PromoterID == int.Parse(menberID))
                    {
                        //只有在等待报名的活动才可以撤销，已经开始或者已经结束的都不可以撤销

                        //1.删除这个活动
                        DataProvider.GetInstance().DeleteWG_Activities(int.Parse(activityID));

                        //2.删除报名列表
                        string whereStr = " 1=1 AND activityID=" + activityID;
                        IList<WG_OnGoingActivitiesEntity> ogae = DataProvider.GetInstance().GetWG_OnGoingActivitiesList(whereStr);
                        if (ogae != null && ogae.Count > 0)
                        {
                            foreach (WG_OnGoingActivitiesEntity item in ogae)
                            {
                                DataProvider.GetInstance().DeleteWG_OnGoingActivities(item.ID);
                            }
                        }

                        //活动已经开始
                        jbo.code = 0;
                        jbo.data = null;
                        jbo.message = "撤销活动成功";
                        jbo.success = true;

                    }
                    else
                    {
                        //判断是否已经参加
                        string whereStr = " status= 0 " + " AND  menberID= " + menberID + " AND activityID= " + activityID;
                        IList<WG_OnGoingActivitiesEntity> ogaeList = DataProvider.GetInstance().GetWG_OnGoingActivitiesList(whereStr);

                        if ("1" == opc)
                        {
                            #region 1参加活动
                            if (null != ogaeList && ogaeList.Count > 0)
                            {
                                //已经参加
                                jbo.code = -1;
                                jbo.data = null;
                                jbo.message = "您已参加了活动，无需重复";
                                jbo.success = false;
                            }
                            else
                            {
                                //判断参加活动的人数是否已经满了
                                string sql = " select * from dbo.WG_OnGoingActivities where ActivityID=" + activityID + " and Status=0 ";
                                DataSet ds = DbHelperSQL.Query(sql);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >= ae.NeedMenberCount)
                                {
                                    //人已经满了
                                    jbo.code = -1;
                                    jbo.data = null;
                                    jbo.message = "活动人数已满";
                                    jbo.success = false;
                                }
                                else
                                {
                                    //在WG_OnGoingActivitiesEntity新增一条记录
                                    WG_OnGoingActivitiesEntity ogae = new WG_OnGoingActivitiesEntity();
                                    ogae.ActivityID = int.Parse(activityID);
                                    ogae.MenberID = int.Parse(menberID);
                                    ogae.Status = 0;
                                    ogae.CreateDate = DateTime.Now;
                                    DataProvider.GetInstance().AddWG_OnGoingActivities(ogae);

                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count + 1 == ae.NeedMenberCount)
                                    {
                                        //人满了
                                        ae.Status = 1;//活动被激活
                                        DataProvider.GetInstance().UpdateWG_Activities(ae);
                                    }

                                    AddNoticeToWG("您发布的活动有新成员参加", "您发布的活动：[ "+ae.Title+" ] 有新成员加入，请知悉。", ae.PromoterID.ToString(),2,ae.ID);

                                    jbo.code = 0;
                                    jbo.data = null;
                                    jbo.message = "成功参加活动";
                                    jbo.success = true;
                                }
                            }
                            #endregion

                        }
                        else if ("2" == opc)
                        {
                            //2只能是退出活动，如果是激活活动，是不能人工的，需要自动人数到了触发活动
                            #region 退出活动
                            if (null != ogaeList && ogaeList.Count > 0)
                            {
                                foreach (WG_OnGoingActivitiesEntity item in ogaeList)
                                {
                                    DataProvider.GetInstance().DeleteWG_OnGoingActivities(item.ID);
                                    AddNoticeToWG("有成员退出了您发布的活动", "您发布的活动：[ " + ae.Title + " ] 有成员退出，请知悉。", ae.PromoterID.ToString(), 2, ae.ID);
                                }

                                jbo.code = 0;
                                jbo.data = null;
                                jbo.message = "成功退出活动";
                                jbo.success = true;
                            }
                            else
                            {
                                //活动不存在
                                jbo.code = -1;
                                jbo.data = null;
                                jbo.message = "你并未参加活动";
                                jbo.success = false;
                            }
                            #endregion
                        }
                        else if ("3" == opc)
                        {
                            //3活动完成,发起人有权限
                            ae.Status = 2;
                            DataProvider.GetInstance().UpdateWG_Activities(ae);

                            jbo.code = 0;
                            jbo.data = null;
                            jbo.message = "完成活动成功";
                            jbo.success = true;
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
            }
            catch (Exception ex)
            {
                //失败
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现其他错误";
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