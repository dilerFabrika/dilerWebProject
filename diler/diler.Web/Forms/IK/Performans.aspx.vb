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
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types


Namespace spWebProductTour.SpreadWebTour
    Partial Class _default
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim instance As FpSpread
        Dim value As Integer
        Dim SQL, SQL2, SQL3, SQL4, SQL5, KULLANICI, IZIN, IKID, Aciklamax, DonenTarih, DonenTersTarih1, IKADSADX
        Dim GIRENADI, GIRENSAD, GIRENUNITE, GIRENBOLUM, IDX, GIRENUNVAN, GIRENALTGRUP, SecilenSheetName, KayitYapan, ToplamSheet, IKDegerlendirilenID, IKDegerlendirilenAdSoyad
        Dim SecilenSheetGrupNo, SuankiSheetNo, YilX, DonemX As Integer
        Public YoneticiDrm, mesaj
        Dim ToplamSfr, ToplamBir, ToplamIk, ToplamUc, ToplamDort, ToplamBes


        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load

            If Not Page.IsPostBack Then
                datasetOlustur()
                IKADSADX = ("IKADSAD")
                FpSpread1.EnableClientScript = False ' TABLAR ARASI GECISI OTOMATIK YAPAR 3 GUN SENI UGRASTIRMA :)

                GIRENKIM()
                GIRENIN_ALTLARINI_GETIR()
                FpSpread1.RenderCSSClass = True
                SORULARI_GRIDE_GETIR()
                PUANLAMA_GR_DB_DOLDUR()
                RadioButtonList1.SelectedIndex = 3 ' hepsı bos
                performansDonemGetir()
                FpSpread1_renk()
                filtre() 'Niye filtreleniyor
            Else
                FpSpread1_renk()

                GIRENKIM()
                FpSpread1.RenderCSSClass = True
            End If

            With FpSpread1.Sheets(0).ColumnHeader
                .DefaultStyle.Reset()
            End With

            FpSpread1.EnableAjaxCall = False
            If IKID = "1001664" Or IKADSADX = "Cem Kavaz" Or IKID = 1001690 Or IKID = 1001664 Then
                ImageButton3.Visible = True
                Label4.Visible = True
            Else
                ImageButton3.Visible = False
                Label4.Visible = False
            End If
        End Sub

        Private Sub performansDonemGetir()
            Dim SQL
            SQL = ""
            SQL = "SELECT * FROM IK.PERFORMANS_DONEM"
            Dim DbConn2 As New ConnectOracleDilerIK
            DbConn2.RaporWhile(SQL)
            While DbConn2.MyDataReader.Read
                Donem.Text = DbConn2.MyDataReader.GetValue(0).ToString() & "/" & DbConn2.MyDataReader.GetValue(1).ToString()
            End While
            DbConn2.Kapat()
        End Sub
        Sub FpSpread1_renk()
            FarPoint.Web.Spread.DefaultSkins.GetAt(13).Apply(FpSpread1.Sheets(0))
            FarPoint.Web.Spread.DefaultSkins.GetAt(13).Apply(FpSpread1.Sheets(1))
            FarPoint.Web.Spread.DefaultSkins.GetAt(13).Apply(FpSpread1.Sheets(2))
            FarPoint.Web.Spread.DefaultSkins.GetAt(13).Apply(FpSpread1.Sheets(3))
            FarPoint.Web.Spread.DefaultSkins.GetAt(13).Apply(FpSpread1.Sheets(4))
            FpSpread1.CommandBar.BackColor = Color.Wheat
        End Sub
        Sub Hesaplatmalar()
            If Label_Id.Text = "...." Then
                AspNetMsgFunc("Lütfen Önce Yukarıdaki Tablodan Personel Seçiniz....")
            Else
                Try
                    Dim l, bak1, i, Puan
                    Dim s = 0
                    ToplamSfr = 0
                    ToplamBir = 0
                    ToplamIk = 0
                    ToplamUc = 0
                    ToplamDort = 0
                    ToplamBes = 0
                    ToplamSheet = FpSpread1.Sheets.Count
                    For s = 0 To ToplamSheet - 1
                        For i = 0 To FpSpread1.Sheets(s).Rows.Count - 1
                            Puan = 0
                            For l = 1 To 5
                                bak1 = Val(FpSpread1.Sheets(s).Cells(i, l).Value)
                                If bak1 = 1 Then Puan = l
                            Next
                            Select Case Puan
                                Case 0
                                    ToplamSfr = Val(ToplamSfr) + 1
                                Case 1
                                    ToplamBir = Val(ToplamBir) + 1
                                Case 2
                                    ToplamIk = Val(ToplamIk) + 1
                                Case 3
                                    ToplamUc = Val(ToplamUc) + 1
                                Case 4
                                    ToplamDort = Val(ToplamDort) + 1
                                Case 5
                                    ToplamBes = Val(ToplamBes) + 1
                                Case Else
                            End Select
                        Next i
                    Next s
                    Dim A1, A2, A3, A4, A5, SIFIR
                    Dim X, Y, YUZDE, SONUC, PUANI
                    Dim ORAN As Decimal
                    YUZDE = 0
                    SONUC = 0
                    PUANI = ""

                    SIFIR = ToplamSfr
                    A1 = ToplamBir * 1
                    A2 = ToplamIk * 2
                    A3 = ToplamUc * 3
                    A4 = ToplamDort * 4
                    A5 = ToplamBes * 5
                    X = A1 + A2 + A3 + A4 + A5
                    If X > 0 Then

                        X = X / (22 - Val(SIFIR))
                        YUZDE = Round(X, 2)
                        Y = (22 - Val(SIFIR)) * 5
                        Y = (A1 + A2 + A3 + A4 + A5) / Y * 100
                        ORAN = Round(Y, 1)

                        If ORAN > 0 And ORAN <= 39.5 Then SONUC = 1
                        If ORAN > 39.6 And ORAN <= 59.5 Then SONUC = 2
                        If ORAN > 59.6 And ORAN <= 79.5 Then SONUC = 3
                        If ORAN > 79.6 And ORAN <= 89.5 Then SONUC = 4
                        If ORAN > 89.6 Then SONUC = 5
                        If SONUC = 5 Then PUANI = "UP"
                        If SONUC = 4 Then PUANI = "IP"
                        If SONUC = 3 Then PUANI = "YP"
                        If SONUC = 2 Then PUANI = "YTP"
                        If SONUC = 1 Then PUANI = "DP"
                        PuanXX.Text = PUANI
                        OranXX.Text = SONUC
                        YuzdeXX.Text = ORAN
                    End If
                Catch ex As Exception
                    'AspNetMsgFunc("Ustünüz Değerlendirme yaptığı için, bu personeli değerlendiremezsiniz....")
                End Try
            End If

        End Sub

        Sub BosVarmKontrolu()

            ToplamSheet = FpSpread1.Sheets.Count
            Dim l, bak1, i
            YoneticiDrm = "H"
            Dim s = 0
            For s = 0 To ToplamSheet - 1
                For i = 0 To FpSpread1.Sheets(s).Rows.Count - 1
                    For l = 1 To 5
                        bak1 = Val(FpSpread1.Sheets(s).Cells(i, l).Value)
                        If bak1 = 1 Then
                            mesaj = ""
                            GoTo son
                        Else
                            mesaj = "EKSK CEVAPLAMA VAR" & s & ".Baslkta"
                        End If
                    Next
                    If mesaj <> "" Then
                        GoTo ck
                    End If
son:
                Next i
            Next s
