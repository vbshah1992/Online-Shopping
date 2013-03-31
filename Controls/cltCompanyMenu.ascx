<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cltCompanyMenu.ascx.vb" Inherits="Controls_cltCompanyMenu" %>
<table>
    <tr>
        <td valign="top">
            <skm:Menu runat="server" ID="mnuCompany" Layout="Vertical" CssClass="left_menuodda">
                <SelectedMenuItemStyle CssClass="left_menuahover"></SelectedMenuItemStyle>
                <UnselectedMenuItemStyle  CssClass="left_menuevena"></UnselectedMenuItemStyle>
            </skm:Menu>
        </td>
    </tr>
</table>