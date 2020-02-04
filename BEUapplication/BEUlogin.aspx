<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BEUlogin.aspx.cs" Inherits="BEUapplication.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 66%;
            background-color: #BDA88B;
            height: 152px;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style3
        {
            text-align: right;
        }
        .style4
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style5
        {
            width: 432px;
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            height: 32px;
        }
        .style6
        {
            height: 32px;
        }
        #form1
        {
            text-align: center;
        }
    </style>
</head>
<body background="images/brick_5.gif">
    <form id="form1" runat="server">
    <div style="height: 154px; background-color: #FFFFFF; width: 219px; text-align: center;" 
        align="center">
    
        <table class="style1" align="center">
            <tr>
                <td class="style2">
                    BEU adminstrative login</td>
            </tr>
            <tr>
                <td class="style4" style="text-align: center">
                    <asp:Login ID="Login1" runat="server" style="text-align: center" 
                        onauthenticate="Login1_Authenticate">
                    </asp:Login>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
