Imports System.IO
Partial Class Customer_ForgotPassword
    Inherits System.Web.UI.Page

    Public Function getMessage(ByVal dr As ds_Customer.CustomerRow) As String
        'Dim objFile As System.IO.File
        Dim objFilestream As FileStream
        Dim strMSG As String = String.Empty
        Try
            If Not File.Exists(MapPath("~") & "\MailTemplate\" & "ForgotPassword.htm") Then
                lblMessage.Text = "An error has occured while creating email message"
                getMessage = ""
                Exit Function
            End If
            objFilestream = File.OpenRead(MapPath("~") & "\MailTemplate\" & "ForgotPassword.htm")
            Dim streamReader As New StreamReader(objFilestream)
            strMSG = streamReader.ReadToEnd

            strMSG = strMSG.Replace("###USER###", (dr.FirstName & " " & dr.LastName))
            strMSG = strMSG.Replace("###USERNAME###", dr.EmailId)
            strMSG = strMSG.Replace("###PASSWORD###", dr.Password)

            streamReader.Close()
            objFilestream.Close()
            streamReader = Nothing
            objFilestream = Nothing
            getMessage = strMSG
        Catch ex As Exception
            lblMessage.Text = ex.Message
            getMessage = Nothing
            Exit Function
        End Try
    End Function

    Protected Sub BTNreterivePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReterivePassword.Click
        Try
            Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
            Dim dtCustomer As New ds_Customer.CustomerDataTable

            dtCustomer = daCustomer.GetDataByEmailId(txtEmail.Text)
            If Not dtCustomer Is Nothing Then
                If dtCustomer.Rows.Count > 0 Then
                    Dim drCustomer As ds_Customer.CustomerRow
                    drCustomer = dtCustomer.Rows(0)
                    SMSCommon.SendMail(txtEmail.Text.Trim, getMessage(drCustomer), "Password Recovery", strSMTPUSERNAME)
                    'Response.Redirect("../Home/ThankYou.aspx?MsgId=" & 2)
                    lblMessage.Text = "Mail is successfully send to your email."
                Else
                    lblMessage.Text = "User with specified email does not exists."
                    Exit Sub
                End If
            Else
                lblMessage.Text = "User with specified email does not exists."
                Exit Sub
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message
            Exit Sub
        End Try
    End Sub
End Class

