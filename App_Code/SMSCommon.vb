Imports Microsoft.VisualBasic
Imports System.Security
Imports System.Web.Mail

Public Module SMSCommon
    '    __________________________________________________________________________________
    'PASSWORD-ENCRIPTION
    '__________________________________________________________________________________

    Public sKey As String = "x5S#p9V@"

    Function TripleDESEncode(ByVal value As String) As String
        Dim des As New System.Security.Cryptography.TripleDESCryptoServiceProvider
        des.IV = New Byte(7) {}
        Dim pdb As New System.Security.Cryptography.PasswordDeriveBytes(sKey, New Byte(-1) {})
        des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, New Byte(7) {})
        Dim ms As New IO.MemoryStream((value.Length * 2) - 1)
        Dim encStream As New System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
        Dim plainBytes As Byte() = Text.Encoding.UTF8.GetBytes(value)
        encStream.Write(plainBytes, 0, plainBytes.Length)
        encStream.FlushFinalBlock()
        Dim encryptedBytes(CInt(ms.Length - 1)) As Byte
        ms.Position = 0
        ms.Read(encryptedBytes, 0, CInt(ms.Length))
        encStream.Close()
        Return Convert.ToBase64String(encryptedBytes)
    End Function

    Function TripleDESDecode(ByVal value As String) As String
        Dim des As New System.Security.Cryptography.TripleDESCryptoServiceProvider
        des.IV = New Byte(7) {}
        Dim pdb As New System.Security.Cryptography.PasswordDeriveBytes(sKey, New Byte(-1) {})
        des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, New Byte(7) {})
        Dim encryptedBytes As Byte() = Convert.FromBase64String(value)
        Dim ms As New IO.MemoryStream(value.Length)
        Dim decStream As New System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()
        Dim plainBytes(CInt(ms.Length - 1)) As Byte
        ms.Position = 0
        ms.Read(plainBytes, 0, CInt(ms.Length))
        decStream.Close()
        Return Text.Encoding.UTF8.GetString(plainBytes)
    End Function

    '__________________________________________________________________________________
    'EMAIL- SENDING
    '__________________________________________________________________________________

    Public sMailTemplatesPath As String = System.Configuration.ConfigurationManager.AppSettings("MailTemplatePath")
    Public strSMTP As String = System.Configuration.ConfigurationManager.AppSettings("SMTP")
    Public strSMTPUSERNAME As String = System.Configuration.ConfigurationManager.AppSettings("SMTPUSERNAME")
    Public strSMTPPSW As String = System.Configuration.ConfigurationManager.AppSettings("SMTPPSW")

    Sub SendMail(ByVal emailid As String, ByVal strMsg As String, ByVal Subject As String, Optional ByVal strFromEmail As String = vbNullString, Optional ByVal CCEMAIL As String = vbNullString, Optional ByVal Priority As String = "")
        Try
            Dim cdoBasic As Int16 = 1
            Dim cdoSendUsingPort As Int16 = 25
            Dim msg As New Mail.MailMessage

            If strSMTPUSERNAME.Length > 0 Then
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", strSMTP)
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", cdoSendUsingPort)
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", cdoBasic)
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", strSMTPUSERNAME)
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", strSMTPPSW)
            End If
            If CCEMAIL <> vbNullString Then
                msg.Cc = CCEMAIL
            End If
            msg.BodyFormat = MailFormat.Html
            msg.To = emailid
            msg.From = strFromEmail
            msg.Subject = Subject
            msg.Body = strMsg
            SmtpMail.SmtpServer = strSMTP
            SmtpMail.Send(msg)
        Catch ex As Exception
            'Throw (ex)
        End Try
    End Sub



End Module
