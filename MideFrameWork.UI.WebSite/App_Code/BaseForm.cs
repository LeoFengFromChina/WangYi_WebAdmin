using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DailyUtility;
using MideFrameWork.Authorization;
using System.Web.UI.WebControls;
using System.Collections;
namespace MideFrameWork.UI.WebSite
{
    public abstract class BaseForm : System.Web.UI.Page
    {
        public BaseForm() { }
        string indexUrl = ConfigurationManager.AppSettings["indexUrl"];
        #region 用户
        protected UsersEntity CurrentUser
        {
            get;
            set;
        }
        protected Authorization.Authorization CurrentAuthor
        {
            get;
            set;
        }
        #endregion
        #region 写日志
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <param name="operate">函数名称</param>
        /// <param name="logcontent">日志正文</param>
        /// <param name="logtype">日志类型</param>
        protected void WriteLog(string module, string operate, string logcontent, MideSmsType.LogType logtype)
        {
            LogEntity log = new LogEntity();
            log.ModuleName = module;
            log.Operation = operate;
            log.LogContent = logcontent;
            log.FromUserID = CurrentUser.ID;
            log.LogType = (int)logtype;
            log.CreateDate = DateTime.Now;

            try
            {
                DataProvider.GetInstance().AddLog(log);
            }
            catch
            {
            }
        }
        #endregion

        #region 权限
        /// <summary>
        /// 权限过期得重新登录
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (System.Web.HttpContext.Current != null && !this.DesignMode)
            {

                CurrentAuthor = Session["cacheKey"] as Authorization.Authorization;
                if (CurrentAuthor == null
                    || CurrentAuthor.GetAuthorizeMenus() == null
                    || CurrentAuthor.GetAuthorizeMenus().Count <= 0
                    || CurrentAuthor.GetAuthorizeUsers() == null)
                {
                    string ParentURL = indexUrl;
                    //string ParentURL = Request.ApplicationPath + indexUrl;
                    System.Web.HttpContext.Current.Response.Write("<script language='javascript'>if(parent.AlertAndgoBack!=null ) { parent.AlertAndgoBack('" + ParentURL + "') ;} else {alert('您当前没有权限浏览本页面，请重新登录！'); window.location.href='" + ParentURL + "';};</script>");
                    Response.End();
                }

                CurrentUser = CurrentAuthor.GetAuthorizeUsers();
            }

        }
        #endregion

        #region 退出
        protected void Logout()
        {
            CurrentAuthor.Logout();
            CurrentAuthor = null;
            Session.RemoveAll();
            Session.Abandon();
            string ParentURL = indexUrl;
            //string ParentURL = Request.ApplicationPath + indexUrl;
            Response.Redirect(ParentURL);
        }
        #endregion

        #region 获取ID
        protected int[] GetSelected(Repeater rpt)
        {
            CheckBox cb = new CheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            ArrayList al = new ArrayList();

            for (int i = 0; i < count; i++)
            {
                cb = (CheckBox)rpt.Items[i].FindControl("chkItem");
                if (cb.Checked)
                {
                    hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                    al.Add(int.Parse(hdf.Value));
                }
            }
            return (int[])al.ToArray(Type.GetType("System.Int32"));
        }
        protected void CheckedAll(Repeater rpt, string notinIDS)
        {
            CheckBox cb = new CheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            ArrayList al = new ArrayList();

            for (int i = 0; i < count; i++)
            {
                hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                cb = (CheckBox)rpt.Items[i].FindControl("chkItem");
                if (!notinIDS.Contains(hdf.Value + ","))
                {
                    cb.Checked = true;
                }
            }
        }

        protected void CheckedAllIN(Repeater rpt, string notinIDS)
        {
            CheckBox cb = new CheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            ArrayList al = new ArrayList();

            for (int i = 0; i < count; i++)
            {
                hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                cb = (CheckBox)rpt.Items[i].FindControl("chkItem");
                if (notinIDS.Contains(hdf.Value + ","))
                {
                    cb.Checked = true;
                }
            }
        }

