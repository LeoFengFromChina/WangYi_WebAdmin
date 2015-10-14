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
                if (currEntity != null)
                {
                    if (currEntity.Status > 1)
                    {
                        //非法操作
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "非法操作";
                        jbo.success = false;

                        resultStr = JsonSerializer<JsonBaseObject>(jbo);
                        context.Response.Write(resultStr);
                    }
                    else
                    {
                        if (currEntity.Status == 0)
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
                            #region respone

                            resultStr = JsonSerializer<JsonBaseObject>(jbo);
                            context.Response.Write(resultStr);

                            #endregion

                            #endregion
                        }
                        else if (currEntity.Status == 1)
                        {
                            #region 完成订单

                            currEntity.Status = 2;
                            currEntity.UpdateDate = DateTime.Now;
                            //完成
                            underTaker = DataProvider.GetInstance().GetWG_MenberEntity(currEntity.UnderTakerID);
                            //2.更新承接人服务时常
                            if (underTaker != null)
                            {
                                underTaker.ServiceHours += currEntity.Duration;
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
                            bool utakerResult = DataProvider.GetInstance().UpdateWG_Menber(underTaker);
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