﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using MideFrameWork.Data;
using MideFrameWork.Data.Entity;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Data;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    public class BaseForm
    {
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, t);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }

        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }


        public static bool AddNoticeToWG(string title, string content, string userIDs, int noticeType = 0, int linkID = 0)
        {
            #region 通知用户主程成功，等待审核 add by frde 20160130

            NoticeEntity ne = new NoticeEntity();
            ne.FromUserID = 0;
            ne.ToUserID = userIDs;
            ne.Title = title;
            ne.NoticeType = noticeType;//1求助帮助，2.活动类型，3.礼物类型
            ne.LinkId = linkID;
            ne.CreateDate = DateTime.Now;
            ne.NoticeContent = content;

            //给用户一条消息
            DataProvider.GetInstance().AddNotice(ne);

            #endregion
            return true;
        }
    }



    [KnownType(typeof(DateTime))]
    [KnownType(typeof(WG_MenberEntity))]
    [KnownType(typeof(WG_HelpRequestEntity))]
    [KnownType(typeof(RequestView))]
    [KnownType(typeof(List<RequestView>))]
    [KnownType(typeof(List<MenberRankingView>))]
    [KnownType(typeof(List<OnGoingGiftsView>))]
    [KnownType(typeof(List<WG_GiftsEntity>))]
    [KnownType(typeof(List<GlobalPictureEntity>))]
    [KnownType(typeof(List<WG_ActivitiesEntity>))]
    [KnownType(typeof(List<NoticeEntity>))]
    [KnownType(typeof(List<WG_TeamEntity>))]
    [KnownType(typeof(List<WG_MenberEntity>))]
    [KnownType(typeof(WG_MenberEntityView))]
    [KnownType(typeof(List<PrivilegeViewEntity>))]
    [KnownType(typeof(ServiceIntentionView))]
    [KnownType(typeof(List<ServiceIntentionView>))]
    [KnownType(typeof(List<RegionView>))]
    [KnownType(typeof(List<WG_VenderEntity>))]
    [KnownType(typeof(List<WG_CommunityNewsEntity>))]
    [DataContract]
    public class JsonBaseObject
    {
        private int _code;
        private string _message;
        private bool _success;
        private object _data;

        [DataMember]
        public int code
        {
            get { return _code; }
            set { _code = value; }
        }

        [DataMember]
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        [DataMember]
        public bool success
        {
            get { return _success; }
            set { _success = value; }
        }

        [DataMember]
        public object data
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}