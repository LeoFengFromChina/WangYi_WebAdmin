﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using System.Collections;

namespace MideFrameWork.UI.WebSite.Admin
{
    public partial class WG_Menber_Operation : BaseForm
    {
        private string ctrID
        {
            get
            {
                if (ViewState["ctrID"] != null)
                    return (string)ViewState["ctrID"];
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["ctrID"] = value;
            }
        }

        private int ModuleID
        {
            get
            {
                if (ViewState["ModuleID"] != null)
                    return (int)ViewState["ModuleID"];
                else
                {
                    return -1;
                }
            }
            set
            {
                ViewState["ModuleID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ctrID = Request.QueryString["ctrID"];
            ddl_Module.AutoPostBack = true;
            ddl_Module.SelectedIndexChanged += Ddl_Module_SelectedIndexChanged;

            if (!Page.IsPostBack)
            {
                //加载按钮
                IList<Base_ButtonEntity> beList = DataProvider.GetInstance().GetBase_ButtonList("1=1");

                if (beList != null && beList.Count > 0)
                {
                    Base_ButtonList.DataSource = beList;
                    Base_ButtonList.DataBind();
                }
                //加载模块
                IList<Base_ModuleEntity> me = DataProvider.GetInstance().GetBase_ModuleList("1=1");
                if (me != null && me.Count > 0)
                {
                    ddl_Module.DataSource = me;
                    ddl_Module.DataTextField = "Memo";
                    ddl_Module.DataValueField = "ID";
                    ddl_Module.DataBind();
                }
                ddl_Module.SelectedIndex = -1;
                init_form(ctrID);
            }

            //表单提交事件
            Button_submit.Click += new EventHandler(Button_submit_Click);


        }

        private void Ddl_Module_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_form(ctrID);
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            int[] idsArray = GetSelected(Base_ButtonList);


            string whereStr = " UserID=" + ctrID + " AND ModuleID=" + ModuleID;

            IList<Base_PrivilegeEntity> peList = DataProvider.GetInstance().GetBase_PrivilegeList(whereStr);

            List<int> idsAlreadyExist = new List<int>();

            if (peList != null && peList.Count > 0)
            {
                foreach (Base_PrivilegeEntity item in peList)
                {
                    idsAlreadyExist.Add(item.ID);
                }
            }



            bool isFind = false;
            List<int> todeleteIDS = new List<int>();
            List<int> tonewIDS = new List<int>();
            #region 要删除的
            for (int i = 0; i < idsAlreadyExist.Count; i++)
            {
                for (int j = 0; j < idsArray.Length; j++)
                {
                    if (idsAlreadyExist[i] == idsArray[j])
                    {
                        isFind = true;
                    }
                }
                if (!isFind)
                {
                    todeleteIDS.Add(idsAlreadyExist[i]);
                }
            }
            #endregion
            #region 要新增的
            for (int i = 0; i < idsArray.Length; i++)
            {
                for (int j = 0; j < idsAlreadyExist.Count; j++)
                {
                    if (idsArray[i] == idsAlreadyExist[j])
                    {
                        isFind = true;
                    }
                }
                if (!isFind)
                {
                    tonewIDS.Add(idsArray[i]);
                }
            }
            #endregion

            if (todeleteIDS.Count > 0)
            {
                foreach (int item in todeleteIDS)
                {
                    DataProvider.GetInstance().DeleteBase_Privilege(item);
                }
            }
            if (tonewIDS.Count > 0)
            {
                foreach (int item in tonewIDS)
                {
                    Base_PrivilegeEntity pe = new Base_PrivilegeEntity();
                    pe.ButtonID = item;
                    pe.ModuleID = ModuleID;
                    pe.UserID = int.Parse(ctrID);
                    pe.CreaterID = CurrentUser.ID;
                    pe.UpdaterID = CurrentUser.ID;
                    pe.CreateDate = DateTime.Now;
                    pe.UpdateDate = DateTime.Now;
                    DataProvider.GetInstance().AddBase_Privilege(pe);
                }
            }
            Alert("授权完成。");
        }

        #region 初始化表单

        protected void init_form(string ctrID)
        {
            UnCheckedAll(Base_ButtonList, "");
            string moduleIDstr = ddl_Module.SelectedValue;
            if (!string.IsNullOrEmpty(ctrID) && !string.IsNullOrEmpty(moduleIDstr))
            {
                ModuleID = int.Parse(moduleIDstr);
                string whereStr = " UserID=" + ctrID + " AND ModuleID=" + moduleIDstr;

                IList<Base_PrivilegeEntity> peList = DataProvider.GetInstance().GetBase_PrivilegeList(whereStr);
                string ids = string.Empty;
                if (peList != null && peList.Count > 0)
                {
                    foreach (Base_PrivilegeEntity item in peList)
                    {
                        ids += item.ButtonID + ",";
                    }
                }
                if (!string.IsNullOrEmpty(ids))
                {
                    CheckedAllIN(Base_ButtonList, ids);
                }
            }
        }
        #endregion
    }
}