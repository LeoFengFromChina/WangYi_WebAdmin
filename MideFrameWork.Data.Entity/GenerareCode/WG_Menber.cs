﻿using System; 

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
        
		private string _region;
		/// <summary>
		/// 区域
        /// </summary>
        public string Region
        {
            get{ return _region; }
            set{ _region = value; }
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