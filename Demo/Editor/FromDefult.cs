using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class FromDefult {

    [Test]
    public void SendToMyMails()
    {
        var mailService = new MailUnity.Mail();
        var list = new System.Collections.Generic.List<string>() { "zouhangtezbm@126.com", "1063627025@qq.com" };
        //群发单显参数：多接收者邮箱、内容
        mailService.AddReceivers("群发测试！", list.ToArray());

        //参数：接收者邮箱、内容
        foreach (var item in list){
            mailService.AddReceivers("单发测试" + item, item);
        }

        mailService.Send("你好01");

        ////参数：接收者邮箱、接收者名字、内容
        //mailService.Send("nuget@mayongfa.cn", "mafly", "测试邮件发送！");

        ////参数：接收者邮箱、接收者名字、邮件主题、内容
        //mailService.Send("nuget@mayongfa.cn", "mafly", "邮件发送", "测试邮件发送！");

        ////使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容
        //mailService.Send(new MailInfo
        //{
        //    Receiver = "nuget@mayongfa.cn",
        //    ReceiverName = "mafly",
        //    Subject = "邮件发送",
        //    Body = "测试邮件发送！"
        //});

        ////使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容、附件路径
        //mailService.Send(
        //    new MailInfo
        //    {
        //        Receiver = "nuget@mayongfa.cn",
        //        ReceiverName = "mafly",
        //        Subject = "带附件邮件发送",
        //        Body = "测试带附件邮件发送！"
        //    }, "../../Program.cs");

        ////使用MailInfo对象模式  参数：接收者邮箱、接收者名字、邮件主题、内容、多附件路径
        //mailService.Send(
        //    new MailInfo
        //    {
        //        Receiver = "nuget@mayongfa.cn",
        //        ReceiverName = "mafly",
        //        Subject = "带附件邮件发送",
        //        Body = "测试带附件邮件发送！"
        //    }, new Attachment("../../Program.cs"), new Attachment("../../App.config"));

    }
}
