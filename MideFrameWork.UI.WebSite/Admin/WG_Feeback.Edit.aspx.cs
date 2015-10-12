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
    public partial class WG_FeebackEdit : BaseForm
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
                WG_FeebackAdd();
            }
            else
            {
                WG_FeebackEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_FeebackEntity _WG_FeebackEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_FeebackEntity = DataProvider.GetInstance().GetWG_FeebackEntity(int.Parse(ctrID));

               				                				                   TextBox_PromoterID.Text = _WG_FeebackEntity.PromoterID.ToString();
                                				                   TextBox_Detail.Text = _WG_FeebackEntity.Detail.ToString();
                                				                   TextBox_Memo.Text = _WG_FeebackEntity.Memo.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void WG_FeebackAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _PromoterID = Request.Form["TextBox_PromoterID"];
                 if (string.IsNullOrEmpty(_PromoterID))
                   {
                        Alert("[ 反馈人ID ]不能为空");
                        return;
                  }
				                                           
                  var _Detail = Request.Form["TextBox_Detail"];
                 if (string.IsNullOrEmpty(_Detail))
                   {
                        Alert("[ 反馈明显 ]不能为空");
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

            WG_FeebackEntity  _WG_FeebackEntity = new WG_FeebackEntity();
            
               		                               	  		                            
                 	                 	                     _WG_FeebackEntity.PromoterID =Convert.ToInt32(_PromoterID.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_FeebackEntity.Detail =Convert.ToString(_Detail.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_FeebackEntity.Memo =Convert.ToString(_Memo.ToString());
               		                        	  		        
		       	_WG_FeebackEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_Feeback(_WG_FeebackEntity);
            }
            catch
            {
                WriteLog("WG_FeebackAdd", "添加WG_Feeback", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Feeback成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_FeebackEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _PromoterID = Request.Form["TextBox_PromoterID"];
                 if (string.IsNullOrEmpty(_PromoterID))
                   {
                        Alert("[ 反馈人ID ]不能为空");
                        return;
                  }
				                                           
                  var _Detail = Request.Form["TextBox_Detail"];
                 if (string.IsNullOrEmpty(_Detail))
                   {
                        Alert("[ 反馈明显 ]不能为空");
                        return;
                  }
				                                           
                  var _Memo = Request.Form["TextBox_Memo"];
                 if (string.IsNullOrEmpty(_Memo))
                   {
                        Alert("[ 备注 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                        _WG_FeebackEntity.PromoterID =Convert.ToInt32(_PromoterID.ToString());
                                					                         
                
                                                                   
                    _WG_FeebackEntity.Detail =Convert.ToString(_Detail.ToString());
                               					                         
                
                                                                   
                    _WG_FeebackEntity.Memo =Convert.ToString(_Memo.ToString());
                               					                       			            try
            {
                DataProvider.GetInstance().UpdateWG_Feeback(_WG_FeebackEntity);
            }
            catch
            {
                WriteLog("WG_FeebackEditFunc", "编辑WG_Feeback", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Feeback资料成功","");
        }
        #endregion
    }
}