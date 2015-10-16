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
    /// register 的摘要说明
    /// </summary>
    public class register : BaseForm, IHttpHandler
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
                string username = context.Request["username"];
                string psw = context.Request["psw"];
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(psw))
                {
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "账号或密码不能为空！";
                    jbo.success = false;
                    result = JsonSerializer<JsonBaseObject>(jbo);
                    context.Response.Write(result);
                }

                string whereStr = " Name ='" + username + "'";
                IList<WG_MenberEntity> userList = DataProvider.GetInstance().GetWG_MenberList(whereStr);
                if (userList.Count > 0)
                {
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "该用户已存在！";
                    jbo.success = false;
                }
                else
                {
                    try
                    {
                        string avatar_url = context.Request["avatar_url"];
                        string nickname = context.Request["nickname"];
                        string sex = context.Request["sex"];
                        string birthday = context.Request["birthday"];
                        string phoneNumber = context.Request["phoneNumber"];
                        string email = context.Request["email"];
                        string QQnumber = context.Request["QQnumber"];
                        string country = context.Request["country"];
                        string province = context.Request["province"];
                        string city = context.Request["city"];
                        string district = context.Request["district"];
                        string community = context.Request["community"];
                        string personalid = context.Request["identity"];
                        string address = context.Request["address"];
                        string weixinNumber = context.Request["weixinNumber"];
                        string education = context.Request["education"];
                        string profession = context.Request["profession"];
                        string speciality = context.Request["speciality"];
                        string intention = context.Request["intention"];
                        string intentionTime = context.Request["intentionTime"];
                        string flag = context.Request["flag"];

                        WG_MenberEntity menber = new WG_MenberEntity();
                        menber.Name = username;
                        menber.Psw = psw;
                        menber.NickName = nickname;
                        menber.PhotoUrl = avatar_url;
                        menber.Birthday = birthday;
                        menber.Phone = phoneNumber;
                        menber.Email = email;
                        menber.QQ = QQnumber;
                        menber.Country = country;
                        menber.Province = province;
                        menber.City = city;
                        menber.District = district;
                        menber.Community = community;
                        menber.PersonalID = personalid;
                        menber.Address = address;
                        menber.WeChat = weixinNumber;
                        menber.Education = education;
                        menber.Major = profession;
                        menber.SpecialSkill = speciality;
                        menber.ServiceIntention = intention;
                        menber.ServiceTimeInterval = intentionTime;
                        //0为游客，1位求助者，2为志愿者。求助者和自愿者才需要审核
                        if (int.Parse(flag) > 0)
                            menber.Status = 1;//状态:0正常,1待审核,2状态异常
                        else
                        {
                            menber.Status = 0;
                        }
                        menber.Flag = int.Parse(flag);
                        menber.Scores = 100;//初始积分100
                        menber.ServiceHours = 0;///初始服务时长为0
                        menber.CreateDate = DateTime.Now;
                        menber.UpdateDate = DateTime.Now;

                        //新增用户
                        int mID = DataProvider.GetInstance().AddWG_Menber(menber);

                        //新增得分明细表
                        WG_ScoreEntity se = new WG_ScoreEntity();
                        se.MenberID = mID;
                        se.Scores = int.Parse(ConfigurationManager.AppSettings["DefaultScore"].ToString());
                        se.CreateDate = DateTime.Now;
                        se.Title = "新用户注册获得" + se.Scores + "积分";
                        DataProvider.GetInstance().AddWG_Score(se);
                        //看看是否心中其他表


                        //返回数据
                        menber.ID = mID;
                        jbo.code = 0;
                        jbo.data = menber;
                        jbo.message = "注册成功！";
                        jbo.success = true;
                    }
                    catch (Exception ex)
                    {
                        jbo.code = -1;
                        jbo.data = null;
                        jbo.message = "注册过程中发生异常！";
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