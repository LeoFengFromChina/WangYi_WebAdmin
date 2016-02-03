using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_HelpRequest:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_HelpRequestEntity
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
		/// 求助标题
        /// </summary>
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
        }
        
		private int _type;
		/// <summary>
		/// 类别（1求助，2帮助）
        /// </summary>
        public int Type
        {
            get{ return _type; }
            set{ _type = value; }
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
		/// 联系人
        /// </summary>
        public string LinkMan
        {
            get{ return _linkman; }
            set{ _linkman = value; }
        }
        
		private string _linkphone;
		/// <summary>
		/// 联系电话
        /// </summary>
        public string LinkPhone
        {
            get{ return _linkphone; }
            set{ _linkphone = value; }
        }
        
		private DateTime _begintime;
		/// <summary>
		/// 求助日期
        /// </summary>
        public DateTime BeginTime
        {
            get{ return _begintime; }
            set{ _begintime = value; }
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
        
		private string _serviceintention;
		/// <summary>
		/// 服务时段
        /// </summary>
        public string ServiceIntention
        {
            get{ return _serviceintention; }
            set{ _serviceintention = value; }
        }
        
		private int _duration;
		/// <summary>
		/// 服务时长
        /// </summary>
        public int Duration
        {
            get{ return _duration; }
            set{ _duration = value; }
        }
        
		private string _detail;
		/// <summary>
		/// 服务明细
        /// </summary>
        public string Detail
        {
            get{ return _detail; }
            set{ _detail = value; }
        }
        
		private int _undertakerid;
		/// <summary>
		/// 承接者
        /// </summary>
        public int UnderTakerID
        {
            get{ return _undertakerid; }
            set{ _undertakerid = value; }
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