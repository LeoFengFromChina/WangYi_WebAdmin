using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Common.DailyUtility;
namespace MideFrameWork.UI.WebSite
{
    public partial class ucQueryHelper : System.Web.UI.UserControl, IQuery
    {
        #region 事件

        /// <summary>
        /// 页面绑定委托
        /// </summary>
        public delegate void PageHandler(object sender, EventArgs e);
        /// <summary>
        /// 束发页面绑定事件
        /// </summary>
        public event PageHandler Search_Click;
        protected override void OnInit(EventArgs e)
        {
            RegisterScript();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlSort.SelectedIndex = 0;
                txtCalendarFrom.Attributes.Add("onclick", "MyCalendar.SetDate(this);");
                txtCalendarFrom.Attributes.Add("onkeypress", "return false;");
                txtCalendarFrom.Attributes.Add("onselectstart", "return false;");
                txtCalendarTo.Attributes.Add("onclick", "MyCalendar.SetDate(this);");
                txtCalendarTo.Attributes.Add("onkeypress", "return false;");
                txtCalendarTo.Attributes.Add("onselectstart", "return false;");

            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            WhereStr = GetQueryText();
            if (Search_Click != null)
            {
                Search_Click(this, EventArgs.Empty);
            }
        }

        #endregion

        #region 属性
        public ListItemCollection StatusItems
        {
            get
            {
                return dllStatus.Items;
            }
        }
        public ListItemCollection KeyWordItems
        {
            get
            {
                return ddlSort.Items;
            }
        }
        public string Keyword
        {
            get { return txtKeyWord.Text; }
            set { txtKeyWord.Text = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 注册JS
        /// </summary>
        public void RegisterScript()
        {
            string Script = "<script type='text/javascript'>"
        + "function change() {"
            + "var ddlSort = document.getElementById('myQueryHelper_ddlSort');"

           + " var txtKeyWord = document.getElementById('myQueryHelper_txtKeyWord');"
            + "var txtCalendar = document.getElementById('txtCalendar');"
            + "var txtCalendarFrom = document.getElementById('myQueryHelper_txtCalendarFrom');"
            + "var txtCalendarTo = document.getElementById('myQueryHelper_txtCalendarTo');"
            + "var dllStatus = document.getElementById('myQueryHelper_dllStatus');"
            + "var lblFrom = document.getElementById('myQueryHelper_lbl_From');"
            + "var lblTo = document.getElementById('myQueryHelper_lbl_To');"


            + "var ddlSort_text = ddlSort.options[ddlSort.selectedIndex].text;"
            + "var index_all = ddlSort_text.indexOf('全部');"
            + "var index_date = ddlSort_text.indexOf('日期');"
            + "var index_time = ddlSort_text.indexOf('时间');"
            + "var index_status = ddlSort_text.indexOf('状态');"
            + "if (index_all >= 0) {"
                + "txtKeyWord.style.display = 'inline';"
                + "txtKeyWord.value = '';"
                + "if (dllStatus != null)"
                   + " dllStatus.style.display = 'none';"
                + "if (txtCalendar != null)"
                    + "txtCalendar.style.display = 'none';"
               + " if (txtCalendarFrom != null)"
                    + "txtCalendarFrom.style.display = 'none';"
                + "if (txtCalendarTo != null)"
                    + "txtCalendarTo.style.display = 'none';"
                + "if (lblFrom != null)"
                   + " lblFrom.style.display = 'none';"
               + " if (lblTo != null)"
                    + "lblTo.style.display = 'none';"
            + "}"
           + " else if (index_date >= 0 || index_time >= 0) {"

                + "if (txtKeyWord != null)"
                    + "txtKeyWord.style.display = 'none';"

                + "if (txtCalendar != null)"
                   + "txtCalendar.style.display = 'inline';"
                + "if (txtCalendarFrom != null)"
                    + "txtCalendarFrom.style.display = 'inline';"
                + "if (txtCalendarTo != null)"
                    + "txtCalendarTo.style.display = 'inline';"
                + "if (lblFrom != null)"
                    + "lblFrom.style.display = 'inline';"
                + "if (lblTo != null)"
                    + "lblTo.style.display = 'inline';"

                + "if (dllStatus != null)"
                   + " dllStatus.style.display = 'none';"
           + " }"
            + "else if (index_status >= 0) {"
                + "txtKeyWord.style.display = 'none';"
                + "txtKeyWord.value = '';"
                + "if (dllStatus != null)"
                   + " dllStatus.style.display = 'inline';"
                + "if (txtCalendar != null)"
                    + "txtCalendar.style.display = 'none';"
                + "if (txtCalendarFrom != null)"
                   + " txtCalendarFrom.style.display = 'none';"
                + "if (txtCalendarTo != null)"
                   + " txtCalendarTo.style.display = 'none';"
              + "  if (lblFrom != null)"
                  + "  lblFrom.style.display = 'none';"
               + " if (lblTo != null)"
                    + "lblTo.style.display = 'none';"
           + " }"
            + "else {"

               + " txtKeyWord.style.display = 'inline';"
                //+ "txtKeyWord.value = '';"
                + "if (dllStatus != null)"
                  + "  dllStatus.style.display = 'none';"
                + "if (txtCalendar != null)"
                  + "  txtCalendar.style.display = 'none';"
               + " if (txtCalendarFrom != null)"
                   + " txtCalendarFrom.style.display = 'none';"
               + " if (txtCalendarTo != null)"
                   + " txtCalendarTo.style.display = 'none';"
                + "if (lblFrom != null)"
                    + "lblFrom.style.display = 'none';"
                + "if (lblTo != null)"
                    + "lblTo.style.display = 'none';"
           + " }"
        + "}"
+ "</script>";


            Page.ClientScript.RegisterStartupScript(this.GetType(), "QueryHelper", Script);
            //这句话很重要，先加载完控件在隐藏
            Page.ClientScript.RegisterStartupScript(this.GetType(), "change", "change();", true);
        }

        private string GetQueryText()
        {
            string where = " WHERE 1=1 ";
            if (txtKeyWord.Visible == true && ddlSort.SelectedItem.Text != "全部" && !string.IsNullOrEmpty(txtKeyWord.Text.Trim()))
            {
                where += "And " + ddlSort.SelectedValue + " like'%" + txtKeyWord.Text.Trim() + "%'";
            }
            if (dllStatus.Visible == true && (ddlSort.SelectedItem.Text.Contains("状态")))
            {
                where += "And " + ddlSort.SelectedValue + " =" + dllStatus.SelectedValue.Trim() + "";
            }
            if (txtCalendar.Visible == true && (ddlSort.SelectedItem.Text.Contains("时间")
                || ddlSort.SelectedItem.Text.Contains("日期"))
                && !string.IsNullOrEmpty(txtCalendarFrom.Text.Trim()) && !string.IsNullOrEmpty(txtCalendarTo.Text.Trim()))
            {
                where += "And " + ddlSort.SelectedValue + " Between '" + txtCalendarFrom.Text.Trim() + "' And '" + txtCalendarTo.Text.Trim() + "'";
            }
            return where;
        }

        #endregion

        #region IQuery 成员

        public string Columns
        {
            get
            {
                if (ViewState["Columns"] == null)
                    ViewState["Columns"] = "*";
                return ViewState["Columns"] as string;
            }
            set
            {
                ViewState["Columns"] = value;
            }
        }

        public string OrderColumn
        {
            get
            {
                if (ViewState["OrderColumn"] == null)
                    ViewState["OrderColumn"] = "ID";
                return ViewState["OrderColumn"] as string;
            }
            set
            {
                ViewState["OrderColumn"] = value;
            }
        }
        /// <summary>
        /// 排序类型
        /// </summary>
        public OrderType OrderType
        {
            get
            {
                if (ViewState["OrderType"] == null)
                    return OrderType.Asc;
                return (OrderType)ViewState["OrderType"];
            }
            set
            {
                ViewState["OrderType"] = value;
            }
        }
        /// <summary>
        /// 查询条件,存储到ViewState中.
        /// </summary>
        public string WhereStr
        {
            get
            {
                if (ViewState["WhereStr"] == null)
                    ViewState["WhereStr"] = GetQueryText();
                return ViewState["WhereStr"] as string;
            }
            set { ViewState["WhereStr"] = value; }
        }
        /// <summary>
        /// 排序字段(最好为有索引的字段)
        /// </summary>
        public string OrderBy
        {
            get
            {
                if (ViewState["OrderBy"] == null)
                    ViewState["OrderBy"] = "";
                return ViewState["OrderBy"] as string;
            }
            set
            {
                ViewState["OrderBy"] = value;
            }
        }

        #endregion
    }
}