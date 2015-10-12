﻿using System;
using System.Collections.Generic;

namespace MideFrameWork.Data.Interface
{
	/// <summary>
	/// 数据访问接口类：Groups
	/// </summary>
	public partial interface IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool GroupsExists(int ID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  AddGroups(MideFrameWork.Data.Entity.GroupsEntity info);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool UpdateGroups(MideFrameWork.Data.Entity.GroupsEntity info);
		
		/// <summary>
		/// 删除数据
		/// </summary>
		bool DeleteGroups(int ID);
		
				bool DeleteGroupsList(string IDlist );
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MideFrameWork.Data.Entity.GroupsEntity GetGroupsEntity(int ID);
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		IList<MideFrameWork.Data.Entity.GroupsEntity> GetGroupsList(string strWhere);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		IList<MideFrameWork.Data.Entity.GroupsEntity> GetGroupsList(int Top,string strWhere,string filedOrder);
		
		        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize">每页的行数</param>
        /// <param name="PageNumber">要显示的页码, 从1开始</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">返回总记录数</param>
        /// <returns></returns>
        IList<MideFrameWork.Data.Entity.GroupsEntity> GetGroupsList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage);
			} 
}