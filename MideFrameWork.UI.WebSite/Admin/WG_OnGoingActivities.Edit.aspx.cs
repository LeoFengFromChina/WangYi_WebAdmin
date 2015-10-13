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
    public partial class WG_OnGoingActivitiesEdit : BaseForm
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
                WG_OnGoingActivitiesAdd();
            }
            else
            {
                WG_OnGoingActivitiesEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_OnGoingActivitiesEntity _WG_OnGoingActivitiesEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_OnGoingActivitiesEntity = DataProvider.GetInstance().GetWG_OnGoingActivitiesEntity(int.Parse(ctrID));

               				                				                   TextBox_ActivityID.Text = _WG_OnGoingActivitiesEntity.ActivityID.ToString();
                                				                   TextBox_MenberID.Text = _WG_OnGoingActivitiesEntity.MenberID.ToString();
                                				                   TextBox_Status.Text = _WG_OnGoingActivitiesEntity.Status.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void WG_OnGoingActivitiesAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _ActivityID = Request.Form["TextBox_ActivityID"];
                 if (string.IsNullOrEmpty(_ActivityID))
                   {
                        Alert("[ 活动ID ]不能为空");
                        return;
                  }
				                                           
                  var _MenberID = Request.Form["TextBox_MenberID"];
                 if (string.IsNullOrEmpty(_MenberID))
                   {
                        Alert("[ 用户ID ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 状态 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
           
            #region 获取数据

            WG_OnGoingActivitiesEntity  _WG_OnGoingActivitiesEntity = new WG_OnGoingActivitiesEntity();
            
               		                               	  		                            
                 	                 	                     _WG_OnGoingActivitiesEntity.ActivityID =Convert.ToInt32(_ActivityID.ToString());
                	                        	  		                            
                 	                 	                     _WG_OnGoingActivitiesEntity.MenberID =Convert.ToInt32(_MenberID.ToString());
                	                        	  		                            
                 	                 	                     _WG_OnGoingActivitiesEntity.Status =Convert.ToInt32(_Status.ToString());
                	                        	  		        
		       	_WG_OnGoingActivitiesEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_OnGoingActivities(_WG_OnGoingActivitiesEntity);
            }
            catch
            {
                WriteLog("WG_OnGoingActivitiesAdd", "添加WG_OnGoingActivities", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_OnGoingActivities成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_OnGoingActivitiesEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _ActivityID = Request.Form["TextBox_ActivityID"];
                 if (string.IsNullOrEmpty(_ActivityID))
                   {
                        Alert("[ 活动ID ]不能为空");
                        return;
                  }
				                                           
                  var _MenberID = Request.Form["TextBox_MenberID"];
                 if (string.IsNullOrEmpty(_MenberID))
                   {
                        Alert("[ 用户ID ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 状态 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                        _WG_OnGoingActivitiesEntity.ActivityID =Convert.ToInt32(_ActivityID.ToString());
                                					                         
                
                                                                        _WG_OnGoingActivitiesEntity.MenberID =Convert.ToInt32(_MenberID.ToString());
                                					                         
                
                                                                        _WG_OnGoingActivitiesEntity.Status =Convert.ToInt32(_Status.ToString());
                                					                       			            try
            {
                DataProvider.GetInstance().UpdateWG_OnGoingActivities(_WG_OnGoingActivitiesEntity);
            }
            catch
            {
                WriteLog("WG_OnGoingActivitiesEditFunc", "编辑WG_OnGoingActivities", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_OnGoingActivities资料成功","");
        }
        #endregion
    }
}