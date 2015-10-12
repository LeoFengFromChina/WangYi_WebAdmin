using System;
using System.Collections.Generic;

namespace MideFrameWork.Data.Interface
{
	/// <summary>
	/// 数据访问接口类：Base_Button
	/// </summary>
	public partial interface IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Base_ButtonExists(int ID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  AddBase_Button(MideFrameWork.Data.Entity.Base_ButtonEntity info);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool UpdateBase_Button(MideFrameWork.Data.Entity.Base_ButtonEntity info);
		
		/// <summary>
		/// 删除数据
		/// </summary>
		bool DeleteBase_Button(int ID);
		
				bool DeleteBase_ButtonList(string IDlist );
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MideFrameWork.Data.Entity.Base_ButtonEntity GetBase_ButtonEntity(int ID);
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		IList<MideFrameWork.Data.Entity.Base_ButtonEntity> GetBase_ButtonList(string strWhere);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		IList<MideFrameWork.Data.Entity.Base_ButtonEntity> GetBase_ButtonList(int Top,string strWhere,string filedOrder);
		
		        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize">每页的行数</param>
        /// <param name="PageNumber">要显示的页码, 从1开始</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">返回总记录数</param>
        /// <returns></returns>
        IList<MideFrameWork.Data.Entity.Base_ButtonEntity> GetBase_ButtonList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage);
			} 
}