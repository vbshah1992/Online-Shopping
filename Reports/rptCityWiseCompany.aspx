<%@ Page Language="VB" MasterPageFile="~/Master/ReportMaster.master" AutoEventWireup="false"
    CodeFile="rptCityWiseCompany.aspx.vb" Inherits="Reports_rptCityWiseCompany" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center">
                City Wise Company Report
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList runat="server" ID="ddlCity">
                </asp:DropDownList>
                <asp:Button runat="server" ID="btnSearch" Text="Search" />
            </td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportViewer ID="crvCompany" runat="server" AutoDataBind="true" />
            </td>
        </tr>
    </table>
</asp:Content>
