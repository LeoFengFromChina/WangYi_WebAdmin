

using System; 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic; 

using MideFrameWork.Common.DBUtility;
using MideFrameWork.Data.Interface;
using MideFrameWork.Data.Entity;

namespace MideFrameWork.Data.SqlServer
{
	/// <summary>
	/// 数据访问实现类：WebSiteManagement
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WebSiteManagementExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM WebSiteManagement");
			strSql.Append(" where ID=@ID");
			
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			                        
						parameters[0].Value = ID;
			
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int AddWebSiteManagement(MideFrameWork.Data.Entity.WebSiteManagementEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WebSiteManagement(");			
            strSql.Append("WebSiteName,MetaKeywords,MetaDescriptions,AdvPopupScript,OwnerID,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@WebSiteName,@MetaKeywords,@MetaDescriptions,@AdvPopupScript,@OwnerID,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@WebSiteName", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@MetaKeywords", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@MetaDescriptions", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@AdvPopupScript", SqlDbType.NVarChar) ,            
                        new SqlParameter("@OwnerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.WebSiteName;                        
            parameters[1].Value = info.MetaKeywords;                        
            parameters[2].Value = info.MetaDescriptions;                        
            parameters[3].Value = info.AdvPopupScript;                        
            parameters[4].Value = info.OwnerID;                        
            parameters[5].Value = info.CreateDate;                        
            parameters[6].Value = info.UpdateDate;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}			   
            			
		}
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateWebSiteManagement(MideFrameWork.Data.Entity.WebSiteManagementEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WebSiteManagement set ");
			                                                
            strSql.Append(" WebSiteName = @WebSiteName , ");                                    
            strSql.Append(" MetaKeywords = @MetaKeywords , ");                                    
            strSql.Append(" MetaDescriptions = @MetaDescriptions , ");                                    
            strSql.Append(" AdvPopupScript = @AdvPopupScript , ");                                    
            strSql.Append(" OwnerID = @OwnerID , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@WebSiteName", SqlDbType.NVarChar,256) ,                        new SqlParameter("@MetaKeywords", SqlDbType.NVarChar,256) ,                        new SqlParameter("@MetaDescriptions", SqlDbType.NVarChar,256) ,                        new SqlParameter("@AdvPopupScript", SqlDbType.NVarChar) ,                        new SqlParameter("@OwnerID", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.WebSiteName;                        
            parameters[2].Value = info.MetaKeywords;                        
            parameters[3].Value = info.MetaDescriptions;                        
            parameters[4].Value = info.AdvPopupScript;                        
            parameters[5].Value = info.OwnerID;                        
            parameters[6].Value = info.CreateDate;                        
            parameters[7].Value = info.UpdateDate;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteWebSiteManagement(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete FROM WebSiteManagement ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			
						parameters[0].Value = ID;
			
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteWebSiteManagementList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete FROM WebSiteManagement ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MideFrameWork.Data.Entity.WebSiteManagementEntity GetWebSiteManagementEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, WebSiteName, MetaKeywords, MetaDescriptions, AdvPopupScript, OwnerID, CreateDate, UpdateDate  ");			
			strSql.Append("  FROM WebSiteManagement ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.WebSiteManagementEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetWebSiteManagement(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WebSiteManagementEntity> GetWebSiteManagementList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,WebSiteName,MetaKeywords,MetaDescriptions,AdvPopupScript,OwnerID,CreateDate,UpdateDate");
			strSql.Append(" FROM WebSiteManagement ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.WebSiteManagementEntity> list = new List<MideFrameWork.Data.Entity.WebSiteManagementEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWebSiteManagement(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WebSiteManagementEntity> GetWebSiteManagementList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,WebSiteName,MetaKeywords,MetaDescriptions,AdvPopupScript,OwnerID,CreateDate,UpdateDate");
			strSql.Append(" FROM WebSiteManagement ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.WebSiteManagementEntity> list = new List<MideFrameWork.Data.Entity.WebSiteManagementEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWebSiteManagement(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize">每页的行数</param>
        /// <param name="PageNumber">要显示的页码, 从1开始</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">返回总记录数</param>
        /// <returns></returns>
        public IList<WebSiteManagementEntity> GetWebSiteManagementList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.WebSiteManagementEntity> list = new List<MideFrameWork.Data.Entity.WebSiteManagementEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage("WebSiteManagement", "ID,WebSiteName,MetaKeywords,MetaDescriptions,AdvPopupScript,OwnerID,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetWebSiteManagement(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.WebSiteManagementEntity GetWebSiteManagement(DataRow dr)
        {
            MideFrameWork.Data.Entity.WebSiteManagementEntity info = new MideFrameWork.Data.Entity.WebSiteManagementEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["WebSiteName"])
				info.WebSiteName= string.Empty;
			else	
				info.WebSiteName= dr["WebSiteName"].ToString();
																								
						if(DBNull.Value==dr["MetaKeywords"])
				info.MetaKeywords= string.Empty;
			else	
				info.MetaKeywords= dr["MetaKeywords"].ToString();
																								
						if(DBNull.Value==dr["MetaDescriptions"])
				info.MetaDescriptions= string.Empty;
			else	
				info.MetaDescriptions= dr["MetaDescriptions"].ToString();
																								
						if(DBNull.Value==dr["AdvPopupScript"])
				info.AdvPopupScript= string.Empty;
			else	
				info.AdvPopupScript= dr["AdvPopupScript"].ToString();
																						if(DBNull.Value==dr["OwnerID"])
					info.OwnerID=0;
				else
					info.OwnerID=int.Parse(dr["OwnerID"].ToString());
									
																									if(DBNull.Value==dr["CreateDate"])
					info.CreateDate=DateTime.Now;
				else
					info.CreateDate=DateTime.Parse(dr["CreateDate"].ToString());
						
																									if(DBNull.Value==dr["UpdateDate"])
					info.UpdateDate=DateTime.Now;
				else
					info.UpdateDate=DateTime.Parse(dr["UpdateDate"].ToString());
						
															            return info;
        }
	}
}

