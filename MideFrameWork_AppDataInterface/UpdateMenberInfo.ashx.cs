using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using System.Configuration;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// UpdateMenberInfo 的摘要说明
    /// </summary>
    public class UpdateMenberInfo : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //todo:加入跨域允许语句
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");

            JsonBaseObject jbo = new JsonBaseObject();
            string resultStr = string.Empty;

            try
            {
                string menberid = context.Request["menberid"];
                if (string.IsNullOrEmpty(menberid))
                {
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "用户ID不能为空";
                    jbo.success = false;
                }
                else
                {
                    WG_MenberEntity me = DataProvider.GetInstance().GetWG_MenberEntity(int.Parse(menberid));
                    if (me != null)
                    {
                        string psw = context.Request["psw"];
                        if (psw != null)
                            me.Psw = psw;
                        string avatar_url = ConfigurationManager.AppSettings["HostUrl"].ToString() + "imgs//" + context.Request["avatar_url"]; //context.Request["avatar_url"];
                        if (avatar_url != null)
                            me.PhotoUrl = avatar_url;
                        string nickname = context.Request["nickname"];
                        if (nickname != null)
                            me.NickName = nickname;
                        string sex = context.Request["sex"];
                        if (sex != null)
                            me.Sex = sex;
                        string birthday = context.Request["birthday"];
                        if (birthday != null)
                            me.Birthday = birthday;
                        string phoneNumber = context.Request["phoneNumber"];
                        if (phoneNumber != null)
                            me.Phone = phoneNumber;
                        string email = context.Request["email"];
                        if (email != null)
                            me.Email = email;
                        string QQnumber = context.Request["QQnumber"];
                        if (QQnumber != null)
                            me.QQ = QQnumber;
                        string country = context.Request["country"];
                        if (country != null)
                            me.Country = country;
                        string province = context.Request["province"];
                        if (province != null)
                            me.Province = province;
                        string city = context.Request["city"];
                        if (city != null)
                            me.City = city;
                        string district = context.Request["district"];
                        if (district != null)
                            me.District = district;
                        string community = context.Request["community"];
                        if (community != null)
                            me.Community = community;
                        string personalid = context.Request["identity"];
                        if (personalid != null)
                            me.PersonalID = personalid;
                        string address = context.Request["address"];
                        if (address != null)
                            me.Address = address;
                        string weixinNumber = context.Request["weixinNumber"];
                        if (weixinNumber != null)
                            me.WeChat = weixinNumber;
                        string education = context.Request["education"];
                        if (education != null)
                            me.Education = education;
                        string profession = context.Request["profession"];
                        if (profession != null)
                            me.Major = profession;
                        string speciality = context.Request["speciality"];
                        if (speciality != null)
                            me.SpecialSkill = speciality;
                        string intention = context.Request["intention"];
                        if (intention != null)
                            me.ServiceIntention = intention;
                        string intentionTime = context.Request["intentionTime"];
                        if (intentionTime != null)
                            me.ServiceTimeInterval = intentionTime;
                        string flag = context.Request["flag"];
                        if (flag != null)
                        {
                            if (int.Parse(flag) > me.Flag)
                            {
                                me.Flag = int.Parse(flag);
                                me.Status = 1;//越级升级需要重新审核
                            }
                        }

                        if (DataProvider.GetInstance().UpdateWG_Menber(me))
                        {
                            jbo.code = 0;
                            jbo.data = null;
                            jbo.message = "成功";
                            jbo.success = true;
                        }
                        else
                        {
                            jbo.code = -1;
                            jbo.data = null;
                            jbo.message = "更新用户数据失败";
                            jbo.success = false;
                        }
                    }
                    else
                    {
                        //用户不存在
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "用户不存在";
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