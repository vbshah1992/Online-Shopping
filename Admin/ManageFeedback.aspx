<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    Theme="AdminTheme" CodeFile="ManageFeedback.aspx.vb" Inherits="Admin_ManageFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Feedback</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Label runat="server" ForeColor="#C04000" ID="lblMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkFeedback" NavigateUrl="~/Admin/Feedback.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="heading">
                From Date :
                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ic1" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" />
                <atk:CalendarExtender ID="cbe1" runat="server" TargetControlID="txtFromDate" PopupButtonID="ic1" />
                &nbsp; To Date :
                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ic2" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" />
                <atk:CalendarExtender ID="ce2" runat="server" TargetControlID="txtToDate" PopupButtonID="ic2" /><br />
                Customer : &nbsp;<asp:DropDownList ID="ddlCustomer" runat="server">
                </asp:DropDownList>
                &nbsp; &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvFeedback" runat="server" EnableSortingAndPagingCallbacks="True"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="FeedbackId"
                    DataSourceID="odsFeedback">
                    <Columns>
                        <asp:BoundField DataField="Feedback" HeaderText="Feedback" SortExpression="Feedback" />
                        <asp:BoundField DataField="FeedbackDate" HeaderText="Feedback Date" SortExpression="FeedbackDate"
                            DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField="FirstName" HeaderText="Customer" SortExpression="FirstName" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="FeedbackId,Feedback" DataNavigateUrlFormatString="~/Admin/Feedback.aspx?Id={0}&amp;Feedback={1}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsFeedback" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="ds_FeedbackTableAdapters.FeedbackTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_FeedbackId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Feedback" Type="String" />
                        <asp:Parameter Name="FeedbackDate" Type="DateTime" />
                        <asp:Parameter Name="CustomerId" Type="Int64" />
                        <asp:Parameter Name="Original_FeedbackId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Feedback" Type="String" />
                        <asp:Parameter Name="FeedbackDate" Type="DateTime" />
                        <asp:Parameter Name="CustomerId" Type="Int64" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Button ID="btnExport" runat="server" Text="Export" />
            </td>
        </tr>
    </table>
</asp:Content>
