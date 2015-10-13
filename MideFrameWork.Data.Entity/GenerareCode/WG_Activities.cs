using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_Activities:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_ActivitiesEntity
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
		/// 活动标题
        /// </summary>
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
        }
        
		private int _promoterid;
		/// <summary>
		/// 发起人ID
        /// </summary>
        public int PromoterID
        {
            get{ return _promoterid; }
            set{ _promoterid = value; }
        }
        
		private string _linkman;
		/// <summary>
		/// 联系人ID
        /// </summary>
        public string LinkMan
        {
            get{ return _linkman; }
            set{ _linkman = value; }
        }
        
		private string _linkphone;
		/// <summary>
		/// LinkPhone
        /// </summary>
        public string LinkPhone
        {
            get{ return _linkphone; }
            set{ _linkphone = value; }
        }
        
		private string _activitytype;
		/// <summary>
		/// 活动类型ID
        /// </summary>
        public string ActivityType
        {
            get{ return _activitytype; }
            set{ _activitytype = value; }
        }
        
		private string _region;
		/// <summary>
		/// 区域ID
        /// </summary>
        public string Region
        {
            get{ return _region; }
            set{ _region = value; }
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
        
		private int _needmenbercount;
		/// <summary>
		/// 人员数量
        /// </summary>
        public int NeedMenberCount
        {
            get{ return _needmenbercount; }
            set{ _needmenbercount = value; }
        }
        
		private DateTime _begintime;
		/// <summary>
		/// 活动日期
        /// </summary>
        public DateTime BeginTime
        {
            get{ return _begintime; }
            set{ _begintime = value; }
        }
        
		private string _detail;
		/// <summary>
		/// 活动明细
        /// </summary>
        public string Detail
        {
            get{ return _detail; }
            set{ _detail = value; }
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