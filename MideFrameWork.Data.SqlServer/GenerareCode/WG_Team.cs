

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
	/// 数据访问实现类：WG_Team
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WG_TeamExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WG_Team");
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
		public int AddWG_Team(MideFrameWork.Data.Entity.WG_TeamEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WG_Team(");			
            strSql.Append("Name,CaptainID,LinkManID,TeamAim,ServiceIntentionIDs,RegionID,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@Name,@CaptainID,@LinkManID,@TeamAim,@ServiceIntentionIDs,@RegionID,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@CaptainID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LinkManID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TeamAim", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@ServiceIntentionIDs", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@RegionID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.Name;                        
            parameters[1].Value = info.CaptainID;                        
            parameters[2].Value = info.LinkManID;                        
            parameters[3].Value = info.TeamAim;                        
            parameters[4].Value = info.ServiceIntentionIDs;                        
            parameters[5].Value = info.RegionID;                        
            parameters[6].Value = info.CreateDate;                        
            parameters[7].Value = info.UpdateDate;                        
			   
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
		public bool UpdateWG_Team(MideFrameWork.Data.Entity.WG_TeamEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WG_Team set ");
			                                                
            strSql.Append(" Name = @Name , ");                                    
            strSql.Append(" CaptainID = @CaptainID , ");                                    
            strSql.Append(" LinkManID = @LinkManID , ");                                    
            strSql.Append(" TeamAim = @TeamAim , ");                                    
            strSql.Append(" ServiceIntentionIDs = @ServiceIntentionIDs , ");                                    
            strSql.Append(" RegionID = @RegionID , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@Name", SqlDbType.NVarChar,32) ,                        new SqlParameter("@CaptainID", SqlDbType.Int,4) ,                        new SqlParameter("@LinkManID", SqlDbType.Int,4) ,                        new SqlParameter("@TeamAim", SqlDbType.NVarChar,1024) ,                        new SqlParameter("@ServiceIntentionIDs", SqlDbType.NVarChar,512) ,                        new SqlParameter("@RegionID", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.Name;                        
            parameters[2].Value = info.CaptainID;                        
            parameters[3].Value = info.LinkManID;                        
            parameters[4].Value = info.TeamAim;                        
            parameters[5].Value = info.ServiceIntentionIDs;                        
            parameters[6].Value = info.RegionID;                        
            parameters[7].Value = info.CreateDate;                        
            parameters[8].Value = info.UpdateDate;                        
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
		public bool DeleteWG_Team(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Team ");
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
		public bool DeleteWG_TeamList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Team ");
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
		public MideFrameWork.Data.Entity.WG_TeamEntity GetWG_TeamEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, Name, CaptainID, LinkManID, TeamAim, ServiceIntentionIDs, RegionID, CreateDate, UpdateDate  ");			
			strSql.Append("  from WG_Team ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.WG_TeamEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetWG_Team(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_TeamEntity> GetWG_TeamList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,CaptainID,LinkManID,TeamAim,ServiceIntentionIDs,RegionID,CreateDate,UpdateDate");
			strSql.Append(" FROM WG_Team ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.WG_TeamEntity> list = new List<MideFrameWork.Data.Entity.WG_TeamEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Team(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_TeamEntity> GetWG_TeamList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,Name,CaptainID,LinkManID,TeamAim,ServiceIntentionIDs,RegionID,CreateDate,UpdateDate");
			strSql.Append(" FROM WG_Team ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.WG_TeamEntity> list = new List<MideFrameWork.Data.Entity.WG_TeamEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Team(dr));
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
        public IList<WG_TeamEntity> GetWG_TeamList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.WG_TeamEntity> list = new List<MideFrameWork.Data.Entity.WG_TeamEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" WG_Team", "ID,Name,CaptainID,LinkManID,TeamAim,ServiceIntentionIDs,RegionID,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetWG_Team(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.WG_TeamEntity GetWG_Team(DataRow dr)
        {
            MideFrameWork.Data.Entity.WG_TeamEntity info = new MideFrameWork.Data.Entity.WG_TeamEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["Name"])
				info.Name= string.Empty;
			else	
				info.Name= dr["Name"].ToString();
																						if(DBNull.Value==dr["CaptainID"])
					info.CaptainID=0;
				else
					info.CaptainID=int.Parse(dr["CaptainID"].ToString());
									
																						if(DBNull.Value==dr["LinkManID"])
					info.LinkManID=0;
				else
					info.LinkManID=int.Parse(dr["LinkManID"].ToString());
									
																								
						if(DBNull.Value==dr["TeamAim"])
				info.TeamAim= string.Empty;
			else	
				info.TeamAim= dr["TeamAim"].ToString();
																								
						if(DBNull.Value==dr["ServiceIntentionIDs"])
				info.ServiceIntentionIDs= string.Empty;
			else	
				info.ServiceIntentionIDs= dr["ServiceIntentionIDs"].ToString();
																						if(DBNull.Value==dr["RegionID"])
					info.RegionID=0;
				else
					info.RegionID=int.Parse(dr["RegionID"].ToString());
									
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

