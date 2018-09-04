
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports diler.Web
Imports diler.dal
Imports diler.Entity
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types

Imports System.Security
Imports System.Security.Principal.WindowsIdentity
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Management
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

Partial Class MerkezSip
    Inherits System.Web.UI.Page
    Public DonenTersTarih, DonenTarih, DonenTersTarihX
    Dim BILDIRIMTAR, BILDIRIMSIRANO, SIRANO
    Dim d1, d2, d3, D4, D5

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TextBox8.Text = Session("KULLANICI_AD")
        TextBox9.Text = Session("KULLANICI_OZET")

    End Sub
    Private Sub Getir()

        Dim SQL = ""
        Dim i = 1

        FpSpread1.Sheets(0).RowCount = 0

        If DATE5.Text = "" Then
            SQL = "SELECT * FROM URTHRK.MERKEZ_KUTUK_TALEP " _
              & " where TALEPBRM='" & TextBox9.Text & "'" _
              & " ORDER BY TARIH DESC"
        Else
            CEVIR(DATE5.Value)
            Dim TarihXxX = DonenTarih
            SQL = "SELECT * FROM URTHRK.MERKEZ_KUTUK_TALEP" _
            & " WHERE TARIH =" & TarihXxX _
            & " and TALEPBRM='" & TextBox9.Text & "'"
        End If


        Dim DbConn As New ConnectGirisVb
        DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
            FpSpread1.Sheets(0).RowCount = FpSpread1.Sheets(0).RowCount + 1
            FpSpread1.Sheets(0).Cells(i - 1, 1).Text = DbConn.MyDataReader.GetValue(0).ToString() 'TARIH
            FpSpread1.Sheets(0).Cells(i - 1, 2).Text = DbConn.MyDataReader.GetValue(1).ToString() 'YER
            FpSpread1.Sheets(0).Cells(i - 1, 3).Text = DbConn.MyDataReader.GetValue(2).ToString() 'CAP
            FpSpread1.Sheets(0).Cells(i - 1, 4).Text = DbConn.MyDataReader.GetValue(3).ToString() ' CINS
            FpSpread1.Sheets(0).Cells(i - 1, 5).Text = DbConn.MyDataReader.GetValue(4).ToString() 'BOY
            FpSpread1.Sheets(0).Cells(i - 1, 6).Text = DbConn.MyDataReader.GetValue(5).ToString() ' TONAJ
            FpSpread1.Sheets(0).Cells(i - 1, 7).Text = DbConn.MyDataReader.GetValue(6).ToString() ' ack 

            If DbConn.MyDataReader.GetValue(8).ToString() = 1 Then
                boya(1, i)
            Else
                boya(0, i)
            End If
            i = i + 1
        End While
        DbConn.Kapat()

    End Sub

    Public Sub boya(ByVal gelen As String, ByVal satır As String)

        Dim j
        For j = 0 To 7
            If gelen = 1 Then FpSpread1.Sheets(0).Cells(satır - 1, j).BackColor = Drawing.Color.Yellow
            If gelen = 0 Then FpSpread1.Sheets(0).Cells(satır - 1, j).BackColor = Drawing.Color.Wheat
        Next

    End Sub


    Public Sub CEVIR(ByVal gelen As String)

        Dim YIL, AY, GUN As String
        YIL = Microsoft.VisualBasic.Year(gelen)
        AY = Microsoft.VisualBasic.Month(gelen)
        If Microsoft.VisualBasic.Len(AY.ToString) = 1 Then AY = "0" & AY
        GUN = Microsoft.VisualBasic.Day(gelen)
        If Microsoft.VisualBasic.Len(GUN) = 1 Then GUN = "0" & GUN
        DonenTarih = YIL & AY & GUN

    End Sub

    Public Sub TERSCEVIR(ByVal gelen As String)

        Dim YIL, AY, GUN, TERSTARIH As String
        YIL = Microsoft.VisualBasic.Left(gelen, 4)
        AY = Mid(gelen, 5, 2)
        GUN = Mid(gelen, 7, 2)
        TERSTARIH = GUN & "/" & AY & "/" & YIL
        DonenTersTarih = TERSTARIH

    End Sub

    Public Sub TERSCEVIRx(ByVal gelen As String)

        Dim YIL, AY, GUN, TERSTARIH As String
        YIL = Microsoft.VisualBasic.Left(gelen, 4)
        AY = Mid(gelen, 5, 2)
        GUN = Mid(gelen, 7, 2)
        TERSTARIH = AY & "/" & GUN & "/" & YIL
        DonenTersTarihx = TERSTARIH

    End Sub

    Protected Sub Image6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image6.Click


        Dim Sql As String
        CEVIR(DATE5.Value)
        Dim TARIH = DonenTarih
        Dim DbConn As New ConnectGirisVb


        ' ONCE SIL
        Sql = "DELETE FROM URTHRK.MERKEZ_KUTUK_TALEP" _
                & " WHERE TARIH=" & BILDIRIMTAR _
                & " and ACIKLAMA='" & TextBox7.Text & "'" _
                & " and TALEPBRM='" & TextBox9.Text & "'" _
                & " and CAP='" & TextBox2.Text & "'" _
                & " and CINS='" & TextBox3.Text & "'" _
                & " and BOY='" & TextBox4.Text & "'"

        DbConn.Sil(Sql)
        DbConn.Kapat()

        Sql = ""
        Sql = " INSERT INTO URTHRK.MERKEZ_KUTUK_TALEP VALUES " _
         & "(" & TARIH & "," _
         & "'" & DropDownList1.Text & "'," _
         & "'" & TextBox2.Text & "'," _
         & "'" & TextBox3.Text & "'," _
         & "'" & TextBox4.Text & "'," _
         & "" & TextBox5.Text & "," _
         & "'" & TextBox7.Text & "'," _
         & "'" & TextBox9.Text & "'," _
         & "" & "0" & ")"

        Dim DbConn3 As New ConnectGirisVb
        DbConn3.SaveUpdate(Sql)
        DbConn3.Kapat()

        mesaj(String.Format("{0}", "Kayıt Başarılı bir şekilde Saklandı"))
        MAILHAZIRLA()
        Getir()

        
    End Sub

    Private Sub mesaj(ByVal mesajx)
        Dim strScript As String

        Try
            strScript = "<script>"
            strScript &= "alert('" & mesajx & "');"
            strScript &= "</script>"

            Page.RegisterStartupScript("ClientSideScript", strScript)
        Catch ex As Exception
            Response.Write(ex.Message & "<br>" & ex.StackTrace)
        End Try

    End Sub

    Protected Sub Image3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image3.Click
        Getir()
    End Sub

    Protected Sub Image5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image5.Click

        Dim Sql As String
        CEVIR(DATE5.Value)
        Dim DbConn As New ConnectGirisVb


        ' ONCE SIL
        Sql = "DELETE FROM URTHRK.MERKEZ_KUTUK_TALEP" _
                & " WHERE TARIH=" & DonenTarih _
                & " and ACIKLAMA='" & TextBox7.Text & "'" _
                & " and TALEPBRM='" & TextBox9.Text & "'" _
                & " and CAP='" & TextBox2.Text & "'" _
                & " and CINS='" & TextBox3.Text & "'" _
                & " and BOY='" & TextBox4.Text & "'"

        DbConn.Sil(Sql)
        DbConn.Kapat()

        mesaj(String.Format("{0}", "Kayıt Başarılı bir şekilde Silindi"))

        Getir()
    End Sub

    Protected Sub Image4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image4.Click

        DATE5.Text = ""
        DropDownList1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""

    End Sub

    Private Sub MAILHAZIRLA()

        Dim MAILACIKLAMASI
        Dim D1, mailbaslık, BAslıkMesajı
        Dim D2, D3 As Decimal
        Dim SQL
        Dim I
        Dim BILDIRIMTARIHIX, YER, CAP, CINS, BOY, TONAJ, ACIKLAMA

        Dim strMsg

        strMsg = ""
        strMsg = strMsg & "<table width='100%' border='1'>"
        strMsg = strMsg & " <tr>"
        strMsg = strMsg & " <td width='500'> <div align='center'> <b>BIRDIRIM TARIHI</b></div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'><b>YER</b> </div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'><b>CAP</b> </div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'><b>CINS</b> </div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'><b>BOY</b> </div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'><b>TONAJ </b></div></td>"
        strMsg = strMsg & " <td width='5000'> <div align='center'><b>ACIKLAMA</b></div></td>"

        strMsg = strMsg & " </tr>"




        BILDIRIMTARIHIX = DATE5.Value
        If DATE5.Text = "" Then
            BILDIRIMTARIHIX = FpSpread1.Sheets(0).Cells(1, 1).Text
        End If

        Dim YIL, AY, GUN
        YIL = Year(BILDIRIMTARIHIX)
        AY = Month(BILDIRIMTARIHIX)
        GUN = Day(BILDIRIMTARIHIX)
        If Len(AY) = 1 Then AY = "0" & AY
        If Len(GUN) = 1 Then GUN = "0" & GUN
        BILDIRIMTARIHIX = GUN & "/" & AY & "/" & YIL



        YER = TextBox9.Text
        CAP = TextBox2.Text
        CINS = TextBox3.Text
        BOY = TextBox4.Text
        TONAJ = TextBox5.Text
        ACIKLAMA = TextBox7.Text


        'For I = 1 To FpSpread1.Sheets(0).RowCount

        '    BILDIRIMTARIHIX = FpSpread1.Sheets(0).Cells(I - 1, 1).Text
        '    YER = FpSpread1.Sheets(0).Cells(I - 1, 2).Text
        '    CAP = FpSpread1.Sheets(0).Cells(I - 1, 3).Text
        '    CINS = FpSpread1.Sheets(0).Cells(I - 1, 4).Text
        '    BOY = FpSpread1.Sheets(0).Cells(I - 1, 5).Text
        '    TONAJ = FpSpread1.Sheets(0).Cells(I - 1, 6).Text
        '    ACIKLAMA = FpSpread1.Sheets(0).Cells(I - 1, 7).Text
        'Next

        '*** HTML Tag ***'  
        strMsg = strMsg & " <tr>"
        strMsg = strMsg & " <td width='500'> <div align='center'>" & BILDIRIMTARIHIX & "</div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'>" & YER & "</div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'>" & CAP & "</div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'>" & CINS & "</div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'>" & BOY & "</div></td>"
        strMsg = strMsg & " <td width='100'> <div align='center'>" & TONAJ & "</div></td>"
        strMsg = strMsg & " <td width='5000'> <div align='center'>" & ACIKLAMA & "</div></td>"
        strMsg = strMsg & " </tr>"


        strMsg = strMsg & "</table>"
        'strMsg = strMsg & "<p>" & "Son Güncelleme Bilgileri : " & DATE & ",</p>"
        MAILACIKLAMASI = strMsg


        MailAt.MailGonder_as400_Kütük_GIRIS_TurgayBeye("turgayener@dilerhld.com", "TURGAY ENER", MAILACIKLAMASI, TextBox8.Text)


        'Dim ADSOYADX, MAILADRESX
        'SQL = "SELECT  * FROM URTTNM.SENDMAIL WHERE URTTNM.SENDMAIL.PRGKOD='MRKKUTUKSIP'"
        'Dim DbConn As New ConnectGiris
        'DbConn.RaporWhile(SQL)

        'While DbConn.MyDataReader.Read
        '    ADSOYADX = DbConn.MyDataReader.GetValue(0).ToString() '
        '    MAILADRESX = DbConn.MyDataReader.GetValue(1).ToString() '

        '    'BURDA YUK SQL E GEREK YOK CUNKU HER ZAMAN
        '    MailAt.MailGonder_as400_Kütük_GIRIS_TurgayBeye(MAILADRESX, ADSOYADX, MAILACIKLAMASI, TextBox8.Text)

        'End While
        'DbConn.Kapat()

        ''mesaj(String.Format("{0}", "Kayıt Mail olarak Turgay Ener'e  iletildi..."))

    End Sub

    Protected Sub Image9_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles Image9.Click
        MAILHAZIRLA()
    End Sub

    Protected Sub FpSpread1_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles FpSpread1.ButtonCommand

        Dim s As Integer

        If e.CommandName = "Getir" Then
            Dim row As Int32 = e.CommandArgument.X

            'd1 = e.SheetView.Cells(row, 1).Text.Trim

            d1 = e.SheetView.Cells(row, 1).Text.Trim
            d1 = e.SheetView.Cells(row, 1).Text


            d3 = e.SheetView.Cells(row, 3).Text
            D4 = e.SheetView.Cells(row, 4).Text
            D5 = e.SheetView.Cells(row, 5).Text

            d2 = e.SheetView.Cells(row, 7).Text

            Dim SQL = ""
            Dim i = 1

            'CEVIR(d1)

            'Dim TarihXxX = DonenTarih

            SQL = "SELECT * FROM URTHRK.MERKEZ_KUTUK_TALEP" _
            & " WHERE TARIH =" & d1 _
            & " and ACIKLAMA='" & d2 & "'" _
            & " and CAP='" & d3 & "'" _
            & " and CINS='" & D4 & "'" _
            & " and BOY='" & D5 & "'"



            Dim DbConn As New ConnectGirisVb
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                'FpSpread1.Sheets(0).RowCount = FpSpread1.Sheets(0).RowCount + 1
                'FpSpread1.Sheets(0).Cells(i - 1, 1).Text = DbConn.MyDataReader.GetValue(0).ToString() 'TARIH
                'FpSpread1.Sheets(0).Cells(i - 1, 2).Text = DbConn.MyDataReader.GetValue(1).ToString() 'YER
                'FpSpread1.Sheets(0).Cells(i - 1, 3).Text = DbConn.MyDataReader.GetValue(2).ToString() 'CAP
                'FpSpread1.Sheets(0).Cells(i - 1, 4).Text = DbConn.MyDataReader.GetValue(3).ToString() ' CINS
                'FpSpread1.Sheets(0).Cells(i - 1, 5).Text = DbConn.MyDataReader.GetValue(4).ToString() 'BOY
                'FpSpread1.Sheets(0).Cells(i - 1, 6).Text = DbConn.MyDataReader.GetValue(5).ToString() ' TONAJ
                'FpSpread1.Sheets(0).Cells(i - 1, 7).Text = DbConn.MyDataReader.GetValue(6).ToString() ' ack 


                'DATE5.Value = d1
                TERSCEVIRx(d1)
                DATE5.Value = DonenTersTarihX
                DropDownList1.Text = DbConn.MyDataReader.GetValue(1).ToString()
                TextBox2.Text = DbConn.MyDataReader.GetValue(2).ToString()
                TextBox3.Text = DbConn.MyDataReader.GetValue(3).ToString()
                TextBox4.Text = DbConn.MyDataReader.GetValue(4).ToString()
                TextBox5.Text = DbConn.MyDataReader.GetValue(5).ToString()
                TextBox7.Text = DbConn.MyDataReader.GetValue(6).ToString()

            End While
            DbConn.Kapat()


        End If

    End Sub

