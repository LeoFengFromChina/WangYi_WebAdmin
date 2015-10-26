using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using System.Collections;

namespace MideFrameWork.UI.WebSite.Admin
{
    public partial class WG_MenberEdit : BaseForm
    {
        private string ctrID
        {
            get
            {
                if (ViewState["ctrID"] != null)
                    return (string)ViewState["ctrID"];
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["ctrID"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrID = Request.QueryString["ctrID"];

            //初始化日期选择事件






























            //表单提交事件
            Button_submit.Click += new EventHandler(Button_submit_Click);

            init_form(ctrID);
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                WG_MenberAdd();
            }
            else
            {
                WG_MenberEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_MenberEntity _WG_MenberEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_MenberEntity = DataProvider.GetInstance().GetWG_MenberEntity(int.Parse(ctrID));

                TextBox_NickName.Text = _WG_MenberEntity.NickName.ToString();
                TextBox_Name.Text = _WG_MenberEntity.Name.ToString();
                //TextBox_Psw.Text = _WG_MenberEntity.Psw.ToString();
                TextBox_Scores.Text = _WG_MenberEntity.Scores.ToString();
                TextBox_Sex.Text = _WG_MenberEntity.Sex.ToString();
                TextBox_Birthday.Text = _WG_MenberEntity.Birthday.ToString();
                TextBox_Email.Text = _WG_MenberEntity.Email.ToString();
                TextBox_Flag.Text = _WG_MenberEntity.Flag.ToString();
                TextBox_PhotoUrl.Text = _WG_MenberEntity.PhotoUrl.ToString();
                TextBox_Country.Text = _WG_MenberEntity.Country.ToString();
                TextBox_Province.Text = _WG_MenberEntity.Province.ToString();
                TextBox_City.Text = _WG_MenberEntity.City.ToString();
                TextBox_District.Text = _WG_MenberEntity.District.ToString();
                TextBox_Community.Text = _WG_MenberEntity.Community.ToString();
                TextBox_Phone.Text = _WG_MenberEntity.Phone.ToString();
                TextBox_WeChat.Text = _WG_MenberEntity.WeChat.ToString();
                TextBox_QQ.Text = _WG_MenberEntity.QQ.ToString();
                TextBox_PersonalID.Text = _WG_MenberEntity.PersonalID.ToString();
                TextBox_Address.Text = _WG_MenberEntity.Address.ToString();
                TextBox_Education.Text = _WG_MenberEntity.Education.ToString();
                TextBox_Major.Text = _WG_MenberEntity.Major.ToString();
                TextBox_SpecialSkill.Text = _WG_MenberEntity.SpecialSkill.ToString();
                TextBox_ServiceIntention.Text = _WG_MenberEntity.ServiceIntention.ToString();
                TextBox_ServiceTimeInterval.Text = _WG_MenberEntity.ServiceTimeInterval.ToString();
                TextBox_ServiceHours.Text = _WG_MenberEntity.ServiceHours.ToString();
                TextBox_Status.Text = _WG_MenberEntity.Status.ToString();
            }
        }
        #endregion

        #region 新增
        protected void WG_MenberAdd()
        {
            #region 判断是否可空


            var _NickName = Request.Form["TextBox_NickName"];


            var _Name = Request.Form["TextBox_Name"];
            if (string.IsNullOrEmpty(_Name))
            {
                Alert("[ 会员名称 ]不能为空");
                return;
            }

            var _Psw = Request.Form["TextBox_Psw"];

            var _Scores = Request.Form["TextBox_Scores"];


            var _Sex = Request.Form["TextBox_Sex"];
 

            var _Birthday = Request.Form["TextBox_Birthday"];


            var _Email = Request.Form["TextBox_Email"];


            var _Flag = Request.Form["TextBox_Flag"];
    

            var _PhotoUrl = Request.Form["TextBox_PhotoUrl"];
  

            var _Country = Request.Form["TextBox_Country"];

            var _Province = Request.Form["TextBox_Province"];


            var _City = Request.Form["TextBox_City"];


            var _District = Request.Form["TextBox_District"];

            var _Community = Request.Form["TextBox_Community"];

            var _Phone = Request.Form["TextBox_Phone"];


            var _WeChat = Request.Form["TextBox_WeChat"];


            var _QQ = Request.Form["TextBox_QQ"];

            var _PersonalID = Request.Form["TextBox_PersonalID"];


            var _Address = Request.Form["TextBox_Address"];


            var _Education = Request.Form["TextBox_Education"];

            var _Major = Request.Form["TextBox_Major"];


            var _SpecialSkill = Request.Form["TextBox_SpecialSkill"];


            var _ServiceIntention = Request.Form["TextBox_ServiceIntention"];


            var _ServiceTimeInterval = Request.Form["TextBox_ServiceTimeInterval"];


            var _ServiceHours = Request.Form["TextBox_ServiceHours"];


            var _Status = Request.Form["TextBox_Status"];
            if (string.IsNullOrEmpty(_Status))
            {
                Alert("[ 当前状态 ]不能为空");
                return;
            }

            #endregion

            #region 获取数据

            WG_MenberEntity _WG_MenberEntity = new WG_MenberEntity();



            _WG_MenberEntity.NickName = Convert.ToString(_NickName.ToString());


            _WG_MenberEntity.Name = Convert.ToString(_Name.ToString());

            //要MD5
            string pswMD5 = MD5Encrypt.MD5Hash(_Psw.ToString());
            _WG_MenberEntity.Psw = Convert.ToString(pswMD5);

            _WG_MenberEntity.Scores = Convert.ToInt32(_Scores.ToString());


            _WG_MenberEntity.Sex = Convert.ToString(_Sex.ToString());


            _WG_MenberEntity.Birthday = Convert.ToString(_Birthday.ToString());


            _WG_MenberEntity.Email = Convert.ToString(_Email.ToString());

            _WG_MenberEntity.Flag = Convert.ToInt32(_Flag.ToString());


            _WG_MenberEntity.PhotoUrl = Convert.ToString(_PhotoUrl.ToString());


            _WG_MenberEntity.Country = Convert.ToString(_Country.ToString());


            _WG_MenberEntity.Province = Convert.ToString(_Province.ToString());


            _WG_MenberEntity.City = Convert.ToString(_City.ToString());


            _WG_MenberEntity.District = Convert.ToString(_District.ToString());


            _WG_MenberEntity.Community = Convert.ToString(_Community.ToString());


            _WG_MenberEntity.Phone = Convert.ToString(_Phone.ToString());


            _WG_MenberEntity.WeChat = Convert.ToString(_WeChat.ToString());


            _WG_MenberEntity.QQ = Convert.ToString(_QQ.ToString());


            _WG_MenberEntity.PersonalID = Convert.ToString(_PersonalID.ToString());


            _WG_MenberEntity.Address = Convert.ToString(_Address.ToString());


            _WG_MenberEntity.Education = Convert.ToString(_Education.ToString());


            _WG_MenberEntity.Major = Convert.ToString(_Major.ToString());


            _WG_MenberEntity.SpecialSkill = Convert.ToString(_SpecialSkill.ToString());


            _WG_MenberEntity.ServiceIntention = Convert.ToString(_ServiceIntention.ToString());


            _WG_MenberEntity.ServiceTimeInterval = Convert.ToString(_ServiceTimeInterval.ToString());

            _WG_MenberEntity.ServiceHours = Convert.ToInt32(_ServiceHours.ToString());

            _WG_MenberEntity.Status = Convert.ToInt32(_Status.ToString());

            _WG_MenberEntity.CreateDate = DateTime.Now;

            _WG_MenberEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().AddWG_Menber(_WG_MenberEntity);
            }
            catch
            {
                WriteLog("WG_MenberAdd", "添加WG_Menber", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Menber成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_MenberEditFunc(string ctrID)
        {
            #region 判断是否可空		 


            var _NickName = Request.Form["TextBox_NickName"];


            var _Name = Request.Form["TextBox_Name"];
            if (string.IsNullOrEmpty(_Name))
            {
                Alert("[ 会员名称 ]不能为空");
                return;
            }

            var _Psw = Request.Form["TextBox_Psw"];


            var _Scores = Request.Form["TextBox_Scores"];


            var _Sex = Request.Form["TextBox_Sex"];

            var _Birthday = Request.Form["TextBox_Birthday"];


            var _Email = Request.Form["TextBox_Email"];

            var _Flag = Request.Form["TextBox_Flag"];


            var _PhotoUrl = Request.Form["TextBox_PhotoUrl"];
  

            var _Country = Request.Form["TextBox_Country"];


            var _Province = Request.Form["TextBox_Province"];


            var _City = Request.Form["TextBox_City"];


            var _District = Request.Form["TextBox_District"];


            var _Community = Request.Form["TextBox_Community"];

            var _Phone = Request.Form["TextBox_Phone"];
 

            var _WeChat = Request.Form["TextBox_WeChat"];


            var _QQ = Request.Form["TextBox_QQ"];

            var _PersonalID = Request.Form["TextBox_PersonalID"];

            var _Address = Request.Form["TextBox_Address"];
  

            var _Education = Request.Form["TextBox_Education"];


            var _Major = Request.Form["TextBox_Major"];


            var _SpecialSkill = Request.Form["TextBox_SpecialSkill"];

            var _ServiceIntention = Request.Form["TextBox_ServiceIntention"];


            var _ServiceTimeInterval = Request.Form["TextBox_ServiceTimeInterval"];


            var _ServiceHours = Request.Form["TextBox_ServiceHours"];


            var _Status = Request.Form["TextBox_Status"];


            #endregion




            _WG_MenberEntity.NickName = Convert.ToString(_NickName.ToString());



            _WG_MenberEntity.Name = Convert.ToString(_Name.ToString());



            //要MD5
            string pswMD5 = MD5Encrypt.MD5Hash(_Psw.ToString());
            _WG_MenberEntity.Psw = Convert.ToString(pswMD5);


            _WG_MenberEntity.Scores = Convert.ToInt32(_Scores.ToString());



            _WG_MenberEntity.Sex = Convert.ToString(_Sex.ToString());



            _WG_MenberEntity.Birthday = Convert.ToString(_Birthday.ToString());



            _WG_MenberEntity.Email = Convert.ToString(_Email.ToString());


            _WG_MenberEntity.Flag = Convert.ToInt32(_Flag.ToString());



            _WG_MenberEntity.PhotoUrl = Convert.ToString(_PhotoUrl.ToString());



            _WG_MenberEntity.Country = Convert.ToString(_Country.ToString());



            _WG_MenberEntity.Province = Convert.ToString(_Province.ToString());



            _WG_MenberEntity.City = Convert.ToString(_City.ToString());



            _WG_MenberEntity.District = Convert.ToString(_District.ToString());



            _WG_MenberEntity.Community = Convert.ToString(_Community.ToString());



            _WG_MenberEntity.Phone = Convert.ToString(_Phone.ToString());



            _WG_MenberEntity.WeChat = Convert.ToString(_WeChat.ToString());



            _WG_MenberEntity.QQ = Convert.ToString(_QQ.ToString());



            _WG_MenberEntity.PersonalID = Convert.ToString(_PersonalID.ToString());



            _WG_MenberEntity.Address = Convert.ToString(_Address.ToString());



            _WG_MenberEntity.Education = Convert.ToString(_Education.ToString());



            _WG_MenberEntity.Major = Convert.ToString(_Major.ToString());



            _WG_MenberEntity.SpecialSkill = Convert.ToString(_SpecialSkill.ToString());



            _WG_MenberEntity.ServiceIntention = Convert.ToString(_ServiceIntention.ToString());



            _WG_MenberEntity.ServiceTimeInterval = Convert.ToString(_ServiceTimeInterval.ToString());


            _WG_MenberEntity.ServiceHours = Convert.ToInt32(_ServiceHours.ToString());


            _WG_MenberEntity.Status = Convert.ToInt32(_Status.ToString());

            _WG_MenberEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().UpdateWG_Menber(_WG_MenberEntity);
            }
            catch
            {
                WriteLog("WG_MenberEditFunc", "编辑WG_Menber", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Menber资料成功", "");
        }
        #endregion
    }
}