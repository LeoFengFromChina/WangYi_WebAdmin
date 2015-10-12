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
    public partial class ArticleTypeEdit : BaseForm
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
                ArticleTypeAdd();
            }
            else
            {
                ArticleTypeEditFunc(ctrID);
            }
        }

        #region 初始化表单
        ArticleTypeEntity _ArticleTypeEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _ArticleTypeEntity = DataProvider.GetInstance().GetArticleTypeEntity(int.Parse(ctrID));

               				                				                   TextBox_TypeNameCN.Text = _ArticleTypeEntity.TypeNameCN.ToString();
                                				                   TextBox_TypeNameEN.Text = _ArticleTypeEntity.TypeNameEN.ToString();
                                				                   TextBox_IconUrl.Text = _ArticleTypeEntity.IconUrl.ToString();
                                				                   TextBox_LinkUrl.Text = _ArticleTypeEntity.LinkUrl.ToString();
                                				                   TextBox_IsEnable.Text = _ArticleTypeEntity.IsEnable.ToString();
                                				                   TextBox_DisplayIndex.Text = _ArticleTypeEntity.DisplayIndex.ToString();
                                				                   TextBox_ParentID.Text = _ArticleTypeEntity.ParentID.ToString();
                                				                   TextBox_OwerID.Text = _ArticleTypeEntity.OwerID.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void ArticleTypeAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _TypeNameCN = Request.Form["TextBox_TypeNameCN"];
                 if (string.IsNullOrEmpty(_TypeNameCN))
                   {
                        Alert("[ 中文名称 ]不能为空");
                        return;
                  }
				                                           
                  var _TypeNameEN = Request.Form["TextBox_TypeNameEN"];
                 if (string.IsNullOrEmpty(_TypeNameEN))
                   {
                        Alert("[ 英文名称 ]不能为空");
                        return;
                  }
				                                           
                  var _IconUrl = Request.Form["TextBox_IconUrl"];
                 if (string.IsNullOrEmpty(_IconUrl))
                   {
                        Alert("[ 图标路径 ]不能为空");
                        return;
                  }
				                                           
                  var _LinkUrl = Request.Form["TextBox_LinkUrl"];
                 if (string.IsNullOrEmpty(_LinkUrl))
                   {
                        Alert("[ 连接地址 ]不能为空");
                        return;
                  }
				                                           
                  var _IsEnable = Request.Form["TextBox_IsEnable"];
                 if (string.IsNullOrEmpty(_IsEnable))
                   {
                        Alert("[ 是否启用 ]不能为空");
                        return;
                  }
				                                           
                  var _DisplayIndex = Request.Form["TextBox_DisplayIndex"];
                 if (string.IsNullOrEmpty(_DisplayIndex))
                   {
                        Alert("[ 显示顺序 ]不能为空");
                        return;
                  }
				                                           
                  var _ParentID = Request.Form["TextBox_ParentID"];
                 if (string.IsNullOrEmpty(_ParentID))
                   {
                        Alert("[ 父ID ]不能为空");
                        return;
                  }
				                                           
                  var _OwerID = Request.Form["TextBox_OwerID"];
                 if (string.IsNullOrEmpty(_OwerID))
                   {
                        Alert("[ 所属用户ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            ArticleTypeEntity  _ArticleTypeEntity = new ArticleTypeEntity();
            
               		                               	  		                            
                 	                 	                
                    _ArticleTypeEntity.TypeNameCN =Convert.ToString(_TypeNameCN.ToString());
               		                        	  		                            
                 	                 	                
                    _ArticleTypeEntity.TypeNameEN =Convert.ToString(_TypeNameEN.ToString());
               		                        	  		                            
                 	                 	                
                    _ArticleTypeEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
               		                        	  		                            
                 	                 	                
                    _ArticleTypeEntity.LinkUrl =Convert.ToString(_LinkUrl.ToString());
               		                        	  		                            
                 	                 	                     _ArticleTypeEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                	                        	  		                            
                 	                 	                     _ArticleTypeEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                	                        	  		                            
                 	                 	                     _ArticleTypeEntity.ParentID =Convert.ToInt32(_ParentID.ToString());
                	                        	  		                            
                 	                 	                     _ArticleTypeEntity.OwerID =Convert.ToInt32(_OwerID.ToString());
                	                        	  		        
		       	_ArticleTypeEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_ArticleTypeEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddArticleType(_ArticleTypeEntity);
            }
            catch
            {
                WriteLog("ArticleTypeAdd", "添加ArticleType", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加ArticleType成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void ArticleTypeEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _TypeNameCN = Request.Form["TextBox_TypeNameCN"];
                 if (string.IsNullOrEmpty(_TypeNameCN))
                   {
                        Alert("[ 中文名称 ]不能为空");
                        return;
                  }
				                                           
                  var _TypeNameEN = Request.Form["TextBox_TypeNameEN"];
                 if (string.IsNullOrEmpty(_TypeNameEN))
                   {
                        Alert("[ 英文名称 ]不能为空");
                        return;
                  }
				                                           
                  var _IconUrl = Request.Form["TextBox_IconUrl"];
                 if (string.IsNullOrEmpty(_IconUrl))
                   {
                        Alert("[ 图标路径 ]不能为空");
                        return;
                  }
				                                           
                  var _LinkUrl = Request.Form["TextBox_LinkUrl"];
                 if (string.IsNullOrEmpty(_LinkUrl))
                   {
                        Alert("[ 连接地址 ]不能为空");
                        return;
                  }
				                                           
                  var _IsEnable = Request.Form["TextBox_IsEnable"];
                 if (string.IsNullOrEmpty(_IsEnable))
                   {
                        Alert("[ 是否启用 ]不能为空");
                        return;
                  }
				                                           
                  var _DisplayIndex = Request.Form["TextBox_DisplayIndex"];
                 if (string.IsNullOrEmpty(_DisplayIndex))
                   {
                        Alert("[ 显示顺序 ]不能为空");
                        return;
                  }
				                                           
                  var _ParentID = Request.Form["TextBox_ParentID"];
                 if (string.IsNullOrEmpty(_ParentID))
                   {
                        Alert("[ 父ID ]不能为空");
                        return;
                  }
				                                           
                  var _OwerID = Request.Form["TextBox_OwerID"];
                 if (string.IsNullOrEmpty(_OwerID))
                   {
                        Alert("[ 所属用户ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _ArticleTypeEntity.TypeNameCN =Convert.ToString(_TypeNameCN.ToString());
                               					                         
                
                                                                   
                    _ArticleTypeEntity.TypeNameEN =Convert.ToString(_TypeNameEN.ToString());
                               					                         
                
                                                                   
                    _ArticleTypeEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
                               					                         
                
                                                                   
                    _ArticleTypeEntity.LinkUrl =Convert.ToString(_LinkUrl.ToString());
                               					                         
                
                                                                        _ArticleTypeEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                                					                         
                
                                                                        _ArticleTypeEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                                					                         
                
                                                                        _ArticleTypeEntity.ParentID =Convert.ToInt32(_ParentID.ToString());
                                					                         
                
                                                                        _ArticleTypeEntity.OwerID =Convert.ToInt32(_OwerID.ToString());
                                					                       					        
		       	_ArticleTypeEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateArticleType(_ArticleTypeEntity);
            }
            catch
            {
                WriteLog("ArticleTypeEditFunc", "编辑ArticleType", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新ArticleType资料成功","");
        }
        #endregion
    }
}