

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
	/// 数据访问实现类：WG_Gifts
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WG_GiftsExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WG_Gifts");
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
		public int AddWG_Gifts(MideFrameWork.Data.Entity.WG_GiftsEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WG_Gifts(");			
            strSql.Append("Title,PhotoUrl,NeedScores,Count,Detail,Region,Status,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@Title,@PhotoUrl,@NeedScores,@Count,@Detail,@Region,@Status,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Title", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@NeedScores", SqlDbType.Int,4) ,            
                        new SqlParameter("@Count", SqlDbType.Int,4) ,            
                        new SqlParameter("@Detail", SqlDbType.NVarChar) ,            
                        new SqlParameter("@Region", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.Title;                        
            parameters[1].Value = info.PhotoUrl;                        
            parameters[2].Value = info.NeedScores;                        
            parameters[3].Value = info.Count;                        
            parameters[4].Value = info.Detail;                        
            parameters[5].Value = info.Region;                        
            parameters[6].Value = info.Status;                        
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
		public bool UpdateWG_Gifts(MideFrameWork.Data.Entity.WG_GiftsEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WG_Gifts set ");
			                                                
            strSql.Append(" Title = @Title , ");                                    
            strSql.Append(" PhotoUrl = @PhotoUrl , ");                                    
            strSql.Append(" NeedScores = @NeedScores , ");                                    
            strSql.Append(" Count = @Count , ");                                    
            strSql.Append(" Detail = @Detail , ");                                    
            strSql.Append(" Region = @Region , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@Title", SqlDbType.NVarChar,32) ,                        new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,512) ,                        new SqlParameter("@NeedScores", SqlDbType.Int,4) ,                        new SqlParameter("@Count", SqlDbType.Int,4) ,                        new SqlParameter("@Detail", SqlDbType.NVarChar) ,                        new SqlParameter("@Region", SqlDbType.NVarChar,64) ,                        new SqlParameter("@Status", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.Title;                        
            parameters[2].Value = info.PhotoUrl;                        
            parameters[3].Value = info.NeedScores;                        
            parameters[4].Value = info.Count;                        
            parameters[5].Value = info.Detail;                        
            parameters[6].Value = info.Region;                        
            parameters[7].Value = info.Status;                        
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
		public bool DeleteWG_Gifts(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Gifts ");
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
		public bool DeleteWG_GiftsList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Gifts ");
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
		public MideFrameWork.Data.Entity.WG_GiftsEntity GetWG_GiftsEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, Title, PhotoUrl, NeedScores, Count, Detail, Region, Status, CreateDate, UpdateDate  ");			
			strSql.Append("  from WG_Gifts ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.WG_GiftsEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetWG_Gifts(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_GiftsEntity> GetWG_GiftsList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Title,PhotoUrl,NeedScores,Count,Detail,Region,Status,CreateDate,UpdateDate");
			strSql.Append(" FROM WG_Gifts ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.WG_GiftsEntity> list = new List<MideFrameWork.Data.Entity.WG_GiftsEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Gifts(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_GiftsEntity> GetWG_GiftsList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,Title,PhotoUrl,NeedScores,Count,Detail,Region,Status,CreateDate,UpdateDate");
			strSql.Append(" FROM WG_Gifts ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.WG_GiftsEntity> list = new List<MideFrameWork.Data.Entity.WG_GiftsEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Gifts(dr));
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
        public IList<WG_GiftsEntity> GetWG_GiftsList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.WG_GiftsEntity> list = new List<MideFrameWork.Data.Entity.WG_GiftsEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" WG_Gifts", "ID,Title,PhotoUrl,NeedScores,Count,Detail,Region,Status,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetWG_Gifts(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.WG_GiftsEntity GetWG_Gifts(DataRow dr)
        {
            MideFrameWork.Data.Entity.WG_GiftsEntity info = new MideFrameWork.Data.Entity.WG_GiftsEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["Title"])
				info.Title= string.Empty;
			else	
				info.Title= dr["Title"].ToString();
																								
						if(DBNull.Value==dr["PhotoUrl"])
				info.PhotoUrl= string.Empty;
			else	
				info.PhotoUrl= dr["PhotoUrl"].ToString();
																						if(DBNull.Value==dr["NeedScores"])
					info.NeedScores=0;
				else
					info.NeedScores=int.Parse(dr["NeedScores"].ToString());
									
																						if(DBNull.Value==dr["Count"])
					info.Count=0;
				else
					info.Count=int.Parse(dr["Count"].ToString());
									
																								
						if(DBNull.Value==dr["Detail"])
				info.Detail= string.Empty;
			else	
				info.Detail= dr["Detail"].ToString();
																								
						if(DBNull.Value==dr["Region"])
				info.Region= string.Empty;
			else	
				info.Region= dr["Region"].ToString();
																						if(DBNull.Value==dr["Status"])
					info.Status=0;
				else
					info.Status=int.Parse(dr["Status"].ToString());
									
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

