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
        Public YoneticiDrm, mesaj, SIFRESI
        Dim ToplamSfr, ToplamBir, ToplamIk, ToplamUc, ToplamDort, ToplamBes
        Dim SicilNo


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then

                IKADSADX = ("IKADSAD")
                GIRIS()
                GIRENKIM()
                GIRENIN_ALTLARINI_GETIR()


                For i As Integer = 0 To FpSpread1.Sheets(0).RowCount - 1
                    If FpSpread1.Sheets(0).Cells(i, 0).Text = "" Then GoTo Bitti
                    SicilNo = FpSpread1.Sheets(0).Cells(i, 0).Text
                    YillikizinleriGetir(i, SicilNo)
                Next

Bitti:

            End If

        End Sub


        Private Sub YillikizinleriGetir(ByVal i, ByVal SicilNo)
            ' FpSpread1.Sheets(0).ColumnCount = 14
            Dim DbConn1 As New ConnectOracleDilerIK
            Dim SQL As String = ""
            SQL = "select * from IK.YILLIKIZIN_V WHERE ID=" & SicilNo & ""
            DbConn1.RaporWhile(SQL)
            While DbConn1.MyDataReader.Read
                FpSpread1.Sheets(0).Cells(i, 5).Text = DbConn1.MyDataReader.GetValue(2).ToString() '2011
                FpSpread1.Sheets(0).Cells(i, 6).Text = DbConn1.MyDataReader.GetValue(3).ToString() '2012
                FpSpread1.Sheets(0).Cells(i, 7).Text = DbConn1.MyDataReader.GetValue(4).ToString() '2013
                FpSpread1.Sheets(0).Cells(i, 8).Text = DbConn1.MyDataReader.GetValue(5).ToString() '2014
                FpSpread1.Sheets(0).Cells(i, 9).Text = DbConn1.MyDataReader.GetValue(6).ToString() '2015
                FpSpread1.Sheets(0).Cells(i, 10).Text = DbConn1.MyDataReader.GetValue(7).ToString() '2016
                FpSpread1.Sheets(0).Cells(i, 11).Text = DbConn1.MyDataReader.GetValue(8).ToString() '2017
                FpSpread1.Sheets(0).Cells(i, 12).Text = DbConn1.MyDataReader.GetValue(9).ToString() '2018
                FpSpread1.Sheets(0).Cells(i, 13).Text = DbConn1.MyDataReader.GetValue(15).ToString() 'tOPLAM
                FpSpread1.Sheets(0).Cells(i, 14).Text = DbConn1.MyDataReader.GetValue(16).ToString() 'ISEGIRTAR

            End While
            DbConn1.Kapat()


        End Sub

        Private Sub GIRIS()

            Dim DbConn As New ConnectOracleDilerIK
            KULLANICI = Session("KULLANICI")
            SIFRESI = Session("SIFRESI")
            SQL = ""
            SQL = "SELECT URTTNM.USRTNM.PERFORMANS,URTTNM.USRTNM.IKID,URTTNM.USRTNM.ADSOYAD FROM URTTNM.USRTNM WHERE URTTNM.USRTNM.USERNAME='" & UCase(KULLANICI) & "' AND URTTNM.USRTNM.SIFRE='" & UCase(SIFRESI) & "'"
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                IZIN = DbConn.MyDataReader.GetString(0)
                IKID = DbConn.MyDataReader.GetString(1)
                IKADSADX = DbConn.MyDataReader.GetString(2)
            End While
            DbConn.Kapat()

            Session("IKID") = IKID
            Session("IKADSAD") = IKADSADX

        End Sub

        Private Sub GIRENKIM()

            IKID = Session("IKID")
            'IKID = 1001690
            '' GİREN ŞEF İSE
            SQL = ""
            SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
            & " WHERE IK.UNITESI.ID='" & IKID & "'" _
            & " AND IK.NUFUS.DRM=1" _
            & " AND IK.UNITESI.DURUMU='AKTIF'" _
            & " AND IK.UNITESI.ALT_GRUP LIKE '%ŞEFİ%'"

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
            & " AND IK.UNITESI.ALT_GRUP LIKE '%MÜHENDİS%'"
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

            'If GIRENUNVAN = "FABRİKA MÜDÜRÜ" And IKADSADX = "İnsan Kaynakları" Then
            '    GirenBilgisi.Text = "Programa Giriş Yapan  İnsan Kaynakları Kullanıcısı..."
            'Else
            '    GirenBilgisi.Text = "Programa Giriş Yapan  " & IDX & "  Sicil Numaralı  " & GIRENBOLUM & "  " & GIRENADI & "  " & GIRENSAD & "  " & GIRENALTGRUP
            'End If

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

            FpSpread1.Sheets(0).RowCount = 0
            FpSpread1.Sheets(0).RowCount = FpSpread1.Sheets(0).RowCount + 1
            FpSpread1.Sheets(0).Cells(0, 0).Text = Session("IKID")
            FpSpread1.Sheets(0).Cells(0, 1).Text = GIRENADI & GIRENSAD
            FpSpread1.Sheets(0).Cells(0, 2).Text = GIRENUNITE
            FpSpread1.Sheets(0).Cells(0, 3).Text = GIRENBOLUM
            FpSpread1.Sheets(0).Cells(0, 4).Text = GIRENALTGRUP

        End Sub

        Private Sub GIRENIN_ALTLARINI_GETIR()
            Dim i = 1


            GIRENUNITE = Session("GIRENUNITE")
            GIRENBOLUM = Session("GIRENBOLUM")
            GIRENUNVAN = Session("GIRENUNVAN")


            If GIRENUNVAN = "MÜDÜR" Then
                SQL = ""
                SQL = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP FROM IK.NUFUS INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " _
                & " WHERE IK.UNITESI.UNITE='" & GIRENUNITE & "'" _
                & " AND IK.UNITESI.ID<>" & IKID _
                & " AND IK.UNITESI.DURUMU='AKTIF'" _
                & " AND IK.UNITESI.BOLUM<>'TAŞERON FIRMA'" _
                & " AND IK.NUFUS.DRM=" & 1 _
                & " AND (IK.UNITESI.ALT_GRUP NOT LIKE '%MÜDÜRÜ%')"
                'If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                '    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                'End If
                Dim DbConn As New ConnectOracleDilerIK
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    'If DegerlendirmeyeUygunMu2(DbConn.MyDataReader.GetValue(0).ToString()) Then 'Değerlendirmeye uygun değilse listede gözükmeyecek
                    FpSpread1.Sheets(0).RowCount = FpSpread1.Sheets(0).RowCount + 1
                    FpSpread1.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.GetValue(0).ToString()
                    FpSpread1.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.GetValue(1).ToString() & " " & DbConn.MyDataReader.GetValue(2).ToString()
                    FpSpread1.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.GetValue(3).ToString()
                    FpSpread1.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.GetValue(4).ToString()
                    FpSpread1.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.GetValue(5).ToString()
                    i = i + 1
                    ' End If
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
                'If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                '    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                'End If




                Dim DbConn1 As New ConnectOracleDilerIK
                DbConn1.RaporWhile(SQL)
                While DbConn1.MyDataReader.Read
                    'If DegerlendirmeyeUygunMu2(DbConn1.MyDataReader.GetValue(0).ToString()) Then 'Değerlendirmeye uygun değilse listede gözükmeyecek
                    FpSpread1.Sheets(0).RowCount = FpSpread1.Sheets(0).RowCount + 1
                    FpSpread1.Sheets(0).Cells(i, 0).Text = DbConn1.MyDataReader.GetValue(0).ToString()
                    FpSpread1.Sheets(0).Cells(i, 1).Text = DbConn1.MyDataReader.GetValue(1).ToString() & " " & DbConn1.MyDataReader.GetValue(2).ToString()
                    FpSpread1.Sheets(0).Cells(i, 2).Text = DbConn1.MyDataReader.GetValue(3).ToString()
                    FpSpread1.Sheets(0).Cells(i, 3).Text = DbConn1.MyDataReader.GetValue(4).ToString()
                    FpSpread1.Sheets(0).Cells(i, 4).Text = DbConn1.MyDataReader.GetValue(5).ToString()
                    i = i + 1
                    ' End If
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
                'If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                '    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                'End If


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
                    'If DropDownList1.Text <> "(All)" And DropDownList1.Text <> "" Then
                    '    SQL = SQL & " AND IK.UNITESI.ALT_GRUP ='" & DropDownList1.Text & "'"
                    'End If
                End If


                Dim DbConn2 As New ConnectOracleDilerIK
                DbConn2.RaporWhile(SQL)
                While DbConn2.MyDataReader.Read
                    'If DegerlendirmeyeUygunMu2(DbConn2.MyDataReader.GetValue(0).ToString()) Then 'Değerlendirmeye uygun değilse listede gözükmeyecek
                    FpSpread1.Sheets(0).RowCount = FpSpread1.Sheets(0).RowCount + 1
                    FpSpread1.Sheets(0).Cells(i, 0).Text = DbConn2.MyDataReader.GetValue(0).ToString()
                    FpSpread1.Sheets(0).Cells(i, 1).Text = DbConn2.MyDataReader.GetValue(1).ToString() & " " & DbConn2.MyDataReader.GetValue(2).ToString()
                    FpSpread1.Sheets(0).Cells(i, 2).Text = DbConn2.MyDataReader.GetValue(3).ToString()
                    FpSpread1.Sheets(0).Cells(i, 3).Text = DbConn2.MyDataReader.GetValue(4).ToString()
                    FpSpread1.Sheets(0).Cells(i, 4).Text = DbConn2.MyDataReader.GetValue(5).ToString()
                    i = i + 1
                    'End If
                End While
                DbConn2.Kapat()
            End If




        End Sub

        Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
            Response.Redirect("../../default2.aspx")
        End Sub

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
End Namespace