using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MenuEntity
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
		/// 父节点ID
        /// </summary>
        public int ParentID
        {
            get{ return _parentid; }
            set{ _parentid = value; }
        }
        
		private string _displayname;
		/// <summary>
		/// 显示名称
        /// </summary>
        public string DisplayName
        {
            get{ return _displayname; }
            set{ _displayname = value; }
        }
        
		private int _displayindex;
		/// <summary>
		/// DisplayIndex
        /// </summary>
        public int DisplayIndex
        {
            get{ return _displayindex; }
            set{ _displayindex = value; }
        }
        
		private int _groupid;
		/// <summary>
		/// 所属权限分组
        /// </summary>
        public int GroupID
        {
            get{ return _groupid; }
            set{ _groupid = value; }
        }
        
		private string _linkurl;
		/// <summary>
		/// 链接URL
        /// </summary>
        public string LinkUrl
        {
            get{ return _linkurl; }
            set{ _linkurl = value; }
        }
        
		private string _imageurl;
		/// <summary>
		/// 图片URL
        /// </summary>
        public string ImageUrl
        {
            get{ return _imageurl; }
            set{ _imageurl = value; }
        }
        
		private int _status;
		/// <summary>
		/// 当前状态，0为正常，1为暂停
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
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