End Class


Friend Class ConnectGirisVb

    Public datasource As String
    Public username As String
    Public password As String
    Public conn As New OracleConnection()
    Public cmd As New OracleCommand
    Public da As New OracleDataAdapter
    Public ds As New DataSet
    Public dr As DataRow
    Public MyDataReader As OracleDataReader
    Public MyDataReader2 As OracleDataReader
    Public GeriDonenRakam As Double
    Public GeriDonenString As String

    Public Sub DbBaglan()
        Try
            Dim connectionString As String = "Data Source=(DESCRIPTION=" _
            & "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" _
            & "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" _
            & "User Id=URTHRK;Password=URTHRK;"
            conn = (New OracleConnection(connectionString))
            cmd.Connection = conn
            conn.Open()
        Catch
        End Try
    End Sub

    Public Sub rapor(ByVal GelenTxt As String)

        Try
            Dim connectionString As String = "Data Source=(DESCRIPTION=" & "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" & "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" & "User Id=IK;Password=IK;"
            conn = (New OracleConnection(connectionString))
            cmd.Connection = conn
            conn.Open()
        Catch
        End Try
        cmd.CommandText = GelenTxt
        Dim da As New OracleDataAdapter(cmd)
        da.Fill(ds, "tablo")

    End Sub

    Public Sub RaporWhile(ByVal GelenTxt As String)

        DbBaglan()
        Dim ObjRS1 As New OracleCommand(GelenTxt, cmd.Connection)
        MyDataReader = ObjRS1.ExecuteReader()

    End Sub

    Public Sub RaporWhile2(ByVal GelenTxt As String)

        DbBaglan()
        Dim ObjRS1 As New OracleCommand(GelenTxt, cmd.Connection)
        MyDataReader = ObjRS1.ExecuteReader()

    End Sub

    Public Sub Sil(ByVal GelenTxt As String)

        Try

            DbBaglan()
            Dim ObjRS1 As New OracleCommand(GelenTxt, cmd.Connection)
            ObjRS1.ExecuteNonQuery()
            ObjRS1.Connection.Close()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub Sayac(ByVal GelenTxt As String)
        Try


            DbBaglan()
            Dim ObjRS1 As New OracleCommand(GelenTxt, cmd.Connection)
            GeriDonenRakam = ObjRS1.ExecuteScalar
            ObjRS1.Connection.Close()

        Catch ex As Exception
            GeriDonenRakam = 0
        End Try

    End Sub
    Public Sub SaveUpdate(ByVal GelenTxt As String)
        DbBaglan()
        Dim ObjRS1 As New OracleCommand(GelenTxt, cmd.Connection)
        ObjRS1.ExecuteNonQuery()
        ObjRS1.Connection.Close()

    End Sub
    Public Sub Kapat()
        conn.Close()
    End Sub

End Class


Friend Class MailAt


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


