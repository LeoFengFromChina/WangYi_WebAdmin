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
    public partial class GlobalPictureEdit : BaseForm
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
                GlobalPictureAdd();
            }
            else
            {
                GlobalPictureEditFunc(ctrID);
            }
        }

        #region 初始化表单
        GlobalPictureEntity _GlobalPictureEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _GlobalPictureEntity = DataProvider.GetInstance().GetGlobalPictureEntity(int.Parse(ctrID));

               				                				                   TextBox_ShowTextCN.Text = _GlobalPictureEntity.ShowTextCN.ToString();
                                				                   TextBox_ShowTextEN.Text = _GlobalPictureEntity.ShowTextEN.ToString();
                                				                   TextBox_IconUrl.Text = _GlobalPictureEntity.IconUrl.ToString();
                                				                   TextBox_LinkUrl.Text = _GlobalPictureEntity.LinkUrl.ToString();
                                				                   TextBox_IsEnable.Text = _GlobalPictureEntity.IsEnable.ToString();
                                				                   TextBox_DisplayIndex.Text = _GlobalPictureEntity.DisplayIndex.ToString();
                                				                   TextBox_GroupID.Text = _GlobalPictureEntity.GroupID.ToString();
                                				                   TextBox_OwnerID.Text = _GlobalPictureEntity.OwnerID.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void GlobalPictureAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _ShowTextCN = Request.Form["TextBox_ShowTextCN"];
                 if (string.IsNullOrEmpty(_ShowTextCN))
                   {
                        Alert("[ 中文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _ShowTextEN = Request.Form["TextBox_ShowTextEN"];
                 if (string.IsNullOrEmpty(_ShowTextEN))
                   {
                        Alert("[ 英文标题 ]不能为空");
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
				                                           
                  var _GroupID = Request.Form["TextBox_GroupID"];
                 if (string.IsNullOrEmpty(_GroupID))
                   {
                        Alert("[ 所属组ID ]不能为空");
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

            GlobalPictureEntity  _GlobalPictureEntity = new GlobalPictureEntity();
            
               		                               	  		                            
                 	                 	                
                    _GlobalPictureEntity.ShowTextCN =Convert.ToString(_ShowTextCN.ToString());
               		                        	  		                            
                 	                 	                
                    _GlobalPictureEntity.ShowTextEN =Convert.ToString(_ShowTextEN.ToString());
               		                        	  		                            
                 	                 	                
                    _GlobalPictureEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
               		                        	  		                            
                 	                 	                
                    _GlobalPictureEntity.LinkUrl =Convert.ToString(_LinkUrl.ToString());
               		                        	  		                            
                 	                 	                     _GlobalPictureEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                	                        	  		                            
                 	                 	                     _GlobalPictureEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                	                        	  		                            
                 	                 	                     _GlobalPictureEntity.GroupID =Convert.ToInt32(_GroupID.ToString());
                	                        	  		                            
                 	                 	                     _GlobalPictureEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                	                        	  		        
		       	_GlobalPictureEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_GlobalPictureEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddGlobalPicture(_GlobalPictureEntity);
            }
            catch
            {
                WriteLog("GlobalPictureAdd", "添加GlobalPicture", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加GlobalPicture成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void GlobalPictureEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _ShowTextCN = Request.Form["TextBox_ShowTextCN"];
                 if (string.IsNullOrEmpty(_ShowTextCN))
                   {
                        Alert("[ 中文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _ShowTextEN = Request.Form["TextBox_ShowTextEN"];
                 if (string.IsNullOrEmpty(_ShowTextEN))
                   {
                        Alert("[ 英文标题 ]不能为空");
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
				                                           
                  var _GroupID = Request.Form["TextBox_GroupID"];
                 if (string.IsNullOrEmpty(_GroupID))
                   {
                        Alert("[ 所属组ID ]不能为空");
                        return;
                  }
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 所属者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _GlobalPictureEntity.ShowTextCN =Convert.ToString(_ShowTextCN.ToString());
                               					                         
                
                                                                   
                    _GlobalPictureEntity.ShowTextEN =Convert.ToString(_ShowTextEN.ToString());
                               					                         
                
                                                                   
                    _GlobalPictureEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
                               					                         
                
                                                                   
                    _GlobalPictureEntity.LinkUrl =Convert.ToString(_LinkUrl.ToString());
                               					                         
                
                                                                        _GlobalPictureEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                                					                         
                
                                                                        _GlobalPictureEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                                					                         
                
                                                                        _GlobalPictureEntity.GroupID =Convert.ToInt32(_GroupID.ToString());
                                					                         
                
                                                                        _GlobalPictureEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                                					                       					        
		       	_GlobalPictureEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateGlobalPicture(_GlobalPictureEntity);
            }
            catch
            {
                WriteLog("GlobalPictureEditFunc", "编辑GlobalPicture", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新GlobalPicture资料成功","");
        }
        #endregion
    }
}