﻿using System;
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
            try
            {//giftid,userid,validatecode
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
                        //领取码=年月日时分秒+id后四位（不够四位前补零）
                        string timespan = DateTime.Now.ToString("yyyyMMddhhmmss");
                        string idSub = string.Empty;
                        if (me.ID.ToString().Length < 4)
                            idSub = me.ID.ToString().PadLeft(4, '0');
                        else
                        {
                            idSub = me.ID.ToString().Substring(me.ID.ToString().Length - 4, 4);
                        }
                        ogge.Code = timespan + idSub;
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
            }
            catch (Exception ex)
            {
                //失败
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现其他错误";
                jbo.success = false;
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
