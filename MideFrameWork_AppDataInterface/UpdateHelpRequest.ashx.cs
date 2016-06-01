using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// UpdateHelpRequest 的摘要说明
    /// </summary>
    public class UpdateHelpRequest : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //1.承接
            //2.完成操作
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");
            context.Response.ContentType = "text/plain";
            JsonBaseObject jbo = new JsonBaseObject();
            string resultStr = string.Empty;
            try
            {

                string helpRequestStr = context.Request["helpRequestID"];//请求单号
                string underTakerStr = context.Request["underTakerID"]; //接单者ID
                string status = context.Request["status"]; //动作状态
                int helpRequestID = int.Parse(helpRequestStr);
                int underTakerID = int.Parse(underTakerStr);
                WG_HelpRequestEntity currEntity = DataProvider.GetInstance().GetWG_HelpRequestEntity(helpRequestID);
                WG_MenberEntity underTaker = new WG_MenberEntity();
                WG_MenberEntity Requestor = DataProvider.GetInstance().GetWG_MenberEntity(currEntity.PromoterID);
                if (currEntity != null)
                {
                    if (currEntity.Status > 1)
                    {
                        //非法操作
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "单子已完成";
                        jbo.success = false;

                        resultStr = JsonSerializer<JsonBaseObject>(jbo);
                        context.Response.Write(resultStr);
                    }
                    else
                    {
                        if (currEntity.Status == 0 && status == "1")
                        {
                            #region 接单===配对
                            //承接
                            currEntity.Status = 1;
                            if (!string.IsNullOrEmpty(underTakerStr))
                                currEntity.UnderTakerID = underTakerID;

                            currEntity.UpdateDate = DateTime.Now;

                            //统一更新单子
                            bool result = DataProvider.GetInstance().UpdateWG_HelpRequest(currEntity);
                            if (result)
                            {
                                //接单成功
                                jbo.code = 0;
                                jbo.data = null;
                                jbo.message = "接单成功。";
                                jbo.success = true;

                            }
                            else
                            {
                                //接单失败
                                jbo.code = -1;
                                jbo.data = null;
                                jbo.message = "接单失败。";
                                jbo.success = false;
                            }

                            #region 通知接单人

                            NoticeEntity ne = new NoticeEntity();
                            ne.Title = "您的求助/帮助已被承接";
                            ne.ToUserID = currEntity.PromoterID.ToString();//通知发帖人
                            ne.NoticeType = 1;//1求助帮助，2.活动类型，3.礼物类型
                            ne.LinkId = currEntity.ID;
                            ne.CreateDate = DateTime.Now;
                            ne.NoticeContent = "您的承接的求助单[ " + currEntity.Title + " ]已被承接。";
                            try
                            {
                                DataProvider.GetInstance().AddNotice(ne);
                            }
                            catch (Exception ex)
                            {

                            }
                            #endregion

                            #region respone

                            resultStr = JsonSerializer<JsonBaseObject>(jbo);
                            context.Response.Write(resultStr);

                            #endregion

                            #endregion
                        }
                        else if (currEntity.Status == 1 && status == "2")
                        {
                            #region 完成订单

                            currEntity.Status = 2;
                            currEntity.UpdateDate = DateTime.Now;
                            //完成
                            underTaker = DataProvider.GetInstance().GetWG_MenberEntity(currEntity.UnderTakerID);
                            //2.更新承接人服务时常
                            if (currEntity.Type == 1 && underTaker != null)
                            {
                                underTaker.ServiceHours += currEntity.Duration;
                                underTaker.Scores += currEntity.Duration * 60;
                                //积分明细

                            }
                            else if (currEntity.Type == 2 && Requestor != null)
                            {
                                Requestor.ServiceHours += currEntity.Duration;
                                Requestor.Scores += currEntity.Duration * 60;
                            }
                            else
                            {
                                //接单人不存在
                                jbo.code = -1;
                                jbo.data = null;
                                jbo.message = "接单人不存在";
                                jbo.success = false;

                                #region respone

                                resultStr = JsonSerializer<JsonBaseObject>(jbo);
                                context.Response.Write(resultStr);

                                #endregion
                            }

                            //统一更新单子
                            bool result = DataProvider.GetInstance().UpdateWG_HelpRequest(currEntity);
                            if (!result)
                            {
                                #region 更新订单出错

                                jbo.code = -1;
                                jbo.data = null;
                                jbo.message = "更新订单出错";
                                jbo.success = false;

                                #region respone

                                resultStr = JsonSerializer<JsonBaseObject>(jbo);
                                context.Response.Write(resultStr);

                                #endregion

                                #endregion
                            }
                            //3.承接者数据更新
                            bool utakerResult = false;
                            if (currEntity.Type == 1)
                                utakerResult = DataProvider.GetInstance().UpdateWG_Menber(underTaker);
                            else if (currEntity.Type == 2)
                                utakerResult = DataProvider.GetInstance().UpdateWG_Menber(Requestor);
                            if (!result)
                            {
                                #region 更新接单人信息出错

                                jbo.code = -1;
                                jbo.data = null;
                                jbo.message = "更新接单人信息出错";
                                jbo.success = false;

                                #region respone

                                resultStr = JsonSerializer<JsonBaseObject>(jbo);
                                context.Response.Write(resultStr);

                                #endregion

                                #endregion
                            }
                            else
                            {

                                #region 通知接单人
                                //1.
                                NoticeEntity ne = new NoticeEntity();
                                ne.Title = "您承接的单被发起人标记为完成状态";
                                ne.ToUserID = underTaker.ID.ToString();
                                ne.NoticeType = 1;//1求助帮助，2.活动类型，3.礼物类型
                                ne.LinkId = currEntity.ID;
                                ne.CreateDate = DateTime.Now;
                                ne.NoticeContent = "您的承接的求助单[ " + currEntity.Title + " ]已被发起人完成，您已获得：" + currEntity.Duration + "的积分和服务时常累积。感谢您的爱心奉献与付出。";
                                try
                                {
                                    DataProvider.GetInstance().AddNotice(ne);
                                }
                                catch (Exception ex)
                                {

                                }
                                #endregion
                                #region 完成订单成功
                                //接单成功
                                jbo.code = 0;
                                jbo.data = null;
                                jbo.message = "完成订单成功。";
                                jbo.success = true;

                                #endregion
                                #region respone

                                resultStr = JsonSerializer<JsonBaseObject>(jbo);
                                context.Response.Write(resultStr);

                                #endregion
                            }

                            #endregion
                        }
                        else if (currEntity.Status == 1 && status == "3")
                        {

                            #region 失约重发 20160110


                            #region 通知接单人
                            //1.
                            string noticeMsg = "";
                            NoticeEntity ne = new NoticeEntity();
                            ne.Title = "您承接的单被发起人标记为失约并重新发布了";
                            ne.ToUserID = currEntity.UnderTakerID.ToString();
                            ne.NoticeType = 1;//1求助帮助，2.活动类型，3.礼物类型
                            ne.LinkId = currEntity.ID;
                            ne.CreateDate = DateTime.Now;

                            ne.NoticeContent = "您的承接的求助单[ " + currEntity.Title + " ]已被发起人重新发出，您此次失约了，请注意与发帖人沟通好。";
                            try
                            {
                                DataProvider.GetInstance().AddNotice(ne);
                            }
                            catch (Exception ex)
                            {
                                noticeMsg = ex.ToString();
                            }
                            #endregion

                            try
                            {
                                //1.修改订单的状态，从已配对（1）改回原来的待配对（0）
                                currEntity.Status = 0;
                                //2.清空承接人信息
                                currEntity.UnderTakerID = -1;//表示没有人承接
                                currEntity.UpdateDate = DateTime.Now;

                                DataProvider.GetInstance().UpdateWG_HelpRequest(currEntity);
                                //接单成功
                                jbo.code = 0;
                                jbo.data = null;
                                jbo.message = "失约重发成功。" + noticeMsg;
                                jbo.success = true;
                            }
                            catch (Exception)
                            {
                                jbo.code = -1;
                                jbo.data = null;
                                jbo.message = "失约重发失败。";
                                jbo.success = false;
                                throw;
                            }


                            #region respone

                            resultStr = JsonSerializer<JsonBaseObject>(jbo);
                            context.Response.Write(resultStr);

                            #endregion
                            #endregion
                        }
                        else
                        {
                        }
                    }
                }
                else
                {
                    //失败
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "所更新的记录不存在。";
                    jbo.success = false;
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