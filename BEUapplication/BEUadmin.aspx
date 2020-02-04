<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BEUadmin.aspx.cs" Inherits="BEUapplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BEU Business Manager</title>
    <style type="text/css">
        #form1
        {
            text-align: center;
        }
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style3
        {
            width: 362px;
            text-align: left;
        }
        .style4
        {
            width: 362px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
        }
        .style5
        {
            text-align: left;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style6
        {
            width: 90px;
            text-align: left;
        }
        .style7
        {
            width: 244px;
            text-align: left;
        }
        .style8
        {
            width: 37px;
            text-align: left;
        }
    </style>
</head>
<body background="images/brick_5.gif">
    <form id="form1" runat="server">
    <table class="style1" bgcolor="#BDA88B">
        <tr>
            <td class="style2" colspan="4">
                BEU Business Manager</td>
        </tr>
        <tr>
            <td class="style4" colspan="3">
                Business Listing:</td>
            <td class="style2" style="text-align: left">
                Company Name:</td>
        </tr>
        <tr>
            <td class="style3" colspan="3" rowspan="6">
                <asp:ListBox ID="BusinessList" runat="server" Height="208px" 
                    style="text-align: justify" Width="263px" 
                    onselectedindexchanged="BusinessList_SelectedIndexChanged" 
                    DataSourceID="BEUbusinessBB1" DataTextField="listings" 
                    DataValueField="businessname"></asp:ListBox>
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                    onselecting="AccessDataSource1_Selecting">
                </asp:AccessDataSource>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="Companyname" runat="server" style="text-align: left" 
                    ontextchanged="Companyname_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Suite #:</td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:TextBox ID="SuiteNumber" runat="server" 
                    ontextchanged="SuiteNumber_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" style="text-align: left">
                Description: </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:TextBox ID="Description" runat="server" Height="96px" 
                    style="text-align: left" Width="255px" 
                    ontextchanged="Description_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" style="text-align: left">
                Opening times:</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Button ID="Confirm" runat="server" Text="Confirm" />
            </td>
            <td class="style8">
                <asp:Button ID="AddButton" runat="server" onclick="Button2_Click" Text="Add" />
            </td>
            <td class="style7">
                <asp:Button ID="RemoveButton" runat="server" onclick="Button3_Click" 
                    style="margin-left: 0px" Text="Remove" />
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="OpeningsTimes" runat="server" 
                    ontextchanged="OpeninsTimes_TextChanged"></asp:TextBox>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
