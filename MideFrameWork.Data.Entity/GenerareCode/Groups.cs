using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// Groups:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GroupsEntity
	{
      	private int _id;
		/// <summary>
		/// 分组ID
        /// </summary>
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }
        
		private string _groupname;
		/// <summary>
		/// 分组名称
        /// </summary>
        public string GroupName
        {
            get{ return _groupname; }
            set{ _groupname = value; }
        }
        
		private int _displayindex;
		/// <summary>
		/// 显示顺序
        /// </summary>
        public int DisplayIndex
        {
            get{ return _displayindex; }
            set{ _displayindex = value; }
        }
        
		private DateTime _createdate;
		/// <summary>
		/// CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }
        
		private DateTime _updatedate;
		/// <summary>
		/// UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get{ return _updatedate; }
            set{ _updatedate = value; }
        }
        
		   
	}
}