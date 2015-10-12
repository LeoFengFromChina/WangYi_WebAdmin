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
    public partial class LogEdit : BaseForm
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
                LogAdd();
            }
            else
            {
                LogEditFunc(ctrID);
            }
        }

        #region 初始化表单
        LogEntity _LogEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _LogEntity = DataProvider.GetInstance().GetLogEntity(int.Parse(ctrID));

               				                				                   TextBox_ModuleName.Text = _LogEntity.ModuleName.ToString();
                                				                   TextBox_Operation.Text = _LogEntity.Operation.ToString();
                                				                   TextBox_LogContent.Text = _LogEntity.LogContent.ToString();
                                				                   TextBox_LogType.Text = _LogEntity.LogType.ToString();
                                				                   TextBox_FromUserID.Text = _LogEntity.FromUserID.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void LogAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _ModuleName = Request.Form["TextBox_ModuleName"];
                 if (string.IsNullOrEmpty(_ModuleName))
                   {
                        Alert("[ 模块名称(触发页面名称) ]不能为空");
                        return;
                  }
				                                           
                  var _Operation = Request.Form["TextBox_Operation"];
                 if (string.IsNullOrEmpty(_Operation))
                   {
                        Alert("[ 操作名称 ]不能为空");
                        return;
                  }
				                                           
                  var _LogContent = Request.Form["TextBox_LogContent"];
                 if (string.IsNullOrEmpty(_LogContent))
                   {
                        Alert("[ 日志正文 ]不能为空");
                        return;
                  }
				                                           
                  var _LogType = Request.Form["TextBox_LogType"];
                 if (string.IsNullOrEmpty(_LogType))
                   {
                        Alert("[ 日志类型 ]不能为空");
                        return;
                  }
				                                           
                  var _FromUserID = Request.Form["TextBox_FromUserID"];
                 if (string.IsNullOrEmpty(_FromUserID))
                   {
                        Alert("[ 用户ID ]不能为空");
                        return;
                  }
				                                                
	        #endregion
           
            #region 获取数据

            LogEntity  _LogEntity = new LogEntity();
            
               		                               	  		                            
                 	                 	                
                    _LogEntity.ModuleName =Convert.ToString(_ModuleName.ToString());
               		                        	  		                            
                 	                 	                
                    _LogEntity.Operation =Convert.ToString(_Operation.ToString());
               		                        	  		                            
                 	                 	                
                    _LogEntity.LogContent =Convert.ToString(_LogContent.ToString());
               		                        	  		                            
                 	                 	                     _LogEntity.LogType =Convert.ToInt32(_LogType.ToString());
                	                        	  		                            
                 	                 	                     _LogEntity.FromUserID =Convert.ToInt32(_FromUserID.ToString());
                	                        	  		        
		       	_LogEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddLog(_LogEntity);
            }
            catch
            {
                WriteLog("LogAdd", "添加Log", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Log成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void LogEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _ModuleName = Request.Form["TextBox_ModuleName"];
                 if (string.IsNullOrEmpty(_ModuleName))
                   {
                        Alert("[ 模块名称(触发页面名称) ]不能为空");
                        return;
                  }
				                                           
                  var _Operation = Request.Form["TextBox_Operation"];
                 if (string.IsNullOrEmpty(_Operation))
                   {
                        Alert("[ 操作名称 ]不能为空");
                        return;
                  }
				                                           
                  var _LogContent = Request.Form["TextBox_LogContent"];
                 if (string.IsNullOrEmpty(_LogContent))
                   {
                        Alert("[ 日志正文 ]不能为空");
                        return;
                  }
				                                           
                  var _LogType = Request.Form["TextBox_LogType"];
                 if (string.IsNullOrEmpty(_LogType))
                   {
                        Alert("[ 日志类型 ]不能为空");
                        return;
                  }
				                                           
                  var _FromUserID = Request.Form["TextBox_FromUserID"];
                 if (string.IsNullOrEmpty(_FromUserID))
                   {
                        Alert("[ 用户ID ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _LogEntity.ModuleName =Convert.ToString(_ModuleName.ToString());
                               					                         
                
                                                                   
                    _LogEntity.Operation =Convert.ToString(_Operation.ToString());
                               					                         
                
                                                                   
                    _LogEntity.LogContent =Convert.ToString(_LogContent.ToString());
                               					                         
                
                                                                        _LogEntity.LogType =Convert.ToInt32(_LogType.ToString());
                                					                         
                
                                                                        _LogEntity.FromUserID =Convert.ToInt32(_FromUserID.ToString());
                                					                       			            try
            {
                DataProvider.GetInstance().UpdateLog(_LogEntity);
            }
            catch
            {
                WriteLog("LogEditFunc", "编辑Log", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Log资料成功","");
        }
        #endregion
    }
}