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
    public partial class WG_HelpRequestEdit : BaseForm
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
                WG_HelpRequestAdd();
            }
            else
            {
                WG_HelpRequestEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_HelpRequestEntity _WG_HelpRequestEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_HelpRequestEntity = DataProvider.GetInstance().GetWG_HelpRequestEntity(int.Parse(ctrID));

               				                				                   TextBox_Title.Text = _WG_HelpRequestEntity.Title.ToString();
                                				                   TextBox_PromoterID.Text = _WG_HelpRequestEntity.PromoterID.ToString();
                                				                   TextBox_LinkMan.Text = _WG_HelpRequestEntity.LinkMan.ToString();
                                				                   TextBox_LinkPhone.Text = _WG_HelpRequestEntity.LinkPhone.ToString();
                                				                   TextBox_BeginTime.Text = _WG_HelpRequestEntity.BeginTime.ToString();
                                				                   TextBox_Region.Text = _WG_HelpRequestEntity.Region.ToString();
                                				                   TextBox_ServiceIntention.Text = _WG_HelpRequestEntity.ServiceIntention.ToString();
                                				                   TextBox_Duration.Text = _WG_HelpRequestEntity.Duration.ToString();
                                				                   TextBox_Detail.Text = _WG_HelpRequestEntity.Detail.ToString();
                                				                   TextBox_UnderTakerID.Text = _WG_HelpRequestEntity.UnderTakerID.ToString();
                                				                   TextBox_Status.Text = _WG_HelpRequestEntity.Status.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void WG_HelpRequestAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 求助标题 ]不能为空");
                        return;
                  }
				                                           
                  var _PromoterID = Request.Form["TextBox_PromoterID"];
                 if (string.IsNullOrEmpty(_PromoterID))
                   {
                        Alert("[ 发起人ID ]不能为空");
                        return;
                  }
				                                           
                  var _LinkMan = Request.Form["TextBox_LinkMan"];
                 if (string.IsNullOrEmpty(_LinkMan))
                   {
                        Alert("[ 联系人 ]不能为空");
                        return;
                  }
				                                           
                  var _LinkPhone = Request.Form["TextBox_LinkPhone"];
                 if (string.IsNullOrEmpty(_LinkPhone))
                   {
                        Alert("[ 联系电话 ]不能为空");
                        return;
                  }
				                                           
                  var _BeginTime = Request.Form["TextBox_BeginTime"];
                 if (string.IsNullOrEmpty(_BeginTime))
                   {
                        Alert("[ 求助日期 ]不能为空");
                        return;
                  }
				                                           
                  var _Region = Request.Form["TextBox_Region"];
                 if (string.IsNullOrEmpty(_Region))
                   {
                        Alert("[ 区域ID ]不能为空");
                        return;
                  }
				                                           
                  var _ServiceIntention = Request.Form["TextBox_ServiceIntention"];
                 if (string.IsNullOrEmpty(_ServiceIntention))
                   {
                        Alert("[ 服务时段 ]不能为空");
                        return;
                  }
				                                           
                  var _Duration = Request.Form["TextBox_Duration"];
                 if (string.IsNullOrEmpty(_Duration))
                   {
                        Alert("[ 服务时长 ]不能为空");
                        return;
                  }
				                                           
                  var _Detail = Request.Form["TextBox_Detail"];
                 if (string.IsNullOrEmpty(_Detail))
                   {
                        Alert("[ 服务明细 ]不能为空");
                        return;
                  }
				                                           
                  var _UnderTakerID = Request.Form["TextBox_UnderTakerID"];
                 if (string.IsNullOrEmpty(_UnderTakerID))
                   {
                        Alert("[ 承接者 ]不能为空");
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

            WG_HelpRequestEntity  _WG_HelpRequestEntity = new WG_HelpRequestEntity();
            
               		                               	  		                            
                 	                 	                
                    _WG_HelpRequestEntity.Title =Convert.ToString(_Title.ToString());
               		                        	  		                            
                 	                 	                     _WG_HelpRequestEntity.PromoterID =Convert.ToInt32(_PromoterID.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_HelpRequestEntity.LinkMan =Convert.ToString(_LinkMan.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_HelpRequestEntity.LinkPhone =Convert.ToString(_LinkPhone.ToString());
               		                        	  		                            
                 	                      _WG_HelpRequestEntity.BeginTime = Convert.ToDateTime(_BeginTime.ToString());
                 	                        	  		                            
                 	                 	                
                    _WG_HelpRequestEntity.Region =Convert.ToString(_Region.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_HelpRequestEntity.ServiceIntention =Convert.ToString(_ServiceIntention.ToString());
               		                        	  		                            
                 	                 	                     _WG_HelpRequestEntity.Duration =Convert.ToInt32(_Duration.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_HelpRequestEntity.Detail =Convert.ToString(_Detail.ToString());
               		                        	  		                            
                 	                 	                     _WG_HelpRequestEntity.UnderTakerID =Convert.ToInt32(_UnderTakerID.ToString());
                	                        	  		                            
                 	                 	                     _WG_HelpRequestEntity.Status =Convert.ToInt32(_Status.ToString());
                	                        	  		        
		       	_WG_HelpRequestEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_WG_HelpRequestEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_HelpRequest(_WG_HelpRequestEntity);
            }
            catch
            {
                WriteLog("WG_HelpRequestAdd", "添加WG_HelpRequest", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_HelpRequest成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_HelpRequestEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 求助标题 ]不能为空");
                        return;
                  }
				                                           
                  var _PromoterID = Request.Form["TextBox_PromoterID"];
                 if (string.IsNullOrEmpty(_PromoterID))
                   {
                        Alert("[ 发起人ID ]不能为空");
                        return;
                  }
				                                           
                  var _LinkMan = Request.Form["TextBox_LinkMan"];
                 if (string.IsNullOrEmpty(_LinkMan))
                   {
                        Alert("[ 联系人 ]不能为空");
                        return;
                  }
				                                           
                  var _LinkPhone = Request.Form["TextBox_LinkPhone"];
                 if (string.IsNullOrEmpty(_LinkPhone))
                   {
                        Alert("[ 联系电话 ]不能为空");
                        return;
                  }
				                                           
                  var _BeginTime = Request.Form["TextBox_BeginTime"];
                 if (string.IsNullOrEmpty(_BeginTime))
                   {
                        Alert("[ 求助日期 ]不能为空");
                        return;
                  }
				                                           
                  var _Region = Request.Form["TextBox_Region"];
                 if (string.IsNullOrEmpty(_Region))
                   {
                        Alert("[ 区域ID ]不能为空");
                        return;
                  }
				                                           
                  var _ServiceIntention = Request.Form["TextBox_ServiceIntention"];
                 if (string.IsNullOrEmpty(_ServiceIntention))
                   {
                        Alert("[ 服务时段 ]不能为空");
                        return;
                  }
				                                           
                  var _Duration = Request.Form["TextBox_Duration"];
                 if (string.IsNullOrEmpty(_Duration))
                   {
                        Alert("[ 服务时长 ]不能为空");
                        return;
                  }
				                                           
                  var _Detail = Request.Form["TextBox_Detail"];
                 if (string.IsNullOrEmpty(_Detail))
                   {
                        Alert("[ 服务明细 ]不能为空");
                        return;
                  }
				                                           
                  var _UnderTakerID = Request.Form["TextBox_UnderTakerID"];
                 if (string.IsNullOrEmpty(_UnderTakerID))
                   {
                        Alert("[ 承接者 ]不能为空");
                        return;
                  }
				                                           
                  var _Status = Request.Form["TextBox_Status"];
                 if (string.IsNullOrEmpty(_Status))
                   {
                        Alert("[ 当前状态 ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _WG_HelpRequestEntity.Title =Convert.ToString(_Title.ToString());
                               					                         
                
                                                                        _WG_HelpRequestEntity.PromoterID =Convert.ToInt32(_PromoterID.ToString());
                                					                         
                
                                                                   
                    _WG_HelpRequestEntity.LinkMan =Convert.ToString(_LinkMan.ToString());
                               					                         
                
                                                                   
                    _WG_HelpRequestEntity.LinkPhone =Convert.ToString(_LinkPhone.ToString());
                               					                         
                
                                                        _WG_HelpRequestEntity.BeginTime = Convert.ToDateTime(_BeginTime.ToString());
                                 					                         
                
                                                                   
                    _WG_HelpRequestEntity.Region =Convert.ToString(_Region.ToString());
                               					                         
                
                                                                   
                    _WG_HelpRequestEntity.ServiceIntention =Convert.ToString(_ServiceIntention.ToString());
                               					                         
                
                                                                        _WG_HelpRequestEntity.Duration =Convert.ToInt32(_Duration.ToString());
                                					                         
                
                                                                   
                    _WG_HelpRequestEntity.Detail =Convert.ToString(_Detail.ToString());
                               					                         
                
                                                                        _WG_HelpRequestEntity.UnderTakerID =Convert.ToInt32(_UnderTakerID.ToString());
                                					                         
                
                                                                        _WG_HelpRequestEntity.Status =Convert.ToInt32(_Status.ToString());
                                					                       					        
		       	_WG_HelpRequestEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateWG_HelpRequest(_WG_HelpRequestEntity);
            }
            catch
            {
                WriteLog("WG_HelpRequestEditFunc", "编辑WG_HelpRequest", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_HelpRequest资料成功","");
        }
        #endregion
    }
}