using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Common.DailyUtility;
namespace MideFrameWork.UI.WebSite
{
    public partial class ucPagination : System.Web.UI.UserControl
    {
        #region 控件属性

        /// <summary>
        /// 页面绑定委托
        /// </summary>
        public delegate void PageHandler(object sender, EventArgs e);
        /// <summary>
        /// 束发页面绑定事件
        /// </summary>
        public event PageHandler Bind;

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize
        {
            get
            {
                if (ViewState["PageSize"] == null)
                    ViewState["PageSize"] = ddl_PageSize.SelectedValue;
                return Convert.ToInt32(ViewState["PageSize"]);
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecord
        {
            get
            {
                if (ViewState["TotalRecord"] == null)
                    ViewState["TotalRecord"] = lbl_TotalRecord.Text.Trim();
                return Convert.ToInt32(ViewState["TotalRecord"]);
            }
            set
            {
                ViewState["TotalRecord"] = value;
                lbl_TotalRecord.Text = value.ToString();
            }
        }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                if (ViewState["CurrentPageIndex"] == null)
                    ViewState["CurrentPageIndex"] = lbl_CurrentPageIndex.Text.Trim();
                return Convert.ToInt32(ViewState["CurrentPageIndex"]);
            }
            set
            {
                ViewState["CurrentPageIndex"] = value;
                lbl_CurrentPageIndex.Text = value.ToString();
            }
        }
        /// <summary>
        /// 总页码
        /// </summary>
        public int TotalPage
        {
            get
            {
                if (ViewState["TotalPage"] == null)
                    ViewState["TotalPage"] = lbl_TotalPage.Text.Trim();
                return Convert.ToInt32(ViewState["TotalPage"]);
            }
            set
            {
                ViewState["TotalPage"] = value;
                lbl_TotalPage.Text = value.ToString();
                SetIcon();
            }
        }

        private IQuery query;
        public IQuery Query
        {
            get
            {
                if (query == null) return new QueryEntity();
                return query;
            }
            set
            {
                query = value;
            }
        }

        #endregion

        #region 控件事件

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ddl_PageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //页面尺寸变化
            CurrentPageIndex = 1;
            PageSize = Convert.ToInt32(ddl_PageSize.SelectedValue);
            Bind(this, EventArgs.Empty);

        }


        /// <summary>
        /// 首页、上页、下页、末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtn_FirstPage_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgBtn = sender as ImageButton;
            switch (imgBtn.ID)
            {
                case "imgbtn_FirstPage":
                    {
                        //首页
                        CurrentPageIndex = 1;
                    }
                    break;
                case "imgbtn_FrontPage":
                    {
                        //上页
                        if (CurrentPageIndex > 1)
                            CurrentPageIndex -= 1;
                    }
                    break;
                case "imgbtn_NextPage":
                    {
                        //下页
                        if (CurrentPageIndex < TotalPage)
                            CurrentPageIndex += 1;
                    }
                    break;
                case "imgbtn_FinalPage":
                    {
                        //末页
                        CurrentPageIndex = TotalPage;
                    }
                    break;
                default:
                    break;
            }
            #region 绑定数据
            Bind(this, EventArgs.Empty);
            SetIcon();
            #endregion
        }

        #endregion

        #region 方法

        /// <summary>
        /// 执行页面绑定
        /// </summary>
        public new void DataBind()
        {
            if (Bind != null)
            {
                Bind(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 图标重置
        /// </summary>
        private void SetIcon()
        {

            if (CurrentPageIndex > 1 && CurrentPageIndex < TotalPage)
            {

                //可以往后
                imgbtn_NextPage.ImageUrl = "~/images/Pagination/page-next.gif";
                imgbtn_FinalPage.ImageUrl = "~/images/Pagination/page-last.gif";


                //可以往前
                imgbtn_FirstPage.ImageUrl = "~/images/Pagination/page-first.gif";
                imgbtn_FrontPage.ImageUrl = "~/images/Pagination/page-prev.gif";
                imgbtn_FirstPage.Enabled = true;
                imgbtn_FrontPage.Enabled = true;
                imgbtn_NextPage.Enabled = true;
                imgbtn_FinalPage.Enabled = true;
            }
            else if (CurrentPageIndex <= 1 && TotalPage > 1)
            {
                //不能再往前
                imgbtn_FirstPage.ImageUrl = "~/images/Pagination/page-first-disabled.gif";
                imgbtn_FrontPage.ImageUrl = "~/images/Pagination/page-prev-disabled.gif";
                imgbtn_FirstPage.Enabled = false;
                imgbtn_FrontPage.Enabled = false;

                //可以往后
                imgbtn_NextPage.ImageUrl = "~/images/Pagination/page-next.gif";
                imgbtn_FinalPage.ImageUrl = "~/images/Pagination/page-last.gif";
                imgbtn_NextPage.Enabled = true;
                imgbtn_FinalPage.Enabled = true;
            }
            else if (CurrentPageIndex >= TotalPage && TotalPage > 1)
            {
                //不能往后
                imgbtn_NextPage.ImageUrl = "~/images/Pagination/page-next-disabled.gif";
                imgbtn_FinalPage.ImageUrl = "~/images/Pagination/page-last-disabled.gif";
                imgbtn_NextPage.Enabled = false;
                imgbtn_FinalPage.Enabled = false;

                //可以往前
                imgbtn_FirstPage.ImageUrl = "~/images/Pagination/page-first.gif";
                imgbtn_FrontPage.ImageUrl = "~/images/Pagination/page-prev.gif";
                imgbtn_FirstPage.Enabled = true;
                imgbtn_FrontPage.Enabled = true;
            }
            else if (CurrentPageIndex == TotalPage)
            {

                //不能再往前
                imgbtn_FirstPage.ImageUrl = "~/images/Pagination/page-first-disabled.gif";
                imgbtn_FrontPage.ImageUrl = "~/images/Pagination/page-prev-disabled.gif";
                imgbtn_FirstPage.Enabled = false;
                imgbtn_FrontPage.Enabled = false;

                //不能往后
                imgbtn_NextPage.ImageUrl = "~/images/Pagination/page-next-disabled.gif";
                imgbtn_FinalPage.ImageUrl = "~/images/Pagination/page-last-disabled.gif";
                imgbtn_NextPage.Enabled = false;
                imgbtn_FinalPage.Enabled = false;
            }
        }
        #endregion
    }
}