using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// Base_Privilege:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Base_PrivilegeEntity
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
        
		private int _moduleid;
		/// <summary>
		/// 模块ID
        /// </summary>
        public int ModuleID
        {
            get{ return _moduleid; }
            set{ _moduleid = value; }
        }
        
		private int _buttonid;
		/// <summary>
		/// 操作ID
        /// </summary>
        public int ButtonID
        {
            get{ return _buttonid; }
            set{ _buttonid = value; }
        }
        
		private int _createrid;
		/// <summary>
		/// 创建者ID
        /// </summary>
        public int CreaterID
        {
            get{ return _createrid; }
            set{ _createrid = value; }
        }
        
		private int _updaterid;
		/// <summary>
		/// 更新者ID
        /// </summary>
        public int UpdaterID
        {
            get{ return _updaterid; }
            set{ _updaterid = value; }
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