using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork.UI.WebSite.Admin
{
    public partial class DistrictList : BaseForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myPagination.Bind += new ucPagination.PageHandler(myPagination_Bind);
            myQueryHelper.Search_Click += new ucQueryHelper.PageHandler(myPagination_Bind);
            if (!IsPostBack)
            {
                myQueryHelper.KeyWordItems.Clear();
                myQueryHelper.KeyWordItems.Add(new ListItem("全部", "全部"));
                myQueryHelper.KeyWordItems.Add(new ListItem("父ID", "ParentID"));
                myQueryHelper.KeyWordItems.Add(new ListItem("地区名称", "DistrictName"));
                myQueryHelper.KeyWordItems.Add(new ListItem("状态", "Status"));
                myQueryHelper.StatusItems.Add(new ListItem("开启", "0"));
                myQueryHelper.StatusItems.Add(new ListItem("停用", "1"));
                myQueryHelper.OrderBy = " ParentID asc";
                myPagination_Bind(this, EventArgs.Empty);
            }
        }
        void myPagination_Bind(object sender, EventArgs e)
        {
            int totalRecords = 0;
            int totalPages = 0;
            myPagination.Query = myQueryHelper;
            IList<DistrictEntity> districtList = DataProvider.GetInstance().GetDistrictList(myPagination.PageSize,
                myPagination.CurrentPageIndex,
                myPagination.Query.WhereStr,
                myPagination.Query.OrderBy,
                out totalRecords,
                out totalPages);
            districtRepeat.DataSource = districtList;
            districtRepeat.DataBind();
            myPagination.TotalRecord = totalRecords;
            myPagination.TotalPage = totalPages;
        }
        void myToolBarButton_Add_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "box_create_item();", true);
        }

        protected void lbt_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = GetSelectedAsString(districtRepeat);
                if (ids.Length > 0)
                {
                    DataProvider.GetInstance().DeleteDistrictList(ids);
                    Alert("操作成功!");
                    myPagination.DataBind();
                }
                else
                {
                    Alert("未选定任何记录！");
                }
            }
            catch (Exception ex)
            {
                WriteLog("DistrictList", "btnDelete_Click", ex.ToString(), Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("无法删除！删除前请清空相关的操作权限！");
            }
        }

        protected void lbt_Refresh_Click(object sender, EventArgs e)
        {
            myPagination.DataBind();
        }
    }
}