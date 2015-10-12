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
using MideFrameWork.Common.DailyUtility;

namespace MideFrameWork.UI.WebSite.Admin
{
    public partial class MenuEdit : BaseForm
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
                MenuAdd();
            }
            else
            {
                MenuEditFunc(ctrID);
            }
        }

        #region 初始化表单
        MenuEntity _MenuEntity = null;
        MenuEntity _MenuEntity_parent = null;
        GroupsEntity _GroupEnty = null;
        protected void init_form(string ctrID)
        {
            //取得menu表
            IList<MenuEntity> menuList = DataProvider.GetInstance().GetMenuList(" 1 = 1 ");

            //获取权限表
            IList<GroupsEntity> groupList = DataProvider.GetInstance().GetGroupsList(" 1 = 1 ");

            if (!string.IsNullOrEmpty(ctrID))
            {
                _MenuEntity = DataProvider.GetInstance().GetMenuEntity(int.Parse(ctrID));

                _MenuEntity_parent = DataProvider.GetInstance().GetMenuEntity(_MenuEntity.ParentID);

                _GroupEnty = DataProvider.GetInstance().GetGroupsEntity(_MenuEntity.GroupID);
            }
            if (!IsPostBack)
            {
                //初始化父菜单
                var parentIdDataSource = from parentIdTabels in menuList where parentIdTabels.ParentID == 0 select parentIdTabels;
                DropDownList_parentId.DataSource = parentIdDataSource;
                DropDownList_parentId.DataTextField = "DisplayName";
                DropDownList_parentId.DataValueField = "ID";
                DropDownList_parentId.DataBind();
                DropDownList_parentId.Items.Insert(0, new ListItem("顶级菜单", "0"));


                DropDownList_Group.DataSource = groupList;
                DropDownList_Group.DataTextField = "GroupName";
                DropDownList_Group.DataValueField = "ID";
                DropDownList_Group.DataBind();
                DropDownList_Group.Items.Insert(0, new ListItem("选择分组", "0"));

                DropDownList_Status.DataSource = new List<Status> { new Status(0, "正常"), new Status(1, "暂停"), new Status(2, "已删除") };
                DropDownList_Status.DataTextField = "Text";
                DropDownList_Status.DataValueField = "ID";
                DropDownList_Status.DataBind();
                DropDownList_Status.Items.Insert(0, new ListItem("选择状体", "-1"));

                #region 编辑
                if (!string.IsNullOrEmpty(ctrID))
                {
                    if (_MenuEntity_parent != null)
                    {
                        DropDownList_parentId.ClearSelection();
                        DropDownList_parentId.Items.FindByText(_MenuEntity_parent.DisplayName).Selected = true;
                    }
                    TextBox_DisplayName.Text = _MenuEntity.DisplayName.ToString();
                    TextBox_DisplayIndex.Text = _MenuEntity.DisplayIndex.ToString();
                    if (_GroupEnty != null)
                    {
                        DropDownList_Group.ClearSelection();
                        DropDownList_Group.Items.FindByText(_GroupEnty.GroupName).Selected = true;
                    }
                    TextBox_LinkUrl.Text = _MenuEntity.LinkUrl.ToString();
                    TextBox_ImageUrl.Text = _MenuEntity.ImageUrl.ToString();
                    if (_MenuEntity != null)
                    {
                        DropDownList_Status.ClearSelection();
                        DropDownList_Status.Items.FindByValue(_MenuEntity.Status.ToString()).Selected = true;
                    }
                }
                #endregion
            }
        }
        #endregion

        #region 新增
        protected void MenuAdd()
        {
            #region 判断是否可空


            var _ParentID = DropDownList_parentId.SelectedItem.Value;
            if (string.IsNullOrEmpty(_ParentID))
            {
                Alert("[ 父节点ID ]不能为空");
                return;
            }

            var _DisplayName = Request.Form["TextBox_DisplayName"];
            if (string.IsNullOrEmpty(_DisplayName))
            {
                Alert("[ 显示名称 ]不能为空");
                return;
            }

            var _DisplayIndex = Request.Form["TextBox_DisplayIndex"];
            if (string.IsNullOrEmpty(_DisplayIndex))
            {
                //Alert("[ 显示顺序 ]不能为空");
                //return;
                _DisplayIndex = "0";
            }

            var _GroupID = DropDownList_Group.SelectedItem.Value;
            if (string.IsNullOrEmpty(_GroupID))
            {
                Alert("[ 权限组ID ]不能为空");
                return;
            }

            var _LinkUrl = Request.Form["TextBox_LinkUrl"];
            //if (string.IsNullOrEmpty(_LinkUrl))
            //{
            //    Alert("[ 链接URL ]不能为空");
            //    return;
            //}

            var _ImageUrl = Request.Form["TextBox_ImageUrl"];
            //if (string.IsNullOrEmpty(_ImageUrl))
            //{
            //    Alert("[ 图片URL ]不能为空");
            //    return;
            //}

            var _Status = DropDownList_Status.SelectedItem.Value;
            if (string.IsNullOrEmpty(_Status) || int.Parse(_Status) < 0)
            {
                Alert("[ 当前状态 ]不能为空");
                return;
            }

            #endregion

            #region 获取数据

            MenuEntity _MenuEntity = new MenuEntity();


            _MenuEntity.ParentID = Convert.ToInt32(_ParentID.ToString());


            _MenuEntity.DisplayName = Convert.ToString(_DisplayName.ToString());

            _MenuEntity.DisplayIndex = Convert.ToInt32(_DisplayIndex.ToString());

            _MenuEntity.GroupID = Convert.ToInt32(_GroupID.ToString());


            _MenuEntity.LinkUrl = Convert.ToString(_LinkUrl.ToString());


            _MenuEntity.ImageUrl = Convert.ToString(_ImageUrl.ToString());

            _MenuEntity.Status = Convert.ToInt32(_Status.ToString());

            _MenuEntity.CreateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().AddMenu(_MenuEntity);
            }
            catch
            {
                WriteLog("MenuAdd", "添加Menu", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Menu成功");
        }
            #endregion
        #endregion
        #region 编辑
        protected void MenuEditFunc(string ctrID)
        {
            #region 判断是否可空


            var _ParentID = DropDownList_parentId.SelectedItem.Value;
            if (string.IsNullOrEmpty(_ParentID))
            {
                Alert("[ 父节点ID ]不能为空");
                return;
            }

            var _DisplayName = Request.Form["TextBox_DisplayName"];
            if (string.IsNullOrEmpty(_DisplayName))
            {
                Alert("[ 显示名称 ]不能为空");
                return;
            }

            var _DisplayIndex = Request.Form["TextBox_DisplayIndex"];
            if (string.IsNullOrEmpty(_DisplayIndex))
            {
                //Alert("[ 显示顺序 ]不能为空");
                //return;
                _DisplayIndex = "0";
            }

            var _GroupID = DropDownList_Group.SelectedItem.Value;
            if (string.IsNullOrEmpty(_GroupID))
            {
                Alert("[ 权限组ID ]不能为空");
                return;
            }

            var _LinkUrl = Request.Form["TextBox_LinkUrl"];
            //if (string.IsNullOrEmpty(_LinkUrl))
            //{
            //    Alert("[ 链接URL ]不能为空");
            //    return;
            //}

            var _ImageUrl = Request.Form["TextBox_ImageUrl"];
            //if (string.IsNullOrEmpty(_ImageUrl))
            //{
            //    Alert("[ 图片URL ]不能为空");
            //    return;
            //}

            var _Status = DropDownList_Status.SelectedItem.Value;
            if (string.IsNullOrEmpty(_Status) || int.Parse(_Status) < 0)
            {
                Alert("[ 当前状态 ]不能为空");
                return;
            }

            #endregion



            _MenuEntity.ParentID = int.Parse(DropDownList_parentId.SelectedValue);



            _MenuEntity.DisplayName = Convert.ToString(_DisplayName.ToString());


            _MenuEntity.DisplayIndex = Convert.ToInt32(_DisplayIndex.ToString());


            _MenuEntity.GroupID = Convert.ToInt32(_GroupID.ToString());



            _MenuEntity.LinkUrl = Convert.ToString(_LinkUrl.ToString());



            _MenuEntity.ImageUrl = Convert.ToString(_ImageUrl.ToString());


            _MenuEntity.Status = Convert.ToInt32(_Status.ToString());
            try
            {
                DataProvider.GetInstance().UpdateMenu(_MenuEntity);
            }
            catch
            {
                WriteLog("MenuEditFunc", "编辑Menu", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Menu资料成功", "");
        }
        #endregion
    }
}