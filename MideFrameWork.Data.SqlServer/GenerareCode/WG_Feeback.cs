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
	/// 数据访问实现类：WG_Feeback
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WG_FeebackExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WG_Feeback");
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
		public int AddWG_Feeback(MideFrameWork.Data.Entity.WG_FeebackEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WG_Feeback(");			
            strSql.Append("PromoterID,Detail,Memo,CreateDate");
			strSql.Append(") values (");
            strSql.Append("@PromoterID,@Detail,@Memo,@CreateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@PromoterID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Detail", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@Memo", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.PromoterID;                        
            parameters[1].Value = info.Detail;                        
            parameters[2].Value = info.Memo;                        
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
		public bool UpdateWG_Feeback(MideFrameWork.Data.Entity.WG_FeebackEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WG_Feeback set ");
			                                                
            strSql.Append(" PromoterID = @PromoterID , ");                                    
            strSql.Append(" Detail = @Detail , ");                                    
            strSql.Append(" Memo = @Memo , ");                                    
            strSql.Append(" CreateDate = @CreateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@PromoterID", SqlDbType.Int,4) ,                        new SqlParameter("@Detail", SqlDbType.NVarChar,1024) ,                        new SqlParameter("@Memo", SqlDbType.NVarChar,512) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.PromoterID;                        
            parameters[2].Value = info.Detail;                        
            parameters[3].Value = info.Memo;                        
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
		public bool DeleteWG_Feeback(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Feeback ");
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
		public bool DeleteWG_FeebackList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Feeback ");
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
		public MideFrameWork.Data.Entity.WG_FeebackEntity GetWG_FeebackEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, PromoterID, Detail, Memo, CreateDate  ");			
			strSql.Append("  from WG_Feeback ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.WG_FeebackEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetWG_Feeback(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_FeebackEntity> GetWG_FeebackList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PromoterID,Detail,Memo,CreateDate");
			strSql.Append(" FROM WG_Feeback ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.WG_FeebackEntity> list = new List<MideFrameWork.Data.Entity.WG_FeebackEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Feeback(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_FeebackEntity> GetWG_FeebackList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,PromoterID,Detail,Memo,CreateDate");
			strSql.Append(" FROM WG_Feeback ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.WG_FeebackEntity> list = new List<MideFrameWork.Data.Entity.WG_FeebackEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Feeback(dr));
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
        public IList<WG_FeebackEntity> GetWG_FeebackList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.WG_FeebackEntity> list = new List<MideFrameWork.Data.Entity.WG_FeebackEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" WG_Feeback", "ID,PromoterID,Detail,Memo,CreateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetWG_Feeback(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.WG_FeebackEntity GetWG_Feeback(DataRow dr)
        {
            MideFrameWork.Data.Entity.WG_FeebackEntity info = new MideFrameWork.Data.Entity.WG_FeebackEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																						if(DBNull.Value==dr["PromoterID"])
					info.PromoterID=0;
				else
					info.PromoterID=int.Parse(dr["PromoterID"].ToString());
									
																								
						if(DBNull.Value==dr["Detail"])
				info.Detail= string.Empty;
			else	
				info.Detail= dr["Detail"].ToString();
																								
						if(DBNull.Value==dr["Memo"])
				info.Memo= string.Empty;
			else	
				info.Memo= dr["Memo"].ToString();
																									if(DBNull.Value==dr["CreateDate"])
					info.CreateDate=DateTime.Now;
				else
					info.CreateDate=DateTime.Parse(dr["CreateDate"].ToString());
						
															            return info;
        }
	}
}

