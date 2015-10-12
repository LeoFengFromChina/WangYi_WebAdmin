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
    public partial class WG_ActivitiesEdit : BaseForm
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
                                
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                        TextBox_BeginTime.Attributes.Add("onclick", "MyCalendar.SetDate(this);");
                                            
                                            
                                            
                                            
                                    
            //表单提交事件
            Button_submit.Click += new EventHandler(Button_submit_Click);

            init_form(ctrID);
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                WG_ActivitiesAdd();
            }
            else
            {
                WG_ActivitiesEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_ActivitiesEntity _WG_ActivitiesEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_ActivitiesEntity = DataProvider.GetInstance().GetWG_ActivitiesEntity(int.Parse(ctrID));

               				                				                   TextBox_Title.Text = _WG_ActivitiesEntity.Title.ToString();
                                				                   TextBox_PromoterID.Text = _WG_ActivitiesEntity.PromoterID.ToString();
                                				                   TextBox_LinkManID.Text = _WG_ActivitiesEntity.LinkManID.ToString();
                                				                   TextBox_ActivityTypeID.Text = _WG_ActivitiesEntity.ActivityTypeID.ToString();
                                				                   TextBox_RegionID.Text = _WG_ActivitiesEntity.RegionID.ToString();
                                				                   TextBox_Address.Text = _WG_ActivitiesEntity.Address.ToString();
                                				                   TextBox_NeedMenberCount.Text = _WG_ActivitiesEntity.NeedMenberCount.ToString();
                                				                   TextBox_BeginTime.Text = _WG_ActivitiesEntity.BeginTime.ToString();
                                				                   TextBox_Detail.Text = _WG_ActivitiesEntity.Detail.ToString();
                                				                   TextBox_Status.Text = _WG_ActivitiesEntity.Status.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void WG_ActivitiesAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 活动标题 ]不能为空");
                        return;
                  }
				                                           
                  var _PromoterID = Request.Form["TextBox_PromoterID"];
                 if (string.IsNullOrEmpty(_PromoterID))
                   {
                        Alert("[ 发起人ID ]不能为空");
                        return;
                  }
				                                           
                  var _LinkManID = Request.Form["TextBox_LinkManID"];
                 if (string.IsNullOrEmpty(_LinkManID))
                   {
                        Alert("[ 联系人ID ]不能为空");
                        return;
                  }
				                                           
                  var _ActivityTypeID = Request.Form["TextBox_ActivityTypeID"];
                 if (string.IsNullOrEmpty(_ActivityTypeID))
                   {
                        Alert("[ 活动类型ID ]不能为空");
                        return;
                  }
				                                           
                  var _RegionID = Request.Form["TextBox_RegionID"];
                 if (string.IsNullOrEmpty(_RegionID))
                   {
                        Alert("[ 区域ID ]不能为空");
                        return;
                  }
				                                           
                  var _Address = Request.Form["TextBox_Address"];
                 if (string.IsNullOrEmpty(_Address))
                   {
                        Alert("[ 联系地址 ]不能为空");
                        return;
                  }
				                                           
                  var _NeedMenberCount = Request.Form["TextBox_NeedMenberCount"];
                 if (string.IsNullOrEmpty(_NeedMenberCount))
                   {
                        Alert("[ 人员数量 ]不能为空");
                        return;
                  }
				                                           
                  var _BeginTime = Request.Form["TextBox_BeginTime"];
                 if (string.IsNullOrEmpty(_BeginTime))
                   {
                        Alert("[ 活动日期 ]不能为空");
                        return;
                  }
				                                           
                  var _Detail = Request.Form["TextBox_Detail"];
                 if (string.IsNullOrEmpty(_Detail))
                   {
                        Alert("[ 活动明细 ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 当前状态 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            WG_ActivitiesEntity  _WG_ActivitiesEntity = new WG_ActivitiesEntity();
            
               		                               	  		                            
                 	                 	                
                    _WG_ActivitiesEntity.Title =Convert.ToString(_Title.ToString());
               		                        	  		                            
                 	                 	                     _WG_ActivitiesEntity.PromoterID =Convert.ToInt32(_PromoterID.ToString());
                	                        	  		                            
                 	                 	                     _WG_ActivitiesEntity.LinkManID =Convert.ToInt32(_LinkManID.ToString());
                	                        	  		                            
                 	                 	                     _WG_ActivitiesEntity.ActivityTypeID =Convert.ToInt32(_ActivityTypeID.ToString());
                	                        	  		                            
                 	                 	                     _WG_ActivitiesEntity.RegionID =Convert.ToInt32(_RegionID.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_ActivitiesEntity.Address =Convert.ToString(_Address.ToString());
               		                        	  		                            
                 	                 	                     _WG_ActivitiesEntity.NeedMenberCount =Convert.ToInt32(_NeedMenberCount.ToString());
                	                        	  		                            
                 	                      _WG_ActivitiesEntity.BeginTime = Convert.ToDateTime(_BeginTime.ToString());
                 	                        	  		                            
                 	                 	                
                    _WG_ActivitiesEntity.Detail =Convert.ToString(_Detail.ToString());
               		                        	  		                            
                 	                 	                     _WG_ActivitiesEntity.Status =Convert.ToInt32(_Status.ToString());
                	                        	  		        
		       	_WG_ActivitiesEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_WG_ActivitiesEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_Activities(_WG_ActivitiesEntity);
            }
            catch
            {
                WriteLog("WG_ActivitiesAdd", "添加WG_Activities", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Activities成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_ActivitiesEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 活动标题 ]不能为空");
                        return;
                  }
				                                           
                  var _PromoterID = Request.Form["TextBox_PromoterID"];
                 if (string.IsNullOrEmpty(_PromoterID))
                   {
                        Alert("[ 发起人ID ]不能为空");
                        return;
                  }
				                                           
                  var _LinkManID = Request.Form["TextBox_LinkManID"];
                 if (string.IsNullOrEmpty(_LinkManID))
                   {
                        Alert("[ 联系人ID ]不能为空");
                        return;
                  }
				                                           
                  var _ActivityTypeID = Request.Form["TextBox_ActivityTypeID"];
                 if (string.IsNullOrEmpty(_ActivityTypeID))
                   {
                        Alert("[ 活动类型ID ]不能为空");
                        return;
                  }
				                                           
                  var _RegionID = Request.Form["TextBox_RegionID"];
                 if (string.IsNullOrEmpty(_RegionID))
                   {
                        Alert("[ 区域ID ]不能为空");
                        return;
                  }
				                                           
                  var _Address = Request.Form["TextBox_Address"];
                 if (string.IsNullOrEmpty(_Address))
                   {
                        Alert("[ 联系地址 ]不能为空");
                        return;
                  }
				                                           
                  var _NeedMenberCount = Request.Form["TextBox_NeedMenberCount"];
                 if (string.IsNullOrEmpty(_NeedMenberCount))
                   {
                        Alert("[ 人员数量 ]不能为空");
                        return;
                  }
				                                           
                  var _BeginTime = Request.Form["TextBox_BeginTime"];
                 if (string.IsNullOrEmpty(_BeginTime))
                   {
                        Alert("[ 活动日期 ]不能为空");
                        return;
                  }
				                                           
                  var _Detail = Request.Form["TextBox_Detail"];
                 if (string.IsNullOrEmpty(_Detail))
                   {
                        Alert("[ 活动明细 ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 当前状态 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion


             
  
               		                       					                         
                
                                                                   
                    _WG_ActivitiesEntity.Title =Convert.ToString(_Title.ToString());
                               					                         
                
                                                                        _WG_ActivitiesEntity.PromoterID =Convert.ToInt32(_PromoterID.ToString());
                                					                         
                
                                                                        _WG_ActivitiesEntity.LinkManID =Convert.ToInt32(_LinkManID.ToString());
                                					                         
                
                                                                        _WG_ActivitiesEntity.ActivityTypeID =Convert.ToInt32(_ActivityTypeID.ToString());
                                					                         
                
                                                                        _WG_ActivitiesEntity.RegionID =Convert.ToInt32(_RegionID.ToString());
                                					                         
                
                                                                   
                    _WG_ActivitiesEntity.Address =Convert.ToString(_Address.ToString());
                               					                         
                
                                                                        _WG_ActivitiesEntity.NeedMenberCount =Convert.ToInt32(_NeedMenberCount.ToString());
                                					                         
                
                                                        _WG_ActivitiesEntity.BeginTime = Convert.ToDateTime(_BeginTime.ToString());
                                 					                         
                
                                                                   
                    _WG_ActivitiesEntity.Detail =Convert.ToString(_Detail.ToString());
                               					                         
                
                                                                        _WG_ActivitiesEntity.Status =Convert.ToInt32(_Status.ToString());
                                					                       					        
		       	_WG_ActivitiesEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateWG_Activities(_WG_ActivitiesEntity);
            }
            catch
            {
                WriteLog("WG_ActivitiesEditFunc", "编辑WG_Activities", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Activities资料成功","");
        }
        #endregion
    }
}