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
    public partial class GlobalMenuEdit : BaseForm
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
                GlobalMenuAdd();
            }
            else
            {
                GlobalMenuEditFunc(ctrID);
            }
        }

        #region 初始化表单
        GlobalMenuEntity _GlobalMenuEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _GlobalMenuEntity = DataProvider.GetInstance().GetGlobalMenuEntity(int.Parse(ctrID));

               				                				                   TextBox_MenuTextCN.Text = _GlobalMenuEntity.MenuTextCN.ToString();
                                				                   TextBox_MenuTextEN.Text = _GlobalMenuEntity.MenuTextEN.ToString();
                                				                   TextBox_IconUrl.Text = _GlobalMenuEntity.IconUrl.ToString();
                                				                   TextBox_LinkUrl.Text = _GlobalMenuEntity.LinkUrl.ToString();
                                				                   TextBox_IsEnable.Text = _GlobalMenuEntity.IsEnable.ToString();
                                				                   TextBox_DisplayIndex.Text = _GlobalMenuEntity.DisplayIndex.ToString();
                                				                   TextBox_ParentID.Text = _GlobalMenuEntity.ParentID.ToString();
                                				                   TextBox_OwnerID.Text = _GlobalMenuEntity.OwnerID.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void GlobalMenuAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _MenuTextCN = Request.Form["TextBox_MenuTextCN"];
                 if (string.IsNullOrEmpty(_MenuTextCN))
                   {
                        Alert("[ 中文菜单 ]不能为空");
                        return;
                  }
				                                           
                  var _MenuTextEN = Request.Form["TextBox_MenuTextEN"];
                 if (string.IsNullOrEmpty(_MenuTextEN))
                   {
                        Alert("[ 英文菜单 ]不能为空");
                        return;
                  }
				                                           
                  var _IconUrl = Request.Form["TextBox_IconUrl"];
                 if (string.IsNullOrEmpty(_IconUrl))
                   {
                        Alert("[ 图标路径 ]不能为空");
                        return;
                  }
				                                           
                  var _LinkUrl = Request.Form["TextBox_LinkUrl"];
                 if (string.IsNullOrEmpty(_LinkUrl))
                   {
                        Alert("[ 连接地址 ]不能为空");
                        return;
                  }
				                                           
                  var _IsEnable = Request.Form["TextBox_IsEnable"];
                 if (string.IsNullOrEmpty(_IsEnable))
                   {
                        Alert("[ 是否启用 ]不能为空");
                        return;
                  }
				                                           
                  var _DisplayIndex = Request.Form["TextBox_DisplayIndex"];
                 if (string.IsNullOrEmpty(_DisplayIndex))
                   {
                        Alert("[ 显示顺序 ]不能为空");
                        return;
                  }
				                                           
                  var _ParentID = Request.Form["TextBox_ParentID"];
                 if (string.IsNullOrEmpty(_ParentID))
                   {
                        Alert("[ 父ID ]不能为空");
                        return;
                  }
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 所属者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            GlobalMenuEntity  _GlobalMenuEntity = new GlobalMenuEntity();
            
               		                               	  		                            
                 	                 	                
                    _GlobalMenuEntity.MenuTextCN =Convert.ToString(_MenuTextCN.ToString());
               		                        	  		                            
                 	                 	                
                    _GlobalMenuEntity.MenuTextEN =Convert.ToString(_MenuTextEN.ToString());
               		                        	  		                            
                 	                 	                
                    _GlobalMenuEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
               		                        	  		                            
                 	                 	                
                    _GlobalMenuEntity.LinkUrl =Convert.ToString(_LinkUrl.ToString());
               		                        	  		                            
                 	                 	                     _GlobalMenuEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                	                        	  		                            
                 	                 	                     _GlobalMenuEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                	                        	  		                            
                 	                 	                     _GlobalMenuEntity.ParentID =Convert.ToInt32(_ParentID.ToString());
                	                        	  		                            
                 	                 	                     _GlobalMenuEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                	                        	  		        
		       	_GlobalMenuEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_GlobalMenuEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddGlobalMenu(_GlobalMenuEntity);
            }
            catch
            {
                WriteLog("GlobalMenuAdd", "添加GlobalMenu", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加GlobalMenu成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void GlobalMenuEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _MenuTextCN = Request.Form["TextBox_MenuTextCN"];
                 if (string.IsNullOrEmpty(_MenuTextCN))
                   {
                        Alert("[ 中文菜单 ]不能为空");
                        return;
                  }
				                                           
                  var _MenuTextEN = Request.Form["TextBox_MenuTextEN"];
                 if (string.IsNullOrEmpty(_MenuTextEN))
                   {
                        Alert("[ 英文菜单 ]不能为空");
                        return;
                  }
				                                           
                  var _IconUrl = Request.Form["TextBox_IconUrl"];
                 if (string.IsNullOrEmpty(_IconUrl))
                   {
                        Alert("[ 图标路径 ]不能为空");
                        return;
                  }
				                                           
                  var _LinkUrl = Request.Form["TextBox_LinkUrl"];
                 if (string.IsNullOrEmpty(_LinkUrl))
                   {
                        Alert("[ 连接地址 ]不能为空");
                        return;
                  }
				                                           
                  var _IsEnable = Request.Form["TextBox_IsEnable"];
                 if (string.IsNullOrEmpty(_IsEnable))
                   {
                        Alert("[ 是否启用 ]不能为空");
                        return;
                  }
				                                           
                  var _DisplayIndex = Request.Form["TextBox_DisplayIndex"];
                 if (string.IsNullOrEmpty(_DisplayIndex))
                   {
                        Alert("[ 显示顺序 ]不能为空");
                        return;
                  }
				                                           
                  var _ParentID = Request.Form["TextBox_ParentID"];
                 if (string.IsNullOrEmpty(_ParentID))
                   {
                        Alert("[ 父ID ]不能为空");
                        return;
                  }
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 所属者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _GlobalMenuEntity.MenuTextCN =Convert.ToString(_MenuTextCN.ToString());
                               					                         
                
                                                                   
                    _GlobalMenuEntity.MenuTextEN =Convert.ToString(_MenuTextEN.ToString());
                               					                         
                
                                                                   
                    _GlobalMenuEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
                               					                         
                
                                                                   
                    _GlobalMenuEntity.LinkUrl =Convert.ToString(_LinkUrl.ToString());
                               					                         
                
                                                                        _GlobalMenuEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                                					                         
                
                                                                        _GlobalMenuEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                                					                         
                
                                                                        _GlobalMenuEntity.ParentID =Convert.ToInt32(_ParentID.ToString());
                                					                         
                
                                                                        _GlobalMenuEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                                					                       					        
		       	_GlobalMenuEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateGlobalMenu(_GlobalMenuEntity);
            }
            catch
            {
                WriteLog("GlobalMenuEditFunc", "编辑GlobalMenu", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新GlobalMenu资料成功","");
        }
        #endregion
    }
}