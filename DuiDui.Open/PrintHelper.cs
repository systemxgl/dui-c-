using System;
using System.Collections.Generic;
using System.Text;

namespace DuiDui.Open
{
    /// <summary>
    /// 打印程序帮助类(包含api里面所有方法调用)
    /// </summary>
    public class PrintHelper
    {
        #region==用户设备绑定==
         /// <summary>
        /// 用户设备绑定
        /// </summary>
        /// <param name="uuid">设备唯一编号</param>
        /// <param name="userId">与对对机平台关联的用户唯一标示（你自己系统定义的）</param>
        /// <param name="deviceName">设备名称</param>
        /// <returns>{\"Code\":200 成功 其他失败,\"Message\":\"信息描述\",\"OpenUserId\":int类型(对对机平台用户唯一编号)}</returns>
        public static string UserBind(String uuid, String userId, String deviceName)
        {
            string url = PrintConfig.BaseUrl + "/home/userbind" + Utils.GenerateParams();
            HttpItem item = new HttpItem();
            item.URL = url;
            item.Method = "POST";
            item.ContentType = "text/json";
            item.Postdata = "{\"Uuid\":\"" + uuid + "\",\"UserId\":\"" + userId + "\",\"DeviceName\":\"" + deviceName + "\"}";
            HttpHelper helper = new HttpHelper();
            HttpResult result = helper.GetHtml(item);
            if (result != null)
            {
                return result.Html;
            }
            return string.Empty;
        }
        #endregion
        #region==获取设备状态==
        /// <summary>
        /// 获取设备状态
        /// </summary>
        /// <param name="uuid">设备编号</param>
        /// <returns>{\"Code\":200 成功 其他失败,\"Message\":\"信息描述\",\"State\":int类型(状态值(-1 错误 0 正常 1 缺纸 2 温度保护 报警 3 忙碌 4 离线))}</returns>
        public static string GetDeviceState(String uuid)
        {
            string url = PrintConfig.BaseUrl + "/home/getdevicestate" + Utils.GenerateParams();
            HttpItem item = new HttpItem();
            item.URL = url;
            item.Method = "POST";
            item.ContentType = "text/json";
            item.Postdata = "{\"Uuid\":\"" + uuid + "\"}";
            HttpHelper helper = new HttpHelper();
            HttpResult result = helper.GetHtml(item);
            if (result != null)
            {
                return result.Html;
            }
            return string.Empty;
        }
        #endregion
        #region==提交打印内容==
        /// <summary>
        /// 提交打印内容
        /// </summary>
        /// <param name="uuid">设备编号</param>
        /// <param name="content">打印内容，格式请参照接口文档三（3）</param>
        /// <param name="OpenUserId">接口三（1） 返回的OpenUserId</param>
        /// <returns>{\"Code\":200 成功 其他失败,\"Message\":\"信息描述\",\"TaskId\":Long类型(打印任务编号)}</returns>
        public static string PrintContent(String uuid, String content, Int32 OpenUserId)
        {
            string url = PrintConfig.BaseUrl + "/home/printcontent2" + Utils.GenerateParams();
            HttpItem item = new HttpItem();
            item.URL = url;
            item.Method = "POST";
            item.ContentType = "text/json";
            item.Postdata = "{\"Uuid\":\"" + uuid + "\",\"PrintContent\":'" + content + "',\"OpenUserId\":" + OpenUserId + "}";
            HttpHelper helper = new HttpHelper();
            HttpResult result = helper.GetHtml(item);
            if (result != null)
            {
                return result.Html;
            }
            return string.Empty;
        }
        #endregion            
        #region==提交打印网页内容==
        /// <summary>
        /// 提交打印网页内容
        /// </summary>
        /// <param name="uuid">设备编号</param>
        /// <param name="content">打印网页地址</param>
        /// <param name="OpenUserId">接口三（1） 返回的OpenUserId</param>
        /// <returns>{\"Code\":200 成功 其他失败,\"Message\":\"信息描述\",\"TaskId\":Long类型(打印任务编号)}</returns>
        public static string PrintHtmlContent(String uuid, String printUrl, Int32 OpenUserId)
        {
            string url = PrintConfig.BaseUrl + "/home/printhtmlcontent" + Utils.GenerateParams();
            HttpItem item = new HttpItem();
            item.URL = url;
            item.Method = "POST";
            item.ContentType = "text/json";
            item.Postdata = "{\"Uuid\":\"" + uuid + "\",\"PrintUrl\":\"" + printUrl + "\",\"OpenUserId\":" + OpenUserId + "}";
            HttpHelper helper = new HttpHelper();
            HttpResult result = helper.GetHtml(item);
            if (result != null)
            {
                return result.Html;
            }
            return string.Empty;
        }
        #region==查询打印任务状态==
        /// <summary>
        /// 查询打印任务状态
        /// </summary>
        /// <param name="taskId">任务编号（由接口文档三（3）返回所得</param>
        /// <returns>{\"Code\":200 成功 其他失败,\"Message\":\"信息描述\",\"State\":状态值(0 待处理 1 成功 2 失败 3 任务过期 4 拒绝打印)}</returns>
        public static string GetPrintTaskState(Int64 taskId)
        {
            string url = PrintConfig.BaseUrl + "/home/getprinttaskstate" + Utils.GenerateParams();
            HttpItem item = new HttpItem();
            item.URL = url;
            item.Method = "POST";
            item.ContentType = "text/json";
            item.Postdata = "{\"TaskId\":\"" + taskId + "\"}";
            HttpHelper helper = new HttpHelper();
            HttpResult result = helper.GetHtml(item);
            if (result != null)
            {
                return result.Html;
            }
            return string.Empty;
        }
        #endregion
    }
}
