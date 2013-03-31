<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master" AutoEventWireup="false"
    CodeFile="ForgotPassword.aspx.vb" Inherits="Customer_ForgotPassword" Title="Recover My Password" %>

<asp:Content ID="ContentForgotPassword" ContentPlaceHolderID="cphCustomer" runat="Server">
    <table id="TBLaddDeal" align="center" runat="server" class="text">
        <tr>
            <td colspan="2" align="center">
            <h2 class="heading">
                Forgot Password
                </h2>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please enter correct email."
                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="ForgotPassword">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RFVemail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Please enter email." ValidationGroup="ForgotPassword">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnReterivePassword" runat="server" Text="Reterive Password" ValidationGroup="ForgotPassword" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsForgotPassword" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="ForgotPassword" />
            </td>
        </tr>
    </table>
</asp:Content>
