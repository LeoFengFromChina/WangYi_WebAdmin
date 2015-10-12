

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
	/// 数据访问实现类：Article
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ArticleExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Article");
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
		public int AddArticle(MideFrameWork.Data.Entity.ArticleEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Article(");			
            strSql.Append("TitleCN,TitleEN,TypeID,Context,Template,IconUrl,Attachment,IsEnable,DisplayIndex,CreateDate,UpdateDate,OwnerID");
			strSql.Append(") values (");
            strSql.Append("@TitleCN,@TitleEN,@TypeID,@Context,@Template,@IconUrl,@Attachment,@IsEnable,@DisplayIndex,@CreateDate,@UpdateDate,@OwnerID");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@TitleCN", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@TitleEN", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@TypeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Context", SqlDbType.NVarChar) ,            
                        new SqlParameter("@Template", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@IconUrl", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Attachment", SqlDbType.NVarChar) ,            
                        new SqlParameter("@IsEnable", SqlDbType.Int,4) ,            
                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@OwnerID", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = info.TitleCN;                        
            parameters[1].Value = info.TitleEN;                        
            parameters[2].Value = info.TypeID;                        
            parameters[3].Value = info.Context;                        
            parameters[4].Value = info.Template;                        
            parameters[5].Value = info.IconUrl;                        
            parameters[6].Value = info.Attachment;                        
            parameters[7].Value = info.IsEnable;                        
            parameters[8].Value = info.DisplayIndex;                        
            parameters[9].Value = info.CreateDate;                        
            parameters[10].Value = info.UpdateDate;                        
            parameters[11].Value = info.OwnerID;                        
			   
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
		public bool UpdateArticle(MideFrameWork.Data.Entity.ArticleEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Article set ");
			                                                
            strSql.Append(" TitleCN = @TitleCN , ");                                    
            strSql.Append(" TitleEN = @TitleEN , ");                                    
            strSql.Append(" TypeID = @TypeID , ");                                    
            strSql.Append(" Context = @Context , ");                                    
            strSql.Append(" Template = @Template , ");                                    
            strSql.Append(" IconUrl = @IconUrl , ");                                    
            strSql.Append(" Attachment = @Attachment , ");                                    
            strSql.Append(" IsEnable = @IsEnable , ");                                    
            strSql.Append(" DisplayIndex = @DisplayIndex , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate , ");                                    
            strSql.Append(" OwnerID = @OwnerID  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@TitleCN", SqlDbType.NVarChar,64) ,                        new SqlParameter("@TitleEN", SqlDbType.NVarChar,128) ,                        new SqlParameter("@TypeID", SqlDbType.Int,4) ,                        new SqlParameter("@Context", SqlDbType.NVarChar) ,                        new SqlParameter("@Template", SqlDbType.NVarChar,256) ,                        new SqlParameter("@IconUrl", SqlDbType.NVarChar,256) ,                        new SqlParameter("@Attachment", SqlDbType.NVarChar) ,                        new SqlParameter("@IsEnable", SqlDbType.Int,4) ,                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime) ,                        new SqlParameter("@OwnerID", SqlDbType.Int,4)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.TitleCN;                        
            parameters[2].Value = info.TitleEN;                        
            parameters[3].Value = info.TypeID;                        
            parameters[4].Value = info.Context;                        
            parameters[5].Value = info.Template;                        
            parameters[6].Value = info.IconUrl;                        
            parameters[7].Value = info.Attachment;                        
            parameters[8].Value = info.IsEnable;                        
            parameters[9].Value = info.DisplayIndex;                        
            parameters[10].Value = info.CreateDate;                        
            parameters[11].Value = info.UpdateDate;                        
            parameters[12].Value = info.OwnerID;                        
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
		public bool DeleteArticle(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete FROM Article ");
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
		public bool DeleteArticleList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete FROM Article ");
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
		public MideFrameWork.Data.Entity.ArticleEntity GetArticleEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, TitleCN, TitleEN, TypeID, Context, Template, IconUrl, Attachment, IsEnable, DisplayIndex, CreateDate, UpdateDate, OwnerID  ");			
			strSql.Append("  FROM Article ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.ArticleEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetArticle(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.ArticleEntity> GetArticleList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,TitleCN,TitleEN,TypeID,Context,Template,IconUrl,Attachment,IsEnable,DisplayIndex,CreateDate,UpdateDate,OwnerID");
			strSql.Append(" FROM Article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.ArticleEntity> list = new List<MideFrameWork.Data.Entity.ArticleEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetArticle(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.ArticleEntity> GetArticleList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,TitleCN,TitleEN,TypeID,Context,Template,IconUrl,Attachment,IsEnable,DisplayIndex,CreateDate,UpdateDate,OwnerID");
			strSql.Append(" FROM Article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.ArticleEntity> list = new List<MideFrameWork.Data.Entity.ArticleEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetArticle(dr));
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
        public IList<ArticleEntity> GetArticleList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.ArticleEntity> list = new List<MideFrameWork.Data.Entity.ArticleEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage("Article", "ID,TitleCN,TitleEN,TypeID,Context,Template,IconUrl,Attachment,IsEnable,DisplayIndex,CreateDate,UpdateDate,OwnerID", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetArticle(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.ArticleEntity GetArticle(DataRow dr)
        {
            MideFrameWork.Data.Entity.ArticleEntity info = new MideFrameWork.Data.Entity.ArticleEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["TitleCN"])
				info.TitleCN= string.Empty;
			else	
				info.TitleCN= dr["TitleCN"].ToString();
																								
						if(DBNull.Value==dr["TitleEN"])
				info.TitleEN= string.Empty;
			else	
				info.TitleEN= dr["TitleEN"].ToString();
																						if(DBNull.Value==dr["TypeID"])
					info.TypeID=0;
				else
					info.TypeID=int.Parse(dr["TypeID"].ToString());
									
																								
						if(DBNull.Value==dr["Context"])
				info.Context= string.Empty;
			else	
				info.Context= dr["Context"].ToString();
																								
						if(DBNull.Value==dr["Template"])
				info.Template= string.Empty;
			else	
				info.Template= dr["Template"].ToString();
																								
						if(DBNull.Value==dr["IconUrl"])
				info.IconUrl= string.Empty;
			else	
				info.IconUrl= dr["IconUrl"].ToString();
																								
						if(DBNull.Value==dr["Attachment"])
				info.Attachment= string.Empty;
			else	
				info.Attachment= dr["Attachment"].ToString();
																						if(DBNull.Value==dr["IsEnable"])
					info.IsEnable=0;
				else
					info.IsEnable=int.Parse(dr["IsEnable"].ToString());
									
																						if(DBNull.Value==dr["DisplayIndex"])
					info.DisplayIndex=0;
				else
					info.DisplayIndex=int.Parse(dr["DisplayIndex"].ToString());
									
																									if(DBNull.Value==dr["CreateDate"])
					info.CreateDate=DateTime.Now;
				else
					info.CreateDate=DateTime.Parse(dr["CreateDate"].ToString());
						
																									if(DBNull.Value==dr["UpdateDate"])
					info.UpdateDate=DateTime.Now;
				else
					info.UpdateDate=DateTime.Parse(dr["UpdateDate"].ToString());
						
																						if(DBNull.Value==dr["OwnerID"])
					info.OwnerID=0;
				else
					info.OwnerID=int.Parse(dr["OwnerID"].ToString());
									
															            return info;
        }
	}
}

