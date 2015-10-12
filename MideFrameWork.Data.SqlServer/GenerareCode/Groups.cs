﻿

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
	/// 数据访问实现类：Groups
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool GroupsExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Groups");
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
		public int AddGroups(MideFrameWork.Data.Entity.GroupsEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Groups(");			
            strSql.Append("GroupName,DisplayIndex,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@GroupName,@DisplayIndex,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@GroupName", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.GroupName;                        
            parameters[1].Value = info.DisplayIndex;                        
            parameters[2].Value = info.CreateDate;                        
            parameters[3].Value = info.UpdateDate;                        
			   
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
		public bool UpdateGroups(MideFrameWork.Data.Entity.GroupsEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Groups set ");
			                                                
            strSql.Append(" GroupName = @GroupName , ");                                    
            strSql.Append(" DisplayIndex = @DisplayIndex , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@GroupName", SqlDbType.NVarChar,32) ,                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.GroupName;                        
            parameters[2].Value = info.DisplayIndex;                        
            parameters[3].Value = info.CreateDate;                        
            parameters[4].Value = info.UpdateDate;                        
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
		public bool DeleteGroups(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Groups ");
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
		public bool DeleteGroupsList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Groups ");
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
		public MideFrameWork.Data.Entity.GroupsEntity GetGroupsEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, GroupName, DisplayIndex, CreateDate, UpdateDate  ");			
			strSql.Append("  from Groups ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.GroupsEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetGroups(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.GroupsEntity> GetGroupsList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,GroupName,DisplayIndex,CreateDate,UpdateDate");
			strSql.Append(" FROM Groups ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.GroupsEntity> list = new List<MideFrameWork.Data.Entity.GroupsEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetGroups(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.GroupsEntity> GetGroupsList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,GroupName,DisplayIndex,CreateDate,UpdateDate");
			strSql.Append(" FROM Groups ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.GroupsEntity> list = new List<MideFrameWork.Data.Entity.GroupsEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetGroups(dr));
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
        public IList<GroupsEntity> GetGroupsList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.GroupsEntity> list = new List<MideFrameWork.Data.Entity.GroupsEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" Groups", "ID,GroupName,DisplayIndex,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetGroups(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.GroupsEntity GetGroups(DataRow dr)
        {
            MideFrameWork.Data.Entity.GroupsEntity info = new MideFrameWork.Data.Entity.GroupsEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["GroupName"])
				info.GroupName= string.Empty;
			else	
				info.GroupName= dr["GroupName"].ToString();
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
						
															            return info;
        }
	}
}

