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
    public partial class Base_PrivilegeEdit : BaseForm
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
                Base_PrivilegeAdd();
            }
            else
            {
                Base_PrivilegeEditFunc(ctrID);
            }
        }

        #region 初始化表单
        Base_PrivilegeEntity _Base_PrivilegeEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _Base_PrivilegeEntity = DataProvider.GetInstance().GetBase_PrivilegeEntity(int.Parse(ctrID));

               				                				                   TextBox_UserID.Text = _Base_PrivilegeEntity.UserID.ToString();
                                				                   TextBox_ModuleID.Text = _Base_PrivilegeEntity.ModuleID.ToString();
                                				                   TextBox_ButtonID.Text = _Base_PrivilegeEntity.ButtonID.ToString();
                                				                   TextBox_CreaterID.Text = _Base_PrivilegeEntity.CreaterID.ToString();
                                				                   TextBox_UpdaterID.Text = _Base_PrivilegeEntity.UpdaterID.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void Base_PrivilegeAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _UserID = Request.Form["TextBox_UserID"];
                 if (string.IsNullOrEmpty(_UserID))
                   {
                        Alert("[ 用户ID ]不能为空");
                        return;
                  }
				                                           
                  var _ModuleID = Request.Form["TextBox_ModuleID"];
                 if (string.IsNullOrEmpty(_ModuleID))
                   {
                        Alert("[ 模块ID ]不能为空");
                        return;
                  }
				                                           
                  var _ButtonID = Request.Form["TextBox_ButtonID"];
                 if (string.IsNullOrEmpty(_ButtonID))
                   {
                        Alert("[ 操作ID ]不能为空");
                        return;
                  }
				                                           
                  var _CreaterID = Request.Form["TextBox_CreaterID"];
                 if (string.IsNullOrEmpty(_CreaterID))
                   {
                        Alert("[ 创建者ID ]不能为空");
                        return;
                  }
				                                           
                  var _UpdaterID = Request.Form["TextBox_UpdaterID"];
                 if (string.IsNullOrEmpty(_UpdaterID))
                   {
                        Alert("[ 更新者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            Base_PrivilegeEntity  _Base_PrivilegeEntity = new Base_PrivilegeEntity();
            
               		                               	  		                            
                 	                 	                     _Base_PrivilegeEntity.UserID =Convert.ToInt32(_UserID.ToString());
                	                        	  		                            
                 	                 	                     _Base_PrivilegeEntity.ModuleID =Convert.ToInt32(_ModuleID.ToString());
                	                        	  		                            
                 	                 	                     _Base_PrivilegeEntity.ButtonID =Convert.ToInt32(_ButtonID.ToString());
                	                        	  		                            
                 	                 	                     _Base_PrivilegeEntity.CreaterID =Convert.ToInt32(_CreaterID.ToString());
                	                        	  		                            
                 	                 	                     _Base_PrivilegeEntity.UpdaterID =Convert.ToInt32(_UpdaterID.ToString());
                	                        	  		        
		       	_Base_PrivilegeEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_Base_PrivilegeEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddBase_Privilege(_Base_PrivilegeEntity);
            }
            catch
            {
                WriteLog("Base_PrivilegeAdd", "添加Base_Privilege", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Base_Privilege成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void Base_PrivilegeEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _UserID = Request.Form["TextBox_UserID"];
                 if (string.IsNullOrEmpty(_UserID))
                   {
                        Alert("[ 用户ID ]不能为空");
                        return;
                  }
				                                           
                  var _ModuleID = Request.Form["TextBox_ModuleID"];
                 if (string.IsNullOrEmpty(_ModuleID))
                   {
                        Alert("[ 模块ID ]不能为空");
                        return;
                  }
				                                           
                  var _ButtonID = Request.Form["TextBox_ButtonID"];
                 if (string.IsNullOrEmpty(_ButtonID))
                   {
                        Alert("[ 操作ID ]不能为空");
                        return;
                  }
				                                           
                  var _CreaterID = Request.Form["TextBox_CreaterID"];
                 if (string.IsNullOrEmpty(_CreaterID))
                   {
                        Alert("[ 创建者ID ]不能为空");
                        return;
                  }
				                                           
                  var _UpdaterID = Request.Form["TextBox_UpdaterID"];
                 if (string.IsNullOrEmpty(_UpdaterID))
                   {
                        Alert("[ 更新者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                        _Base_PrivilegeEntity.UserID =Convert.ToInt32(_UserID.ToString());
                                					                         
                
                                                                        _Base_PrivilegeEntity.ModuleID =Convert.ToInt32(_ModuleID.ToString());
                                					                         
                
                                                                        _Base_PrivilegeEntity.ButtonID =Convert.ToInt32(_ButtonID.ToString());
                                					                         
                
                                                                        _Base_PrivilegeEntity.CreaterID =Convert.ToInt32(_CreaterID.ToString());
                                					                         
                
                                                                        _Base_PrivilegeEntity.UpdaterID =Convert.ToInt32(_UpdaterID.ToString());
                                					                       					        
		       	_Base_PrivilegeEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateBase_Privilege(_Base_PrivilegeEntity);
            }
            catch
            {
                WriteLog("Base_PrivilegeEditFunc", "编辑Base_Privilege", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Base_Privilege资料成功","");
        }
        #endregion
    }
}