<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cltCategoryMenu.ascx.vb" Inherits="Controls_cltCategoryMenu" %>
<table>
    <tr>
        <td valign="top">
            <skm:Menu runat="server" ID="mnuCategory" cssclass="left_menuodda" Layout="Vertical">
                <SelectedMenuItemStyle CssClass="left_menuahover"></SelectedMenuItemStyle>
                <UnselectedMenuItemStyle  CssClass="left_menuevena"></UnselectedMenuItemStyle>
            </skm:Menu>
        </td>
    </tr>
</table>