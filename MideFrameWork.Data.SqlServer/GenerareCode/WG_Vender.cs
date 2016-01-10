

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
	/// 数据访问实现类：WG_Vender
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WG_VenderExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WG_Vender");
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
		public int AddWG_Vender(MideFrameWork.Data.Entity.WG_VenderEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WG_Vender(");			
            strSql.Append("VenderName,VenderType,Logo,Address,ComLevel,Phone,Memo,CreateDate");
			strSql.Append(") values (");
            strSql.Append("@VenderName,@VenderType,@Logo,@Address,@ComLevel,@Phone,@Memo,@CreateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@VenderName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@VenderType", SqlDbType.Int,4) ,            
                        new SqlParameter("@Logo", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,256) ,            
                        new SqlParameter("@ComLevel", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@Phone", SqlDbType.NVarChar,11) ,            
                        new SqlParameter("@Memo", SqlDbType.NVarChar,512) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.VenderName;                        
            parameters[1].Value = info.VenderType;                        
            parameters[2].Value = info.Logo;                        
            parameters[3].Value = info.Address;                        
            parameters[4].Value = info.ComLevel;                        
            parameters[5].Value = info.Phone;                        
            parameters[6].Value = info.Memo;                        
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
		public bool UpdateWG_Vender(MideFrameWork.Data.Entity.WG_VenderEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WG_Vender set ");
			                                                
            strSql.Append(" VenderName = @VenderName , ");                                    
            strSql.Append(" VenderType = @VenderType , ");                                    
            strSql.Append(" Logo = @Logo , ");                                    
            strSql.Append(" Address = @Address , ");                                    
            strSql.Append(" ComLevel = @ComLevel , ");                                    
            strSql.Append(" Phone = @Phone , ");                                    
            strSql.Append(" Memo = @Memo , ");                                    
            strSql.Append(" CreateDate = @CreateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@VenderName", SqlDbType.NVarChar,50) ,                        new SqlParameter("@VenderType", SqlDbType.Int,4) ,                        new SqlParameter("@Logo", SqlDbType.NVarChar,256) ,                        new SqlParameter("@Address", SqlDbType.NVarChar,256) ,                        new SqlParameter("@ComLevel", SqlDbType.NVarChar,32) ,                        new SqlParameter("@Phone", SqlDbType.NVarChar,11) ,                        new SqlParameter("@Memo", SqlDbType.NVarChar,512) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.VenderName;                        
            parameters[2].Value = info.VenderType;                        
            parameters[3].Value = info.Logo;                        
            parameters[4].Value = info.Address;                        
            parameters[5].Value = info.ComLevel;                        
            parameters[6].Value = info.Phone;                        
            parameters[7].Value = info.Memo;                        
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
		public bool DeleteWG_Vender(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Vender ");
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
		public bool DeleteWG_VenderList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WG_Vender ");
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
		public MideFrameWork.Data.Entity.WG_VenderEntity GetWG_VenderEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, VenderName, VenderType, Logo, Address, ComLevel, Phone, Memo, CreateDate  ");			
			strSql.Append("  from WG_Vender ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.WG_VenderEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetWG_Vender(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_VenderEntity> GetWG_VenderList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,VenderName,VenderType,Logo,Address,ComLevel,Phone,Memo,CreateDate");
			strSql.Append(" FROM WG_Vender ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.WG_VenderEntity> list = new List<MideFrameWork.Data.Entity.WG_VenderEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Vender(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.WG_VenderEntity> GetWG_VenderList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,VenderName,VenderType,Logo,Address,ComLevel,Phone,Memo,CreateDate");
			strSql.Append(" FROM WG_Vender ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.WG_VenderEntity> list = new List<MideFrameWork.Data.Entity.WG_VenderEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetWG_Vender(dr));
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
        public IList<WG_VenderEntity> GetWG_VenderList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
            IList<MideFrameWork.Data.Entity.WG_VenderEntity> list = new List<MideFrameWork.Data.Entity.WG_VenderEntity>();
            recordCount = 0;
            totalPage = 0;
            DataSet ds = GetRecordByPage(" WG_Vender", "ID,VenderName,VenderType,Logo,Address,ComLevel,Phone,Memo,CreateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetWG_Vender(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.WG_VenderEntity GetWG_Vender(DataRow dr)
        {
            MideFrameWork.Data.Entity.WG_VenderEntity info = new MideFrameWork.Data.Entity.WG_VenderEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																								
						if(DBNull.Value==dr["VenderName"])
				info.VenderName= string.Empty;
			else	
				info.VenderName= dr["VenderName"].ToString();
																						if(DBNull.Value==dr["VenderType"])
					info.VenderType=0;
				else
					info.VenderType=int.Parse(dr["VenderType"].ToString());
									
																								
						if(DBNull.Value==dr["Logo"])
				info.Logo= string.Empty;
			else	
				info.Logo= dr["Logo"].ToString();
																								
						if(DBNull.Value==dr["Address"])
				info.Address= string.Empty;
			else	
				info.Address= dr["Address"].ToString();
																								
						if(DBNull.Value==dr["ComLevel"])
				info.ComLevel= string.Empty;
			else	
				info.ComLevel= dr["ComLevel"].ToString();
																								
						if(DBNull.Value==dr["Phone"])
				info.Phone= string.Empty;
			else	
				info.Phone= dr["Phone"].ToString();
																								
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

