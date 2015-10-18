﻿
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
    public partial class WG_MenberList : BaseForm
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
                firstDataSource.Add(new DropDownItem("电话", "Phone", "content"));
                firstDataSource.Add(new DropDownItem("帐号", "Name", "content"));
                firstDataSource.Add(new DropDownItem("姓名", "NickName", "content"));
                firstDataSource.Add(new DropDownItem("日期", "CreateDate", "date"));
                firstDataSource.Add(new DropDownItem("状态", "Status", "status"));
                myQueryHelper.FirstSelectDataSource = firstDataSource;


                myQueryHelper.SecondSelectDataSource = null;
                List<DropDownItem> secondDataSource = new List<DropDownItem>();
                secondDataSource.Add(new DropDownItem("待审核", "1", "status"));
                secondDataSource.Add(new DropDownItem("正常", "0", "status"));
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
            IList<WG_MenberEntity> WG_MenberList = DataProvider.GetInstance().GetWG_MenberList(myPagination.PageSize,
                myPagination.CurrentPageIndex,
                myPagination.Query.WhereStr,
                myPagination.Query.OrderBy,
                out totalRecords,
                out totalPages);
            WG_MenberRepeat.DataSource = WG_MenberList;
            WG_MenberRepeat.DataBind();
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
                string ids = GetSelectedAsString(WG_MenberRepeat);
                if (ids.Length > 0)
                {
                    DataProvider.GetInstance().DeleteWG_MenberList(ids);
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
                WriteLog("WG_Menberlist", "lbt_Delete_Click", ex.ToString(), Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("无法删除！删除前请清空相关的操作权限！");
            }
        }

        protected void lbt_Refresh_Click(object sender, EventArgs e)
        {
            myPagination.DataBind();
        }
    }
}