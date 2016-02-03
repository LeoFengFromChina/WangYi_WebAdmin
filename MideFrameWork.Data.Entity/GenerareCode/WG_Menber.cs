using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_Menber:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_MenberEntity
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
        
		private string _nickname;
		/// <summary>
		/// 昵称
        /// </summary>
        public string NickName
        {
            get{ return _nickname; }
            set{ _nickname = value; }
        }
        
		private string _name;
		/// <summary>
		/// 会员名称
        /// </summary>
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }
        
		private string _psw;
		/// <summary>
		/// 密码
        /// </summary>
        public string Psw
        {
            get{ return _psw; }
            set{ _psw = value; }
        }
        
		private int _scores;
		/// <summary>
		/// Scores
        /// </summary>
        public int Scores
        {
            get{ return _scores; }
            set{ _scores = value; }
        }
        
		private string _sex;
		/// <summary>
		/// 性别
        /// </summary>
        public string Sex
        {
            get{ return _sex; }
            set{ _sex = value; }
        }
        
		private string _birthday;
		/// <summary>
		/// Birthday
        /// </summary>
        public string Birthday
        {
            get{ return _birthday; }
            set{ _birthday = value; }
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
        
		private int _flag;
		/// <summary>
		/// 会员标识[游客，求助者，自愿者]
        /// </summary>
        public int Flag
        {
            get{ return _flag; }
            set{ _flag = value; }
        }
        
		private string _photourl;
		/// <summary>
		/// 头像地址
        /// </summary>
        public string PhotoUrl
        {
            get{ return _photourl; }
            set{ _photourl = value; }
        }
        
		private string _country;
		/// <summary>
		/// 国家
        /// </summary>
        public string Country
        {
            get{ return _country; }
            set{ _country = value; }
        }
        
		private string _province;
		/// <summary>
		/// 省份
        /// </summary>
        public string Province
        {
            get{ return _province; }
            set{ _province = value; }
        }
        
		private string _city;
		/// <summary>
		/// 市
        /// </summary>
        public string City
        {
            get{ return _city; }
            set{ _city = value; }
        }
        
		private string _district;
		/// <summary>
		/// 区
        /// </summary>
        public string District
        {
            get{ return _district; }
            set{ _district = value; }
        }
        
		private string _town;
		/// <summary>
		/// 镇
        /// </summary>
        public string Town
        {
            get{ return _town; }
            set{ _town = value; }
        }
        
		private string _community;
		/// <summary>
		/// 社区/小区
        /// </summary>
        public string Community
        {
            get{ return _community; }
            set{ _community = value; }
        }
        
		private string _phone;
		/// <summary>
		/// 联系电话
        /// </summary>
        public string Phone
        {
            get{ return _phone; }
            set{ _phone = value; }
        }
        
		private string _wechat;
		/// <summary>
		/// 微信号
        /// </summary>
        public string WeChat
        {
            get{ return _wechat; }
            set{ _wechat = value; }
        }
        
		private string _qq;
		/// <summary>
		/// QQ号
        /// </summary>
        public string QQ
        {
            get{ return _qq; }
            set{ _qq = value; }
        }
        
		private string _personalid;
		/// <summary>
		/// 身份证
        /// </summary>
        public string PersonalID
        {
            get{ return _personalid; }
            set{ _personalid = value; }
        }
        
		private string _address;
		/// <summary>
		/// 联系地址
        /// </summary>
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }
        
		private string _education;
		/// <summary>
		/// 学历
        /// </summary>
        public string Education
        {
            get{ return _education; }
            set{ _education = value; }
        }
        
		private string _major;
		/// <summary>
		/// 专业
        /// </summary>
        public string Major
        {
            get{ return _major; }
            set{ _major = value; }
        }
        
		private string _specialskill;
		/// <summary>
		/// 擅长技能
        /// </summary>
        public string SpecialSkill
        {
            get{ return _specialskill; }
            set{ _specialskill = value; }
        }
        
		private string _serviceintention;
		/// <summary>
		/// 服务意向
        /// </summary>
        public string ServiceIntention
        {
            get{ return _serviceintention; }
            set{ _serviceintention = value; }
        }
        
		private string _servicetimeinterval;
		/// <summary>
		/// 服务时段
        /// </summary>
        public string ServiceTimeInterval
        {
            get{ return _servicetimeinterval; }
            set{ _servicetimeinterval = value; }
        }
        
		private int _servicehours;
		/// <summary>
		/// 服务总时长
        /// </summary>
        public int ServiceHours
        {
            get{ return _servicehours; }
            set{ _servicehours = value; }
        }
        
		private int _status;
		/// <summary>
		/// 当前状态
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }
        
		private string _verification;
		/// <summary>
		/// 验证信息
        /// </summary>
        public string Verification
        {
            get{ return _verification; }
            set{ _verification = value; }
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