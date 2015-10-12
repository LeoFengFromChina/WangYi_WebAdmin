

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
	/// 数据访问实现类：District
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool DistrictExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from District");
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
		public int AddDistrict(MideFrameWork.Data.Entity.DistrictEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into District(");			
            strSql.Append("ParentID,DistrictName,Status");
			strSql.Append(") values (");
            strSql.Append("@ParentID,@DistrictName,@Status");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@DistrictName", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = info.ParentID;                        
            parameters[1].Value = info.DistrictName;                        
            parameters[2].Value = info.Status;                        
			   
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
		public bool UpdateDistrict(MideFrameWork.Data.Entity.DistrictEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update District set ");
			                                                
            strSql.Append(" ParentID = @ParentID , ");                                    
            strSql.Append(" DistrictName = @DistrictName , ");                                    
            strSql.Append(" Status = @Status  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@ParentID", SqlDbType.Int,4) ,                        new SqlParameter("@DistrictName", SqlDbType.NVarChar,32) ,                        new SqlParameter("@Status", SqlDbType.Int,4)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.ParentID;                        
            parameters[2].Value = info.DistrictName;                        
            parameters[3].Value = info.Status;                        
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
		public bool DeleteDistrict(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from District ");
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
		public bool DeleteDistrictList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from District ");
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
		public MideFrameWork.Data.Entity.DistrictEntity GetDistrictEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, ParentID, DistrictName, Status  ");			
			strSql.Append("  from District ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.DistrictEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetDistrict(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.DistrictEntity> GetDistrictList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ParentID,DistrictName,Status");
			strSql.Append(" FROM District ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.DistrictEntity> list = new List<MideFrameWork.Data.Entity.DistrictEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetDistrict(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.DistrictEntity> GetDistrictList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,ParentID,DistrictName,Status");
			strSql.Append(" FROM District ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.DistrictEntity> list = new List<MideFrameWork.Data.Entity.DistrictEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetDistrict(dr));
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
        public IList<DistrictEntity> GetDistrictList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
		
			recordCount = 0;
            totalPage = 0;
            IList<MideFrameWork.Data.Entity.DistrictEntity> list = new List<MideFrameWork.Data.Entity.DistrictEntity>();
            recordCount = 0;
            
            DataSet ds = GetRecordByPage("District","ID,ParentID,DistrictName,Status", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetDistrict(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.DistrictEntity GetDistrict(DataRow dr)
        {
            MideFrameWork.Data.Entity.DistrictEntity info = new MideFrameWork.Data.Entity.DistrictEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																						if(DBNull.Value==dr["ParentID"])
					info.ParentID=0;
				else
					info.ParentID=int.Parse(dr["ParentID"].ToString());
									
																								
						if(DBNull.Value==dr["DistrictName"])
				info.DistrictName= string.Empty;
			else	
				info.DistrictName= dr["DistrictName"].ToString();
																						if(DBNull.Value==dr["Status"])
					info.Status=0;
				else
					info.Status=int.Parse(dr["Status"].ToString());
									
															            return info;
        }
	}
}

