using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_Team:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_TeamEntity
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
        
		private string _name;
		/// <summary>
		/// 团队名称
        /// </summary>
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }
        
		private int _captainid;
		/// <summary>
		/// 队长ID
        /// </summary>
        public int CaptainID
        {
            get{ return _captainid; }
            set{ _captainid = value; }
        }
        
		private int _linkmanid;
		/// <summary>
		/// 联系人ID
        /// </summary>
        public int LinkManID
        {
            get{ return _linkmanid; }
            set{ _linkmanid = value; }
        }
        
		private string _teamaim;
		/// <summary>
		/// 团队宗旨
        /// </summary>
        public string TeamAim
        {
            get{ return _teamaim; }
            set{ _teamaim = value; }
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
        
		private string _region;
		/// <summary>
		/// 区域
        /// </summary>
        public string Region
        {
            get{ return _region; }
            set{ _region = value; }
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