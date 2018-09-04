Imports System.Configuration
Imports System.Web.Security
Imports System.Web.UI 
Imports System.Web.UI.WebControls 
Imports System.Web.UI.WebControls.WebParts 
Imports System.Web.UI.HtmlControls 


Imports System.Security
Imports System.Security.Principal.WindowsIdentity
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Management
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Reflection
Imports System.Runtime.InteropServices
'Imports Outlook = Microsoft.Office.Interop.Outlook
'Imports Microsoft.Office.Core
Imports Microsoft.Win32
Imports System.Web
Imports System.Web.Mail
Imports System.Net.WebRequestMethods

Public Delegate Sub DisplayInvoker(ByVal t As String)

Public Class MailAt


    Public Shared Sub MailGonder_DısTicaret_Kütük_ALım(ByVal ADRES As String, ByVal ADSOYAD As String, ByVal ACIKLAMA As String)

        Dim mailack, MailGittimi
        Dim BAslıkMesajı, SubjectMesajı, mailsmtp
        MailGittimi = "H"

        Try
            Dim message As New System.Web.Mail.MailMessage
            mailack = "FILMASIN HADDEHANESI YURT DISINDAN ALINAN KUTUK BILGILERI "

            Dim mesaj = "<body>" _
                      & "<font FACE='Agency FB'>" _
                      & "<p></p>" _
                      & "</font><font FACE='Agency FB' SIZE='4' >" _
                      & "<p>" & "Sayın " & ADSOYAD & ",</p>" _
                      & "<p ALIGN='JUSTIFY'></p>" _
                      & "<p ALIGN='JUSTIFY'>" _
                      & " FILMASIN HADDEHANESI YURT DISINDAN ALINAN KUTUK BILGILERI Aşağıdaki gibidir. " _
                      & "<b>" _
                      & "<font color=red><p></font> " & ACIKLAMA & "</p>" _
                      & "<p></p>" _
                      & "</font>" _
                      & "</body>"

            With message

                .From = "eys@dilerhld.com"
                .To = ADRES ' "adnanguler@dilerhld.com" 
                .Subject = mailack
                .Body = mesaj

                .BodyFormat = Web.Mail.MailFormat.Html
                ' For authentication...
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "DILEREXCH.dilerhld.com")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eys")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "Eee")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 specifies NTLM, 1 for basic, 0 for none
            End With

            Dim smtp As System.Web.Mail.SmtpMail
            smtp.SmtpServer = mailsmtp
            smtp.Send(message)
            MailGittimi = "E"

        Catch

            MailGittimi = "H"
            'MessageBox.Show("E-mail gönderilemedi", "Smtp Mail", MessageBoxButtons.OK)
            'AspNetMsgFunc("E-mail gönderilemedi", "Smtp Mail")

        End Try

    End Sub

    Public Shared Sub MailGonder_as400_Kütük_GIRIS(ByVal ADRES As String, ByVal ADSOYAD As String, ByVal ACIKLAMA As String)

        Dim mailack, MailGittimi
        Dim BAslıkMesajı, SubjectMesajı, mailsmtp
        MailGittimi = "H"

        Dim Attachment As System.Web.Mail.MailAttachment
        Dim message As New System.Web.Mail.MailMessage

        Dim resource As LinkedResource
        Dim View As AlternateView


        Dim FilePath As String
        FilePath = System.Web.HttpContext.Current.Server.MapPath("~/Imza/turgayener.jpg")
        Attachment = New MailAttachment(FilePath)
        message.Attachments.Add(Attachment)


        ''link the resource to embed
        'resource = New LinkedResource((System.Web.HttpContext.Current.Server.MapPath("Imza\turgayener.jpg")))
        ''name the resource
        'resource.ContentId = "Image1"
        ''add the resource to the alternate view
        'View.LinkedResources.Add(resource)


        Try
            mailack = "AS400 SİSTEMİNE DEMİR TALEBİ GİRİŞ - (GEBZE - FABRIKA)"

            Dim mesaj1 = "<body>" _
                      & "<font FACE='Agency FB'>" _
                      & "<p></p>" _
                      & "</font><font FACE='Agency FB' SIZE='4' >" _
                      & "<p>" & "Sayın " & " Metin Şener Bey Dikkatine!" & ",</p>" _
                      & "<p ALIGN='JUSTIFY'></p>" _
                      & "<p ALIGN='JUSTIFY'>" _
                      & " Aşağıda özellikleri belirtilen siparişin AS400 Sistemine girilmesini Arz/Rica ederim. " _
                      & "<b>" _
                      & "<p ALIGN='JUSTIFY'></p>" _
                      & "<p ALIGN='JUSTIFY'>" _
                      & "<p>" & "Saygılarımla," & "</p>" _
                      & "<p ALIGN='JUSTIFY'></p>" _
                      & "<p ALIGN='JUSTIFY'>" _
                      & "<p>" & "Turgay ENER" & ",</p>" _
                      & "<img border='0' src='http://192.168.198.192/dlrweb/Imza/Turgayener.jpg' width='140' height='90'></p>" _
                      & "<font color=red><p></font> " & ACIKLAMA & "</p>" _
                      & "<p></p>" _
                      & "</font>" _
                      & "</body>"
            ' & " <img border='0' src='file:///" & FilePath & "' width='140' height='90'></p>" _

            With message



                'Attachment = New MailAttachment("C:\TURGAYENER.JPG")
                'message.Attachments.Add(Attachment)

                '•Server.MapPath(".") returns D:\WebApps\shop\products
                '•Server.MapPath("..") returns D:\WebApps\shop
                '•Server.MapPath("~") returns D:\WebApps\shop
                '•Server.MapPath("/") returns C:\Inetpub\wwwroot
                '•Server.MapPath("/shop") returns D:\WebApps\shop





                '.From = "eys@dilerhld.com"
                .From = "TURGAYENER@dilerhld.com"
                .To = ADRES  ' "adnanguler@dilerhld.com" '
                .Subject = mailack
                .Body = mesaj1


                .BodyFormat = Web.Mail.MailFormat.Html
                ' For authentication...
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "DILEREXCH.dilerhld.com")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
                '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eys")
                '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "Eee")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "turgayener")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "denver")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 specifies NTLM, 1 for basic, 0 for none
            End With

            Dim smtp As System.Web.Mail.SmtpMail
            smtp.SmtpServer = mailsmtp
            smtp.Send(message)
            MailGittimi = "E"
        Catch
            MailGittimi = "H"

            'MessageBox.Show("E-mail gönderilemedi", "Smtp Mail", MessageBoxButtons.OK)
            'AspNetMsgFunc("E-mail gönderilemedi", "Smtp Mail")
        End Try

    End Sub

    Public Shared Sub MailGonder_as400_Kütük_GIRIS_TurgayBeye(ByVal ADRES As String, ByVal ADSOYAD As String, ByVal ACIKLAMA As String, ByVal Gonderenx As String)

        Dim mailack, MailGittimi
        Dim BAslıkMesajı, SubjectMesajı, mailsmtp
        MailGittimi = "H"

        Try
            Dim message As New System.Web.Mail.MailMessage
            mailack = "AS400 SİSTEMİNE DEMİR TALEBİ GİRİŞ - (GEBZE - FABRIKA)"

            Dim mesaj1 = "<body>" _
                      & "<font FACE='Agency FB'>" _
                      & "<p></p>" _
                      & "</font><font FACE='Agency FB' SIZE='4' >" _
                      & "<p>" & "Sayın " & " Turgay ENER Bey Dikkatine!" & ",</p>" _
                      & "<p ALIGN='JUSTIFY'></p>" _
                      & "<p ALIGN='JUSTIFY'>" _
                      & " Aşağıda özellikleri belirtilen siparişin Sisteme girilmesini Arz/Rica ederim. " _
                      & "<b>" _
                      & "<p ALIGN='JUSTIFY'></p>" _
                      & "<p ALIGN='JUSTIFY'>" _
                      & "<p>" & "Saygılarımla," & "</p>" _
                      & "<p ALIGN='JUSTIFY'></p>" _
                      & "<p ALIGN='JUSTIFY'>" _
                      & "<p>" & Gonderenx & ",</p>" _
                      & "<font color=red><p></font> " & ACIKLAMA & "</p>" _
                      & "<p></p>" _
                      & "<p>&nbsp</p>" _
                      & "<p>&nbsp</p>" _
                      & "<a href='http://192.168.198.192/dlrweb/login.aspx'> Onaylamak İçin Sisteme Burdan Girebilirsiniz</a> </p>" _
                      & "</font>" _
                      & "</body>"

            With message

                .From = "eys@dilerhld.com"
                .To = ADRES ' "adnanguler@dilerhld.com" 
                .Subject = mailack
                .Body = mesaj1

                .BodyFormat = Web.Mail.MailFormat.Html
                ' For authentication...
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "DILEREXCH.dilerhld.com")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "eys")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "Eee")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 specifies NTLM, 1 for basic, 0 for none
            End With

            Dim smtp As System.Web.Mail.SmtpMail
            smtp.SmtpServer = mailsmtp
            smtp.Send(message)
            MailGittimi = "E"
        Catch
            MailGittimi = "H"

            'MessageBox.Show("E-mail gönderilemedi", "Smtp Mail", MessageBoxButtons.OK)
            'AspNetMsgFunc("E-mail gönderilemedi", "Smtp Mail")
        End Try

    End Sub


End Class


