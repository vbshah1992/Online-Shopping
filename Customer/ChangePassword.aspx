<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master"AutoEventWireup="false"
    CodeFile="ChangePassword.aspx.vb" Inherits="Customer_ChangePassword" Title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCustomer" runat="Server">
    <h2 align="center" class="heading">
        Change Password</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" ForeColor="black" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Old Password</td>
            <td>
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword" ErrorMessage="Please enter old password."
                    ValidationGroup="vgChagePassword">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                New Password</td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="Please enter new password."
                    ValidationGroup="vgChagePassword">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password</td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                    ErrorMessage="Please enter confirm password." InitialValue="0" ValidationGroup="vgChagePassword">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtNewPassword"
                    ControlToValidate="txtConfirmPassword" ErrorMessage="New Password and confirm password does not match."
                    ValidationGroup="vgChagePassword">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnChagePassword" runat="server" Text="Chage Password" ValidationGroup="vgChagePassword" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsChangePassword" runat="server" ValidationGroup="vgChagePassword"
                    ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>
