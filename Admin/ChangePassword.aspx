<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false" Theme="AdminTheme" CodeFile="ChangePassword.aspx.vb" Inherits="Admin_ChangePassword" title="Change Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <h2 align="center" class="heading">
        Change Password</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>        
        <tr>
            <td>
                Old Password</td>
            <td>
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword"
                    ErrorMessage="Please enter Old password." ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                New Password</td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="Please enter New password." ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>
                Confirm Password</td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                    ErrorMessage="Please enter confirm password." InitialValue="0" ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtNewPassword"
                    ControlToValidate="txtConfirmPassword" ErrorMessage="New Password and confirm password does not match."
                    ValidationGroup="vgChangePassword">*</asp:CompareValidator></td>
        </tr>        
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" ValidationGroup="vgChangePassword" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsChangePassword" runat="server" ValidationGroup="vgChangePassword" ShowMessageBox="True"
                    ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>

