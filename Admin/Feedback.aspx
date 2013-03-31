<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Feedback.aspx.vb" Inherits="Admin_Feedback" Title="Feedback" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
    <h2 align="center" class="heading">
        Feedback</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Feedback</td>
            <td>
                <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFeedback" runat="server" ControlToValidate="txtFeedback"
                    ErrorMessage="Please enter feedback." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Feedback Date</td>
            <td>
                <asp:TextBox ID="txtFeedbackDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="imgCalendar4" ImageUrl="~/Images/Calendar.png"
                    AlternateText="Click to show calendar" /><br />
                <atk:CalendarExtender ID="calendarButtonExtender4" runat="server" TargetControlID="txtFeedbackDate"
                    PopupButtonID="imgCalendar4" />
                <asp:RequiredFieldValidator ID="rfvFeedbackDate" runat="server" ControlToValidate="txtFeedbackDate"
                    ErrorMessage="Please enter feedback date." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvFeedbackDate" runat="server" ControlToValidate="txtFeedbackDate"
                    ErrorMessage="Please enter valid feedback date." ValidationGroup="vgLogIn" Operator="DataTypeCheck"
                    Type="Date">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td>
                Customer
            </td>
            <td>
                <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCustomer" runat="server" ControlToValidate="ddlCustomer"
                    ErrorMessage="Please select customer." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsFeedback" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True"
                    ShowSummary="False" />
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
