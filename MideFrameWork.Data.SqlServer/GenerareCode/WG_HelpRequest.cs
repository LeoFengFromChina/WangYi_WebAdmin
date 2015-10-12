

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
	/// 数据访问实现类：WG_HelpRequest
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WG_HelpRequestExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WG_HelpRequest");
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
		public int AddWG_HelpRequest(MideFrameWork.Data.Entity.WG_HelpRequestEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WG_HelpRequest(");			
            strSql.Append("Title,PromoterID,LinkMan,LinkPhone,BeginTime,Region,ServiceIntention,Duration,Detail,UnderTakerID,Status,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@Title,@PromoterID,@LinkMan,@LinkPhone,@BeginTime,@Region,@ServiceIntention,@Duration,@Detail,@UnderTakerID,@Status,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Title", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@PromoterID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LinkMan", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@LinkPhone", SqlDbType.NVarChar,11) ,            
                        new SqlParameter("@BeginTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Region", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@ServiceIntention", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Duration", SqlDbType.Int,4) ,            
                        new SqlParameter("@Detail", SqlDbType.NVarChar) ,            
                        new SqlParameter("@UnderTakerID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.Title;                        
            parameters[1].Value = info.PromoterID;                        
            parameters[2].Value = info.LinkMan;                        
            parameters[3].Value = info.LinkPhone;                        
            parameters[4].Value = info.BeginTime;                        
            parameters[5].Value = info.Region;                        
            parameters[6].Value = info.ServiceIntention;                        
            parameters[7].Value = info.Duration;                        
            parameters[8].Value = info.Detail;                        
            parameters[9].Value = info.UnderTakerID;                        
            parameters[10].Value = info.Status;                        
            parameters[11].Value = info.CreateDate;                        
            parameters[12].Value = info.UpdateDate;                        
			   
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
		public bool UpdateWG_HelpRequest(MideFrameWork.Data.Entity.WG_HelpRequestEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WG_HelpRequest set ");
			                                                
            strSql.Append(" Title = @Title , ");                                    
            strSql.Append(" PromoterID = @PromoterID , ");                                    
            strSql.Append(" LinkMan = @LinkMan , ");                                    
            strSql.Append(" LinkPhone = @LinkPhone , ");                                    
            strSql.Append(" BeginTime = @BeginTime , ");                                    
            strSql.Append(" Region = @Region , ");                                    
            strSql.Append(" ServiceIntention = @ServiceIntention , ");                                    
            strSql.Append(" Duration = @Duration , ");                                    
            strSql.Append(" Detail = @Detail , ");                                    
            strSql.Append(" UnderTakerID = @UnderTakerID , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@Title", SqlDbType.NVarChar,256) ,                        new SqlParameter("@PromoterID", SqlDbType.Int,4) ,                        new SqlParameter("@LinkMan", SqlDbType.NVarChar,32) ,                        new SqlParameter("@LinkPhone", SqlDbType.NVarChar,11) ,                        new SqlParameter("@BeginTime", SqlDbType.DateTime) ,                        new SqlParameter("@Region", SqlDbType.NVarChar,64) ,                        new SqlParameter("@ServiceIntention", SqlDbType.NVarChar,128) ,                        new SqlParameter("@Duration", SqlDbType.Int,4) ,                        new SqlParameter("@Detail", SqlDbType.NVarChar) ,                        new SqlParameter("@UnderTakerID", SqlDbType.Int,4) ,                        new SqlParameter("@Status", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.Title;                        
            parameters[2].Value = info.PromoterID;                        
            parameters[3].Value = info.LinkMan;                        
            parameters[4].Value = info.LinkPhone;                        
            parameters[5].Value = info.BeginTime;                        
            parameters[6].Value = info.Region;                        
            parameters[7].Value = info.ServiceIntention;                        
            parameters[8].Value = info.Duration;                        
            parameters[9].Value = info.Detail;                        
            parameters[10].Value = info.UnderTakerID;                        
            parameters[11].Value = info.Status;                        
            parameters[12].Value = info.CreateDate;                        
            parameters[13].Value = info.UpdateDate;                        
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
		public bool DeleteWG_HelpRequest(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_HelpRequest ");
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
		public bool DeleteWG_HelpRequestList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_HelpRequest ");
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
		public MideFrameWork.Data.Entity.WG_HelpRequestEntity GetWG_HelpRequestEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, Title, PromoterID, LinkMan, LinkPhone, BeginTime, Region, ServiceIntention, Duration, Detail, UnderTakerID, Status, CreateDate, UpdateDate  ");			
			strSql.Append("  from WG_HelpRequest ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.WG_HelpRequestEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetWG_HelpRequest(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_HelpRequestEntity> GetWG_HelpRequestList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Title,PromoterID,LinkMan,LinkPhone,BeginTime,Region,ServiceIntention,Duration,Detail,UnderTakerID,Status,CreateDate,UpdateDate");
			strSql.Append(" FROM WG_HelpRequest ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.WG_HelpRequestEntity> list = new List<MideFrameWork.Data.Entity.WG_HelpRequestEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_HelpRequest(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_HelpRequestEntity> GetWG_HelpRequestList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,Title,PromoterID,LinkMan,LinkPhone,BeginTime,Region,ServiceIntention,Duration,Detail,UnderTakerID,Status,CreateDate,UpdateDate");
			strSql.Append(" FROM WG_HelpRequest ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.WG_HelpRequestEntity> list = new List<MideFrameWork.Data.Entity.WG_HelpRequestEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_HelpRequest(dr));
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
        public IList<WG_HelpRequestEntity> GetWG_HelpRequestList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.WG_HelpRequestEntity> list = new List<MideFrameWork.Data.Entity.WG_HelpRequestEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" WG_HelpRequest", "ID,Title,PromoterID,LinkMan,LinkPhone,BeginTime,Region,ServiceIntention,Duration,Detail,UnderTakerID,Status,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetWG_HelpRequest(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.WG_HelpRequestEntity GetWG_HelpRequest(DataRow dr)
        {
            MideFrameWork.Data.Entity.WG_HelpRequestEntity info = new MideFrameWork.Data.Entity.WG_HelpRequestEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["Title"])
				info.Title= string.Empty;
			else	
				info.Title= dr["Title"].ToString();
																						if(DBNull.Value==dr["PromoterID"])
					info.PromoterID=0;
				else
					info.PromoterID=int.Parse(dr["PromoterID"].ToString());
									
																								
						if(DBNull.Value==dr["LinkMan"])
				info.LinkMan= string.Empty;
			else	
				info.LinkMan= dr["LinkMan"].ToString();
																								
						if(DBNull.Value==dr["LinkPhone"])
				info.LinkPhone= string.Empty;
			else	
				info.LinkPhone= dr["LinkPhone"].ToString();
																									if(DBNull.Value==dr["BeginTime"])
					info.BeginTime=DateTime.Now;
				else
					info.BeginTime=DateTime.Parse(dr["BeginTime"].ToString());
						
																								
						if(DBNull.Value==dr["Region"])
				info.Region= string.Empty;
			else	
				info.Region= dr["Region"].ToString();
																								
						if(DBNull.Value==dr["ServiceIntention"])
				info.ServiceIntention= string.Empty;
			else	
				info.ServiceIntention= dr["ServiceIntention"].ToString();
																						if(DBNull.Value==dr["Duration"])
					info.Duration=0;
				else
					info.Duration=int.Parse(dr["Duration"].ToString());
									
																								
						if(DBNull.Value==dr["Detail"])
				info.Detail= string.Empty;
			else	
				info.Detail= dr["Detail"].ToString();
																						if(DBNull.Value==dr["UnderTakerID"])
					info.UnderTakerID=0;
				else
					info.UnderTakerID=int.Parse(dr["UnderTakerID"].ToString());
									
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

