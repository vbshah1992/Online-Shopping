<%@ Page Language="VB" MasterPageFile="~/Master/ReportMaster.master" AutoEventWireup="false"
    CodeFile="rptCustomerByOrder.aspx.vb" Inherits="Reports_rptCustomerByOrder" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center">
                Customer By Order Count Report
            </td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportViewer ID="crvCustomerByOrderCount" runat="server" AutoDataBind="true" />
            </td>
        </tr>
    </table>
</asp:Content>
