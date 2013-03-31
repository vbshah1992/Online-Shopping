<%@ Page Language="VB" MasterPageFile="~/Master/ReportMaster.master" AutoEventWireup="false" CodeFile="rpt_MonthlyOrder.aspx.vb" Inherits="Reports_rpt_MonthlyOrder" title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<table width="100%" class="text">
        <tr>
            <td align="center">
                Monthly Feedback Report
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ib1" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" /><br />
                <atk:CalendarExtender ID="ce1" runat="server" TargetControlID="txtDate" PopupButtonID="ic2" Format="MMM-yyyy" />
                <asp:Button runat="server" ID="btnSearch" Text="Search" />
            </td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportViewer ID="crvMonthlyOrder" runat="server" AutoDataBind="true" />
                
            </td>
        </tr>
    </table>
</asp:Content>

