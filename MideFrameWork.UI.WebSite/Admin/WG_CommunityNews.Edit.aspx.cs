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
    public partial class WG_CommunityNewsEdit : BaseForm
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
                WG_CommunityNewsAdd();
            }
            else
            {
                WG_CommunityNewsEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_CommunityNewsEntity _WG_CommunityNewsEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_CommunityNewsEntity = DataProvider.GetInstance().GetWG_CommunityNewsEntity(int.Parse(ctrID));

               				                				                   TextBox_Title.Text = _WG_CommunityNewsEntity.Title.ToString();
                                				                   TextBox_Contents.Text = _WG_CommunityNewsEntity.Contents.ToString();
                                				                   TextBox_UpCount.Text = _WG_CommunityNewsEntity.UpCount.ToString();
                                				                   TextBox_Memo.Text = _WG_CommunityNewsEntity.Memo.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void WG_CommunityNewsAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 标题 ]不能为空");
                        return;
                  }
				                                           
                  var _Contents = Request.Form["TextBox_Contents"];
                 if (string.IsNullOrEmpty(_Contents))
                   {
                        Alert("[ 正文 ]不能为空");
                        return;
                  }
				                                           
                  var _UpCount = Request.Form["TextBox_UpCount"];
                 if (string.IsNullOrEmpty(_UpCount))
                   {
                        Alert("[ 顶次数 ]不能为空");
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

            WG_CommunityNewsEntity  _WG_CommunityNewsEntity = new WG_CommunityNewsEntity();
            
               		                               	  		                            
                 	                 	                
                    _WG_CommunityNewsEntity.Title =Convert.ToString(_Title.ToString());
               		                        	  		                            
                 	                 	                
                    _WG_CommunityNewsEntity.Contents =Convert.ToString(_Contents.ToString());
               		                        	  		                            
                 	                 	                     _WG_CommunityNewsEntity.UpCount =Convert.ToInt32(_UpCount.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_CommunityNewsEntity.Memo =Convert.ToString(_Memo.ToString());
               		                        	  		        
		       	_WG_CommunityNewsEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_CommunityNews(_WG_CommunityNewsEntity);
            }
            catch
            {
                WriteLog("WG_CommunityNewsAdd", "添加WG_CommunityNews", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_CommunityNews成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_CommunityNewsEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 标题 ]不能为空");
                        return;
                  }
				                                           
                  var _Contents = Request.Form["TextBox_Contents"];
                 if (string.IsNullOrEmpty(_Contents))
                   {
                        Alert("[ 正文 ]不能为空");
                        return;
                  }
				                                           
                  var _UpCount = Request.Form["TextBox_UpCount"];
                 if (string.IsNullOrEmpty(_UpCount))
                   {
                        Alert("[ 顶次数 ]不能为空");
                        return;
                  }
				                                           
                  var _Memo = Request.Form["TextBox_Memo"];
                 if (string.IsNullOrEmpty(_Memo))
                   {
                        Alert("[ 备注 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _WG_CommunityNewsEntity.Title =Convert.ToString(_Title.ToString());
                               					                         
                
                                                                   
                    _WG_CommunityNewsEntity.Contents =Convert.ToString(_Contents.ToString());
                               					                         
                
                                                                        _WG_CommunityNewsEntity.UpCount =Convert.ToInt32(_UpCount.ToString());
                                					                         
                
                                                                   
                    _WG_CommunityNewsEntity.Memo =Convert.ToString(_Memo.ToString());
                               					                       			            try
            {
                DataProvider.GetInstance().UpdateWG_CommunityNews(_WG_CommunityNewsEntity);
            }
            catch
            {
                WriteLog("WG_CommunityNewsEditFunc", "编辑WG_CommunityNews", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_CommunityNews资料成功","");
        }
        #endregion
    }
}