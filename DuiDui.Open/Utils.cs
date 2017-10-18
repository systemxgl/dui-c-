using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DuiDui.Open
{
    public class Utils
    {
        /// <summary>
        /// 生成通用请求参数
        /// </summary>
        /// <returns>?appid=&nonce=&timestamp=&signature=</returns>
        public static string GenerateParams()
        {
            if (!string.IsNullOrEmpty(PrintConfig.AppSecret) && !string.IsNullOrEmpty(PrintConfig.AppId))
            {
                string nonce = GetNonce(9);
                string timestamp = toUTP(DateTime.Now).ToString();
                string signStr = SignatureString(PrintConfig.AppSecret, timestamp, nonce);
                return string.Format("?appid={0}&nonce={1}&timestamp={2}&signature={3}", PrintConfig.AppId, nonce, timestamp, signStr);
            }
            return "请先设置AppId和AppSecret";
        }
        /// <summary>
        /// 字符串转成base64(默认 gbk编码)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringToBase64(string str)
        {
            byte[] bs = Encoding.GetEncoding("GBK").GetBytes(str);
            return Convert.ToBase64String(bs);
        }
        /// <summary>
        /// 字符串转成base64
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string StringToBase64(string str, Encoding encoding)
        {
            byte[] bs = encoding.GetBytes(str);
            return Convert.ToBase64String(bs);
        }
        /// <summary>
        /// 生成签名字符串
        /// </summary>
        /// <param name="appSecret">接入秘钥</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        static string SignatureString(string appSecret, string timestamp, string nonce)
        {
            string[] ArrTmp = { appSecret, timestamp, nonce };
            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = SHA1_Hash(tmpStr);
            return tmpStr.ToLower();
        }
        /// <summary>
        /// SHA1 加密
        /// </summary>
        /// <param name="str_sha1_in">加密字符串</param>
        /// <returns></returns>
        static string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "");
            return str_sha1_out;
        }
        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <returns></returns>
        static string GetNonce(int Length)
        {
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }
        protected static readonly DateTime unixTPStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        /// <summary>
        /// 时间转换成长整形
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        static long toUTP(DateTime dt)
        {
            TimeSpan toNow = dt.Subtract(unixTPStart);
            return (long)Math.Round(toNow.TotalSeconds);
        }
        /// <summary>
        /// 长整型转成时间
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        static DateTime fromUTP(long tp)
        {
            return unixTPStart.Add(new TimeSpan(tp * 10000000));
        }
    }
}
