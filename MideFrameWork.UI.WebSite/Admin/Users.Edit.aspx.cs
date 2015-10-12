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
    public partial class UsersEdit : BaseForm
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
                UsersAdd();
            }
            else
            {
                UsersEditFunc(ctrID);
            }
        }

        #region 初始化表单
        UsersEntity _UsersEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _UsersEntity = DataProvider.GetInstance().GetUsersEntity(int.Parse(ctrID));

               				                				                   TextBox_ChildAccount.Text = _UsersEntity.ChildAccount.ToString();
                                				                   TextBox_ParentAccount.Text = _UsersEntity.ParentAccount.ToString();
                                				                   TextBox_Status.Text = _UsersEntity.Status.ToString();
                                				                   TextBox_GroupID.Text = _UsersEntity.GroupID.ToString();
                                				                   TextBox_IsAdmin.Text = _UsersEntity.IsAdmin.ToString();
                                				                   TextBox_Password.Text = _UsersEntity.Password.ToString();
                                				                   TextBox_CorpName.Text = _UsersEntity.CorpName.ToString();
                                				                   TextBox_Signature.Text = _UsersEntity.Signature.ToString();
                                				                   TextBox_ChannelID.Text = _UsersEntity.ChannelID.ToString();
                                				                   TextBox_Balance.Text = _UsersEntity.Balance.ToString();
                                				                   TextBox_Email.Text = _UsersEntity.Email.ToString();
                                				                   TextBox_TelePhone.Text = _UsersEntity.TelePhone.ToString();
                                				                   TextBox_MobilePhone.Text = _UsersEntity.MobilePhone.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void UsersAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _ChildAccount = Request.Form["TextBox_ChildAccount"];
                 if (string.IsNullOrEmpty(_ChildAccount))
                   {
                        Alert("[ 子账号 ]不能为空");
                        return;
                  }
				                                           
                  var _ParentAccount = Request.Form["TextBox_ParentAccount"];
                 if (string.IsNullOrEmpty(_ParentAccount))
                   {
                        Alert("[ 企业账号 ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 状态(0：正常，1:停用，2：删除) ]不能为空");
                        return;
                  }
				                                           
                  var _GroupID = Request.Form["TextBox_GroupID"];
                 if (string.IsNullOrEmpty(_GroupID))
                   {
                        Alert("[ 分组ID ]不能为空");
                        return;
                  }
				                                           
                  var _IsAdmin = Request.Form["TextBox_IsAdmin"];
                 if (string.IsNullOrEmpty(_IsAdmin))
                   {
                        Alert("[ 是否是管理员 ]不能为空");
                        return;
                  }
				                                           
                  var _Password = Request.Form["TextBox_Password"];
                 if (string.IsNullOrEmpty(_Password))
                   {
                        Alert("[ 密码 ]不能为空");
                        return;
                  }
				                                           
                  var _CorpName = Request.Form["TextBox_CorpName"];
                 if (string.IsNullOrEmpty(_CorpName))
                   {
                        Alert("[ 企业名称 ]不能为空");
                        return;
                  }
				                                           
                  var _Signature = Request.Form["TextBox_Signature"];
                 if (string.IsNullOrEmpty(_Signature))
                   {
                        Alert("[ 个人签名 ]不能为空");
                        return;
                  }
				                                           
                  var _ChannelID = Request.Form["TextBox_ChannelID"];
                 if (string.IsNullOrEmpty(_ChannelID))
                   {
                        Alert("[ 通道ID ]不能为空");
                        return;
                  }
				                                           
                  var _Balance = Request.Form["TextBox_Balance"];
                 if (string.IsNullOrEmpty(_Balance))
                   {
                        Alert("[ 余额(默认为0) ]不能为空");
                        return;
                  }
				                                           
                  var _Email = Request.Form["TextBox_Email"];
                 if (string.IsNullOrEmpty(_Email))
                   {
                        Alert("[ 邮箱 ]不能为空");
                        return;
                  }
				                                           
                  var _TelePhone = Request.Form["TextBox_TelePhone"];
                 if (string.IsNullOrEmpty(_TelePhone))
                   {
                        Alert("[ 电话 ]不能为空");
                        return;
                  }
				                                           
                  var _MobilePhone = Request.Form["TextBox_MobilePhone"];
                 if (string.IsNullOrEmpty(_MobilePhone))
                   {
                        Alert("[ 手机 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            UsersEntity  _UsersEntity = new UsersEntity();
            
               		                               	  		                            
                 	                 	                
                    _UsersEntity.ChildAccount =Convert.ToString(_ChildAccount.ToString());
               		                        	  		                            
                 	                 	                
                    _UsersEntity.ParentAccount =Convert.ToString(_ParentAccount.ToString());
               		                        	  		                            
                 	                 	                     _UsersEntity.Status =Convert.ToInt32(_Status.ToString());
                	                        	  		                            
                 	                 	                     _UsersEntity.GroupID =Convert.ToInt32(_GroupID.ToString());
                	                        	  		                            
                 	                 	                     _UsersEntity.IsAdmin =Convert.ToInt32(_IsAdmin.ToString());
                	                        	  		                            
                 	                 	                
                    _UsersEntity.Password =Convert.ToString(_Password.ToString());
               		                        	  		                            
                 	                 	                
                    _UsersEntity.CorpName =Convert.ToString(_CorpName.ToString());
               		                        	  		                            
                 	                 	                
                    _UsersEntity.Signature =Convert.ToString(_Signature.ToString());
               		                        	  		                            
                 	                 	                     _UsersEntity.ChannelID =Convert.ToInt32(_ChannelID.ToString());
                	                        	  		                            
                 	                 	                     _UsersEntity.Balance =Convert.ToInt32(_Balance.ToString());
                	                        	  		                            
                 	                 	                
                    _UsersEntity.Email =Convert.ToString(_Email.ToString());
               		                        	  		                            
                 	                 	                
                    _UsersEntity.TelePhone =Convert.ToString(_TelePhone.ToString());
               		                        	  		                            
                 	                 	                
                    _UsersEntity.MobilePhone =Convert.ToString(_MobilePhone.ToString());
               		                        	  		        
		       	_UsersEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_UsersEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddUsers(_UsersEntity);
            }
            catch
            {
                WriteLog("UsersAdd", "添加Users", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Users成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void UsersEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _ChildAccount = Request.Form["TextBox_ChildAccount"];
                 if (string.IsNullOrEmpty(_ChildAccount))
                   {
                        Alert("[ 子账号 ]不能为空");
                        return;
                  }
				                                           
                  var _ParentAccount = Request.Form["TextBox_ParentAccount"];
                 if (string.IsNullOrEmpty(_ParentAccount))
                   {
                        Alert("[ 企业账号 ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 状态(0：正常，1:停用，2：删除) ]不能为空");
                        return;
                  }
				                                           
                  var _GroupID = Request.Form["TextBox_GroupID"];
                 if (string.IsNullOrEmpty(_GroupID))
                   {
                        Alert("[ 分组ID ]不能为空");
                        return;
                  }
				                                           
                  var _IsAdmin = Request.Form["TextBox_IsAdmin"];
                 if (string.IsNullOrEmpty(_IsAdmin))
                   {
                        Alert("[ 是否是管理员 ]不能为空");
                        return;
                  }
				                                           
                  var _Password = Request.Form["TextBox_Password"];
                 if (string.IsNullOrEmpty(_Password))
                   {
                        Alert("[ 密码 ]不能为空");
                        return;
                  }
				                                           
                  var _CorpName = Request.Form["TextBox_CorpName"];
                 if (string.IsNullOrEmpty(_CorpName))
                   {
                        Alert("[ 企业名称 ]不能为空");
                        return;
                  }
				                                           
                  var _Signature = Request.Form["TextBox_Signature"];
                 if (string.IsNullOrEmpty(_Signature))
                   {
                        Alert("[ 个人签名 ]不能为空");
                        return;
                  }
				                                           
                  var _ChannelID = Request.Form["TextBox_ChannelID"];
                 if (string.IsNullOrEmpty(_ChannelID))
                   {
                        Alert("[ 通道ID ]不能为空");
                        return;
                  }
				                                           
                  var _Balance = Request.Form["TextBox_Balance"];
                 if (string.IsNullOrEmpty(_Balance))
                   {
                        Alert("[ 余额(默认为0) ]不能为空");
                        return;
                  }
				                                           
                  var _Email = Request.Form["TextBox_Email"];
                 if (string.IsNullOrEmpty(_Email))
                   {
                        Alert("[ 邮箱 ]不能为空");
                        return;
                  }
				                                           
                  var _TelePhone = Request.Form["TextBox_TelePhone"];
                 if (string.IsNullOrEmpty(_TelePhone))
                   {
                        Alert("[ 电话 ]不能为空");
                        return;
                  }
				                                           
                  var _MobilePhone = Request.Form["TextBox_MobilePhone"];
                 if (string.IsNullOrEmpty(_MobilePhone))
                   {
                        Alert("[ 手机 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _UsersEntity.ChildAccount =Convert.ToString(_ChildAccount.ToString());
                               					                         
                
                                                                   
                    _UsersEntity.ParentAccount =Convert.ToString(_ParentAccount.ToString());
                               					                         
                
                                                                        _UsersEntity.Status =Convert.ToInt32(_Status.ToString());
                                					                         
                
                                                                        _UsersEntity.GroupID =Convert.ToInt32(_GroupID.ToString());
                                					                         
                
                                                                        _UsersEntity.IsAdmin =Convert.ToInt32(_IsAdmin.ToString());
                                					                         
                
                                                                   
                    _UsersEntity.Password =Convert.ToString(_Password.ToString());
                               					                         
                
                                                                   
                    _UsersEntity.CorpName =Convert.ToString(_CorpName.ToString());
                               					                         
                
                                                                   
                    _UsersEntity.Signature =Convert.ToString(_Signature.ToString());
                               					                         
                
                                                                        _UsersEntity.ChannelID =Convert.ToInt32(_ChannelID.ToString());
                                					                         
                
                                                                        _UsersEntity.Balance =Convert.ToInt32(_Balance.ToString());
                                					                         
                
                                                                   
                    _UsersEntity.Email =Convert.ToString(_Email.ToString());
                               					                         
                
                                                                   
                    _UsersEntity.TelePhone =Convert.ToString(_TelePhone.ToString());
                               					                         
                
                                                                   
                    _UsersEntity.MobilePhone =Convert.ToString(_MobilePhone.ToString());
                               					                       					        
		       	_UsersEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateUsers(_UsersEntity);
            }
            catch
            {
                WriteLog("UsersEditFunc", "编辑Users", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Users资料成功","");
        }
        #endregion
    }
}