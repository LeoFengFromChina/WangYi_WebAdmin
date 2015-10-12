using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MideFrameWork.Common.DailyUtility
{
    public static class HuaXiaMD5Encode
    {

        /// <summary>
        ///  加密密码
        /// </summary>
        /// <param name="username">登录名</param>
        /// <param name="password">密码</param>
        /// <param name="timeStamp"></param>
        /// <returns>加密后的面貌</returns>
        public static string EncodePassword(string name, string password, string timeStamp)
        {
            password = MD5_16(password);
            byte[] result = new byte[4 + name.Length + 8 + password.Length + 4];

            Encoding.Default.GetBytes("1858").CopyTo(result, 0);
            Encoding.Default.GetBytes(name).CopyTo(result, 4);
            (new byte[8]).CopyTo(result, 4 + name.Length);
            Encoding.Default.GetBytes(password).CopyTo(result, 4 + name.Length + 8);
            (new byte[4]).CopyTo(result, 4 + name.Length + 8 + password.Length);
            //return MD5_32(result).ToUpper();
            return MD5_32(MD5_32(result).ToUpper() + timeStamp);
        }

        public static string MD5_16(string src)
        {
            StringBuilder result = new StringBuilder("");
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            byte[] value, hash;
            value = System.Text.Encoding.UTF8.GetBytes(src);
            hash = md.ComputeHash(value);
            md.Clear();
            for (int i = 4; i < 12; i++) //for (int i = 8; i < 16; i++)  modify by tangbaogui (old md32_16 error)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString().ToLower();
        }

        public static string MD5_32(byte[] src)
        {
            StringBuilder result = new StringBuilder("");
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            byte[] value, hash;
            value = src;
            hash = md.ComputeHash(value);
            md.Clear();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            string hh = result.ToString().ToLower();
            return result.ToString().ToLower();
        }
        private static string MD5_32(string src)
        {
            StringBuilder result = new StringBuilder("");
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            byte[] value, hash;
            value = System.Text.Encoding.UTF8.GetBytes(src);
            hash = md.ComputeHash(value);
            md.Clear();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            string hh = result.ToString().ToLower();
            return result.ToString().ToLower();
        }
    }
}
