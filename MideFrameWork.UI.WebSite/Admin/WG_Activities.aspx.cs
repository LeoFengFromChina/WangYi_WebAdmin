
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
    public partial class WG_ActivitiesList : BaseForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myQueryHelper.Search_Click += new ucQueryHelper2.PageHandler(myQueryHelper_Search_Click);
            myPagination.Bind += new ucPagination.PageHandler(myPagination_Bind);
            myPagination.Query = myQueryHelper;
            if (!IsPostBack)
            {
                myQueryHelper.FirstSelectDataSource = null;
                List<DropDownItem> firstDataSource = new List<DropDownItem>();
                firstDataSource.Add(new DropDownItem("全部", "all", "content"));
                firstDataSource.Add(new DropDownItem("内容", "MsgContent", "content"));
                firstDataSource.Add(new DropDownItem("日期", "CreateDate", "date"));
                firstDataSource.Add(new DropDownItem("状态", "Status", "status"));
                myQueryHelper.FirstSelectDataSource = firstDataSource;


                myQueryHelper.SecondSelectDataSource = null;
                List<DropDownItem> secondDataSource = new List<DropDownItem>();
                secondDataSource.Add(new DropDownItem("成功", "1", "status"));
                secondDataSource.Add(new DropDownItem("失败", "2", "status"));
                myQueryHelper.SecondSelectDataSource = secondDataSource;

                this.myQueryHelper.OrderBy = "CreateDate Desc";
                myPagination_Bind(this, EventArgs.Empty);
            }
        }
        void myQueryHelper_Search_Click(object sender, EventArgs e)
        {
            myPagination.CurrentPageIndex = 1;
            myPagination_Bind(sender, e);
        }
        void myPagination_Bind(object sender, EventArgs e)
        {
            int totalRecords = 0;
            int totalPages = 0;
            myPagination.Query = myQueryHelper;
            IList<WG_ActivitiesEntity> WG_ActivitiesList = DataProvider.GetInstance().GetWG_ActivitiesList(myPagination.PageSize,
                myPagination.CurrentPageIndex,
                myPagination.Query.WhereStr,
                myPagination.Query.OrderBy,
                out totalRecords,
                out totalPages);
            WG_ActivitiesRepeat.DataSource = WG_ActivitiesList;
            WG_ActivitiesRepeat.DataBind();
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
                string ids = GetSelectedAsString(WG_ActivitiesRepeat);
                if (ids.Length > 0)
                {
                    DataProvider.GetInstance().DeleteWG_ActivitiesList(ids);
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
                WriteLog("WG_Activitieslist", "lbt_Delete_Click", ex.ToString(), Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("无法删除！删除前请清空相关的操作权限！");
            }
        }

        protected void lbt_Refresh_Click(object sender, EventArgs e)
        {
            myPagination.DataBind();
        }
    }
}