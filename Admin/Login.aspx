<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Login.aspx.vb" Inherits="Admin_Login" Title="Login" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <h2 align="center" class="heading">
        Login</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ForeColor="#C04000" ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Email Id</td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" ErrorMessage="Please enter email id."
                    ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="revEmailId" runat="server" ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Please enter valid email id." ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password."
                    ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnLogIn" runat="server" Text="Login" ValidationGroup="vgLogIn" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:LinkButton ID="lnkForgotPassword" runat="server">Forgot Password?</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsLogIn" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True"
                    ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>
