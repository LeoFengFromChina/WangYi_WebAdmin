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
    public partial class WG_EducationEdit : BaseForm
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
                WG_EducationAdd();
            }
            else
            {
                WG_EducationEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_EducationEntity _WG_EducationEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_EducationEntity = DataProvider.GetInstance().GetWG_EducationEntity(int.Parse(ctrID));

               				                				                   TextBox_Name.Text = _WG_EducationEntity.Name.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void WG_EducationAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 学历名称 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            WG_EducationEntity  _WG_EducationEntity = new WG_EducationEntity();
            
               		                               	  		                            
                 	                 	                
                    _WG_EducationEntity.Name =Convert.ToString(_Name.ToString());
               		                        	  		        
		       	_WG_EducationEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_WG_EducationEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_Education(_WG_EducationEntity);
            }
            catch
            {
                WriteLog("WG_EducationAdd", "添加WG_Education", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Education成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_EducationEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 学历名称 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion


             
  
               		                       					                         
                
                                                                   
                    _WG_EducationEntity.Name =Convert.ToString(_Name.ToString());
                               					                       					        
		       	_WG_EducationEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateWG_Education(_WG_EducationEntity);
            }
            catch
            {
                WriteLog("WG_EducationEditFunc", "编辑WG_Education", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Education资料成功","");
        }
        #endregion
    }
}