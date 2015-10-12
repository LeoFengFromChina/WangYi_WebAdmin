using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork.UI.WebSite
{
    public partial class RegisterDetailList : BaseForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myPagination.Bind += new ucPagination.PageHandler(myPagination_Bind);
            myQueryHelper.Search_Click += new ucQueryHelper.PageHandler(myPagination_Bind);
            if (!IsPostBack)
            {
                myQueryHelper.KeyWordItems.Clear();
                myQueryHelper.KeyWordItems.Add(new ListItem("全部", "全部"));
                myQueryHelper.KeyWordItems.Add(new ListItem("用户ID", "UserID"));
                myQueryHelper.KeyWordItems.Add(new ListItem("IP", "IP"));
                myQueryHelper.KeyWordItems.Add(new ListItem("日期", "CreateDate"));
                myQueryHelper.OrderBy = "CreateDate asc";
                myPagination_Bind(this, EventArgs.Empty);
            }
        }

        void myPagination_Bind(object sender, EventArgs e)
        {
            int totalRecords = 0;
            int totalPages = 0;
            myPagination.Query = myQueryHelper;
            IList<RegisterDetailEntity> RegisterDetailList = DataProvider.GetInstance().GetRegisterDetailList(myPagination.PageSize,
                myPagination.CurrentPageIndex,
                myPagination.Query.WhereStr,
                myPagination.Query.OrderBy,
                out totalRecords,
                out totalPages);
            myRepeat.DataSource = RegisterDetailList;
            myRepeat.DataBind();
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
                string ids = GetSelectedAsString(myRepeat);
                if (ids.Length > 0)
                {
                    DataProvider.GetInstance().DeleteRegisterDetailList(ids);
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
                WriteLog("RegisterDetailList", "lbt_Delete_Click", ex.ToString(), Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("无法删除！删除前请清空相关的操作权限！");
            }
        }

        protected void lbt_Refresh_Click(object sender, EventArgs e)
        {
            myPagination.DataBind();
        }
    }
}