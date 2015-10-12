using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// Log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LogEntity
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
        
		private string _modulename;
		/// <summary>
		/// 模块名称(触发页面名称)
        /// </summary>
        public string ModuleName
        {
            get{ return _modulename; }
            set{ _modulename = value; }
        }
        
		private string _operation;
		/// <summary>
		/// 操作名称(触发的方法)
        /// </summary>
        public string Operation
        {
            get{ return _operation; }
            set{ _operation = value; }
        }
        
		private string _logcontent;
		/// <summary>
		/// 日志正文
        /// </summary>
        public string LogContent
        {
            get{ return _logcontent; }
            set{ _logcontent = value; }
        }
        
		private int _logtype;
		/// <summary>
		/// 日志类型(1为系统异常,2为操作日志)
        /// </summary>
        public int LogType
        {
            get{ return _logtype; }
            set{ _logtype = value; }
        }
        
		private int _fromuserid;
		/// <summary>
		/// 产生日志用户ID
        /// </summary>
        public int FromUserID
        {
            get{ return _fromuserid; }
            set{ _fromuserid = value; }
        }
        
		private DateTime _createdate;
		/// <summary>
		/// 日期
        /// </summary>
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }
        
		   
	}
}