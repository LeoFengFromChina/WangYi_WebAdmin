using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// Article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ArticleEntity
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
        
		private string _titlecn;
		/// <summary>
		/// TitleCN
        /// </summary>
        public string TitleCN
        {
            get{ return _titlecn; }
            set{ _titlecn = value; }
        }
        
		private string _titleen;
		/// <summary>
		/// TitleEN
        /// </summary>
        public string TitleEN
        {
            get{ return _titleen; }
            set{ _titleen = value; }
        }
        
		private int _typeid;
		/// <summary>
		/// TypeID
        /// </summary>
        public int TypeID
        {
            get{ return _typeid; }
            set{ _typeid = value; }
        }
        
		private string _context;
		/// <summary>
		/// Context
        /// </summary>
        public string Context
        {
            get{ return _context; }
            set{ _context = value; }
        }
        
		private string _template;
		/// <summary>
		/// Template
        /// </summary>
        public string Template
        {
            get{ return _template; }
            set{ _template = value; }
        }
        
		private string _iconurl;
		/// <summary>
		/// IconUrl
        /// </summary>
        public string IconUrl
        {
            get{ return _iconurl; }
            set{ _iconurl = value; }
        }
        
		private string _attachment;
		/// <summary>
		/// Attachment
        /// </summary>
        public string Attachment
        {
            get{ return _attachment; }
            set{ _attachment = value; }
        }
        
		private int _isenable;
		/// <summary>
		/// IsEnable
        /// </summary>
        public int IsEnable
        {
            get{ return _isenable; }
            set{ _isenable = value; }
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
        
		private DateTime _createdate;
		/// <summary>
		/// CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }
        
		private DateTime _updatedate;
		/// <summary>
		/// UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get{ return _updatedate; }
            set{ _updatedate = value; }
        }
        
		private int _ownerid;
		/// <summary>
		/// OwnerID
        /// </summary>
        public int OwnerID
        {
            get{ return _ownerid; }
            set{ _ownerid = value; }
        }
        
		   
	}
}