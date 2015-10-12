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
    public partial class WG_ScoreEdit : BaseForm
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
                WG_ScoreAdd();
            }
            else
            {
                WG_ScoreEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_ScoreEntity _WG_ScoreEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_ScoreEntity = DataProvider.GetInstance().GetWG_ScoreEntity(int.Parse(ctrID));

               				                				                   TextBox_MenberID.Text = _WG_ScoreEntity.MenberID.ToString();
                                				                   TextBox_Scores.Text = _WG_ScoreEntity.Scores.ToString();
                                				                   TextBox_Title.Text = _WG_ScoreEntity.Title.ToString();
                                				                            }
        }
        #endregion

        #region 新增
        protected void WG_ScoreAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _MenberID = Request.Form["TextBox_MenberID"];
                 if (string.IsNullOrEmpty(_MenberID))
                   {
                        Alert("[ 会员ID ]不能为空");
                        return;
                  }
				                                           
                  var _Scores = Request.Form["TextBox_Scores"];
                 if (string.IsNullOrEmpty(_Scores))
                   {
                        Alert("[ 积分数 ]不能为空");
                        return;
                  }
				                                           
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 积分说明 ]不能为空");
                        return;
                  }
				                                                
	        #endregion
           
            #region 获取数据

            WG_ScoreEntity  _WG_ScoreEntity = new WG_ScoreEntity();
            
               		                               	  		                            
                 	                 	                     _WG_ScoreEntity.MenberID =Convert.ToInt32(_MenberID.ToString());
                	                        	  		                            
                 	                 	                     _WG_ScoreEntity.Scores =Convert.ToInt32(_Scores.ToString());
                	                        	  		                            
                 	                 	                
                    _WG_ScoreEntity.Title =Convert.ToString(_Title.ToString());
               		                        	  		        
		       	_WG_ScoreEntity.CreateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddWG_Score(_WG_ScoreEntity);
            }
            catch
            {
                WriteLog("WG_ScoreAdd", "添加WG_Score", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Score成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void WG_ScoreEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _MenberID = Request.Form["TextBox_MenberID"];
                 if (string.IsNullOrEmpty(_MenberID))
                   {
                        Alert("[ 会员ID ]不能为空");
                        return;
                  }
				                                           
                  var _Scores = Request.Form["TextBox_Scores"];
                 if (string.IsNullOrEmpty(_Scores))
                   {
                        Alert("[ 积分数 ]不能为空");
                        return;
                  }
				                                           
                  var _Title = Request.Form["TextBox_Title"];
                 if (string.IsNullOrEmpty(_Title))
                   {
                        Alert("[ 积分说明 ]不能为空");
                        return;
                  }
				                                                
	        #endregion


             
  
               		                       					                         
                
                                                                        _WG_ScoreEntity.MenberID =Convert.ToInt32(_MenberID.ToString());
                                					                         
                
                                                                        _WG_ScoreEntity.Scores =Convert.ToInt32(_Scores.ToString());
                                					                         
                
                                                                   
                    _WG_ScoreEntity.Title =Convert.ToString(_Title.ToString());
                               					                       			            try
            {
                DataProvider.GetInstance().UpdateWG_Score(_WG_ScoreEntity);
            }
            catch
            {
                WriteLog("WG_ScoreEditFunc", "编辑WG_Score", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Score资料成功","");
        }
        #endregion
    }
}