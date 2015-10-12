

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
	/// 数据访问实现类：Menu
	/// </summary>
	public partial class DataProvider: IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool MenuExists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Menu");
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
		public int AddMenu(MideFrameWork.Data.Entity.MenuEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Menu(");			
            strSql.Append("ParentID,DisplayName,DisplayIndex,GroupID,LinkUrl,ImageUrl,Status,CreateDate");
			strSql.Append(") values (");
            strSql.Append("@ParentID,@DisplayName,@DisplayIndex,@GroupID,@LinkUrl,@ImageUrl,@Status,@CreateDate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@DisplayName", SqlDbType.NVarChar,32) ,            
                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ImageUrl", SqlDbType.NVarChar) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = info.ParentID;                        
            parameters[1].Value = info.DisplayName;                        
            parameters[2].Value = info.DisplayIndex;                        
            parameters[3].Value = info.GroupID;                        
            parameters[4].Value = info.LinkUrl;                        
            parameters[5].Value = info.ImageUrl;                        
            parameters[6].Value = info.Status;                        
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
		public bool UpdateMenu(MideFrameWork.Data.Entity.MenuEntity info)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Menu set ");
			                                                
            strSql.Append(" ParentID = @ParentID , ");                                    
            strSql.Append(" DisplayName = @DisplayName , ");                                    
            strSql.Append(" DisplayIndex = @DisplayIndex , ");                                    
            strSql.Append(" GroupID = @GroupID , ");                                    
            strSql.Append(" LinkUrl = @LinkUrl , ");                                    
            strSql.Append(" ImageUrl = @ImageUrl , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" CreateDate = @CreateDate  ");            			
			strSql.Append(" where ID=@ID ");			
			SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                        new SqlParameter("@ParentID", SqlDbType.Int,4) ,                        new SqlParameter("@DisplayName", SqlDbType.NVarChar,32) ,                        new SqlParameter("@DisplayIndex", SqlDbType.Int,4) ,                        new SqlParameter("@GroupID", SqlDbType.Int,4) ,                        new SqlParameter("@LinkUrl", SqlDbType.NVarChar) ,                        new SqlParameter("@ImageUrl", SqlDbType.NVarChar) ,                        new SqlParameter("@Status", SqlDbType.Int,4) ,                        new SqlParameter("@CreateDate", SqlDbType.DateTime)               
            };
						            
            parameters[0].Value = info.ID;                        
            parameters[1].Value = info.ParentID;                        
            parameters[2].Value = info.DisplayName;                        
            parameters[3].Value = info.DisplayIndex;                        
            parameters[4].Value = info.GroupID;                        
            parameters[5].Value = info.LinkUrl;                        
            parameters[6].Value = info.ImageUrl;                        
            parameters[7].Value = info.Status;                        
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
		public bool DeleteMenu(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Menu ");
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
		public bool DeleteMenuList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Menu ");
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
		public MideFrameWork.Data.Entity.MenuEntity GetMenuEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, ParentID, DisplayName, DisplayIndex, GroupID, LinkUrl, ImageUrl, Status, CreateDate  ");			
			strSql.Append("  from Menu ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters ={
			                new SqlParameter("@ID",SqlDbType.Int,4)           
			};
			            
						parameters[0].Value = ID;
						
			MideFrameWork.Data.Entity.MenuEntity info = null;
			DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
				info = GetMenu(ds.Tables[0].Rows[0]);
			}

			ds.Dispose();
			return info;
		}		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<MideFrameWork.Data.Entity.MenuEntity> GetMenuList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ParentID,DisplayName,DisplayIndex,GroupID,LinkUrl,ImageUrl,Status,CreateDate");
			strSql.Append(" FROM Menu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			IList<MideFrameWork.Data.Entity.MenuEntity> list = new List<MideFrameWork.Data.Entity.MenuEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetMenu(dr));
            }
			ds.Dispose();
			
            return list;
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public IList<MideFrameWork.Data.Entity.MenuEntity> GetMenuList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("ID,ParentID,DisplayName,DisplayIndex,GroupID,LinkUrl,ImageUrl,Status,CreateDate");
			strSql.Append(" FROM Menu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);

			IList<MideFrameWork.Data.Entity.MenuEntity> list = new List<MideFrameWork.Data.Entity.MenuEntity>();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
            	list.Add(GetMenu(dr));
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
        public IList<MenuEntity> GetMenuList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage)
		{
		
			recordCount = 0;
            totalPage = 0;
            IList<MideFrameWork.Data.Entity.MenuEntity> list = new List<MideFrameWork.Data.Entity.MenuEntity>();
            recordCount = 0;
            
            DataSet ds = GetRecordByPage("Menu","ID,ParentID,DisplayName,DisplayIndex,GroupID,LinkUrl,ImageUrl,Status,CreateDate", orderBy,strWhere,PageSize,PageIndex);
            if (ds.Tables.Count == 2)
            {
                // 组装
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(GetMenu(dr));
                }

                // 取记录总数
                //recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                recordCount = (int)ds.Tables[1].Rows[0]["TotalRecord"];
                totalPage = (int)ds.Tables[1].Rows[0]["TotalPage"];
            }
            ds.Dispose();

            return list;
		}
		
        private MideFrameWork.Data.Entity.MenuEntity GetMenu(DataRow dr)
        {
            MideFrameWork.Data.Entity.MenuEntity info = new MideFrameWork.Data.Entity.MenuEntity();
										if(DBNull.Value==dr["ID"])
					info.ID=0;
				else
					info.ID=int.Parse(dr["ID"].ToString());
									
																						if(DBNull.Value==dr["ParentID"])
					info.ParentID=0;
				else
					info.ParentID=int.Parse(dr["ParentID"].ToString());
									
																								
						if(DBNull.Value==dr["DisplayName"])
				info.DisplayName= string.Empty;
			else	
				info.DisplayName= dr["DisplayName"].ToString();
																						if(DBNull.Value==dr["DisplayIndex"])
					info.DisplayIndex=0;
				else
					info.DisplayIndex=int.Parse(dr["DisplayIndex"].ToString());
									
																						if(DBNull.Value==dr["GroupID"])
					info.GroupID=0;
				else
					info.GroupID=int.Parse(dr["GroupID"].ToString());
									
																								
						if(DBNull.Value==dr["LinkUrl"])
				info.LinkUrl= string.Empty;
			else	
				info.LinkUrl= dr["LinkUrl"].ToString();
																								
						if(DBNull.Value==dr["ImageUrl"])
				info.ImageUrl= string.Empty;
			else	
				info.ImageUrl= dr["ImageUrl"].ToString();
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

