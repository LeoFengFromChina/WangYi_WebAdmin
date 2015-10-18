

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
	/// 数据访问实现类：PrivilegeView
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool PrivilegeViewExists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PrivilegeView");
			strSql.Append(" where ");

            SqlParameter[] parameters = { };
						
			                                    
			            
			            
            
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void AddPrivilegeView(MideFrameWork.Data.Entity.PrivilegeViewEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PrivilegeView(");			
            strSql.Append("UserID,ModuleName,ButtonName");
			strSql.Append(") values (");
            strSql.Append("@UserID,@ModuleName,@ButtonName");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ModuleName", SqlDbType.NVarChar,128) ,            
                        new SqlParameter("@ButtonName", SqlDbType.NVarChar,32)             
              
            };
			            
            parameters[0].Value = info.UserID;                        
            parameters[1].Value = info.ModuleName;                        
            parameters[2].Value = info.ButtonName;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdatePrivilegeView(MideFrameWork.Data.Entity.PrivilegeViewEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PrivilegeView set ");
			                        
            strSql.Append(" UserID = @UserID , ");                                    
            strSql.Append(" ModuleName = @ModuleName , ");                                    
            strSql.Append(" ButtonName = @ButtonName  ");            			
			strSql.Append(" where  ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.Int,4) ,                        new SqlParameter("@ModuleName", SqlDbType.NVarChar,128) ,                        new SqlParameter("@ButtonName", SqlDbType.NVarChar,32)               
            };
						            
            parameters[0].Value = info.UserID;                        
            parameters[1].Value = info.ModuleName;                        
            parameters[2].Value = info.ButtonName;                        
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
		public bool DeletePrivilegeView()
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PrivilegeView ");
			strSql.Append(" where ");
            SqlParameter[] parameters ={

            };
			            
			            
            
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
		/// 得到一个对象实体
		/// </summary>
		public MideFrameWork.Data.Entity.PrivilegeViewEntity GetPrivilegeViewEntity()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID, ModuleName, ButtonName  ");			
			strSql.Append("  from PrivilegeView ");
			strSql.Append(" where ");
            SqlParameter[] parameters ={


                        };
			            
			            
            			
			MideFrameWork.Data.Entity.PrivilegeViewEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetPrivilegeView(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.PrivilegeViewEntity> GetPrivilegeViewList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID,ModuleName,ButtonName");
			strSql.Append(" FROM PrivilegeView ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.PrivilegeViewEntity> list = new List<MideFrameWork.Data.Entity.PrivilegeViewEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetPrivilegeView(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.PrivilegeViewEntity> GetPrivilegeViewList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("UserID,ModuleName,ButtonName");
			strSql.Append(" FROM PrivilegeView ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.PrivilegeViewEntity> list = new List<MideFrameWork.Data.Entity.PrivilegeViewEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetPrivilegeView(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		
        private MideFrameWork.Data.Entity.PrivilegeViewEntity GetPrivilegeView(DataRow dr)
        {
            MideFrameWork.Data.Entity.PrivilegeViewEntity info = new MideFrameWork.Data.Entity.PrivilegeViewEntity();
										if(DBNull.Value==dr["UserID"])
					info.UserID=0;
				else
					info.UserID=int.Parse(dr["UserID"].ToString());
									
																								
						if(DBNull.Value==dr["ModuleName"])
				info.ModuleName= string.Empty;
			else	
				info.ModuleName= dr["ModuleName"].ToString();
																								
						if(DBNull.Value==dr["ButtonName"])
				info.ButtonName= string.Empty;
			else	
				info.ButtonName= dr["ButtonName"].ToString();
															            return info;
        }
	}
}

