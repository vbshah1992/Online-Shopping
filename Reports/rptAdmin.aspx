<%@ Page Language="VB" MasterPageFile="~/Master/ReportMaster.master" AutoEventWireup="false" CodeFile="rptAdmin.aspx.vb" Inherits="Reports_rptAdmin" title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<table width="100%" class="text">
        <tr>
            <td align="center">
                Admin Report
            </td>
        </tr>      
        <tr>
            <td>
                <CR:CrystalReportViewer ID="crvAdmin" runat="server" AutoDataBind="true" />                
            </td>
        </tr>
    </table>
</asp:Content>

