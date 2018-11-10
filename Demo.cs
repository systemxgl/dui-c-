using DuiDui.Open;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Demo
    {
        static void Main(string[] args)
        {
            /*
          * 引用 DuiDui.Open
          * 初始化您的appid和appsecret
          */
            PrintConfig.AppId = "您的app key";
            PrintConfig.AppSecret = "您的appsecret";

            //用户设备绑定
            PrintHelper.UserBind("您的设备编号", "您系统的用户编号（自己定义）最好是数字","设备名称");
            //查下设备状态
            PrintHelper.GetDeviceState("您的设备编号");
            //打印信息
            string content = "对对机测试订单";
            content += "\n";
            content += "单号：123456";
            //格式详见 http://www.mstching.com/home/openapi
            string jsonContent = "[{\"Alignment\":0,\"BaseText\":\"" + Utils.StringToBase64(content) + "\",\"Bold\":0,\"FontSize\":0,\"PrintType\":0}]";
            PrintHelper.PrintContent("您的设备编号", jsonContent, 0);//0 改成用户设备绑定返回的OpenUserId即可
            string printUrl = "您要打印的网页地址";//例：http://www.open.mstching.com/print-demo.html
            PrintHelper.PrintHtmlContent("您的设备编号",printUrl,0);//0 改成用户设备绑定返回的OpenUserId即可
            //查询任务状态
            PrintHelper.GetPrintTaskState(0);//0 改成任务编号即可 
        }
    }
    }
}
