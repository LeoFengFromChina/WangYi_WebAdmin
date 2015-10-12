

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
	/// 数据访问实现类：Log
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool LogExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Log");
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
		public int AddLog(MideFrameWork.Data.Entity.LogEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Log(");			
            strSql.Append("ModuleName,Operation,LogContent,LogType,FromUserID,CreateDate");
			strSql.Append(") values (");
            strSql.Append("@ModuleName,@Operation,@LogContent,@LogType,@FromUserID,@CreateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@ModuleName", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Operation", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@LogContent", SqlDbType.NVarChar) ,            
                        new SqlParameter("@LogType", SqlDbType.Int,4) ,            
                        new SqlParameter("@FromUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.ModuleName;                        
            parameters[1].Value = info.Operation;                        
            parameters[2].Value = info.LogContent;                        
            parameters[3].Value = info.LogType;                        
            parameters[4].Value = info.FromUserID;                        
            parameters[5].Value = info.CreateDate;                        
			   
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
		public bool UpdateLog(MideFrameWork.Data.Entity.LogEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Log set ");
			                                                
            strSql.Append(" ModuleName = @ModuleName , ");                                    
            strSql.Append(" Operation = @Operation , ");                                    
            strSql.Append(" LogContent = @LogContent , ");                                    
            strSql.Append(" LogType = @LogType , ");                                    
            strSql.Append(" FromUserID = @FromUserID , ");                                    
            strSql.Append(" CreateDate = @CreateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@ModuleName", SqlDbType.NVarChar,64) ,                        new SqlParameter("@Operation", SqlDbType.NVarChar,64) ,                        new SqlParameter("@LogContent", SqlDbType.NVarChar) ,                        new SqlParameter("@LogType", SqlDbType.Int,4) ,                        new SqlParameter("@FromUserID", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.ModuleName;                        
            parameters[2].Value = info.Operation;                        
            parameters[3].Value = info.LogContent;                        
            parameters[4].Value = info.LogType;                        
            parameters[5].Value = info.FromUserID;                        
            parameters[6].Value = info.CreateDate;                        
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
		public bool DeleteLog(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Log ");
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
		public bool DeleteLogList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Log ");
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
		public MideFrameWork.Data.Entity.LogEntity GetLogEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, ModuleName, Operation, LogContent, LogType, FromUserID, CreateDate  ");			
			strSql.Append("  from Log ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.LogEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetLog(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.LogEntity> GetLogList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ModuleName,Operation,LogContent,LogType,FromUserID,CreateDate");
			strSql.Append(" FROM Log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.LogEntity> list = new List<MideFrameWork.Data.Entity.LogEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetLog(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.LogEntity> GetLogList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,ModuleName,Operation,LogContent,LogType,FromUserID,CreateDate");
			strSql.Append(" FROM Log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.LogEntity> list = new List<MideFrameWork.Data.Entity.LogEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetLog(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize">每页的行数</param>
        /// <param name="PageIndex">要显示的页码, 从1开始</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">返回总记录数</param>
        /// <param name="totalPage">返回总页数</param>
        /// <returns></returns>
        public IList<LogEntity> GetLogList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
		
			recordCount = 0;
            totalPage = 0;
            IList<MideFrameWork.Data.Entity.LogEntity> list = new List<MideFrameWork.Data.Entity.LogEntity>();
            recordCount = 0;
            
            DataSet ds = GetRecordByPage("Log","ID,ModuleName,Operation,LogContent,LogType,FromUserID,CreateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetLog(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.LogEntity GetLog(DataRow dr)
        {
            MideFrameWork.Data.Entity.LogEntity info = new MideFrameWork.Data.Entity.LogEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["ModuleName"])
				info.ModuleName= string.Empty;
			else	
				info.ModuleName= dr["ModuleName"].ToString();
																								
						if(DBNull.Value==dr["Operation"])
				info.Operation= string.Empty;
			else	
				info.Operation= dr["Operation"].ToString();
																								
						if(DBNull.Value==dr["LogContent"])
				info.LogContent= string.Empty;
			else	
				info.LogContent= dr["LogContent"].ToString();
																						if(DBNull.Value==dr["LogType"])
					info.LogType=0;
				else
					info.LogType=int.Parse(dr["LogType"].ToString());
									
																						if(DBNull.Value==dr["FromUserID"])
					info.FromUserID=0;
				else
					info.FromUserID=int.Parse(dr["FromUserID"].ToString());
									
																									if(DBNull.Value==dr["CreateDate"])
					info.CreateDate=DateTime.Now;
				else
					info.CreateDate=DateTime.Parse(dr["CreateDate"].ToString());
						
															            return info;
        }
	}
}

