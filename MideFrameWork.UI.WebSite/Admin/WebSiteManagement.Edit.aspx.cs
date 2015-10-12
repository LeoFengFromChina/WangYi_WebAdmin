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
    public partial class WebSiteManagementEdit : BaseForm
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
                WebSiteManagementAdd();
            }
            else
            {
                WebSiteManagementEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WebSiteManagementEntity _WebSiteManagementEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WebSiteManagementEntity = DataProvider.GetInstance().GetWebSiteManagementEntity(int.Parse(ctrID));

               				                				                   TextBox_WebSiteName.Text = _WebSiteManagementEntity.WebSiteName.ToString();
                                				                   TextBox_MetaKeywords.Text = _WebSiteManagementEntity.MetaKeywords.ToString();
                                				                   TextBox_MetaDescriptions.Text = _WebSiteManagementEntity.MetaDescriptions.ToString();
                                				                   TextBox_AdvPopupScript.Text = _WebSiteManagementEntity.AdvPopupScript.ToString();
                                				                   TextBox_OwnerID.Text = _WebSiteManagementEntity.OwnerID.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void WebSiteManagementAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _WebSiteName = Request.Form["TextBox_WebSiteName"];
                 if (string.IsNullOrEmpty(_WebSiteName))
                   {
                        Alert("[ 网站名称 ]不能为空");
                        return;
                  }
				                                           
                  var _MetaKeywords = Request.Form["TextBox_MetaKeywords"];
                 if (string.IsNullOrEmpty(_MetaKeywords))
                   {
                        Alert("[ Meta关键字 ]不能为空");
                        return;
                  }
				                                           
                  var _MetaDescriptions = Request.Form["TextBox_MetaDescriptions"];
                 if (string.IsNullOrEmpty(_MetaDescriptions))
                   {
                        Alert("[ Meta描述 ]不能为空");
                        return;
                  }
				                                           
                  var _AdvPopupScript = Request.Form["TextBox_AdvPopupScript"];
                 if (string.IsNullOrEmpty(_AdvPopupScript))
                   {
                        Alert("[ 广告脚本 ]不能为空");
                        return;
                  }
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 拥有者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            WebSiteManagementEntity  _WebSiteManagementEntity = new WebSiteManagementEntity();
            
               		                               	  		                            
                 	                 	                
                    _WebSiteManagementEntity.WebSiteName =Convert.ToString(_WebSiteName.ToString());
               		                        	  		                            
                 	                 	                
                    _WebSiteManagementEntity.MetaKeywords =Convert.ToString(_MetaKeywords.ToString());
               		                        	  		                            
                 	                 	                
                    _WebSiteManagementEntity.MetaDescriptions =Convert.ToString(_MetaDescriptions.ToString());
               		                        	  		                            
                 	                 	                
                    _WebSiteManagementEntity.AdvPopupScript =Convert.ToString(_AdvPopupScript.ToString());
               		                        	  		                            
                 	                 	                     _WebSiteManagementEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                	                        	  		        
		       	_WebSiteManagementEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_WebSiteManagementEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWebSiteManagement(_WebSiteManagementEntity);
            }
            catch
            {
                WriteLog("WebSiteManagementAdd", "添加WebSiteManagement", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WebSiteManagement成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WebSiteManagementEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _WebSiteName = Request.Form["TextBox_WebSiteName"];
                 if (string.IsNullOrEmpty(_WebSiteName))
                   {
                        Alert("[ 网站名称 ]不能为空");
                        return;
                  }
				                                           
                  var _MetaKeywords = Request.Form["TextBox_MetaKeywords"];
                 if (string.IsNullOrEmpty(_MetaKeywords))
                   {
                        Alert("[ Meta关键字 ]不能为空");
                        return;
                  }
				                                           
                  var _MetaDescriptions = Request.Form["TextBox_MetaDescriptions"];
                 if (string.IsNullOrEmpty(_MetaDescriptions))
                   {
                        Alert("[ Meta描述 ]不能为空");
                        return;
                  }
				                                           
                  var _AdvPopupScript = Request.Form["TextBox_AdvPopupScript"];
                 if (string.IsNullOrEmpty(_AdvPopupScript))
                   {
                        Alert("[ 广告脚本 ]不能为空");
                        return;
                  }
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 拥有者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _WebSiteManagementEntity.WebSiteName =Convert.ToString(_WebSiteName.ToString());
                               					                         
                
                                                                   
                    _WebSiteManagementEntity.MetaKeywords =Convert.ToString(_MetaKeywords.ToString());
                               					                         
                
                                                                   
                    _WebSiteManagementEntity.MetaDescriptions =Convert.ToString(_MetaDescriptions.ToString());
                               					                         
                
                                                                   
                    _WebSiteManagementEntity.AdvPopupScript =Convert.ToString(_AdvPopupScript.ToString());
                               					                         
                
                                                                        _WebSiteManagementEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                                					                       					        
		       	_WebSiteManagementEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateWebSiteManagement(_WebSiteManagementEntity);
            }
            catch
            {
                WriteLog("WebSiteManagementEditFunc", "编辑WebSiteManagement", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WebSiteManagement资料成功","");
        }
        #endregion
    }
}