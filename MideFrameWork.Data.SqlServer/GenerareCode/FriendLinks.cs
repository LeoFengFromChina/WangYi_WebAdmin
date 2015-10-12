

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
	/// 数据访问实现类：FriendLinks
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool FriendLinksExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM FriendLinks");
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
		public int AddFriendLinks(MideFrameWork.Data.Entity.FriendLinksEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FriendLinks(");			
            strSql.Append("IconUrl,LinkTextCN,LinkTextEN,LinkUrl,IsEnable,DisplayIndex,OwnerID,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@IconUrl,@LinkTextCN,@LinkTextEN,@LinkUrl,@IsEnable,@DisplayIndex,@OwnerID,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@IconUrl", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@LinkTextCN", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@LinkTextEN", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@IsEnable", SqlDbType.Int,4) ,            
                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@OwnerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.IconUrl;                        
            parameters[1].Value = info.LinkTextCN;                        
            parameters[2].Value = info.LinkTextEN;                        
            parameters[3].Value = info.LinkUrl;                        
            parameters[4].Value = info.IsEnable;                        
            parameters[5].Value = info.DisplayIndex;                        
            parameters[6].Value = info.OwnerID;                        
            parameters[7].Value = info.CreateDate;                        
            parameters[8].Value = info.UpdateDate;                        
			   
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
		public bool UpdateFriendLinks(MideFrameWork.Data.Entity.FriendLinksEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FriendLinks set ");
			                                                
            strSql.Append(" IconUrl = @IconUrl , ");                                    
            strSql.Append(" LinkTextCN = @LinkTextCN , ");                                    
            strSql.Append(" LinkTextEN = @LinkTextEN , ");                                    
            strSql.Append(" LinkUrl = @LinkUrl , ");                                    
            strSql.Append(" IsEnable = @IsEnable , ");                                    
            strSql.Append(" DisplayIndex = @DisplayIndex , ");                                    
            strSql.Append(" OwnerID = @OwnerID , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@IconUrl", SqlDbType.NVarChar,256) ,                        new SqlParameter("@LinkTextCN", SqlDbType.NVarChar,64) ,                        new SqlParameter("@LinkTextEN", SqlDbType.NVarChar,64) ,                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar,256) ,                        new SqlParameter("@IsEnable", SqlDbType.Int,4) ,                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,                        new SqlParameter("@OwnerID", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.IconUrl;                        
            parameters[2].Value = info.LinkTextCN;                        
            parameters[3].Value = info.LinkTextEN;                        
            parameters[4].Value = info.LinkUrl;                        
            parameters[5].Value = info.IsEnable;                        
            parameters[6].Value = info.DisplayIndex;                        
            parameters[7].Value = info.OwnerID;                        
            parameters[8].Value = info.CreateDate;                        
            parameters[9].Value = info.UpdateDate;                        
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
		public bool DeleteFriendLinks(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete FROM FriendLinks ");
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
		public bool DeleteFriendLinksList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete FROM FriendLinks ");
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
		public MideFrameWork.Data.Entity.FriendLinksEntity GetFriendLinksEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, IconUrl, LinkTextCN, LinkTextEN, LinkUrl, IsEnable, DisplayIndex, OwnerID, CreateDate, UpdateDate  ");			
			strSql.Append("  FROM FriendLinks ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.FriendLinksEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetFriendLinks(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.FriendLinksEntity> GetFriendLinksList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,IconUrl,LinkTextCN,LinkTextEN,LinkUrl,IsEnable,DisplayIndex,OwnerID,CreateDate,UpdateDate");
			strSql.Append(" FROM FriendLinks ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.FriendLinksEntity> list = new List<MideFrameWork.Data.Entity.FriendLinksEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetFriendLinks(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.FriendLinksEntity> GetFriendLinksList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,IconUrl,LinkTextCN,LinkTextEN,LinkUrl,IsEnable,DisplayIndex,OwnerID,CreateDate,UpdateDate");
			strSql.Append(" FROM FriendLinks ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.FriendLinksEntity> list = new List<MideFrameWork.Data.Entity.FriendLinksEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetFriendLinks(dr));
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
        public IList<FriendLinksEntity> GetFriendLinksList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.FriendLinksEntity> list = new List<MideFrameWork.Data.Entity.FriendLinksEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage("FriendLinks", "ID,IconUrl,LinkTextCN,LinkTextEN,LinkUrl,IsEnable,DisplayIndex,OwnerID,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetFriendLinks(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.FriendLinksEntity GetFriendLinks(DataRow dr)
        {
            MideFrameWork.Data.Entity.FriendLinksEntity info = new MideFrameWork.Data.Entity.FriendLinksEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["IconUrl"])
				info.IconUrl= string.Empty;
			else	
				info.IconUrl= dr["IconUrl"].ToString();
																								
						if(DBNull.Value==dr["LinkTextCN"])
				info.LinkTextCN= string.Empty;
			else	
				info.LinkTextCN= dr["LinkTextCN"].ToString();
																								
						if(DBNull.Value==dr["LinkTextEN"])
				info.LinkTextEN= string.Empty;
			else	
				info.LinkTextEN= dr["LinkTextEN"].ToString();
																								
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

