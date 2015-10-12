

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
	/// 数据访问实现类：Base_Privilege
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Base_PrivilegeExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Base_Privilege");
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
		public int AddBase_Privilege(MideFrameWork.Data.Entity.Base_PrivilegeEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Base_Privilege(");			
            strSql.Append("UserID,ModuleID,ButtonID,CreaterID,UpdaterID,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@UserID,@ModuleID,@ButtonID,@CreaterID,@UpdaterID,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ButtonID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreaterID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UpdaterID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.UserID;                        
            parameters[1].Value = info.ModuleID;                        
            parameters[2].Value = info.ButtonID;                        
            parameters[3].Value = info.CreaterID;                        
            parameters[4].Value = info.UpdaterID;                        
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
		public bool UpdateBase_Privilege(MideFrameWork.Data.Entity.Base_PrivilegeEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Base_Privilege set ");
			                                                
            strSql.Append(" UserID = @UserID , ");                                    
            strSql.Append(" ModuleID = @ModuleID , ");                                    
            strSql.Append(" ButtonID = @ButtonID , ");                                    
            strSql.Append(" CreaterID = @CreaterID , ");                                    
            strSql.Append(" UpdaterID = @UpdaterID , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@UserID", SqlDbType.Int,4) ,                        new SqlParameter("@ModuleID", SqlDbType.Int,4) ,                        new SqlParameter("@ButtonID", SqlDbType.Int,4) ,                        new SqlParameter("@CreaterID", SqlDbType.Int,4) ,                        new SqlParameter("@UpdaterID", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.UserID;                        
            parameters[2].Value = info.ModuleID;                        
            parameters[3].Value = info.ButtonID;                        
            parameters[4].Value = info.CreaterID;                        
            parameters[5].Value = info.UpdaterID;                        
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
		public bool DeleteBase_Privilege(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Base_Privilege ");
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
		public bool DeleteBase_PrivilegeList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Base_Privilege ");
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
		public MideFrameWork.Data.Entity.Base_PrivilegeEntity GetBase_PrivilegeEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, UserID, ModuleID, ButtonID, CreaterID, UpdaterID, CreateDate, UpdateDate  ");			
			strSql.Append("  from Base_Privilege ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.Base_PrivilegeEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetBase_Privilege(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.Base_PrivilegeEntity> GetBase_PrivilegeList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,ModuleID,ButtonID,CreaterID,UpdaterID,CreateDate,UpdateDate");
			strSql.Append(" FROM Base_Privilege ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.Base_PrivilegeEntity> list = new List<MideFrameWork.Data.Entity.Base_PrivilegeEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetBase_Privilege(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.Base_PrivilegeEntity> GetBase_PrivilegeList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,UserID,ModuleID,ButtonID,CreaterID,UpdaterID,CreateDate,UpdateDate");
			strSql.Append(" FROM Base_Privilege ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.Base_PrivilegeEntity> list = new List<MideFrameWork.Data.Entity.Base_PrivilegeEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetBase_Privilege(dr));
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
        public IList<Base_PrivilegeEntity> GetBase_PrivilegeList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.Base_PrivilegeEntity> list = new List<MideFrameWork.Data.Entity.Base_PrivilegeEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" Base_Privilege", "ID,UserID,ModuleID,ButtonID,CreaterID,UpdaterID,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetBase_Privilege(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.Base_PrivilegeEntity GetBase_Privilege(DataRow dr)
        {
            MideFrameWork.Data.Entity.Base_PrivilegeEntity info = new MideFrameWork.Data.Entity.Base_PrivilegeEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																						if(DBNull.Value==dr["UserID"])
					info.UserID=0;
				else
					info.UserID=int.Parse(dr["UserID"].ToString());
									
																						if(DBNull.Value==dr["ModuleID"])
					info.ModuleID=0;
				else
					info.ModuleID=int.Parse(dr["ModuleID"].ToString());
									
																						if(DBNull.Value==dr["ButtonID"])
					info.ButtonID=0;
				else
					info.ButtonID=int.Parse(dr["ButtonID"].ToString());
									
																						if(DBNull.Value==dr["CreaterID"])
					info.CreaterID=0;
				else
					info.CreaterID=int.Parse(dr["CreaterID"].ToString());
									
																						if(DBNull.Value==dr["UpdaterID"])
					info.UpdaterID=0;
				else
					info.UpdaterID=int.Parse(dr["UpdaterID"].ToString());
									
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

