

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
	/// 数据访问实现类：Users
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool UsersExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
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
		public int AddUsers(MideFrameWork.Data.Entity.UsersEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");			
            strSql.Append("ChildAccount,ParentAccount,Status,GroupID,IsAdmin,Password,CorpName,Signature,ChannelID,Balance,Email,TelePhone,MobilePhone,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@ChildAccount,@ParentAccount,@Status,@GroupID,@IsAdmin,@Password,@CorpName,@Signature,@ChannelID,@Balance,@Email,@TelePhone,@MobilePhone,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@ChildAccount", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@ParentAccount", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupID", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsAdmin", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@Password", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@CorpName", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Signature", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@ChannelID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Balance", SqlDbType.Int,4) ,            
                        new SqlParameter("@Email", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@TelePhone", SqlDbType.NVarChar,16) ,            
                        new SqlParameter("@MobilePhone", SqlDbType.NVarChar,16) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.ChildAccount;                        
            parameters[1].Value = info.ParentAccount;                        
            parameters[2].Value = info.Status;                        
            parameters[3].Value = info.GroupID;                        
            parameters[4].Value = info.IsAdmin;                        
            parameters[5].Value = info.Password;                        
            parameters[6].Value = info.CorpName;                        
            parameters[7].Value = info.Signature;                        
            parameters[8].Value = info.ChannelID;                        
            parameters[9].Value = info.Balance;                        
            parameters[10].Value = info.Email;                        
            parameters[11].Value = info.TelePhone;                        
            parameters[12].Value = info.MobilePhone;                        
            parameters[13].Value = info.CreateDate;                        
            parameters[14].Value = info.UpdateDate;                        
			   
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
		public bool UpdateUsers(MideFrameWork.Data.Entity.UsersEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			                                                
            strSql.Append(" ChildAccount = @ChildAccount , ");                                    
            strSql.Append(" ParentAccount = @ParentAccount , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" GroupID = @GroupID , ");                                    
            strSql.Append(" IsAdmin = @IsAdmin , ");                                    
            strSql.Append(" Password = @Password , ");                                    
            strSql.Append(" CorpName = @CorpName , ");                                    
            strSql.Append(" Signature = @Signature , ");                                    
            strSql.Append(" ChannelID = @ChannelID , ");                                    
            strSql.Append(" Balance = @Balance , ");                                    
            strSql.Append(" Email = @Email , ");                                    
            strSql.Append(" TelePhone = @TelePhone , ");                                    
            strSql.Append(" MobilePhone = @MobilePhone , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@ChildAccount", SqlDbType.NVarChar,32) ,                        new SqlParameter("@ParentAccount", SqlDbType.NVarChar,32) ,                        new SqlParameter("@Status", SqlDbType.Int,4) ,                        new SqlParameter("@GroupID", SqlDbType.Int,4) ,                        new SqlParameter("@IsAdmin", SqlDbType.SmallInt,2) ,                        new SqlParameter("@Password", SqlDbType.NVarChar,64) ,                        new SqlParameter("@CorpName", SqlDbType.NVarChar,32) ,                        new SqlParameter("@Signature", SqlDbType.NVarChar,32) ,                        new SqlParameter("@ChannelID", SqlDbType.Int,4) ,                        new SqlParameter("@Balance", SqlDbType.Int,4) ,                        new SqlParameter("@Email", SqlDbType.NVarChar,64) ,                        new SqlParameter("@TelePhone", SqlDbType.NVarChar,16) ,                        new SqlParameter("@MobilePhone", SqlDbType.NVarChar,16) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.ChildAccount;                        
            parameters[2].Value = info.ParentAccount;                        
            parameters[3].Value = info.Status;                        
            parameters[4].Value = info.GroupID;                        
            parameters[5].Value = info.IsAdmin;                        
            parameters[6].Value = info.Password;                        
            parameters[7].Value = info.CorpName;                        
            parameters[8].Value = info.Signature;                        
            parameters[9].Value = info.ChannelID;                        
            parameters[10].Value = info.Balance;                        
            parameters[11].Value = info.Email;                        
            parameters[12].Value = info.TelePhone;                        
            parameters[13].Value = info.MobilePhone;                        
            parameters[14].Value = info.CreateDate;                        
            parameters[15].Value = info.UpdateDate;                        
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
		public bool DeleteUsers(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
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
		public bool DeleteUsersList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
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
		public MideFrameWork.Data.Entity.UsersEntity GetUsersEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, ChildAccount, ParentAccount, Status, GroupID, IsAdmin, Password, CorpName, Signature, ChannelID, Balance, Email, TelePhone, MobilePhone, CreateDate, UpdateDate  ");			
			strSql.Append("  from Users ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.UsersEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetUsers(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.UsersEntity> GetUsersList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ChildAccount,ParentAccount,Status,GroupID,IsAdmin,Password,CorpName,Signature,ChannelID,Balance,Email,TelePhone,MobilePhone,CreateDate,UpdateDate");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.UsersEntity> list = new List<MideFrameWork.Data.Entity.UsersEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetUsers(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.UsersEntity> GetUsersList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,ChildAccount,ParentAccount,Status,GroupID,IsAdmin,Password,CorpName,Signature,ChannelID,Balance,Email,TelePhone,MobilePhone,CreateDate,UpdateDate");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.UsersEntity> list = new List<MideFrameWork.Data.Entity.UsersEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetUsers(dr));
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
        public IList<UsersEntity> GetUsersList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
		
			recordCount = 0;
            totalPage = 0;
            IList<MideFrameWork.Data.Entity.UsersEntity> list = new List<MideFrameWork.Data.Entity.UsersEntity>();
            recordCount = 0;
            
            DataSet ds = GetRecordByPage("Users","ID,ChildAccount,ParentAccount,Status,GroupID,IsAdmin,Password,CorpName,Signature,ChannelID,Balance,Email,TelePhone,MobilePhone,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetUsers(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.UsersEntity GetUsers(DataRow dr)
        {
            MideFrameWork.Data.Entity.UsersEntity info = new MideFrameWork.Data.Entity.UsersEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["ChildAccount"])
				info.ChildAccount= string.Empty;
			else	
				info.ChildAccount= dr["ChildAccount"].ToString();
																								
						if(DBNull.Value==dr["ParentAccount"])
				info.ParentAccount= string.Empty;
			else	
				info.ParentAccount= dr["ParentAccount"].ToString();
																						if(DBNull.Value==dr["Status"])
					info.Status=0;
				else
					info.Status=int.Parse(dr["Status"].ToString());
									
																						if(DBNull.Value==dr["GroupID"])
					info.GroupID=0;
				else
					info.GroupID=int.Parse(dr["GroupID"].ToString());
									
																						if(DBNull.Value==dr["IsAdmin"])
					info.IsAdmin=0;
				else
					info.IsAdmin=int.Parse(dr["IsAdmin"].ToString());
									
																								
						if(DBNull.Value==dr["Password"])
				info.Password= string.Empty;
			else	
				info.Password= dr["Password"].ToString();
																								
						if(DBNull.Value==dr["CorpName"])
				info.CorpName= string.Empty;
			else	
				info.CorpName= dr["CorpName"].ToString();
																								
						if(DBNull.Value==dr["Signature"])
				info.Signature= string.Empty;
			else	
				info.Signature= dr["Signature"].ToString();
																						if(DBNull.Value==dr["ChannelID"])
					info.ChannelID=0;
				else
					info.ChannelID=int.Parse(dr["ChannelID"].ToString());
									
																						if(DBNull.Value==dr["Balance"])
					info.Balance=0;
				else
					info.Balance=int.Parse(dr["Balance"].ToString());
									
																								
						if(DBNull.Value==dr["Email"])
				info.Email= string.Empty;
			else	
				info.Email= dr["Email"].ToString();
																								
						if(DBNull.Value==dr["TelePhone"])
				info.TelePhone= string.Empty;
			else	
				info.TelePhone= dr["TelePhone"].ToString();
																								
						if(DBNull.Value==dr["MobilePhone"])
				info.MobilePhone= string.Empty;
			else	
				info.MobilePhone= dr["MobilePhone"].ToString();
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

