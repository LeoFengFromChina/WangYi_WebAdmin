using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_CommunityNews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_CommunityNewsEntity
	{
      	private int _id;
		/// <summary>
		/// ID
        /// </summary>
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }
        
		private string _title;
		/// <summary>
		/// 标题
        /// </summary>
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
        }
        
		private string _contents;
		/// <summary>
		/// 正文
        /// </summary>
        public string Contents
        {
            get{ return _contents; }
            set{ _contents = value; }
        }
        
		private int _upcount;
		/// <summary>
		/// 顶次数
        /// </summary>
        public int UpCount
        {
            get{ return _upcount; }
            set{ _upcount = value; }
        }
        
		private string _memo;
		/// <summary>
		/// 备注
        /// </summary>
        public string Memo
        {
            get{ return _memo; }
            set{ _memo = value; }
        }
        
		private DateTime _createdate;
		/// <summary>
		/// 创建日期
        /// </summary>
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }
        
		   
	}
}