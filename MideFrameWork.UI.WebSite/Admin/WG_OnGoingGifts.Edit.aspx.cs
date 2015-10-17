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
    public partial class WG_OnGoingGiftsEdit : BaseForm
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
                WG_OnGoingGiftsAdd();
            }
            else
            {
                WG_OnGoingGiftsEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_OnGoingGiftsEntity _WG_OnGoingGiftsEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_OnGoingGiftsEntity = DataProvider.GetInstance().GetWG_OnGoingGiftsEntity(int.Parse(ctrID));

               				                				                   TextBox_Code.Text = _WG_OnGoingGiftsEntity.Code.ToString();
                                				                   TextBox_MenberID.Text = _WG_OnGoingGiftsEntity.MenberID.ToString();
                                				                   TextBox_GiftID.Text = _WG_OnGoingGiftsEntity.GiftID.ToString();
                                				                   TextBox_Count.Text = _WG_OnGoingGiftsEntity.Count.ToString();
                                				                   TextBox_Status.Text = _WG_OnGoingGiftsEntity.Status.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void WG_OnGoingGiftsAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Code = Request.Form["TextBox_Code"];
                 if (string.IsNullOrEmpty(_Code))
                   {
                        Alert("[ 兑换码 ]不能为空");
                        return;
                  }
				                                           
                  var _MenberID = Request.Form["TextBox_MenberID"];
                 if (string.IsNullOrEmpty(_MenberID))
                   {
                        Alert("[ 会员ID ]不能为空");
                        return;
                  }
				                                           
                  var _GiftID = Request.Form["TextBox_GiftID"];
                 if (string.IsNullOrEmpty(_GiftID))
                   {
                        Alert("[ 礼物ID ]不能为空");
                        return;
                  }
				                                           
                  var _Count = Request.Form["TextBox_Count"];
                 if (string.IsNullOrEmpty(_Count))
                   {
                        Alert("[ 数量 ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 状态 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
           
            #region 获取数据

            WG_OnGoingGiftsEntity  _WG_OnGoingGiftsEntity = new WG_OnGoingGiftsEntity();
            
               		                               	  		                            
                 	                 	                
                    _WG_OnGoingGiftsEntity.Code =Convert.ToString(_Code.ToString());
               		                        	  		                            
                 	                 	                     _WG_OnGoingGiftsEntity.MenberID =Convert.ToInt32(_MenberID.ToString());
                	                        	  		                            
                 	                 	                     _WG_OnGoingGiftsEntity.GiftID =Convert.ToInt32(_GiftID.ToString());
                	                        	  		                            
                 	                 	                     _WG_OnGoingGiftsEntity.Count =Convert.ToInt32(_Count.ToString());
                	                        	  		                            
                 	                 	                     _WG_OnGoingGiftsEntity.Status =Convert.ToInt32(_Status.ToString());
                	                        	  		        
		       	_WG_OnGoingGiftsEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_OnGoingGifts(_WG_OnGoingGiftsEntity);
            }
            catch
            {
                WriteLog("WG_OnGoingGiftsAdd", "添加WG_OnGoingGifts", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_OnGoingGifts成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_OnGoingGiftsEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Code = Request.Form["TextBox_Code"];
                 if (string.IsNullOrEmpty(_Code))
                   {
                        Alert("[ 兑换码 ]不能为空");
                        return;
                  }
				                                           
                  var _MenberID = Request.Form["TextBox_MenberID"];
                 if (string.IsNullOrEmpty(_MenberID))
                   {
                        Alert("[ 会员ID ]不能为空");
                        return;
                  }
				                                           
                  var _GiftID = Request.Form["TextBox_GiftID"];
                 if (string.IsNullOrEmpty(_GiftID))
                   {
                        Alert("[ 礼物ID ]不能为空");
                        return;
                  }
				                                           
                  var _Count = Request.Form["TextBox_Count"];
                 if (string.IsNullOrEmpty(_Count))
                   {
                        Alert("[ 数量 ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 状态 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _WG_OnGoingGiftsEntity.Code =Convert.ToString(_Code.ToString());
                               					                         
                
                                                                        _WG_OnGoingGiftsEntity.MenberID =Convert.ToInt32(_MenberID.ToString());
                                					                         
                
                                                                        _WG_OnGoingGiftsEntity.GiftID =Convert.ToInt32(_GiftID.ToString());
                                					                         
                
                                                                        _WG_OnGoingGiftsEntity.Count =Convert.ToInt32(_Count.ToString());
                                					                         
                
                                                                        _WG_OnGoingGiftsEntity.Status =Convert.ToInt32(_Status.ToString());
                                					                       			            try
            {
                DataProvider.GetInstance().UpdateWG_OnGoingGifts(_WG_OnGoingGiftsEntity);
            }
            catch
            {
                WriteLog("WG_OnGoingGiftsEditFunc", "编辑WG_OnGoingGifts", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_OnGoingGifts资料成功","");
        }
        #endregion
    }
}