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
    public partial class WG_VenderEdit : BaseForm
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
                WG_VenderAdd();
            }
            else
            {
                WG_VenderEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_VenderEntity _WG_VenderEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_VenderEntity = DataProvider.GetInstance().GetWG_VenderEntity(int.Parse(ctrID));

               				                				                   TextBox_VenderName.Text = _WG_VenderEntity.VenderName.ToString();
                                				                   TextBox_VenderType.Text = _WG_VenderEntity.VenderType.ToString();
                                				                   TextBox_Logo.Text = _WG_VenderEntity.Logo.ToString();
                                				                   TextBox_Address.Text = _WG_VenderEntity.Address.ToString();
                                				                   TextBox_ComLevel.Text = _WG_VenderEntity.ComLevel.ToString();
                                				                   TextBox_Phone.Text = _WG_VenderEntity.Phone.ToString();
                                				                   TextBox_Memo.Text = _WG_VenderEntity.Memo.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void WG_VenderAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _VenderName = Request.Form["TextBox_VenderName"];
                 if (string.IsNullOrEmpty(_VenderName))
                   {
                        Alert("[ 商家名称 ]不能为空");
                        return;
                  }
				                                           
                  var _VenderType = Request.Form["TextBox_VenderType"];
                 if (string.IsNullOrEmpty(_VenderType))
                   {
                        Alert("[ 商家类别 ]不能为空");
                        return;
                  }
				                                           
                  var _Logo = Request.Form["TextBox_Logo"];
                 if (string.IsNullOrEmpty(_Logo))
                   {
                        Alert("[ 图片 ]不能为空");
                        return;
                  }
				                                           
                  var _Address = Request.Form["TextBox_Address"];
                 if (string.IsNullOrEmpty(_Address))
                   {
                        Alert("[ 地址 ]不能为空");
                        return;
                  }
				                                           
                  var _ComLevel = Request.Form["TextBox_ComLevel"];
                 if (string.IsNullOrEmpty(_ComLevel))
                   {
                        Alert("[ 合作等级 ]不能为空");
                        return;
                  }
				                                           
                  var _Phone = Request.Form["TextBox_Phone"];
                 if (string.IsNullOrEmpty(_Phone))
                   {
                        Alert("[ 联系电话 ]不能为空");
                        return;
                  }
				                                           
                  var _Memo = Request.Form["TextBox_Memo"];
                 if (string.IsNullOrEmpty(_Memo))
                   {
                        Alert("[ 备注 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
           
            #region 获取数据

            WG_VenderEntity  _WG_VenderEntity = new WG_VenderEntity();
            
               		                               	  		                            
                 	                 	                
                    _WG_VenderEntity.VenderName =Convert.ToString(_VenderName.ToString());
               		                        	  		                            
                 	                 	                     _WG_VenderEntity.VenderType =Convert.ToInt32(_VenderType.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_VenderEntity.Logo =Convert.ToString(_Logo.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_VenderEntity.Address =Convert.ToString(_Address.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_VenderEntity.ComLevel =Convert.ToString(_ComLevel.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_VenderEntity.Phone =Convert.ToString(_Phone.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_VenderEntity.Memo =Convert.ToString(_Memo.ToString());
               		                        	  		        
		       	_WG_VenderEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_Vender(_WG_VenderEntity);
            }
            catch
            {
                WriteLog("WG_VenderAdd", "添加WG_Vender", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Vender成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_VenderEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _VenderName = Request.Form["TextBox_VenderName"];
                 if (string.IsNullOrEmpty(_VenderName))
                   {
                        Alert("[ 商家名称 ]不能为空");
                        return;
                  }
				                                           
                  var _VenderType = Request.Form["TextBox_VenderType"];
                 if (string.IsNullOrEmpty(_VenderType))
                   {
                        Alert("[ 商家类别 ]不能为空");
                        return;
                  }
				                                           
                  var _Logo = Request.Form["TextBox_Logo"];
                 if (string.IsNullOrEmpty(_Logo))
                   {
                        Alert("[ 图片 ]不能为空");
                        return;
                  }
				                                           
                  var _Address = Request.Form["TextBox_Address"];
                 if (string.IsNullOrEmpty(_Address))
                   {
                        Alert("[ 地址 ]不能为空");
                        return;
                  }
				                                           
                  var _ComLevel = Request.Form["TextBox_ComLevel"];
                 if (string.IsNullOrEmpty(_ComLevel))
                   {
                        Alert("[ 合作等级 ]不能为空");
                        return;
                  }
				                                           
                  var _Phone = Request.Form["TextBox_Phone"];
                 if (string.IsNullOrEmpty(_Phone))
                   {
                        Alert("[ 联系电话 ]不能为空");
                        return;
                  }
				                                           
                  var _Memo = Request.Form["TextBox_Memo"];
                 if (string.IsNullOrEmpty(_Memo))
                   {
                        Alert("[ 备注 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _WG_VenderEntity.VenderName =Convert.ToString(_VenderName.ToString());
                               					                         
                
                                                                        _WG_VenderEntity.VenderType =Convert.ToInt32(_VenderType.ToString());
                                					                         
                
                                                                   
                    _WG_VenderEntity.Logo =Convert.ToString(_Logo.ToString());
                               					                         
                
                                                                   
                    _WG_VenderEntity.Address =Convert.ToString(_Address.ToString());
                               					                         
                
                                                                   
                    _WG_VenderEntity.ComLevel =Convert.ToString(_ComLevel.ToString());
                               					                         
                
                                                                   
                    _WG_VenderEntity.Phone =Convert.ToString(_Phone.ToString());
                               					                         
                
                                                                   
                    _WG_VenderEntity.Memo =Convert.ToString(_Memo.ToString());
                               					                       			            try
            {
                DataProvider.GetInstance().UpdateWG_Vender(_WG_VenderEntity);
            }
            catch
            {
                WriteLog("WG_VenderEditFunc", "编辑WG_Vender", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Vender资料成功","");
        }
        #endregion
    }
}