        protected void HtmlCheckedAll(Repeater rpt, List<string> notinIDS)
        {

            System.Web.UI.HtmlControls.HtmlInputCheckBox cb = new System.Web.UI.HtmlControls.HtmlInputCheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            ArrayList al = new ArrayList();

            for (int i = 0; i < count; i++)
            {
                hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                cb = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rpt.Items[i].FindControl("chkItem");
                if (!notinIDS.Contains(hdf.Value))
                {
                    cb.Checked = true;
                }
            }
        }
        protected void HtmlCheckedIn(Repeater rpt, List<string> inIDS)
        {

            System.Web.UI.HtmlControls.HtmlInputCheckBox cb = new System.Web.UI.HtmlControls.HtmlInputCheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            ArrayList al = new ArrayList();

            for (int i = 0; i < count; i++)
            {
                hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                cb = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rpt.Items[i].FindControl("chkItem");
                if (inIDS.Contains(hdf.Value))
                {
                    cb.Checked = true;
                }
            }
        }

        protected void UnCheckedAll(Repeater rpt, string notinIDS)
        {
            CheckBox cb = new CheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            ArrayList al = new ArrayList();

            for (int i = 0; i < count; i++)
            {
                hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                cb = (CheckBox)rpt.Items[i].FindControl("chkItem");
                if (!notinIDS.Contains(hdf.Value + ","))
                {
                    cb.Checked = false;
                }
            }
        }
        /// <summary>
        /// 获取ID集合如（1,2,3,4...）
        /// </summary>
        /// <param name="rpt"></param>
        /// <returns></returns>
        protected string GetSelectedAsString(Repeater rpt)
        {
            CheckBox cb = new CheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            string ids = "";
            for (int i = 0; i < count; i++)
            {
                cb = (CheckBox)rpt.Items[i].FindControl("chkItem");
                if (cb != null && cb.Checked)
                {
                    hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                    ids += hdf.Value + ",";
                }
            }
            if (string.IsNullOrEmpty(ids))
                ids = "-9999";
            return ids.Substring(0, ids.Length - 1);
        }
        protected List<string> Get_HtmlCheckBoxSelectedID_AsString(Repeater rpt)
        {
            System.Web.UI.HtmlControls.HtmlInputCheckBox cb = new System.Web.UI.HtmlControls.HtmlInputCheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            List<string> ids = new List<string>();
            for (int i = 0; i < count; i++)
            {
                cb = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rpt.Items[i].FindControl("chkItem");
                if (cb != null && cb.Checked)
                {
                    hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                    ids.Add(hdf.Value);
                }
            }
            return ids;
        }
        protected List<string> Get_HtmlUnCheckBoxSelectedID_AsString(Repeater rpt)
        {
            System.Web.UI.HtmlControls.HtmlInputCheckBox cb = new System.Web.UI.HtmlControls.HtmlInputCheckBox();
            HiddenField hdf = new HiddenField();
            int count = rpt.Items.Count;
            List<string> ids = new List<string>();
            for (int i = 0; i < count; i++)
            {
                cb = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rpt.Items[i].FindControl("chkItem");
                if (cb != null && !cb.Checked)
                {
                    hdf = (HiddenField)rpt.Items[i].FindControl("hdfID");
                    ids.Add(hdf.Value);
                }
            }
            return ids;
        }
        #endregion

        #region 弹框

        protected string ConvertAlertMessage(string msg)
        {
            string data = msg.ToString();

            if (0 == msg.Length)
            {
                data = "";
            }
            else
            {
                data = data.Replace("\r", "");
                data = data.Replace("\t", "");
                data = data.Replace("\n", "");
            }
            return data;
        }
        /// <summary>
        /// 显示警告框
        /// </summary>
        /// <param name="msg">警告信息</param>
        protected void Alert(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + msg, "alert(\"" + ConvertAlertMessage(msg) + "\");", true);
        }

        /// <summary>
        /// 显示警告框，并重定向到另外一个页面
        /// </summary>
        /// <param name="msg">警告信息</param>
        /// <param name="url">重定向页面</param>
        protected void Alert(string msg, string url)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + msg, "alert(\"" + ConvertAlertMessage(msg) + "\");window.location.href='" + url + "'", true);
        }
        
        #endregion
        
    }
}