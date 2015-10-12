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
    public partial class WG_TeamEdit : BaseForm
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
                WG_TeamAdd();
            }
            else
            {
                WG_TeamEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_TeamEntity _WG_TeamEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_TeamEntity = DataProvider.GetInstance().GetWG_TeamEntity(int.Parse(ctrID));

               				                				                   TextBox_Name.Text = _WG_TeamEntity.Name.ToString();
                                				                   TextBox_CaptainID.Text = _WG_TeamEntity.CaptainID.ToString();
                                				                   TextBox_LinkManID.Text = _WG_TeamEntity.LinkManID.ToString();
                                				                   TextBox_TeamAim.Text = _WG_TeamEntity.TeamAim.ToString();
                                				                   TextBox_ServiceIntentionIDs.Text = _WG_TeamEntity.ServiceIntentionIDs.ToString();
                                				                   TextBox_RegionID.Text = _WG_TeamEntity.RegionID.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void WG_TeamAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 团队名称 ]不能为空");
                        return;
                  }
				                                           
                  var _CaptainID = Request.Form["TextBox_CaptainID"];
                 if (string.IsNullOrEmpty(_CaptainID))
                   {
                        Alert("[ 队长ID ]不能为空");
                        return;
                  }
				                                           
                  var _LinkManID = Request.Form["TextBox_LinkManID"];
                 if (string.IsNullOrEmpty(_LinkManID))
                   {
                        Alert("[ 联系人ID ]不能为空");
                        return;
                  }
				                                           
                  var _TeamAim = Request.Form["TextBox_TeamAim"];
                 if (string.IsNullOrEmpty(_TeamAim))
                   {
                        Alert("[ 团队宗旨 ]不能为空");
                        return;
                  }
				                                           
                  var _ServiceIntentionIDs = Request.Form["TextBox_ServiceIntentionIDs"];
                 if (string.IsNullOrEmpty(_ServiceIntentionIDs))
                   {
                        Alert("[ 服务意向IDs ]不能为空");
                        return;
                  }
				                                           
                  var _RegionID = Request.Form["TextBox_RegionID"];
                 if (string.IsNullOrEmpty(_RegionID))
                   {
                        Alert("[ 区域ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            WG_TeamEntity  _WG_TeamEntity = new WG_TeamEntity();
            
               		                               	  		                            
                 	                 	                
                    _WG_TeamEntity.Name =Convert.ToString(_Name.ToString());
               		                        	  		                            
                 	                 	                     _WG_TeamEntity.CaptainID =Convert.ToInt32(_CaptainID.ToString());
                	                        	  		                            
                 	                 	                     _WG_TeamEntity.LinkManID =Convert.ToInt32(_LinkManID.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_TeamEntity.TeamAim =Convert.ToString(_TeamAim.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_TeamEntity.ServiceIntentionIDs =Convert.ToString(_ServiceIntentionIDs.ToString());
               		                        	  		                            
                 	                 	                     _WG_TeamEntity.RegionID =Convert.ToInt32(_RegionID.ToString());
                	                        	  		        
		       	_WG_TeamEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_WG_TeamEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_Team(_WG_TeamEntity);
            }
            catch
            {
                WriteLog("WG_TeamAdd", "添加WG_Team", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Team成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_TeamEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Name = Request.Form["TextBox_Name"];
                 if (string.IsNullOrEmpty(_Name))
                   {
                        Alert("[ 团队名称 ]不能为空");
                        return;
                  }
				                                           
                  var _CaptainID = Request.Form["TextBox_CaptainID"];
                 if (string.IsNullOrEmpty(_CaptainID))
                   {
                        Alert("[ 队长ID ]不能为空");
                        return;
                  }
				                                           
                  var _LinkManID = Request.Form["TextBox_LinkManID"];
                 if (string.IsNullOrEmpty(_LinkManID))
                   {
                        Alert("[ 联系人ID ]不能为空");
                        return;
                  }
				                                           
                  var _TeamAim = Request.Form["TextBox_TeamAim"];
                 if (string.IsNullOrEmpty(_TeamAim))
                   {
                        Alert("[ 团队宗旨 ]不能为空");
                        return;
                  }
				                                           
                  var _ServiceIntentionIDs = Request.Form["TextBox_ServiceIntentionIDs"];
                 if (string.IsNullOrEmpty(_ServiceIntentionIDs))
                   {
                        Alert("[ 服务意向IDs ]不能为空");
                        return;
                  }
				                                           
                  var _RegionID = Request.Form["TextBox_RegionID"];
                 if (string.IsNullOrEmpty(_RegionID))
                   {
                        Alert("[ 区域ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion


             
  
               		                       					                         
                
                                                                   
                    _WG_TeamEntity.Name =Convert.ToString(_Name.ToString());
                               					                         
                
                                                                        _WG_TeamEntity.CaptainID =Convert.ToInt32(_CaptainID.ToString());
                                					                         
                
                                                                        _WG_TeamEntity.LinkManID =Convert.ToInt32(_LinkManID.ToString());
                                					                         
                
                                                                   
                    _WG_TeamEntity.TeamAim =Convert.ToString(_TeamAim.ToString());
                               					                         
                
                                                                   
                    _WG_TeamEntity.ServiceIntentionIDs =Convert.ToString(_ServiceIntentionIDs.ToString());
                               					                         
                
                                                                        _WG_TeamEntity.RegionID =Convert.ToInt32(_RegionID.ToString());
                                					                       					        
		       	_WG_TeamEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateWG_Team(_WG_TeamEntity);
            }
            catch
            {
                WriteLog("WG_TeamEditFunc", "编辑WG_Team", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Team资料成功","");
        }
        #endregion
    }
}