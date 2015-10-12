

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
	/// 数据访问实现类：ArticleType
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ArticleTypeExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ArticleType");
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
		public int AddArticleType(MideFrameWork.Data.Entity.ArticleTypeEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ArticleType(");			
            strSql.Append("TypeNameCN,TypeNameEN,IconUrl,LinkUrl,IsEnable,DisplayIndex,ParentID,OwerID,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@TypeNameCN,@TypeNameEN,@IconUrl,@LinkUrl,@IsEnable,@DisplayIndex,@ParentID,@OwerID,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@TypeNameCN", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@TypeNameEN", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@IconUrl", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@IsEnable", SqlDbType.Int,4) ,            
                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@OwerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.TypeNameCN;                        
            parameters[1].Value = info.TypeNameEN;                        
            parameters[2].Value = info.IconUrl;                        
            parameters[3].Value = info.LinkUrl;                        
            parameters[4].Value = info.IsEnable;                        
            parameters[5].Value = info.DisplayIndex;                        
            parameters[6].Value = info.ParentID;                        
            parameters[7].Value = info.OwerID;                        
            parameters[8].Value = info.CreateDate;                        
            parameters[9].Value = info.UpdateDate;                        
			   
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
		public bool UpdateArticleType(MideFrameWork.Data.Entity.ArticleTypeEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArticleType set ");
			                                                
            strSql.Append(" TypeNameCN = @TypeNameCN , ");                                    
            strSql.Append(" TypeNameEN = @TypeNameEN , ");                                    
            strSql.Append(" IconUrl = @IconUrl , ");                                    
            strSql.Append(" LinkUrl = @LinkUrl , ");                                    
            strSql.Append(" IsEnable = @IsEnable , ");                                    
            strSql.Append(" DisplayIndex = @DisplayIndex , ");                                    
            strSql.Append(" ParentID = @ParentID , ");                                    
            strSql.Append(" OwerID = @OwerID , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@TypeNameCN", SqlDbType.NVarChar,32) ,                        new SqlParameter("@TypeNameEN", SqlDbType.NVarChar,64) ,                        new SqlParameter("@IconUrl", SqlDbType.NVarChar,256) ,                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar,256) ,                        new SqlParameter("@IsEnable", SqlDbType.Int,4) ,                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,                        new SqlParameter("@ParentID", SqlDbType.Int,4) ,                        new SqlParameter("@OwerID", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.TypeNameCN;                        
            parameters[2].Value = info.TypeNameEN;                        
            parameters[3].Value = info.IconUrl;                        
            parameters[4].Value = info.LinkUrl;                        
            parameters[5].Value = info.IsEnable;                        
            parameters[6].Value = info.DisplayIndex;                        
            parameters[7].Value = info.ParentID;                        
            parameters[8].Value = info.OwerID;                        
            parameters[9].Value = info.CreateDate;                        
            parameters[10].Value = info.UpdateDate;                        
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
		public bool DeleteArticleType(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete FROM ArticleType ");
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
		public bool DeleteArticleTypeList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete FROM ArticleType ");
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
		public MideFrameWork.Data.Entity.ArticleTypeEntity GetArticleTypeEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, TypeNameCN, TypeNameEN, IconUrl, LinkUrl, IsEnable, DisplayIndex, ParentID, OwerID, CreateDate, UpdateDate  ");			
			strSql.Append("  FROM ArticleType ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.ArticleTypeEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetArticleType(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.ArticleTypeEntity> GetArticleTypeList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,TypeNameCN,TypeNameEN,IconUrl,LinkUrl,IsEnable,DisplayIndex,ParentID,OwerID,CreateDate,UpdateDate");
			strSql.Append(" FROM ArticleType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.ArticleTypeEntity> list = new List<MideFrameWork.Data.Entity.ArticleTypeEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetArticleType(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.ArticleTypeEntity> GetArticleTypeList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,TypeNameCN,TypeNameEN,IconUrl,LinkUrl,IsEnable,DisplayIndex,ParentID,OwerID,CreateDate,UpdateDate");
			strSql.Append(" FROM ArticleType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.ArticleTypeEntity> list = new List<MideFrameWork.Data.Entity.ArticleTypeEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetArticleType(dr));
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
        public IList<ArticleTypeEntity> GetArticleTypeList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.ArticleTypeEntity> list = new List<MideFrameWork.Data.Entity.ArticleTypeEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage("ArticleType", "ID,TypeNameCN,TypeNameEN,IconUrl,LinkUrl,IsEnable,DisplayIndex,ParentID,OwerID,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetArticleType(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.ArticleTypeEntity GetArticleType(DataRow dr)
        {
            MideFrameWork.Data.Entity.ArticleTypeEntity info = new MideFrameWork.Data.Entity.ArticleTypeEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["TypeNameCN"])
				info.TypeNameCN= string.Empty;
			else	
				info.TypeNameCN= dr["TypeNameCN"].ToString();
																								
						if(DBNull.Value==dr["TypeNameEN"])
				info.TypeNameEN= string.Empty;
			else	
				info.TypeNameEN= dr["TypeNameEN"].ToString();
																								
						if(DBNull.Value==dr["IconUrl"])
				info.IconUrl= string.Empty;
			else	
				info.IconUrl= dr["IconUrl"].ToString();
																								
						if(DBNull.Value==dr["LinkUrl"])
				info.LinkUrl= string.Empty;
			else	
				info.LinkUrl= dr["LinkUrl"].ToString();
																						if(DBNull.Value==dr["IsEnable"])
					info.IsEnable=0;
				else
					info.IsEnable=int.Parse(dr["IsEnable"].ToString());
									
																						if(DBNull.Value==dr["DisplayIndex"])
					info.DisplayIndex=0;
				else
					info.DisplayIndex=int.Parse(dr["DisplayIndex"].ToString());
									
																						if(DBNull.Value==dr["ParentID"])
					info.ParentID=0;
				else
					info.ParentID=int.Parse(dr["ParentID"].ToString());
									
																						if(DBNull.Value==dr["OwerID"])
					info.OwerID=0;
				else
					info.OwerID=int.Parse(dr["OwerID"].ToString());
									
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

