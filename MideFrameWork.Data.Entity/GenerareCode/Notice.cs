using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// Notice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NoticeEntity
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
        
		private string _noticecontent;
		/// <summary>
		/// 通知正文
        /// </summary>
        public string NoticeContent
        {
            get{ return _noticecontent; }
            set{ _noticecontent = value; }
        }
        
		private int _fromuserid;
		/// <summary>
		/// 发起人
        /// </summary>
        public int FromUserID
        {
            get{ return _fromuserid; }
            set{ _fromuserid = value; }
        }
        
		private string _touserid;
		/// <summary>
		/// 接收者ID
        /// </summary>
        public string ToUserID
        {
            get{ return _touserid; }
            set{ _touserid = value; }
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