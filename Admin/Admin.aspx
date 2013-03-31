<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Admin.aspx.vb" Inherits="Admin_Admin" Title="Admin" Theme="AdminTheme" %>

<asp:Content ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 align="center" class="heading">
                Admin</h2>
            <table align="center" class="text">
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="Please enter first name." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFirstName" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="Please enter valid first name." ValidationExpression="[A-Z,a-z, ]*"
                            ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Name</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                            ErrorMessage="Please enter last name." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revLastName" runat="server" ControlToValidate="txtLastName"
                            ErrorMessage="Please enter valid last name." ValidationExpression="[A-Z,a-z, ]*"
                            ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>
                        Date Of Birth</td>
                    <td>
                        <asp:TextBox ID="txtDateOfBirth" runat="server">
                        </asp:TextBox>
                        <asp:ImageButton runat="Server" ID="imgCalendar1" ImageUrl="~/Images/Calendar.png"
                            AlternateText="Click to show calendar" /><br />
                        <atk:CalendarExtender ID="calendarButtonExtender1" runat="server" TargetControlID="txtDateOfBirth"
                            PopupButtonID="imgCalendar1" />
                        <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth"
                            ErrorMessage="Please enter date of birth." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth"
                            ErrorMessage="Please enter valid date of birth." ValidationGroup="vgLogIn" Operator="DataTypeCheck"
                            Type="Date">*</asp:CompareValidator></td>
                </tr>
                <tr>
                    <td>
                        Address</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="150px">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                            ErrorMessage="Please enter address." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Country
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" Width="155px">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                            ErrorMessage="Please select country." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        State
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" Width="155px">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                            ErrorMessage="Please select state." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        City
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" Width="155px">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                            ErrorMessage="Please select city." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Pincode
                    </td>
                    <td>
                        <asp:TextBox ID="txtPincode" runat="server">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvPincode" runat="server" ControlToValidate="txtPincode"
                            ErrorMessage="Please enter pin code." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="revPincode" runat="server" ControlToValidate="txtPincode" ErrorMessage="Please enter valid pincode."
                                ValidationExpression="[0-9, ]*" ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>
                        Phone Number</td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumber" runat="server">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                            ErrorMessage="Please enter phone number" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Please enter valid phone number"
                                ValidationExpression="\w{10}" ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>
                        Contact Number</td>
                    <td>
                        <asp:TextBox ID="txtContactNumber" runat="server">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ControlToValidate="txtContactNumber"
                            ErrorMessage="Please enter contact Number." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="revContactNumber" runat="server" ErrorMessage="Please enter valid contact number"
                                ValidationExpression="\w{10}" ValidationGroup="vgLogIn" ControlToValidate="txtContactNumber">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>
                        Email Id</td>
                    <td>
                        <asp:TextBox ID="txtEmailId" runat="server">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId"
                            ErrorMessage="Please enter email id." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="revEmailId" runat="server" ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="Please enter valid email id." ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>
                        Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px">
                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Please enter password." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator><asp:RangeValidator
                                ID="rvPassword" runat="server" ErrorMessage="Please enter password between 4 to 20 characters."
                                ControlToValidate="txtPassword" ValidationGroup="vgSave">*</asp:RangeValidator></td>
                </tr>
                <tr>
                    <td>
                        Confirm Password</td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="150px">
                        </asp:TextBox><asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" ErrorMessage="Password and confirm password does not match."
                            ValidationGroup="vgLogIn">*</asp:CompareValidator></td>
                </tr>
                <tr>
                    <td>
                        Is Active</td>
                    <td>
                        <asp:CheckBox ID="chkIsActive" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="vsAdmin" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True"
                            ShowSummary="False" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
