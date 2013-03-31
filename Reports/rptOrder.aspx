<%@ Page Language="VB" MasterPageFile="~/Master/ReportMaster.master" AutoEventWireup="false"
    CodeFile="rptOrder.aspx.vb" Inherits="Reports_rptOrder" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center">
                Order Report
            </td>
        </tr>
        <tr>
            <td>
                From Date :
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ic1" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" /><br />
                <atk:CalendarExtender ID="cbe1" runat="server" TargetControlID="txtStartDate" PopupButtonID="ic1" />
                &nbsp; To Date :
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ic2" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" /><br />
                <atk:CalendarExtender ID="ce2" runat="server" TargetControlID="txtEndDate" PopupButtonID="ic2" />
                <asp:Button runat="server" ID="btnSearch" Text="Search" />
            </td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportViewer ID="crvOrder" runat="server" AutoDataBind="true" />
            </td>
        </tr>
    </table>
</asp:Content>
