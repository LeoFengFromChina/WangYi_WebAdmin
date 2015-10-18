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
    public partial class WG_MenberValidate : BaseForm
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
            Button_submit1.Click += new EventHandler(Button_submit_Click);
            Button_submit2.Click += new EventHandler(Button_submit_Click);
            Button_NoPassTo2.Click += Button_NoPassTo1_Click;
            Button_NoPassTo1.Click += Button_NoPassTo1_Click;
            init_form(ctrID);
        }

        private void Button_NoPassTo1_Click(object sender, EventArgs e)
        {
            //不通过

            WG_MenberEntity _entity = DataProvider.GetInstance().GetWG_MenberEntity(int.Parse(ctrID));
            //当前身份
            string flagStr = _WG_MenberEntity.Flag == 1 ? "求助者" : _WG_MenberEntity.Flag == 2 ? "自愿者" : "游客";
            int flag = int.Parse(ddl_Flag.SelectedValue);
            _entity.Flag = flag;
            _entity.Status = 0;

            string flagStr2 = flag == 1 ? "求助者" : flag == 2 ? "自愿者" : "游客";
            DataProvider.GetInstance().UpdateWG_Menber(_entity);


            NoticeEntity ne = new NoticeEntity();
            ne.FromUserID = 0;
            ne.ToUserID = ctrID;
            ne.Title = "系统审核消息";
            ne.CreateDate = DateTime.Now;
            ne.NoticeContent = "您申请成为 [ " + flagStr + " ] 身份不通过，并贬为 ["+ flagStr2 + " ]，请注意完善您个人的真实信息。";

            //给用户一条消息
            DataProvider.GetInstance().AddNotice(ne);

            Alert("授权完成");

        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                WG_MenberEditFunc(ctrID);
            }
        }

        #region 初始化表单
        //当前身份
        WG_MenberEntity _WG_MenberEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_MenberEntity = DataProvider.GetInstance().GetWG_MenberEntity(int.Parse(ctrID));

                //当前身份
                string flagStr = _WG_MenberEntity.Flag == 1 ? "求助者" : _WG_MenberEntity.Flag == 2 ? "自愿者" : "游客";

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

        #region 编辑
        protected void WG_MenberEditFunc(string ctrID)
        {
            //通过授权
            _WG_MenberEntity.Status = 0;
            try
            {
                //当前身份
                string flagStr = _WG_MenberEntity.Flag == 1 ? "求助者" : _WG_MenberEntity.Flag == 2 ? "自愿者" : "游客";
                DataProvider.GetInstance().UpdateWG_Menber(_WG_MenberEntity);

                NoticeEntity ne = new NoticeEntity();
                ne.FromUserID = 0;
                ne.ToUserID = ctrID;
                ne.Title = "系统审核消息";
                ne.CreateDate = DateTime.Now;
                ne.NoticeContent = "恭喜您，您申请成为 [ " + flagStr + " ] 身份已通过管理员审核。";

                //给用户一条消息
                DataProvider.GetInstance().AddNotice(ne);
            }
            catch
            {
                WriteLog("WG_MenberEditFunc", "用户授权", "用户授权时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("用户授权时出错，请重试");
                return;
            }
            Alert("用户授权成功", "");
        }
        #endregion
    }
}