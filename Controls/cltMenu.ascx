<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cltMenu.ascx.vb" Inherits="Controls_cltMenu" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td valign="top">
                    <skm:Menu runat="server" ID="mnuAdmin" Layout="Horizontal" Width="950px" CssClass="mainmenuli">
                        <SelectedMenuItemStyle CssClass="mainmenuliahover"></SelectedMenuItemStyle>
                        <UnselectedMenuItemStyle CssClass="mainmenulia"></UnselectedMenuItemStyle>
                    </skm:Menu>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
