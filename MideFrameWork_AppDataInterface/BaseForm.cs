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
    }



    public class RequestView
    {
        public WG_HelpRequestEntity HelpRequest { get; set; }

        public WG_MenberEntity Author { get; set; }

        public WG_MenberEntity Helper { get; set; }
    }

    [KnownType(typeof(WG_MenberEntity))]
    [KnownType(typeof(WG_HelpRequestEntity))]
    [KnownType(typeof(RequestView))]
    [KnownType(typeof(List<RequestView>))]
    [DataContract]
    [Serializable]
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