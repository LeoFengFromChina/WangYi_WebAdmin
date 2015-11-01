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
    public partial class WG_ServiceIntentionEdit : BaseForm
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
                WG_ServiceIntentionAdd();
            }
            else
            {
                WG_ServiceIntentionEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_ServiceIntentionEntity _WG_ServiceIntentionEntity = null;
        WG_ServiceIntentionEntity _WG_ServiceIntentionEntity_parent = null;
        protected void init_form(string ctrID)
        {
            IList<WG_ServiceIntentionEntity> regionList = DataProvider.GetInstance().GetWG_ServiceIntentionList(" 1 = 1 ");

            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_ServiceIntentionEntity = DataProvider.GetInstance().GetWG_ServiceIntentionEntity(int.Parse(ctrID));

                _WG_ServiceIntentionEntity_parent = DataProvider.GetInstance().GetWG_ServiceIntentionEntity(_WG_ServiceIntentionEntity.ParentID);

            }
            if (!IsPostBack)
            {
                //初始化父菜单
                //var parentIdDataSource = from parentIdTabels in regionList where parentIdTabels.ParentID == 0 select parentIdTabels;
                var parentIdDataSource = from parentIdTabels in regionList where 1 == 1 select parentIdTabels;
                DropDownList_parentId.DataSource = parentIdDataSource;
                DropDownList_parentId.DataTextField = "Content";
                DropDownList_parentId.DataValueField = "ID";
                DropDownList_parentId.DataBind();
                DropDownList_parentId.Items.Insert(0, new ListItem("全部", "0"));


            }
            #region 编辑
            if (!string.IsNullOrEmpty(ctrID))
            {
                if (_WG_ServiceIntentionEntity_parent != null)
                {
                    DropDownList_parentId.ClearSelection();
                    DropDownList_parentId.Items.FindByText(_WG_ServiceIntentionEntity_parent.Content).Selected = true;
                }
                TextBox_Content.Text = _WG_ServiceIntentionEntity.Content.ToString();
            }
            #endregion
        }
        #endregion

        #region 新增
        protected void WG_ServiceIntentionAdd()
        {
            #region 判断是否可空


            var _ParentID = DropDownList_parentId.SelectedItem.Value;
            if (string.IsNullOrEmpty(_ParentID))
            {
                Alert("[ 父ID ]不能为空");
                return;
            }

            var _Content = Request.Form["TextBox_Content"];
            if (string.IsNullOrEmpty(_Content))
            {
                Alert("[ 意向名称 ]不能为空");
                return;
            }

            #endregion

            #region 获取数据

            WG_ServiceIntentionEntity _WG_ServiceIntentionEntity = new WG_ServiceIntentionEntity();


            _WG_ServiceIntentionEntity.ParentID = Convert.ToInt32(_ParentID.ToString());


            _WG_ServiceIntentionEntity.Content = Convert.ToString(_Content.ToString());

            _WG_ServiceIntentionEntity.CreateDate = DateTime.Now;

            _WG_ServiceIntentionEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().AddWG_ServiceIntention(_WG_ServiceIntentionEntity);
            }
            catch
            {
                WriteLog("WG_ServiceIntentionAdd", "添加WG_ServiceIntention", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_ServiceIntention成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_ServiceIntentionEditFunc(string ctrID)
        {
            #region 判断是否可空		 


            var _ParentID = DropDownList_parentId.SelectedItem.Value;
            if (string.IsNullOrEmpty(_ParentID))
            {
                Alert("[ 父ID ]不能为空");
                return;
            }

            var _Content = Request.Form["TextBox_Content"];
            if (string.IsNullOrEmpty(_Content))
            {
                Alert("[ 意向名称 ]不能为空");
                return;
            }

            #endregion



            _WG_ServiceIntentionEntity.ParentID = Convert.ToInt32(_ParentID.ToString());



            _WG_ServiceIntentionEntity.Content = Convert.ToString(_Content.ToString());

            _WG_ServiceIntentionEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().UpdateWG_ServiceIntention(_WG_ServiceIntentionEntity);
            }
            catch
            {
                WriteLog("WG_ServiceIntentionEditFunc", "编辑WG_ServiceIntention", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_ServiceIntention资料成功", "");
        }
        #endregion
    }
}