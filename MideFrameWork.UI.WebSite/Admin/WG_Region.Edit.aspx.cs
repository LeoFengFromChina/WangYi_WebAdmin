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
    public partial class WG_RegionEdit : BaseForm
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
        private int CurrentEditLevel
        {
            get
            {
                if (ViewState["CurrentEditLevel"] != null)
                    return (int)ViewState["CurrentEditLevel"];
                else
                {
                    return -1;
                }
            }
            set
            {
                ViewState["CurrentEditLevel"] = value;
            }
        }

        private WG_RegionEntity _WG_RegionEntity
        {
            get
            {
                if (ViewState["_WG_RegionEntity"] != null)
                    return (WG_RegionEntity)ViewState["_WG_RegionEntity"];
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["_WG_RegionEntity"] = value;
            }
        }

        private IList<WG_RegionEntity> GlobalList
        {
            get
            {
                if (ViewState["GlobalList"] != null)
                    return (IList<WG_RegionEntity>)ViewState["GlobalList"];
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["GlobalList"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrID = Request.QueryString["ctrID"];
            DropDownList_Province.AutoPostBack = true;
            DropDownList_City.AutoPostBack = true;
            DropDownList_District.AutoPostBack = true;
            DropDownList_Town.AutoPostBack = true;
            DropDownList_Province.SelectedIndexChanged += DropDownList_Province_SelectedIndexChanged;
            DropDownList_City.SelectedIndexChanged += DropDownList_City_SelectedIndexChanged;
            DropDownList_District.SelectedIndexChanged += DropDownList_District_SelectedIndexChanged;
            if (!Page.IsPostBack)
            {
                init_form(ctrID);
            }
            Button_submit.Click += new EventHandler(Button_submit_Click);
        }

        private void DropDownList_District_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_Town.Items.Clear();
            int pID = int.Parse(DropDownList_District.SelectedValue);
            SetDropdownListData(DropDownList_Town, pID, "全区");
        }

        private void DropDownList_City_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList_District.Items.Clear();
            DropDownList_Town.Items.Clear();
            int pID = int.Parse(DropDownList_City.SelectedValue);
            SetDropdownListData(DropDownList_District, pID, "全市");
        }

        private void DropDownList_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_City.Items.Clear();
            DropDownList_District.Items.Clear();
            DropDownList_Town.Items.Clear();
            int pID = int.Parse(DropDownList_Province.SelectedValue);
            SetDropdownListData(DropDownList_City, pID, "全省");
        }

        /// <summary>
        /// 统一填充下拉框的数据
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="rangeID"></param>
        /// <param name="TopText"></param>
        private void SetDropdownListData(DropDownList ddl, int rangeID, string TopText)
        {
            ddl.Items.Clear();
            var parentIdDataSource = from parentIdTabels in GlobalList where parentIdTabels.ParentID == rangeID select parentIdTabels;
            ddl.DataSource = parentIdDataSource;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "ID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(TopText, rangeID.ToString()));
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                WG_RegionAdd();
            }
            else
            {
                WG_RegionEditFunc(ctrID);
            }
        }

        #region 初始化表单

        protected void init_form(string ctrID)
        {
            IList<WG_RegionEntity> regionList = DataProvider.GetInstance().GetWG_RegionList(" 1 = 1 ");
            GlobalList = regionList;
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(ctrID))
                {
                    _WG_RegionEntity = DataProvider.GetInstance().GetWG_RegionEntity(int.Parse(ctrID));
                    CurrentEditLevel = SetParentBinding(_WG_RegionEntity);

                }
                else
                {
                    //初始化父菜单
                    var parentIdDataSource = from parentIdTabels in regionList where parentIdTabels.ParentID == 0 select parentIdTabels;
                    DropDownList_Province.DataSource = parentIdDataSource;
                    DropDownList_Province.DataTextField = "Name";
                    DropDownList_Province.DataValueField = "ID";
                    DropDownList_Province.DataBind();
                    DropDownList_Province.Items.Insert(0, new ListItem("全国", "0"));
                    DropDownList_City.Items.Insert(0, new ListItem("全省", "0"));
                    DropDownList_District.Items.Insert(0, new ListItem("全市", "0"));
                    DropDownList_Town.Items.Insert(0, new ListItem("全区", "0"));
                }
            }
        }

        protected int SetParentBinding(WG_RegionEntity currRegion)
        {

            int level = 0;
            WG_RegionEntity ParentRegion = DataProvider.GetInstance().GetWG_RegionEntity(currRegion.ParentID);
            if (null == ParentRegion)
                level = 0;
            else
            {
                level = SetParentBinding(ParentRegion);
            }

            switch (level)
            {
                case 0:
                    {
                        //省，已经是全国范围了
                        SetDropdownListData(DropDownList_Province, 0, "全国");
                        DropDownList_Province.Items.FindByText(currRegion.Name).Selected = true;
                    }
                    break;
                case 1:
                    {
                        //市
                        SetDropdownListData(DropDownList_City, currRegion.ParentID, "全市");
                        DropDownList_City.Items.FindByText(currRegion.Name).Selected = true;
                    }
                    break;
                case 2:
                    {
                        //区
                        SetDropdownListData(DropDownList_District, currRegion.ParentID, "全区");
                        DropDownList_District.Items.FindByText(currRegion.Name).Selected = true;
                    }
                    break;
                case 3:
                    {
                        //镇
                        SetDropdownListData(DropDownList_Town, currRegion.ParentID, "全镇");
                        DropDownList_Town.Items.FindByText(currRegion.Name).Selected = true;
                    }
                    break;
                default:
                    break;
            }
            TextBox_Name.Text = currRegion.Name;
            TextBox_Meno.Text = currRegion.Meno;
            return level + 1; ;
        }
        #endregion

        #region 新增
        protected void WG_RegionAdd()
        {
            #region 判断是否可空


            var _ParentID = "0";
            if (!string.IsNullOrEmpty(DropDownList_Town.SelectedValue.Replace("0", "")))
            {
                //镇
                _ParentID = DropDownList_Town.SelectedValue;
            }
            else if (!string.IsNullOrEmpty(DropDownList_District.SelectedValue.Replace("0", "")))
            {
                //区
                _ParentID = DropDownList_District.SelectedValue;
            }
            else if (!string.IsNullOrEmpty(DropDownList_City.SelectedValue.Replace("0", "")))
            {
                //市
                _ParentID = DropDownList_City.SelectedValue;
            }
            else if (!string.IsNullOrEmpty(DropDownList_Province.SelectedValue.Replace("0", "")))
            {
                //省
                _ParentID = DropDownList_Province.SelectedValue;
            }
            else
            {
                //全国
                _ParentID = "0";
            }

            if (string.IsNullOrEmpty(_ParentID))
            {
                Alert("[ 父ID ]不能为空");
                return;
            }

            var _Name = Request.Form["TextBox_Name"];
            if (string.IsNullOrEmpty(_Name))
            {
                Alert("[ 区域名称 ]不能为空");
                return;
            }

            var _Meno = Request.Form["TextBox_Meno"];

            #endregion

            #region 获取数据

            WG_RegionEntity _WG_RegionEntity = new WG_RegionEntity();


            _WG_RegionEntity.ParentID = Convert.ToInt32(_ParentID.ToString());


            _WG_RegionEntity.Name = Convert.ToString(_Name.ToString());


            _WG_RegionEntity.Meno = Convert.ToString(_Meno.ToString());

            _WG_RegionEntity.CreateDate = DateTime.Now;

            _WG_RegionEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().AddWG_Region(_WG_RegionEntity);
            }
            catch
            {
                WriteLog("WG_RegionAdd", "添加WG_Region", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Region成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_RegionEditFunc(string ctrID)
        {
            #region 判断是否可空		 
            var _ParentID = "";// DropDownList_parentId.SelectedItem.Value;
            switch (CurrentEditLevel)
            {
                case 1:
                    {
                        _ParentID = "0";
                    }
                    break;
                case 2:
                    {

                        _ParentID = DropDownList_Province.SelectedValue;
                    }
                    break;
                case 3:
                    {

                        _ParentID = DropDownList_City.SelectedValue;
                    }
                    break;
                case 4:
                    {

                        _ParentID = DropDownList_District.SelectedValue;
                    }
                    break;
                case 5:
                    {

                        _ParentID = DropDownList_Town.SelectedValue;
                    }
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(_ParentID))
            {
                Alert("[ 父ID ]不能为空");
                return;
            }

            var _Name = Request.Form["TextBox_Name"];
            if (string.IsNullOrEmpty(_Name))
            {
                Alert("[ 区域名称 ]不能为空");
                return;
            }

            var _Meno = Request.Form["TextBox_Meno"];

            #endregion






            _WG_RegionEntity.ParentID = Convert.ToInt32(_ParentID.ToString());



            _WG_RegionEntity.Name = Convert.ToString(_Name.ToString());



            _WG_RegionEntity.Meno = Convert.ToString(_Meno.ToString());

            _WG_RegionEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().UpdateWG_Region(_WG_RegionEntity);
            }
            catch
            {
                WriteLog("WG_RegionEditFunc", "编辑WG_Region", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Region资料成功", "");
        }
        #endregion
    }
}