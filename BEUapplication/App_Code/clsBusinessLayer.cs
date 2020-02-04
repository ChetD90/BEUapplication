using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;

/// <summary>
/// Summary description for clsBusinessLayer
/// </summary>
public class clsBusinessLayer
{
   
public static bool SendEmail(string Sender, string Recipient, string bcc, string cc,
string Subject, string Body)
{
try {


MailMessage MyMailMessage = new MailMessage();


MyMailMessage.From = new MailAddress(Sender);


MyMailMessage.To.Add(new MailAddress(Recipient));


if (bcc != null && bcc != string.Empty) {

MyMailMessage.Bcc.Add(new MailAddress(bcc));
}


if (cc != null && cc != string.Empty) {

MyMailMessage.CC.Add(new MailAddress(cc));
}


MyMailMessage.Subject = Subject;


MyMailMessage.Body = Body;


MyMailMessage.IsBodyHtml = true;


MyMailMessage.Priority = MailPriority.Normal;


SmtpClient MySmtpClient = new SmtpClient();


MySmtpClient.Port = 25;
MySmtpClient.Host = "127.0.0.1";

 
MySmtpClient.Send(MyMailMessage);


return true;
} catch (Exception ex) {


return false;
}

}
	}