ck:
            If mesaj <> "" Then

                Select Case s
                    Case "0"
                        mesaj = "Bilgi Beceri Sorularında Eksik Girdiniz"""
                    Case "1"
                        mesaj = "Verimlilik Sorularında Eksik Girdiniz"
                    Case "2"
                        mesaj = "Sosyal Yön Sorularında Eksik Girdiniz"""
                    Case "3"
                        mesaj = "Yönetim Becerisi Sorularında Eksik Girdiniz"
                    Case "4"
                        mesaj = "Yöneticilik Sorularnda Eksik Girdiniz"
                End Select
            End If
        End Sub

        Public Sub AspNetMsgFunc(ByVal sMsg As String)
            'Try
            '    Dim sb As New StringBuilder()
            '    Dim oFormObject As System.Web.UI.Control
            '    sMsg = sMsg.Replace("'", "\'")
            '    sMsg = sMsg.Replace(Chr(34), "\" & Chr(34))
            '    sMsg = sMsg.Replace(vbCrLf, "\n")
            '    sMsg = "<script language=javascript>alert(""" & sMsg & """)</script>"
            '    sb = New StringBuilder()
            '    sb.Append(sMsg)
            '    For Each oFormObject In Me.Controls
            '        If TypeOf oFormObject Is HtmlForm Then
            '            Exit For
            '        End If
            '    Next
            '    oFormObject.Controls.AddAt(oFormObject.Controls.Count, New LiteralControl(sb.ToString()))
            'Catch ex As Exception
            'End Try
        End Sub

        Sub filtre()
            Dim ds As New DataSet
            'Dim f As String = MapPath("authors.xml")
            'ds.ReadXml(f)
            FarPoint.Web.Spread.DefaultSkins.GetAt(13).Apply(FpSpread2.Sheets(0))
            FpSpread2.CommandBar.BackColor = Color.Wheat
            Dim hideRowFilter As New FarPoint.Web.Spread.HideRowFilter(FpSpread2.ActiveSheetView)
            hideRowFilter.ShowFilterIndicator = False '- Hide Spread's built-in column header filter
            hideRowFilter.AddColumn(5)
            FpSpread2.ActiveSheetView.RowFilter = hideRowFilter 'Apply the filter
            Dim filterItemList As ArrayList = FpSpread2.ActiveSheetView.GetDropDownFilterItems(5)
            If Not filterItemList Is Nothing Then
                Dim i As Integer
                For i = 0 To filterItemList.Count - 1
                    DropDownList1.Items.Add(filterItemList.Item(i))
                Next
            End If
        End Sub
        Sub Grupla()
            Dim ds As New DataSet
            Dim f As String = MapPath("emp.xml")
            ds.ReadXml(f, XmlReadMode.ReadSchema)
            Dim rc As Integer = 20   '000
            Dim cc As Integer = 8   '0
            Dim m As New FarPoint.Web.Spread.Model.DefaultSheetDataModel(rc, cc)
            Dim gm As New FarPoint.Web.Spread.Model.GroupDataModel(m)
            m.DataSource = ds
            m.DataMember = "Employees"
            m.AddColumns(0, 1)
            FpSpread2.Sheets(0).RowHeader.Visible = False
            FpSpread2.Sheets(0).AllowPage = False
            FpSpread2.Sheets(0).AllowSort = True

            FpSpread2.Sheets(0).ColumnHeaderAutoText = FarPoint.Web.Spread.HeaderAutoText.Blank
            FpSpread2.Sheets(0).Columns(0).Width = 20
            FpSpread2.Sheets(0).Columns(0).BackColor = Color.LightYellow
            'Title column
            FpSpread2.Sheets(0).Columns(4).Width = 175
            FpSpread2.ActiveSheetView.AllowGroup = True
            FpSpread2.ActiveSheetView.GroupBarVisible = True
            FpSpread2.ActiveSheetView.AllowColumnMove = True
            'Set first level grouping details
            Dim gi As New FarPoint.Web.Spread.GroupInfo
            gi.BackColor = Color.LightSteelBlue
            gi.ForeColor = Color.Black
            FpSpread2.ActiveSheetView.GroupInfos.Add(gi)
            'Set second level grouping details
            gi = New FarPoint.Web.Spread.GroupInfo
            gi.ForeColor = Color.Black  'Navy
            FpSpread2.ActiveSheetView.GroupInfos.Add(gi)
            'add additional levels if desired, like above, here
            FpSpread2.ShowFocusRectangle = True

        End Sub
        Sub InitSpread()
            FpSpread2.ScrollBarBaseColor = Color.LightSteelBlue
            With FpSpread2.Sheets(0)
                .HeaderGrayAreaColor = Color.LightSteelBlue
                Dim ch As New FarPoint.Web.Spread.LabelCellType
                ch.BackgroundImageUrl = "images/greenbk.jpg"
                .ColumnHeader.DefaultStyle.CellType = ch
                .ColumnHeader.DefaultStyle.ForeColor = Color.White
                .ColumnHeader.DefaultStyle.Font.Name = "Verdana"
                .SheetCornerStyle.CellType = ch

            End With
        End Sub
        Private Sub PUANLAMA_GR_DB_DOLDUR()
            SuankiSheetNo = 0
            SecilenSheetName = ""
            SuankiSheetNo = FpSpread3.ActiveSheetViewIndex
            SecilenSheetName = FpSpread3.Sheets(0).SheetName
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
                FpSpread3.Sheets(0).Cells(i, 0).Text = Yaz
                i = i + 1
            End While
            DbConn.Kapat()
        End Sub
        Private Sub GIRENKIM()
            IKID = Session("IKIDSI")
            'IKID = 1001690
            '' GİREN ŞEF İSE
            SQL = ""
            SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID='" & IKID & "'" _
            & " AND IK.NUFUS.DRM=1" _
            & " AND IK.UNITESI.DURUMU='AKTIF'" _
            & " AND IK.UNITESI.ALT_GRUP LIKE '%ŞEFİ%'"
            '& " OR IK.UNITESI.ALT_GRUP LIKE '%HEKİMİ%'" _
            '& " ORDER BY ID "

            Dim DbConn1 As New ConnectOracleDilerIK
            DbConn1.RaporWhile(SQL)
            While DbConn1.MyDataReader.Read
                GIRENUNVAN = "ŞEF"
                KayitYapan = 2
                IDX = DbConn1.MyDataReader.GetValue(0).ToString()
                GIRENADI = DbConn1.MyDataReader.GetValue(1).ToString()
                GIRENSAD = DbConn1.MyDataReader.GetValue(2).ToString()
                GIRENUNITE = DbConn1.MyDataReader.GetValue(3).ToString()
                GIRENBOLUM = DbConn1.MyDataReader.GetValue(4).ToString()
                GIRENALTGRUP = DbConn1.MyDataReader.GetValue(5).ToString()

            End While
            DbConn1.Kapat()

            '' GİREN MÜDÜR İSE
            SQL = ""
            SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID='" & IKID & "'" _
            & " AND IK.UNITESI.DURUMU='AKTIF'" _
            & " AND (IK.UNITESI.ALT_GRUP LIKE '%MÜDÜRÜ%' OR IK.UNITESI.ALT_GRUP LIKE '%MÜDÜR Y%')"
            '& " AND IK.UNITESI.ALT_GRUP NOT LIKE '%MÜDÜRÜ%'"
            Dim DbConn2 As New ConnectOracleDilerIK
            DbConn2.RaporWhile(SQL)
            While DbConn2.MyDataReader.Read
                GIRENUNVAN = "MÜDÜR"
                KayitYapan = 3
                IDX = DbConn2.MyDataReader.GetValue(0).ToString()
                GIRENADI = DbConn2.MyDataReader.GetValue(1).ToString()
                GIRENSAD = DbConn2.MyDataReader.GetValue(2).ToString()
                GIRENUNITE = DbConn2.MyDataReader.GetValue(3).ToString()
                GIRENBOLUM = DbConn2.MyDataReader.GetValue(4).ToString()
                GIRENALTGRUP = DbConn2.MyDataReader.GetValue(5).ToString()
            End While
            DbConn2.Kapat()
            '' GİREN MÜHENDİS İSE
            SQL = ""
            SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID='" & IKID & "'" _
            & " AND IK.UNITESI.DURUMU='AKTIF'" _
            & " AND IK.UNITESI.ALT_GRUP LIKE '%MÜHENDİSİ%'"
            Dim DbConn3 As New ConnectOracleDilerIK
            DbConn3.RaporWhile(SQL)
            While DbConn3.MyDataReader.Read
                GIRENUNVAN = "MÜHENDİSİ"
                KayitYapan = 1
                IDX = DbConn3.MyDataReader.GetValue(0).ToString()
                GIRENADI = DbConn3.MyDataReader.GetValue(1).ToString()
                GIRENSAD = DbConn3.MyDataReader.GetValue(2).ToString()
                GIRENUNITE = DbConn3.MyDataReader.GetValue(3).ToString()
                GIRENBOLUM = DbConn3.MyDataReader.GetValue(4).ToString()
                GIRENALTGRUP = DbConn3.MyDataReader.GetValue(5).ToString()
            End While
            DbConn3.Kapat()


            SQL = ""
            SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID='" & IKID & "'" _
            & " AND IK.UNITESI.DURUMU='AKTIF'" _
            & " AND IK.UNITESI.ALT_GRUP LIKE '%FABRİKA MÜDÜRÜ%'"
            Dim DbConnFM As New ConnectOracleDilerIK
            DbConnFM.RaporWhile(SQL)
            While DbConnFM.MyDataReader.Read
                GIRENUNVAN = "FABRİKA MÜDÜRÜ"
                KayitYapan = 4
                IDX = DbConnFM.MyDataReader.GetValue(0).ToString()
                GIRENADI = DbConnFM.MyDataReader.GetValue(1).ToString()
                GIRENSAD = DbConnFM.MyDataReader.GetValue(2).ToString()
                GIRENUNITE = DbConnFM.MyDataReader.GetValue(3).ToString()
                GIRENBOLUM = DbConnFM.MyDataReader.GetValue(4).ToString()
                GIRENALTGRUP = DbConnFM.MyDataReader.GetValue(5).ToString()
            End While
            DbConnFM.Kapat()

            If GIRENUNVAN = "FABRİKA MÜDÜRÜ" And IKADSADX = "İnsan Kaynakları" Then
                GirenBilgisi.Text = "Programa Giriş Yapan  İnsan Kaynakları Kullanıcısı..."
            Else
                GirenBilgisi.Text = "Programa Giriş Yapan  " & IDX & "  Sicil Numaralı  " & GIRENBOLUM & "  " & GIRENADI & "  " & GIRENSAD & "  " & GIRENALTGRUP
            End If

            If IKID = "7001111" Then
                GIRENUNVAN = "MÜDÜR"
                KayitYapan = 2
                IDX = "7001111"
                GIRENADI = "MURAT"
                GIRENSAD = "DURAK"
                GIRENUNITE = "Diler Liman Müdürlüğü"
                GIRENBOLUM = "Diler Liman Müdürlüğü"
                GIRENALTGRUP = "Diler Liman Müdürlüğü"
            End If

            If IKID = "3698" Then
                GIRENUNVAN = "MÜDÜR"
                KayitYapan = 3
                IDX = "3698"
                GIRENADI = "SİNAN"
                GIRENSAD = "EVCİMEN"
                GIRENUNITE = "Diler Liman Müdürlüğü"
                GIRENBOLUM = "Diler Liman Müdürlüğü"
                GIRENALTGRUP = "Diler Liman Müdürlüğü"
            End If


            Session("GIRENUNITE") = GIRENUNITE
            Session("GIRENBOLUM") = GIRENBOLUM
            Session("GIRENUNVAN") = GIRENUNVAN

        End Sub

        Private Sub SORULARI_GRIDE_GETIR()

            ToplamSheet = FpSpread1.Sheets.Count

            Dim i = 0
            Dim s = 0

            For s = 0 To ToplamSheet - 1
                SuankiSheetNo = s
                i = 0
                SecilenSheetName = FpSpread1.Sheets(s).SheetName
                SQL = ""
                SQL = "SELECT GRUPNO FROM IK.PERFORMANS_SORU_GRUPLARI " &
                " WHERE IK.PERFORMANS_SORU_GRUPLARI.GRUPACK='" & SecilenSheetName & "'"
                Dim DbConn As New ConnectOracleDilerIK
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    SecilenSheetGrupNo = DbConn.MyDataReader.Item(0)
                End While
                DbConn.Kapat()
                ''Şimdi Seçilen Sheete Göre Grid Doldur
                SQL = ""
                SQL = "SELECT GRUPNO,SORUNO,SORUACK FROM IK.PERFORMANS_GRUP_SORULARI " _
                & " WHERE IK.PERFORMANS_GRUP_SORULARI.GRUPNO='" & SecilenSheetGrupNo & "'" _
                & " ORDER BY GRUPNO,SORUNO"
                Dim DbConn2 As New ConnectOracleDilerIK
                DbConn2.RaporWhile(SQL)

                FpSpread1.Sheets(SuankiSheetNo).RowCount = 0
                While DbConn2.MyDataReader.Read
                    FpSpread1.Sheets(SuankiSheetNo).RowCount = FpSpread1.Sheets(SuankiSheetNo).RowCount + 1
                    FpSpread1.Sheets(SuankiSheetNo).Cells(i, 0).Text = DbConn2.MyDataReader.GetValue(2).ToString()
                    i = i + 1
                End While
                DbConn2.Kapat()
            Next s
        End Sub

        Private Sub GIRENIN_ALTLARINI_GETIR()
            Dim i = 0
            datasetOlustur()
            FpSpread2.Sheets(0).RowCount = 0
            GIRENUNITE = Session("GIRENUNITE")
            GIRENBOLUM = Session("GIRENBOLUM")
            GIRENUNVAN = Session("GIRENUNVAN")
            If GIRENUNVAN = "FABRİKA MÜDÜRÜ" Then
                DropDownList1.Items.Clear()
                'TAŞERON FIRMA
                SQL = ""
                SQL = "SELECT DISTINCT (IK.UNITESI.ALT_GRUP) FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                & " WHERE IK.UNITESI.ID<>" & IKID _
                & " AND IK.NUFUS.DRM=" & 1 _
                & " AND IK.UNITESI.DURUMU='AKTIF'" _
                & " AND IK.UNITESI.BOLUM<>'TAŞERON FIRMA'" _
                & " ORDER BY IK.UNITESI.ALT_GRUP"
                Dim DbConnFM As New ConnectOracleDilerIK
                DbConnFM.RaporWhile(SQL)
                While DbConnFM.MyDataReader.Read
                    DropDownList1.Items.Add(DbConnFM.MyDataReader.GetValue(0).ToString())
                End While
                DbConnFM.Kapat()
            End If
            '& " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ŞEF%')" _

            If GIRENUNVAN = "MÜDÜR" Then
                SQL = ""
                SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                & " WHERE IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
                & " AND IK.UNITESI.ID<>" & IKID _
                & " AND IK.UNITESI.DURUMU='AKTIF'" _
                & " AND IK.UNITESI.BOLUM<>'TAŞERON FIRMA'" _
                & " AND IK.NUFUS.DRM=" & 1 _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜDÜRÜ%')"
                If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                End If
                Dim DbConn As New ConnectOracleDilerIK
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    If DegerlendirmeyeUygunMu2(DbConn.MyDataReader.GetValue(0).ToString()) Then 'Değerlendirmeye uygun değilse listede gözükmeyecek
                        FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
                        FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(0).ToString()
                        FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.GetValue(1).ToString() & " " & DbConn.MyDataReader.GetValue(2).ToString()
                        FpSpread2.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.GetValue(3).ToString()
                        FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.GetValue(4).ToString()
                        FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn.MyDataReader.GetValue(5).ToString()
                        i = i + 1
                    End If
                End While
                DbConn.Kapat()
            End If
            If GIRENUNVAN = "ŞEF" Then
                SQL = ""
                SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                & " WHERE IK.UNITESI.BOLUM='" & GIRENBOLUM & "'" _
                & " AND IK.UNITESI.ID<>" & IKID _
                & " AND IK.UNITESI.DURUMU='AKTIF'" _
                & " AND IK.UNITESI.BOLUM<>'TAŞERON FIRMA'" _
                & " AND IK.NUFUS.DRM=" & 1 _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ŞEF%')"
                If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                End If


                ''SEZGIN BEY KAYITLARDA SEF GOZUKMESEDE FIZIKCILERI SEF GIBI ONAYLAMASI ICIN
                'If IKID = 1001117 Then
                '    SQL = ""
                '    SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                '    & " WHERE IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
                '    & " AND IK.UNITESI.ID<>" & IKID _
                '    & " AND IK.NUFUS.ID<>" & 1001841 _
                '    & " AND IK.UNITESI.DURUMU='AKTIF'" _
                '    & " AND IK.UNITESI.BOLUM<>'TAŞERON FIRMA'" _
                '    & " AND IK.UNITESI.BOLUM<>'TEL-ÇUBUK HH K_GÜVENCE ŞEFLİĞİ'" _
                '    & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜHENDİS%')" _
                '    & " AND IK.NUFUS.DRM=" & 1
                '    If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                '        SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                '    End If
                'End If

                'SEZGIN BEY KAYITLARDA SEF GOZUKMESEDE FIZIKCILERI SEF GIBI ONAYLAMASI ICIN ---Emre Özakyol gözükmediği için 25.10.2013 de yapılan değişiklik
                If IKID = 1001117 Then
                    SQL = ""
                    SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                    & " WHERE IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
                    & " AND IK.UNITESI.ID<>" & IKID _
                    & " AND IK.NUFUS.ID<>" & 1001841 _
                    & " AND IK.UNITESI.DURUMU='AKTIF'" _
                    & " AND IK.UNITESI.BOLUM<>'TAŞERON FIRMA'" _
                    & " AND IK.UNITESI.BOLUM<>'TEL-ÇUBUK HH K_GÜVENCE ŞEFLİĞİ'" _
                    & " AND IK.NUFUS.DRM=" & 1
                    If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                        SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                    End If
                End If


                Dim DbConn1 As New ConnectOracleDilerIK
                DbConn1.RaporWhile(SQL)
                While DbConn1.MyDataReader.Read
                    If DegerlendirmeyeUygunMu2(DbConn1.MyDataReader.GetValue(0).ToString()) Then 'Değerlendirmeye uygun değilse listede gözükmeyecek
                        FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
                        FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn1.MyDataReader.GetValue(0).ToString()
                        FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn1.MyDataReader.GetValue(1).ToString() & " " & DbConn1.MyDataReader.GetValue(2).ToString()
                        FpSpread2.Sheets(0).Cells(i, 3).Text = DbConn1.MyDataReader.GetValue(3).ToString()
                        FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn1.MyDataReader.GetValue(4).ToString()
                        FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn1.MyDataReader.GetValue(5).ToString()
                        i = i + 1
                    End If
                End While
                DbConn1.Kapat()
            End If
            If GIRENUNVAN = "MÜHENDİSİ" Then


                SQL = ""
                SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                & " WHERE IK.UNITESI.BOLUM='" & GIRENBOLUM & "'" _
                & " AND IK.UNITESI.ID<>" & IKID _
                 & " AND IK.UNITESI.BOLUM<>'TAŞERON FIRMA'" _
                & " AND IK.NUFUS.DRM=" & 1 _
                & " AND IK.UNITESI.DURUMU='AKTIF'" _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ŞEF%')" _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜHENDİS%')"
                If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                End If


                If IKID = 1002587 Then
                    SQL = ""
                    SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                    & " WHERE IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
                    & " AND IK.UNITESI.ID<>" & IKID _
                    & " AND IK.NUFUS.ID<>" & 1001117 _
                    & " AND IK.NUFUS.ID<>" & 1001841 _
                    & " AND IK.UNITESI.DURUMU='AKTIF'" _
                    & " AND IK.UNITESI.BOLUM<>'TAŞERON FIRMA'" _
                    & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%ŞEF%')" _
                    & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜHENDİS%')" _
                    & " AND IK.NUFUS.DRM=" & 1
                    If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                        SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                    End If
                End If


                'SQL = ""
                'SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                '& " WHERE IK.UNITESI.BOLUM='" & GIRENBOLUM & "'" _
                '& " AND IK.UNITESI.ID<>" & IKID _
                '& " AND IK.NUFUS.DRM=" & 1
                'If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                '    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                'End If
                Dim DbConn2 As New ConnectOracleDilerIK
                DbConn2.RaporWhile(SQL)
                While DbConn2.MyDataReader.Read
                    If DegerlendirmeyeUygunMu2(DbConn2.MyDataReader.GetValue(0).ToString()) Then 'Değerlendirmeye uygun değilse listede gözükmeyecek
                        FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
                        FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn2.MyDataReader.GetValue(0).ToString()
                        FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn2.MyDataReader.GetValue(1).ToString() & " " & DbConn2.MyDataReader.GetValue(2).ToString()
                        FpSpread2.Sheets(0).Cells(i, 3).Text = DbConn2.MyDataReader.GetValue(3).ToString()
                        FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn2.MyDataReader.GetValue(4).ToString()
                        FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn2.MyDataReader.GetValue(5).ToString()
                        i = i + 1
                    End If
                End While
                DbConn2.Kapat()
            End If
            FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 2


            AKTIF_DONEM_NOTU_GETIR()
            'ONAYLADIM_MI()
        End Sub

        Private Sub AKTIF_DONEM_NOTU_GETIR()

            Try
                SQL = ""
                SQL = "SELECT * FROM PERFORMANS_DONEM"
                Dim DbConn2 As New ConnectOracleDilerIK
                DbConn2.RaporWhile(SQL)
                While DbConn2.MyDataReader.Read
                    YilX = DbConn2.MyDataReader.GetValue(0).ToString()
                    DonemX = DbConn2.MyDataReader.GetValue(1).ToString()
                End While
                DbConn2.Kapat()
                IKDegerlendirilenID = ""
                Dim k
                For k = 0 To FpSpread2.Sheets(0).RowCount - 1
                    IKDegerlendirilenID = FpSpread2.Sheets(0).Cells(k, 1).Text
                    SQL = ""
                    SQL = "SELECT YUZDE FROM PERFORMANS_OZET " _
                    & " WHERE ID=" & IKDegerlendirilenID _
                    & " AND YIL=" & YilX _
                    & " AND DONEM=" & DonemX
                    Dim DbConn As New ConnectOracleDilerIK
                    DbConn.RaporWhile(SQL)
                    While DbConn.MyDataReader.Read
                        FpSpread2.Sheets(0).Cells(k, 6).Text = DbConn.MyDataReader.GetValue(0).ToString()
                    End While
                    DbConn.Kapat()
                Next
            Catch ex As Exception

            End Try

            ONAYLADIM_MI()

            'Try
            '    SQL = ""
            '    SQL = "SELECT * FROM PERFORMANS_DONEM"
            '    Dim DbConn2 As New ConnectOracleDilerIK
            '    DbConn2.RaporWhile(SQL)
            '    While DbConn2.MyDataReader.Read
            '        YilX = DbConn2.MyDataReader.GetValue(0).ToString()
            '        DonemX = DbConn2.MyDataReader.GetValue(1).ToString()
            '    End While
            '    DbConn2.Kapat()

            '    IKDegerlendirilenID = ""
            '    Dim k
            '    For k = 0 To FpSpread2.Sheets(0).RowCount - 1
            '        IKDegerlendirilenID = FpSpread2.Sheets(0).Cells(k, 1).Text
            '        SQL = ""
            '        SQL = "SELECT YUZDE FROM PERFORMANS_OZET " _
            '        & " WHERE ID=" & IKDegerlendirilenID _
            '        & " AND YIL=" & YilX _
            '        & " AND DONEM=" & DonemX
            '        Dim DbConn As New ConnectOracleDilerIK
            '        DbConn.RaporWhile(SQL)
            '        While DbConn.MyDataReader.Read
            '            FpSpread2.Sheets(0).Cells(k, 6).Text = DbConn.MyDataReader.GetValue(0).ToString()
            '        End While
            '        DbConn.Kapat()
            '    Next
            'Catch ex As Exception

            'End Try
        End Sub

        Protected Sub FpSpread2_Grouped(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpread2.Grouped
            Dim ss As FarPoint.Web.Spread.FpSpread = sender
            Dim gm As FarPoint.Web.Spread.Model.GroupDataModel
            If TypeOf (ss.ActiveSheetView.DataModel) Is FarPoint.Web.Spread.Model.GroupDataModel Then
                gm = ss.ActiveSheetView.DataModel
                If TypeOf (gm.GroupComparer) Is MyGroupComparer Then
                    Dim i As Integer
                    For i = 0 To ss.ActiveSheetView.RowCount - 1
                        If gm.IsGroup(i) Then
                            Dim g As FarPoint.Web.Spread.Model.Group
                            g = gm.GetGroup(i)
                            If TypeOf (g.Rows(0)) Is Integer Then
                                Dim r As Integer = ss.ActiveSheetView.ColumnHeaderAutoTextIndex
                                Dim s As String = ss.ActiveSheetView.GetColumnLabel(r, ss.ActiveSheetView.GetViewColumnFromModelColumn(g.Column))
                                If s.IndexOf("Birth") >= 0 Then
                                    g.Text = s & ": " & GetDecade(gm.TargetModel.GetValue(g.Rows(0), g.Column)) & "s"
                                Else
                                    g.Text = s & ": " & GetYear(gm.TargetModel.GetValue(g.Rows(0), g.Column))
                                End If
                            End If
                        End If
                    Next
                End If

            End If
        End Sub


        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            'Paint the commandbar background
            Dim cmdbar As WebControl = FpSpread2.FindControl("commandBar")
            If Not cmdbar Is Nothing Then
                cmdbar.Attributes.CssStyle.Add("background-image", "url(images/ajax/toolbar.Horizontal.background.gif)")
            End If

            'Paint the 'Group' buttons
            Dim wc As WebControl = FpSpread2.FindControl("groupBar")
            If Not wc Is Nothing Then
                Dim c1 As WebControl
                Dim i As Integer
                For i = 0 To wc.Controls.Count - 1
                    If i Mod 2 = 0 Then
                        'If even control, add the image (don't paint the 'links' image)
                        If TypeOf (wc.Controls(i)) Is WebControl Then
                            c1 = wc.Controls(i)
                            c1.Attributes.CssStyle.Add("background-image", "url(images/ajax/toolbar.Horizontal.background.gif)")
                        End If
                    End If
                Next
            End If

            MyBase.Render(writer)


        End Sub
        Protected Sub FpSpread2_ActiveSheetChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpread2.ActiveSheetChanged
            SORULARI_GRIDE_GETIR()
        End Sub



        Private Sub YoneticimiKontrolu()

            FpSpread1.Sheets(4).Visible = True
            Dim Ne As Integer
            SQL = "SELECT IK.FABRIKAGENEL.YONETICILIK FROM IK.FABRIKAGENEL WHERE IK.FABRIKAGENEL.ID=" & IKDegerlendirilenID
            Dim DbConn As New ConnectOracleDilerIK
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                Ne = Val(DbConn.MyDataReader.GetValue(0).ToString())
            End While
            DbConn.Kapat()
            If Ne = 0 Then
                FpSpread1.Sheets(4).Visible = False
                YoneticiDrm = "H"
            Else
                FpSpread1.Sheets(4).Visible = True
                YoneticiDrm = "E"
            End If
        End Sub

        Protected Sub FpSpread2_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles FpSpread2.ButtonCommand
            'TUM CHECK BOXLARI KALDIR
            ToplamSheet = FpSpread1.Sheets.Count
            Dim l, i
            YoneticiDrm = "H"
            Dim s = 0
            For s = 0 To ToplamSheet - 1
                For i = 0 To FpSpread1.Sheets(s).Rows.Count - 1
                    For l = 1 To 5
                        'FpSpread1.Sheets(s).Cells(i, l).Text = ""
                        FpSpread1.Sheets(s).Cells(i, l).Value = 0
                    Next
                Next i
            Next s
            'AÇIKLAMAYI BOŞALT
            s = 0
            For s = 0 To ToplamSheet - 1
                For i = 0 To FpSpread1.Sheets(s).Rows.Count - 1
                    l = 6
                    'FpSpread1.Sheets(s).Cells(i, l).Text = ""
                    FpSpread1.Sheets(s).Cells(i, l).Text = ""
                Next i
            Next s
            RadioButtonList1.SelectedIndex = 3
            EgitimTalebiX.Text = "-"
            PuanXX.Text = ""
            OranXX.Text = ""
            YuzdeXX.Text = ""
            If (e.CommandName.StartsWith("filter")) Then
                Dim n As Integer = e.CommandName.IndexOf(".") + 1
                Dim state As String = e.CommandName.Substring(n)
                FpSpread2.ActiveSheetView.AutoFilterColumn(5, state)
            End If
            Dim row As Int32 = e.CommandArgument.X
            IKDegerlendirilenID = e.SheetView.Cells(row, 1).Text.Trim
            IKDegerlendirilenAdSoyad = e.SheetView.Cells(row, 2).Text.Trim
            YoneticimiKontrolu()
            Label_AdSad.Text = IKDegerlendirilenAdSoyad
            Label_Id.Text = IKDegerlendirilenID
            IKDAN_BILGI_GETIR()
            IKDAN_EGITIM_GETIR()
            SECILEN_PUANLAMASI_GRID_GETIR()
            SECILEN_PUANI_GETIR_OZETTEN()
            RESIM_GETIR()
            KARSILASTIR()
            SECILENIN_PUANLAMASINI_CHECKED_YAP()
            'D1002447
        End Sub
        Private Sub SECILENIN_PUANLAMASINI_CHECKED_YAP()

            Dim MAXPUANVERENX As Integer
            SQL = ""
            SQL = "SELECT * FROM PERFORMANS_DONEM"
            Dim DbConn2 As New ConnectOracleDilerIK
            DbConn2.RaporWhile(SQL)
            While DbConn2.MyDataReader.Read
                YilX = DbConn2.MyDataReader.GetValue(0).ToString()
                DonemX = DbConn2.MyDataReader.GetValue(1).ToString()
            End While
            DbConn2.Kapat()
            SQL = ""
            SQL = "SELECT MAX(PUANVEREN) FROM PERFORMANS_DATA" _
            & " WHERE YIL=" & YilX _
            & " AND DONEM=" & DonemX _
            & " AND ID=" & Label_Id.Text
            Dim DbConn3 As New ConnectOracleDilerIK
            DbConn3.RaporWhile(SQL)
            While DbConn3.MyDataReader.Read
                MAXPUANVERENX = Val(DbConn3.MyDataReader.GetValue(0).ToString())
            End While
            DbConn3.Kapat()
            If MAXPUANVERENX > 0 Then
                SQL = ""
                SQL = "SELECT * FROM PERFORMANS_DATA" _
                & " WHERE YIL=" & YilX _
                & " AND DONEM=" & DonemX _
                & " AND ID=" & Label_Id.Text _
                & " AND PUANVEREN=" & MAXPUANVERENX _
                & " ORDER BY ID,SORUGRUPNO,GRUPSORUNO,PUANVEREN ASC"
                Dim DbConn As New ConnectOracleDilerIK
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    Dim SeetNo = DbConn.MyDataReader.GetValue(3).ToString()
                    Dim SatirNo = DbConn.MyDataReader.GetValue(4).ToString()
                    Dim KolonNo = DbConn.MyDataReader.GetValue(5).ToString()
                    Dim Ack = DbConn.MyDataReader.GetValue(7).ToString()
                    FpSpread1.Sheets(SeetNo - 1).Cells(SatirNo - 1, KolonNo).Value = 1
                    FpSpread1.Sheets(SeetNo - 1).Cells(SatirNo - 1, 6).Text = Ack
                    FpSpread1.Sheets(SeetNo - 1).Cells(SatirNo - 1, 6).Value = Ack
                    's = 0
                    'For s = 0 To ToplamSheet - 1
                    '    For i = 0 To FpSpread1.Sheets(s).Rows.Count - 1
                    '        l = 6
                    '        'FpSpread1.Sheets(s).Cells(i, l).Text = ""
                    '        FpSpread1.Sheets(s).Cells(i, l).Text = ""
                    '    Next i
                    'Next s

                End While
                DbConn.Kapat()
            Else
            End If

        End Sub
        Private Sub KARSILASTIR()
            Dim F
            For F = 0 To FpSpread3.Sheets(0).RowCount - 1
                Dim A, B, C, D
                'MÜHENDİS
                A = Val(FpSpread3.Sheets(0).Cells(F, 1).Value)
                'ŞEF
                B = Val(FpSpread3.Sheets(0).Cells(F, 2).Value)
                'MÜDÜRÜ
                C = Val(FpSpread3.Sheets(0).Cells(F, 3).Value)
                'FABRİKA MÜDÜRÜ
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

        Private Sub SECILEN_PUANLAMASI_GRID_GETIR()
            FpSpread3.Sheets(0).RowCount = 0
            PUANLAMA_GR_DB_DOLDUR()
            'DÖNEM ve YIL BUL
            SQL = ""
            SQL = "SELECT * FROM PERFORMANS_DONEM"
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
                SQL = "SELECT (SORUGRUPNO || '.' || GRUPSORUNO) As SORU,PUANVEREN,PUANI FROM PERFORMANS_DATA " _
                & " WHERE ID=" & Label_Id.Text _
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

        Private Sub SECILEN_PUANI_GETIR_OZETTEN()
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

            PuanXX.Text = ""
            OranXX.Text = ""
            YuzdeXX.Text = ""
            IKDegerlendirilenID = ""
            IKDegerlendirilenID = Label_Id.Text
            SQL = ""
            SQL = "SELECT PUAN,ORAN,YUZDE,ILERLEME,EGITIMISTEK FROM PERFORMANS_OZET " _
            & " WHERE ID=" & IKDegerlendirilenID _
            & " AND DONEM=" & DonemX _
            & " AND YIL=" & YilX

            Dim DbConn As New ConnectOracleDilerIK
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                PuanXX.Text = DbConn.MyDataReader.GetValue(0).ToString()
                OranXX.Text = DbConn.MyDataReader.GetValue(1).ToString()
                YuzdeXX.Text = DbConn.MyDataReader.GetValue(2).ToString()
                If DbConn.MyDataReader.GetValue(3).ToString() < 0 Then
                    RadioButtonList1.SelectedIndex = -1
                Else
                    RadioButtonList1.SelectedIndex = DbConn.MyDataReader.GetValue(3).ToString()
                End If

                EgitimTalebiX.Text = DbConn.MyDataReader.GetValue(4).ToString()
            End While
            DbConn.Kapat()

        End Sub

        Private Sub RESIM_GETIR()

            Dim ADRES As String
            Dim tcno As String

            Dim sql = "SELECT TCNO FROM NUFUS " _
                & " WHERE ID = " & Label_Id.Text
            Dim DbConn As New ConnectOracleDilerIK
            DbConn.RaporWhile(sql)
            While DbConn.MyDataReader.Read
                tcno = DbConn.MyDataReader.Item("TCNO")
            End While
            DbConn.Kapat()


            Try
                If String.IsNullOrEmpty(tcno.ToString()) Then
                    ADRES = "/tum_fotolar/diler.jpg"
                Else
                    ADRES = "/tum_fotolar/" & tcno.ToString() & "-" & Label_Id.Text & ".JPG"
                End If
                Image1.ImageUrl = "http://" + System.Web.HttpContext.Current.Request.Url.Host + System.Web.HttpContext.Current.Request.ApplicationPath + ADRES

            Catch ex As Exception
            End Try

        End Sub

        Private Sub IKDAN_EGITIM_GETIR()
            Gr_Egitim.Sheets(0).RowCount = 0
            Dim Sql2 = "SELECT DISTINCT * FROM IK.ALINAN_EGITIMLER WHERE ID=" & Label_Id.Text
            Sql2 = Sql2 & " ORDER BY BASLANGIC_TARIHI DESC "
            Dim I As Integer
            Dim DbConn2 As New ConnectOracleDilerIK
            DbConn2.RaporWhile(Sql2)
            I = 0
            While DbConn2.MyDataReader.Read
                Try
                    I = I + 1
                    Gr_Egitim.Sheets(0).RowCount = Gr_Egitim.Sheets(0).RowCount + 1
                    Gr_Egitim.Sheets(0).Cells(I - 1, 0).Value = DbConn2.MyDataReader.Item("EGITIM_TANIMI")
                Catch ex As Exception
                End Try
            End While
            DbConn2.Kapat()
        End Sub

        Private Sub IKDAN_BILGI_GETIR()
            SQL = ""
            SQL = "SELECT IK.NUFUS.D_TAR,IK.NUFUS.M_HAL,IK.FABRIKAGENEL.IS_BAS_TAR,IK.TAHSIL.GRUP" _
            & " FROM IK.NUFUS INNER JOIN IK.FABRIKAGENEL ON IK.NUFUS.ID=IK.FABRIKAGENEL.ID" _
            & " INNER JOIN IK.TAHSIL ON IK.FABRIKAGENEL.ID=IK.TAHSIL.ID" _
            & " WHERE IK.NUFUS.ID=" & Label_Id.Text _
            & " AND TAHSIL.BITIS = (SELECT MAX(TI.BITIS) FROM IK.TAHSIL TI " _
            & " WHERE(TI.ID = IK.NUFUS.ID) )"



            Dim DbConn1 As New ConnectOracleDilerIK
            DbConn1.RaporWhile(SQL)
            While DbConn1.MyDataReader.Read
                TERSCEVIR(DbConn1.MyDataReader.GetValue(0).ToString())
                Label_DogTar.Text = DonenTersTarih1
                Label_MHal.Text = DbConn1.MyDataReader.GetValue(1).ToString()
                TERSCEVIR(DbConn1.MyDataReader.GetValue(2).ToString())
                Label_IsBasTar.Text = DonenTersTarih1
                labelDonem.Text = DbConn1.MyDataReader.GetValue(3).ToString()
            End While
            DbConn1.Kapat()
        End Sub
        Public Sub TERSCEVIR(ByVal gelen As Double)
            DonenTersTarih1 = ""
            Dim YIL, AY, GUN As String
            YIL = Microsoft.VisualBasic.Left(gelen, 4)
            AY = Mid(gelen, 5, 2)
            GUN = Mid(gelen, 7, 2)
            DonenTersTarih1 = GUN & "/" & AY & "/" & YIL
        End Sub
        Public Sub CEVIR(ByVal gelen As Date)
            DonenTarih = ""
            Dim YIL, AY, GUN As String
            YIL = Microsoft.VisualBasic.Year(gelen)
            AY = Microsoft.VisualBasic.Month(gelen)
            If Microsoft.VisualBasic.Len(AY.ToString) = 1 Then AY = "0" & AY
            GUN = Microsoft.VisualBasic.Day(gelen)
            If Microsoft.VisualBasic.Len(GUN) = 1 Then GUN = "0" & GUN
            DonenTarih = YIL & AY & GUN
        End Sub

        Private Function GetYear(ByVal value As DateTime) As Integer
            Return value.Year
        End Function

        Private Function GetDecade(ByVal value As DateTime) As Integer
            Dim x As Integer = 0
            x = value.Year Mod 10
            x = value.Year - x
            Return x
        End Function

        Protected Sub FpSpread2_UpdateCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles FpSpread2.UpdateCommand

        End Sub

        Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
            If GIRENUNVAN = "FABRİKA MÜDÜRÜ" Then
                FABRIKA_MUDURU_ICIN_GRIDDOLDUR()
            Else
                GIRENIN_ALTLARINI_GETIR()
            End If
        End Sub
        Private Sub FABRIKA_MUDURU_ICIN_GRIDDOLDUR()
            datasetOlustur()
            FpSpread2.Sheets(0).RowCount = 0

            Dim i = 0
            SQL = ""
            SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID<>" & IKID _
            & " AND IK.NUFUS.DRM=" & 1
            If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
            End If
            Dim DbConn As New ConnectOracleDilerIK
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                If DegerlendirmeyeUygunMu2(DbConn.MyDataReader.GetValue(0).ToString()) Then 'Değerlendirmeye uygun değilse listede gözükmeyecek
                    FpSpread2.Sheets(0).RowCount = FpSpread2.Sheets(0).RowCount + 1
                    FpSpread2.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(0).ToString()
                    FpSpread2.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.GetValue(1).ToString() & " " & DbConn.MyDataReader.GetValue(2).ToString()
                    FpSpread2.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.GetValue(3).ToString()
                    FpSpread2.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.GetValue(4).ToString()
                    FpSpread2.Sheets(0).Cells(i, 5).Text = DbConn.MyDataReader.GetValue(5).ToString()
                    'FpSpread1.Sheets(0).Cells(i, 5).Text = DbConn.MyDataReader.GetValue(5).ToString()
                    i = i + 1
                End If
            End While
            DbConn.Kapat()


            AKTIF_DONEM_NOTU_GETIR()

        End Sub
        Private Sub UstuOnayladimi()
            SQL = ""
            SQL = "SELECT MAX(PUANVEREN) FROM PERFORMANS_DATA" _
            & " WHERE ID=" & Label_Id.Text _
            & " AND YIL=" & YilX _
            & " AND DONEM=" & DonemX

            Dim DbConn2 As New ConnectOracleDilerIK
            DbConn2.RaporWhile(SQL)
            While DbConn2.MyDataReader.Read
                UstumOnayladimi = DbConn2.MyDataReader.GetValue(0).ToString()
                If UstumOnayladimi = "" Then
                    UstumOnayladimi = 1
                End If
            End While
            DbConn2.Kapat()
        End Sub
        Dim UstumOnayladimi 'Globelde tutarak oracle connectionu azaltmak
        Private Sub KAYIT_SAKLA()
            Dim K = 0
            Dim f, g
            YilX = 0
            DonemX = 0
            Dim a = FpSpread1.Sheets.Count
            Dim xx

            datasetOlustur() 'Bönem ve Yıl Bul kullanarak her seferinde oracle a baglanmaktansa bu method kullanılıyor.
            'Dim UstumOnayladimi 
            UstuOnayladimi() 'Globelda oluşturulan UstumOnayladımı değişkenine atacak. oracle connection azalacak
            Dim KayitOlacakSicilNo = Label_Id.Text
            YilX = PerforYil
            DonemX = PerforDonem
            GIRENKIM() 'Döngüye sokmadan globalde tek sefer de connection.

            Dim ManuelConn As New ConnectOracleDilerIK
            ManuelConn.DbBaglan()


            FpSpread2.ClientAutoCalculation = True
            FpSpread2.RenderCSSClass = True
            FpSpread2.SaveChanges()
            FpSpread1.SaveChanges()


            If KayitYapan < UstumOnayladimi Then
                AspNetMsgFunc(":...Artık Bu Değerlendirmeyi Yapamazsınız...:")
                GoTo SON
            Else

                For xx = 0 To FpSpread1.Sheets.Count - 1
                    'Dim KayitOlacakSicilNo = Label_Id.Text 'üst satıra taşıdım
                    SuankiSheetNo = 0
                    SecilenSheetName = ""
                    SuankiSheetNo = xx
                    SecilenSheetName = FpSpread1.Sheets(SuankiSheetNo).SheetName
                    Dim s1
                    Dim GrupNo = SuankiSheetNo + 1
                    For f = 0 To FpSpread1.Sheets(SuankiSheetNo).RowCount - 1
                        For g = 1 To FpSpread1.Sheets(SuankiSheetNo).ColumnCount - 1
                            s1 = FpSpread1.Sheets(SuankiSheetNo).Cells(f, g).Text
                            If s1 <> "True" Then
                                s1 = "False"
                            End If
                            If s1 = True Then
                                Dim GrupSoruNo = f + 1
                                Dim Puanx = g
                                Aciklamax = ""
                                Aciklamax = FpSpread1.Sheets(SuankiSheetNo).Cells(f, 6).Text
                                'DÖNEM ve YIL BUL  ''Manuel connectiondan önce de çalışıyordu
                                'SQL = ""
                                'SQL = "SELECT * FROM PERFORMANS_DONEM"
                                'Dim DbConn As New ConnectOracleDilerIK
                                'DbConn.RaporWhile(SQL)
                                'While DbConn.MyDataReader.Read
                                '    YilX = DbConn.MyDataReader.GetValue(0).ToString()
                                '    DonemX = DbConn.MyDataReader.GetValue(1).ToString()
                                'End While
                                'DbConn.Kapat()

                                'YilX = PerforYil 'Üst satıra taşıdım
                                'DonemX = PerforDonem

                                'KAYIT YAPAN BUL
                                'GIRENKIM()
                                'KONTROL1 ''Manuel connectiondan önce de çalışıyordu
                                'SQL = ""
                                'SQL = "SELECT MAX(PUANVEREN) FROM PERFORMANS_DATA" _
                                '& " WHERE ID=" & KayitOlacakSicilNo _
                                '& " AND YIL=" & YilX _
                                '& " AND DONEM=" & DonemX

                                'Dim DbConn2 As New ConnectOracleDilerIK
                                'DbConn2.RaporWhile(SQL)
                                'While DbConn2.MyDataReader.Read
                                '    UstumOnayladimi = DbConn2.MyDataReader.GetValue(0).ToString()
                                '    If UstumOnayladimi = "" Then
                                '        UstumOnayladimi = 1
                                '    End If
                                'End While
                                'DbConn2.Kapat()

                                'If KayitYapan < UstumOnayladimi Then ''dış kontrol yaptım
                                '    AspNetMsgFunc(":...Artık Bu Değerlendirmeyi Yapamazsınız...:")
                                '    GoTo SON
                                'Else
                                'SQL = ""
                                'SQL = "DELETE PERFORMANS_DATA " _
                                '& " WHERE PERFORMANS_DATA.ID=" & KayitOlacakSicilNo _
                                '& " AND PERFORMANS_DATA.YIL=" & YilX _
                                '& " AND PERFORMANS_DATA.DONEM=" & DonemX _
                                '& " AND PERFORMANS_DATA.SORUGRUPNO=" & GrupNo _
                                '& " AND PERFORMANS_DATA.GRUPSORUNO=" & GrupSoruNo _
                                '& " AND PERFORMANS_DATA.PUANVEREN=" & KayitYapan

                                'Dim DbConn3 As New ConnectOracleDilerIK
                                'DbConn3.Sil(SQL)
                                'DbConn3.Kapat()

                                SQL = ""
                                SQL = "DELETE PERFORMANS_DATA " _
                                & " WHERE PERFORMANS_DATA.ID=" & KayitOlacakSicilNo _
                                & " AND PERFORMANS_DATA.YIL=" & YilX _
                                & " AND PERFORMANS_DATA.DONEM=" & DonemX _
                                & " AND PERFORMANS_DATA.SORUGRUPNO=" & GrupNo _
                                & " AND PERFORMANS_DATA.GRUPSORUNO=" & GrupSoruNo _
                                & " AND PERFORMANS_DATA.PUANVEREN=" & KayitYapan
                                ManuelConn.Sil(SQL)

                                'SQL = ""
                                'SQL = "INSERT INTO PERFORMANS_DATA (YIL,DONEM,ID,SORUGRUPNO,GRUPSORUNO," _
                                '& " PUANI,PUANVEREN,ACK)  VALUES " _
                                ' & "(" & YilX & "," _
                                ' & DonemX & "," _
                                ' & KayitOlacakSicilNo & "," _
                                ' & GrupNo & "," _
                                ' & GrupSoruNo & "," _
                                ' & Puanx & "," _
                                ' & KayitYapan & "," _
                                ' & "'" & Aciklamax & "')"
                                'Dim DbConn1 As New ConnectOracleDilerIK
                                'DbConn1.SaveUpdate(SQL)
                                'DbConn1.Kapat()

                                SQL = ""
                                SQL = "INSERT INTO PERFORMANS_DATA (YIL,DONEM,ID,SORUGRUPNO,GRUPSORUNO," _
                                & " PUANI,PUANVEREN,ACK)  VALUES " _
                                 & "(" & YilX & "," _
                                 & DonemX & "," _
                                 & KayitOlacakSicilNo & "," _
                                 & GrupNo & "," _
                                 & GrupSoruNo & "," _
                                 & Puanx & "," _
                                 & KayitYapan & "," _
                                 & "'" & Aciklamax & "')"
                                ManuelConn.SaveUpdate(SQL)

                                'SQL = ""
                                'SQL = "DELETE PERFORMANS_OZET " _
                                '& " WHERE PERFORMANS_OZET.ID=" & KayitOlacakSicilNo _
                                '& " AND PERFORMANS_OZET.YIL=" & YilX _
                                '& " AND PERFORMANS_OZET.DONEM=" & DonemX
                                'Dim DbConn5 As New ConnectOracleDilerIK
                                'DbConn5.Sil(SQL)
                                'DbConn5.Kapat()


                                'Dim secilen, secilen1
                                'Dim s As Integer
                                'For s = 0 To RadioButtonList1.Items.Count - 1
                                '    If RadioButtonList1.Items(s).Selected Then
                                '        secilen = RadioButtonList1.Items(s).Text
                                '        secilen1 = RadioButtonList1.Items(s).Value
                                '    End If
                                'Next
                                'YuzdeXX.Text = YuzdeXX.Text.Replace(",", ".")
                                'OranXX.Text = OranXX.Text.Replace(",", ".")
                                'EgitimTalebiX.Text = EgitimTalebiX.Text.Replace(",", "-")
                                'SQL = ""
                                'SQL = "INSERT INTO PERFORMANS_OZET (YIL,DONEM,ID,PUAN,ORAN,YUZDE,ILERLEME,EGITIMISTEK) VALUES " _
                                ' & "(" & YilX & "," _
                                ' & DonemX & "," _
                                ' & KayitOlacakSicilNo & "," _
                                ' & "'" & PuanXX.Text & "'," _
                                ' & OranXX.Text & "," _
                                ' & YuzdeXX.Text & "," _
                                ' & secilen1 & "," _
                                ' & "'" & EgitimTalebiX.Text & "')"
                                'Dim DbConn4 As New ConnectOracleDilerIK
                                'DbConn4.SaveUpdate(SQL)
                                'DbConn4.Kapat()

                                'SQL = "" '''for dışına taşıdım
                                'SQL = "DELETE PERFORMANS_OZET " _
                                '& " WHERE PERFORMANS_OZET.ID=" & KayitOlacakSicilNo _
                                '& " AND PERFORMANS_OZET.YIL=" & YilX _
                                '& " AND PERFORMANS_OZET.DONEM=" & DonemX
                                'ManuelConn.ManuelSil(SQL)

                                'Dim secilen, secilen1
                                'Dim s As Integer
                                'For s = 0 To RadioButtonList1.Items.Count - 1
                                '    If RadioButtonList1.Items(s).Selected Then
                                '        secilen = RadioButtonList1.Items(s).Text
                                '        secilen1 = RadioButtonList1.Items(s).Value
                                '    End If
                                'Next

                                'YuzdeXX.Text = YuzdeXX.Text.Replace(",", ".")
                                'OranXX.Text = OranXX.Text.Replace(",", ".")
                                'EgitimTalebiX.Text = EgitimTalebiX.Text.Replace(",", "-")
                                'SQL = ""
                                'SQL = "INSERT INTO PERFORMANS_OZET (YIL,DONEM,ID,PUAN,ORAN,YUZDE,ILERLEME,EGITIMISTEK) VALUES " _
                                ' & "(" & YilX & "," _
                                ' & DonemX & "," _
                                ' & KayitOlacakSicilNo & "," _
                                ' & "'" & PuanXX.Text & "'," _
                                ' & OranXX.Text & "," _
                                ' & YuzdeXX.Text & "," _
                                ' & secilen1 & "," _
                                ' & "'" & EgitimTalebiX.Text & "')"
                                'ManuelConn.ManuelOpenSaveUpdate(SQL)

                                'End If
                            End If
                        Next
                    Next
                Next

                SQL = ""
                SQL = "DELETE PERFORMANS_OZET " _
                & " WHERE PERFORMANS_OZET.ID=" & KayitOlacakSicilNo _
                & " AND PERFORMANS_OZET.YIL=" & YilX _
                & " AND PERFORMANS_OZET.DONEM=" & DonemX
                ManuelConn.Sil(SQL)

                Dim secilen = "MevCut Pozisyonda Kalması Uygundur."
                Dim secilen1 = 3
                Dim s As Integer
                For s = 0 To RadioButtonList1.Items.Count - 1
                    If RadioButtonList1.Items(s).Selected Then
                        secilen = RadioButtonList1.Items(s).Text
                        secilen1 = RadioButtonList1.Items(s).Value
                    End If
                Next

                YuzdeXX.Text = YuzdeXX.Text.Replace(",", ".")
                OranXX.Text = OranXX.Text.Replace(",", ".")
                EgitimTalebiX.Text = EgitimTalebiX.Text.Replace(",", "-")

                SQL = ""
                SQL = "INSERT INTO PERFORMANS_OZET (YIL,DONEM,ID,PUAN,ORAN,YUZDE,ILERLEME,EGITIMISTEK) VALUES " _
                 & "(" & YilX & "," _
                 & DonemX & "," _
                 & KayitOlacakSicilNo & "," _
                 & "'" & PuanXX.Text & "'," _
                 & OranXX.Text & "," _
                 & YuzdeXX.Text & "," _
                 & secilen1 & "," _
                 & "'" & EgitimTalebiX.Text & "')"
                ManuelConn.SaveUpdate(SQL)

            End If


            'ManuelConn.KontrolKapat()
            ManuelConn.Kapat()
            AspNetMsgFunc("Kayıt Saklandı/Güncellendi...")
