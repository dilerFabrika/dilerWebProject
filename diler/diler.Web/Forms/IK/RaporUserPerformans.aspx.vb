Imports System.IO
Imports System.IO.TextWriter
Imports System.Data
Imports System.Math
Imports System.Text
Imports System.Drawing
Imports Microsoft.Win32
Imports System.Data.Sql
Imports System.Data.Odbc
Imports System.Threading
Imports System.Data.OleDb
Imports System.Web.UI.Page
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Threading.Thread
Imports System.Data.SqlClient.SqlDataAdapter
Imports FarPoint.Web.Spread
Imports System.Drawing.Image
Imports System.Drawing.Bitmap
Imports System.Web.UI.WebControls.Image
Imports System.Web.UI.WebControls.ImageMap
Imports Infragistics.WebUI.UltraWebTab
Imports Microsoft.Office.Interop.Excel


Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types



Partial Class Rapor
    'Inherits System.Web.UI.Page
    Inherits System.Web.UI.Page
    Dim instance As FpSpread
    Dim value As Integer
    Dim SQL, SQL2, SQL3, SQL4, SQL5, KULLANICI, IZIN, IKID, Aciklamax, DonenTarih, DonenTersTarih1, IKIDXX
    Dim GIRENADI, GIRENSAD, GIRENUNITE, GIRENBOLUM, IDX, GIRENUNVAN, GIRENALTGRUP, SecilenSheetName
    Dim KayitYapan, ToplamSheet, IKDegerlendirilenID, IKDegerlendirilenAdSoyad, IKADSADX

    Dim SecilenSheetGrupNo, SuankiSheetNo, YilX, DonemX As Integer
    Public YoneticiDrm, mesaj
    Dim ToplamSfr, ToplamBir, ToplamIk, ToplamUc, ToplamDort, ToplamBes
    Private Shared prevPage As String = String.Empty

    Private Sub PUANLAMA_GR_DB_DOLDUR()

        'SuankiSheetNo = 0
        'SecilenSheetName = ""
        'SuankiSheetNo = FpSpread3.ActiveSheetViewIndex
        'SecilenSheetName = FpSpread3.Sheets(0).SheetName
        Dim i = 0
        FpSpread3.Sheets(0).RowCount = 0
        SQL = ""
        SQL = "SELECT GRUPNO,SORUNO,SORUACK FROM IK.PERFORMANS_GRUP_SORULARI " _
            & " ORDER BY GRUPNO,SORUNO"
        Dim DbConn As New ConnectOracleDilerIK
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            FpSpread3.Sheets(0).RowCount = FpSpread3.Sheets(0).RowCount + 1
            Dim Yaz = DbConn.MyDataReader.GetValue(0).ToString() & "." & DbConn.MyDataReader.GetValue(1).ToString()
            FpSpread3.Sheets(0).Cells(i, 0).Text = Yaz.ToString()
            i = i + 1
        End While
        DbConn.Kapat()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'AspNetMsgFunc("0")
        IKID = Session("IKIDSI")
        '  IKADSADX = Session("IKADSAD")
        If Not Page.IsPostBack Then
            PUANLAMA_GR_DB_DOLDUR()
            '   AspNetMsgFunc("1")
            GIRENIN_ALTLARINI_GETIR()
            ' AspNetMsgFunc("2")
            'If IKID = "1001664" Then
            'Else
            'Filtre()

            'End If
        Else
            FpSpread2.RenderCSSClass = True
        End If

    End Sub
    'Private Sub YIL_DOLDUR()

    '    Yil.Text = Year(Date.Today)
    '    OrtYil.Text = Year(Date.Today)
    '    YilKisi.Text = Year(Date.Today)
    '    Dim i As Long
    '    For i = Year(Date.Today) To Year(Date.Today) - 10 Step -1
    '        Yil.Items.Add(i)
    '        OrtYil.Items.Add(i)
    '        YilKisi.Items.Add(i)
    '    Next i
    'End Sub
    Public Sub AspNetMsgFunc(ByVal sMsg As String)
        Try

            Dim sb As New StringBuilder()
            Dim oFormObject As System.Web.UI.Control
            sMsg = sMsg.Replace("'", "\'")
            sMsg = sMsg.Replace(Chr(34), "\" & Chr(34))
            sMsg = sMsg.Replace(vbCrLf, "\n")
            sMsg = "<script language=javascript>alert(""" & sMsg & """)</script>"
            sb = New StringBuilder()
            sb.Append(sMsg)
            For Each oFormObject In Me.Controls
                If TypeOf oFormObject Is HtmlForm Then
                    Exit For
                End If
            Next
            oFormObject.Controls.AddAt(oFormObject.Controls.Count, New LiteralControl(sb.ToString()))
        Catch ex As Exception

        End Try
    End Sub

    Sub Filtre()
        'Dim ds As New DataSet
        'Dim f As String = MapPath("authors.xml")
        'ds.ReadXml(f)
        'FarPoint.Web.Spread.DefaultSkins.GetAt(13).Apply(FpSpread2.Sheets(0))
        'FpSpread2.CommandBar.BackColor = Color.Wheat
        'Dim hideRowFilter As New FarPoint.Web.Spread.HideRowFilter(FpSpread2.ActiveSheetView)
        'hideRowFilter.ShowFilterIndicator = False '- Hide Spread's built-in column header filter
        'hideRowFilter.AddColumn(5)
        'FpSpread2.ActiveSheetView.RowFilter = hideRowFilter 'Apply the filter
        'Dim filterItemList As ArrayList = FpSpread2.ActiveSheetView.GetDropDownFilterItems(5)
        'If Not filterItemList Is Nothing Then
        '    Dim i As Integer
        '    For i = 0 To filterItemList.Count - 1
        '        RaporCombo.Items.Add(filterItemList.Item(i))
        '    Next
        'End If
        ''Dim ds As New DataSet
        ''Dim f As String = MapPath("authors.xml")
        ''ds.ReadXml(f)
        ''FarPoint.Web.Spread.DefaultSkins.GetAt(13).Apply(FpSpread2.Sheets(0))
        ''FpSpread2.CommandBar.BackColor = Color.Wheat
        ''Dim hideRowFilter As New FarPoint.Web.Spread.HideRowFilter(FpSpread2.ActiveSheetView)
        ''hideRowFilter.ShowFilterIndicator = False '- Hide Spread's built-in column header filter
        ''hideRowFilter.AddColumn(5)
        ''FpSpread2.ActiveSheetView.RowFilter = hideRowFilter 'Apply the filter
        ''Dim filterItemList As ArrayList = FpSpread2.ActiveSheetView.GetDropDownFilterItems(5)

        ''If Not filterItemList Is Nothing Then
        ''    Dim i As Integer
        ''    For i = 0 To filterItemList.Count - 1
        ''        RaporCombo.Items.Add(filterItemList.Item(i))
        ''    Next
        ''End If
        RaporCombo.Items.Clear()
        SQL = ""
        SQL = "SELECT DISTINCT (IK.UNITESI.ALT_GRUP) FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
        & " WHERE IK.UNITESI.ID<>" & IKID _
        & " AND IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
        & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ÞEF%')" _
        & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜHENDÝS%')" _
        & " AND IK.NUFUS.DRM=" & 1 _
        & " ORDER BY IK.UNITESI.ALT_GRUP"
        Dim DbConnMDR As New ConnectOracleDilerIK
        DbConnMDR.RaporWhile(SQL)
        While DbConnMDR.MyDataReader.Read
            RaporCombo.Items.Add(DbConnMDR.MyDataReader.GetValue(0).ToString())
        End While
        DbConnMDR.Kapat()




    End Sub
    Private Sub GIRENIN_ALTLARINI_GETIR()
        Dim i As Integer
        i = 0
        FpSpread2.Sheets(0).RowCount = 0
        GIRENUNITE = Session("GIRENUNITE")
        GIRENBOLUM = Session("GIRENBOLUM")
        GIRENUNVAN = Session("GIRENUNVAN")
        IKID = Session("IKIDSI")
        If GIRENUNVAN = "FABRÝKA MÜDÜRÜ" Then
            RaporCombo.Items.Clear()
            SQL = ""
            SQL = "SELECT DISTINCT (IK.UNITESI.ALT_GRUP) FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID<>" & IKID _
            & " AND IK.NUFUS.DRM=" & 1 _
            & " ORDER BY IK.UNITESI.ALT_GRUP"
            Dim DbConnFM As New ConnectOracleDilerIK
            DbConnFM.RaporWhile(SQL)
            While DbConnFM.MyDataReader.Read
                RaporCombo.Items.Add(DbConnFM.MyDataReader.GetValue(0).ToString())
            End While
            DbConnFM.Kapat()
        End If
        If GIRENUNVAN = "MÜDÜR" Then
            SQL = ""
            SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
            & " AND IK.UNITESI.ID<>" & IKID _
            & " AND IK.NUFUS.DRM=" & 1
            If RaporCombo.Text <> "(All)" And RaporCombo.Text <> "" Then
                SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & RaporCombo.Text & "'"
            End If
            Dim DbConn As New ConnectOracleDilerIK
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
                FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(0).ToString()
                FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.GetValue(1).ToString() & " " & DbConn.MyDataReader.GetValue(2).ToString()
                FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.GetValue(4).ToString()
                FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn.MyDataReader.GetValue(5).ToString()
                i = i + 1
            End While
            DbConn.Kapat()
        End If
        If GIRENUNVAN = "ÞEF" Then
            SQL = ""
            SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.BOLUM='" & GIRENBOLUM & "'" _
             & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ÞEF%')" _
              & " AND IK.UNITESI.BOLUM<>'TAÞERON FIRMA' " _
              & " AND IK.UNITESI.ID<>" & IKID _
            & " AND IK.NUFUS.DRM=" & 1
            If RaporCombo.Text <> "(All)" And RaporCombo.Text <> "" Then

                SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & RaporCombo.Text & "'"
            End If

            Dim DbConn1 As New ConnectOracleDilerIK
            DbConn1.RaporWhile(SQL)
            While DbConn1.MyDataReader.Read
                FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
                FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn1.MyDataReader.GetValue(0).ToString()
                FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn1.MyDataReader.GetValue(1).ToString() & " " & DbConn1.MyDataReader.GetValue(2).ToString()
                FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn1.MyDataReader.GetValue(4).ToString()
                FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn1.MyDataReader.GetValue(5).ToString()
                i = i + 1
            End While
            DbConn1.Kapat()
        End If
        If GIRENUNVAN = "MÜHENDÝSÝ" Then

            If IKID = 1002587 Then
                SQL = ""
                SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                & " WHERE IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
                & " AND IK.UNITESI.BOLUM<>'TAÞERON FIRMA' " _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ÞEF%')" _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜHENDÝS%')" _
                & " AND IK.UNITESI.ID<>" & IKID _
                & " AND IK.NUFUS.DRM=" & 1
                If RaporCombo.Text <> "(All)" And RaporCombo.Text <> "" Then
                    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & RaporCombo.Text & "'"
                End If
                Dim DbConn2 As New ConnectOracleDilerIK
                DbConn2.RaporWhile(SQL)
                While DbConn2.MyDataReader.Read
                    FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
                    FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn2.MyDataReader.GetValue(0).ToString()
                    FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn2.MyDataReader.GetValue(1).ToString() & " " & DbConn2.MyDataReader.GetValue(2).ToString()
                    FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn2.MyDataReader.GetValue(4).ToString()
                    FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn2.MyDataReader.GetValue(5).ToString()
                    i = i + 1
                End While
                DbConn2.Kapat()
            Else
                SQL = ""
                SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                & " WHERE IK.UNITESI.BOLUM='" & GIRENBOLUM & "'" _
                & " AND IK.UNITESI.BOLUM<>'TAÞERON FIRMA' " _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ÞEF%')" _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜHENDÝS%')" _
                & " AND IK.UNITESI.ID<>" & IKID _
                & " AND IK.NUFUS.DRM=" & 1
                If RaporCombo.Text <> "(All)" And RaporCombo.Text <> "" Then
                    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & RaporCombo.Text & "'"
                End If
                Dim DbConn2 As New ConnectOracleDilerIK
                DbConn2.RaporWhile(SQL)
                While DbConn2.MyDataReader.Read
                    FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
                    FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn2.MyDataReader.GetValue(0).ToString()
                    FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn2.MyDataReader.GetValue(1).ToString() & " " & DbConn2.MyDataReader.GetValue(2).ToString()
                    FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn2.MyDataReader.GetValue(4).ToString()
                    FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn2.MyDataReader.GetValue(5).ToString()
                    i = i + 1
                End While
                DbConn2.Kapat()
            End If
        End If
        'AKTIF_DONEM_NOTU_GETIR()
    End Sub
    Private Sub FABRIKA_MUDURU_ICIN_GRIDDOLDUR()
        FpSpread2.Sheets(0).RowCount = 0
        IKID = Session("IKIDSI")
        Dim i = 0
        SQL = ""
        SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
        & " WHERE IK.UNITESI.ID<>" & IKID _
        & " AND IK.NUFUS.DRM=" & 1
        If RaporCombo.Text <> "(All)" And RaporCombo.Text <> "" Then
            SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & RaporCombo.Text & "'"
        End If
        Dim DbConn As New ConnectOracleDilerIK
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
            FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(0).ToString()
            FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.GetValue(1).ToString() & " " & DbConn.MyDataReader.GetValue(2).ToString()
            'FpSpread2.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.GetValue(3).ToString()
            FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.GetValue(4).ToString()
            FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn.MyDataReader.GetValue(5).ToString()
            'FpSpread1.Sheets(0).Cells(i, 5).Text = DbConn.MyDataReader.GetValue(5).ToString()
            i = i + 1
        End While
        DbConn.Kapat()
    End Sub

    'Private Sub SORU_GRUPLARI()
    '    SoruGruplari.Items.Clear()
    '    SoruGruplari.Items.Add("-")
    '    Dim i = 0
    '    SQL = ""
    '    SQL = "SELECT (GRUPNO || '.' || GRUPACK) As LIST FROM IK.PERFORMANS_SORU_GRUPLARI"
    '    Dim DbConn As New ConnectOracleDilerIK
    '    DbConn.RaporWhile(SQL)
    '    While DbConn.MyDataReader.Read
    '        SoruGruplari.Items.Add(DbConn.MyDataReader.GetValue(0).ToString())
    '    End While
    '    DbConn.Kapat()
    '    SoruGruplari.Text = "-"

    'End Sub

    Protected Sub FpSpread2_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles FpSpread2.ButtonCommand
        If (e.CommandName.StartsWith("filter")) Then
            Dim n As Integer = e.CommandName.IndexOf(".") + 1
            Dim state As String = e.CommandName.Substring(n)
            FpSpread2.ActiveSheetView.AutoFilterColumn(5, state)
        End If
        Dim row As Int32 = e.CommandArgument.X
        IKDegerlendirilenID = e.SheetView.Cells(row, 1).Text.Trim
        IKDegerlendirilenAdSoyad = e.SheetView.Cells(row, 2).Text
        Session("DEG-IKID") = IKDegerlendirilenID
        Dim i As Integer
        i = 0
        SQL = "SELECT * FROM IK.PERFORMANS_OZET" _
        & " WHERE ID =" & IKDegerlendirilenID _
        & " ORDER BY YIL,DONEM"
        FpSpread1.Sheets(0).RowCount = 0
        Dim DbConn As New ConnectOracleDilerIK
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            FpSpread1.Sheets(0).RowCount = FpSpread1.Sheets(0).RowCount + 1
            FpSpread1.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.GetValue(0).ToString()
            FpSpread1.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(1).ToString()
            FpSpread1.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.GetValue(3).ToString()
            FpSpread1.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.GetValue(4).ToString()
            FpSpread1.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.GetValue(5).ToString()
            i = i + 1
        End While
        DbConn.Kapat()
        Label1.Text = "Þuan Ýncelediðiniz Kiþi " & IKDegerlendirilenID & " Sicil Numaralý " & IKDegerlendirilenAdSoyad
        SECILEN_PUANLAMASI_GRID_GETIR()
        KARSILASTIR()
    End Sub
    Private Sub SECILEN_PUANLAMASI_GRID_GETIR()

        IKIDXX = Session("DEG-IKID")
        FpSpread3.Sheets(0).RowCount = 0
        PUANLAMA_GR_DB_DOLDUR()
        'DÖNEM ve YIL BUL
        SQL = ""
        SQL = "SELECT * FROM IK.PERFORMANS_DONEM"
        Dim DbConnX As New ConnectOracleDilerIK
        DbConnX.RaporWhile(SQL)
        While DbConnX.MyDataReader.Read
            YilX = DbConnX.MyDataReader.GetValue(0).ToString()
            DonemX = DbConnX.MyDataReader.GetValue(1).ToString()
        End While
        DbConnX.Kapat()
        IKDegerlendirilenID = ""
        Dim k
        For k = 0 To FpSpread3.Sheets(0).RowCount - 1
            SQL = ""
            SQL = "SELECT (SORUGRUPNO || '.' || GRUPSORUNO) As SORU,PUANVEREN,PUANI FROM IK.PERFORMANS_DATA " _
            & " WHERE ID=" & IKIDXX _
            & " AND DONEM=" & DonemX _
            & " AND YIL=" & YilX _
            & "  ORDER BY SORU "
            Dim DbConn As New ConnectOracleDilerIK
            DbConn.RaporWhile(SQL)

            While DbConn.MyDataReader.Read
                Dim PUANLAMAXX = DbConn.MyDataReader.GetValue(0).ToString()
                Dim PUANVERENXX = DbConn.MyDataReader.GetValue(1).ToString()
                Dim PUANXX = DbConn.MyDataReader.GetValue(2).ToString()
                Dim F
                For F = 0 To FpSpread3.Sheets(0).RowCount - 1
                    Dim YAZANX = FpSpread3.Sheets(0).Cells(F, 0).Text
                    If YAZANX = PUANLAMAXX Then
                        FpSpread3.Sheets(0).Cells(F, PUANVERENXX).Text = PUANXX
                    End If
                Next
            End While
            DbConn.Kapat()
        Next
    End Sub
    Private Sub KARSILASTIR()
        Dim F
        For F = 0 To FpSpread3.Sheets(0).RowCount - 1
            Dim A, B, C, D
            'MÜHENDÝS
            A = Val(FpSpread3.Sheets(0).Cells(F, 1).Value)
            'ÞEF
            B = Val(FpSpread3.Sheets(0).Cells(F, 2).Value)
            'MÜDÜRÜ
            C = Val(FpSpread3.Sheets(0).Cells(F, 3).Value)
            'FABRÝKA MÜDÜRÜ
            D = Val(FpSpread3.Sheets(0).Cells(F, 4).Value)
            If A > 0 Then
                If B > 0 Then
                    If A <> B Then
                        FpSpread3.Sheets(0).Cells(F, 2).BackColor = Color.Pink
                    End If
                End If
            End If

            If B > 0 Then
                If C > 0 Then
                    If B <> C Then
                        FpSpread3.Sheets(0).Cells(F, 3).BackColor = Color.Pink
                    End If
                End If
            End If
            If C > 0 Then
                If D > 0 Then
                    If C <> D Then
                        FpSpread3.Sheets(0).Cells(F, 4).BackColor = Color.Pink
                    End If
                End If
            End If
        Next
    End Sub


    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        'Response.Redirect("~/Performans.aspx")
        Response.Redirect(prevPage)

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RaporCombo.SelectedIndexChanged
        FpSpread2.Sheets(0).RowCount = 0
        GIRENUNITE = Session("GIRENUNITE")
        GIRENBOLUM = Session("GIRENBOLUM")
        GIRENUNVAN = Session("GIRENUNVAN")
        If GIRENUNVAN = "FABRÝKA MÜDÜRÜ" Then
            FABRIKA_MUDURU_ICIN_GRIDDOLDUR()
        Else
            GIRENIN_ALTLARINI_GETIR()
        End If
    End Sub

    'Protected Sub SoruGruplari_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SoruGruplari.SelectedIndexChanged
    '    SECILEN_SORUGRUBUNUN_SORULARINI_GETIR()
    'End Sub
    'Private Sub SECILEN_SORUGRUBUNUN_SORULARINI_GETIR()

    '    Dim GrupNoX = Microsoft.VisualBasic.Left(SoruGruplari.Text, 1)
    '    GR_SecilenGrupSorulari.Sheets(0).RowCount = 0
    '    Dim i = 0
    '    SQL = ""
    '    SQL = "SELECT (GRUPNO || '.' || SORUNO || '.' || SORUACK ) As LIST FROM IK.PERFORMANS_GRUP_SORULARI " _
    '    & " WHERE GRUPNO=" & GrupNoX _
    '    & " ORDER BY LIST "
    '    Dim DbConn As New ConnectOracleDilerIK
    '    DbConn.RaporWhile(SQL)
    '    While DbConn.MyDataReader.Read
    '        GR_SecilenGrupSorulari.Sheets(0).RowCount = GR_SecilenGrupSorulari.Sheets(0).RowCount + 1
    '        GR_SecilenGrupSorulari.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(0).ToString()
    '        i = i + 1
    '    End While
    '    DbConn.Kapat()

    'End Sub

    'Protected Sub GR_SecilenGrupSorulari_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles GR_SecilenGrupSorulari.ButtonCommand
    '    If Combo_Op.Text = "" Or Combo_PuanX.Text = "-" Then
    '        AspNetMsgFunc("::...Raporlamak Ýstediðiniz Puaný veya Op. Seçmediniz...::")
    '    Else
    '        Dim i = 0
    '        Dim AktifSatirx = GR_SecilenGrupSorulari.Sheets(0).ActiveRow.ToString
    '        Dim SoruGrupNo, GrupSoruNox
    '        SoruGrupNo = Microsoft.VisualBasic.Left(GR_SecilenGrupSorulari.Sheets(0).Cells(AktifSatirx, 1).Text(), 1)
    '        GrupSoruNox = Microsoft.VisualBasic.Mid(GR_SecilenGrupSorulari.Sheets(0).Cells(AktifSatirx, 1).Text(), 3, 1)
    '        SQL = ""
    '        'SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP
    '        'FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID 
    '        'INNER JOIN IK.PERFORMANS_DATA ON IK.NUFUS.ID=IK.PERFORMANS_DATA.ID 
    '        'WHERE IK.PERFORMANS_DATA.SORUGRUPNO=1
    '        'AND IK.PERFORMANS_DATA.GRUPSORUNO=1
    '        'AND IK.PERFORMANS_DATA.PUANI=3
    '        'AND IK.PERFORMANS_DATA.YIL=2011
    '        'AND IK.PERFORMANS_DATA.DONEM=1

    '        SQL = "SELECT DISTINCT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP" _
    '        & " FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
    '        & " INNER JOIN IK.PERFORMANS_DATA ON IK.NUFUS.ID=IK.PERFORMANS_DATA.ID " _
    '        & " WHERE IK.PERFORMANS_DATA.SORUGRUPNO=" & SoruGrupNo _
    '        & " AND IK.PERFORMANS_DATA.GRUPSORUNO=" & GrupSoruNox _
    '        & " AND IK.PERFORMANS_DATA.PUANI" & Combo_Op.Text & Combo_PuanX.Text _
    '        & " AND IK.PERFORMANS_DATA.YIL=" & Yil.Text _
    '        & " AND IK.PERFORMANS_DATA.DONEM=" & Donem.Text
    '        Gr_Liste.Sheets(0).RowCount = 0
    '        Dim DbConn As New ConnectOracleDilerIK
    '        DbConn.RaporWhile(SQL)
    '        While DbConn.MyDataReader.Read
    '            Gr_Liste.Sheets(0).RowCount = Gr_Liste.Sheets(0).RowCount + 1
    '            Gr_Liste.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.GetValue(0).ToString()
    '            Gr_Liste.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(1).ToString() & "  " & DbConn.MyDataReader.GetValue(2).ToString()
    '            Gr_Liste.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.GetValue(3).ToString()
    '            Gr_Liste.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.GetValue(4).ToString()
    '            i = i + 1
    '        End While
    '        DbConn.Kapat()
    '    End If
    'End Sub
    'Protected Sub GR_SecilenGrupSorulari_UpdateCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles GR_SecilenGrupSorulari.UpdateCommand

    'End Sub

    Protected Sub FpSpread1_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles FpSpread1.ButtonCommand
        IKIDXX = Session("DEG-IKID")
        FpSpread3.Sheets(0).RowCount = 0
        PUANLAMA_GR_DB_DOLDUR()
        If (e.CommandName.StartsWith("filter")) Then
            Dim n As Integer = e.CommandName.IndexOf(".") + 1
            Dim state As String = e.CommandName.Substring(n)
            FpSpread2.ActiveSheetView.AutoFilterColumn(5, state)
        End If
        Dim row As Int32 = e.CommandArgument.X
        Dim YilX = e.SheetView.Cells(row, 1).Text.Trim
        Dim DonemX = e.SheetView.Cells(row, 1).Text.Trim
        YilX = e.SheetView.Cells(row, 0).Text
        DonemX = e.SheetView.Cells(row, 1).Text
        Dim k
        For k = 0 To FpSpread3.Sheets(0).RowCount - 1
            SQL = ""
            SQL = "SELECT (SORUGRUPNO || '.' || GRUPSORUNO) As SORU,PUANVEREN,PUANI FROM IK.PERFORMANS_DATA " _
            & " WHERE ID=" & IKIDXX _
            & " AND DONEM=" & DonemX _
            & " AND YIL=" & YilX _
            & "  ORDER BY SORU "
            Dim DbConn As New ConnectOracleDilerIK
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                Dim PUANLAMAXX = DbConn.MyDataReader.GetValue(0).ToString()
                Dim PUANVERENXX = DbConn.MyDataReader.GetValue(1).ToString()
                Dim PUANXX = DbConn.MyDataReader.GetValue(2).ToString()
                Dim F
                For F = 0 To FpSpread3.Sheets(0).RowCount - 1
                    Dim YAZANX = FpSpread3.Sheets(0).Cells(F, 0).Text
                    If YAZANX = PUANLAMAXX Then
                        FpSpread3.Sheets(0).Cells(F, PUANVERENXX).Text = PUANXX
                    End If
                Next
            End While
            DbConn.Kapat()
        Next
    End Sub

    Protected Sub FpSpread1_UpdateCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles FpSpread1.UpdateCommand

    End Sub

    'Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

    '    ORTALAMAYA_GORE_RAPOR()

    'End Sub

    'Private Sub ORTALAMAYA_GORE_RAPOR()
    '    If OrtPuan.Text = "-" Or OrtDnm.Text = "-" Then
    '        AspNetMsgFunc("::...Raporlamak Ýstediðiniz Puaný veya Dönemi Seçmediniz...::")
    '    Else
    '        Dim i = 0
    '        SQL = ""
    '        SQL = "SELECT DISTINCT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM" _
    '        & " FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
    '        & " INNER JOIN IK.PERFORMANS_OZET ON IK.NUFUS.ID=IK.PERFORMANS_OZET.ID " _
    '        & " WHERE IK.PERFORMANS_OZET.PUAN='" & OrtPuan.Text & "'" _
    '        & " AND IK.PERFORMANS_OZET.YIL=" & OrtYil.Text _
    '        & " AND IK.PERFORMANS_OZET.DONEM=" & OrtDnm.Text _
    '        & " ORDER BY ID ASC "
    '        FpSpread4.Sheets(0).RowCount = 0
    '        Dim DbConn As New ConnectOracleDilerIK
    '        DbConn.RaporWhile(SQL)
    '        While DbConn.MyDataReader.Read
    '            FpSpread4.Sheets(0).RowCount = FpSpread4.Sheets(0).RowCount + 1
    '            FpSpread4.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.GetValue(0).ToString()
    '            FpSpread4.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(1).ToString() & "  " & DbConn.MyDataReader.GetValue(2).ToString()
    '            FpSpread4.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.GetValue(3).ToString()
    '            FpSpread4.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.GetValue(4).ToString()
    '            i = i + 1
    '        End While
    '        DbConn.Kapat()
    '    End If
    'End Sub


    Private Sub GIRENE_GORE_COMBO_DOLDUR()
        If GIRENUNVAN = "MÜDÜR" Then
            RaporCombo.Items.Clear()
            SQL = ""
            SQL = "SELECT DISTINCT (IK.UNITESI.ALT_GRUP) FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID<>" & IKID _
            & " AND IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
            & " AND IK.NUFUS.DRM=" & 1 _
            & " ORDER BY IK.UNITESI.ALT_GRUP"
            Dim DbConnMDR As New ConnectOracleDilerIK
            DbConnMDR.RaporWhile(SQL)
            While DbConnMDR.MyDataReader.Read
                RaporCombo.Items.Add(DbConnMDR.MyDataReader.GetValue(0).ToString())
            End While
            DbConnMDR.Kapat()
        End If


        If GIRENUNVAN = "ÞEF" Then
            RaporCombo.Items.Clear()
            SQL = ""
            SQL = "SELECT DISTINCT (IK.UNITESI.ALT_GRUP) FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID<>" & IKID _
            & " AND IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
            & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ÞEF%')" _
            & " AND IK.NUFUS.DRM=" & 1 _
            & " ORDER BY IK.UNITESI.ALT_GRUP"
            Dim DbConnMDR As New ConnectOracleDilerIK
            DbConnMDR.RaporWhile(SQL)
            While DbConnMDR.MyDataReader.Read
                RaporCombo.Items.Add(DbConnMDR.MyDataReader.GetValue(0).ToString())
            End While
            DbConnMDR.Kapat()
        End If


        If GIRENUNVAN = "MÜHENDÝSÝ" Then
            RaporCombo.Items.Clear()
            SQL = ""
            SQL = "SELECT DISTINCT (IK.UNITESI.ALT_GRUP) FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID<>" & IKID _
            & " AND IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
            & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ÞEF%')" _
            & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜHENDÝS%')" _
            & " AND IK.NUFUS.DRM=" & 1 _
            & " ORDER BY IK.UNITESI.ALT_GRUP"
            Dim DbConnMDR As New ConnectOracleDilerIK
            DbConnMDR.RaporWhile(SQL)
            While DbConnMDR.MyDataReader.Read
                RaporCombo.Items.Add(DbConnMDR.MyDataReader.GetValue(0).ToString())
            End While
            DbConnMDR.Kapat()
        End If
    End Sub

    'Private Sub KISIYE_GORE_RAPOR()

    '    Dim PUANxXx, f
    '    If DropDownList2.Text = "DP" Then
    '        PUANxXx = 1

    '    End If
    '    If DropDownList2.Text = "YTP" Then
    '        PUANxXx = 2

    '    End If
    '    f = 0
    '    SQL = ""
    '    SQL = " SELECT IK.PERFORMANS_DATA.ID,IK.NUFUS.ADI || ' ' || IK.NUFUS.SOYADI AS ISIM," _
    '    & " IK.PERFORMANS_DATA.SORUGRUPNO,IK.PERFORMANS_DATA.GRUPSORUNO,IK.PERFORMANS_DATA.PUANI" _
    '    & " FROM IK.NUFUS INNER JOIN IK.PERFORMANS_DATA  ON IK.NUFUS.ID = IK.PERFORMANS_DATA.ID" _
    '    & " WHERE PUANI=" & PUANxXx _
    '    & " AND YIL=" & YilKisi.Text _
    '    & " AND DONEM=" & DropDownList3.Text _
    '    & " AND PUANVEREN=3" _
    '    & " ORDER BY ID,SORUGRUPNO,GRUPSORUNO"
    '    FpSpread5.Sheets(0).RowCount = 0
    '    Dim DbConn As New ConnectOracleDilerIK
    '    DbConn.RaporWhile(SQL)
    '    While DbConn.MyDataReader.Read
    '        FpSpread5.Sheets(0).RowCount = FpSpread5.Sheets(0).RowCount + 1
    '        FpSpread5.Sheets(0).Cells(f, 0).Text = DbConn.MyDataReader.GetValue(0).ToString()
    '        FpSpread5.Sheets(0).Cells(f, 1).Text = DbConn.MyDataReader.GetValue(1).ToString()
    '        FpSpread5.Sheets(0).Cells(f, 2).Text = DbConn.MyDataReader.GetValue(2).ToString()
    '        FpSpread5.Sheets(0).Cells(f, 3).Text = DbConn.MyDataReader.GetValue(3).ToString()
    '        FpSpread5.Sheets(0).Cells(f, 5).Text = DbConn.MyDataReader.GetValue(4).ToString()
    '        f = f + 1
    '    End While
    '    DbConn.Kapat()
    '    Dim g = 0
    '    For g = 0 To FpSpread5.Sheets(0).RowCount - 1
    '        Dim GrupNoX = FpSpread5.Sheets(0).Cells(g, 2).Text
    '        Dim SoruNoX = FpSpread5.Sheets(0).Cells(g, 3).Text
    '        SQL = ""
    '        SQL = " SELECT SORUACK FROM PERFORMANS_GRUP_SORULARI" _
    '        & " WHERE GRUPNO=" & GrupNoX _
    '        & " AND SORUNO=" & SoruNoX
    '        Dim DbConn2 As New ConnectOracleDilerIK
    '        DbConn2.RaporWhile(SQL)
    '        While DbConn2.MyDataReader.Read
    '            FpSpread5.Sheets(0).Cells(g, 4).Text = DbConn2.MyDataReader.GetValue(0).ToString()
    '        End While
    '        DbConn2.Kapat()
    '    Next
    '    Dim XX
    '    Dim k = 0
    '    For k = 0 To FpSpread5.Sheets(0).RowCount - 1


    '        XX = FpSpread5.Sheets(0).Cells(k, 5).Text
    '        If XX <> "" Then
    '            If XX = 1 Then
    '                XX = "DP"
    '            End If
    '            Try
    '                If XX = 2 Then
    '                    XX = "YTP"
    '                End If
    '            Catch ex As Exception
    '            End Try
    '            Try
    '                If XX = 3 Then
    '                    XX = "YP"
    '                End If
    '            Catch ex As Exception
    '            End Try
    '            Try
    '                If XX = 4 Then
    '                    XX = "ÝP"
    '                End If
    '            Catch ex As Exception
    '            End Try
    '            Try
    '                If XX = 5 Then
    '                    XX = "ÜP"
    '                End If
    '            Catch ex As Exception
    '            End Try
    '            FpSpread5.Sheets(0).Cells(k, 5).Text = XX
    '            If XX = "DP" Then
    '                FpSpread5.Sheets(0).Cells(k, 0).BackColor = Color.Pink
    '                FpSpread5.Sheets(0).Cells(k, 1).BackColor = Color.Pink
    '                FpSpread5.Sheets(0).Cells(k, 2).BackColor = Color.Pink
    '                FpSpread5.Sheets(0).Cells(k, 3).BackColor = Color.Pink
    '                FpSpread5.Sheets(0).Cells(k, 4).BackColor = Color.Pink
    '                FpSpread5.Sheets(0).Cells(k, 5).BackColor = Color.Pink
    '            End If

    '            If XX = "YTP" Then
    '                FpSpread5.Sheets(0).Cells(k, 0).BackColor = Color.Cyan
    '                FpSpread5.Sheets(0).Cells(k, 1).BackColor = Color.Cyan
    '                FpSpread5.Sheets(0).Cells(k, 2).BackColor = Color.Cyan
    '                FpSpread5.Sheets(0).Cells(k, 3).BackColor = Color.Cyan
    '                FpSpread5.Sheets(0).Cells(k, 4).BackColor = Color.Cyan
    '                FpSpread5.Sheets(0).Cells(k, 5).BackColor = Color.Cyan
    '            End If

    '        End If
    '        XX = ""
    '    Next

    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    '    YAZ()
    'End Sub
    'Private Sub YAZ()
    '    Dim F, ADSADXX
    '    Dim IDX
    '    Dim IsimX
    '    Dim GrupX
    '    Dim SoruX
    '    Dim Sayi
    '    Dim SoruAckX
    '    Dim Deger
    '    Dim TxtYaz
    '    For F = 0 To FpSpread5.Sheets(0).RowCount - 1
    '        Dim Secilimi = Val(FpSpread5.Sheets(0).Cells(F, 6).Value)
    '        If Secilimi = 1 Then
    '            IDX = FpSpread5.Sheets(0).Cells(F, 0).Value
    '            IsimX = FpSpread5.Sheets(0).Cells(F, 1).Value
    '            GrupX = FpSpread5.Sheets(0).Cells(F, 2).Value
    '            SoruX = FpSpread5.Sheets(0).Cells(F, 3).Value
    '            Sayi = InStr(FpSpread5.Sheets(0).Cells(F, 4).Value, ":")
    '            SoruAckX = Microsoft.VisualBasic.Mid(FpSpread5.Sheets(0).Cells(F, 4).Value, 1, Sayi - 1) & "'"
    '            Deger = Deger & GrupX & "." & SoruX & "." & SoruAckX
    '        End If
    '    Next
    '    TxtYaz = IDX & "*" & IsimX & "Q" & Deger
    '    'Dim sw = File.AppendText(Server.MapPath("log.txt"))
    '    'sw.WriteLine(TxtYaz)
    '    'sw.Flush()
    '    'sw.Close()
    '    'Try

    '    Dim BAK, dxx As Integer
    '    dxx = 0
    '    Dim D, D1, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13, S14, S15, S16, S17, S18, S19
    '    Dim XX = TxtYaz
    '    BAK = Val(InStr(XX, "*"))
    '    D = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '    dxx = D.ToString.ToCharArray.Length
    '    Dim IDXX = Microsoft.VisualBasic.Mid(D, 1, dxx)
    '    XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    BAK = Val(InStr(XX, "Q"))
    '    If BAK > 0 Then
    '        D1 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = D1.ToString.ToCharArray.Length
    '        'dxx = dxx - 2
    '        D1 = Microsoft.VisualBasic.Mid(D1, 1, dxx)
    '        ADSADXX = D1
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If
    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S1 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S1.ToString.ToCharArray.Length
    '        S1 = Microsoft.VisualBasic.Mid(S1, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If
    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S2 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S2.ToString.ToCharArray.Length
    '        S2 = Microsoft.VisualBasic.Mid(S2, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S3 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S3.ToString.ToCharArray.Length
    '        S3 = Microsoft.VisualBasic.Mid(S3, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If
    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S4 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S4.ToString.ToCharArray.Length
    '        S4 = Microsoft.VisualBasic.Mid(S4, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))

    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S5 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S5.ToString.ToCharArray.Length
    '        S5 = Microsoft.VisualBasic.Mid(S5, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))

    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S6 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S6.ToString.ToCharArray.Length
    '        S6 = Microsoft.VisualBasic.Mid(S6, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If
    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S7 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S7.ToString.ToCharArray.Length
    '        S7 = Microsoft.VisualBasic.Mid(S7, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If
    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S8 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S8.ToString.ToCharArray.Length
    '        S8 = Microsoft.VisualBasic.Mid(S8, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If
    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S9 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S9.ToString.ToCharArray.Length
    '        S9 = Microsoft.VisualBasic.Mid(S9, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If
    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S10 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S10.ToString.ToCharArray.Length
    '        S10 = Microsoft.VisualBasic.Mid(S10, 1, dxx)
    '        XX = Trim(Microsoft.VisualBasic.Mid(XX, BAK + 1, Len(XX) - BAK))
    '    End If
    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S11 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S11.ToString.ToCharArray.Length
    '        S11 = Microsoft.VisualBasic.Mid(S11, 1, dxx)
    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S12 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S12.ToString.ToCharArray.Length
    '        S12 = Microsoft.VisualBasic.Mid(S12, 1, dxx)
    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S13 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S13.ToString.ToCharArray.Length
    '        S13 = Microsoft.VisualBasic.Mid(S13, 1, dxx)
    '    End If


    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S14 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S14.ToString.ToCharArray.Length
    '        S14 = Microsoft.VisualBasic.Mid(S14, 1, dxx)
    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S15 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S15.ToString.ToCharArray.Length
    '        S15 = Microsoft.VisualBasic.Mid(S15, 1, dxx)
    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S16 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S16.ToString.ToCharArray.Length
    '        S16 = Microsoft.VisualBasic.Mid(S16, 1, dxx)
    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S17 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S17.ToString.ToCharArray.Length
    '        S17 = Microsoft.VisualBasic.Mid(S17, 1, dxx)
    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S18 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S18.ToString.ToCharArray.Length
    '        S18 = Microsoft.VisualBasic.Mid(S18, 1, dxx)
    '    End If

    '    BAK = Val(InStr(XX, "'"))
    '    If BAK > 0 Then
    '        S19 = Microsoft.VisualBasic.Mid(XX, 1, BAK - 1)
    '        dxx = S19.ToString.ToCharArray.Length
    '        S19 = Microsoft.VisualBasic.Mid(S19, 1, dxx)
    '    End If
    '    Prnt.Sheets(0).Cells(4, 1).Text = ADSADXX
    '    Prnt.Sheets(0).Cells(34, 3).Text = ADSADXX
    '    Prnt.Sheets(0).Cells(35, 3).Text = IDXX
    '    If S1 <> "" Then Prnt.Sheets(0).Cells(8, 1).Text = S1
    '    If S2 <> "" Then Prnt.Sheets(0).Cells(9, 1).Text = S2
    '    If S3 <> "" Then Prnt.Sheets(0).Cells(10, 1).Text = S3
    '    If S4 <> "" Then Prnt.Sheets(0).Cells(11, 1).Text = S4
    '    If S5 <> "" Then Prnt.Sheets(0).Cells(12, 1).Text = S5
    '    If S6 <> "" Then Prnt.Sheets(0).Cells(13, 1).Text = S6
    '    If S7 <> "" Then Prnt.Sheets(0).Cells(14, 1).Text = S7
    '    If S8 <> "" Then Prnt.Sheets(0).Cells(15, 1).Text = S8
    '    If S9 <> "" Then Prnt.Sheets(0).Cells(16, 1).Text = S9
    '    If S10 <> "" Then Prnt.Sheets(0).Cells(17, 1).Text = S10
    '    If S11 <> "" Then Prnt.Sheets(0).Cells(18, 1).Text = S11
    '    If S12 <> "" Then Prnt.Sheets(0).Cells(19, 1).Text = S12
    '    If S13 <> "" Then Prnt.Sheets(0).Cells(20, 1).Text = S13
    '    If S14 <> "" Then Prnt.Sheets(0).Cells(21, 1).Text = S14
    '    If S15 <> "" Then Prnt.Sheets(0).Cells(22, 1).Text = S15
    '    If S16 <> "" Then Prnt.Sheets(0).Cells(23, 1).Text = S16
    '    If S17 <> "" Then Prnt.Sheets(0).Cells(24, 1).Text = S17
    '    If S18 <> "" Then Prnt.Sheets(0).Cells(25, 1).Text = S18
    '    If S19 <> "" Then Prnt.Sheets(0).Cells(26, 1).Text = S19
    '    Prnt.Sheets(0).Cells(6, 5).Text = YilKisi.Text & " / " & DropDownList3.Text
    '    Panel1.Visible = True
    '    Panel2.Visible = True
    '    Prnt.Visible = True
    '    Prnt.Height = 1050

    '    FpSpread5.Visible = False
    '    Label13.Visible = False
    '    Label14.Visible = False
    '    Button1.Visible = False
    '    DropDownList2.Visible = False
    '    DropDownList3.Visible = False
    '    ImageButton3.Visible = False
    '    YilKisi.Visible = False
    'End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

    '    Prnt.Sheets(0).Cells(4, 1).Text = ""
    '    Prnt.Sheets(0).Cells(34, 3).Text = ""
    '    Prnt.Sheets(0).Cells(35, 3).Text = ""
    '    Prnt.Sheets(0).Cells(8, 1).Text = ""
    '    Prnt.Sheets(0).Cells(9, 1).Text = ""
    '    Prnt.Sheets(0).Cells(10, 1).Text = ""
    '    Prnt.Sheets(0).Cells(11, 1).Text = ""
    '    Prnt.Sheets(0).Cells(12, 1).Text = ""
    '    Prnt.Sheets(0).Cells(13, 1).Text = ""
    '    Prnt.Sheets(0).Cells(14, 1).Text = ""
    '    Prnt.Sheets(0).Cells(15, 1).Text = ""
    '    Prnt.Sheets(0).Cells(16, 1).Text = ""
    '    Prnt.Sheets(0).Cells(17, 1).Text = ""
    '    Prnt.Sheets(0).Cells(18, 1).Text = ""
    '    Prnt.Sheets(0).Cells(19, 1).Text = ""
    '    Prnt.Sheets(0).Cells(20, 1).Text = ""
    '    Prnt.Sheets(0).Cells(21, 1).Text = ""
    '    Prnt.Sheets(0).Cells(22, 1).Text = ""
    '    Prnt.Sheets(0).Cells(23, 1).Text = ""
    '    Prnt.Sheets(0).Cells(24, 1).Text = ""
    '    Prnt.Sheets(0).Cells(25, 1).Text = ""
    '    Prnt.Sheets(0).Cells(26, 1).Text = ""



    '    Panel1.Visible = False
    '    Panel2.Visible = False
    '    Prnt.Visible = False
    '    Prnt.Height = 24
    '    FpSpread5.Visible = True
    '    Label13.Visible = True
    '    Label14.Visible = True
    '    Button1.Visible = True
    '    DropDownList2.Visible = True
    '    DropDownList3.Visible = True
    '    ImageButton3.Visible = True
    '    YilKisi.Visible = True
    'End Sub

End Class


Friend Class ConnectOracleDilerIK

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


    Public Sub RaporWhile(ByVal GelenTxt As String)

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

