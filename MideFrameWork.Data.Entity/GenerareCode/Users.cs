using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UsersEntity
	{
      	private int _id;
		/// <summary>
		/// 用户ID
        /// </summary>
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }
        
		private string _childaccount;
		/// <summary>
		/// 子账号
        /// </summary>
        public string ChildAccount
        {
            get{ return _childaccount; }
            set{ _childaccount = value; }
        }
        
		private string _parentaccount;
		/// <summary>
		/// 企业账号
        /// </summary>
        public string ParentAccount
        {
            get{ return _parentaccount; }
            set{ _parentaccount = value; }
        }
        
		private int _status;
		/// <summary>
		/// 状态(0：正常，1:停用，2：删除)
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }
        
		private int _groupid;
		/// <summary>
		/// 分组ID
        /// </summary>
        public int GroupID
        {
            get{ return _groupid; }
            set{ _groupid = value; }
        }
        
		private int _isadmin;
		/// <summary>
		/// 是否是管理员
        /// </summary>
        public int IsAdmin
        {
            get{ return _isadmin; }
            set{ _isadmin = value; }
        }
        
		private string _password;
		/// <summary>
		/// 密码
        /// </summary>
        public string Password
        {
            get{ return _password; }
            set{ _password = value; }
        }
        
		private string _corpname;
		/// <summary>
		/// 企业名称
        /// </summary>
        public string CorpName
        {
            get{ return _corpname; }
            set{ _corpname = value; }
        }
        
		private string _signature;
		/// <summary>
		/// 个人签名
        /// </summary>
        public string Signature
        {
            get{ return _signature; }
            set{ _signature = value; }
        }
        
		private int _channelid;
		/// <summary>
		/// 通道ID
        /// </summary>
        public int ChannelID
        {
            get{ return _channelid; }
            set{ _channelid = value; }
        }
        
		private int _balance;
		/// <summary>
		/// 余额(默认为0)
        /// </summary>
        public int Balance
        {
            get{ return _balance; }
            set{ _balance = value; }
        }
        
		private string _email;
		/// <summary>
		/// 邮箱
        /// </summary>
        public string Email
        {
            get{ return _email; }
            set{ _email = value; }
        }
        
		private string _telephone;
		/// <summary>
		/// 电话
        /// </summary>
        public string TelePhone
        {
            get{ return _telephone; }
            set{ _telephone = value; }
        }
        
		private string _mobilephone;
		/// <summary>
		/// 手机
        /// </summary>
        public string MobilePhone
        {
            get{ return _mobilephone; }
            set{ _mobilephone = value; }
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
		/// 最近更新日期
        /// </summary>
        public DateTime UpdateDate
        {
            get{ return _updatedate; }
            set{ _updatedate = value; }
        }
        
		   
	}
}