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
    public partial class Base_ModuleEdit : BaseForm
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
                Base_ModuleAdd();
            }
            else
            {
                Base_ModuleEditFunc(ctrID);
            }
        }

        #region 初始化表单
        Base_ModuleEntity _Base_ModuleEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _Base_ModuleEntity = DataProvider.GetInstance().GetBase_ModuleEntity(int.Parse(ctrID));

               				                				                   TextBox_Name.Text = _Base_ModuleEntity.Name.ToString();
                                				                   TextBox_Memo.Text = _Base_ModuleEntity.Memo.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void Base_ModuleAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 模块名称 ]不能为空");
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

            Base_ModuleEntity  _Base_ModuleEntity = new Base_ModuleEntity();
            
               		                               	  		                            
                 	                 	                
                    _Base_ModuleEntity.Name =Convert.ToString(_Name.ToString());
               		                        	  		                            
                 	                 	                
                    _Base_ModuleEntity.Memo =Convert.ToString(_Memo.ToString());
               		                        	  		        
		       	_Base_ModuleEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddBase_Module(_Base_ModuleEntity);
            }
            catch
            {
                WriteLog("Base_ModuleAdd", "添加Base_Module", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Base_Module成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void Base_ModuleEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 模块名称 ]不能为空");
                        return;
                  }
				                                           
                  var _Memo = Request.Form["TextBox_Memo"];
                 if (string.IsNullOrEmpty(_Memo))
                   {
                        Alert("[ 备注 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _Base_ModuleEntity.Name =Convert.ToString(_Name.ToString());
                               					                         
                
                                                                   
                    _Base_ModuleEntity.Memo =Convert.ToString(_Memo.ToString());
                               					                       			            try
            {
                DataProvider.GetInstance().UpdateBase_Module(_Base_ModuleEntity);
            }
            catch
            {
                WriteLog("Base_ModuleEditFunc", "编辑Base_Module", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Base_Module资料成功","");
        }
        #endregion
    }
}