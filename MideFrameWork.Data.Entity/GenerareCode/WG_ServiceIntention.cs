using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_ServiceIntention:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_ServiceIntentionEntity
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
        
		private int _parentid;
		/// <summary>
		/// 父ID
        /// </summary>
        public int ParentID
        {
            get{ return _parentid; }
            set{ _parentid = value; }
        }
        
		private string _content;
		/// <summary>
		/// 意向名称
        /// </summary>
        public string Content
        {
            get{ return _content; }
            set{ _content = value; }
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
        
		private DateTime _updatedate;
		/// <summary>
		/// 更新日期
        /// </summary>
        public DateTime UpdateDate
        {
            get{ return _updatedate; }
            set{ _updatedate = value; }
        }
        
		   
	}
}