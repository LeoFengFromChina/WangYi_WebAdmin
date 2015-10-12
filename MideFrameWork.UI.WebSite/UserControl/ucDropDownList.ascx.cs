using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MideFrameWork.UI.WebSite
{
    public partial class ucDropDownList : System.Web.UI.UserControl
    {


        #region 属性
        public string SelectedValue
        {
            get
            {
                if (ViewState["Value"] != null)
                    return ViewState["Value"] as string;
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["Value"] = value;
            }
        }
        public string SelectedText
        {
            get
            {
                if (ViewState["Text"] != null)
                    return ViewState["Text"] as string;
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        public double Width
        {
            get
            {
                if (ViewState["Width"] != null)
                    return double.Parse(ViewState["Width"].ToString());
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["Width"] = value;
            }
        }

        public List<ucDropDownListItem> DataSource
        {
            get { return (List<ucDropDownListItem>)rpt_DropDownList.DataSource; }
            set { rpt_DropDownList.DataSource = value; rpt_DropDownList.DataBind(); }
        }



        #endregion

        #region 事件
        /// <summary>
        /// 页面绑定委托
        /// </summary>
        public delegate void PageHandler(object sender, EventArgs e);
        /// <summary>
        /// 束发页面绑定事件
        /// </summary>
        public event PageHandler SelectIndexChanged;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownListItem_Click(object sender, EventArgs e)
        {
            //设置当前选中的内容

            if (SelectIndexChanged != null)
            {
                SelectIndexChanged(this, EventArgs.Empty);
            }
        }
    }

    public class ucDropDownListItem
    {
        public ucDropDownListItem()
        { }
        public ucDropDownListItem(string itemText, string itemValue)
        {
            ItemText = itemText;
            ItemValue = itemValue;
        }
        public string ItemText
        {
            get;
            set;
        }
        public string ItemValue
        {
            get;
            set;
        }
    }
}