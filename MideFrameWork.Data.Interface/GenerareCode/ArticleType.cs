using System;
using System.Collections.Generic;

namespace MideFrameWork.Data.Interface
{
	/// <summary>
	/// 数据访问接口类：ArticleType
	/// </summary>
	public partial interface IDataProvider
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool ArticleTypeExists(int ID);
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  AddArticleType(MideFrameWork.Data.Entity.ArticleTypeEntity info);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool UpdateArticleType(MideFrameWork.Data.Entity.ArticleTypeEntity info);
		
		/// <summary>
		/// 删除数据
		/// </summary>
		bool DeleteArticleType(int ID);
		
				bool DeleteArticleTypeList(string IDlist );
				/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MideFrameWork.Data.Entity.ArticleTypeEntity GetArticleTypeEntity(int ID);
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		IList<MideFrameWork.Data.Entity.ArticleTypeEntity> GetArticleTypeList(string strWhere);
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		IList<MideFrameWork.Data.Entity.ArticleTypeEntity> GetArticleTypeList(int Top,string strWhere,string filedOrder);
		
		        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize">每页的行数</param>
        /// <param name="PageNumber">要显示的页码, 从1开始</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="orderBy">排序</param>
        /// <param name="recordCount">返回总记录数</param>
        /// <returns></returns>
        IList<MideFrameWork.Data.Entity.ArticleTypeEntity> GetArticleTypeList(int PageSize, int PageIndex, string strWhere, string orderBy, out int recordCount , out int totalPage);
			} 
}