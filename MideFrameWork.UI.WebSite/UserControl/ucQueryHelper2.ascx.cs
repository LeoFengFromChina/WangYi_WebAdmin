using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Common.DailyUtility;
namespace MideFrameWork.UI.WebSite
{
    public partial class ucQueryHelper2 : System.Web.UI.UserControl, IQuery
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
        protected void Page_Load(object sender, EventArgs e)
        {
            datetxt1.Attributes.Add("onclick", "MyCalendar.SetDate(this);");
            datetxt1.Attributes.Add("onkeypress", "return false;");
            datetxt1.Attributes.Add("onselectstart", "return false;");
            datetxt2.Attributes.Add("onclick", "MyCalendar.SetDate(this);");
            datetxt2.Attributes.Add("onkeypress", "return false;");
            datetxt2.Attributes.Add("onselectstart", "return false;");
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected string Search()
        {
            
            WhereStr = GetQueryText();
            if (Search_Click != null)
            {
                Search_Click(this, EventArgs.Empty);
            }
            return "";
        }

        #endregion


        #region 属性

        protected string FirstSelectText
        {
            get
            {
                if (ViewState["SelectText"] != null)
                    return ViewState["SelectText"].ToString();
                else return "全部";
            }
            set
            {
                ViewState["SelectText"] = value;
            }
        }
        protected string SecondSelectText
        {
            get
            {
                if (ViewState["SecondSelectText"] != null)
                    return ViewState["SecondSelectText"].ToString();
                else return "全部";
            }
            set
            {
                ViewState["SecondSelectText"] = value;
            }
        }

        public List<DropDownItem> FirstSelectDataSource
        {

            get { return (List<DropDownItem>)rpt_FirstSelect.DataSource; }
            set { rpt_FirstSelect.DataSource = value; rpt_FirstSelect.DataBind(); }
        }
        public List<DropDownItem> SecondSelectDataSource
        {

            get { return (List<DropDownItem>)rpt_SecondSelect.DataSource; }
            set { rpt_SecondSelect.DataSource = value; rpt_SecondSelect.DataBind(); }
        }
        #endregion

        #region 方法

        private string GetQueryText()
        {
            //-------------------第一个下拉框---------------------
            string where = " WHERE 1=1 ";
            string FirstSelectValue = string.Empty;
            string value_title = hid_FistSelect.Attributes["value"].Trim();
            if (!string.IsNullOrEmpty(value_title))
            {
                string[] FirstSelectItem = value_title.Split(';');
                if (FirstSelectItem.Length > 1)
                    FirstSelectText = FirstSelectItem[1]; ;
                FirstSelectValue = FirstSelectItem[0];
            }
            else
            {
                FirstSelectValue = "all";
            }

            //-------------------第二个下拉框---------------------
            string SecondSelectValue = string.Empty;
            string value_title_S = hid_SecondSelect.Attributes["value"].Trim();
            if (!string.IsNullOrEmpty(value_title_S))
            {
                string[] SecondSelectItem = value_title_S.Split(';');
                if (SecondSelectItem.Length > 1)
                    SecondSelectText = SecondSelectItem[1]; //设置第二个下拉框的当前选中标签
                SecondSelectValue = SecondSelectItem[0];
            }
            else
            {
                SecondSelectValue = "all";
            }

            string SecondTxtKeyWord = txtKeyWord.Value.Trim();
            string DateFrom = datetxt1.Value.Trim();
            string DateTo = datetxt2.Value.Trim();


            if (FirstSelectValue.Contains("all"))
            {
                //全部就直接1=1
                txtKeyWord.Value = "";
                datetxt1.Value = "";
                datetxt2.Value = "";
                SecondSelectText = "全部";
            }
            else if (FirstSelectValue.Contains("Date")
                || FirstSelectValue.Contains("Time"))
            {
                where += "And " + FirstSelectValue + " BETWEEN '" + DateFrom + "' AND '" + DateTo + "'";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "setStatus", "setDate();", true);
            }
            else if (FirstSelectValue.Contains("Status"))
            {
                if (!string.IsNullOrEmpty(SecondSelectValue) && SecondSelectValue != "all")
                    where += "And " + FirstSelectValue + " = " + SecondSelectValue;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "setStatus", "setStatus();", true);

            }
            else
            {
                where += "And " + FirstSelectValue + " Like '%" + SecondTxtKeyWord + "%'";
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


    public class DropDownItem
    {
        public DropDownItem()
        { }
        public DropDownItem(string text, string value, string type)
        {
            Text = text;
            Value = value;
            Type = type;
        }
        public string Type
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
        public string Value
        {
            get;
            set;
        }
    }
}