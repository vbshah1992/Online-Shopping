<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Country.aspx.vb" Inherits="Admin_Country" Title="Country" Theme="AdminTheme" %>

<asp:Content ContentPlaceHolderID="cphAdmin" runat="server">
     <h2 align="center" class="heading">
        Country</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Country
            </td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Please enter country."
                    ControlToValidate="txtCountry" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCountry" runat="server" ControlToValidate="txtCountry"
                    ErrorMessage="Please enter valid country." ValidationExpression="[A-Z,a-z, ]*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsCountry" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>
