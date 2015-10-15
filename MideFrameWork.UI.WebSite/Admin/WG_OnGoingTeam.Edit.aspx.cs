using System;
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
    public partial class WG_OnGoingTeamEdit : BaseForm
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
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrID = Request.QueryString["ctrID"];

            //初始化日期选择事件
                                
                                            
                                            
                                            
                                    
            //表单提交事件
            Button_submit.Click += new EventHandler(Button_submit_Click);

            init_form(ctrID);
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                WG_OnGoingTeamAdd();
            }
            else
            {
                WG_OnGoingTeamEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_OnGoingTeamEntity _WG_OnGoingTeamEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_OnGoingTeamEntity = DataProvider.GetInstance().GetWG_OnGoingTeamEntity(int.Parse(ctrID));

               				                				                   TextBox_TeamID.Text = _WG_OnGoingTeamEntity.TeamID.ToString();
                                				                   TextBox_MenberID.Text = _WG_OnGoingTeamEntity.MenberID.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void WG_OnGoingTeamAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _TeamID = Request.Form["TextBox_TeamID"];
                 if (string.IsNullOrEmpty(_TeamID))
                   {
                        Alert("[ 团队ID ]不能为空");
                        return;
                  }
				                                           
                  var _MenberID = Request.Form["TextBox_MenberID"];
                 if (string.IsNullOrEmpty(_MenberID))
                   {
                        Alert("[ 用户ID ]不能为空");
                        return;
                  }
				                                                
	        #endregion
           
            #region 获取数据

            WG_OnGoingTeamEntity  _WG_OnGoingTeamEntity = new WG_OnGoingTeamEntity();
            
               		                               	  		                            
                 	                 	                     _WG_OnGoingTeamEntity.TeamID =Convert.ToInt32(_TeamID.ToString());
                	                        	  		                            
                 	                 	                     _WG_OnGoingTeamEntity.MenberID =Convert.ToInt32(_MenberID.ToString());
                	                        	  		        
		       	_WG_OnGoingTeamEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_OnGoingTeam(_WG_OnGoingTeamEntity);
            }
            catch
            {
                WriteLog("WG_OnGoingTeamAdd", "添加WG_OnGoingTeam", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_OnGoingTeam成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_OnGoingTeamEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _TeamID = Request.Form["TextBox_TeamID"];
                 if (string.IsNullOrEmpty(_TeamID))
                   {
                        Alert("[ 团队ID ]不能为空");
                        return;
                  }
				                                           
                  var _MenberID = Request.Form["TextBox_MenberID"];
                 if (string.IsNullOrEmpty(_MenberID))
                   {
                        Alert("[ 用户ID ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                        _WG_OnGoingTeamEntity.TeamID =Convert.ToInt32(_TeamID.ToString());
                                					                         
                
                                                                        _WG_OnGoingTeamEntity.MenberID =Convert.ToInt32(_MenberID.ToString());
                                					                       			            try
            {
                DataProvider.GetInstance().UpdateWG_OnGoingTeam(_WG_OnGoingTeamEntity);
            }
            catch
            {
                WriteLog("WG_OnGoingTeamEditFunc", "编辑WG_OnGoingTeam", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_OnGoingTeam资料成功","");
        }
        #endregion
    }
}