

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
	/// 数据访问实现类：WG_Menber
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WG_MenberExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WG_Menber");
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
		public int AddWG_Menber(MideFrameWork.Data.Entity.WG_MenberEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WG_Menber(");			
            strSql.Append("NickName,Name,Psw,Scores,Sex,Birthday,Email,Flag,PhotoUrl,Country,Province,City,District,Town,Community,Phone,WeChat,QQ,PersonalID,Address,Education,Major,SpecialSkill,ServiceIntention,ServiceTimeInterval,ServiceHours,Status,CreateDate,UpdateDate");
			strSql.Append(") values (");
            strSql.Append("@NickName,@Name,@Psw,@Scores,@Sex,@Birthday,@Email,@Flag,@PhotoUrl,@Country,@Province,@City,@District,@Town,@Community,@Phone,@WeChat,@QQ,@PersonalID,@Address,@Education,@Major,@SpecialSkill,@ServiceIntention,@ServiceTimeInterval,@ServiceHours,@Status,@CreateDate,@UpdateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@NickName", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Name", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Psw", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Scores", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sex", SqlDbType.NVarChar,2) ,            
                        new SqlParameter("@Birthday", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Email", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@Flag", SqlDbType.Int,4) ,            
                        new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,1024) ,            
                        new SqlParameter("@Country", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Province", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@City", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@District", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Town", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Community", SqlDbType.NVarChar,64) ,            
                        new SqlParameter("@Phone", SqlDbType.NVarChar,11) ,            
                        new SqlParameter("@WeChat", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@QQ", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@PersonalID", SqlDbType.NVarChar,18) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Education", SqlDbType.NVarChar,16) ,            
                        new SqlParameter("@Major", SqlDbType.NVarChar,16) ,            
                        new SqlParameter("@SpecialSkill", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@ServiceIntention", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@ServiceTimeInterval", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@ServiceHours", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.NickName;                        
            parameters[1].Value = info.Name;                        
            parameters[2].Value = info.Psw;                        
            parameters[3].Value = info.Scores;                        
            parameters[4].Value = info.Sex;                        
            parameters[5].Value = info.Birthday;                        
            parameters[6].Value = info.Email;                        
            parameters[7].Value = info.Flag;                        
            parameters[8].Value = info.PhotoUrl;                        
            parameters[9].Value = info.Country;                        
            parameters[10].Value = info.Province;                        
            parameters[11].Value = info.City;                        
            parameters[12].Value = info.District;                        
            parameters[13].Value = info.Town;                        
            parameters[14].Value = info.Community;                        
            parameters[15].Value = info.Phone;                        
            parameters[16].Value = info.WeChat;                        
            parameters[17].Value = info.QQ;                        
            parameters[18].Value = info.PersonalID;                        
            parameters[19].Value = info.Address;                        
            parameters[20].Value = info.Education;                        
            parameters[21].Value = info.Major;                        
            parameters[22].Value = info.SpecialSkill;                        
            parameters[23].Value = info.ServiceIntention;                        
            parameters[24].Value = info.ServiceTimeInterval;                        
            parameters[25].Value = info.ServiceHours;                        
            parameters[26].Value = info.Status;                        
            parameters[27].Value = info.CreateDate;                        
            parameters[28].Value = info.UpdateDate;                        
			   
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
		public bool UpdateWG_Menber(MideFrameWork.Data.Entity.WG_MenberEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WG_Menber set ");
			                                                
            strSql.Append(" NickName = @NickName , ");                                    
            strSql.Append(" Name = @Name , ");                                    
            strSql.Append(" Psw = @Psw , ");                                    
            strSql.Append(" Scores = @Scores , ");                                    
            strSql.Append(" Sex = @Sex , ");                                    
            strSql.Append(" Birthday = @Birthday , ");                                    
            strSql.Append(" Email = @Email , ");                                    
            strSql.Append(" Flag = @Flag , ");                                    
            strSql.Append(" PhotoUrl = @PhotoUrl , ");                                    
            strSql.Append(" Country = @Country , ");                                    
            strSql.Append(" Province = @Province , ");                                    
            strSql.Append(" City = @City , ");                                    
            strSql.Append(" District = @District , ");                                    
            strSql.Append(" Town = @Town , ");                                    
            strSql.Append(" Community = @Community , ");                                    
            strSql.Append(" Phone = @Phone , ");                                    
            strSql.Append(" WeChat = @WeChat , ");                                    
            strSql.Append(" QQ = @QQ , ");                                    
            strSql.Append(" PersonalID = @PersonalID , ");                                    
            strSql.Append(" Address = @Address , ");                                    
            strSql.Append(" Education = @Education , ");                                    
            strSql.Append(" Major = @Major , ");                                    
            strSql.Append(" SpecialSkill = @SpecialSkill , ");                                    
            strSql.Append(" ServiceIntention = @ServiceIntention , ");                                    
            strSql.Append(" ServiceTimeInterval = @ServiceTimeInterval , ");                                    
            strSql.Append(" ServiceHours = @ServiceHours , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" UpdateDate = @UpdateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@NickName", SqlDbType.NVarChar,32) ,                        new SqlParameter("@Name", SqlDbType.NVarChar,32) ,                        new SqlParameter("@Psw", SqlDbType.NVarChar,64) ,                        new SqlParameter("@Scores", SqlDbType.Int,4) ,                        new SqlParameter("@Sex", SqlDbType.NVarChar,2) ,                        new SqlParameter("@Birthday", SqlDbType.NVarChar,32) ,                        new SqlParameter("@Email", SqlDbType.NVarChar,128) ,                        new SqlParameter("@Flag", SqlDbType.Int,4) ,                        new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,1024) ,                        new SqlParameter("@Country", SqlDbType.NVarChar,64) ,                        new SqlParameter("@Province", SqlDbType.NVarChar,64) ,                        new SqlParameter("@City", SqlDbType.NVarChar,64) ,                        new SqlParameter("@District", SqlDbType.NVarChar,64) ,                        new SqlParameter("@Town", SqlDbType.NVarChar,64) ,                        new SqlParameter("@Community", SqlDbType.NVarChar,64) ,                        new SqlParameter("@Phone", SqlDbType.NVarChar,11) ,                        new SqlParameter("@WeChat", SqlDbType.NVarChar,32) ,                        new SqlParameter("@QQ", SqlDbType.NVarChar,32) ,                        new SqlParameter("@PersonalID", SqlDbType.NVarChar,18) ,                        new SqlParameter("@Address", SqlDbType.NVarChar,256) ,                        new SqlParameter("@Education", SqlDbType.NVarChar,16) ,                        new SqlParameter("@Major", SqlDbType.NVarChar,16) ,                        new SqlParameter("@SpecialSkill", SqlDbType.NVarChar,512) ,                        new SqlParameter("@ServiceIntention", SqlDbType.NVarChar,128) ,                        new SqlParameter("@ServiceTimeInterval", SqlDbType.NVarChar,32) ,                        new SqlParameter("@ServiceHours", SqlDbType.Int,4) ,                        new SqlParameter("@Status", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,                        new SqlParameter("@UpdateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.NickName;                        
            parameters[2].Value = info.Name;                        
            parameters[3].Value = info.Psw;                        
            parameters[4].Value = info.Scores;                        
            parameters[5].Value = info.Sex;                        
            parameters[6].Value = info.Birthday;                        
            parameters[7].Value = info.Email;                        
            parameters[8].Value = info.Flag;                        
            parameters[9].Value = info.PhotoUrl;                        
            parameters[10].Value = info.Country;                        
            parameters[11].Value = info.Province;                        
            parameters[12].Value = info.City;                        
            parameters[13].Value = info.District;                        
            parameters[14].Value = info.Town;                        
            parameters[15].Value = info.Community;                        
            parameters[16].Value = info.Phone;                        
            parameters[17].Value = info.WeChat;                        
            parameters[18].Value = info.QQ;                        
            parameters[19].Value = info.PersonalID;                        
            parameters[20].Value = info.Address;                        
            parameters[21].Value = info.Education;                        
            parameters[22].Value = info.Major;                        
            parameters[23].Value = info.SpecialSkill;                        
            parameters[24].Value = info.ServiceIntention;                        
            parameters[25].Value = info.ServiceTimeInterval;                        
            parameters[26].Value = info.ServiceHours;                        
            parameters[27].Value = info.Status;                        
            parameters[28].Value = info.CreateDate;                        
            parameters[29].Value = info.UpdateDate;                        
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
		public bool DeleteWG_Menber(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Menber ");
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
		public bool DeleteWG_MenberList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Menber ");
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
		public MideFrameWork.Data.Entity.WG_MenberEntity GetWG_MenberEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, NickName, Name, Psw, Scores, Sex, Birthday, Email, Flag, PhotoUrl, Country, Province, City, District, Town, Community, Phone, WeChat, QQ, PersonalID, Address, Education, Major, SpecialSkill, ServiceIntention, ServiceTimeInterval, ServiceHours, Status, CreateDate, UpdateDate  ");			
			strSql.Append("  from WG_Menber ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.WG_MenberEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetWG_Menber(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_MenberEntity> GetWG_MenberList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,NickName,Name,Psw,Scores,Sex,Birthday,Email,Flag,PhotoUrl,Country,Province,City,District,Town,Community,Phone,WeChat,QQ,PersonalID,Address,Education,Major,SpecialSkill,ServiceIntention,ServiceTimeInterval,ServiceHours,Status,CreateDate,UpdateDate");
			strSql.Append(" FROM WG_Menber ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.WG_MenberEntity> list = new List<MideFrameWork.Data.Entity.WG_MenberEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Menber(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_MenberEntity> GetWG_MenberList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,NickName,Name,Psw,Scores,Sex,Birthday,Email,Flag,PhotoUrl,Country,Province,City,District,Town,Community,Phone,WeChat,QQ,PersonalID,Address,Education,Major,SpecialSkill,ServiceIntention,ServiceTimeInterval,ServiceHours,Status,CreateDate,UpdateDate");
			strSql.Append(" FROM WG_Menber ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.WG_MenberEntity> list = new List<MideFrameWork.Data.Entity.WG_MenberEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Menber(dr));
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
        public IList<WG_MenberEntity> GetWG_MenberList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.WG_MenberEntity> list = new List<MideFrameWork.Data.Entity.WG_MenberEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" WG_Menber", "ID,NickName,Name,Psw,Scores,Sex,Birthday,Email,Flag,PhotoUrl,Country,Province,City,District,Town,Community,Phone,WeChat,QQ,PersonalID,Address,Education,Major,SpecialSkill,ServiceIntention,ServiceTimeInterval,ServiceHours,Status,CreateDate,UpdateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetWG_Menber(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.WG_MenberEntity GetWG_Menber(DataRow dr)
        {
            MideFrameWork.Data.Entity.WG_MenberEntity info = new MideFrameWork.Data.Entity.WG_MenberEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["NickName"])
				info.NickName= string.Empty;
			else	
				info.NickName= dr["NickName"].ToString();
																								
						if(DBNull.Value==dr["Name"])
				info.Name= string.Empty;
			else	
				info.Name= dr["Name"].ToString();
																								
						if(DBNull.Value==dr["Psw"])
				info.Psw= string.Empty;
			else	
				info.Psw= dr["Psw"].ToString();
																						if(DBNull.Value==dr["Scores"])
					info.Scores=0;
				else
					info.Scores=int.Parse(dr["Scores"].ToString());
									
																								
						if(DBNull.Value==dr["Sex"])
				info.Sex= string.Empty;
			else	
				info.Sex= dr["Sex"].ToString();
																								
						if(DBNull.Value==dr["Birthday"])
				info.Birthday= string.Empty;
			else	
				info.Birthday= dr["Birthday"].ToString();
																								
						if(DBNull.Value==dr["Email"])
				info.Email= string.Empty;
			else	
				info.Email= dr["Email"].ToString();
																						if(DBNull.Value==dr["Flag"])
					info.Flag=0;
				else
					info.Flag=int.Parse(dr["Flag"].ToString());
									
																								
						if(DBNull.Value==dr["PhotoUrl"])
				info.PhotoUrl= string.Empty;
			else	
				info.PhotoUrl= dr["PhotoUrl"].ToString();
																								
						if(DBNull.Value==dr["Country"])
				info.Country= string.Empty;
			else	
				info.Country= dr["Country"].ToString();
																								
						if(DBNull.Value==dr["Province"])
				info.Province= string.Empty;
			else	
				info.Province= dr["Province"].ToString();
																								
						if(DBNull.Value==dr["City"])
				info.City= string.Empty;
			else	
				info.City= dr["City"].ToString();
																								
						if(DBNull.Value==dr["District"])
				info.District= string.Empty;
			else	
				info.District= dr["District"].ToString();
																								
						if(DBNull.Value==dr["Town"])
				info.Town= string.Empty;
			else	
				info.Town= dr["Town"].ToString();
																								
						if(DBNull.Value==dr["Community"])
				info.Community= string.Empty;
			else	
				info.Community= dr["Community"].ToString();
																								
						if(DBNull.Value==dr["Phone"])
				info.Phone= string.Empty;
			else	
				info.Phone= dr["Phone"].ToString();
																								
						if(DBNull.Value==dr["WeChat"])
				info.WeChat= string.Empty;
			else	
				info.WeChat= dr["WeChat"].ToString();
																								
						if(DBNull.Value==dr["QQ"])
				info.QQ= string.Empty;
			else	
				info.QQ= dr["QQ"].ToString();
																								
						if(DBNull.Value==dr["PersonalID"])
				info.PersonalID= string.Empty;
			else	
				info.PersonalID= dr["PersonalID"].ToString();
																								
						if(DBNull.Value==dr["Address"])
				info.Address= string.Empty;
			else	
				info.Address= dr["Address"].ToString();
																								
						if(DBNull.Value==dr["Education"])
				info.Education= string.Empty;
			else	
				info.Education= dr["Education"].ToString();
																								
						if(DBNull.Value==dr["Major"])
				info.Major= string.Empty;
			else	
				info.Major= dr["Major"].ToString();
																								
						if(DBNull.Value==dr["SpecialSkill"])
				info.SpecialSkill= string.Empty;
			else	
				info.SpecialSkill= dr["SpecialSkill"].ToString();
																								
						if(DBNull.Value==dr["ServiceIntention"])
				info.ServiceIntention= string.Empty;
			else	
				info.ServiceIntention= dr["ServiceIntention"].ToString();
																								
						if(DBNull.Value==dr["ServiceTimeInterval"])
				info.ServiceTimeInterval= string.Empty;
			else	
				info.ServiceTimeInterval= dr["ServiceTimeInterval"].ToString();
																						if(DBNull.Value==dr["ServiceHours"])
					info.ServiceHours=0;
				else
					info.ServiceHours=int.Parse(dr["ServiceHours"].ToString());
									
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

