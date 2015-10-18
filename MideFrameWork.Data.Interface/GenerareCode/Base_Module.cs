using System;
using System.Collections.Generic;

namespace MideFrameWork.Data.Interface
{
	/// <summary>
	/// 数据访问接口类：Base_Module
	/// </summary>
	public partial interface IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Base_ModuleExists(int ID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  AddBase_Module(MideFrameWork.Data.Entity.Base_ModuleEntity info);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool UpdateBase_Module(MideFrameWork.Data.Entity.Base_ModuleEntity info);
		
		/// <summary>
		/// 删除数据
		/// </summary>
		bool DeleteBase_Module(int ID);
		
				bool DeleteBase_ModuleList(string IDlist );
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MideFrameWork.Data.Entity.Base_ModuleEntity GetBase_ModuleEntity(int ID);
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		IList<MideFrameWork.Data.Entity.Base_ModuleEntity> GetBase_ModuleList(string strWhere);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		IList<MideFrameWork.Data.Entity.Base_ModuleEntity> GetBase_ModuleList(int Top,string strWhere,string filedOrder);
		
		        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize">每页的行数</param>
        /// <param name="PageNumber">要显示的页码, 从1开始</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">返回总记录数</param>
        /// <returns></returns>
        IList<MideFrameWork.Data.Entity.Base_ModuleEntity> GetBase_ModuleList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage);
			} 
}