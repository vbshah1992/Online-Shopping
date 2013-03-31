<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="State.aspx.vb" Inherits="Admin_State" Title="State" Theme="AdminTheme" %>

<asp:Content ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
   <h2 align="center" class="heading">
        State</h2>
    <table align="center" class="text">
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                State
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtState"
                    ErrorMessage="Please enter state." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revState" runat="server" ControlToValidate="txtState"
                    ErrorMessage="Please enter valid state." ValidationExpression="[A-Z,a-z, ]*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                Country
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                    ErrorMessage="Please select country." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsState" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
