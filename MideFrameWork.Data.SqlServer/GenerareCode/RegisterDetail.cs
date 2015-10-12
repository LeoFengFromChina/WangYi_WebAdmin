

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
	/// 数据访问实现类：RegisterDetail
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool RegisterDetailExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RegisterDetail");
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
		public int AddRegisterDetail(MideFrameWork.Data.Entity.RegisterDetailEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RegisterDetail(");			
            strSql.Append("UserID,Mac,IP,CreateDate");
			strSql.Append(") values (");
            strSql.Append("@UserID,@Mac,@IP,@CreateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Mac", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@IP", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.UserID;                        
            parameters[1].Value = info.Mac;                        
            parameters[2].Value = info.IP;                        
            parameters[3].Value = info.CreateDate;                        
			   
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
		public bool UpdateRegisterDetail(MideFrameWork.Data.Entity.RegisterDetailEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RegisterDetail set ");
			                                                
            strSql.Append(" UserID = @UserID , ");                                    
            strSql.Append(" Mac = @Mac , ");                                    
            strSql.Append(" IP = @IP , ");                                    
            strSql.Append(" CreateDate = @CreateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@UserID", SqlDbType.Int,4) ,                        new SqlParameter("@Mac", SqlDbType.NVarChar,64) ,                        new SqlParameter("@IP", SqlDbType.NVarChar,64) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.UserID;                        
            parameters[2].Value = info.Mac;                        
            parameters[3].Value = info.IP;                        
            parameters[4].Value = info.CreateDate;                        
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
		public bool DeleteRegisterDetail(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RegisterDetail ");
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
		public bool DeleteRegisterDetailList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RegisterDetail ");
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
		public MideFrameWork.Data.Entity.RegisterDetailEntity GetRegisterDetailEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, UserID, Mac, IP, CreateDate  ");			
			strSql.Append("  from RegisterDetail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.RegisterDetailEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetRegisterDetail(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.RegisterDetailEntity> GetRegisterDetailList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,Mac,IP,CreateDate");
			strSql.Append(" FROM RegisterDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.RegisterDetailEntity> list = new List<MideFrameWork.Data.Entity.RegisterDetailEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetRegisterDetail(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.RegisterDetailEntity> GetRegisterDetailList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,UserID,Mac,IP,CreateDate");
			strSql.Append(" FROM RegisterDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.RegisterDetailEntity> list = new List<MideFrameWork.Data.Entity.RegisterDetailEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetRegisterDetail(dr));
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
        public IList<RegisterDetailEntity> GetRegisterDetailList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
		
			recordCount = 0;
            totalPage = 0;
            IList<MideFrameWork.Data.Entity.RegisterDetailEntity> list = new List<MideFrameWork.Data.Entity.RegisterDetailEntity>();
            recordCount = 0;
            
            DataSet ds = GetRecordByPage("RegisterDetail","ID,UserID,Mac,IP,CreateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetRegisterDetail(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.RegisterDetailEntity GetRegisterDetail(DataRow dr)
        {
            MideFrameWork.Data.Entity.RegisterDetailEntity info = new MideFrameWork.Data.Entity.RegisterDetailEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																						if(DBNull.Value==dr["UserID"])
					info.UserID=0;
				else
					info.UserID=int.Parse(dr["UserID"].ToString());
									
																								
						if(DBNull.Value==dr["Mac"])
				info.Mac= string.Empty;
			else	
				info.Mac= dr["Mac"].ToString();
																								
						if(DBNull.Value==dr["IP"])
				info.IP= string.Empty;
			else	
				info.IP= dr["IP"].ToString();
																									if(DBNull.Value==dr["CreateDate"])
					info.CreateDate=DateTime.Now;
				else
					info.CreateDate=DateTime.Parse(dr["CreateDate"].ToString());
						
															            return info;
        }
	}
}

