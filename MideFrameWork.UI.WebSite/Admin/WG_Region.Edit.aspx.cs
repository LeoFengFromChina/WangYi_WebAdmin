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
    public partial class WG_RegionEdit : BaseForm
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
                WG_RegionAdd();
            }
            else
            {
                WG_RegionEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_RegionEntity _WG_RegionEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_RegionEntity = DataProvider.GetInstance().GetWG_RegionEntity(int.Parse(ctrID));

               				                				                   TextBox_ParentID.Text = _WG_RegionEntity.ParentID.ToString();
                                				                   TextBox_Name.Text = _WG_RegionEntity.Name.ToString();
                                				                   TextBox_Meno.Text = _WG_RegionEntity.Meno.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void WG_RegionAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _ParentID = Request.Form["TextBox_ParentID"];
                 if (string.IsNullOrEmpty(_ParentID))
                   {
                        Alert("[ 父ID ]不能为空");
                        return;
                  }
				                                           
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 区域名称 ]不能为空");
                        return;
                  }
				                                           
                  var _Meno = Request.Form["TextBox_Meno"];
                 if (string.IsNullOrEmpty(_Meno))
                   {
                        Alert("[ 备注 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            WG_RegionEntity  _WG_RegionEntity = new WG_RegionEntity();
            
               		                               	  		                            
                 	                 	                     _WG_RegionEntity.ParentID =Convert.ToInt32(_ParentID.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_RegionEntity.Name =Convert.ToString(_Name.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_RegionEntity.Meno =Convert.ToString(_Meno.ToString());
               		                        	  		        
		       	_WG_RegionEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_WG_RegionEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_Region(_WG_RegionEntity);
            }
            catch
            {
                WriteLog("WG_RegionAdd", "添加WG_Region", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Region成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_RegionEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _ParentID = Request.Form["TextBox_ParentID"];
                 if (string.IsNullOrEmpty(_ParentID))
                   {
                        Alert("[ 父ID ]不能为空");
                        return;
                  }
				                                           
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 区域名称 ]不能为空");
                        return;
                  }
				                                           
                  var _Meno = Request.Form["TextBox_Meno"];
                 if (string.IsNullOrEmpty(_Meno))
                   {
                        Alert("[ 备注 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion


             
  
               		                       					                         
                
                                                                        _WG_RegionEntity.ParentID =Convert.ToInt32(_ParentID.ToString());
                                					                         
                
                                                                   
                    _WG_RegionEntity.Name =Convert.ToString(_Name.ToString());
                               					                         
                
                                                                   
                    _WG_RegionEntity.Meno =Convert.ToString(_Meno.ToString());
                               					                       					        
		       	_WG_RegionEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateWG_Region(_WG_RegionEntity);
            }
            catch
            {
                WriteLog("WG_RegionEditFunc", "编辑WG_Region", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Region资料成功","");
        }
        #endregion
    }
}