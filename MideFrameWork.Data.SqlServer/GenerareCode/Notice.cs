

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
	/// 数据访问实现类：Notice
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool NoticeExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Notice");
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
		public int AddNotice(MideFrameWork.Data.Entity.NoticeEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Notice(");			
            strSql.Append("Title,NoticeContent,FromUserID,NoticeType,LinkId,AlreadyRead,ToUserID,CreateDate");
			strSql.Append(") values (");
            strSql.Append("@Title,@NoticeContent,@FromUserID,@NoticeType,@LinkId,@AlreadyRead,@ToUserID,@CreateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Title", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@NoticeContent", SqlDbType.NVarChar) ,            
                        new SqlParameter("@FromUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@NoticeType", SqlDbType.Int,4) ,            
                        new SqlParameter("@LinkId", SqlDbType.Int,4) ,            
                        new SqlParameter("@AlreadyRead", SqlDbType.Int,4) ,            
                        new SqlParameter("@ToUserID", SqlDbType.NChar,10) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.Title;                        
            parameters[1].Value = info.NoticeContent;                        
            parameters[2].Value = info.FromUserID;                        
            parameters[3].Value = info.NoticeType;                        
            parameters[4].Value = info.LinkId;                        
            parameters[5].Value = info.AlreadyRead;                        
            parameters[6].Value = info.ToUserID;                        
            parameters[7].Value = info.CreateDate;                        
			   
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
		public bool UpdateNotice(MideFrameWork.Data.Entity.NoticeEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Notice set ");
			                                                
            strSql.Append(" Title = @Title , ");                                    
            strSql.Append(" NoticeContent = @NoticeContent , ");                                    
            strSql.Append(" FromUserID = @FromUserID , ");                                    
            strSql.Append(" NoticeType = @NoticeType , ");                                    
            strSql.Append(" LinkId = @LinkId , ");                                    
            strSql.Append(" AlreadyRead = @AlreadyRead , ");                                    
            strSql.Append(" ToUserID = @ToUserID , ");                                    
            strSql.Append(" CreateDate = @CreateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@Title", SqlDbType.NVarChar,128) ,                        new SqlParameter("@NoticeContent", SqlDbType.NVarChar) ,                        new SqlParameter("@FromUserID", SqlDbType.Int,4) ,                        new SqlParameter("@NoticeType", SqlDbType.Int,4) ,                        new SqlParameter("@LinkId", SqlDbType.Int,4) ,                        new SqlParameter("@AlreadyRead", SqlDbType.Int,4) ,                        new SqlParameter("@ToUserID", SqlDbType.NChar,10) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.Title;                        
            parameters[2].Value = info.NoticeContent;                        
            parameters[3].Value = info.FromUserID;                        
            parameters[4].Value = info.NoticeType;                        
            parameters[5].Value = info.LinkId;                        
            parameters[6].Value = info.AlreadyRead;                        
            parameters[7].Value = info.ToUserID;                        
            parameters[8].Value = info.CreateDate;                        
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
		public bool DeleteNotice(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Notice ");
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
		public bool DeleteNoticeList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Notice ");
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
		public MideFrameWork.Data.Entity.NoticeEntity GetNoticeEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, Title, NoticeContent, FromUserID, NoticeType, LinkId, AlreadyRead, ToUserID, CreateDate  ");			
			strSql.Append("  from Notice ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.NoticeEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetNotice(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.NoticeEntity> GetNoticeList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Title,NoticeContent,FromUserID,NoticeType,LinkId,AlreadyRead,ToUserID,CreateDate");
			strSql.Append(" FROM Notice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.NoticeEntity> list = new List<MideFrameWork.Data.Entity.NoticeEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetNotice(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.NoticeEntity> GetNoticeList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,Title,NoticeContent,FromUserID,NoticeType,LinkId,AlreadyRead,ToUserID,CreateDate");
			strSql.Append(" FROM Notice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.NoticeEntity> list = new List<MideFrameWork.Data.Entity.NoticeEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetNotice(dr));
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
        public IList<NoticeEntity> GetNoticeList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.NoticeEntity> list = new List<MideFrameWork.Data.Entity.NoticeEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" Notice", "ID,Title,NoticeContent,FromUserID,NoticeType,LinkId,AlreadyRead,ToUserID,CreateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetNotice(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.NoticeEntity GetNotice(DataRow dr)
        {
            MideFrameWork.Data.Entity.NoticeEntity info = new MideFrameWork.Data.Entity.NoticeEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["Title"])
				info.Title= string.Empty;
			else	
				info.Title= dr["Title"].ToString();
																								
						if(DBNull.Value==dr["NoticeContent"])
				info.NoticeContent= string.Empty;
			else	
				info.NoticeContent= dr["NoticeContent"].ToString();
																						if(DBNull.Value==dr["FromUserID"])
					info.FromUserID=0;
				else
					info.FromUserID=int.Parse(dr["FromUserID"].ToString());
									
																						if(DBNull.Value==dr["NoticeType"])
					info.NoticeType=0;
				else
					info.NoticeType=int.Parse(dr["NoticeType"].ToString());
									
																						if(DBNull.Value==dr["LinkId"])
					info.LinkId=0;
				else
					info.LinkId=int.Parse(dr["LinkId"].ToString());
									
																						if(DBNull.Value==dr["AlreadyRead"])
					info.AlreadyRead=0;
				else
					info.AlreadyRead=int.Parse(dr["AlreadyRead"].ToString());
									
																								
						if(DBNull.Value==dr["ToUserID"])
				info.ToUserID= string.Empty;
			else	
				info.ToUserID= dr["ToUserID"].ToString();
																									if(DBNull.Value==dr["CreateDate"])
					info.CreateDate=DateTime.Now;
				else
					info.CreateDate=DateTime.Parse(dr["CreateDate"].ToString());
						
															            return info;
        }
	}
}

