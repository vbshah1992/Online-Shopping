<%@ Page Language="VB" MasterPageFile="~/Master/ReportMaster.master" AutoEventWireup="false" CodeFile="rptCompanyByProduct.aspx.vb" Inherits="Reports_rptCompanyByProduct"  %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
   <asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <table width="100%">
        <tr>
            <td align="center">
                Company By Product Count Report
            </td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportViewer ID="crvCompanyByProductCount" runat="server" AutoDataBind="true" />
            </td>
        </tr>
    </table>
</asp:Content>

