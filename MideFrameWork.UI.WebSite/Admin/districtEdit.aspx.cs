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
    public partial class DistrictEdit : BaseForm
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
            Button_submit.Click += new EventHandler(Button_submit_Click);
            if (!IsPostBack)
            {
                ctrID = Request.QueryString["ctrID"];
                init_form(ctrID);
            }
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                DistrictAddFunc();
            }
            else
            {
                DistrictEditFunc(ctrID);
            }
        }

        #region 初始化表单
        protected void init_form(string ctrID)
        {

            //初始化状态
            DropDownList_Status.Items.Add(new ListItem("正常", "0"));
            DropDownList_Status.Items.Add(new ListItem("停用", "1"));
            if (string.IsNullOrEmpty(ctrID))
            {
                //初始化父菜单
                IList<DistrictEntity> DistrictParentIdList = DataProvider.GetInstance().GetDistrictList(" ParentID=0 ");
                DropDownList_ParentID.DataSource = DistrictParentIdList.ToList();
                DropDownList_ParentID.DataTextField = "DistrictName";
                DropDownList_ParentID.DataValueField = "ID";
                DropDownList_ParentID.DataBind();
                DropDownList_ParentID.Items.Insert(0, new ListItem("全国", "0"));

            }
            else
            {

                //如果是编辑操作
                IList<DistrictEntity> DistrictExist = DataProvider.GetInstance().GetDistrictList(" ID=" + ctrID + "");
                if (DistrictExist.ToList().Count == 0)
                {
                    Alert("地区不存在，参数错误");
                    return;
                }
                var DistrictExistTable = DistrictExist.ToList()[0];
                DropDownList_Status.SelectedValue = DistrictExistTable.Status.ToString();
                TextBox_DistrictName.Text = DistrictExistTable.DistrictName;

                //初始化父菜单
                //判断当前区域是不是顶级域名，如果是，父区域为全国，不是，则显示所在省的子区域
                if (DistrictExistTable.ParentID == 0)
                {
                    //初始化父菜单
                    IList<DistrictEntity> DistrictParentIdList = DataProvider.GetInstance().GetDistrictList(" ParentID=0 ");
                    DropDownList_ParentID.DataSource = DistrictParentIdList.ToList();
                    DropDownList_ParentID.DataTextField = "DistrictName";
                    DropDownList_ParentID.DataValueField = "ID";
                    DropDownList_ParentID.DataBind();
                    DropDownList_ParentID.Items.Insert(0, new ListItem("全国", "0"));
                }
                else
                {
                    int count = 0;
                    int ProvinceID = GetProvinceID(Convert.ToInt32(ctrID), count);
                    IList<DistrictEntity> ProvinceSubId = DataProvider.GetInstance().GetDistrictList(" ParentID=" + ProvinceID);
                    DropDownList_ParentID.DataSource = ProvinceSubId.ToList();
                    DropDownList_ParentID.DataTextField = "DistrictName";
                    DropDownList_ParentID.DataValueField = "ID";
                    DropDownList_ParentID.DataBind();
                    DropDownList_ParentID.SelectedValue = DistrictExistTable.ParentID.ToString();
                }
            }
        }
        #endregion

        #region 添加地区
        protected void DistrictAddFunc()
        {
            int ParentId = Convert.ToInt32(Request.Form["DropDownList_ParentID"]);
            int status = Convert.ToInt32(Request.Form["DropDownList_Status"]);
            string DistrictName = Request.Form["TextBox_DistrictName"].Trim();
            if (string.IsNullOrEmpty(DistrictName))
            {
                Alert("地区名称不能为空");
                return;
            }
            //检查在该父菜单下是否存在相同的地区名称
            IList<DistrictEntity> DistrictExist = DataProvider.GetInstance().GetDistrictList(" DistrictName='" + DistrictName + "' and ParentID=" + ParentId);
            if (DistrictExist.ToList().Count > 0)
            {
                Alert("在该父菜单下存在相同的地区名称");
                return;
            }

            DistrictEntity District = new DistrictEntity();
            District.ParentID = ParentId;
            District.Status = status;
            District.DistrictName = DistrictName;
            try
            {
                DataProvider.GetInstance().AddDistrict(District);
            }
            catch
            {
                WriteLog("DistrictEdit", "DistrictAddFunc", "把地区名称加入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加地区时出错，请重试");
            }
            Alert("添加成功");
        }
        #endregion

        #region 编辑地区
        protected void DistrictEditFunc(string ctrID)
        {

            int ParentId = Convert.ToInt32(Request.Form["DropDownList_ParentID"]);
            int status = Convert.ToInt32(Request.Form["DropDownList_Status"]);
            string DistrictName = Request.Form["TextBox_DistrictName"].Trim();
            if (string.IsNullOrEmpty(DistrictName))
            {
                Alert("地区名称不能为空");
                return;
            }
            //检查在该父菜单下是否存在相同的地区名称
            IList<DistrictEntity> DistrictExist = DataProvider.GetInstance().GetDistrictList(" DistrictName='" + DistrictName + "' and ParentID=" + ParentId + " and ID<>" + ctrID);

            if (DistrictExist.ToList().Count > 0)
            {
                Alert("在该父菜单下存在相同的地区名称");
                return;
            }

            DistrictEntity District = new DistrictEntity();
            District.ID = Convert.ToInt32(ctrID);
            District.ParentID = ParentId;
            District.Status = status;
            District.DistrictName = DistrictName;
            try
            {
                DataProvider.GetInstance().UpdateDistrict(District);
            }
            catch
            {
                WriteLog("DistrictEditFunc", "编辑地区", "把地区名称更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
            }
            Alert("编辑成功", "?ctrID=" + ctrID);
        }
        #endregion

        #region 获取省级地区的ID
        protected int GetProvinceID(int DistrictID, int count)
        {
            IList<DistrictEntity> District = DataProvider.GetInstance().GetDistrictList(" ID=" + DistrictID);
            if (count >= 1)
                return District.ToList()[0].ParentID;
            else
            {
                count++;
                return GetProvinceID(District.ToList()[0].ParentID, count);
            }
        }
        #endregion
    }
}