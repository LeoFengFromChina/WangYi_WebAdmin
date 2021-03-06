﻿using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// GlobalPicture:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GlobalPictureEntity
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
        
		private string _showtextcn;
		/// <summary>
		/// ShowTextCN
        /// </summary>
        public string ShowTextCN
        {
            get{ return _showtextcn; }
            set{ _showtextcn = value; }
        }
        
		private string _showtexten;
		/// <summary>
		/// ShowTextEN
        /// </summary>
        public string ShowTextEN
        {
            get{ return _showtexten; }
            set{ _showtexten = value; }
        }
        
		private string _iconurl;
		/// <summary>
		/// IconUrl
        /// </summary>
        public string IconUrl
        {
            get{ return _iconurl; }
            set{ _iconurl = value; }
        }
        
		private string _linkurl;
		/// <summary>
		/// LinkUrl
        /// </summary>
        public string LinkUrl
        {
            get{ return _linkurl; }
            set{ _linkurl = value; }
        }
        
		private int _isenable;
		/// <summary>
		/// IsEnable
        /// </summary>
        public int IsEnable
        {
            get{ return _isenable; }
            set{ _isenable = value; }
        }
        
		private int _displayindex;
		/// <summary>
		/// DisplayIndex
        /// </summary>
        public int DisplayIndex
        {
            get{ return _displayindex; }
            set{ _displayindex = value; }
        }
        
		private int _groupid;
		/// <summary>
		/// GroupID
        /// </summary>
        public int GroupID
        {
            get{ return _groupid; }
            set{ _groupid = value; }
        }
        
		private int _ownerid;
		/// <summary>
		/// OwnerID
        /// </summary>
        public int OwnerID
        {
            get{ return _ownerid; }
            set{ _ownerid = value; }
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