SON:
        End Sub
        Protected Sub Sakla_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Sakla.Click

            If DegerlendirmeyeUygunMu() Then
                IKDegerlendirilenID = Label_Id.Text
                BosVarmKontrolu()
                YoneticimiKontrolu()
                Hesaplatmalar()
                If YoneticiDrm = "E" Then
                    If mesaj <> "" Then
                        AspNetMsgFunc(mesaj)
                    Else
                        Hesaplatmalar()
                        KAYIT_SAKLA()
                    End If
                Else
                    If mesaj <> "Yöneticilik Sorularnda Eksik Girdiniz" Then
                        AspNetMsgFunc(mesaj)
                    Else
                        Hesaplatmalar()
                        KAYIT_SAKLA()
                    End If
                End If
                AKTIF_DONEM_NOTU_GETIR()
                SECILEN_PUANI_GETIR_OZETTEN()
                SECILEN_PUANLAMASI_GRID_GETIR()
            Else
                AspNetMsgFunc("Personel 6 Aylık Çalışma Dönemini Tamamlamamış")
                'MsgBox("Personel 6 Aylık Çalışma Dönemini Tamamlamamış")
            End If

        End Sub
        Private Sub ONAYLADIM_MI()
            Try
                SQL = ""
                SQL = "SELECT * FROM PERFORMANS_DONEM"
                Dim DbConn2 As New ConnectOracleDilerIK
                DbConn2.RaporWhile(SQL)
                While DbConn2.MyDataReader.Read
                    YilX = DbConn2.MyDataReader.GetValue(0).ToString()
                    DonemX = DbConn2.MyDataReader.GetValue(1).ToString()
                End While
                DbConn2.Kapat()
                IKDegerlendirilenID = ""
                Dim k
                For k = 0 To FpSpread2.Sheets(0).RowCount - 1
                    IKDegerlendirilenID = FpSpread2.Sheets(0).Cells(k, 1).Text
                    SQL = ""
                    SQL = "SELECT COUNT(PUANVEREN) FROM PERFORMANS_DATA " _
                    & " WHERE ID=" & IKDegerlendirilenID _
                    & " AND YIL=" & YilX _
                    & " AND DONEM=" & DonemX _
                    & " AND PUANVEREN=" & KayitYapan

                    Dim DbConn3 As New ConnectOracleDilerIK
                    DbConn3.Sayac(SQL)
                    Dim SAYAC = DbConn3.GeriDonenRakam
                    DbConn3.Kapat()
                    If SAYAC > 0 Then
                        FpSpread2.Sheets(0).Cells(k, 1).BackColor = Color.LightCyan
                        FpSpread2.Sheets(0).Cells(k, 2).BackColor = Color.LightCyan
                        FpSpread2.Sheets(0).Cells(k, 3).BackColor = Color.LightCyan
                        FpSpread2.Sheets(0).Cells(k, 4).BackColor = Color.LightCyan
                        FpSpread2.Sheets(0).Cells(k, 5).BackColor = Color.LightCyan
                        'FpSpread2.Sheets(0).Cells(k, 6).BackColor = Color.YellowGreen
                    End If
                    'Dim DbConn As New ConnectOracleDilerIK
                    ''DbConn.Sayac(SQL)

                    'DbConn.RaporWhile(SQL)
                    'While DbConn.MyDataReader.Read
                    '    FpSpread2.Sheets(0).Cells(k, 7).Text = KayitYapan

                    'End While
                    'DbConn.Kapat()
                Next
            Catch ex As Exception

            End Try

        End Sub


        Protected Sub FpSpread1_ActiveSheetChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpread1.ActiveSheetChanged
            Hesaplatmalar()
        End Sub

        'Protected Sub FpSpread1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FpSpread1.PreRender
        '    'Hesaplatmalar()
        'End Sub

        Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
            Hesaplatmalar()
        End Sub
        Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
            Dim k
            If CheckBox1.Checked = True Then
                For k = 0 To FpSpread2.Sheets(0).RowCount - 1
                    Dim deger = FpSpread2.Sheets(0).Cells(k, 6).Value
                    If Val(deger) > 1 Then
                        FpSpread2.Sheets(0).Rows(k).Visible = False

                    End If
                Next
            Else
                GIRENIN_ALTLARINI_GETIR()

            End If
        End Sub

        Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
            'Response.Redirect("../../Forms/IK/PerformansRapor.aspx")
            Response.Redirect("../../Forms/IK/RaporUserPerformans.aspx")

        End Sub


        Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click

            DegerlendirmeYapilamayanBulucu()


            'datasetOlustur()
            'FpSpread4.Sheets(0).RowCount = 0
            'Dim SATIRSAY = 0

            'SQL = ""
            'SQL = "SELECT * FROM PERFORMANS_DONEM"
            'Dim DbConn2 As New ConnectOracleDilerIK
            'DbConn2.RaporWhile(SQL)
            'While DbConn2.MyDataReader.Read
            '    YilX = DbConn2.MyDataReader.GetValue(0).ToString()
            '    DonemX = DbConn2.MyDataReader.GetValue(1).ToString()
            'End While
            'DbConn2.Kapat()

            'FpSpread2.Visible = False
            'Image1.Visible = False
            'Gr_Egitim.Visible = False
            'FpSpread1.Visible = False
            'FpSpread3.Visible = False
            'EgitimTalebiX.Visible = False
            'Label5.Visible = False
            'Label3.Visible = False
            'PuanlamaBaslik.Visible = False
            'PuanXX.Visible = False
            'OranXX.Visible = False
            'YuzdeXX.Visible = False
            'RadioButtonList1.Visible = False
            'FpSpread4.Visible = True
            'ImageButton4.Visible = True
            'Label6.Visible = True
            'FpSpread4.Height = 600
            'FpSpread4.Width = 1176

            'SQL = ""
            'Dim i As Integer
            'Dim SecilenAltGrup, BOSID, BOSFIRMA, BOSALTGRUP, BOSISIM, BOSBOLUM
            'For i = 0 To DropDownList1.Items.Count - 1
            '    SecilenAltGrup = DropDownList1.Items(i).Text
            '    SQL = "SELECT NUFUS.ID,UNITESI.CAL_FRMA,UNITESI.ALT_GRUP,ADI|| ' ' ||SOYADI AS ISIM,UNITESI.BOLUM " _
            '    & " FROM NUFUS INNER JOIN UNITESI ON NUFUS.ID=UNITESI.ID" _
            '    & " WHERE ALT_GRUP='" & SecilenAltGrup & "'" _
            '    & " AND NUFUS.DRM=" & 1 _
            '    & " AND UNITESI.DURUMU='AKTIF'"
            '    Dim DbConn As New ConnectOracleDilerIK
            '    DbConn.RaporWhile(SQL)
            '    Try
            '        While DbConn.MyDataReader.Read
            '            If DegerlendirmeyeUygunMu2(DbConn.MyDataReader.GetValue(0).ToString()) Then
            '                BOSID = DbConn.MyDataReader.GetValue(0).ToString()
            '                BOSFIRMA = DbConn.MyDataReader.GetValue(1).ToString()
            '                BOSALTGRUP = DbConn.MyDataReader.GetValue(2).ToString()
            '                BOSISIM = DbConn.MyDataReader.GetValue(3).ToString()
            '                BOSBOLUM = DbConn.MyDataReader.GetValue(4).ToString()
            '                Dim SQL2 = "SELECT * FROM  PERFORMANS_OZET WHERE YIL=" & YilX _
            '                & " AND DONEM=" & DonemX & " And ID=" & BOSID
            '                Try
            '                    Dim SAYAC = 0
            '                    Dim DbConn3 As New ConnectOracleDilerIK
            '                    DbConn3.Sayac(SQL2)
            '                    SAYAC = DbConn3.GeriDonenRakam
            '                    'DbConn3.Kapat()
            '                    DbConn3.Dispose()
            '                    If SAYAC < 1 Then
            '                        FpSpread4.Sheets(0).RowCount = FpSpread4.Sheets(0).RowCount + 1
            '                        FpSpread4.Sheets(0).Cells(SATIRSAY, 0).Text = BOSID
            '                        FpSpread4.Sheets(0).Cells(SATIRSAY, 1).Text = BOSISIM
            '                        FpSpread4.Sheets(0).Cells(SATIRSAY, 2).Text = BOSFIRMA
            '                        FpSpread4.Sheets(0).Cells(SATIRSAY, 3).Text = BOSBOLUM
            '                        FpSpread4.Sheets(0).Cells(SATIRSAY, 4).Text = BOSALTGRUP
            '                        SATIRSAY = SATIRSAY + 1
            '                    End If
            '                Catch ex As Exception
            '                    AspNetMsgFunc("İç hata :FpSpread4 yazdırırken hata oluştu")
            '                End Try
            '            End If

            '        End While
            '    Catch ex As Exception
            '        AspNetMsgFunc("Dış hata")
            '    End Try
            '    'DbConn.Kapat()
            '    DbConn.Dispose()
            'Next

        End Sub
        Private Sub DegerlendirmeYapilamayanBulucu()
            datasetOlustur()
            FpSpread4.Sheets(0).RowCount = 0
            Dim SATIRSAY = 0

            YilX = PerforYil
            DonemX = PerforDonem

            FpSpread2.Visible = False
            Image1.Visible = False
            Gr_Egitim.Visible = False
            FpSpread1.Visible = False
            FpSpread3.Visible = False
            EgitimTalebiX.Visible = False
            Label5.Visible = False
            Label3.Visible = False
            PuanlamaBaslik.Visible = False
            PuanXX.Visible = False
            OranXX.Visible = False
            YuzdeXX.Visible = False
            RadioButtonList1.Visible = False
            FpSpread4.Visible = True
            ImageButton4.Visible = True
            Label6.Visible = True
            FpSpread4.Height = 600
            FpSpread4.Width = 1176

            SQL = ""
            Dim i As Integer
            Dim SecilenAltGrup, BOSID, BOSFIRMA, BOSALTGRUP, BOSISIM, BOSBOLUM
            For i = 0 To DropDownList1.Items.Count - 1
                SecilenAltGrup = DropDownList1.Items(i).Text
                SQL = "SELECT NUFUS.ID,UNITESI.CAL_FRMA,UNITESI.ALT_GRUP,ADI|| ' ' ||SOYADI AS ISIM,UNITESI.BOLUM,FG.IS_BAS_TAR " _
                & " FROM NUFUS INNER JOIN UNITESI ON NUFUS.ID=UNITESI.ID" _
                & " INNER JOIN FABRIKAGENEL FG ON NUFUS.ID=FG.ID" _
                & " WHERE ALT_GRUP='" & SecilenAltGrup & "'" _
                & " AND NUFUS.DRM=" & 1 _
                & " AND UNITESI.DURUMU='AKTIF'"
                Dim DbConn As New ConnectOracleDilerIK
                DbConn.RaporWhile(SQL)
                Try
                    While DbConn.MyDataReader.Read
                        If DegerlendirmeyeUygunMu3(DbConn.MyDataReader.Item("IS_BAS_TAR").ToString()) Then
                            BOSID = DbConn.MyDataReader.GetValue(0).ToString()
                            BOSFIRMA = DbConn.MyDataReader.GetValue(1).ToString()
                            BOSALTGRUP = DbConn.MyDataReader.GetValue(2).ToString()
                            BOSISIM = DbConn.MyDataReader.GetValue(3).ToString()
                            BOSBOLUM = DbConn.MyDataReader.GetValue(4).ToString()
                            Dim SQL2 = "SELECT * FROM  PERFORMANS_OZET WHERE YIL=" & YilX _
                            & " AND DONEM=" & DonemX & " And ID=" & BOSID
                            Try
                                Dim SAYAC = 0
                                Dim DbConn3 As New ConnectOracleDilerIK
                                DbConn3.Sayac(SQL2)
                                SAYAC = DbConn3.GeriDonenRakam
                                DbConn3.Kapat()
                                'DbConn3.Dispose()
                                If SAYAC < 1 Then
                                    FpSpread4.Sheets(0).RowCount = FpSpread4.Sheets(0).RowCount + 1
                                    FpSpread4.Sheets(0).Cells(SATIRSAY, 0).Text = BOSID
                                    FpSpread4.Sheets(0).Cells(SATIRSAY, 1).Text = BOSISIM
                                    FpSpread4.Sheets(0).Cells(SATIRSAY, 2).Text = BOSFIRMA
                                    FpSpread4.Sheets(0).Cells(SATIRSAY, 3).Text = BOSBOLUM
                                    FpSpread4.Sheets(0).Cells(SATIRSAY, 4).Text = BOSALTGRUP
                                    SATIRSAY = SATIRSAY + 1
                                End If
                            Catch ex As Exception
                                AspNetMsgFunc("İç hata :FpSpread4 yazdırırken hata oluştu")
                            End Try
                        End If

                    End While
                Catch ex As Exception
                    AspNetMsgFunc("Dış hata")
                End Try
                DbConn.Kapat()
                ' DbConn.Dispose()
            Next
        End Sub

        Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton4.Click
            FpSpread2.Visible = True
            Image1.Visible = True
            Gr_Egitim.Visible = True
            FpSpread1.Visible = True
            FpSpread3.Visible = True
            EgitimTalebiX.Visible = True
            Label5.Visible = True
            Label3.Visible = True
            PuanlamaBaslik.Visible = True
            PuanXX.Visible = True
            OranXX.Visible = True
            YuzdeXX.Visible = True
            RadioButtonList1.Visible = True
            FpSpread4.Visible = False
            ImageButton4.Visible = False
            Label6.Visible = False
            FpSpread4.Height = 0
            FpSpread4.Width = 0
        End Sub

        Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click
            Response.Redirect("../../default2.aspx")
        End Sub
        Public Function DegerlendirmeyeUygunMu() As Boolean
            Dim DbConn2 As New ConnectOracleDilerIK
            Try
                'Personel değerlendirlecek dönemden önce işe başlaması gerekir. Yani min 6 ay görev yapması gerekir.
                Dim Yilx, SQL, Ay, Gun As String
                Dim Donemx, IsBasTar, SinirTarih As Integer
                SQL = "SELECT * FROM PERFORMANS_DONEM"

                DbConn2.RaporWhile(SQL)
                While DbConn2.MyDataReader.Read
                    Yilx = DbConn2.MyDataReader.GetValue(0).ToString()
                    Donemx = DbConn2.MyDataReader.GetValue(1).ToString()
                End While
                DbConn2.Kapat()
                SQL = "SELECT IS_BAS_TAR FROM NUFUS N,FABRIKAGENEL FG" _
                    & " WHERE(FG.ID = N.ID) " _
                    & " And N.DRM = 1 " _
                    & " AND N.ID=" & Label_Id.Text
                DbConn2.RaporWhile(SQL)
                While DbConn2.MyDataReader.Read
                    IsBasTar = DbConn2.MyDataReader.Item("IS_BAS_TAR").ToString()
                End While
                DbConn2.Kapat()

                If Donemx = 1 Then
                    Ay = "01"
                    Gun = "01"
                    SinirTarih = Yilx & Ay & Gun
                ElseIf Donemx = 2 Then
                    Ay = "07"
                    Gun = "01"
                    SinirTarih = Yilx & Ay & Gun
                End If

                If IsBasTar < SinirTarih Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                AspNetMsgFunc("Degerlendirmeye Uygunmu kontrol hatası. Hata: " & ex.ToString)
                DbConn2.Kapat()
                'DbConn2.KontrolKapat()
            End Try

        End Function
        Public dsPer As DataSet = New DataSet ' dataset isbastar ve performans donem için
        Public tblIsbastar As DataTable
        Public tblPerfDonem As DataTable
        Public daPer As New OracleDataAdapter
        Dim PerforYil, PerforDonem
        Private Sub datasetOlustur()

            Dim DbConn1 As New ConnectOracleDilerIK

            SQL = "SELECT YIL,DONEM FROM IK.PERFORMANS_DONEM"
            DbConn1.RaporWhile(SQL)
            While DbConn1.MyDataReader.Read
                PerforYil = DbConn1.MyDataReader.GetValue(0).ToString()
                PerforDonem = DbConn1.MyDataReader.GetValue(1).ToString()
            End While
            DbConn1.Kapat()





        End Sub
        Public Function DegerlendirmeyeUygunMu2(ByVal sicilNo) As Boolean
            'Dim DbConn2 As New ConnectOracleDilerIK
            Dim DbConn3 As New ConnectOracleDilerIK
            Try
                'Degerlendirilmesi yapılmamış personelde sicil numarasına göre zaten değerlendirilmesi yapılması gerekip gerekmediğini kontrol ediyor.
                Dim Yilx, Donemx, SQL, Ay, Gun As String
                Dim IsBasTar, SinirTarih As Integer
                'SQL = ""
                'SQL = "SELECT * FROM IK.PERFORMANS_DONEM"
                'DbConn2.RaporWhile(SQL)
                'While DbConn2.MyDataReader.Read
                '    Yilx = DbConn2.MyDataReader.GetValue(0).ToString()
                '    Donemx = DbConn2.MyDataReader.GetValue(1).ToString()
                'End While
                'DbConn2.Dispose()
                Yilx = PerforYil
                Donemx = PerforDonem
                SQL = ""
                SQL = "SELECT IS_BAS_TAR FROM IK.NUFUS N,IK.FABRIKAGENEL FG" _
                    & " WHERE(FG.ID = N.ID) " _
                    & " And N.DRM = 1 " _
                    & " AND N.ID=" & sicilNo
                DbConn3.RaporWhile(SQL)
                While DbConn3.MyDataReader.Read
                    IsBasTar = DbConn3.MyDataReader.Item("IS_BAS_TAR").ToString()
                End While
                DbConn3.Kapat()
                'DbConn3.Dispose()

                If Donemx = 1 Then
                    Ay = "01"
                    Gun = "01"
                    SinirTarih = Yilx & Ay & Gun
                ElseIf Donemx = 2 Then
                    Ay = "07"
                    Gun = "01"
                    SinirTarih = Yilx & Ay & Gun
                End If

                If IsBasTar < SinirTarih Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                'MsgBox("Degerlendirilmemiş personel degerlendirmeye uygunmu kontrol hatası. Hata: " & ex.ToString)
                'DbConn2.KontrolKapat()
                DbConn3.Kapat()
                'DbConn3.KontrolKapat()
            End Try
        End Function
        Public Function DegerlendirmeyeUygunMu3(ByVal gelenIsBasTar) As Boolean
            'Değerlendirilmesi yapılmamış personelin İş başı tarihine göre bulan modül.
            Try
                Dim Yilx, Donemx, Ay, Gun As String
                Dim IsBasTar, SinirTarih As Integer
                IsBasTar = gelenIsBasTar

                Yilx = PerforYil
                Donemx = PerforDonem

                If Donemx = 1 Then
                    Ay = "01"
                    Gun = "01"
                    SinirTarih = Yilx & Ay & Gun
                ElseIf Donemx = 2 Then
                    Ay = "07"
                    Gun = "01"
                    SinirTarih = Yilx & Ay & Gun
                End If


                If IsBasTar < SinirTarih Then
                    DegerlendirmeyeUygunMu3 = True
                Else
                    DegerlendirmeyeUygunMu3 = False
                End If

                Return True
            Catch ex As Exception
                MsgBox("Degerlendirilmemiş personel degerlendirmeye uygunmu kontrol hatası. Hata: " & ex.ToString)
            End Try

        End Function

        Protected Sub FpSpread2_Grouping(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.GroupingEventArgs) Handles FpSpread2.Grouping

        End Sub
    End Class

    Public Class MyGroupComparer
        Implements IComparer

        Private birthDate As Boolean = True
        Public Sub New(ByVal bd As Boolean)
            birthDate = bd
        End Sub

        Public Function Compare(ByVal x1 As Object, ByVal y1 As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim x, y As Integer
            x = 0
            y = 0

            If birthDate Then
                If TypeOf (x1) Is DateTime Then
                    x = CType(x1, DateTime).Year Mod 10
                    x = CType(x1, DateTime).Year - x
                End If
                If TypeOf (y1) Is DateTime Then
                    y = CType(y1, DateTime).Year Mod 10
                    y = CType(y1, DateTime).Year - y
                End If
            Else
                If TypeOf (x1) Is DateTime Then
                    x = CType(x1, DateTime).Year
                End If
                If TypeOf (y1) Is DateTime Then
                    y = CType(y1, DateTime).Year
                End If
            End If

            If x = y Then
                Return 0
            ElseIf x > y Then
                Return 1
            Else
                Return -1
            End If
        End Function
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
                & "User Id=IK;Password=IK;"
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
End Namespace