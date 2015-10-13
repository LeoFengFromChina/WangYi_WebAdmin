using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// ExchangeForGift 的摘要说明
    /// </summary>
    public class ExchangeForGift : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");
            context.Response.ContentType = "text/plain";
            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;
            //giftid,userid,validatecode
            string giftID = context.Request["giftID"];
            string menberID = context.Request["menberID"];
            string giftCount = context.Request["giftCount"];
            string status = context.Request["status"];//0已兑换，1已领取
            int count = 0;
            int.TryParse(giftCount, out count);
            if (string.IsNullOrEmpty(giftID) || string.IsNullOrEmpty(menberID) || string.IsNullOrEmpty(giftCount))
            {
                //失败
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "礼物或领取人不存在，或兑换礼物的个数不能小于等于0";
                jbo.success = false;
            }
            else
            {
                WG_GiftsEntity ge = DataProvider.GetInstance().GetWG_GiftsEntity(int.Parse(giftID));
                WG_MenberEntity me = DataProvider.GetInstance().GetWG_MenberEntity(int.Parse(menberID));
                if (null != ge
                    && null != me
                    && me.Scores >= ge.NeedScores * count
                    && ge.Count >= count)
                {
                    //1.在ongoinggift表中新增一条记录
                    WG_OnGoingGiftsEntity ogge = new WG_OnGoingGiftsEntity();
                    ogge.Code = Guid.NewGuid().ToString();
                    ogge.MenberID = int.Parse(menberID);
                    ogge.GiftID = int.Parse(giftID);
                    ogge.Status = int.Parse(status);
                    ogge.CreateDate = DateTime.Now;
                    int addresult = DataProvider.GetInstance().AddWG_OnGoingGifts(ogge);
                    if (addresult >= 0)
                    {
                        //2.扣除兑换者的积分
                        me.Scores = me.Scores - ge.NeedScores * count;
                        if (!DataProvider.GetInstance().UpdateWG_Menber(me))
                        {
                            //失败
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.message = "扣除兑换者积分异常";
                            jbo.success = false;
                        }
                        else
                        {
                            //3.礼物表中的数量减去相应的数量
                            ge.Count = ge.Count - count;
                            if (!DataProvider.GetInstance().UpdateWG_Gifts(ge))
                            {
                                //失败
                                jbo.code = -1;
                                jbo.data = null;
                                jbo.message = "减去礼物剩余数量异常";
                                jbo.success = false;
                            }
                            else
                            {
                                //成功
                                jbo.code = 0;
                                jbo.data = null;
                                jbo.message = "成功";
                                jbo.success = true;
                            }
                        }
                    }
                    else
                    {
                        //失败
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "加入领取队列出错";
                        jbo.success = false;
                    }

                }
                else
                {
                    //失败
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "礼物不存在或积分不够";
                    jbo.success = false;
                }
            }

            #region 返回json

            result = JsonSerializer<JsonBaseObject>(jbo);
            context.Response.Write(result);

            #endregion
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