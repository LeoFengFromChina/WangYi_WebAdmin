using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// V_UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class V_UserInfoEntity
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
		/// NickName
        /// </summary>
        public string NickName
        {
            get{ return _nickname; }
            set{ _nickname = value; }
        }
        
		private string _username;
		/// <summary>
		/// username
        /// </summary>
        public string username
        {
            get{ return _username; }
            set{ _username = value; }
        }
        
		private string _avatar_url;
		/// <summary>
		/// avatar_url
        /// </summary>
        public string avatar_url
        {
            get{ return _avatar_url; }
            set{ _avatar_url = value; }
        }
        
		private DateTime _create_at;
		/// <summary>
		/// create_at
        /// </summary>
        public DateTime create_at
        {
            get{ return _create_at; }
            set{ _create_at = value; }
        }
        
		private int _score;
		/// <summary>
		/// score
        /// </summary>
        public int score
        {
            get{ return _score; }
            set{ _score = value; }
        }
        
		private string _gender;
		/// <summary>
		/// gender
        /// </summary>
        public string gender
        {
            get{ return _gender; }
            set{ _gender = value; }
        }
        
		private string _qqnumber;
		/// <summary>
		/// QQnumber
        /// </summary>
        public string QQnumber
        {
            get{ return _qqnumber; }
            set{ _qqnumber = value; }
        }
        
		private string _phonenumber;
		/// <summary>
		/// phonenumber
        /// </summary>
        public string phonenumber
        {
            get{ return _phonenumber; }
            set{ _phonenumber = value; }
        }
        
		private string _region;
		/// <summary>
		/// region
        /// </summary>
        public string region
        {
            get{ return _region; }
            set{ _region = value; }
        }
        
		private string _personalid;
		/// <summary>
		/// PersonalID
        /// </summary>
        public string PersonalID
        {
            get{ return _personalid; }
            set{ _personalid = value; }
        }
        
		private string _address;
		/// <summary>
		/// Address
        /// </summary>
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }
        
		private string _weixinnumber;
		/// <summary>
		/// weixinNumber
        /// </summary>
        public string weixinNumber
        {
            get{ return _weixinnumber; }
            set{ _weixinnumber = value; }
        }
        
		private string _education;
		/// <summary>
		/// education
        /// </summary>
        public string education
        {
            get{ return _education; }
            set{ _education = value; }
        }
        
		private string _profession;
		/// <summary>
		/// profession
        /// </summary>
        public string profession
        {
            get{ return _profession; }
            set{ _profession = value; }
        }
        
		private string _speciality;
		/// <summary>
		/// speciality
        /// </summary>
        public string speciality
        {
            get{ return _speciality; }
            set{ _speciality = value; }
        }
        
		private string _intention;
		/// <summary>
		/// intention
        /// </summary>
        public string intention
        {
            get{ return _intention; }
            set{ _intention = value; }
        }
        
		private string _psw;
		/// <summary>
		/// psw
        /// </summary>
        public string psw
        {
            get{ return _psw; }
            set{ _psw = value; }
        }
        
		   
	}
}