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
    public partial class WG_MajorEdit : BaseForm
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
                WG_MajorAdd();
            }
            else
            {
                WG_MajorEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_MajorEntity _WG_MajorEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_MajorEntity = DataProvider.GetInstance().GetWG_MajorEntity(int.Parse(ctrID));

               				                				                   TextBox_Name.Text = _WG_MajorEntity.Name.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void WG_MajorAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 专业名称 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            WG_MajorEntity  _WG_MajorEntity = new WG_MajorEntity();
            
               		                               	  		                            
                 	                 	                
                    _WG_MajorEntity.Name =Convert.ToString(_Name.ToString());
               		                        	  		        
		       	_WG_MajorEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_WG_MajorEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_Major(_WG_MajorEntity);
            }
            catch
            {
                WriteLog("WG_MajorAdd", "添加WG_Major", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Major成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_MajorEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 专业名称 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion


             
  
               		                       					                         
                
                                                                   
                    _WG_MajorEntity.Name =Convert.ToString(_Name.ToString());
                               					                       					        
		       	_WG_MajorEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateWG_Major(_WG_MajorEntity);
            }
            catch
            {
                WriteLog("WG_MajorEditFunc", "编辑WG_Major", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Major资料成功","");
        }
        #endregion
    }
}