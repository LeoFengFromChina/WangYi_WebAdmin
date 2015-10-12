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
    public partial class GroupsEdit : BaseForm
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
                GroupsAdd();
            }
            else
            {
                GroupsEditFunc(ctrID);
            }
        }

        #region 初始化表单
        GroupsEntity _GroupsEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _GroupsEntity = DataProvider.GetInstance().GetGroupsEntity(int.Parse(ctrID));

                TextBox_GroupName.Text = _GroupsEntity.GroupName.ToString();
                TextBox_DisplayIndex.Text = _GroupsEntity.DisplayIndex.ToString();
            }
        }
        #endregion

        #region 新增
        protected void GroupsAdd()
        {
            #region 判断是否可空


            var _GroupName = Request.Form["TextBox_GroupName"];
            if (string.IsNullOrEmpty(_GroupName))
            {
                Alert("[ 分组名称 ]不能为空");
                return;
            }

            var _DisplayIndex = Request.Form["TextBox_DisplayIndex"];
            if (string.IsNullOrEmpty(_DisplayIndex))
            {
                Alert("[ 显示顺序 ]不能为空");
                return;
            }

            #endregion

            #region 获取数据

            GroupsEntity _GroupsEntity = new GroupsEntity();



            _GroupsEntity.GroupName = Convert.ToString(_GroupName.ToString());

            _GroupsEntity.DisplayIndex = Convert.ToInt32(_DisplayIndex.ToString());
            _GroupsEntity.CreateDate = DateTime.Now;
            _GroupsEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().AddGroups(_GroupsEntity);
            }
            catch
            {
                WriteLog("GroupsAdd", "添加Groups", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Groups成功");
        }
            #endregion
        #endregion
        #region 编辑
        protected void GroupsEditFunc(string ctrID)
        {
            #region 判断是否可空


            var _GroupName = Request.Form["TextBox_GroupName"];
            if (string.IsNullOrEmpty(_GroupName))
            {
                Alert("[ 分组名称 ]不能为空");
                return;
            }

            var _DisplayIndex = Request.Form["TextBox_DisplayIndex"];
            if (string.IsNullOrEmpty(_DisplayIndex))
            {
                Alert("[ 显示顺序 ]不能为空");
                return;
            }

            #endregion




            _GroupsEntity.GroupName = Convert.ToString(_GroupName.ToString());


            _GroupsEntity.DisplayIndex = Convert.ToInt32(_DisplayIndex.ToString());
            _GroupsEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().UpdateGroups(_GroupsEntity);
            }
            catch
            {
                WriteLog("GroupsEditFunc", "编辑Groups", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Groups资料成功", "");
        }
        #endregion
    }
}