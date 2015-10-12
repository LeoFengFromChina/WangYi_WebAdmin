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
    public partial class RegisterDetailEdit : BaseForm
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
            //初始化日期选择事件
            TextBox_CreateDate.Attributes.Add("onclick", "MyCalendar.SetDate(this);");
            Button_submit.Click += new EventHandler(Button_submit_Click);

            ctrID = Request.QueryString["ctrID"];
            init_form(ctrID);
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                RegisterDetailAddFunc();
            }
            else
            {
                RegisterDetailEditFunc(ctrID);
            }
        }

        #region 初始化表单
        protected void init_form(string ctrID)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                return;
            }

            IList<RegisterDetailEntity> RegisterDetail = DataProvider.GetInstance().GetRegisterDetailList(" ID=" + ctrID);
            if (RegisterDetail.ToList().Count == 0)
            {
                Alert("参数错误");
                return;
            }
            var RegisterDetailTable = RegisterDetail.ToList()[0];
            TextBox_UserID.Text = RegisterDetailTable.UserID.ToString();
            TextBox_Mac.Text = RegisterDetailTable.Mac;
            TextBox_IP.Text = RegisterDetailTable.IP;
            TextBox_CreateDate.Text = RegisterDetailTable.CreateDate.ToString();
        }
        #endregion

        #region 添加详细注册信息
        protected void RegisterDetailAddFunc()
        {
            int UserId = 0;
            if (!int.TryParse(Request.Form["TextBox_UserID"], out UserId))
            {
                Alert("用户ID错误");
                return;
            }
            IList<UsersEntity> UserExist = DataProvider.GetInstance().GetUsersList(" ID=" + UserId);
            if (UserExist.ToList().Count == 0)
            {
                Alert("不存在该用户");
                return;
            }

            DateTime CreateDate = new DateTime();
            if (!DateTime.TryParse(Request.Form["TextBox_CreateDate"], out CreateDate))
            {
                Alert("日期格式错误");
                return;
            }

            RegisterDetailEntity RegisterDetailInsert = new RegisterDetailEntity();
            RegisterDetailInsert.UserID = UserId;
            RegisterDetailInsert.Mac = Request.Form["TextBox_Mac"];
            RegisterDetailInsert.IP = Request.Form["TextBox_IP"];
            RegisterDetailInsert.CreateDate = Convert.ToDateTime(Request.Form["TextBox_CreateDate"]);
            try
            {
                DataProvider.GetInstance().AddRegisterDetail(RegisterDetailInsert);
            }
            catch
            {
                WriteLog("RegisterDetailAddFunc", "添加新信息到注册详细信息表", "添加新信息到注册详细信息表时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加信息时发生错误");
                return;
            }
            Alert("添加详细注册信息成功");
        }
        #endregion

        #region 编辑详细注册信息
        protected void RegisterDetailEditFunc(string ctrID)
        {
            int ID = 0;
            if (!int.TryParse(ctrID, out ID))
            {
                Alert("参数必段为数字");
                return;
            }

            IList<UsersEntity> user = DataProvider.GetInstance().GetUsersList(" ID=" + Request.Form["TextBox_UserID"].Trim());
            if (user.ToList().Count == 0)
            {
                Alert("该用户ID不存在");
                return;
            }

            DateTime CreateDate = new DateTime();
            if (!DateTime.TryParse(Request.Form["TextBox_CreateDate"], out CreateDate))
            {
                Alert("日期格式错误");
                return;
            }

            RegisterDetailEntity RegisterDetail = new RegisterDetailEntity();
            RegisterDetail.ID = ID;
            RegisterDetail.UserID = Convert.ToInt32(Request.Form["TextBox_UserID"]);
            RegisterDetail.Mac = Request.Form["TextBox_Mac"];
            RegisterDetail.IP = Request.Form["TextBox_IP"];
            RegisterDetail.CreateDate = CreateDate;
            try
            {
                DataProvider.GetInstance().UpdateRegisterDetail(RegisterDetail);
            }
            catch
            {
                WriteLog("RegisterDetailAddFunc", "更新详细注册信息表", "更新详细注册信息表时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新信息时发生错误");
                return;
            }
            Alert("更新注册信息成功","?ctrID="+ID);
        }
        #endregion
    }
}