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
    public class GetGiftList : BaseForm, IHttpHandler
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
                string MenberID = context.Request["MenberID"];//用户ID

                string ID = context.Request["ID"];
                string PageIndex = "1";
                if (!string.IsNullOrEmpty(context.Request["PageIndex"]))
                    PageIndex = context.Request["PageIndex"];

                string whereStr = " 1=1 ";
                if (!string.IsNullOrEmpty(MenberID))
                {
                    //MenberID不为空，则说明是获取用户已经申请领取的礼物列表
                    whereStr += " AND MenberID=" + MenberID;
                    whereStr += " ";//加多一个空格，避免sql的语法问题

                    //IList<WG_OnGoingGiftsEntity> OnGoingGiftList = DataProvider.GetInstance().GetWG_OnGoingGiftsList(whereStr);
                    int recordCount = -1;
                    int pageCount = -1;

                    //如果传了ID，就只有一条
                    if (!string.IsNullOrEmpty(ID))
                    {
                        whereStr = " Status=0 AND ID=" + ID;
                    }

                    // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                    IList<WG_OnGoingGiftsEntity> OnGoingGiftList = DataProvider.GetInstance().GetWG_OnGoingGiftsList(20, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                    //如果所有数据分页后的总页数比请求的页数小，则返回空。
                    if (int.Parse(PageIndex) > pageCount)
                        OnGoingGiftList.Clear();

                    if (OnGoingGiftList != null && OnGoingGiftList.Count > 0)
                    {
                        List<OnGoingGiftsView> oggvList = new List<OnGoingGiftsView>();
                        foreach (WG_OnGoingGiftsEntity item in OnGoingGiftList)
                        {
                            WG_GiftsEntity Gift = DataProvider.GetInstance().GetWG_GiftsEntity(item.GiftID);
                            if (Gift != null)
                            {
                                OnGoingGiftsView oggv = new OnGoingGiftsView();
                                oggv.ValidateCode = item.Code;
                                oggv.GiftEntity = Gift;
                                oggv.Status = item.Status;
                                oggvList.Add(oggv);
                            }
                        }

                        jbo.code = 0;
                        jbo.data = oggvList;
                        jbo.success = true;
                        jbo.message = "成功获取您的礼物列表。";

                    }
                    else
                    {
                        //不存在
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.success = false;
                        jbo.message = "你还没有领取任何礼物。";
                    }
                }
                else
                {
                    //否则为获取全部礼品列表
                    //IList<WG_GiftsEntity> giftList = DataProvider.GetInstance().GetWG_GiftsList(" Status=0 ");              
                    int recordCount = -1;
                    int pageCount = -1;
                    // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                    //如果传了ID，就只有一条
                    if (!string.IsNullOrEmpty(ID))
                    {
                        whereStr = " Status=0 AND ID=" + ID;
                    }
                    IList<WG_GiftsEntity> giftList = DataProvider.GetInstance().GetWG_GiftsList(20, int.Parse(PageIndex), " WHERE " + whereStr, " CreateDate Desc ", out recordCount, out pageCount);

                    //如果所有数据分页后的总页数比请求的页数小，则返回空。
                    if (int.Parse(PageIndex) > pageCount)
                        giftList.Clear();


                    if (giftList != null && giftList.Count > 0)
                    {
                        jbo.code = 0;
                        jbo.data = giftList;
                        jbo.success = true;
                        jbo.message = "成功获取所有礼物列表。";
                    }
                    else
                    {
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.success = false;
                        jbo.message = "礼物列表为空。";
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

    public class OnGoingGiftsView
    {
        public string ValidateCode { get; set; }

        public WG_GiftsEntity GiftEntity { get; set; }

        public int Status { get; set; }
    }
}