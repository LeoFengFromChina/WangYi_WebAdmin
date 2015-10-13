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
            string MenberID = "1";// context.Request["MenberID"];//用户ID

            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;
            if (!string.IsNullOrEmpty(MenberID))
            {
                string whereStr = " 1=1 ";
                //MenberID不为空，则说明是获取用户已经申请领取的礼物列表
                whereStr += " AND MenberID=" + MenberID;
                whereStr += " ";//加多一个空格，避免sql的语法问题
                IList<WG_OnGoingGiftsEntity> OnGoingGiftList = DataProvider.GetInstance().GetWG_OnGoingGiftsList(whereStr);
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
                IList<WG_GiftsEntity> giftList = DataProvider.GetInstance().GetWG_GiftsList(" Status=0 ");
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