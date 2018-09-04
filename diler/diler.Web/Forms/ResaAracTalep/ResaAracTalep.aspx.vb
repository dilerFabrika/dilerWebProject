
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports diler.Web
Imports diler.Dal
Imports diler.Entity
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types



Partial Public Class AracTalep
    Inherits System.Web.UI.Page

    'Public datasource As String
    'Public username As String
    'Public password As String
    'Public conn As New OracleConnection()
    'Public cmd As New OracleCommand
    'Public da As New OracleDataAdapter
    'Public ds As New DataSet
    'Public dr As DataRow
    'Public MyDataReader As OracleDataReader
    'Public MyDataReader2 As OracleDataReader
    Public GeriDonenRakam As Double
    Public GeriDonenString As String


    Public DonenTersTarih, DonenTersTarihx, DonenTarih
    Dim BILDIRIMTAR, BILDIRIMSIRANO, SIRANO
    Dim d1, d2, d3, D4, D5


    Protected Sub Image6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image6.Click

        'TextBox21.Text = "" ' TLP EDEn bırım

        TextBox25.Text = "" ' arac sayısı
        TextBox26.Text = "" ' sure
        'DropDownList9.Text="" 'sure birimi
        'TextBox28.Text = "" ' tlp eden
        TextBox31.Text = "" ' sefer sayısı
        TextBox32.Text = "" ' gemı
        TextBox33.Text = "" ' posta

        TextBox34.Text = "" ' alınacak yer
        TextBox42.Text = "" ' bırakılacak yer

        TextBox52.Text = "" ' mlz cinsi
        TextBox35.Text = "" ' boyut
        TextBox36.Text = "" ' agırlık 
        TextBox53.Text = "" ' tonaj

        TextBox37.Text = "" ' masraf kodu
        TextBox38.Text = "" ' iletişim 1
        TextBox39.Text = "" ' iletişim 2

        DATE9.Text = "" ' bas tar
        TextBox51.Text = "" ' bas saat
        DATE10.Text = "" ' bit tar
        TextBox46.Text = "" ' bit saat

        CEVIR(Date.Now)
        DATE7.Text = DonenTarih
        DATE9.Text = DonenTarih
        DATE10.Text = DonenTarih

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        'If Page.IsPostBack Then

        '        FpSpread1.Sheets(0).RowHeader.Visible = False
        '       FpSpread2.Sheets(0).RowHeader.Visible = False
        'Getir()
        'Else

        'End If


        'CEVIR(Date.Now)
        'DATE7.Value = DonenTarih

        TextBox21.Text = Session("KULLANICI_OZET")
        TextBox28.Text = Session("KULLANICI_AD")

        GETIR()

        'Session("KULLANICI") = UCase(kullanıcı)
        'Session("SIFRESI") = UCase(sifre)
        'Session("KULLANICI_AD") = KULLANICI_AD
        'Session("KULLANICI_OZET") = KULLANICI_OZET

    End Sub
    Sub GETIR()

        Dim SQL
        Dim i = 1

        FpSpread1.Sheets(0).RowCount = 0

        SQL = "SELECT * FROM URTHRK.RESAARACTALEP WHERE BIRIM='" & TextBox21.Text & "' ORDER BY TALEPTAR DESC"


        Dim DbConn As New ConnectGirisVb
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            FpSpread1.Sheets(0).RowCount = FpSpread1.Sheets(0).RowCount + 1
            FpSpread1.Sheets(0).Cells(i - 1, 1).Text = DbConn.MyDataReader.GetValue(0).ToString() ' BIRIM
            FpSpread1.Sheets(0).Cells(i - 1, 2).Text = DbConn.MyDataReader.GetValue(5).ToString() ' TLP EDEN
            FpSpread1.Sheets(0).Cells(i - 1, 3).Text = DbConn.MyDataReader.GetValue(18).ToString() ' BIL TAR
            FpSpread1.Sheets(0).Cells(i - 1, 4).Text = DbConn.MyDataReader.GetValue(19).ToString() ' BAS TAR
            FpSpread1.Sheets(0).Cells(i - 1, 5).Text = DbConn.MyDataReader.GetValue(1).ToString() 'ARAC CINSI
            FpSpread1.Sheets(0).Cells(i - 1, 6).Text = DbConn.MyDataReader.GetValue(7).ToString() 'gemı

            i = i + 1
        End While
        DbConn.Kapat()

    End Sub

    Protected Sub Image4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image4.Click

        'SAKLA

        Dim Sql As String
        CEVIR(DATE7.Text)
        Dim TALEPTAR = DonenTarih
        CEVIR(DATE9.Text)
        Dim BASLANGICTAR = DonenTarih
        CEVIR(DATE10.Text)
        Dim BITISTAR = DonenTarih
        Dim DbConn As New ConnectGirisVb

        Sql = ""
        Sql = " INSERT INTO URTHRK.RESAARACTALEP  VALUES " _
         & "('" & TextBox21.Text & "'," _
         & "'" & DropDownList8.Text & "'," _
         & "'" & TextBox25.Text & "'," _
         & "'" & TextBox26.Text & "'," _
         & "'" & DropDownList9.Text & "'," _
         & "'" & TextBox28.Text & "'," _
         & "'" & TextBox31.Text & "'," _
         & "'" & TextBox32.Text & "'," _
         & "'" & TextBox33.Text & "'," _
         & "'" & TextBox34.Text & "'," _
         & "'" & TextBox42.Text & "'," _
         & "'" & TextBox52.Text & "'," _
         & "'" & TextBox35.Text & "'," _
         & "'" & TextBox36.Text & "'," _
         & "'" & TextBox53.Text & "'," _
         & "'" & TextBox37.Text & "'," _
         & "'" & TextBox38.Text & "'," _
         & "'" & TextBox39.Text & "'," _
         & "" & TALEPTAR & "," _
         & "" & BASLANGICTAR & "," _
        & "'" & TextBox51.Text & "'," _
        & "" & BITISTAR & "," _
        & "'" & TextBox46.Text & "'," _
        & "'" & TextBox54.Text & "')"


        If TextBox37.Text = "" Or TextBox25.Text = "" Then
            mesaj("Masraf Kodunu ve Araç Sayısını Girmeniz Gerekli")
        Else


            Dim DbConn3 As New ConnectGirisVb
            DbConn3.SaveUpdate(Sql)
            DbConn3.Kapat()
            MAILAT()
            mesaj("Kayıt Başarılı bir şekilde Saklandı")

            GETIR()
        End If

    End Sub
    Sub MAILAT()


        Dim BOLUM As String = TextBox21.Text
        Dim TALEPTAR As String = DATE7.Text


        Dim YIL, AY, GUN, TERSTARIH As String
        YIL = Year(TALEPTAR)
        AY = Month(TALEPTAR)
        GUN = Day(TALEPTAR)
        If Len(AY) = 1 Then AY = "0" & AY
        If Len(GUN) = 1 Then GUN = "0" & GUN
        TALEPTAR = GUN & "/" & AY & "/" & YIL





        Dim SURE As String = TextBox26.Text & ", " & DropDownList9.Text
        Dim NEDENI As String = TextBox54.Text
        Dim ARACCINSIxx As String = DropDownList8.Text
        Dim ACIKLAMA As String = TextBox54.Text
        Dim ARACSAYISIxx As String = TextBox25.Text
        Dim ISBASTAR As String = DATE9.Text
        Dim ISBITTAR As String = DATE10.Text
        Dim MLZCINSI As String = TextBox52.Text
        Dim MLZBOYUT As String = TextBox35.Text
        Dim MLZAGIRLIK As String = TextBox36.Text
        Dim MLZTONAJ As String = TextBox53.Text
        Dim ALINACAKYERxx As String = TextBox34.Text
        Dim BIRAKILACAKYERxx As String = TextBox42.Text
        Dim MASRAFKODUxx As String = TextBox37.Text
        Dim IRTIBATALYER As String = TextBox38.Text
        Dim IRTIBATGITYER As String = TextBox39.Text
        Dim TALEPEDENKISI As String = TextBox28.Text

        Dim GEMIX As String = TextBox32.Text
        Dim POSTAX As String = TextBox33.Text
        Dim BASLASAAT As String = TextBox51.Text
        Dim BITMESAAT As String = TextBox46.Text


        YIL = Year(ISBASTAR)
        AY = Month(ISBASTAR)
        GUN = Day(ISBASTAR)
        If Len(AY) = 1 Then AY = "0" & AY
        If Len(GUN) = 1 Then GUN = "0" & GUN
        ISBASTAR = GUN & "/" & AY & "/" & YIL

        YIL = Year(ISBITTAR)
        AY = Month(ISBITTAR)
        GUN = Day(ISBITTAR)
        If Len(AY) = 1 Then AY = "0" & AY
        If Len(GUN) = 1 Then GUN = "0" & GUN
        ISBITTAR = GUN & "/" & AY & "/" & YIL

        Dim xxxmailxxx = "<body>" _
               & "<font FACE='Agency FB'>" _
               & "<p>&nbsp;</p>" _
               & "</font><font FACE='Agency FB' SIZE='4' >" _
               & "<p>Sayın</p>" _
                & "<p>" & "Resa Yetkilisi" & ",</p>" _
               & "<p ALIGN='JUSTIFY'></p>" _
               & "<p ALIGN='JUSTIFY'>" _
               & "Fabrikadan Araç Talebinde Bulunuldu. Bilgiler Aşağıda Bilginize Bunulmuştur." _
               & "<b>" _
               & "<font color=red> <p>TALEP EDEN KİSİ :</font> " & TALEPEDENKISI & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>BOLUM:</font> " & BOLUM & "</p>" _
               & "<font color=red>TALEP TARİHİ:</font> " & TALEPTAR & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>SÜRE:</font> " & SURE & "</p>" _
               & "<font color=red>ARAÇ CİNSİ:</font> " & ARACCINSIxx & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>ARAÇ SAYISI:</font> " & ARACSAYISIxx & "</p>" _
               & "<font color=red>İSİN BASLAMA TARİHİ:</font> " & ISBASTAR & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>İSİN BİTİS TARİHİ:</font> " & ISBITTAR & "</p>" _
               & "<font color=red>İSİN BASLAMA SAATİ:</font> " & BASLASAAT & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>İSİN BİTİS SAATİ:</font> " & BITMESAAT & "</p>" _
               & "<font color=red>MALZEMENİN CINSI:</font> " & MLZCINSI & "</p>" _
               & "<font color=red>MALZEMENİN BOYUTU:</font> " & MLZBOYUT & "</p>" _
               & "<font color=red>MALZEMENİN AGIRLIGI:</font> " & MLZAGIRLIK & "</p>" _
               & "<font color=red>MALZEMENİN TONAJI:</font> " & MLZTONAJ & "</p>" _
               & "<font color=red>ALINACAK YER:</font> " & ALINACAKYERxx & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>BIRAKILACAK YER:</font> " & BIRAKILACAKYERxx & "</p>" _
               & "<font color=red>ALINACAK YER İRTİBAT: " & IRTIBATALYER & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=red>BIRAKILACAK YER İRTİBAT:</font> " & IRTIBATGITYER & "</p>" _
               & "<font color=red>MASRAF KODU:</font><font color=black> " & MASRAFKODUxx & "</font></p>" _
               & "<font color=red>GEMİ:</font><font color=black>" & GEMIX & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font><font color=red>POSTA:</font><font color=black> " & POSTAX & "</font></p>" _
               & "<font color=red>ACIKLAMA:</font><font color=black> " & ACIKLAMA & "</font></p>" _
               & "<p></p>" _
               & "</font>" _
               & "</body>"
        Dim MESSAGE As New System.Web.Mail.MailMessage
        With MESSAGE
            .From = "dilerfab@dilerhld.com"
            .To = "resavrd@dilerhld.com"
            '.To = "ADNANGULER@dilerhld.com"
            .Subject = "Yeni Araç talebiniz var."
            .Body = xxxmailxxx
            .BodyFormat = Web.Mail.MailFormat.Html
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smptserver", "DILEREXCH.dilerhld.com")
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "dilerfab")
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "dlrbim")
            .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2)
        End With
        Dim mailsmtp As String = "DILEREXCH.dilerhld.com"
        Dim smtp As System.Web.Mail.SmtpMail
        smtp.SmtpServer = mailsmtp
        smtp.Send(MESSAGE)


    End Sub
    Protected Sub FpSpread1_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles FpSpread1.ButtonCommand


        If e.CommandName = "Liste" Then

            d1 = FpSpread1.Sheets(0).Cells(e.CommandArgument.X, 1).Value ' BIRIM
            d2 = FpSpread1.Sheets(0).Cells(e.CommandArgument.X, 2).Value ' TLP EDEN
            d3 = FpSpread1.Sheets(0).Cells(e.CommandArgument.X, 3).Value ' TALEP TAR
            D4 = FpSpread1.Sheets(0).Cells(e.CommandArgument.X, 4).Value ' BAS TAR
            D5 = FpSpread1.Sheets(0).Cells(e.CommandArgument.X, 5).Value 'ARAC CINSI


            Dim SQL
            Dim i = 1


            SQL = "SELECT * FROM URTHRK.RESAARACTALEP WHERE BIRIM='" & d1 & "'" _
                    & " AND TLPEDEN='" & d2 & "'" _
                    & " AND TALEPTAR=" & d3 & "" _
                    & " AND BASLAMATAR=" & D4 & "" _
                    & " AND ARACCINSI='" & D5 & "'"

            Dim DbConn As New ConnectGirisVb
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read

                TextBox21.Text = DbConn.MyDataReader.GetValue(0).ToString()
                DropDownList8.SelectedValue = DbConn.MyDataReader.GetValue(1).ToString()
                TextBox25.Text = DbConn.MyDataReader.GetValue(2).ToString()
                TextBox26.Text = DbConn.MyDataReader.GetValue(3).ToString()
                DropDownList9.SelectedValue = DbConn.MyDataReader.GetValue(4).ToString()
                TextBox28.Text = DbConn.MyDataReader.GetValue(5).ToString()
                TextBox31.Text = DbConn.MyDataReader.GetValue(6).ToString()
                TextBox32.Text = DbConn.MyDataReader.GetValue(7).ToString()
                TextBox33.Text = DbConn.MyDataReader.GetValue(8).ToString()
                TextBox34.Text = DbConn.MyDataReader.GetValue(9).ToString()
                TextBox42.Text = DbConn.MyDataReader.GetValue(10).ToString()
                TextBox52.Text = DbConn.MyDataReader.GetValue(11).ToString()
                TextBox35.Text = DbConn.MyDataReader.GetValue(12).ToString()
                TextBox36.Text = DbConn.MyDataReader.GetValue(13).ToString()
                TextBox53.Text = DbConn.MyDataReader.GetValue(14).ToString()
                TextBox37.Text = DbConn.MyDataReader.GetValue(15).ToString()
                TextBox38.Text = DbConn.MyDataReader.GetValue(16).ToString()
                TextBox39.Text = DbConn.MyDataReader.GetValue(17).ToString()

                TERSCEVIRx(DbConn.MyDataReader.GetValue(18).ToString())
                DATE7.Text = DonenTersTarihx

                TERSCEVIRx(DbConn.MyDataReader.GetValue(19).ToString())
                DATE9.Text = DonenTersTarihx

                TextBox51.Text = DbConn.MyDataReader.GetValue(20).ToString()

                TERSCEVIRx(DbConn.MyDataReader.GetValue(21).ToString())
                DATE10.Text = DonenTersTarihx

                TextBox46.Text = DbConn.MyDataReader.GetValue(22).ToString()
                TextBox54.Text = DbConn.MyDataReader.GetValue(23).ToString()

            End While
            DbConn.Kapat()



        End If



    End Sub

    Protected Sub FpSpread1_UpdateCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles FpSpread1.UpdateCommand

    End Sub

    Protected Sub Image10_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image10.Click


        Session("Birim") = TextBox21.Text
        Session("AracCinsi") = DropDownList8.Text
        Session("AracTalepTarihi") = DATE7.Text
        Session("AracSayisi") = TextBox25.Text
        Session("ToplamSure") = TextBox26.Text
        Session("TalepEdenxx") = TextBox28.Text
        Session("TalepEdenGorevixx") = ""
        Session("SeferSayisi") = TextBox31.Text
        Session("Gemi") = TextBox32.Text
        Session("Posta") = TextBox33.Text
        Session("AlinacakYer") = TextBox34.Text
        Session("BirakilacakYer") = TextBox42.Text
        Session("MalzemeninCinsi") = TextBox52.Text
        Session("MalzemeninBoyutu") = TextBox35.Text
        Session("MalzemeninAgirligi") = TextBox36.Text
        Session("MalzemeninTonaji") = TextBox53.Text
        Session("MasrafKodu") = TextBox37.Text
        Session("IsinBaslamaTarihi") = DATE9.Text
        Session("IsinBitisTarihi") = DATE10.Text
        Session("AlacakYerİletisim") = TextBox38.Text
        Session("BirakilacakYerİletisim") = TextBox39.Text
        Session("IsBaslamaSaati") = TextBox51.Text
        Session("IsBaitisSaati") = TextBox46.Text
        Session("Acıklama") = TextBox54.Text

        Dim ADRES = "~/" & "YazdirmaSayfasi" & ".aspx"
        Response.Redirect(ADRES)

    End Sub

    Protected Sub Image5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image5.Click

        Dim SQL
        Dim i = 1


        CEVIR(DATE7.Text)
        Dim TALEPTAR = DonenTarih

        CEVIR(DATE9.Text)
        Dim BASTAR = DonenTarih

        SQL = "DELETE  FROM URTHRK.RESAARACTALEP WHERE BIRIM='" & TextBox21.Text & "'" _
                & " AND TLPEDEN='" & TextBox28.Text & "'" _
                & " AND TALEPTAR=" & TALEPTAR & "" _
                & " AND BASLAMATAR=" & BASTAR & "" _
                & " AND ARACCINSI='" & DropDownList8.Text & "'"

        Dim DbConn As New ConnectGirisVb
        DbConn.Sil(SQL)
        DbConn.Kapat()

        mesaj("Kayıt Başarılı bir şekilde SILINDI")
        GETIR()


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

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("../../default2.aspx")
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
            Dim connectionString As String = "Data Source=(DESCRIPTION=" & "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" & "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" & "User Id=URTHRK;Password=URTHRK;"
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
