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
    public partial class UserEdit : BaseForm
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
            TextBox_CreateDate.Attributes.Add("onclick", "MyCalendar.SetDate(this);");

            //表单提交事件
            Button_submit.Click += new EventHandler(Button_submit_Click);

            init_form(ctrID);
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                userAdd();
            }
            else
            {
                userEditFunc(ctrID);
            }
        }

        #region 初始化表单
        protected void init_form(string ctrID)
        {
            //取得groups表
            IList<GroupsEntity> groupsList = DataProvider.GetInstance().GetGroupsList(" 1 = 1 ");

            //初始化groups下拉框
            DropDownList_GroupID.DataSource = groupsList.ToList();
            DropDownList_GroupID.DataTextField = "GroupName";
            DropDownList_GroupID.DataValueField = "ID";
            DropDownList_GroupID.DataBind();

            //初始化状态值
            DropDownList_Status.Items.Add(new ListItem("正常", "0"));
            DropDownList_Status.Items.Add(new ListItem("停用", "1"));
            DropDownList_Status.Items.Add(new ListItem("删除", "2"));

            //初始化是否为企业管理员选项
            DropDownList_IsAdmin.Items.Add(new ListItem("是", "0"));
            DropDownList_IsAdmin.Items.Add(new ListItem("否", "1"));

            //根据ID值判断是编辑还是添加操作
            //如果是添加操作
            if (string.IsNullOrEmpty(ctrID))
            {
                TextBox_Balance.Text = "0";
            }
            //如果是编辑操作
            else
            {
                //取得user表中用户的数据
                IList<UsersEntity> userIlist = DataProvider.GetInstance().GetUsersList(" ID = " + ctrID);
                var userTable = userIlist.ToList()[0];

                TextBox_ChildAccount.Text = userTable.ChildAccount;
                TextBox_ParentAccount.Text = userTable.ParentAccount;
                DropDownList_Status.SelectedValue = userTable.Status.ToString();
                DropDownList_GroupID.SelectedValue = userTable.GroupID.ToString();
                DropDownList_IsAdmin.SelectedValue = userTable.IsAdmin.ToString();
                TextBox_Password.Text = userTable.Password;
                TextBox_CorpName.Text = userTable.CorpName;
                TextBox_Signature.Text = userTable.Signature;
                TextBox_ChannelID.Text = userTable.ChannelID.ToString();
                TextBox_Balance.Text = userTable.Balance.ToString();
                TextBox_Email.Text = userTable.Email;
                TextBox_TelePhone.Text = userTable.TelePhone;
                TextBox_MobilePhone.Text = userTable.MobilePhone;
                TextBox_CreateDate.Text = userTable.CreateDate.ToString();
            }
        }
        #endregion

        #region 添加用户
        protected void userAdd()
        {
            //获取数据
            string ChildAccount = Request.Form["TextBox_ChildAccount"];
            if (string.IsNullOrEmpty(ChildAccount))
            {
                Alert("子帐号不能为空");
                return;
            }
            string ParentAccount = Request.Form["TextBox_ParentAccount"];
            if (string.IsNullOrEmpty(ParentAccount))
            {
                Alert("企业帐号不能为空");
                return;
            }
            int Balance = Convert.ToInt32(Request.Form["TextBox_Balance"]);
            if (string.IsNullOrEmpty(Balance.ToString()))
            {
                Alert("余额不能为空");
                return;
            }
            string Password = Request.Form["TextBox_Password"];
            if (string.IsNullOrEmpty(Password))
            {
                Alert("密码不能为空");
                return;
            }
            DateTime CreateDate;
            DateTime.TryParse(Request.Form["TextBox_CreateDate"], out CreateDate);
            if (string.IsNullOrEmpty(CreateDate.ToString()))
            {
                Alert("创建时间不能为空");
                return;
            }
            int ChannelID = string.IsNullOrEmpty(Request.Form["TextBox_ChannelID"]) ? 0 : Convert.ToInt32(Request.Form["TextBox_ChannelID"]);
            int Status = Convert.ToInt32(Request.Form["DropDownList_Status.SelectedValue"]);
            int GroupID = Convert.ToInt32(Request.Form["DropDownList_GroupID"]);
            int IsAdmin = Convert.ToInt32(Request.Form["DropDownList_IsAdmin"]);
            string CorpName = Request.Form["TextBox_CorpName"];
            string Signature = Request.Form["TextBox_Signature"];
            string Email = Request.Form["TextBox_Email"];
            string TelePhone = Request.Form["TextBox_TelePhone"];
            string MobilePhone = Request.Form["TextBox_MobilePhone"];

            UsersEntity userEntity = new UsersEntity();
            userEntity.ChildAccount = ChildAccount;
            userEntity.ParentAccount = ParentAccount;
            userEntity.Status = Status;
            userEntity.GroupID = GroupID;
            userEntity.IsAdmin = IsAdmin;
            userEntity.Password = Password;
            userEntity.CorpName = CorpName;
            userEntity.Signature = Signature;
            userEntity.ChannelID = ChannelID;
            userEntity.Balance = Balance;
            userEntity.Email = Email;
            userEntity.TelePhone = TelePhone;
            userEntity.MobilePhone = MobilePhone;
            userEntity.CreateDate = CreateDate;
            userEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().AddUsers(userEntity);
            }
            catch
            {
                WriteLog("userAdd", "添加用户", "把用户数据插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加用户成功");
        }
        #endregion

        #region 编辑用户资料
        protected void userEditFunc(string ctrID)
        {
            //获取数据
            string ChildAccount = Request.Form["TextBox_ChildAccount"];
            if (string.IsNullOrEmpty(ChildAccount))
            {
                Alert("子帐号不能为空");
                return;
            }
            string ParentAccount = Request.Form["TextBox_ParentAccount"];
            if (string.IsNullOrEmpty(ParentAccount))
            {
                Alert("企业帐号不能为空");
                return;
            }
            int Balance = Convert.ToInt32(Request.Form["TextBox_Balance"]);
            if (string.IsNullOrEmpty(Balance.ToString()))
            {
                Alert("余额不能为空");
                return;
            }
            string Password = Request.Form["TextBox_Password"];
            if (string.IsNullOrEmpty(Password))
            {
                Alert("密码不能为空");
                return;
            }
            DateTime CreateDate;
            DateTime.TryParse(Request.Form["TextBox_CreateDate"], out CreateDate);
            if (string.IsNullOrEmpty(CreateDate.ToString()))
            {
                Alert("创建时间不能为空");
                return;
            }
            int ChannelID = string.IsNullOrEmpty(Request.Form["TextBox_ChannelID"]) ? 0 : Convert.ToInt32(Request.Form["TextBox_ChannelID"]);
            int Status = Convert.ToInt32(Request.Form["DropDownList_Status.SelectedValue"]);
            int GroupID = Convert.ToInt32(Request.Form["DropDownList_GroupID"]);
            int IsAdmin = Convert.ToInt32(Request.Form["DropDownList_IsAdmin"]);
            string CorpName = Request.Form["TextBox_CorpName"];
            string Signature = Request.Form["TextBox_Signature"];
            string Email = Request.Form["TextBox_Email"];
            string TelePhone = Request.Form["TextBox_TelePhone"];
            string MobilePhone = Request.Form["TextBox_MobilePhone"];

            UsersEntity userEntity = new UsersEntity();
            userEntity.ID = Convert.ToInt32(ctrID);
            userEntity.ChildAccount = ChildAccount;
            userEntity.ParentAccount = ParentAccount;
            userEntity.Status = Status;
            userEntity.GroupID = GroupID;
            userEntity.IsAdmin = IsAdmin;
            userEntity.Password = Password;
            userEntity.CorpName = CorpName;
            userEntity.Signature = Signature;
            userEntity.ChannelID = ChannelID;
            userEntity.Balance = Balance;
            userEntity.Email = Email;
            userEntity.TelePhone = TelePhone;
            userEntity.MobilePhone = MobilePhone;
            userEntity.CreateDate = CreateDate;
            userEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().UpdateUsers(userEntity);
            }
            catch
            {
                WriteLog("userEditFunc", "编辑用户资料", "把新用户数据更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新用户资料成功","");
        }
        #endregion
    }
}