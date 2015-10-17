

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
	/// 数据访问实现类：WG_OnGoingGifts
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WG_OnGoingGiftsExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WG_OnGoingGifts");
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
		public int AddWG_OnGoingGifts(MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WG_OnGoingGifts(");			
            strSql.Append("Code,MenberID,GiftID,Count,Status,CreateDate");
			strSql.Append(") values (");
            strSql.Append("@Code,@MenberID,@GiftID,@Count,@Status,@CreateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Code", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@MenberID", SqlDbType.Int,4) ,            
                        new SqlParameter("@GiftID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.Code;                        
            parameters[1].Value = info.MenberID;                        
            parameters[2].Value = info.GiftID;                        
            parameters[3].Value = info.Count;                        
            parameters[4].Value = info.Status;                        
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
		public bool UpdateWG_OnGoingGifts(MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WG_OnGoingGifts set ");
			                                                
            strSql.Append(" Code = @Code , ");                                    
            strSql.Append(" MenberID = @MenberID , ");                                    
            strSql.Append(" GiftID = @GiftID , ");                                    
            strSql.Append(" Count = @Count , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" CreateDate = @CreateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@Code", SqlDbType.NVarChar,32) ,                        new SqlParameter("@MenberID", SqlDbType.Int,4) ,                        new SqlParameter("@GiftID", SqlDbType.Int,4) ,                        new SqlParameter("@Count", SqlDbType.Int,4) ,                        new SqlParameter("@Status", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.Code;                        
            parameters[2].Value = info.MenberID;                        
            parameters[3].Value = info.GiftID;                        
            parameters[4].Value = info.Count;                        
            parameters[5].Value = info.Status;                        
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
		public bool DeleteWG_OnGoingGifts(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_OnGoingGifts ");
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
		public bool DeleteWG_OnGoingGiftsList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_OnGoingGifts ");
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
		public MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity GetWG_OnGoingGiftsEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, Code, MenberID, GiftID, Count, Status, CreateDate  ");			
			strSql.Append("  from WG_OnGoingGifts ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetWG_OnGoingGifts(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity> GetWG_OnGoingGiftsList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Code,MenberID,GiftID,Count,Status,CreateDate");
			strSql.Append(" FROM WG_OnGoingGifts ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity> list = new List<MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_OnGoingGifts(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity> GetWG_OnGoingGiftsList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,Code,MenberID,GiftID,Count,Status,CreateDate");
			strSql.Append(" FROM WG_OnGoingGifts ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity> list = new List<MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_OnGoingGifts(dr));
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
        public IList<WG_OnGoingGiftsEntity> GetWG_OnGoingGiftsList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity> list = new List<MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" WG_OnGoingGifts", "ID,Code,MenberID,GiftID,Count,Status,CreateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetWG_OnGoingGifts(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity GetWG_OnGoingGifts(DataRow dr)
        {
            MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity info = new MideFrameWork.Data.Entity.WG_OnGoingGiftsEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["Code"])
				info.Code= string.Empty;
			else	
				info.Code= dr["Code"].ToString();
																						if(DBNull.Value==dr["MenberID"])
					info.MenberID=0;
				else
					info.MenberID=int.Parse(dr["MenberID"].ToString());
									
																						if(DBNull.Value==dr["GiftID"])
					info.GiftID=0;
				else
					info.GiftID=int.Parse(dr["GiftID"].ToString());
									
																						if(DBNull.Value==dr["Count"])
					info.Count=0;
				else
					info.Count=int.Parse(dr["Count"].ToString());
									
																						if(DBNull.Value==dr["Status"])
					info.Status=0;
				else
					info.Status=int.Parse(dr["Status"].ToString());
									
																									if(DBNull.Value==dr["CreateDate"])
					info.CreateDate=DateTime.Now;
				else
					info.CreateDate=DateTime.Parse(dr["CreateDate"].ToString());
						
															            return info;
        }
	}
}

