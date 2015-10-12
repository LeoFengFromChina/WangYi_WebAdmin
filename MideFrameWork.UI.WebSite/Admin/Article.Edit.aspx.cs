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
    public partial class ArticleEdit : BaseForm
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
                ArticleAdd();
            }
            else
            {
                ArticleEditFunc(ctrID);
            }
        }

        #region 初始化表单
        ArticleEntity _ArticleEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _ArticleEntity = DataProvider.GetInstance().GetArticleEntity(int.Parse(ctrID));

               				                				                   TextBox_TitleCN.Text = _ArticleEntity.TitleCN.ToString();
                                				                   TextBox_TitleEN.Text = _ArticleEntity.TitleEN.ToString();
                                				                   TextBox_TypeID.Text = _ArticleEntity.TypeID.ToString();
                                				                   TextBox_Context.Text = _ArticleEntity.Context.ToString();
                                				                   TextBox_Template.Text = _ArticleEntity.Template.ToString();
                                				                   TextBox_IconUrl.Text = _ArticleEntity.IconUrl.ToString();
                                				                   TextBox_Attachment.Text = _ArticleEntity.Attachment.ToString();
                                				                   TextBox_IsEnable.Text = _ArticleEntity.IsEnable.ToString();
                                				                   TextBox_DisplayIndex.Text = _ArticleEntity.DisplayIndex.ToString();
                                				                   TextBox_OwnerID.Text = _ArticleEntity.OwnerID.ToString();
                                				                				                            }
        }
        #endregion

        #region 新增
        protected void ArticleAdd()
        {
            #region 判断是否可空
		 
                                                                          
                  var _TitleCN = Request.Form["TextBox_TitleCN"];
                 if (string.IsNullOrEmpty(_TitleCN))
                   {
                        Alert("[ 中文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _TitleEN = Request.Form["TextBox_TitleEN"];
                 if (string.IsNullOrEmpty(_TitleEN))
                   {
                        Alert("[ 英文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _TypeID = Request.Form["TextBox_TypeID"];
                 if (string.IsNullOrEmpty(_TypeID))
                   {
                        Alert("[ 类别ID ]不能为空");
                        return;
                  }
				                                           
                  var _Context = Request.Form["TextBox_Context"];
                 if (string.IsNullOrEmpty(_Context))
                   {
                        Alert("[ 正文 ]不能为空");
                        return;
                  }
				                                           
                  var _Template = Request.Form["TextBox_Template"];
                 if (string.IsNullOrEmpty(_Template))
                   {
                        Alert("[ 模板 ]不能为空");
                        return;
                  }
				                                           
                  var _IconUrl = Request.Form["TextBox_IconUrl"];
                 if (string.IsNullOrEmpty(_IconUrl))
                   {
                        Alert("[ 图标地址 ]不能为空");
                        return;
                  }
				                                           
                  var _Attachment = Request.Form["TextBox_Attachment"];
                 if (string.IsNullOrEmpty(_Attachment))
                   {
                        Alert("[ 附件 ]不能为空");
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
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 所属者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
           
            #region 获取数据

            ArticleEntity  _ArticleEntity = new ArticleEntity();
            
               		                               	  		                            
                 	                 	                
                    _ArticleEntity.TitleCN =Convert.ToString(_TitleCN.ToString());
               		                        	  		                            
                 	                 	                
                    _ArticleEntity.TitleEN =Convert.ToString(_TitleEN.ToString());
               		                        	  		                            
                 	                 	                     _ArticleEntity.TypeID =Convert.ToInt32(_TypeID.ToString());
                	                        	  		                            
                 	                 	                
                    _ArticleEntity.Context =Convert.ToString(_Context.ToString());
               		                        	  		                            
                 	                 	                
                    _ArticleEntity.Template =Convert.ToString(_Template.ToString());
               		                        	  		                            
                 	                 	                
                    _ArticleEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
               		                        	  		                            
                 	                 	                
                    _ArticleEntity.Attachment =Convert.ToString(_Attachment.ToString());
               		                        	  		                            
                 	                 	                     _ArticleEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                	                        	  		                            
                 	                 	                     _ArticleEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                	                        	  		                            
                 	                 	                     _ArticleEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                	                        	  		        
		       	_ArticleEntity.CreateDate =DateTime.Now;
		               	  		        
		       	_ArticleEntity.UpdateDate =DateTime.Now;
		               	              try
            {
                DataProvider.GetInstance().AddArticle(_ArticleEntity);
            }
            catch
            {
                WriteLog("ArticleAdd", "添加Article", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加Article成功");
        }
        #endregion
        #endregion
        #region 编辑
        protected void ArticleEditFunc(string ctrID)
        {
            #region 判断是否可空		 
		 
                                                                          
                  var _TitleCN = Request.Form["TextBox_TitleCN"];
                 if (string.IsNullOrEmpty(_TitleCN))
                   {
                        Alert("[ 中文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _TitleEN = Request.Form["TextBox_TitleEN"];
                 if (string.IsNullOrEmpty(_TitleEN))
                   {
                        Alert("[ 英文标题 ]不能为空");
                        return;
                  }
				                                           
                  var _TypeID = Request.Form["TextBox_TypeID"];
                 if (string.IsNullOrEmpty(_TypeID))
                   {
                        Alert("[ 类别ID ]不能为空");
                        return;
                  }
				                                           
                  var _Context = Request.Form["TextBox_Context"];
                 if (string.IsNullOrEmpty(_Context))
                   {
                        Alert("[ 正文 ]不能为空");
                        return;
                  }
				                                           
                  var _Template = Request.Form["TextBox_Template"];
                 if (string.IsNullOrEmpty(_Template))
                   {
                        Alert("[ 模板 ]不能为空");
                        return;
                  }
				                                           
                  var _IconUrl = Request.Form["TextBox_IconUrl"];
                 if (string.IsNullOrEmpty(_IconUrl))
                   {
                        Alert("[ 图标地址 ]不能为空");
                        return;
                  }
				                                           
                  var _Attachment = Request.Form["TextBox_Attachment"];
                 if (string.IsNullOrEmpty(_Attachment))
                   {
                        Alert("[ 附件 ]不能为空");
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
				                                           
                  var _OwnerID = Request.Form["TextBox_OwnerID"];
                 if (string.IsNullOrEmpty(_OwnerID))
                   {
                        Alert("[ 所属者ID ]不能为空");
                        return;
                  }
				                                                                                
	        #endregion
	        
               		                       					                         
                
                                                                   
                    _ArticleEntity.TitleCN =Convert.ToString(_TitleCN.ToString());
                               					                         
                
                                                                   
                    _ArticleEntity.TitleEN =Convert.ToString(_TitleEN.ToString());
                               					                         
                
                                                                        _ArticleEntity.TypeID =Convert.ToInt32(_TypeID.ToString());
                                					                         
                
                                                                   
                    _ArticleEntity.Context =Convert.ToString(_Context.ToString());
                               					                         
                
                                                                   
                    _ArticleEntity.Template =Convert.ToString(_Template.ToString());
                               					                         
                
                                                                   
                    _ArticleEntity.IconUrl =Convert.ToString(_IconUrl.ToString());
                               					                         
                
                                                                   
                    _ArticleEntity.Attachment =Convert.ToString(_Attachment.ToString());
                               					                         
                
                                                                        _ArticleEntity.IsEnable =Convert.ToInt32(_IsEnable.ToString());
                                					                         
                
                                                                        _ArticleEntity.DisplayIndex =Convert.ToInt32(_DisplayIndex.ToString());
                                					                         
                
                                                                        _ArticleEntity.OwnerID =Convert.ToInt32(_OwnerID.ToString());
                                					                       					        
		       	_ArticleEntity.UpdateDate =DateTime.Now;
		       			            try
            {
                DataProvider.GetInstance().UpdateArticle(_ArticleEntity);
            }
            catch
            {
                WriteLog("ArticleEditFunc", "编辑Article", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新Article资料成功","");
        }
        #endregion
    }
}