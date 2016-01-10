using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetActivityList 的摘要说明
    /// </summary>
    public class GetActivityList : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // todo: [KnownType(typeof(List<WG_ActivitiesEntity>))]

            //todo:加入跨域允许语句
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");

            context.Response.ContentType = "text/plain";
            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;
            try
            {

                string ID = context.Request["ID"];
                int count = 20;
                string countStr = context.Request["Count"];
                if (!string.IsNullOrEmpty(countStr))
                    int.TryParse(countStr, out count);

                //获取活动列表，所有活动和我的活动
                string menberID = context.Request["menberID"];

                string promoterID = context.Request["promoterID"];

                string PageIndex = "1";
                if (!string.IsNullOrEmpty(context.Request["PageIndex"]))
                    PageIndex = context.Request["PageIndex"];

                string whereStr = " 1 = 1 ";
                if (string.IsNullOrEmpty(menberID)
                    && string.IsNullOrEmpty(promoterID))
                {
                    //所有活动
                    //IList<WG_ActivitiesEntity> ae = DataProvider.GetInstance().GetWG_ActivitiesList(" 1=1 ");
                    //如果传了ID，就只有一条
                    if (!string.IsNullOrEmpty(ID))
                    {
                        whereStr = " ID=" + ID;
                    }

                    int recordCount = -1;
                    int pageCount = -1;
                    // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                    IList<WG_ActivitiesEntity> ae = DataProvider.GetInstance().GetWG_ActivitiesList(count, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                    //如果所有数据分页后的总页数比请求的页数小，则返回空。
                    if (int.Parse(PageIndex) > pageCount)
                        ae.Clear();

                    if (ae != null && ae.Count > 0)
                    {
                        jbo.code = 0;
                        jbo.data = ae;
                        jbo.message = "成功";
                        jbo.success = true;
                    }
                    else
                    {
                        //没有任何数据
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "活动列表为空";
                        jbo.success = false;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(menberID))
                    {
                        //我的活动
                         whereStr = " menberID = " + menberID;

                        //IList<WG_OnGoingActivitiesEntity> ogae = DataProvider.GetInstance().GetWG_OnGoingActivitiesList(whereStr);
                        int recordCount = -1;
                        int pageCount = -1;
                        // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                        IList<WG_OnGoingActivitiesEntity> ogae = DataProvider.GetInstance().GetWG_OnGoingActivitiesList(count, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                        //如果所有数据分页后的总页数比请求的页数小，则返回空。
                        if (int.Parse(PageIndex) > pageCount)
                            ogae.Clear();


                        if (null != ogae && ogae.Count > 0)
                        {
                            IList<WG_ActivitiesEntity> aeList = new List<WG_ActivitiesEntity>();
                            foreach (WG_OnGoingActivitiesEntity item in ogae)
                            {
                                WG_ActivitiesEntity ae = DataProvider.GetInstance().GetWG_ActivitiesEntity(item.ActivityID);
                                if (null != ae)
                                {
                                    aeList.Add(ae);
                                }
                            }

                            jbo.code = 0;
                            jbo.data = aeList;
                            jbo.message = "成功获取我的活动";
                            jbo.success = true;
                        }
                        else
                        {
                            //没有任何数据
                            //没有任何数据
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.message = "您还未参加任何活动";
                            jbo.success = false;
                        }
                    }
                    else if (!string.IsNullOrEmpty(promoterID))
                    {
                        //我发布的活动
                         whereStr = " promoterid = " + promoterID;
                        //IList<WG_OnGoingActivitiesEntity> ogae = DataProvider.GetInstance().GetWG_OnGoingActivitiesList(whereStr);
                        int recordCount = -1;
                        int pageCount = -1;
                        // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                        IList<WG_ActivitiesEntity> aeList = DataProvider.GetInstance().GetWG_ActivitiesList(count, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                        //如果所有数据分页后的总页数比请求的页数小，则返回空。
                        if (int.Parse(PageIndex) > pageCount)
                            aeList.Clear();

                        if (aeList != null && aeList.Count > 0)
                        {
                            jbo.code = 0;
                            jbo.data = aeList;
                            jbo.message = "成功获取我的活动";
                            jbo.success = true;
                        }
                        else
                        {
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.message = "你还没有发布任何活动";
                            jbo.success = false;
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
}