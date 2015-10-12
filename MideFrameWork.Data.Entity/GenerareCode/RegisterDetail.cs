using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// RegisterDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RegisterDetailEntity
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
        
		private int _userid;
		/// <summary>
		/// 用户ID
        /// </summary>
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }
        
		private string _mac;
		/// <summary>
		/// Mac地址
        /// </summary>
        public string Mac
        {
            get{ return _mac; }
            set{ _mac = value; }
        }
        
		private string _ip;
		/// <summary>
		/// IP地址
        /// </summary>
        public string IP
        {
            get{ return _ip; }
            set{ _ip = value; }
        }
        
		private DateTime _createdate;
		/// <summary>
		/// 注册日期
        /// </summary>
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }
        
		   
	}
}