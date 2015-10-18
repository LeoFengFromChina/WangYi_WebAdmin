using System;
using System.Collections.Generic;

namespace MideFrameWork.Data.Interface
{
	/// <summary>
	/// 数据访问接口类：PrivilegeView
	/// </summary>
	public partial interface IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool PrivilegeViewExists();
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void  AddPrivilegeView(MideFrameWork.Data.Entity.PrivilegeViewEntity info);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool UpdatePrivilegeView(MideFrameWork.Data.Entity.PrivilegeViewEntity info);
		
		/// <summary>
		/// 删除数据
		/// </summary>
		bool DeletePrivilegeView();
		
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MideFrameWork.Data.Entity.PrivilegeViewEntity GetPrivilegeViewEntity();
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		IList<MideFrameWork.Data.Entity.PrivilegeViewEntity> GetPrivilegeViewList(string strWhere);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		IList<MideFrameWork.Data.Entity.PrivilegeViewEntity> GetPrivilegeViewList(int Top,string strWhere,string filedOrder);
		
			} 
}