using System;
using System.Collections.Generic;
using System.Text;

namespace DuiDui.Open
{
    public class PrintConfig
    {
        /// <summary>
        /// 对应开发者申请的AppKey
        /// </summary>
        public static string AppId { get; set; }
        /// <summary>
        /// 对应开发者申请的AppSecret
        /// </summary>
        public static string AppSecret { get; set; }
        /// <summary>
        /// 请求开放平台的Domain
        /// </summary>
        public static readonly string BaseUrl = "http://www.open.mstching.com";
    }
}
