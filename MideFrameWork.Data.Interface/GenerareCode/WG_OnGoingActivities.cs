﻿using System;
using System.Collections.Generic;

namespace MideFrameWork.Data.Interface
{
	/// <summary>
	/// 数据访问接口类：WG_OnGoingActivities
	/// </summary>
	public partial interface IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool WG_OnGoingActivitiesExists(int ID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  AddWG_OnGoingActivities(MideFrameWork.Data.Entity.WG_OnGoingActivitiesEntity info);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool UpdateWG_OnGoingActivities(MideFrameWork.Data.Entity.WG_OnGoingActivitiesEntity info);
		
		/// <summary>
		/// 删除数据
		/// </summary>
		bool DeleteWG_OnGoingActivities(int ID);
		
				bool DeleteWG_OnGoingActivitiesList(string IDlist );
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MideFrameWork.Data.Entity.WG_OnGoingActivitiesEntity GetWG_OnGoingActivitiesEntity(int ID);
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		IList<MideFrameWork.Data.Entity.WG_OnGoingActivitiesEntity> GetWG_OnGoingActivitiesList(string strWhere);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		IList<MideFrameWork.Data.Entity.WG_OnGoingActivitiesEntity> GetWG_OnGoingActivitiesList(int Top,string strWhere,string filedOrder);
		
		        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize">每页的行数</param>
        /// <param name="PageNumber">要显示的页码, 从1开始</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">返回总记录数</param>
        /// <returns></returns>
        IList<MideFrameWork.Data.Entity.WG_OnGoingActivitiesEntity> GetWG_OnGoingActivitiesList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage);
			} 
}