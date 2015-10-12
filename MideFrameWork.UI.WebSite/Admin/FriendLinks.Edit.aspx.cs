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
    public partial class FriendLinksEdit : BaseForm
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
                FriendLinksAdd();
            }
            else
            {
                FriendLinksEditFunc(ctrID);
            }
        }

        #region 初始化表单
        FriendLinksEntity _FriendLinksEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _FriendLinksEntity = DataProvider.GetInstance().GetFriendLinksEntity(int.Parse(ctrID));

               				                				                   TextBox_LinkTextCN.Text = _FriendLinksEntity.LinkTextCN.ToString();
                                				                   TextBox_LinkTextEN.Text = _FriendLinksEntity.LinkTextEN.ToString();
                                				                   TextBox_IconUrl.Text = _FriendLinksEntity.IconUrl.ToString();
                                				                   TextBox_LinkUrl.Text = _FriendLinksEntity.LinkUrl.ToString();
                                				                   TextBox_IsEnable.Text = _FriendLinksEntity.IsEnable.ToString();
                                				                   TextBox_DisplayIndex.Text = _FriendLinksEntity.DisplayIndex.ToString();
                                				                   TextBox_OwnerID.Text = _FriendLinksEntity.OwnerID.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void FriendLinksAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _LinkTextCN = Request.Form["TextBox_LinkTextCN"];
                 if (string.IsNullOrEmpty(_LinkTextCN))
                   {
                        Alert("[ 中文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _LinkTextEN = Request.Form["TextBox_LinkTextEN"];
                 if (string.IsNullOrEmpty(_LinkTextEN))
                   {
                        Alert("[ 英文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _IconUrl = Request.Form["TextBox_IconUrl"];
                 if (string.IsNullOrEmpty(_IconUrl))
                   {
                        Alert("[ 图标地址 ]不能为空");
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
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 所属者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            FriendLinksEntity  _FriendLinksEntity = new FriendLinksEntity();
            
               		                               	  		                            
                 	                 	                
                    _FriendLinksEntity.LinkTextCN =Convert.ToString(_LinkTextCN.ToString());
               		                        	  		                            
                 	                 	                
                    _FriendLinksEntity.LinkTextEN =Convert.ToString(_LinkTextEN.ToString());
               		                        	  		                            
                 	                 	                
                    _FriendLinksEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
               		                        	  		                            
                 	                 	                
                    _FriendLinksEntity.LinkUrl =Convert.ToString(_LinkUrl.ToString());
               		                        	  		                            
                 	                 	                     _FriendLinksEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                	                        	  		                            
                 	                 	                     _FriendLinksEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                	                        	  		                            
                 	                 	                     _FriendLinksEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                	                        	  		        
		       	_FriendLinksEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_FriendLinksEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddFriendLinks(_FriendLinksEntity);
            }
            catch
            {
                WriteLog("FriendLinksAdd", "添加FriendLinks", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加FriendLinks成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void FriendLinksEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _LinkTextCN = Request.Form["TextBox_LinkTextCN"];
                 if (string.IsNullOrEmpty(_LinkTextCN))
                   {
                        Alert("[ 中文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _LinkTextEN = Request.Form["TextBox_LinkTextEN"];
                 if (string.IsNullOrEmpty(_LinkTextEN))
                   {
                        Alert("[ 英文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _IconUrl = Request.Form["TextBox_IconUrl"];
                 if (string.IsNullOrEmpty(_IconUrl))
                   {
                        Alert("[ 图标地址 ]不能为空");
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
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 所属者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _FriendLinksEntity.LinkTextCN =Convert.ToString(_LinkTextCN.ToString());
                               					                         
                
                                                                   
                    _FriendLinksEntity.LinkTextEN =Convert.ToString(_LinkTextEN.ToString());
                               					                         
                
                                                                   
                    _FriendLinksEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
                               					                         
                
                                                                   
                    _FriendLinksEntity.LinkUrl =Convert.ToString(_LinkUrl.ToString());
                               					                         
                
                                                                        _FriendLinksEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                                					                         
                
                                                                        _FriendLinksEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                                					                         
                
                                                                        _FriendLinksEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                                					                       					        
		       	_FriendLinksEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateFriendLinks(_FriendLinksEntity);
            }
            catch
            {
                WriteLog("FriendLinksEditFunc", "编辑FriendLinks", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新FriendLinks资料成功","");
        }
        #endregion
    }
}