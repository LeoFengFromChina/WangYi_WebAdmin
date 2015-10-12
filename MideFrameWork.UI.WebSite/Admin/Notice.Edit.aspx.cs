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
    public partial class NoticeEdit : BaseForm
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
                NoticeAdd();
            }
            else
            {
                NoticeEditFunc(ctrID);
            }
        }

        #region 初始化表单
        NoticeEntity _NoticeEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _NoticeEntity = DataProvider.GetInstance().GetNoticeEntity(int.Parse(ctrID));

               				                				                   TextBox_Title.Text = _NoticeEntity.Title.ToString();
                                				                   TextBox_NoticeContent.Text = _NoticeEntity.NoticeContent.ToString();
                                				                   TextBox_FromUserID.Text = _NoticeEntity.FromUserID.ToString();
                                				                   TextBox_ToUserID.Text = _NoticeEntity.ToUserID.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void NoticeAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 标题 ]不能为空");
                        return;
                  }
				                                           
                  var _NoticeContent = Request.Form["TextBox_NoticeContent"];
                 if (string.IsNullOrEmpty(_NoticeContent))
                   {
                        Alert("[ 通知正文 ]不能为空");
                        return;
                  }
				                                           
                  var _FromUserID = Request.Form["TextBox_FromUserID"];
                 if (string.IsNullOrEmpty(_FromUserID))
                   {
                        Alert("[ 发起人 ]不能为空");
                        return;
                  }
				                                           
                  var _ToUserID = Request.Form["TextBox_ToUserID"];
                 if (string.IsNullOrEmpty(_ToUserID))
                   {
                        Alert("[ 接收者ID ]不能为空");
                        return;
                  }
				                                                
	        #endregion
           
            #region 获取数据

            NoticeEntity  _NoticeEntity = new NoticeEntity();
            
               		                               	  		                            
                 	                 	                
                    _NoticeEntity.Title =Convert.ToString(_Title.ToString());
               		                        	  		                            
                 	                 	                
                    _NoticeEntity.NoticeContent =Convert.ToString(_NoticeContent.ToString());
               		                        	  		                            
                 	                 	                     _NoticeEntity.FromUserID =Convert.ToInt32(_FromUserID.ToString());
                	                        	  		                            
                 	                 	                
                    _NoticeEntity.ToUserID =Convert.ToString(_ToUserID.ToString());
               		                        	  		        
		       	_NoticeEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddNotice(_NoticeEntity);
            }
            catch
            {
                WriteLog("NoticeAdd", "添加Notice", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Notice成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void NoticeEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 标题 ]不能为空");
                        return;
                  }
				                                           
                  var _NoticeContent = Request.Form["TextBox_NoticeContent"];
                 if (string.IsNullOrEmpty(_NoticeContent))
                   {
                        Alert("[ 通知正文 ]不能为空");
                        return;
                  }
				                                           
                  var _FromUserID = Request.Form["TextBox_FromUserID"];
                 if (string.IsNullOrEmpty(_FromUserID))
                   {
                        Alert("[ 发起人 ]不能为空");
                        return;
                  }
				                                           
                  var _ToUserID = Request.Form["TextBox_ToUserID"];
                 if (string.IsNullOrEmpty(_ToUserID))
                   {
                        Alert("[ 接收者ID ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _NoticeEntity.Title =Convert.ToString(_Title.ToString());
                               					                         
                
                                                                   
                    _NoticeEntity.NoticeContent =Convert.ToString(_NoticeContent.ToString());
                               					                         
                
                                                                        _NoticeEntity.FromUserID =Convert.ToInt32(_FromUserID.ToString());
                                					                         
                
                                                                   
                    _NoticeEntity.ToUserID =Convert.ToString(_ToUserID.ToString());
                               					                       			            try
            {
                DataProvider.GetInstance().UpdateNotice(_NoticeEntity);
            }
            catch
            {
                WriteLog("NoticeEditFunc", "编辑Notice", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Notice资料成功","");
        }
        #endregion
    }
}