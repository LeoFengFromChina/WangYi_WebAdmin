using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MideFrameWork.UI.WebSite
{
    public partial class ucToolBarButton : System.Web.UI.UserControl
    {

        #region 事件定义
        /// <summary>
        /// 页面绑定委托
        /// </summary>
        public delegate void PageHandler(object sender, EventArgs e);
        /// <summary>
        /// 新增事件
        /// </summary>
        public event PageHandler Add_Click;
        /// <summary>
        /// 删除事件
        /// </summary>
        public event PageHandler Delete_Click;
        /// <summary>
        /// 刷新事件
        /// </summary>
        public event PageHandler Refresh_Click;
        /// <summary>
        /// 修改事件
        /// </summary>
        public event PageHandler Update_Click;
        /// <summary>
        /// 导入时间
        /// </summary>
        public event PageHandler Import_Click;
        /// <summary>
        /// 导出事件
        /// </summary>
        public event PageHandler Export_Click;
        /// <summary>
        /// 返回事件
        /// </summary>
        public event PageHandler GoBack_Click;
        /// <summary>
        /// 扩展一事件
        /// </summary>
        public event PageHandler Ex1_Click;
        /// <summary>
        /// 扩展二事件
        /// </summary>
        public event PageHandler Ex2_Click;


        #endregion

        #region 事件

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtn_Add_Click(object sender, ImageClickEventArgs e)
        {
            switch (((ImageButton)sender).ID)
            {
                case "imgbtn_Add":
                    {
                        if (Add_Click != null)
                        {
                            Add_Click(this, EventArgs.Empty);
                        }
                    } break;
                case "imgbtn_Delete":
                    {
                        if (Delete_Click != null)
                        {
                            Delete_Click(this, EventArgs.Empty);
                        }
                    } break;
                case "imgbtn_Refresh":
                    {
                        if (Refresh_Click != null)
                        {
                            Refresh_Click(this, EventArgs.Empty);
                        }
                    } break;
                case "imgbtn_Update":
                    {
                        if (Update_Click != null)
                        {
                            Update_Click(this, EventArgs.Empty);
                        }
                    } break;
                case "imgbtn_Import":
                    {
                        if (Import_Click != null)
                        {
                            Import_Click(this, EventArgs.Empty);
                        }
                    } break;
                case "imgbtn_Export":
                    {
                        if (Export_Click != null)
                        {
                            Export_Click(this, EventArgs.Empty);
                        }
                    } break;
                case "imgbtn_GoBack":
                    {
                        if (GoBack_Click != null)
                        {
                            GoBack_Click(this, EventArgs.Empty);
                        }
                    } break;
                case "imgbtn_Ex1":
                    {
                        if (Ex1_Click != null)
                        {
                            Ex1_Click(this, EventArgs.Empty);
                        }
                    } break;
                case "imgbtn_Ex2":
                    {
                        if (Ex2_Click != null)
                        {
                            Ex2_Click(this, EventArgs.Empty);
                        }
                    } break;
                default:
                    break;
            }
        }
        #endregion

        #region 属性

        public bool AddVisable
        {
            get { return imgbtn_Add.Visible; }
            set { imgbtn_Add.Visible = value; }
        }
        public bool DeleteVisable
        {
            get { return imgbtn_Delete.Visible; }
            set { imgbtn_Delete.Visible = value; }
        }
        public bool RefreshVisable
        {
            get { return imgbtn_Refresh.Visible; }
            set { imgbtn_Refresh.Visible = value; }
        }
        public bool UpdateVisable
        {
            get { return imgbtn_Update.Visible; }
            set { imgbtn_Update.Visible = value; }
        }
        public bool ImportVisable
        {
            get { return imgbtn_Import.Visible; }
            set { imgbtn_Import.Visible = value; }
        }
        public bool ExportVisable
        {
            get { return imgbtn_Export.Visible; }
            set { imgbtn_Export.Visible = value; }
        }
        public bool GoBackVisable
        {
            get { return imgbtn_GoBack.Visible; }
            set { imgbtn_GoBack.Visible = value; }
        }
        public bool Ex1Visable
        {
            get { return imgbtn_Ex1.Visible; }
            set { imgbtn_Ex1.Visible = value; }
        }
        public bool Ex2Visable
        {
            get { return imgbtn_Ex2.Visible; }
            set { imgbtn_Ex2.Visible = value; }
        }

        #endregion
    }
}