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
    public partial class Base_ButtonEdit : BaseForm
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
                Base_ButtonAdd();
            }
            else
            {
                Base_ButtonEditFunc(ctrID);
            }
        }

        #region 初始化表单
        Base_ButtonEntity _Base_ButtonEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _Base_ButtonEntity = DataProvider.GetInstance().GetBase_ButtonEntity(int.Parse(ctrID));

               				                				                   TextBox_Title.Text = _Base_ButtonEntity.Title.ToString();
                                				                   TextBox_Memo.Text = _Base_ButtonEntity.Memo.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void Base_ButtonAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 权限名称 ]不能为空");
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

            Base_ButtonEntity  _Base_ButtonEntity = new Base_ButtonEntity();
            
               		                               	  		                            
                 	                 	                
                    _Base_ButtonEntity.Title =Convert.ToString(_Title.ToString());
               		                        	  		                            
                 	                 	                
                    _Base_ButtonEntity.Memo =Convert.ToString(_Memo.ToString());
               		                        	  		        
		       	_Base_ButtonEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_Base_ButtonEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddBase_Button(_Base_ButtonEntity);
            }
            catch
            {
                WriteLog("Base_ButtonAdd", "添加Base_Button", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Base_Button成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void Base_ButtonEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 权限名称 ]不能为空");
                        return;
                  }
				                                           
                  var _Memo = Request.Form["TextBox_Memo"];
                 if (string.IsNullOrEmpty(_Memo))
                   {
                        Alert("[ 备注 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _Base_ButtonEntity.Title =Convert.ToString(_Title.ToString());
                               					                         
                
                                                                   
                    _Base_ButtonEntity.Memo =Convert.ToString(_Memo.ToString());
                               					                       					        
		       	_Base_ButtonEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateBase_Button(_Base_ButtonEntity);
            }
            catch
            {
                WriteLog("Base_ButtonEditFunc", "编辑Base_Button", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Base_Button资料成功","");
        }
        #endregion
    }
}