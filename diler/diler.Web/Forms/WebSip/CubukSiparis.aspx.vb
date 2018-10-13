Imports System.Web
Imports System.Drawing
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Mail
Imports System.Net.WebRequestMethods
Imports System.IO
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Script.Serialization
Imports System.Diagnostics.Process
Imports System.Web.UI
Imports System.Diagnostics
Imports System.Web.UI.WebControls
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types
Imports System.Data

Public Class CubukSiparis
    Inherits System.Web.UI.Page
    Dim OncekiCap, MUSTERIADI_RAPOR
    Dim gg, bb, varmı
    Dim Ipadresi
    Dim UrunAgacListesi As New ArrayList()
    Dim KODUNACIKLAMASI
    Dim KALITESINIFACK, KALITESINIFACK_EKLENECEK
    Dim SIPARISIN_GRUBU
    Dim Siparisin_sahibi_Kim_Mail, Siparisi_Giren_Kim_Mail, MailAdresi
    Dim siparisDurumu, SiparisNoDurumu As Integer
    Dim SQL, KULLANICI, IZIN, IKID, Aciklamax, DonenTarih, DonenTersTarih, DonenTersTarihx, DonenTersTarih1, IKADSADX, UserName, Sifre
    Dim KaliteAck
    Dim SiparisinDurumu As Integer


    Public Kullanıcı, PrgKod, PrgYer, KullanıcıSipYetki, AktifSiparisinDurumu, Program_YetkNumarasi, Program_Grubu, Filtre_Drm, Btn_EKRAN_GIRIS, Btn_EKRAN_ONAY
    Public MailMesaj As String
    Dim mailack, MailGittimi
    Dim BAslıkMesajı, SubjectMesajı, mailsmtp
    Dim Btn_SIP_GIRIS_MAIL, Btn_SIP_SIL_MAIL, Btn_SIP_GIR_ONAY_MAIL, Btn_SIP_KONTROL_MAIL, Btn_SIP_ONAY_MAIL, Btn_SIP_IPTAL_MAIL, Btn_SIP_IADE_MAIL, Btn_SIP_URT_CEVIR_MAIL, Btn_SIP_REVIZYON_MAIL
    Dim SiparisNoZatenVar As Boolean = False
    Dim EskiRevNo
    Dim item_id As String
    'Private WithEvents doc As HTMLDocument
    Private Sub btnyetki_New(ByVal UserName, ByVal Sifre)

        Dim DbConn As New ConnectGiris
        SQL = " SELECT * FROM urttnm.USRSIPARIS" _
        & " WHERE USRNAME='" & UserName & "'" _
        & " AND PASSWORD='" & Sifre & "'"
        DbConn.RaporWhile(SQL)
        'burda butınları acmak için akıllcaklar var
        Dim Btn_SIP_GIRIS, Btn_SIP_SIL, Btn_SIP_GIR_ONAY, Btn_SIP_KONTROL, Btn_SIP_ONAY, Btn_SIP_IPTAL, Btn_SIP_IADE
        Dim Btn_SIP_URT_CEVIR, Btn_SIP_REVIZYON

        While DbConn.MyDataReader.Read

            Btn_SIP_GIRIS = DbConn.MyDataReader.Item("SIP_GIRIS")
            Btn_SIP_SIL = DbConn.MyDataReader.Item("SIP_SIL")
            Btn_SIP_GIR_ONAY = DbConn.MyDataReader.Item("SIP_GIR_ONAY")
            Btn_SIP_KONTROL = DbConn.MyDataReader.Item("SIP_KONTROL")
            Btn_SIP_ONAY = DbConn.MyDataReader.Item("SIP_ONAY")
            Btn_SIP_IPTAL = DbConn.MyDataReader.Item("SIP_IPTAL")
            Btn_SIP_IADE = DbConn.MyDataReader.Item("SIP_IADE")
            Btn_SIP_URT_CEVIR = DbConn.MyDataReader.Item("SIP_URT_CEVIR")
            Btn_SIP_REVIZYON = DbConn.MyDataReader.Item("SIP_REVIZYON")
            Btn_EKRAN_GIRIS = DbConn.MyDataReader.Item("EKRAN_GIRIS")
            Btn_EKRAN_ONAY = DbConn.MyDataReader.Item("EKRAN_ONAY")
            Filtre_Drm = DbConn.MyDataReader.Item("FILTRE")

            Program_YetkNumarasi = DbConn.MyDataReader.Item("PROGRAM_YETKI_NUMARASI")
            Session("Program_YetkNumarasi") = Program_YetkNumarasi
            Program_Grubu = DbConn.MyDataReader.Item(0)

            Btn_SIP_GIRIS_MAIL = DbConn.MyDataReader.Item(18)
            Btn_SIP_SIL_MAIL = DbConn.MyDataReader.Item(19)
            Btn_SIP_GIR_ONAY_MAIL = DbConn.MyDataReader.Item(20)
            Btn_SIP_KONTROL_MAIL = DbConn.MyDataReader.Item(21)
            Btn_SIP_ONAY_MAIL = DbConn.MyDataReader.Item(22)
            Btn_SIP_IPTAL_MAIL = DbConn.MyDataReader.Item(23)
            Btn_SIP_IADE_MAIL = DbConn.MyDataReader.Item(24)
            Btn_SIP_URT_CEVIR_MAIL = DbConn.MyDataReader.Item(25)
            Btn_SIP_REVIZYON_MAIL = DbConn.MyDataReader.Item(26)


        End While
        DbConn.Kapat()

        ' önce bütün butonları visible= false yap

        Buton_SIP_GIRIS.Visible = False
        Buton_SIP_SIL.Visible = False
        Buton_SIP_GIR_ONAY.Visible = False
        buton_SIP_KONTROL.Visible = False
        Buton_SIP_ONAY.Visible = False
        Buton_SIP_IPTAL.Visible = False
        Buton_SIP_IADE.Visible = False
        Buton_SIP_URT_CEVIR.Visible = False
        Buton_SIP_REVIZYON.Visible = False


        If Btn_SIP_GIRIS = 1 Then Buton_SIP_GIRIS.Visible = True
        If Btn_SIP_SIL = 1 Then Buton_SIP_SIL.Visible = True
        If Btn_SIP_GIR_ONAY = 1 Then Buton_SIP_GIR_ONAY.Visible = True
        If Btn_SIP_KONTROL = 1 Then buton_SIP_KONTROL.Visible = True
        If Btn_SIP_ONAY = 1 Then Buton_SIP_ONAY.Visible = True
        If Btn_SIP_IPTAL = 1 Then Buton_SIP_IPTAL.Visible = True
        If Btn_SIP_IADE = 1 Then Buton_SIP_IADE.Visible = True
        If Btn_SIP_URT_CEVIR = 1 Then Buton_SIP_URT_CEVIR.Visible = True
        If Btn_SIP_REVIZYON = 1 Then Buton_SIP_REVIZYON.Visible = True



        If Btn_EKRAN_GIRIS = 1 Then
            TabPanel1.Visible = True
            TabPanel2.Visible = True
            TabPanel3.Enabled = False
            TabPanel4.Visible = False
            TabPanel5.Visible = True
            TabPanel6.Visible = False
        End If

        If Btn_EKRAN_ONAY = 1 Then
            TabPanel1.Visible = True
            TabPanel2.Visible = False
            TabPanel3.Enabled = True
            TabPanel4.Visible = False
            TabPanel5.Visible = False
            TabPanel6.Visible = False

        End If
        If Btn_EKRAN_GIRIS = 1 And Btn_EKRAN_ONAY = 1 Then
            TabPanel1.Visible = True
            TabPanel2.Visible = True
            TabPanel3.Enabled = True
            TabPanel4.Visible = False
            TabPanel5.Visible = True
            TabPanel6.Visible = False
        End If


        If PrgKod = "ICPIYS" Then
            ' raporgrd.Sheets(0).RowCount = 17
            lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş İÇ PİYASA SİPARİŞ BİLDİRİM FORMU"
            raporgrd.Sheets(0).Rows(0).Visible = True
            raporgrd.Sheets(0).Rows(1).Visible = False
            raporgrd.Sheets(0).Rows(2).Visible = False
            raporgrd.Sheets(0).Rows(3).Visible = False
            raporgrd.Sheets(0).Rows(4).Visible = False
            raporgrd.Sheets(0).Rows(5).Visible = True
            raporgrd.Sheets(0).Rows(6).Visible = False
            raporgrd.Sheets(0).Rows(7).Visible = False
            raporgrd.Sheets(0).Rows(8).Visible = False
            raporgrd.Sheets(0).Rows(9).Visible = False
            raporgrd.Sheets(0).Rows(10).Visible = True
            raporgrd.Sheets(0).Rows(11).Visible = False
            raporgrd.Sheets(0).Rows(12).Visible = False
            raporgrd.Sheets(0).Rows(13).Visible = False
            raporgrd.Sheets(0).Rows(14).Visible = False

            ' raporgrd.Sheets(0).Rows(15).Visible = False

            'raporgrd.Sheets(0).Cells(16, 0).Text = "Form No: 05.10.1-4/R-1"

            myDiv.Visible = True


        Else
            'myDiv.Visible = False
            'dateRaporBas.Visible = False
            'dateRaporBit.Visible = False
            'btnListele.Visible = False


            If SIPARISIN_GRUBU = "OZLCLK" Then
                lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş TEL ÇUBUK HH SİPARİŞ BİLDİRİM FORMU"
                IhrKaySip_Yeni.Enabled = False
            Else
                lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş DIŞ PİYASA SİPARİŞ BİLDİRİM FORMU"

            End If
            raporgrd.Sheets(0).Rows(0).Visible = True
            raporgrd.Sheets(0).Rows(1).Visible = True
            raporgrd.Sheets(0).Rows(2).Visible = True
            raporgrd.Sheets(0).Rows(3).Visible = True
            'raporgrd.Sheets(0).Rows(4).Visible = False
            raporgrd.Sheets(0).Rows(5).Visible = True
            raporgrd.Sheets(0).Rows(6).Visible = True
            raporgrd.Sheets(0).Rows(7).Visible = True
            raporgrd.Sheets(0).Rows(8).Visible = True
            raporgrd.Sheets(0).Rows(9).Visible = True
            raporgrd.Sheets(0).Rows(10).Visible = True
            raporgrd.Sheets(0).Rows(11).Visible = True
            raporgrd.Sheets(0).Rows(12).Visible = True
            raporgrd.Sheets(0).Rows(13).Visible = True
            raporgrd.Sheets(0).Rows(14).Visible = True


        End If

        If SIPARISIN_GRUBU <> "" Then
            PrgKod = SIPARISIN_GRUBU
        End If


        If PrgKod = "OZLCLK" Then

            If SIPARISIN_GRUBU = "OZLCLK" Then
                fpSiparisGetir.Sheets(0).Columns(14).Visible = True
                lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş TEL ÇUBUK HH SİPARİŞ BİLDİRİM FORMU"
                IhrKaySip_Yeni.Enabled = False

            Else
                lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş DIŞ PİYASA SİPARİŞ BİLDİRİM FORMU"


            End If


            Dim BAK
            For index As Integer = 0 To UrunAgacListesi.Count - 1
                BAK = BAK & UrunAgacListesi(index)
            Next
            raporgrd.Sheets(0).Rows(4).Visible = True
            raporgrd.Sheets(0).Rows(15).Visible = True ' FIRMA BILGISI
            raporgrd.Sheets(0).RowCount = 18
            'raporgrd.Sheets(0).Cells(16, 0).Text = KALITESINIFACK
            'raporgrd.Sheets(0).Cells(17, 0).Text = "Form No: 05.10.1-2/R-3"
            'raporgrd.Sheets(0).Cells(17, 0).Font.Size = 11
            'raporgrd.Sheets(0).Cells(17, 0).Font.Bold = True
            'raporgrd.Sheets(0).Cells(17, 0).ForeColor = Drawing.Color.Blue

        Else
            '16 DEDIM YANI 15 SATIR 15 ALANA FOR YAZDIR 
            ' ESASINDA 15 TE FIRMA BILGISI VAR AMA SADECE OZLCLK TE GORULCEK
            raporgrd.Sheets(0).RowCount = 16
            'raporgrd.Sheets(0).Cells(15, 0).Text = "Form No: 05.10.1-4/R-1"
            'raporgrd.Sheets(0).Cells(15, 0).Font.Size = 11
            'raporgrd.Sheets(0).Cells(15, 0).Font.Bold = True
            'raporgrd.Sheets(0).Cells(15, 0).ForeColor = Drawing.Color.Blue
        End If


        If Session("PRGKOD") = "DISTIC" Then
            IhrKaySip_Yeni.Enabled = True
            IhrKaySip_Yeni.Text = "IhrKaySip_Yeni"
            BtnYeni.Visible = True
        End If


        If Session("PRGKOD") = "OZLCLK" Then
            IhrKaySip_Yeni.Enabled = False
            IhrKaySip_Yeni.Text = "IhrKaySip_Yeni"
            BtnYeni.Visible = True
        End If

        If Session("PRGKOD") = "ICPIYS" Then
            IhrKaySip_Yeni.Visible = False
            BtnYeni.Visible = True

            'COMBOYA BAK tÜMÜ YOK ISE EKLE
            Dim H, VARX
            VARX = "yok"
            For H = 0 To drpSiparisDurum1.Items.Count - 1
                If drpSiparisDurum1.Items(H).Text = "Tümü" Then
                    VARX = "var"
                    GoTo cık
                End If

            Next
cık:
            If VARX = "yok" Then drpSiparisDurum1.Items.Add("Tümü")

        End If

        If UserName = "OPR1A11" Or UserName = "OPR1912" Then
            fpSiparisGetir.Sheets(0).Columns(13).Visible = True



            TabPanel6.Visible = True
            TabPanel5.Visible = False
            TabPanel4.Visible = False
            TabPanel2.Visible = False
            TabPanel3.Enabled = False
            ' grdcelalbey_getir()
        Else
            fpSiparisGetir.Sheets(0).Columns(13).Visible = False

            TabPanel6.Visible = False
        End If

        If PrgKod = "URTPLN" Then
            TabPanel4.Visible = True
        End If




    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim EkliDosyaYolu

        Dim scriptManager As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        scriptManager.RegisterPostBackControl(Me.Button6)
        scriptManager.RegisterPostBackControl(Me.btnNewEntry)




        txtKayitDurumu.ForeColor = Drawing.Color.White
        Kullanıcı = Session("KULLANICI")
        PrgKod = Session("PRGKOD")
        UserName = Session("USRNAME")
        Sifre = Session("PASSWORD")
        'hiddenPrgKod.Value = Session("PRGKOD")
        UsrTxt.Text = "Kullanıcı :" & Kullanıcı
        Ipadresi = Session("IPADRES")
        'UsrTxt.Text = Ipadresi
        'btnyetki_New(UserName, Sifre)

        Dim i, AnaToplam
        AnaToplam = 0

        If Page.IsPostBack Then
            btnyetki_New(UserName, Sifre)
            EkliDosyaYolu = "upload\" & lblEk.Text
            GRIDLERI_TOPARLA()
        Else
            EkliDosyaYolu = "upload\" & lblEk.Text
            'dateRaporBas0.Value = Date.Now.AddDays(-30)
            'dateRaporBit0.Value = Date.Now
            dateRaporBas.Text = Date.Today
            dateRaporBit.Text = Date.Today
            btnyetki_New(UserName, Sifre)
            Secilirken_Tum_alanları_Kapat()
            If Program_YetkNumarasi = 0 Then drpSiparisDurum1.Text = "Giriş Onayı Bekleyen"
            If Program_YetkNumarasi = 1 Then drpSiparisDurum1.Text = "Giriş Onayı Bekleyen"
            If Program_YetkNumarasi = 2 Then drpSiparisDurum1.Text = "Kontrol Bekleyen"
            If Program_YetkNumarasi = 3 Then drpSiparisDurum1.Text = "Müdür Onayı Bekleyen"
            If Program_YetkNumarasi = 4 Then drpSiparisDurum1.Text = "Uretilecek Siparisler"
            'Uretilecek Siparisler"
            spreadUrunBilgiDoldur()
            spreadKutukKaliteDoldur()
            spreadKutukTedarikciDoldur()
            MustaeriAdıDoldur()
            spreadBoyDoldur()
            txtRevizyon.Text = "0"
            dateSipTar.Text = Date.Today.ToString("dd/MM/yyyy")
            ulkeGetir()
            SiparisSahibiGetir()
            tabAnaliz.ActiveTab = TabPanel1

            If PrgKod = "ICPIYS" Then
                drpSiparisDurum1.Text = "Tümü"
                Rapor_New3()
            Else
                Rapor_New()
            End If

            If Session("PRGKOD") = "KTKTLP" Then
                IhrKaySip_Yeni.Visible = False
            End If
            If PrgKod = "OZLCLK" Then
                Rapor_New()
                drpSiparisDurum1.Items.Remove("Giriş Onayı Bekleyen")
            End If

        End If

        GRIDLERI_TOPARLA()


    End Sub

    Sub GRIDLERI_TOPARLA()

        For i = 0 To fpSiparisGetir.Sheets(0).Columns.Count - 1
            fpSiparisGetir.Sheets(0).ColumnHeader.Columns(i).Font.Size = 7
        Next

        For i = 0 To fpSiparisGetir.Sheets(0).Columns.Count - 1
            fpSiparisGetir.Sheets(0).Columns(i).Font.Size = 8
        Next

        fpSiparisGetir.Sheets(0).Columns(0).Width = 130
        fpSiparisGetir.Sheets(0).Columns(6).Width = 200
        fpSiparisGetir.Sheets(0).Columns(7).Width = 200
    End Sub

    Dim ULKE
    Dim hedefDosyaAdi
    Dim Iade_Durumu = 0

    Private Sub siparisSakla(ByVal gelenRevizyonNo As Integer, ByVal gelenSipNo As String, ByVal gelenSipTar As String)

        Dim MAMUL, FIRMA, CAP_MIK_TOL_N, CAP_MIK_TOL_P, TOP_MIK_TOL_N, TOP_MIK_TOL_P, FATURALAMA, GOZETIM, PAKETLEME, ETIKET, OZEL_SARTLAR
        Dim MRKSIPGIRx, MRKSIPKONTROLx, MRKSIPONAYx, URTPLNONAYx, Durumx
        Dim DbConn As New ConnectGiris


        siparisDurumu = GetSiparisDurumu(gelenRevizyonNo, gelenSipNo)
        SiparisNoDurumu = GetSiparisNoVarmı(gelenRevizyonNo, gelenSipNo)

        If Program_YetkNumarasi >= siparisDurumu Then
            hedefDosyaAdi = lblEk.Text
            Try
                MAMUL = StringToTire(txtMamul.Text.Trim.Replace("'", " "))

                CAP_MIK_TOL_N = 0
                CAP_MIK_TOL_P = 0
                TOP_MIK_TOL_N = 0
                TOP_MIK_TOL_P = 0

                If rdFaturalama.SelectedIndex = 0 Then
                    FATURALAMA = "A"
                ElseIf rdFaturalama.SelectedIndex = 1 Then
                    FATURALAMA = "T"
                Else
                    FATURALAMA = ""
                End If
                'CEVIR(dateSonYuk.Value)
                'son_yuk_tar = StringToZero(DonenTarih)
                PAKETLEME = StringToTire(txtPaketleme.Text.Trim.Replace("'", " "))
                ETIKET = StringToTire(txtEtiket.Text.Trim.Replace("'", " "))
                GOZETIM = StringToTire(txtGozetim.Text.Trim.Replace("'", " "))
                OZEL_SARTLAR = StringToTire(txtOzelSart.Text.Trim.Replace("'", " "))

                ULKE = drpUlke.Text
                FIRMA = txtFirma.Text.Trim.Replace("'", " ")

                SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                & " WHERE SIP_NO= '" & gelenSipNo & "'" _
                & " AND REVIZ_NO= " & gelenRevizyonNo

                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    Iade_Durumu = DbConn.MyDataReader.Item("IADE_DURUM") 'İade durumunu tekrar update etmedim. Zaten kaydı sildimiz için 0 default atanıyor.
                End While
                DbConn.Kapat()

                If gelenRevizyonNo > 0 Then
                    SQL = "UPDATE MRKSIP_CBK_FLM " _
                    & " SET DURUM='99'" _
                    & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                    & " AND REVIZ_NO <> '" & txtRevizyon.Text & "'"
                    DbConn.SaveUpdate(SQL)
                    DbConn.Kapat()
                End If

                SQL = "DELETE FROM MRKSIP_CBK_FLM" _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO=" & gelenRevizyonNo _
                & " AND SIPARIS_GRUBU='" & PrgKod & "'"

                DbConn.Sil(SQL)
                DbConn.Kapat()

                Try

                    Dim SIPARIS_GIRISX = ""
                    Dim SIPARIS_GIRIS_ONAYX = ""
                    Dim SIPARIS_KONTROLX = ""
                    Dim SIPARIS_ONAYX = ""
                    Dim SIPARIS_URETIM_ONAYX = ""
                    Durumx = ""

                    SIPARIS_GIRISX = Kullanıcı & "-" & Date.Now

                    If PrgKod = "ICPIYS" Then
                        If Program_YetkNumarasi = 3 Then
                            Durumx = -1
                        Else
                            If Program_YetkNumarasi = -1 Then
                                Durumx = -1
                            End If
                        End If
                    Else
                        Durumx = -1
                    End If
                    'CAP_MIK_TOL VE TOP_MIK_TOL ALANLARI YUKARIDA 0 ATANARAK SAKLATILIYOR. SQL DEĞİŞTİRİLMEDİ.
                    SQL = "INSERT INTO MRKSIP_CBK_FLM(SIP_TAR,SIP_NO,REVIZ_NO,MAMUL,ULKE,FIRMA,CAP_MIK_TOL_N,CAP_MIK_TOL_P,TOP_MIK_TOL_N,TOP_MIK_TOL_P,FATURALAMA,GOZETIM,PAKETLEME,ETIKET,OZEL_SARTLAR,SIPARIS_GIRIS,SIPARIS_GIRIS_ONAY,SIPARIS_KONTROL,SIPARIS_ONAY,SIPARIS_URETIM_ONAY,DURUM,MARKA,DOSYA,SIPARIS_SAHIBI,SIPARISI_GIREN,SIPARIS_GRUBU,PDF) VALUES " _
                    & "('" & gelenSipTar & "'," _
                    & "'" & gelenSipNo & "'," _
                    & "'" & gelenRevizyonNo & "'," _
                    & "'" & MAMUL & "'," _
                    & "'" & ULKE & "'," _
                    & "'" & FIRMA & "'," _
                    & "'" & CAP_MIK_TOL_N & "'," _
                    & "'" & CAP_MIK_TOL_P & "'," _
                    & "'" & TOP_MIK_TOL_N & "'," _
                    & "'" & TOP_MIK_TOL_P & "'," _
                    & "'" & FATURALAMA & "'," _
                    & "'" & GOZETIM & "'," _
                    & "'" & PAKETLEME & "'," _
                    & "'" & ETIKET & "'," _
                    & "'" & OZEL_SARTLAR & "'," _
                    & "'" & SIPARIS_GIRISX & "'," _
                    & "'" & SIPARIS_GIRIS_ONAYX & "'," _
                    & "'" & SIPARIS_KONTROLX & "'," _
                    & "'" & SIPARIS_ONAYX & "'," _
                    & "'" & SIPARIS_URETIM_ONAYX & "'," _
                    & "'" & Durumx & "'," _
                    & "'" & drpMarka.Text & "'," _
                    & "'" & hedefDosyaAdi & "'," _
                    & "'" & Siparis_Sahibi.Text & "'," _
                     & "'" & Kullanıcı & "'," _
                     & "'" & PrgKod & "'," _
                    & "" & 0 & ")"

                    DbConn.SaveUpdate(SQL)
                    DbConn.Kapat()
                    txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
                    txtKayitDurumu.Text = "Siparis ana kayit tamamlandı."
                    'rapor()

                    altTabloSakla(gelenSipNo, gelenRevizyonNo)

                    ' bunların yanında ayrıca MRKSIP_CBK_FLM TABLOSUNDAKI PDF ALANINI 0 YAPMAK LAZIM
                    ' CUNKI SERVERDA CALISAN EXE BUNA BAKIP BU SIPARISIN PDF'INI OLUSTURUYOR

                    'SQL = "UPDATE MRKSIP_CBK_FLM " _
                    '   & " SET PDF=0" _
                    '   & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                    '   & " AND REVIZ_NO <> '" & txtRevizyon.Text & "'"
                    'DbConn9.SaveUpdate(SQL)
                    'DbConn9.Kapat()



                Catch ex As Exception
                    txtKayitDurumu.BackColor = Drawing.Color.Red
                    txtKayitDurumu.Text = "MRKSIP_CBK_FLM SAKLA fonksiyonu hataya düştü"
                    'MsgBox("MRKSIP_CBK_FLM SAKLA fonksiyonu hataya düştü")
                    DbConn.Kapat()
                    'Kayıt sırasında degerlerden kaynaklı hata oluşursa serbest alanlı alana kayıt atılacak.
                    SQL = "INSERT INTO MRKSIP_CBK_FLM_hata(SIP_TAR,SIP_NO,REVIZ_NO,MAMUL,ULKE,FIRMA,CAP_MIK_TOL_N,CAP_MIK_TOL_P,TOP_MIK_TOL_N,TOP_MIK_TOL_P,FATURALAMA,GOZETIM,PAKETLEME,ETIKET,OZEL_SARTLAR,MRKSIPGIR,MRKSIPKONTROL,MRKSIPONAY,URTPLNONAY,DURUM,NEDEN,MARKA,DOSYA) VALUES " _
                    & "('" & gelenSipTar & "'," _
                    & "'" & gelenSipNo & "'," _
                    & "'" & gelenRevizyonNo & "'," _
                    & "'" & MAMUL & "'," _
                    & "'" & ULKE & "'," _
                    & "'" & FIRMA & "'," _
                    & "'" & CAP_MIK_TOL_N & "'," _
                    & "'" & CAP_MIK_TOL_P & "'," _
                    & "'" & TOP_MIK_TOL_N & "'," _
                    & "'" & TOP_MIK_TOL_P & "'," _
                    & "'" & FATURALAMA & "'," _
                    & "'" & GOZETIM & "'," _
                    & "'" & PAKETLEME & "'," _
                    & "'" & ETIKET & "'," _
                    & "'" & OZEL_SARTLAR & "'," _
                    & "'" & MRKSIPGIRx & "'," _
                    & "'" & MRKSIPKONTROLx & "'," _
                    & "'" & MRKSIPONAYx & "'," _
                    & "'" & URTPLNONAYx & "'," _
                    & "'" & Durumx & "'," _
                    & "'ANA TABLO KAYIT HATASI'," _
                    & "'" & drpMarka.Text & "'," _
                    & "'" & hedefDosyaAdi & "')"


                    DbConn.SaveUpdate(SQL)
                    DbConn.Kapat()
                End Try
            Catch ex As Exception
                txtKayitDurumu.BackColor = Drawing.Color.Red
                txtKayitDurumu.Text = "Degisken atamada hata"
                'MsgBox("Degisken atamada hata")
                DbConn.Kapat()
            End Try
        Else
            txtKayitDurumu.Text = "Üst onay aldığı için saklama gerçekleştiremezsiniz."
            txtKayitDurumu.BackColor = Drawing.Color.Red
        End If
    End Sub
    Private Sub altTabloSakla(ByVal gelenSipNo As String, ByVal gelenRevizyonNo As Integer)

        Dim DbConn As New ConnectGiris
        Dim DbConnSil As New ConnectGiris
        Dim LOT, MAM_STANDART, MAM_KALITE, MAM_TIP, EBAT, ND, BOY, BOY_TOL_N, BOY_TOL_P, MIKTAR, BOYAMA, ROTOR_TIP, URUN_BILGI, KUTUK_MENSEI, KUTUK_KALITE, TERMIN_BAS_TAR, TERMIN_BIT_TAR, CUBUK_SAY, BRM_AGIRLIK_KG, PAKET_AGIRLIK, MARKA, BOSALTMA_LIMAN, HADDE_TOL_N, HADDE_TOL_P, KOSE_RADYUS, ROMBIK, DOG_SAPMA, BURULMA, KESME_SEKLI, EBAT_TOL_N, EBAT_TOL_P, CAP_MIK_TOL_MIN, CAP_MIK_TOL_MAX, TOP_MIK_TOL_MIN, TOP_MIK_TOL_MAX, MusteriAdi
        Try
            SQL = "DELETE FROM MRKSIP_CBK_FLM_ALT" _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO=" & gelenRevizyonNo
            DbConnSil.Sil(SQL)
            DbConn.Kapat()
            'MsgBox "alt tablo silindi"
            For index As Integer = 0 To fpEbatMiktar.Rows.Count - 1
                LOT = fpEbatMiktar.Sheets(0).Cells(index, 2).Text.Trim 'y
                MAM_STANDART = fpEbatMiktar.Sheets(0).Cells(index, 4).Text.Trim
                MAM_KALITE = fpEbatMiktar.Sheets(0).Cells(index, 5).Text.Trim
                MAM_TIP = ""
                If fpEbatMiktar.Sheets(0).Cells(index, 3).Text.Trim = "Kangal" Then
                    MAM_TIP = "K"
                ElseIf fpEbatMiktar.Sheets(0).Cells(index, 3).Text.Trim = "Çubuk" Then
                    MAM_TIP = "C"
                ElseIf fpEbatMiktar.Sheets(0).Cells(index, 3).Text.Trim = "Kangal Doğrultma" Then
                    MAM_TIP = "KD"
                ElseIf fpEbatMiktar.Sheets(0).Cells(index, 3).Text.Trim = "Kutuk" Then
                    MAM_TIP = "KT"
                End If
                EBAT = fpEbatMiktar.Sheets(0).Cells(index, 6).Text.Trim
                ND = fpEbatMiktar.Sheets(0).Cells(index, 7).Text.Trim

                If fpEbatMiktar.Sheets(0).Cells(index, 8).Text.Trim = "FİRKETE" Then
                    BOY = "999"
                Else
                    BOY = fpEbatMiktar.Sheets(0).Cells(index, 8).Text.Trim
                End If

                BOY_TOL_N = fpEbatMiktar.Sheets(0).Cells(index, 9).Text.Trim
                BOY_TOL_P = fpEbatMiktar.Sheets(0).Cells(index, 10).Text.Trim
                MIKTAR = fpEbatMiktar.Sheets(0).Cells(index, 11).Text.Trim

                CUBUK_SAY = fpEbatMiktar.Sheets(0).Cells(index, 12).Text.Trim
                BRM_AGIRLIK_KG = fpEbatMiktar.Sheets(0).Cells(index, 13).Text.Trim.Replace(",", ".")
                PAKET_AGIRLIK = fpEbatMiktar.Sheets(0).Cells(index, 14).Text.Trim

                HADDE_TOL_N = fpEbatMiktar.Sheets(0).Cells(index, 15).Text
                HADDE_TOL_P = fpEbatMiktar.Sheets(0).Cells(index, 16).Text

                If fpEbatMiktar.Sheets(0).Cells(index, 17).Text.Trim = "Büyük Rotor" Then
                    ROTOR_TIP = "BR"
                ElseIf fpEbatMiktar.Sheets(0).Cells(index, 17).Text.Trim = "Küçük Rotor" Then
                    ROTOR_TIP = "KR"
                Else
                    ROTOR_TIP = "0"
                End If

                URUN_BILGI = fpEbatMiktar.Sheets(0).Cells(index, 18).Text.Trim
                KUTUK_MENSEI = fpEbatMiktar.Sheets(0).Cells(index, 19).Text.Trim
                KUTUK_KALITE = fpEbatMiktar.Sheets(0).Cells(index, 20).Text.Trim
                If PrgKod <> "ICPIYS" Then
                    CEVIRconvert(fpEbatMiktar.Sheets(0).Cells(index, 21).Text)
                    TERMIN_BAS_TAR = StringToZero(DonenTarih)
                    CEVIRconvert(fpEbatMiktar.Sheets(0).Cells(index, 22).Text)
                    TERMIN_BIT_TAR = StringToZero(DonenTarih)
                End If
                If fpEbatMiktar.Sheets(0).Cells(index, 21).Text <> "" Then
                    CEVIRconvert(fpEbatMiktar.Sheets(0).Cells(index, 21).Text)
                    TERMIN_BAS_TAR = StringToZero(DonenTarih)
                End If
                If fpEbatMiktar.Sheets(0).Cells(index, 22).Text <> "" Then
                    CEVIRconvert(fpEbatMiktar.Sheets(0).Cells(index, 22).Text)
                    TERMIN_BIT_TAR = StringToZero(DonenTarih)
                End If
                BOSALTMA_LIMAN = fpEbatMiktar.Sheets(0).Cells(index, 23).Text.Trim

                If fpEbatMiktar.Sheets(0).Cells(index, 24).Text.Trim = "" Then
                    BOYAMA = "-"
                Else
                    BOYAMA = fpEbatMiktar.Sheets(0).Cells(index, 24).Text.Trim
                End If

                KOSE_RADYUS = fpEbatMiktar.Sheets(0).Cells(index, 25).Text.Trim
                ROMBIK = fpEbatMiktar.Sheets(0).Cells(index, 26).Text.Trim
                DOG_SAPMA = fpEbatMiktar.Sheets(0).Cells(index, 27).Text.Trim
                BURULMA = fpEbatMiktar.Sheets(0).Cells(index, 28).Text.Trim
                KESME_SEKLI = fpEbatMiktar.Sheets(0).Cells(index, 29).Text.Trim

                EBAT_TOL_N = StringToZero(fpEbatMiktar.Sheets(0).Cells(index, 30).Text.Trim)
                EBAT_TOL_P = StringToZero(fpEbatMiktar.Sheets(0).Cells(index, 31).Text.Trim)

                MusteriAdi = StringToZero(fpEbatMiktar.Sheets(0).Cells(index, 36).Text.Trim)

                CAP_MIK_TOL_MIN = StringToZero(fpEbatMiktar.Sheets(0).Cells(index, 32).Text.Trim)
                CAP_MIK_TOL_MAX = StringToZero(fpEbatMiktar.Sheets(0).Cells(index, 33).Text.Trim)
                TOP_MIK_TOL_MIN = StringToZero(fpEbatMiktar.Sheets(0).Cells(index, 34).Text.Trim)
                TOP_MIK_TOL_MAX = StringToZero(fpEbatMiktar.Sheets(0).Cells(index, 35).Text.Trim)

                If LOT = "" Then LOT = "0"
                'If ebat = "" Or miktar = "" Or cubukSayisi = "" Or BirimAgir = "" Then
                '    txtKayitDurumu.ForeColor = Drawing.Color.Red
                '    txtKayitDurumu.Text = " Ebat, Miktar, Çubuk Sayısı veya Birim Ağırlık alanlarından 1 veya birkaçı boş."
                'Else
                Dim URETIMYERI
                If MAM_TIP = "C" Then URETIMYERI = "Çubuk Haddehanesi"
                If MAM_TIP = "K" Then URETIMYERI = "Tel Çubuk Haddehanesi"
                If MAM_TIP = "KD" Then URETIMYERI = "Tel Çubuk Haddehanesi"


                If MAM_TIP <> "KT" Then

                    SQL = "INSERT INTO MRKSIP_CBK_FLM_ALT(SIP_NO,LOT,REVIZ_NO,MAM_STANDART,MAM_KALITE,MAM_TIP,EBAT,ND,BOY,BOY_TOL_N,BOY_TOL_P,MIKTAR,BOYAMA,ROTOR_TIP,URUN_BILGI,KUTUK_MENSEI,KUTUK_KALITE,TERMIN_BAS_TAR,TERMIN_BIT_TAR,CUBUK_SAY,BRM_AGIRLIK_KG,PAKET_AGIRLIK,HADDE_TOL_N,HADDE_TOL_P,BOSALTMA_LIMAN ,KOSERADYUS,ROMBIKLIK,DOGSAPMA,BURULMA,KESMESEKLI,EBAT_TOL_N,EBAT_TOL_P,EBAT_SIRA,CAP_MIK_TOL_MIN, CAP_MIK_TOL_MAX, TOP_MIK_TOL_MIN, TOP_MIK_TOL_MAX,MUSTERIADI,URETIM_YERI) VALUES " _
                                   & "('" & gelenSipNo & "'," _
                                   & "'" & LOT & "'," _
                                   & "'" & gelenRevizyonNo & "'," _
                                   & "'" & MAM_STANDART & "'," _
                                   & "'" & MAM_KALITE & "'," _
                                   & "'" & MAM_TIP & "'," _
                                   & "'" & EBAT & "'," _
                                   & "'" & ND & "'," _
                                   & "'" & BOY & "'," _
                                   & "'" & BOY_TOL_N & "'," _
                                   & "'" & BOY_TOL_P & "'," _
                                   & "'" & MIKTAR & "'," _
                                   & "'" & BOYAMA & "'," _
                                   & "'" & ROTOR_TIP & "'," _
                                   & "'" & URUN_BILGI & "'," _
                                   & "'" & KUTUK_MENSEI & "'," _
                                   & "'" & KUTUK_KALITE & "'," _
                                   & "'" & TERMIN_BAS_TAR & "'," _
                                   & "'" & TERMIN_BIT_TAR & "'," _
                                   & "'" & CUBUK_SAY & "'," _
                                   & "'" & BRM_AGIRLIK_KG & "'," _
                                   & "'" & PAKET_AGIRLIK & "'," _
                                   & "'" & HADDE_TOL_N & "'," _
                                   & "'" & HADDE_TOL_P & "'," _
                                   & "'" & BOSALTMA_LIMAN & "'," _
                                   & "'" & KOSE_RADYUS & "'," _
                                   & "'" & ROMBIK & "'," _
                                   & "'" & DOG_SAPMA & "'," _
                                   & "'" & BURULMA & "'," _
                                   & "'" & KESME_SEKLI & "'," _
                                   & "'" & EBAT_TOL_N & "'," _
                                   & "'" & EBAT_TOL_P & "'," _
                                   & "" & 1000 & "," _
                                   & "'" & CAP_MIK_TOL_MIN & "'," _
                                   & "'" & CAP_MIK_TOL_MAX & "'," _
                                   & "'" & TOP_MIK_TOL_MIN & "'," _
                                   & "'" & TOP_MIK_TOL_MAX & "'," _
                                   & "'" & MusteriAdi & "'," _
                                   & "'" & URETIMYERI & "')"
                Else
                    SQL = "INSERT INTO MRKSIP_CBK_FLM_ALT(SIP_NO,LOT,REVIZ_NO,MAM_STANDART,MAM_KALITE,MAM_TIP,EBAT,ND,BOY,BOY_TOL_N,BOY_TOL_P,MIKTAR,BOYAMA,ROTOR_TIP,URUN_BILGI,KUTUK_MENSEI,KUTUK_KALITE,TERMIN_BAS_TAR,TERMIN_BIT_TAR,CUBUK_SAY,BRM_AGIRLIK_KG,PAKET_AGIRLIK,HADDE_TOL_N,HADDE_TOL_P,BOSALTMA_LIMAN ,KOSERADYUS,ROMBIKLIK,DOGSAPMA,BURULMA,KESMESEKLI,EBAT_TOL_N,EBAT_TOL_P,CAP_MIK_TOL_MIN, CAP_MIK_TOL_MAX, TOP_MIK_TOL_MIN, TOP_MIK_TOL_MAX,MUSTERIADI,URETIM_YERI) VALUES " _
                                   & "('" & gelenSipNo & "'," _
                                   & "'" & LOT & "'," _
                                   & "'" & gelenRevizyonNo & "'," _
                                   & "'" & MAM_STANDART & "'," _
                                   & "'" & MAM_KALITE & "'," _
                                   & "'" & MAM_TIP & "'," _
                                   & "'" & EBAT & "'," _
                                   & "'" & ND & "'," _
                                   & "'" & BOY & "'," _
                                   & "'" & BOY_TOL_N & "'," _
                                   & "'" & BOY_TOL_P & "'," _
                                   & "'" & MIKTAR & "'," _
                                   & "'" & BOYAMA & "'," _
                                   & "'" & ROTOR_TIP & "'," _
                                   & "'" & URUN_BILGI & "'," _
                                   & "'" & KUTUK_MENSEI & "'," _
                                   & "'" & KUTUK_KALITE & "'," _
                                   & "'" & TERMIN_BAS_TAR & "'," _
                                   & "'" & TERMIN_BIT_TAR & "'," _
                                   & "'" & CUBUK_SAY & "'," _
                                   & "'" & BRM_AGIRLIK_KG & "'," _
                                   & "'" & PAKET_AGIRLIK & "'," _
                                   & "'" & HADDE_TOL_N & "'," _
                                   & "'" & HADDE_TOL_P & "'," _
                                   & "'" & BOSALTMA_LIMAN & "'," _
                                   & "'" & KOSE_RADYUS & "'," _
                                   & "'" & ROMBIK & "'," _
                                   & "'" & DOG_SAPMA & "'," _
                                   & "'" & BURULMA & "'," _
                                   & "'" & KESME_SEKLI & "'," _
                                   & "'" & EBAT_TOL_N & "'," _
                                   & "'" & EBAT_TOL_P & "'," _
                                   & "'" & CAP_MIK_TOL_MIN & "'," _
                                   & "'" & CAP_MIK_TOL_MAX & "'," _
                                   & "'" & TOP_MIK_TOL_MIN & "'," _
                                   & "'" & TOP_MIK_TOL_MAX & "'," _
                                    & "'" & MusteriAdi & "'," _
                                   & "'" & URETIMYERI & "')"
                End If

                DbConn.SaveUpdate(SQL)
                DbConn.Kapat()
                'End If

            Next

            GETIR()
            'txtKayitDurumu.BackColor = Drawing.Color.Green
            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = fpEbatMiktar.Rows.Count & " adet satır başarıyla kaydedildi"
            alanlariBeyazlat()
            Buton_SIP_GIRIS.Enabled = True


            'If SiparisNoZatenVar = False Or Iade_Durumu = 1 Then ' yanı bu sipariş zaten vardı kullanıcı sadece kend ıcınde kayıt yenıledi **Sipariş yeni açıldıysa yada iade durumu 1 ise(yani iade edildiyse) mail kesin gidecek. Else girmesi için iade durumu mutlaka 0 olmalı
            '    MailGonder(Session("KULLANICI"), Btn_SIP_GIRIS_MAIL, "Yeni bir Sipariş Girildi", txtUretimSipNo.Text, txtRevizyon.Text)
            'Else

            '    If Session("EskiRevNo") <> txtRevizyon.Text Then
            '        Session("EskiRevNo") = txtRevizyon.Text
            '        MailGonder(Session("KULLANICI"), Btn_SIP_REVIZYON_MAIL, "Sipariş Revizyon Edilmiştir", txtUretimSipNo.Text, txtRevizyon.Text)
            '    End If

            '    'MailGonder(Session("KULLANICI"), Btn_SIP_REVIZYON_MAIL, "Sipariş Bilgileri Güncellendi", txtUretimSipNo.Text, txtRevizyon.Text)

            'End If

            'rapor() ' Alt tablo saklandıktan sonra rapor çalıştırılacak
        Catch ex As Exception
            DbConn.Kapat()
            txtKayitDurumu.BackColor = Drawing.Color.Red
            txtKayitDurumu.Text = "ALT TABLO SAKLA fonksiyonu hataya düştü"
            'MsgBox("ALT TABLO SAKLA fonksiyonu hataya düştü" & ex.ToString)
            'SQL = "INSERT INTO MRKSIP_CBK_FLM_ALT_hata(SIP_NO,LOT,REVIZ_NO,MAM_STANDART,MAM_KALITE,MAM_TIP,EBAT,ND,BOY,BOY_TOL_N,BOY_TOL_P,MIKTAR,BOYAMA,ROTOR_TIP,URUN_BILGI,KUTUK_MENSEI,KUTUK_KALITE,TERMIN_BAS_TAR,TERMIN_BIT_TAR,CUBUK_SAY,BRM_AGIRLIK_KG,PAKET_AGIRLIK,NEDEN,MARKA,BOSALTMA_LIMAN ) VALUES " _
            '    & "('" & gelenSipNo & "'," _
            '    & "'" & LOT & "'," _
            '    & "'" & gelenRevizyonNo & "'," _
            '    & "'" & MAM_STANDART & "'," _
            '    & "'" & MAM_KALITE & "'," _
            '    & "'" & MAM_TIP & "'," _
            '    & "'" & EBAT & "'," _
            '    & "'" & ND & "'," _
            '    & "'" & BOY & "'," _
            '    & "'" & BOY_TOL_N & "'," _
            '    & "'" & BOY_TOL_P & "'," _
            '    & "'" & MIKTAR & "'," _
            '    & "'" & BOYAMA & "'," _
            '    & "'" & ROTOR_TIP & "'," _
            '    & "'" & URUN_BILGI & "'," _
            '    & "'" & KUTUK_MENSEI & "'," _
            '    & "'" & KUTUK_KALITE & "'," _
            '    & "'" & TERMIN_BAS_TAR & "'," _
            '    & "'" & TERMIN_BIT_TAR & "'," _
            '    & "'" & CUBUK_SAY & "'," _
            '    & "'" & BRM_AGIRLIK_KG & "'," _
            '    & "'" & PAKET_AGIRLIK & "'," _
            '    & "'ALT TABLO SAKLAMA HATASI'," _
            '    & "'" & MARKA & "'," _
            '    & "'" & BOSALTMA_LIMAN & "')"
            'DbConn.SaveUpdate(SQL)
            'DbConn.Kapat()
        End Try

    End Sub

    Public Sub CEVIR4(ByVal gelen)

        Dim YIL, AY, GUN As String
        YIL = Microsoft.VisualBasic.Year(gelen)
        AY = Microsoft.VisualBasic.Month(gelen)
        If Microsoft.VisualBasic.Len(AY.ToString) = 1 Then AY = "0" & AY
        GUN = Microsoft.VisualBasic.Day(gelen)
        If Microsoft.VisualBasic.Len(GUN) = 1 Then GUN = "0" & GUN
        DonenTarih = YIL & AY & GUN

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

    Public Shared Function StringToZero(ByVal obj As Object) As Object
        Try
            If obj = "" Or IsNothing(obj) Or IsDBNull(obj) Then
                Return 0
            Else
                Return obj
            End If
        Catch ex As System.Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function StringToTire(ByVal obj As Object) As Object
        Try
            If obj = "" Or IsNothing(obj) Or IsDBNull(obj) Then
                Return "-"
            Else
                Return obj
            End If
        Catch ex As System.Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Shared Function NullToString(ByVal obj As Object) As Object
        Try
            If IsNothing(obj) Or IsDBNull(obj) Then
                Return ""
            Else
                Return obj
            End If
        Catch ex As System.Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Sub siparisleriAlanaGetir(ByVal gelenSipNo As String, ByVal gelenRevizNo As Integer, ByVal SiparisinDurumu As Integer)
        Try

            'eger bu siparişin veya bu lotun revizyonu yoksa prınt için hazırlanan raporgrd gridini beyazlatmalıyım
            Dim h
            For h = 0 To 14
                raporgrd.Sheets(0).Cells(h, 1).ForeColor = Drawing.Color.Black
                raporgrd.Sheets(0).Cells(h, 1).Font.Italic = False
            Next h

            'önce revizyonlu sipariş seçilir sonrasında revizyonsuz sipariş seçilirse alanların beyazlatılması gerekiyor.
            dateSipTar.ForeColor = Drawing.Color.Black
            dateSipTarOnay.ForeColor = Drawing.Color.Black
            dateSipTarOnay.Font.Italic = False
            txtMamul.ForeColor = Drawing.Color.Black
            txtMamulOnay.ForeColor = Drawing.Color.Black
            txtMamulOnay.Font.Italic = False
            drpUlke.ForeColor = Drawing.Color.Black
            txtCapMikTolPoz.ForeColor = Drawing.Color.Black
            txtCapMikTolNeg.ForeColor = Drawing.Color.Black
            txtTopMikTolPoz.ForeColor = Drawing.Color.Black
            txtTopMikTolNeg.ForeColor = Drawing.Color.Black
            rdFaturalama.ForeColor = Drawing.Color.Black
            txtGozetim.ForeColor = Drawing.Color.Black
            txtPaketleme.ForeColor = Drawing.Color.Black


            Dim SQL, SQL1
            Dim DbConn As New ConnectGiris
            Dim DbConnEski As New ConnectGiris
            SQL = " SELECT *FROM MRKSIP_CBK_FLM" _
                & " WHERE SIP_NO= '" & gelenSipNo & "'" _
                & " AND REVIZ_NO= " & gelenRevizNo
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                If gelenRevizNo > 0 Then
                    SQL1 = " SELECT *FROM MRKSIP_CBK_FLM" _
                & " WHERE SIP_NO= '" & gelenSipNo & "'" _
                & " AND REVIZ_NO= " & gelenRevizNo - 1
                    DbConnEski.RaporWhile(SQL1)
                    While DbConnEski.MyDataReader.Read

                        If DbConn.MyDataReader.Item("SIP_TAR") <> DbConnEski.MyDataReader.Item("SIP_TAR") Then
                            dateSipTar.ForeColor = Drawing.Color.Red
                            dateSipTarOnay.ForeColor = Drawing.Color.Red
                            dateSipTarOnay.Font.Italic = True
                        Else
                            dateSipTar.ForeColor = Drawing.Color.Black
                            dateSipTarOnay.ForeColor = Drawing.Color.Black
                            dateSipTarOnay.Font.Italic = False
                        End If
                        If DbConn.MyDataReader.Item("MAMUL") <> DbConnEski.MyDataReader.Item("MAMUL") Then
                            txtMamul.ForeColor = Drawing.Color.Red
                            txtMamulOnay.ForeColor = Drawing.Color.Red
                            txtMamulOnay.Font.Italic = True
                        Else
                            txtMamul.ForeColor = Drawing.Color.Black
                            txtMamulOnay.ForeColor = Drawing.Color.Black
                            txtMamulOnay.Font.Italic = False
                        End If




                        If IsDBNull(DbConn.MyDataReader.Item("ULKE")) <> IsDBNull(DbConnEski.MyDataReader.Item("ULKE")) Then
                            drpUlke.ForeColor = Drawing.Color.Red
                            ' drpUlkeOnay.BackColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(11, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(11, 1).Font.Italic = True
                        Else
                            drpUlke.ForeColor = Drawing.Color.Black
                            'drpUlkeOnay.BackColor = Drawing.Color.White
                            raporgrd.Sheets(0).Cells(11, 1).ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(11, 1).Font.Italic = False
                        End If

                        ' CAP GRUBU 
                        'If DbConn.MyDataReader.Item("CAP_MIK_TOL_P") <> DbConnEski.MyDataReader.Item("CAP_MIK_TOL_P") Then
                        '    txtCapMikTolPoz.ForeColor = Drawing.Color.Red
                        'Else
                        '    txtCapMikTolPoz.ForeColor = Drawing.Color.Black
                        'End If

                        'If DbConn.MyDataReader.Item("CAP_MIK_TOL_N") <> DbConnEski.MyDataReader.Item("CAP_MIK_TOL_N") Then
                        '    txtCapMikTolNeg.ForeColor = Drawing.Color.Red
                        'Else
                        '    txtCapMikTolNeg.ForeColor = Drawing.Color.Black
                        'End If
                        'If DbConn.MyDataReader.Item("CAP_MIK_TOL_P") <> DbConnEski.MyDataReader.Item("CAP_MIK_TOL_P") Or DbConn.MyDataReader.Item("CAP_MIK_TOL_N") <> DbConnEski.MyDataReader.Item("CAP_MIK_TOL_N") Then
                        '    raporgrd.Sheets(0).Cells(2, 1).ForeColor = Drawing.Color.Red
                        '    raporgrd.Sheets(0).Cells(2, 1).Font.Italic = True
                        'Else
                        '    raporgrd.Sheets(0).Cells(2, 1).ForeColor = Drawing.Color.Black
                        '    raporgrd.Sheets(0).Cells(2, 1).Font.Italic = False
                        'End If


                        ' MIKTAR GRUBU
                        'If DbConn.MyDataReader.Item("TOP_MIK_TOL_P") <> DbConnEski.MyDataReader.Item("TOP_MIK_TOL_P") Then
                        '    txtTopMikTolPoz.ForeColor = Drawing.Color.Red
                        'Else
                        '    txtTopMikTolPoz.ForeColor = Drawing.Color.Black
                        'End If
                        'If DbConn.MyDataReader.Item("TOP_MIK_TOL_N") <> DbConnEski.MyDataReader.Item("TOP_MIK_TOL_N") Then
                        '    txtTopMikTolNeg.ForeColor = Drawing.Color.Red
                        'Else
                        '    txtTopMikTolNeg.ForeColor = Drawing.Color.Black
                        'End If

                        'If DbConn.MyDataReader.Item("TOP_MIK_TOL_P") <> DbConnEski.MyDataReader.Item("TOP_MIK_TOL_P") Or DbConn.MyDataReader.Item("TOP_MIK_TOL_N") <> DbConnEski.MyDataReader.Item("TOP_MIK_TOL_N") Then
                        '    raporgrd.Sheets(0).Cells(1, 1).ForeColor = Drawing.Color.Red
                        '    raporgrd.Sheets(0).Cells(1, 1).Font.Italic = True
                        'Else
                        '    raporgrd.Sheets(0).Cells(1, 1).ForeColor = Drawing.Color.Black
                        '    raporgrd.Sheets(0).Cells(1, 1).Font.Italic = False
                        'End If


                        If DbConn.MyDataReader.Item("FATURALAMA") <> DbConnEski.MyDataReader.Item("FATURALAMA") Then
                            rdFaturalama.ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(6, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(6, 1).Font.Italic = True
                        Else
                            rdFaturalama.ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(6, 1).ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(6, 1).Font.Italic = False
                        End If

                        If DbConn.MyDataReader.Item("GOZETIM") <> DbConnEski.MyDataReader.Item("GOZETIM") Then
                            txtGozetim.ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(9, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(9, 1).Font.Italic = True
                        Else
                            txtGozetim.ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(9, 1).ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(9, 1).Font.Italic = False
                        End If

                        If DbConn.MyDataReader.Item("PAKETLEME") <> DbConnEski.MyDataReader.Item("PAKETLEME") Then
                            txtPaketleme.ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(7, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(7, 1).Font.Italic = True
                        Else
                            txtPaketleme.ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(7, 1).ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(7, 1).Font.Italic = False
                        End If

                        If DbConn.MyDataReader.Item("ETIKET") <> DbConnEski.MyDataReader.Item("ETIKET") Then
                            txtEtiket.ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(8, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(8, 1).Font.Italic = True
                        Else
                            txtEtiket.ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(8, 1).ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(8, 1).Font.Italic = False
                        End If

                        If DbConn.MyDataReader.Item("OZEL_SARTLAR") <> DbConnEski.MyDataReader.Item("OZEL_SARTLAR") Then
                            txtOzelSart.ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(10, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(10, 1).Font.Italic = True
                        Else
                            txtOzelSart.ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(10, 1).ForeColor = Drawing.Color.Black
                            raporgrd.Sheets(0).Cells(10, 1).Font.Italic = False
                        End If

                        'If DbConn.MyDataReader.Item("SIPARIS_SAHIBI") <> DbConnEski.MyDataReader.Item("SIPARIS_SAHIBI") Then
                        '    Siparis_Sahibi.BackColor = Drawing.Color.Red
                        '    Siparis_Sahibi.BackColor = Drawing.Color.Red
                        'Else
                        '    Siparis_Sahibi.BackColor = Drawing.Color.White
                        '    Siparis_Sahibi.BackColor = Drawing.Color.White
                        'End If

                        If IsDBNull(DbConn.MyDataReader.Item("DOSYA")) Or IsDBNull(DbConnEski.MyDataReader.Item("DOSYA")) Then

                        Else
                            If DbConn.MyDataReader.Item("DOSYA") <> DbConnEski.MyDataReader.Item("DOSYA") Then
                                lblEk.ForeColor = Drawing.Color.Black
                                raporgrd.Sheets(0).Cells(12, 1).ForeColor = Drawing.Color.Black
                                raporgrd.Sheets(0).Cells(12, 1).Font.Italic = True
                            Else
                                lblEk.ForeColor = Drawing.Color.Black
                                raporgrd.Sheets(0).Cells(12, 1).ForeColor = Drawing.Color.Black
                                raporgrd.Sheets(0).Cells(12, 1).Font.Italic = False
                            End If
                        End If


                    End While
                    DbConnEski.Kapat()
                End If

                txtUretimSipNoOnay.Text = txtUretimSipNo.Text
                txtRevizyonOnay.Text = txtRevizyon.Text

                TERSCEVIR(DbConn.MyDataReader.Item("SIP_TAR"))
                dateSipTar.Text = DonenTersTarih
                dateSipTarOnay.Text = DonenTersTarih

                txtMamul.Text = DbConn.MyDataReader.Item("MAMUL") & ""
                txtMamulOnay.Text = DbConn.MyDataReader.Item("MAMUL") & ""

                '0 satır toplam alanı hesaplanıp geldı 
                'Dim Isaret1 = "", Isaret2 = ""
                'If DbConn.MyDataReader.Item("TOP_MIK_TOL_N") > 0 Then Isaret1 = "+"
                'If DbConn.MyDataReader.Item("TOP_MIK_TOL_P") > 0 Then Isaret2 = "+"
                'txtTopMikTolPoz.Text = DbConn.MyDataReader.Item("TOP_MIK_TOL_P")
                'txtTopMikTolNeg.Text = DbConn.MyDataReader.Item("TOP_MIK_TOL_N")
                'raporgrd.Sheets(0).Cells(1, 1).Text = "  " & Isaret1 & DbConn.MyDataReader.Item("TOP_MIK_TOL_N") & " / " & Isaret2 & DbConn.MyDataReader.Item("TOP_MIK_TOL_P")
                'Isaret1 = ""
                'Isaret2 = ""
                'txtCapMikTolPoz.Text = DbConn.MyDataReader.Item("CAP_MIK_TOL_P")
                'txtCapMikTolNeg.Text = DbConn.MyDataReader.Item("CAP_MIK_TOL_N")
                'If DbConn.MyDataReader.Item("CAP_MIK_TOL_N") > 0 Then Isaret1 = "+"
                'If DbConn.MyDataReader.Item("CAP_MIK_TOL_P") > 0 Then Isaret2 = "+"
                'raporgrd.Sheets(0).Cells(2, 1).Text = Isaret1 & DbConn.MyDataReader.Item("CAP_MIK_TOL_N") & " / " & Isaret2 & DbConn.MyDataReader.Item("CAP_MIK_TOL_P")

                txtFirma.Text = DbConn.MyDataReader.Item("FIRMA") & ""
                'txtFirma.Text = DbConn.MyDataReader.Item("FIRMA") & ""

                If IsDBNull(DbConn.MyDataReader.Item("FATURALAMA")) Then
                    'ICPIYASA DA FATURALAMA ZORUNLU DEĞİL

                ElseIf DbConn.MyDataReader.Item("FATURALAMA") = "A" Then
                    rdFaturalama.SelectedIndex = 0
                    'rdFaturalamaOnay.SelectedIndex = 0
                    raporgrd.Sheets(0).Cells(6, 1).Text = "  " & "Gerçek"
                ElseIf DbConn.MyDataReader.Item("FATURALAMA") = "T" Then
                    rdFaturalama.SelectedIndex = 1
                    'rdFaturalamaOnay.SelectedIndex = 1
                    raporgrd.Sheets(0).Cells(6, 1).Text = "  " & "Teorik"
                Else
                    rdFaturalama.ClearSelection()
                    ' rdFaturalamaOnay.ClearSelection()
                End If

                txtPaketleme.Text = DbConn.MyDataReader.Item("PAKETLEME")
                raporgrd.Sheets(0).Cells(7, 1).Text = "   " & DbConn.MyDataReader.Item("PAKETLEME")

                txtEtiket.Text = DbConn.MyDataReader.Item("ETIKET")
                raporgrd.Sheets(0).Cells(8, 1).Text = "   " & DbConn.MyDataReader.Item("ETIKET")

                txtGozetim.Text = DbConn.MyDataReader.Item("GOZETIM")
                raporgrd.Sheets(0).Cells(9, 1).Text = "   " & DbConn.MyDataReader.Item("GOZETIM")

                txtOzelSart.Text = DbConn.MyDataReader.Item("OZEL_SARTLAR")
                raporgrd.Sheets(0).Cells(10, 1).Text = "   " & DbConn.MyDataReader.Item("OZEL_SARTLAR")

                drpUlke.Text = DbConn.MyDataReader.Item("ULKE") & ""
                raporgrd.Sheets(0).Cells(11, 1).Text = "   " & DbConn.MyDataReader.Item("ULKE") & ""

                lblEk.Text = DbConn.MyDataReader.Item("DOSYA") & ""

                If lblEk.Text <> "" Then
                    '    btnDokumanIncele.Enabled = True
                Else
                    '   btnDokumanIncele.Enabled = False
                End If
                'Dim hedef = "\\192.168.198.192\Upload\" & lblEk.Text
                'fileEklenecekDosya.FindControl(hedef)
                raporgrd.Sheets(0).Cells(12, 1).Text = DbConn.MyDataReader.Item("DOSYA") & ""



                'Siparis_Sahibi.Items.Add(NullToString(DbConn.MyDataReader.Item("SIPARIS_SAHIBI")) & "")

                varmı = 0
                Try

                    For gg = 0 To Siparis_Sahibi.Items.Count
                        If Siparis_Sahibi.Items.Count <> 0 Then

                            If Siparis_Sahibi.Items(gg).Text =
                            DbConn.MyDataReader.Item("SIPARIS_SAHIBI") Then
                                varmı = 1
                                GoTo son2
                            End If

                        End If


                    Next

                Catch ex As Exception

                End Try

                If varmı = 0 Then
                    Siparis_Sahibi.Items.Add(NullToString(DbConn.MyDataReader.Item("SIPARIS_SAHIBI")) & "")
                End If
son2:

                Siparis_Sahibi.Text = NullToString(DbConn.MyDataReader.Item("SIPARIS_SAHIBI")) & ""
            End While
            DbConn.Kapat()

            GrdAnaliz_Hazırla()

            ALTGRUP_GETIR(gelenSipNo, gelenRevizNo)
            '  SatirKapat()


            'If txtCapMikTolNeg.ForeColor = Drawing.Color.Red Or txtCapMikTolPoz.ForeColor = Drawing.Color.Red Then
            '    raporgrd.Sheets(0).Cells(2, 1).ForeColor = Drawing.Color.Red
            'Else
            '    raporgrd.Sheets(0).Cells(2, 1).ForeColor = Drawing.Color.Black
            'End If
            'If txtTopMikTolPoz.ForeColor = Drawing.Color.Red Or txtTopMikTolNeg.ForeColor = Drawing.Color.Red Then
            '    raporgrd.Sheets(0).Cells(1, 1).ForeColor = Drawing.Color.Red
            'Else
            '    raporgrd.Sheets(0).Cells(1, 1).ForeColor = Drawing.Color.Black
            'End If

            'txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            'txtKayitDurumu.Text = gelenSipNo & " Nolu Sipariş Bilgileri Listelendi"
        Catch ex As Exception
            txtKayitDurumu.BackColor = Drawing.Color.Red
            txtKayitDurumu.Text = gelenSipNo & " Nolu Sipariş Bilgileri Listelenirken HATA oluştu"
        End Try


    End Sub

    Sub ALTGRUP_GETIR(ByVal gelenSipNo As String, ByVal gelenRevizNo As Integer)

        Try

            'FormnoAyar(gelenSipNo, gelenRevizNo)

            Dim EskiDeger
            Dim DbConn As New ConnectGiris
            Dim DbConnEski As New ConnectGiris
            Dim AnaToplam = 0
            EskiDeger = ""
            Dim SQL1, SQL2
            SQL1 = " SELECT * FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO= '" & gelenSipNo & "'" _
                & " AND REVIZ_NO= " & gelenRevizNo

            ' If SIPARISIN_GRUBU = "OZLCLK" Then
            'SQL2 = " ORDER BY (LOT),MAM_TIP,MAM_KALITE,to_number(replace(ebat,'.',',')),to_number(replace(boy,'.',','))"
            'Else
            If SIPARISIN_GRUBU = "KTKTLP" Then
                SQL2 = " ORDER BY (LOT),MAM_TIP,MAM_KALITE,LPAD(EBAT, 10),LPAD(BOY, 10)"
            Else
                SQL2 = " ORDER BY (LOT),MAM_TIP,MAM_KALITE,LPAD(EBAT, 10),LPAD(BOY, 10)"
                'SQL2 = " ORDER BY (LOT),MAM_TIP,MAM_KALITE,to_number(replace(ebat,'.',',')),to_number(replace(boy,'.',','))"
            End If


            SQL = SQL1 & SQL2



            DbConn.RaporWhile(SQL)
            fpEbatMiktar.Sheets(0).RowCount = 0
            fpEbatMiktarOnay.Sheets(0).RowCount = 0
            Dim i = 0


            '********** FORM NUMARASI AYARI*****************************'
            FormnoAyar(SIPARISIN_GRUBU)
            '********** FORM NUMARASI AYARI*****************************'


            While DbConn.MyDataReader.Read
                fpEbatMiktar.Sheets(0).RowCount += 1

                fpEbatMiktar.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.Item("LOT")

                If DbConn.MyDataReader.Item("MAM_TIP") = "K" Then
                    fpEbatMiktar.Sheets(0).Cells(i, 3).Text = "Kangal"
                    drpMamulTip.Text = "Kangal"

                ElseIf DbConn.MyDataReader.Item("MAM_TIP") = "C" Then
                    fpEbatMiktar.Sheets(0).Cells(i, 3).Text = "Çubuk"
                    drpMamulTip.Text = "Çubuk"

                ElseIf DbConn.MyDataReader.Item("MAM_TIP") = "KD" Then
                    fpEbatMiktar.Sheets(0).Cells(i, 3).Text = "Kangal Doğrultma"
                    drpMamulTip.Text = "Kangal Doğrultma"

                ElseIf DbConn.MyDataReader.Item("MAM_TIP") = "KT" Then
                    fpEbatMiktar.Sheets(0).Cells(i, 3).Text = "Kutuk"
                    drpMamulTip.Text = "Kutuk"
                    raporgrd.Sheets(0).Rows(4).Visible = True
                    kutukCapDoldur_Gridli()
                End If

                Siparis_Tipinden_Alan_AcKapat(fpEbatMiktar.Sheets(0).Cells(i, 3).Text)

                If DbConn.MyDataReader.Item("MAM_TIP") = "KT" Then
                    GrdAnaliz.Visible = True

                    analileriGetir(gelenSipNo, gelenRevizNo, DbConn.MyDataReader.Item("LOT"))

                    analizGetirOnayEkrani(gelenSipNo, gelenRevizNo)
                    CHStdKalitebul()
                    kutukCapDoldur()
                    btnAnalizGir.Text = "Analizler"
                    btnAnalizGir.Visible = True
                    fpEbatMiktarOnay.Sheets(0).Columns(5).Visible = False
                    fpEbatMiktarOnay.Sheets(0).Columns(11).Visible = False
                    fpEbatMiktarOnay.Sheets(0).Columns(12).Visible = False
                    fpEbatMiktarOnay.Sheets(0).Columns(13).Visible = True
                    fpEbatMiktarOnay.Sheets(0).Columns(14).Visible = False
                    fpEbatMiktarOnay.Sheets(0).Columns(15).Visible = False

                    'fpEbatMiktarOnay.Sheets(0).Columns(16).Visible = True ' rotor tipi zafer20150703
                    fpEbatMiktarOnay.Sheets(0).Columns(16).Visible = False ' rotor tipi

                    fpEbatMiktarOnay.Sheets(0).Columns(23).Visible = True
                    fpEbatMiktarOnay.Sheets(0).Columns(24).Visible = True
                    fpEbatMiktarOnay.Sheets(0).Columns(25).Visible = True
                    fpEbatMiktarOnay.Sheets(0).Columns(26).Visible = True
                    fpEbatMiktarOnay.Sheets(0).Columns(27).Visible = True




                    fpEbatMiktarOnay.Sheets(0).Columns(18).Visible = False ' 
                    fpEbatMiktarOnay.Sheets(0).Columns(19).Visible = False ' 
                    fpEbatMiktarOnay.Sheets(0).Columns(20).Visible = False ' 

                Else
                    GrdAnaliz.Visible = False

                    PrgKod = SIPARISIN_GRUBU
                    ' burda kullanıcı kodu siparişin kodu ile degiştirdim
                    ' pln ve celal bey için

                    If PrgKod <> "ICPIYS" Then
                        fpEbatMiktarOnay.Sheets(0).Columns(5).Visible = True
                        fpEbatMiktarOnay.Sheets(0).Columns(11).Visible = True
                        fpEbatMiktarOnay.Sheets(0).Columns(12).Visible = True
                        fpEbatMiktarOnay.Sheets(0).Columns(13).Visible = True
                        fpEbatMiktarOnay.Sheets(0).Columns(14).Visible = True
                        fpEbatMiktarOnay.Sheets(0).Columns(15).Visible = True

                        fpEbatMiktarOnay.Sheets(0).Columns(16).Visible = True ' rotor tipi
                    Else
                        fpEbatMiktarOnay.Sheets(0).Columns(5).Visible = True
                        fpEbatMiktarOnay.Sheets(0).Columns(11).Visible = False
                        fpEbatMiktarOnay.Sheets(0).Columns(12).Visible = False
                        fpEbatMiktarOnay.Sheets(0).Columns(13).Visible = False
                        fpEbatMiktarOnay.Sheets(0).Columns(14).Visible = False
                        fpEbatMiktarOnay.Sheets(0).Columns(15).Visible = False
                        fpEbatMiktarOnay.Sheets(0).Columns(16).Visible = False ' rotor tipi

                    End If




                    If PrgKod = "OZLCLK" Or PrgKod = "KTKTLP" Then
                        If drpMamulTip.Text <> "Kutuk" Then fpEbatMiktarOnay.Sheets(0).Columns(18).Visible = True ' 
                        If drpMamulTip.Text <> "Kutuk" Then fpEbatMiktarOnay.Sheets(0).Columns(19).Visible = True ' 
                        If drpMamulTip.Text <> "Kutuk" Then fpEbatMiktarOnay.Sheets(0).Columns(20).Visible = True ' 

                        fpEbatMiktarOnay.Sheets(0).Columns(6).Visible = False 'boy
                        fpEbatMiktarOnay.Sheets(0).Columns(11).Visible = False 'cubuk sayısı
                        fpEbatMiktarOnay.Sheets(0).Columns(12).Visible = False 'birim ağırlık

                        fpEbatMiktarOnay.Sheets(0).Columns(14).Visible = False 'Hadde tol n
                        fpEbatMiktarOnay.Sheets(0).Columns(15).Visible = False 'Hadde tol 9



                    Else



                        fpEbatMiktarOnay.Sheets(0).Columns(11).Visible = True 'cubuk sayısı
                        fpEbatMiktarOnay.Sheets(0).Columns(12).Visible = True 'birim ağırlık
                        fpEbatMiktarOnay.Sheets(0).Columns(14).Visible = True 'Hadde tol n
                        fpEbatMiktarOnay.Sheets(0).Columns(15).Visible = True 'Hadde tol 9
                        fpEbatMiktarOnay.Sheets(0).Columns(6).Visible = True 'boy

                        fpEbatMiktarOnay.Sheets(0).Columns(18).Visible = False ' 
                        fpEbatMiktarOnay.Sheets(0).Columns(19).Visible = False ' 
                        fpEbatMiktarOnay.Sheets(0).Columns(20).Visible = False ' 


                        '   fpEbatMiktar.Sheets(0).Columns(12).Visible = True
                        '    fpEbatMiktar.Sheets(0).Columns(11).Visible = True

                    End If



                    fpEbatMiktarOnay.Sheets(0).Columns(23).Visible = False
                    fpEbatMiktarOnay.Sheets(0).Columns(24).Visible = False
                    fpEbatMiktarOnay.Sheets(0).Columns(25).Visible = False
                    fpEbatMiktarOnay.Sheets(0).Columns(26).Visible = False
                    fpEbatMiktarOnay.Sheets(0).Columns(27).Visible = False
                    spreadCapDoldur()
                    spreadBoyDoldur()
                    btnAnalizGir.Visible = False
                End If


                If PrgKod = "ICPIYS" Then

                    lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş İÇ PİYASA SİPARİŞ BİLDİRİM FORMU"



                    raporgrd.Sheets(0).Rows(0).Visible = True
                    raporgrd.Sheets(0).Rows(1).Visible = False
                    raporgrd.Sheets(0).Rows(2).Visible = False
                    raporgrd.Sheets(0).Rows(3).Visible = False
                    raporgrd.Sheets(0).Rows(4).Visible = False
                    raporgrd.Sheets(0).Rows(5).Visible = True
                    raporgrd.Sheets(0).Rows(6).Visible = False
                    raporgrd.Sheets(0).Rows(7).Visible = False
                    raporgrd.Sheets(0).Rows(8).Visible = False
                    raporgrd.Sheets(0).Rows(9).Visible = False
                    raporgrd.Sheets(0).Rows(10).Visible = True
                    raporgrd.Sheets(0).Rows(11).Visible = False
                    raporgrd.Sheets(0).Rows(12).Visible = False
                    raporgrd.Sheets(0).Rows(13).Visible = False
                    raporgrd.Sheets(0).Rows(14).Visible = False


                    myDiv.Visible = True


                Else


                    If SIPARISIN_GRUBU = "OZLCLK" Then
                        lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş TEL ÇUBUK HH SİPARİŞ BİLDİRİM FORMU"
                        IhrKaySip_Yeni.Enabled = False


                    End If
                    If SIPARISIN_GRUBU = "DISTIC" Then
                        lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş DIŞ PİYASA SİPARİŞ BİLDİRİM FORMU"


                    End If
                    If SIPARISIN_GRUBU = "ICPIYS" Then
                        lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş İÇ PİYASA SİPARİŞ BİLDİRİM FORMU"


                    End If

                    If PrgKod = "OZLCLK" Or (PrgKod = "KTKTLP" And drpMamulTip.Text <> "Kutuk") Then
                        raporgrd.Sheets(0).Rows(0).Visible = True
                        raporgrd.Sheets(0).Rows(1).Visible = False
                        raporgrd.Sheets(0).Rows(2).Visible = False
                        raporgrd.Sheets(0).Rows(3).Visible = False

                        raporgrd.Sheets(0).Rows(5).Visible = True
                        raporgrd.Sheets(0).Rows(6).Visible = True
                        raporgrd.Sheets(0).Rows(7).Visible = False
                        raporgrd.Sheets(0).Rows(8).Visible = False
                        raporgrd.Sheets(0).Rows(9).Visible = False
                        raporgrd.Sheets(0).Rows(10).Visible = True
                        raporgrd.Sheets(0).Rows(11).Visible = True
                        raporgrd.Sheets(0).Rows(12).Visible = True
                        raporgrd.Sheets(0).Rows(13).Visible = True
                        raporgrd.Sheets(0).Rows(14).Visible = True
                    Else
                        raporgrd.Sheets(0).Rows(0).Visible = True
                        raporgrd.Sheets(0).Rows(1).Visible = True
                        raporgrd.Sheets(0).Rows(2).Visible = True
                        raporgrd.Sheets(0).Rows(3).Visible = True

                        raporgrd.Sheets(0).Rows(5).Visible = True
                        raporgrd.Sheets(0).Rows(6).Visible = True
                        raporgrd.Sheets(0).Rows(7).Visible = True
                        raporgrd.Sheets(0).Rows(8).Visible = True
                        raporgrd.Sheets(0).Rows(9).Visible = True
                        raporgrd.Sheets(0).Rows(10).Visible = True
                        raporgrd.Sheets(0).Rows(11).Visible = True
                        raporgrd.Sheets(0).Rows(12).Visible = True
                        raporgrd.Sheets(0).Rows(13).Visible = True
                        raporgrd.Sheets(0).Rows(14).Visible = True
                    End If



                End If

                fpEbatMiktar.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.Item("MAM_STANDART") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 5).Text = DbConn.MyDataReader.Item("MAM_KALITE") & ""

                fpEbatMiktar.Sheets(0).Cells(i, 5).Column.Width = 100

                fpEbatMiktar.Sheets(0).Cells(i, 6).Text = DbConn.MyDataReader.Item("EBAT") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 7).Text = DbConn.MyDataReader.Item("ND") & ""
                If Not IsDBNull(DbConn.MyDataReader.Item("BOY")) Then
                    If DbConn.MyDataReader.Item("BOY") = "999" Then
                        fpEbatMiktar.Sheets(0).Cells(i, 8).Text = "FİRKETE"
                    Else
                        fpEbatMiktar.Sheets(0).Cells(i, 8).Text = DbConn.MyDataReader.Item("BOY") & ""
                    End If
                End If

                fpEbatMiktar.Sheets(0).Cells(i, 9).Text = DbConn.MyDataReader.Item("BOY_TOL_N") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 10).Text = DbConn.MyDataReader.Item("BOY_TOL_P") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 11).Text = DbConn.MyDataReader.Item("MIKTAR") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 12).Text = DbConn.MyDataReader.Item("CUBUK_SAY") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 13).Text = DbConn.MyDataReader.Item("BRM_AGIRLIK_KG") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 14).Text = DbConn.MyDataReader.Item("PAKET_AGIRLIK") & ""

                fpEbatMiktar.Sheets(0).Cells(i, 15).Text = NullToString(DbConn.MyDataReader.Item("HADDE_TOL_N"))
                fpEbatMiktar.Sheets(0).Cells(i, 16).Text = NullToString(DbConn.MyDataReader.Item("HADDE_TOL_P"))

                If DbConn.MyDataReader.Item("ROTOR_TIP") = "BR" Then
                    fpEbatMiktar.Sheets(0).Cells(i, 17).Text = "Büyük Rotor"
                ElseIf DbConn.MyDataReader.Item("ROTOR_TIP") = "KR" Then
                    fpEbatMiktar.Sheets(0).Cells(i, 17).Text = "Küçük Rotor"
                ElseIf DbConn.MyDataReader.Item("ROTOR_TIP") = "0" Then
                    fpEbatMiktar.Sheets(0).Cells(i, 17).Text = ""
                End If

                ' UrunAgacıEkle(DbConn.MyDataReader.Item("URUN_BILGI"))
                fpEbatMiktar.Sheets(0).Cells(i, 18).Text = DbConn.MyDataReader.Item("URUN_BILGI") & ""

                fpEbatMiktar.Sheets(0).Cells(i, 19).Text = DbConn.MyDataReader.Item("KUTUK_MENSEI") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 20).Text = DbConn.MyDataReader.Item("KUTUK_KALITE") & ""

                If PrgKod <> "ICPIYS" Then
                    TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BAS_TAR"))
                    fpEbatMiktar.Sheets(0).Cells(i, 21).Text = DonenTersTarih
                    TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BIT_TAR"))
                    fpEbatMiktar.Sheets(0).Cells(i, 22).Text = DonenTersTarih
                End If
                If Not IsDBNull(DbConn.MyDataReader.Item("TERMIN_BAS_TAR")) Then
                    TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BAS_TAR"))
                    fpEbatMiktar.Sheets(0).Cells(i, 21).Text = DonenTersTarih
                End If
                If Not IsDBNull(DbConn.MyDataReader.Item("TERMIN_BIT_TAR")) Then
                    TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BIT_TAR"))
                    fpEbatMiktar.Sheets(0).Cells(i, 22).Text = DonenTersTarih
                End If

                fpEbatMiktar.Sheets(0).Cells(i, 23).Text = DbConn.MyDataReader.Item("BOSALTMA_LIMAN") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 23).Column.Width = 100
                fpEbatMiktar.Sheets(0).Cells(i, 24).Text = DbConn.MyDataReader.Item("BOYAMA") & ""

                fpEbatMiktar.Sheets(0).Cells(i, 25).Text = DbConn.MyDataReader.Item("KOSERADYUS") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 26).Text = DbConn.MyDataReader.Item("ROMBIKLIK") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 27).Text = DbConn.MyDataReader.Item("DOGSAPMA") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 28).Text = DbConn.MyDataReader.Item("BURULMA") & ""
                fpEbatMiktar.Sheets(0).Cells(i, 29).Text = DbConn.MyDataReader.Item("KESMESEKLI") & ""

                fpEbatMiktar.Sheets(0).Cells(i, 30).Text = DbConn.MyDataReader.Item("EBAT_TOL_N").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktar.Sheets(0).Cells(i, 31).Text = DbConn.MyDataReader.Item("EBAT_TOL_P").ToString.Replace(".", ",").Trim & ""

                fpEbatMiktar.Sheets(0).Cells(i, 32).Text = DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktar.Sheets(0).Cells(i, 33).Text = DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktar.Sheets(0).Cells(i, 34).Text = DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktar.Sheets(0).Cells(i, 35).Text = DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX").ToString.Replace(".", ",").Trim & ""

                fpEbatMiktar.Sheets(0).Cells(i, 36).Text = DbConn.MyDataReader.Item("MUSTERIADI") & ""


                fpEbatMiktarOnay.Sheets(0).RowCount += 1
                fpEbatMiktarOnay.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("LOT")
                fpEbatMiktarOnay.Sheets(0).Cells(i, 2).Text = "" & DbConn.MyDataReader.Item("MAM_STANDART") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 3).Text = "" & DbConn.MyDataReader.Item("MAM_KALITE") & ""


                If DbConn.MyDataReader.Item("MAM_TIP") = "K" Then
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 1).Text = "Kangal"
                ElseIf DbConn.MyDataReader.Item("MAM_TIP") = "C" Then
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 1).Text = "Çubuk"
                ElseIf DbConn.MyDataReader.Item("MAM_TIP") = "KD" Then
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 1).Text = "Kangal Doğrultma"
                ElseIf DbConn.MyDataReader.Item("MAM_TIP") = "KT" Then
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 1).Text = "Kutuk"
                End If

                fpEbatMiktarOnay.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.Item("EBAT") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 5).Text = DbConn.MyDataReader.Item("ND") & ""

                If Not IsDBNull(DbConn.MyDataReader.Item("BOY")) Then
                    If DbConn.MyDataReader.Item("BOY") = "999" Then
                        fpEbatMiktarOnay.Sheets(0).Cells(i, 6).Text = "FİRKETE"
                    Else
                        fpEbatMiktarOnay.Sheets(0).Cells(i, 6).Text = DbConn.MyDataReader.Item("BOY") & ""
                    End If
                End If

                'fpEbatMiktarOnay.Sheets(0).Cells(i, 6).Text = DbConn.MyDataReader.Item("BOY") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 7).Text = DbConn.MyDataReader.Item("BOY_TOL_N").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 8).Text = DbConn.MyDataReader.Item("BOY_TOL_P").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 9).Text = DbConn.MyDataReader.Item("MIKTAR")
                fpEbatMiktarOnay.Sheets(0).Cells(i, 10).Text = DbConn.MyDataReader.Item("BOYAMA") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 11).Text = DbConn.MyDataReader.Item("CUBUK_SAY") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 12).Text = DbConn.MyDataReader.Item("BRM_AGIRLIK_KG") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 13).Text = DbConn.MyDataReader.Item("PAKET_AGIRLIK") & ""

                fpEbatMiktarOnay.Sheets(0).Cells(i, 14).Text = DbConn.MyDataReader.Item("HADDE_TOL_N").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 15).Text = DbConn.MyDataReader.Item("HADDE_TOL_P").ToString.Replace(".", ",").Trim & ""

                'fpEbatMiktarOnay.Sheets(0).Cells(i, 16).Text = DbConn.MyDataReader.Item("MARKA") & ""
                If DbConn.MyDataReader.Item("ROTOR_TIP") = "BR" Then
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 16).Text = "Büyük Rotor"
                ElseIf DbConn.MyDataReader.Item("ROTOR_TIP") = "KR" Then
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 16).Text = "Küçük Rotor"
                ElseIf DbConn.MyDataReader.Item("ROTOR_TIP") = "0" Then
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 16).Text = ""
                End If
                fpEbatMiktarOnay.Sheets(0).Cells(i, 17).Text = DbConn.MyDataReader.Item("BOSALTMA_LIMAN") & ""

                KALITESINIFACK_EKLENECEK = ""
                UrunAgacıEkle(DbConn.MyDataReader.Item("URUN_BILGI"))
                fpEbatMiktarOnay.Sheets(0).Cells(i, 18).Text = KALITESINIFACK_EKLENECEK 'DbConn.MyDataReader.Item("URUN_BILGI") & ""

                fpEbatMiktarOnay.Sheets(0).Cells(i, 19).Text = DbConn.MyDataReader.Item("KUTUK_MENSEI") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 20).Text = DbConn.MyDataReader.Item("KUTUK_KALITE") & ""

                If PrgKod <> "ICPIYS" Then
                    TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BAS_TAR"))
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 21).Text = DonenTersTarih
                    TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BIT_TAR"))
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 22).Text = DonenTersTarih
                End If
                If Not IsDBNull(DbConn.MyDataReader.Item("TERMIN_BAS_TAR")) Then
                    TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BAS_TAR"))
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 21).Text = DonenTersTarih
                End If
                If Not IsDBNull(DbConn.MyDataReader.Item("TERMIN_BIT_TAR")) Then
                    TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BIT_TAR"))
                    fpEbatMiktarOnay.Sheets(0).Cells(i, 22).Text = DonenTersTarih
                End If

                'TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BAS_TAR"))
                'fpEbatMiktar.Sheets(0).Cells(i, 22).Text = DonenTersTarih
                'TERSCEVIR(DbConn.MyDataReader.Item("TERMIN_BIT_TAR"))
                'fpEbatMiktar.Sheets(0).Cells(i, 23).Text = DonenTersTarih

                fpEbatMiktarOnay.Sheets(0).Cells(i, 23).Text = DbConn.MyDataReader.Item("KOSERADYUS") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 24).Text = DbConn.MyDataReader.Item("ROMBIKLIK") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 25).Text = DbConn.MyDataReader.Item("DOGSAPMA") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 26).Text = DbConn.MyDataReader.Item("BURULMA") & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 27).Text = DbConn.MyDataReader.Item("KESMESEKLI") & ""

                fpEbatMiktarOnay.Sheets(0).Cells(i, 28).Text = DbConn.MyDataReader.Item("EBAT_TOL_N").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 29).Text = DbConn.MyDataReader.Item("EBAT_TOL_P").ToString.Replace(".", ",").Trim & ""

                fpEbatMiktarOnay.Sheets(0).Cells(i, 30).Text = DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 31).Text = DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 32).Text = DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 33).Text = DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX").ToString.Replace(".", ",").Trim & ""
                fpEbatMiktarOnay.Sheets(0).Cells(i, 34).Text = DbConn.MyDataReader.Item("MUSTERIADI") & ""
                i += 1
            End While
            DbConn.Kapat()

            RevizyonKarsilastirma(gelenRevizNo, gelenSipNo)

            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = gelenSipNo & " Nolu Sipariş Bilgileri Listelendi. Toplam satır sayısı: " & i

            SQL = " SELECT SUM(MIKTAR) TOPLAM FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO= '" & gelenSipNo & "'" _
                & " AND REVIZ_NO= " & gelenRevizNo
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                txtToplamMik.Text = DbConn.MyDataReader.Item("TOPLAM") & ""
                'txtToplamMikOnay.Text = DbConn.MyDataReader.Item("TOPLAM")
                raporgrd.Sheets(0).Cells(0, 1).Text = DbConn.MyDataReader.Item("TOPLAM") & ""
            End While
            DbConn.Kapat()
            fpEbatMiktar.Enabled = True


            '************* SATIR DUZELTMELERI
            'CUBUK, KANGAL VB 2 KOLON
            'Dim TARIHLER

            If fpEbatMiktarOnay.Sheets(0).RowCount > 0 Then
                Dim J, Gelen
                Gelen = fpEbatMiktarOnay.Sheets(0).Cells(0, 1).Text
                For J = 1 To fpEbatMiktarOnay.Sheets(0).RowCount - 1
                    EskiDeger = fpEbatMiktarOnay.Sheets(0).Cells(J, 1).Text
                    If EskiDeger = Gelen Then
                        fpEbatMiktarOnay.Sheets(0).Cells(J, 1).Text = ""
                    Else
                        Gelen = fpEbatMiktarOnay.Sheets(0).Cells(J, 1).Text
                    End If
                Next
            End If

            'raporgrd.Sheets(0).Cells(4, 1).Text = TARIHLER
            Dim TARIHLER As String = ""
            Dim terminBasSayac, terminBitSayac
            Dim dbConnSayac As New ConnectGiris
            SQL = "SELECT COUNT(DISTINCT(TERMIN_BAS_TAR)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            terminBasSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()

            SQL = "SELECT COUNT(DISTINCT(TERMIN_BIT_TAR)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            terminBitSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()

            If terminBasSayac = 1 And terminBitSayac = 1 Then
                SQL = " SELECT LOT,TERMIN_BAS_TAR,TERMIN_BIT_TAR " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,TERMIN_BAS_TAR,TERMIN_BIT_TAR " _
                & " ORDER BY LOT"

                DbConn.RaporWhile(SQL)
                'fpRapor.Sheets(0).Cells(24, 20).Text = ""
                While DbConn.MyDataReader.Read
                    If Not IsDBNull(DbConn.MyDataReader.Item("TERMIN_BAS_TAR")) And Not IsDBNull(DbConn.MyDataReader.Item("TERMIN_BIT_TAR")) Then
                        TARIHLER = DbConn.MyDataReader.Item("TERMIN_BAS_TAR") & " - " & DbConn.MyDataReader.Item("TERMIN_BIT_TAR")
                    End If
                End While
                DbConn.Kapat()
            Else
                SQL = " SELECT LOT,TERMIN_BAS_TAR,TERMIN_BIT_TAR " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,TERMIN_BAS_TAR,TERMIN_BIT_TAR " _
                & " ORDER BY LOT"

                DbConn.RaporWhile(SQL)
                'fpRapor.Sheets(0).Cells(24, 20).Text = ""
                While DbConn.MyDataReader.Read
                    If Not IsDBNull(DbConn.MyDataReader.Item("TERMIN_BAS_TAR")) And Not IsDBNull(DbConn.MyDataReader.Item("TERMIN_BIT_TAR")) Then
                        TARIHLER += " Lot No=" & DbConn.MyDataReader.Item("LOT") & " : " & DbConn.MyDataReader.Item("TERMIN_BAS_TAR") & " - " & DbConn.MyDataReader.Item("TERMIN_BIT_TAR")
                    End If
                End While
                DbConn.Kapat()
            End If
            raporgrd.Sheets(0).Cells(5, 1).Text = TARIHLER

            Dim str As String = ""
            SQL = " SELECT BOY,BOY_TOL_N,BOY_TOL_P FROM MRKSIP_CBK_FLM_ALT" _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY BOY,BOY_TOL_N,BOY_TOL_P"

            DbConn.RaporWhile(SQL)
            'fpRapor.Sheets(0).Cells(24, 20).Text = ""
            Dim BOYU
            While DbConn.MyDataReader.Read
                If Not IsDBNull(DbConn.MyDataReader.Item("BOY")) Then
                    If DbConn.MyDataReader.Item("BOY") <> "0" Then
                        BOYU = DbConn.MyDataReader.Item("BOY")
                        If BOYU = "999" Then
                            BOYU = "FIRKETE"
                        Else
                            BOYU = BOYU
                        End If
                        str += "  " & BOYU & "M(-" & DbConn.MyDataReader.Item("BOY_TOL_N") & " / + " & DbConn.MyDataReader.Item("BOY_TOL_P") & " MM),"
                    End If
                End If
            End While
            raporgrd.Sheets(0).Cells(3, 1).Text = ""
            If Len(str) > 3 Then
                raporgrd.Sheets(0).Cells(3, 1).Text = Mid(str, 1, Len(str) - 1)
            End If
            DbConn.Kapat()

            'EBAT_TOL_N

            '************* SATIR DUZELTMELERI
            ' BOSALTMA LIMANI
            'fpEbatMiktarOnay.Sheets(0).Cells(i, 17).Text = DbConn.MyDataReader.Item("BOSALTMA_LIMAN") & ""
            Dim LIMANLAR = ""
            If fpEbatMiktarOnay.Sheets(0).RowCount > 0 Then
                Dim BosaltmaLimanı, Gelen, J
                Gelen = fpEbatMiktarOnay.Sheets(0).Cells(0, 17).Text
                For J = 1 To fpEbatMiktarOnay.Sheets(0).RowCount - 1
                    BosaltmaLimanı = fpEbatMiktarOnay.Sheets(0).Cells(J, 17).Text
                    If BosaltmaLimanı = Gelen Then
                        fpEbatMiktarOnay.Sheets(0).Cells(J, 17).Text = ""
                    Else
                        Gelen = fpEbatMiktarOnay.Sheets(0).Cells(J, 17).Text
                        BosaltmaLimanı = fpEbatMiktar.Sheets(0).Cells(J, 17).Text
                        'LIMANLAR = LIMANLAR & vbNewLine & BosaltmaLimanı
                    End If
                Next
            End If

            'Boşaltma limanı gruplama işlemi :)
            Dim bosaltmaSayac
            SQL = "SELECT COUNT(DISTINCT(BOSALTMA_LIMAN)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            bosaltmaSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()

            Dim SAYAC
            SAYAC = 1
            If bosaltmaSayac = 1 Then
                SQL = " SELECT LOT,BOSALTMA_LIMAN " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,BOSALTMA_LIMAN " _
                & " HAVING BOSALTMA_LIMAN IS NOT NULL" _
                & " ORDER BY LOT"
                DbConn.RaporWhile(SQL)
                'fpRapor.Sheets(0).Cells(24, 20).Text = ""
                While DbConn.MyDataReader.Read
                    LIMANLAR = DbConn.MyDataReader.Item("BOSALTMA_LIMAN") & ""
                End While
                DbConn.Kapat()
            ElseIf bosaltmaSayac = 0 Then
                LIMANLAR = ""
            Else
                SQL = " SELECT LOT,BOSALTMA_LIMAN " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,BOSALTMA_LIMAN " _
                & " HAVING BOSALTMA_LIMAN IS NOT NULL" _
                & " ORDER BY LOT"
                DbConn.RaporWhile(SQL)
                'fpRapor.Sheets(0).Cells(24, 20).Text = ""
                While DbConn.MyDataReader.Read
                    LIMANLAR += " Lot " & DbConn.MyDataReader.Item("LOT") & ":" & DbConn.MyDataReader.Item("BOSALTMA_LIMAN") & ","
                    SAYAC = SAYAC + 1
                End While
                DbConn.Kapat()
            End If
            If SAYAC > 1 Then
                raporgrd.Sheets(0).Cells(13, 1).Text = Mid(LIMANLAR, 1, Len(LIMANLAR) - 1)
            Else
                raporgrd.Sheets(0).Cells(13, 1).Text = LIMANLAR
            End If




            'MUSTERI ADI REVIZYONLU GETIR

            Dim MusteriAdiEski = ""
            If gelenRevizNo > 0 Then
                Dim MusteriAdiSayacEski
                SQL = "SELECT COUNT(DISTINCT(CAP_MIK_TOL_MIN)) " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'"
                dbConnSayac.Sayac(SQL)
                MusteriAdiSayacEski = dbConnSayac.GeriDonenRakam
                dbConnSayac.Kapat()
                Dim virgulBayragiMusteriEski As Boolean = False
                Dim isaret1Eski = "", isaret2Eski = ""
                If MusteriAdiSayacEski = 1 Then
                    SQL = " SELECT LOT,MUSTERIADI " _
                    & " FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO='" & gelenSipNo & "'" _
                    & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'" _
                    & " GROUP BY LOT,MUSTERIADI " _
                    & " ORDER BY LOT"
                    DbConn.RaporWhile(SQL)
                    While DbConn.MyDataReader.Read
                        If IsDBNull(DbConn.MyDataReader.Item("MUSTERIADI")) Then
                            MusteriAdiEski = "-"
                        Else
                            MusteriAdiEski = DbConn.MyDataReader.Item("MUSTERIADI")
                        End If
                    End While
                    DbConn.Kapat()
                ElseIf MusteriAdiSayacEski = 0 Then
                    'Bu durumun olmaması gerekiyor. Alanlar boş olamaz
                    MusteriAdiEski = ""
                ElseIf MusteriAdiSayacEski > 1 Then
                    SQL = " SELECT LOT,MUSTERIADI " _
                    & " FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO='" & gelenSipNo & "'" _
                    & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'" _
                    & " GROUP BY LOT,MUSTERIADI  " _
                    & " ORDER BY LOT"
                    DbConn.RaporWhile(SQL)
                    While DbConn.MyDataReader.Read
                        MusteriAdiEski += " Lot " & DbConn.MyDataReader.Item("LOT") & ":" & DbConn.MyDataReader.Item("MUSTERIADI") & ","
                        virgulBayragiMusteriEski = True
                    End While
                    DbConn.Kapat()
                End If
                If virgulBayragiMusteriEski Then
                    MusteriAdiEski = Mid(MusteriAdiEski, 1, Len(MusteriAdiEski) - 1)
                End If

            End If


            '******************************************************************
            '**********REVIZYONLU KARSILASTIRMA 

            Dim MusteriAdi = ""
            Dim MusteriAdiSayac
            SQL = "SELECT COUNT(DISTINCT(MUSTERIADI)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            MusteriAdiSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()
            Dim virgulBayragiMusteri As Boolean = False
            If MusteriAdiSayac = 1 Then
                SQL = " SELECT LOT,MUSTERIADI " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,MUSTERIADI " _
                & " ORDER BY LOT"
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    MusteriAdi = DbConn.MyDataReader.Item("MUSTERIADI")
                End While
                DbConn.Kapat()
            ElseIf MusteriAdiSayac = 0 Then
                'Bu durumun olmaması gerekiyor. Alanlar boş olamaz
                MusteriAdi = ""
            ElseIf MusteriAdiSayac > 1 Then
                SQL = " SELECT LOT,MUSTERIADI " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,MUSTERIADI  " _
                & " ORDER BY LOT"
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    MusteriAdi += " Lot " & DbConn.MyDataReader.Item("LOT") & ":" & DbConn.MyDataReader.Item("MUSTERIADI") & ","
                    virgulBayragiMusteri = True
                End While
                DbConn.Kapat()
            End If
            If SIPARISIN_GRUBU = "OZLCLK" Then
                If virgulBayragiMusteri Then
                    raporgrd.Sheets(0).Cells(15, 1).Text = Mid(MusteriAdi, 1, Len(MusteriAdi) - 1)
                Else
                    raporgrd.Sheets(0).Cells(15, 1).Text = MusteriAdi
                End If


                If MusteriAdiEski <> raporgrd.Sheets(0).Cells(15, 1).Text And MusteriAdiEski <> "" Then
                    raporgrd.Sheets(0).Cells(15, 1).ForeColor = Drawing.Color.Red
                Else
                    raporgrd.Sheets(0).Cells(15, 1).ForeColor = Drawing.Color.Black
                End If

            End If


            'Çap_Mik_Tol gruplama işlemi :)



            Dim CapMikToleranslariEski = ""
            If gelenRevizNo > 0 Then
                Dim CapMikTolMinSayacEski
                Dim CapMikTolMaxSayacEski
                SQL = "SELECT COUNT(DISTINCT(CAP_MIK_TOL_MIN)) " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'"
                dbConnSayac.Sayac(SQL)
                CapMikTolMinSayacEski = dbConnSayac.GeriDonenRakam
                dbConnSayac.Kapat()
                SQL = "SELECT COUNT(DISTINCT(CAP_MIK_TOL_MAX)) " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'"
                dbConnSayac.Sayac(SQL)
                CapMikTolMaxSayacEski = dbConnSayac.GeriDonenRakam
                dbConnSayac.Kapat()
                Dim virgulBayragiEski As Boolean = False
                Dim isaret1Eski = "", isaret2Eski = ""
                If CapMikTolMinSayacEski = 1 And CapMikTolMaxSayacEski = 1 Then
                    SQL = " SELECT LOT,CAP_MIK_TOL_MIN,CAP_MIK_TOL_MAX " _
                    & " FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO='" & gelenSipNo & "'" _
                    & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'" _
                    & " GROUP BY LOT,CAP_MIK_TOL_MIN,CAP_MIK_TOL_MAX " _
                    & " ORDER BY LOT"
                    DbConn.RaporWhile(SQL)
                    While DbConn.MyDataReader.Read
                        If DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN") > 0 Then isaret1Eski = "+"
                        If DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX") > 0 Then isaret2Eski = "+"
                        CapMikToleranslariEski = isaret1Eski & DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN") & "/" & isaret2Eski & DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX")
                    End While
                    DbConn.Kapat()
                ElseIf CapMikTolMinSayacEski = 0 And CapMikTolMaxSayacEski = 0 Then
                    'Bu durumun olmaması gerekiyor. Alanlar boş olamaz
                    CapMikToleranslariEski = ""
                ElseIf CapMikTolMinSayacEski > 1 Or CapMikTolMaxSayacEski > 1 Then
                    SQL = " SELECT LOT,CAP_MIK_TOL_MIN,CAP_MIK_TOL_MAX " _
                    & " FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO='" & gelenSipNo & "'" _
                    & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'" _
                    & " GROUP BY LOT,CAP_MIK_TOL_MIN,CAP_MIK_TOL_MAX  " _
                    & " ORDER BY LOT"
                    DbConn.RaporWhile(SQL)
                    While DbConn.MyDataReader.Read
                        If DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN") > 0 Then isaret1Eski = "+"
                        If DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX") > 0 Then isaret2Eski = "+"
                        CapMikToleranslariEski += " Lot " & DbConn.MyDataReader.Item("LOT") & ":" & isaret1Eski & DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN") & "/" & isaret2Eski & DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX") & ","
                        'CapMikToleranslari += " Lot" & DbConn.MyDataReader.Item("LOT") & ":" & DbConn.MyDataReader.Item("BOSALTMA_LIMAN") & ","
                        virgulBayragiEski = True
                    End While
                    DbConn.Kapat()
                End If
                If virgulBayragiEski Then
                    CapMikToleranslariEski = Mid(CapMikToleranslariEski, 1, Len(CapMikToleranslariEski) - 1)
                    'Else
                    '    CapMikToleranslariEski = CapMikToleranslariEski
                End If

            End If



            '******************************************************************
            '**********REVIZYONLU KARSILASTIRMA 

            Dim CapMikToleranslari = ""
            Dim CapMikTolMinSayac
            Dim CapMikTolMaxSayac
            SQL = "SELECT COUNT(DISTINCT(CAP_MIK_TOL_MIN)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            CapMikTolMinSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()

            SQL = "SELECT COUNT(DISTINCT(CAP_MIK_TOL_MAX)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            CapMikTolMaxSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()
            Dim virgulBayragi As Boolean = False
            Dim isaret1 = "", isaret2 = ""

            If CapMikTolMinSayac = 1 And CapMikTolMaxSayac = 1 Then
                SQL = " SELECT LOT,CAP_MIK_TOL_MIN,CAP_MIK_TOL_MAX " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,CAP_MIK_TOL_MIN,CAP_MIK_TOL_MAX " _
                & " ORDER BY LOT"
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    If DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN") > 0 Then isaret1 = "+"
                    If DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX") > 0 Then isaret2 = "+"
                    CapMikToleranslari = isaret1 & DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN") & "/" & isaret2 & DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX")
                End While
                DbConn.Kapat()
            ElseIf CapMikTolMinSayac = 0 And CapMikTolMaxSayac = 0 Then
                'Bu durumun olmaması gerekiyor. Alanlar boş olamaz
                CapMikToleranslari = ""
            ElseIf CapMikTolMinSayac > 1 Or CapMikTolMaxSayac > 1 Then
                SQL = " SELECT LOT,CAP_MIK_TOL_MIN,CAP_MIK_TOL_MAX " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,CAP_MIK_TOL_MIN,CAP_MIK_TOL_MAX  " _
                & " ORDER BY LOT"
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    If DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN") > 0 Then isaret1 = "+"
                    If DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX") > 0 Then isaret2 = "+"
                    CapMikToleranslari += " Lot " & DbConn.MyDataReader.Item("LOT") & ":" & isaret1 & DbConn.MyDataReader.Item("CAP_MIK_TOL_MIN") & "/" & isaret2 & DbConn.MyDataReader.Item("CAP_MIK_TOL_MAX") & ","
                    'CapMikToleranslari += " Lot" & DbConn.MyDataReader.Item("LOT") & ":" & DbConn.MyDataReader.Item("BOSALTMA_LIMAN") & ","
                    virgulBayragi = True
                End While
                DbConn.Kapat()
            End If
            If virgulBayragi Then
                raporgrd.Sheets(0).Cells(2, 1).Text = Mid(CapMikToleranslari, 1, Len(CapMikToleranslari) - 1)
            Else
                raporgrd.Sheets(0).Cells(2, 1).Text = CapMikToleranslari
            End If

            If CapMikToleranslariEski <> raporgrd.Sheets(0).Cells(2, 1).Text And CapMikToleranslariEski <> "" Then
                raporgrd.Sheets(0).Cells(2, 1).ForeColor = Drawing.Color.Red
            Else
                raporgrd.Sheets(0).Cells(2, 1).ForeColor = Drawing.Color.Black
            End If


            'Top_Mik_Tol gruplama işlemi :)
            '****************************
            Dim TopMikToleranslariEski = ""
            If gelenRevizNo > 0 Then
                Dim TopMikTolMinSayacEski
                Dim TopMikTolMaxSayacEski
                SQL = "SELECT COUNT(DISTINCT(TOP_MIK_TOL_MIN)) " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'"
                dbConnSayac.Sayac(SQL)
                TopMikTolMinSayacEski = dbConnSayac.GeriDonenRakam
                dbConnSayac.Kapat()
                SQL = "SELECT COUNT(DISTINCT(TOP_MIK_TOL_MAX)) " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'"
                dbConnSayac.Sayac(SQL)
                TopMikTolMaxSayacEski = dbConnSayac.GeriDonenRakam
                dbConnSayac.Kapat()
                virgulBayragi = False
                Dim isaret1Eski = ""
                Dim isaret2Eski = ""
                If TopMikTolMinSayacEski = 1 And TopMikTolMaxSayacEski = 1 Then
                    SQL = " SELECT LOT,TOP_MIK_TOL_MIN,TOP_MIK_TOL_MAX " _
                    & " FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO='" & gelenSipNo & "'" _
                    & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'" _
                    & " GROUP BY LOT,TOP_MIK_TOL_MIN,TOP_MIK_TOL_MAX " _
                    & " ORDER BY LOT"
                    DbConn.RaporWhile(SQL)
                    While DbConn.MyDataReader.Read
                        If DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN") > 0 Then isaret1Eski = "+"
                        If DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX") > 0 Then isaret2Eski = "+"
                        TopMikToleranslariEski = isaret1Eski & DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN") & "/" & isaret2Eski & DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX")
                    End While
                    DbConn.Kapat()
                ElseIf TopMikTolMinSayacEski = 0 And TopMikTolMaxSayacEski = 0 Then
                    'Bu durumun olmaması gerekiyor. Alanlar boş olamaz
                    TopMikToleranslariEski = ""
                ElseIf TopMikTolMinSayacEski > 1 Or TopMikTolMaxSayacEski > 1 Then
                    SQL = " SELECT LOT,TOP_MIK_TOL_MIN,TOP_MIK_TOL_MAX " _
                    & " FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO='" & gelenSipNo & "'" _
                    & " AND REVIZ_NO='" & gelenRevizNo - 1 & "'" _
                    & " GROUP BY LOT,TOP_MIK_TOL_MIN,TOP_MIK_TOL_MAX  " _
                    & " ORDER BY LOT"
                    DbConn.RaporWhile(SQL)
                    While DbConn.MyDataReader.Read
                        If DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN") > 0 Then isaret1Eski = "+"
                        If DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX") > 0 Then isaret2Eski = "+"
                        TopMikToleranslariEski += " Lot " & DbConn.MyDataReader.Item("LOT") & ":" & isaret1Eski & DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN") & "/" & isaret2Eski & DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX") & ","
                        virgulBayragi = True
                    End While
                    DbConn.Kapat()
                End If
                If virgulBayragi Then
                    TopMikToleranslariEski = Mid(TopMikToleranslariEski, 1, Len(TopMikToleranslariEski) - 1)
                    'Else
                    '    TopMikToleranslariEski = TopMikToleranslariEski
                End If
            End If

            Dim TopMikToleranslari = ""
            Dim TopMikTolMinSayac
            Dim TopMikTolMaxSayac
            SQL = "SELECT COUNT(DISTINCT(TOP_MIK_TOL_MIN)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            TopMikTolMinSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()
            SQL = "SELECT COUNT(DISTINCT(TOP_MIK_TOL_MAX)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            TopMikTolMaxSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()
            virgulBayragi = False
            isaret1 = ""
            isaret2 = ""
            If TopMikTolMinSayac = 1 And TopMikTolMaxSayac = 1 Then
                SQL = " SELECT LOT,TOP_MIK_TOL_MIN,TOP_MIK_TOL_MAX " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,TOP_MIK_TOL_MIN,TOP_MIK_TOL_MAX " _
                & " ORDER BY LOT"
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    If DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN") > 0 Then isaret1 = "+"
                    If DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX") > 0 Then isaret2 = "+"
                    TopMikToleranslari = isaret1 & DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN") & "/" & isaret2 & DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX")
                End While
                DbConn.Kapat()
            ElseIf TopMikTolMinSayac = 0 And TopMikTolMaxSayac = 0 Then
                'Bu durumun olmaması gerekiyor. Alanlar boş olamaz
                TopMikToleranslari = ""
            ElseIf TopMikTolMinSayac > 1 Or TopMikTolMaxSayac > 1 Then
                SQL = " SELECT LOT,TOP_MIK_TOL_MIN,TOP_MIK_TOL_MAX " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,TOP_MIK_TOL_MIN,TOP_MIK_TOL_MAX  " _
                & " ORDER BY LOT"
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    If DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN") > 0 Then isaret1 = "+"
                    If DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX") > 0 Then isaret2 = "+"
                    TopMikToleranslari += " Lot " & DbConn.MyDataReader.Item("LOT") & ":" & isaret1 & DbConn.MyDataReader.Item("TOP_MIK_TOL_MIN") & "/" & isaret2 & DbConn.MyDataReader.Item("TOP_MIK_TOL_MAX") & ","
                    virgulBayragi = True
                End While
                DbConn.Kapat()
            End If
            If virgulBayragi Then
                raporgrd.Sheets(0).Cells(1, 1).Text = Mid(TopMikToleranslari, 1, Len(TopMikToleranslari) - 1)
            Else
                raporgrd.Sheets(0).Cells(1, 1).Text = TopMikToleranslari
            End If
            If TopMikToleranslariEski <> raporgrd.Sheets(0).Cells(1, 1).Text And TopMikToleranslariEski <> "" Then
                raporgrd.Sheets(0).Cells(1, 1).ForeColor = Drawing.Color.Red
            Else
                raporgrd.Sheets(0).Cells(1, 1).ForeColor = Drawing.Color.Black
            End If

            'Boyama gruplama işlemi
            Dim boyamaSayac, BOYAMALAR

            SQL = "SELECT COUNT(DISTINCT(BOYAMA)) " _
            & " FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevizNo & "'"
            dbConnSayac.Sayac(SQL)
            boyamaSayac = dbConnSayac.GeriDonenRakam
            dbConnSayac.Kapat()

            If boyamaSayac = 1 Then
                SQL = " SELECT LOT,EBAT,BOYAMA " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,EBAT,BOYAMA " _
                & " ORDER BY LOT"

                DbConn.RaporWhile(SQL)
                'fpRapor.Sheets(0).Cells(24, 20).Text = ""
                While DbConn.MyDataReader.Read
                    BOYAMALAR = DbConn.MyDataReader.Item("BOYAMA")
                End While
                DbConn.Kapat()
            Else
                SQL = " SELECT LOT,EBAT,BOYAMA " _
                & " FROM MRKSIP_CBK_FLM_ALT " _
                & " WHERE SIP_NO='" & gelenSipNo & "'" _
                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                & " GROUP BY LOT,EBAT,BOYAMA " _
                & " ORDER BY LOT"

                DbConn.RaporWhile(SQL)
                'fpRapor.Sheets(0).Cells(24, 20).Text = ""
                While DbConn.MyDataReader.Read
                    BOYAMALAR += DbConn.MyDataReader.Item("LOT") & "/" & DbConn.MyDataReader.Item("EBAT") & " - " & DbConn.MyDataReader.Item("BOYAMA") & ", "
                End While

                DbConn.Kapat()
            End If
            If Right(Trim(BOYAMALAR), 1) = "," Then
                BOYAMALAR = Mid(Trim(BOYAMALAR), 1, Len(Trim(BOYAMALAR)) - 1)
            Else
                BOYAMALAR = BOYAMALAR
            End If

            raporgrd.Sheets(0).Cells(14, 1).Text = BOYAMALAR

            If fpEbatMiktar.Sheets(0).RowCount > 0 Then
                If fpEbatMiktar.Sheets(0).Cells(0, 3).Text = "Kutuk" Or fpEbatMiktar.Sheets(0).Cells(0, 3).Text = "Kangal" Then
                    Dim EbatToleranslari = ""
                    Try
                        Dim HEPSI_SIFIRMI

                        SQL = " SELECT COUNT(EBAT) FROM MRKSIP_CBK_FLM_ALT" _
                            & " WHERE SIP_NO ='" & gelenSipNo & "'" _
                            & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                            & " AND (EBAT_TOL_N <> 0 or EBAT_TOL_P <> 0)"

                        DbConn.Sayac(SQL)
                        'fpRapor.Sheets(0).Cells(24, 20).Text = ""
                        HEPSI_SIFIRMI = DbConn.GeriDonenRakam
                        DbConn.Kapat()



                        If HEPSI_SIFIRMI <> 0 Then

                            SQL = " SELECT EBAT,EBAT_TOL_N,EBAT_TOL_P FROM MRKSIP_CBK_FLM_ALT" _
                                & " WHERE SIP_NO ='" & gelenSipNo & "'" _
                                & " AND REVIZ_NO='" & gelenRevizNo & "'" _
                                & " GROUP BY EBAT,EBAT_TOL_N,EBAT_TOL_P"
                            DbConn.RaporWhile(SQL)
                            'fpRapor.Sheets(0).Cells(24, 20).Text = ""
                            While DbConn.MyDataReader.Read
                                EbatToleranslari += DbConn.MyDataReader.Item("EBAT") & "MM(-" & DbConn.MyDataReader.Item("EBAT_TOL_N") & " / +" & DbConn.MyDataReader.Item("EBAT_TOL_P") & "MM), "
                            End While
                            If Len(EbatToleranslari) > 3 Then
                                raporgrd.Sheets(0).Cells(4, 1).Text = Mid(EbatToleranslari, 1, Len(EbatToleranslari) - 2)
                            End If
                            DbConn.Kapat()
                        Else
                            EbatToleranslari = "-"
                            raporgrd.Sheets(0).Cells(4, 1).Text = EbatToleranslari
                        End If


                    Catch ex As Exception
                        txtKayitDurumu.BackColor = Drawing.Color.Red
                        txtKayitDurumu.Text = gelenSipNo & " Nolu siparişin Ebat Toleransları gruplarınırken hata oluştu!"
                    End Try
                Else

                End If
            End If



            If PrgKod = "OZLCLK" Then
                Dim BAK
                For index As Integer = 0 To UrunAgacListesi.Count - 1
                    KALITESINIFACK = KALITESINIFACK & "  ;  " & UrunAgacListesi(index)
                Next

                raporgrd.ActiveSheetView.AddSpanCell(16, 0, 1, 2)
                raporgrd.Sheets(0).Cells(16, 0).Font.Size = 11
                raporgrd.Sheets(0).Cells(16, 0).Font.Bold = True
                '   raporgrd.Sheets(0).Cells(16, 0).ForeColor = System.Drawing.Color.FromKnownColor("#0000CC")


                raporgrd.Sheets(0).Cells(16, 0).Text = "Ürün Kodları " & KALITESINIFACK

            End If




            For i = 0 To fpEbatMiktar.Sheets(0).Columns.Count - 1
                fpEbatMiktar.Sheets(0).ColumnHeader.Columns(i).Font.Size = 7
            Next

            For i = 0 To fpEbatMiktar.Sheets(0).Columns.Count - 1
                fpEbatMiktar.Sheets(0).Columns(i).Font.Size = 8
            Next
            fpEbatMiktar.Sheets(0).Columns(21).Font.Size = 7
            fpEbatMiktar.Sheets(0).Columns(22).Font.Size = 7
            fpEbatMiktar.Sheets(0).Columns(23).Font.Size = 7

        Catch ex As Exception
            txtKayitDurumu.BackColor = Drawing.Color.Red
            txtKayitDurumu.Text = ex.ToString
        End Try

    End Sub
    Private Sub FormnoAyar(SIPARISIN_GRUBU As String)

        If SIPARISIN_GRUBU = "OZLCLK" Or SIPARISIN_GRUBU = "KTKTLP" Then
            raporgrd.Sheets(0).RowCount = 18
            lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş TEL ÇUBUK HH SİPARİŞ BİLDİRİM FORMU"
            IhrKaySip_Yeni.Enabled = False
            raporgrd.Sheets(0).Cells(17, 0).Text = "Form No: 05.10.1-5/R-1"
            raporgrd.Sheets(0).Cells(17, 0).Font.Size = 11
            raporgrd.Sheets(0).Cells(17, 0).Font.Bold = True
            raporgrd.Sheets(0).Cells(17, 0).ForeColor = Drawing.Color.Blue


            raporgrd.Sheets(0).Rows(15).Visible = True ' FIRMA BILGISI

            raporgrd.Sheets(0).Cells(15, 0).Text = "Firma"

            raporgrd.Sheets(0).Rows(4).Visible = True

        End If
        If SIPARISIN_GRUBU = "DISTIC" Then
            raporgrd.Sheets(0).RowCount = 16
            lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş DIŞ PİYASA SİPARİŞ BİLDİRİM FORMU"
            raporgrd.Sheets(0).Cells(15, 0).Text = "Form No: 05.10.1-2/R-3"
            raporgrd.Sheets(0).Cells(15, 0).Font.Size = 11
            raporgrd.Sheets(0).Cells(15, 0).Font.Bold = True
            raporgrd.Sheets(0).Cells(15, 0).ForeColor = Drawing.Color.Blue



            raporgrd.Sheets(0).Rows(4).Visible = False

        End If
        If SIPARISIN_GRUBU = "ICPIYS" Then
            raporgrd.Sheets(0).RowCount = 16
            lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş İÇ PİYASA SİPARİŞ BİLDİRİM FORMU"
            raporgrd.Sheets(0).Cells(15, 0).Text = "Form No: 05.10.1-4/R-1"
            raporgrd.Sheets(0).Cells(15, 0).Font.Size = 11
            raporgrd.Sheets(0).Cells(15, 0).Font.Bold = True
            raporgrd.Sheets(0).Cells(15, 0).ForeColor = Drawing.Color.Blue

            raporgrd.Sheets(0).Rows(4).Visible = False

        End If
    End Sub
    'Private Sub FormnoAyar(ByVal gelenSipNo, ByVal gelenRevizNo)

    '    Dim DbConn1 As New ConnectGiris
    '    SQL = " SELECT DURUM,SIPARIS_GRUBU FROM MRKSIP_CBK_FLM" _
    '        & " WHERE SIP_NO= '" & gelenSipNo & "'" _
    '        & " AND REVIZ_NO= " & gelenRevizNo
    '    DbConn1.RaporWhile(SQL)
    '    While DbConn1.MyDataReader.Read
    '        SiparisinDurumu = DbConn1.MyDataReader.Item("DURUM")
    '        SIPARISIN_GRUBU = DbConn1.MyDataReader.Item("SIPARIS_GRUBU")
    '    End While
    '    DbConn1.Kapat()

    '    If SIPARISIN_GRUBU = "OZLCLK" Or SIPARISIN_GRUBU = "KTKTLP" Then
    '        raporgrd.Sheets(0).RowCount = 18
    '        lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş TEL ÇUBUK HH SİPARİŞ BİLDİRİM FORMU"
    '        IhrKaySip_Yeni.Enabled = False
    '        raporgrd.Sheets(0).Cells(17, 0).Text = "Form No: 05.10.1-5/R-1"
    '        raporgrd.Sheets(0).Cells(17, 0).Font.Size = 11
    '        raporgrd.Sheets(0).Cells(17, 0).Font.Bold = True
    '        raporgrd.Sheets(0).Cells(17, 0).ForeColor = Drawing.Color.Blue


    '        raporgrd.Sheets(0).Rows(15).Visible = True ' FIRMA BILGISI

    '        raporgrd.Sheets(0).Cells(15, 0).Text = "Firma"

    '        raporgrd.Sheets(0).Rows(4).Visible = True

    '    End If
    '    If SIPARISIN_GRUBU = "DISTIC" Then
    '        raporgrd.Sheets(0).RowCount = 16
    '        lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş DIŞ PİYASA SİPARİŞ BİLDİRİM FORMU"
    '        raporgrd.Sheets(0).Cells(15, 0).Text = "Form No: 05.10.1-2/R-3"
    '        raporgrd.Sheets(0).Cells(15, 0).Font.Size = 11
    '        raporgrd.Sheets(0).Cells(15, 0).Font.Bold = True
    '        raporgrd.Sheets(0).Cells(15, 0).ForeColor = Drawing.Color.Blue



    '        raporgrd.Sheets(0).Rows(4).Visible = False

    '    End If
    '    If SIPARISIN_GRUBU = "ICPIYS" Then
    '        raporgrd.Sheets(0).RowCount = 16
    '        lblBaslik.Text = "DİLER DEMİR ÇELİK A.Ş İÇ PİYASA SİPARİŞ BİLDİRİM FORMU"
    '        raporgrd.Sheets(0).Cells(15, 0).Text = "Form No: 05.10.1-4/R-1"
    '        raporgrd.Sheets(0).Cells(15, 0).Font.Size = 11
    '        raporgrd.Sheets(0).Cells(15, 0).Font.Bold = True
    '        raporgrd.Sheets(0).Cells(15, 0).ForeColor = Drawing.Color.Blue


    '        raporgrd.Sheets(0).Rows(4).Visible = False

    '    End If

    'End Sub
    Private Sub RevizyonKarsilastirma(ByVal gelenRevizNo, ByVal gelenSipNo)
        Try
            Dim DbConnEski As New ConnectGiris
            Dim MamulTip
            Dim LotVarMi As Boolean
            'Termin tarihi yazısını siyaha boyatma işlemi
            raporgrd.Sheets(0).Cells(5, 1).ForeColor = Drawing.Color.Black
            raporgrd.Sheets(0).Cells(5, 1).Font.Italic = False

            For index As Integer = 0 To fpEbatMiktarOnay.Sheets(0).RowCount - 1

                If gelenRevizNo > 0 Then
                    LotVarMi = False
                    If fpEbatMiktarOnay.Sheets(0).Cells(index, 1).Text = "Çubuk" Then
                        MamulTip = "C"
                    ElseIf fpEbatMiktarOnay.Sheets(0).Cells(index, 1).Text = "Kangal" Then
                        MamulTip = "K"
                    ElseIf fpEbatMiktarOnay.Sheets(0).Cells(index, 1).Text = "Kangal Doğrultma" Then
                        MamulTip = "KD"
                    ElseIf fpEbatMiktarOnay.Sheets(0).Cells(index, 1).Text = "Kutuk" Then
                        MamulTip = "KT"
                    End If
                    Dim boyCevirilmisHal

                    If fpEbatMiktar.Sheets(0).Cells(index, 6).Text = "FİRKETE" Then
                        boyCevirilmisHal = "999"
                    Else
                        boyCevirilmisHal = fpEbatMiktar.Sheets(0).Cells(index, 8).Text
                    End If

                    If MamulTip <> "KT" Then
                        If MamulTip <> "K" Then
                            SQL = " SELECT *FROM MRKSIP_CBK_FLM_ALT" _
                        & " WHERE SIP_NO= '" & gelenSipNo & "'" _
                        & " AND REVIZ_NO= " & gelenRevizNo - 1 _
                        & " AND LOT ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 0).Text & "'" _
                        & " AND UPPER(MAM_TIP) ='" & MamulTip & "'" _
                        & " AND MAM_STANDART ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 2).Text & "'" _
                        & " AND MAM_KALITE ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 3).Text & "'" _
                        & " AND EBAT ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 4).Text & "'" _
                        & " AND UPPER(ND) ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 5).Text & "'" _
                        & " AND BOY ='" & boyCevirilmisHal & "'"
                        Else
                            SQL = " SELECT *FROM MRKSIP_CBK_FLM_ALT" _
                        & " WHERE SIP_NO= '" & gelenSipNo & "'" _
                        & " AND REVIZ_NO= " & gelenRevizNo - 1 _
                        & " AND LOT ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 0).Text & "'" _
                        & " AND UPPER(MAM_TIP) ='" & MamulTip & "'" _
                        & " AND MAM_STANDART ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 2).Text & "'" _
                        & " AND MAM_KALITE ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 3).Text & "'" _
                        & " AND EBAT ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 4).Text & "'" _
                        & " AND UPPER(ND) ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 5).Text & "'"
                        End If
                    Else
                        SQL = " SELECT *FROM MRKSIP_CBK_FLM_ALT" _
                    & " WHERE SIP_NO= '" & gelenSipNo & "'" _
                    & " AND REVIZ_NO= " & gelenRevizNo - 1 _
                    & " AND LOT ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 0).Text & "'" _
                    & " AND UPPER(MAM_TIP) ='" & MamulTip & "'" _
                    & " AND MAM_KALITE ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 3).Text & "'" _
                    & " AND EBAT ='" & fpEbatMiktarOnay.Sheets(0).Cells(index, 4).Text & "'" _
                    & " AND BOY ='" & boyCevirilmisHal & "'"
                    End If
                    DbConnEski.RaporWhile(SQL)
                    While DbConnEski.MyDataReader.Read
                        KODUNACIKLAMASI = ""
                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 7).Text <> NullToString(DbConnEski.MyDataReader.Item("BOY_TOL_N")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 7).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 7).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 9).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 7).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 7).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 9).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 8).Text <> NullToString(DbConnEski.MyDataReader.Item("BOY_TOL_P")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 8).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 8).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 10).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 8).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 8).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 10).ForeColor = Drawing.Color.Black
                        End If


                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 9).Text <> DbConnEski.MyDataReader.Item("MIKTAR") Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 9).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 9).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 11).ForeColor = Drawing.Color.Red

                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 9).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 9).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 11).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 10).Text <> NullToString(DbConnEski.MyDataReader.Item("BOYAMA")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 10).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 10).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 24).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(14, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(14, 1).Font.Italic = True
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 10).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 10).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 24).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 11).Text <> NullToString(DbConnEski.MyDataReader.Item("CUBUK_SAY")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 11).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 11).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 12).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 11).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 11).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 12).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 12).Text <> NullToString(DbConnEski.MyDataReader.Item("BRM_AGIRLIK_KG")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 12).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 12).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 13).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 12).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 12).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 13).ForeColor = Drawing.Color.Black
                        End If



                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 13).Text <> NullToString(DbConnEski.MyDataReader.Item("PAKET_AGIRLIK")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 13).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 13).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 14).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 13).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 13).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 14).ForeColor = Drawing.Color.Black
                        End If




                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 14).Text <> NullToString(DbConnEski.MyDataReader.Item("HADDE_TOL_N")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 14).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 14).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 15).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 14).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 14).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 15).ForeColor = Drawing.Color.Black
                        End If


                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 15).Text <> NullToString(DbConnEski.MyDataReader.Item("HADDE_TOL_P")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 15).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 15).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 16).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 15).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 15).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 16).ForeColor = Drawing.Color.Black
                        End If



                        Dim rt
                        If DbConnEski.MyDataReader.Item("ROTOR_TIP") = "KR" Then rt = "Küçük Rotor"
                        If DbConnEski.MyDataReader.Item("ROTOR_TIP") = "BR" Then rt = "Büyük Rotor"
                        If DbConnEski.MyDataReader.Item("ROTOR_TIP") = "0" Then rt = "0"

                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 16).Text <> rt Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 16).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 16).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 17).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 16).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 16).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 17).ForeColor = Drawing.Color.Black
                        End If



                        KODUBUL(fpEbatMiktarOnay.Sheets(0).Cells(index, 18).Text)

                        If KODUNACIKLAMASI <> NullToString(DbConnEski.MyDataReader.Item("URUN_BILGI")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 18).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 18).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 18).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 18).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 18).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 18).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 19).Text <> NullToString(DbConnEski.MyDataReader.Item("KUTUK_MENSEI")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 19).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 19).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 19).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 19).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 19).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 19).ForeColor = Drawing.Color.Black
                        End If


                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 20).Text <> NullToString(DbConnEski.MyDataReader.Item("KUTUK_KALITE")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 20).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 20).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 20).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 20).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 20).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 20).ForeColor = Drawing.Color.Black
                        End If



                        TERSCEVIR(DbConnEski.MyDataReader.Item("TERMIN_BAS_TAR"))
                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 21).Text <> DonenTersTarih Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 21).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 21).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 21).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(5, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(5, 1).Font.Italic = True

                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 21).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 21).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 21).ForeColor = Drawing.Color.Black
                        End If
                        TERSCEVIR(DbConnEski.MyDataReader.Item("TERMIN_BIT_TAR"))
                        If fpEbatMiktarOnay.Sheets(0).Cells(index, 22).Text <> DonenTersTarih Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 22).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 22).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 22).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(5, 1).ForeColor = Drawing.Color.Red
                            raporgrd.Sheets(0).Cells(5, 1).Font.Italic = True
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 22).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 22).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 22).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktar.Sheets(0).Cells(index, 25).Text <> NullToString(DbConnEski.MyDataReader.Item("KOSERADYUS")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 23).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 23).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 25).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 23).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 23).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 25).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktar.Sheets(0).Cells(index, 26).Text <> NullToString(DbConnEski.MyDataReader.Item("ROMBIKLIK")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 24).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 24).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 26).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 24).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 24).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 26).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktar.Sheets(0).Cells(index, 27).Text <> NullToString(DbConnEski.MyDataReader.Item("DOGSAPMA")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 25).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 25).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 27).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 25).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 25).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 27).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktar.Sheets(0).Cells(index, 28).Text <> NullToString(DbConnEski.MyDataReader.Item("BURULMA")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 26).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 26).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 28).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 26).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 26).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 28).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktar.Sheets(0).Cells(index, 29).Text <> NullToString(DbConnEski.MyDataReader.Item("KESMESEKLI")) Then
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 27).ForeColor = Drawing.Color.Red
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 27).Font.Italic = True
                            fpEbatMiktar.Sheets(0).Cells(index, 29).ForeColor = Drawing.Color.Red
                        Else
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 27).ForeColor = Drawing.Color.Black
                            fpEbatMiktarOnay.Sheets(0).Cells(index, 27).Font.Italic = False
                            fpEbatMiktar.Sheets(0).Cells(index, 29).ForeColor = Drawing.Color.Black
                        End If

                        Dim TopMikTolMinBayrak As Boolean = False
                        Dim TopMikTolMaxBayrak As Boolean = False
                        If fpEbatMiktar.Sheets(0).Cells(index, 34).Text <> DbConnEski.MyDataReader.Item("TOP_MIK_TOL_MIN") Then
                            fpEbatMiktar.Sheets(0).Cells(index, 34).ForeColor = Drawing.Color.Red
                            TopMikTolMinBayrak = True
                        Else
                            fpEbatMiktar.Sheets(0).Cells(index, 34).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktar.Sheets(0).Cells(index, 35).Text <> DbConnEski.MyDataReader.Item("TOP_MIK_TOL_MAX") Then
                            fpEbatMiktar.Sheets(0).Cells(index, 35).ForeColor = Drawing.Color.Red
                            TopMikTolMaxBayrak = True
                        Else
                            fpEbatMiktar.Sheets(0).Cells(index, 35).ForeColor = Drawing.Color.Black
                        End If

                        If TopMikTolMinBayrak Or TopMikTolMaxBayrak Then
                            raporgrd.Sheets(0).Cells(1, 1).ForeColor = Drawing.Color.Red
                        Else
                            raporgrd.Sheets(0).Cells(1, 1).ForeColor = Drawing.Color.Black
                        End If

                        Dim CapMikTolMinBayrak As Boolean = False
                        Dim CapMikTolMaxBayrak As Boolean = False
                        If fpEbatMiktar.Sheets(0).Cells(index, 32).Text <> DbConnEski.MyDataReader.Item("CAP_MIK_TOL_MIN") Then
                            fpEbatMiktar.Sheets(0).Cells(index, 32).ForeColor = Drawing.Color.Red
                            CapMikTolMinBayrak = True
                        Else
                            fpEbatMiktar.Sheets(0).Cells(index, 32).ForeColor = Drawing.Color.Black
                        End If

                        If fpEbatMiktar.Sheets(0).Cells(index, 33).Text <> DbConnEski.MyDataReader.Item("CAP_MIK_TOL_MAX") Then
                            fpEbatMiktar.Sheets(0).Cells(index, 33).ForeColor = Drawing.Color.Red
                            CapMikTolMaxBayrak = True
                        Else
                            fpEbatMiktar.Sheets(0).Cells(index, 33).ForeColor = Drawing.Color.Black
                        End If

                        If CapMikTolMinBayrak Or CapMikTolMaxBayrak Then
                            raporgrd.Sheets(0).Cells(2, 1).ForeColor = Drawing.Color.Red
                        Else
                            raporgrd.Sheets(0).Cells(2, 1).ForeColor = Drawing.Color.Black
                        End If

                        LotVarMi = True

                        'If fpEbatMiktar.Sheets(0).Cells(index, 29).Text <> NullToString(DbConnEski.MyDataReader.Item("KESMESEKLI")) Then
                        '    fpEbatMiktarOnay.Sheets(0).Cells(index, 27).BackColor = Drawing.Color.Red
                        '    fpEbatMiktar.Sheets(0).Cells(index, 29).BackColor = Drawing.Color.Red
                        'Else
                        '    fpEbatMiktarOnay.Sheets(0).Cells(index, 27).BackColor = Drawing.Color.White
                        '    fpEbatMiktar.Sheets(0).Cells(index, 29).BackColor = Drawing.Color.White
                        'End If
                        ' LotVarMi = False
                    End While

                    DbConnEski.Kapat()


                    If LotVarMi = False Then
                        'Eskisinde lot yoksa sadece yenisinde varsa
                        fpEbatMiktarOnay.Sheets(0).Rows(index).ForeColor = Drawing.Color.Red
                        fpEbatMiktar.Sheets(0).Rows(index).ForeColor = Drawing.Color.Red
                    End If
                End If
            Next

        Catch ex As Exception
            txtKayitDurumu.Text = "Revizyon karşılaştırmada hata oluştu."
            txtKayitDurumu.BackColor = Drawing.Color.Red
        End Try
    End Sub
    Private Sub KODUBUL(ByVal KODU)

        Dim DbConn As New ConnectOracleFilmasin
        SQL = " SELECT DISTINCT KALITESINIFI FROM FILMASIN.KALITESINIF " _
            & " WHERE OZLKOD='" & KODU & "'"

        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            KODUNACIKLAMASI = DbConn.MyDataReader.Item("KALITESINIFI")
        End While
        DbConn.Kapat()

    End Sub
    Private Sub alanlariAc()
        'alanlariKapat()
        txtUretimSipNo.Enabled = True
        dateSipTar.Enabled = True
        txtMamul.Enabled = True
        txtCapMikTolPoz.Enabled = True
        txtCapMikTolNeg.Enabled = True
        txtTopMikTolPoz.Enabled = True
        txtTopMikTolNeg.Enabled = True
        rdFaturalama.Enabled = True
        txtPaketleme.Enabled = True
        txtEtiket.Enabled = True
        txtOzelSart.Enabled = True
        txtGozetim.Enabled = True
        txtFirma.Enabled = True
        drpUlke.Enabled = True
        fpEbatMiktar.Enabled = True

        'Satir ekleme tarafı
        txtLotNo.Enabled = True
        drpMamulTip.Enabled = True
        drpStandart.Enabled = True
        drpKalite.Enabled = True
        drpCap.Enabled = True
        drpND.Enabled = True
        drpBoy.Enabled = True
        txtBoyTolPoz.Enabled = True
        txtBoyTolNeg.Enabled = True
        txtMiktar.Enabled = True
        txtBoyama.Enabled = True
        txtCubukSayisi.Enabled = True
        txtBirimAgirlik.Enabled = True
        txtPaketAgirlik.Enabled = True
        drpMarka.Enabled = True

        drpRotorTip.Enabled = True

        txtBosLiman.Enabled = True

        txtHadde_Tol_N.Enabled = True
        txtHadde_Tol_P.Enabled = True
        dateTerminBit.Enabled = True
        dateTerminBas.Enabled = True

        txtKaynakLotNo.Enabled = True
        txtYeniLotNo.Enabled = True

        'End If
        drpUrunBilgi.Enabled = True
        drpKutukTedarikci.Enabled = True
        txtKutukKalite.Enabled = True
        txtMusteriAdi.Enabled = True

        btnSatirEkle.Enabled = True
        btnSatirCogalt.Enabled = True
        BtnSakla.Enabled = True
        If drpMamulTip.Text = "Kutuk" Then
            txtKoseRadyusu.Enabled = True
            txtRombiklik.Enabled = True
            txtDogSapma.Enabled = True
            txtBurulma.Enabled = True
            txtKesmeSekli.Enabled = True
        Else
        End If
        txtCapMikTolMin.Enabled = True
        txtCapMikTolMax.Enabled = True
        txtTopMikTolMin.Enabled = True
        txtTopMikTolMax.Enabled = True
    End Sub
    Private Sub alanlariKapat()

        dateSipTar.Enabled = False
        txtMamul.Enabled = False
        txtCapMikTolPoz.Enabled = False
        txtCapMikTolNeg.Enabled = False
        txtTopMikTolPoz.Enabled = False
        txtTopMikTolNeg.Enabled = False
        rdFaturalama.Enabled = False
        txtPaketleme.Enabled = False
        txtEtiket.Enabled = False
        txtOzelSart.Enabled = False
        txtGozetim.Enabled = False

        txtFirma.Enabled = False
        drpUlke.Enabled = False
        fpEbatMiktar.Enabled = False

        'Satir ekleme tarafi        
        drpStandart.Enabled = False
        drpKalite.Enabled = False
        drpCap.Enabled = False
        drpND.Enabled = False
        drpBoy.Enabled = False
        txtBoyTolPoz.Enabled = False
        txtBoyTolNeg.Enabled = False
        txtMiktar.Enabled = False
        txtBoyama.Enabled = False
        txtCubukSayisi.Enabled = False
        txtBirimAgirlik.Enabled = False
        txtPaketAgirlik.Enabled = False
        txtBosLiman.Enabled = False

        drpMarka.Enabled = False
        drpRotorTip.Enabled = False
        drpUrunBilgi.Enabled = False
        drpKutukTedarikci.Enabled = False
        txtKutukKalite.Enabled = False
        txtMusteriAdi.Enabled = False
        BtnSakla.Enabled = False
        txtKoseRadyusu.Enabled = False
        txtRombiklik.Enabled = False
        txtDogSapma.Enabled = False
        txtBurulma.Enabled = False
        txtKesmeSekli.Enabled = False

        txtCapMikTolMin.Enabled = False
        txtCapMikTolMax.Enabled = False
        txtTopMikTolMin.Enabled = False
        txtTopMikTolMax.Enabled = False
    End Sub
    Sub alanKontrolEtArkaplanDegistir()
        If drpUlke.Enabled Then drpUlke.BackColor = Drawing.Color.White Else drpUlke.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpMamulTip.Enabled Then drpMamulTip.BackColor = Drawing.Color.White Else drpMamulTip.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpStandart.Enabled Then drpStandart.BackColor = Drawing.Color.White Else drpStandart.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If txtKutukKalite.Enabled Then txtKutukKalite.BackColor = Drawing.Color.White Else txtKutukKalite.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpKalite.Enabled Then drpKalite.BackColor = Drawing.Color.White Else drpKalite.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpCap.Enabled Then drpCap.BackColor = Drawing.Color.White Else drpCap.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpND.Enabled Then drpND.BackColor = Drawing.Color.White Else drpND.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpBoy.Enabled Then drpBoy.BackColor = Drawing.Color.White Else drpBoy.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpMarka.Enabled Then drpMarka.BackColor = Drawing.Color.White Else drpMarka.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpRotorTip.Enabled Then drpRotorTip.BackColor = Drawing.Color.White Else drpRotorTip.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpUrunBilgi.Enabled Then drpUrunBilgi.BackColor = Drawing.Color.White Else drpUrunBilgi.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If drpKutukTedarikci.Enabled Then drpKutukTedarikci.BackColor = Drawing.Color.White Else drpKutukTedarikci.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If txtCapMikTolMin.Enabled Then txtCapMikTolMin.BackColor = Drawing.Color.White Else txtCapMikTolMin.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If txtCapMikTolMax.Enabled Then txtCapMikTolMax.BackColor = Drawing.Color.White Else txtCapMikTolMax.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If txtTopMikTolMin.Enabled Then txtTopMikTolMin.BackColor = Drawing.Color.White Else txtTopMikTolMin.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
        If txtTopMikTolMax.Enabled Then txtTopMikTolMax.BackColor = Drawing.Color.White Else txtTopMikTolMax.BackColor = Drawing.ColorTranslator.FromHtml("#EBEBE4")
    End Sub
    Sub btnyetki()
        Kullanıcı = Session("KULLANICI")
        PrgKod = Session("PRGKOD")
        PrgYer = Session("PRGYER")
        'UsrTxt.Text = "Kullanıcı :" & Kullanıcı
        KullanıcıSipYetki = Session("KULLANICISIPARISNO")
        AktifSiparisinDurumu = Session("AktifSiparisDurumu")

        If KullanıcıSipYetki = 0 Or KullanıcıSipYetki = 1 Then
            BtnYeni.Enabled = True
            Buton_SIP_GIRIS.Enabled = False
            'alanlariKapat()
            btnSatirEkle.Enabled = False
            Buton_SIP_SIL.Enabled = False
            Buton_SIP_REVIZYON.Enabled = False
            Buton_SIP_GIR_ONAY.Enabled = False

            Buton_SIP_IPTAL.Enabled = False

            Buton_SIP_IPTAL.BackColor = Drawing.Color.Gray

            btnSatirEkle.BackColor = Drawing.Color.Gray
            BtnYeni.BackColor = Drawing.Color.SteelBlue
            Buton_SIP_GIRIS.BackColor = Drawing.Color.Gray
            Buton_SIP_SIL.BackColor = Drawing.Color.Gray
            Buton_SIP_REVIZYON.BackColor = Drawing.Color.Gray
            Buton_SIP_GIR_ONAY.BackColor = Drawing.Color.Gray
        End If

        If KullanıcıSipYetki = 2 Then
            BtnYeni.Enabled = False
            Buton_SIP_GIRIS.Enabled = False
            'alanlariKapat()
            btnSatirEkle.Enabled = False
            Buton_SIP_SIL.Enabled = False
            Buton_SIP_REVIZYON.Enabled = False
            Buton_SIP_GIR_ONAY.Enabled = True
            fpEbatMiktar.Enabled = True

            Buton_SIP_IPTAL.Enabled = True
            Buton_SIP_IPTAL.BackColor = Drawing.Color.SteelBlue

            BtnYeni.BackColor = Drawing.Color.Gray
            Buton_SIP_GIRIS.BackColor = Drawing.Color.Gray
            btnSatirEkle.BackColor = Drawing.Color.Gray
            Buton_SIP_SIL.BackColor = Drawing.Color.Gray
            Buton_SIP_REVIZYON.BackColor = Drawing.Color.Gray
            Buton_SIP_GIR_ONAY.BackColor = Drawing.Color.SteelBlue

            dateSipTar.Enabled = True
            txtRevizyon.Enabled = True
        End If

        If KullanıcıSipYetki = 3 Then
            BtnYeni.Enabled = False
            Buton_SIP_GIRIS.Enabled = False
            'alanlariKapat()
            btnSatirEkle.Enabled = False
            Buton_SIP_SIL.Enabled = False
            Buton_SIP_REVIZYON.Enabled = False
            Buton_SIP_GIR_ONAY.Enabled = True
            fpEbatMiktar.Enabled = True

            Buton_SIP_IPTAL.Enabled = True
            Buton_SIP_IPTAL.BackColor = Drawing.Color.SteelBlue

            BtnYeni.BackColor = Drawing.Color.Gray
            Buton_SIP_GIRIS.BackColor = Drawing.Color.Gray
            btnSatirEkle.BackColor = Drawing.Color.Gray
            Buton_SIP_SIL.BackColor = Drawing.Color.Gray
            Buton_SIP_REVIZYON.BackColor = Drawing.Color.Gray
            Buton_SIP_GIR_ONAY.BackColor = Drawing.Color.SteelBlue

            dateSipTar.Enabled = True
            txtRevizyon.Enabled = True
        End If

    End Sub
    Private Sub ulkeGetir()
        Dim DbConn As New ConnectGiris
        'drpUlke2.Items.Clear()
        drpUlke.Items.Clear()
        'drpUlke2.Items.Add("Türkiye")
        'drpUlke2.Items.Add("İç Piyasa")
        drpUlke.Items.Add("")
        drpUlke.Items.Add("Türkiye")
        drpUlke.Items.Add("İç Piyasa")

        SQL = " SELECT ULKEADI FROM URTTNM.ULKE " _
        & " ORDER BY ULKEADI "
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            drpUlke.Items.Add(DbConn.MyDataReader.Item("ULKEADI"))
            'drpUlke2.Items.Add(DbConn.MyDataReader.Item("ULKEADI"))
        End While
        DbConn.Kapat()


    End Sub

    Private Sub SiparisSahibiGetir()

        Dim DbConn As New ConnectGiris

        Siparis_Sahibi.Items.Clear()
        'Siparis_Sahibi.Items.Add("")

        SQL = "SELECT TANIMI FROM URTTNM.USRSIPARIS WHERE (PROGRAM_YETKI_NUMARASI=2 AND GRUP='DISTIC') " _
        & " ORDER BY TANIMI"

        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            Siparis_Sahibi.Items.Add(DbConn.MyDataReader.Item("TANIMI"))
        End While
        DbConn.Kapat()

        If Program_Grubu = "OZLCLK" Or Program_Grubu = "ICPIYS" Then
            Siparis_Sahibi.Items.Clear()
            'Siparis_Sahibi.Items.Add("-")
        End If

    End Sub


    Private Sub SiparisSahibiGetir_IHR()

        Dim DbConn As New ConnectGiris

        Siparis_Sahibi.Items.Clear()
        Siparis_Sahibi.Items.Add("")

        SQL = "SELECT TANIMI FROM URTTNM.USRSIPARIS WHERE (PROGRAM_YETKI_NUMARASI=2 AND GRUP='DISTIC') OR  (PROGRAM_YETKI_NUMARASI=3 AND GRUP='OZLCLK') " _
        & " ORDER BY TANIMI"

        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            Siparis_Sahibi.Items.Add(DbConn.MyDataReader.Item("TANIMI"))
        End While
        DbConn.Kapat()

    End Sub

    Private Sub KaliteAckBul(ByVal GelenKalitekod)

        KaliteAck = ""
        Dim sql
        sql = "SELECT DISTINCT URTTNM.KALITE.ACK FROM URTTNM.KALITE  " _
                & " WHERE URTTNM.KALITE.FRMNUM='D'" _
                & " AND URTTNM.KALITE.AYRILMA='DHH'" _
                & " AND URTTNM.KALITE.KOD='" & GelenKalitekod & "'"
        Dim DbConn As New ConnectGiris
        DbConn.RaporWhile(sql)
        While DbConn.MyDataReader.Read
            KaliteAck = DbConn.MyDataReader.GetString(0).ToString()
        End While
        DbConn.Kapat()

    End Sub

    Dim GelecekDrm
    'Sub rapor()
    '    Try
    '        Dim s1, s2, s3, s4, s5
    '        Dim ToplamKayitSayisi
    '        'fpSiparisGetir.ActiveSheetView.ColumnCount = 3
    '        'fpSiparisGetir.ActiveSheetView.PageSize = 50
    '        'fpSiparisGetir.ActiveSheetView.RowCount = 50
    '        'fpSiparisGetir.HorizontalScrollBarPolicy = FarPoint.Web.Spread.ScrollBarPolicy.Always
    '        'fpSiparisGetir.VerticalScrollBarPolicy = FarPoint.Web.Spread.ScrollBarPolicy.Always
    '        Dim sip_No As String = ""
    '        sip_No = txtSipNoRapor.Text.Trim
    '        If sip_No = "" Then
    '            Dim DbConn As New ConnectGiris
    '            If drpSiparisDurum.Text = "Kontrol Bekleyen" Then GelecekDrm = "0"
    '            If drpSiparisDurum.Text = "Merkez Onay Bekleyen" Then
    '                'If KullanıcıSipYetki = 2 Then
    '                GelecekDrm = "1"
    '                'End If
    '                'If KullanıcıSipYetki = 3 Then
    '                'GelecekDrm = "2"
    '                'End If
    '            End If
    '            If drpSiparisDurum.Text = "Uretim Plan Onay Bekleyen" Then GelecekDrm = "2"
    '            If drpSiparisDurum.Text = "Onaylanmış Sipariş" Then GelecekDrm = "3"
    '            If drpSiparisDurum.Text = "Reddedilmiş Sipariş" Then GelecekDrm = "4"
    '            Dim raporBasTar, raporBitTar
    '            CEVIR(dateRaporBas.Value)
    '            raporBasTar = DonenTarih
    '            CEVIR(dateRaporBit.Value)
    '            raporBitTar = DonenTarih
    '            If GelecekDrm = "" Then
    '                SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
    '                    & " WHERE SIP_TAR >=" & raporBasTar _
    '                    & " AND SIP_TAR <=" & raporBitTar _
    '                    & " ORDER BY KAYIT_TAR DESC, SIP_NO, REVIZ_NO"
    '            End If

    '            If GelecekDrm <> "" Then
    '                SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
    '                    & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "' " _
    '                    & " AND SIP_TAR >=" & raporBasTar _
    '                    & " AND SIP_TAR <=" & raporBitTar _
    '                    & " ORDER BY KAYIT_TAR DESC, SIP_NO, REVIZ_NO"
    '            End If
    '            DbConn.RaporWhile(SQL)
    '            Dim i As Int16 = 0
    '            fpSiparisGetir.Sheets(0).RowCount = 0

    '            While DbConn.MyDataReader.Read
    '                fpSiparisGetir.Sheets(0).RowCount += 1
    '                fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
    '                fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
    '                fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.Item("ULKE")
    '                fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("DURUM")

    '                If Len(DbConn.MyDataReader.Item("MRKSIPGIR") & "") > 0 Then
    '                    s1 = Mid(DbConn.MyDataReader.Item("MRKSIPGIR"), 1, 10)
    '                Else
    '                    s1 = ""
    '                End If

    '                If Len(DbConn.MyDataReader.Item("MRKSIPKONTROL") & "") > 0 Then
    '                    s2 = Mid(DbConn.MyDataReader.Item("MRKSIPKONTROL"), 1, 10)
    '                Else
    '                    s2 = ""
    '                End If

    '                If Len(DbConn.MyDataReader.Item("MRKSIPONAY") & "") > 0 Then
    '                    s3 = Mid(DbConn.MyDataReader.Item("MRKSIPONAY"), 1, 12)
    '                Else
    '                    s3 = ""
    '                End If
    '                If Len(DbConn.MyDataReader.Item("URTPLNONAY") & "") > 0 Then
    '                    s4 = Mid(DbConn.MyDataReader.Item("URTPLNONAY"), 1, 12)
    '                Else
    '                    s4 = ""
    '                End If
    '                If Len(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI") & "") > 0 Then
    '                    s5 = Mid(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI"), 1, 15)
    '                Else
    '                    s5 = ""
    '                End If


    '                fpSiparisGetir.Sheets(0).Cells(i, 4).Text = s1
    '                fpSiparisGetir.Sheets(0).Cells(i, 5).Text = s2
    '                fpSiparisGetir.Sheets(0).Cells(i, 6).Text = s3
    '                fpSiparisGetir.Sheets(0).Cells(i, 7).Text = s4
    '                fpSiparisGetir.Sheets(0).Cells(i, 8).Text = s5

    '                i += 1
    '            End While
    '            DbConn.Kapat()

    '            txtKayitDurumu.BackColor = Drawing.Color.Green
    '            txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
    '            lblMsg.Text = " Bulunan Toplam Kayıt=" & i
    '        Else
    '            Dim DbConn As New ConnectGiris
    '            SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
    '                & " WHERE MRKSIP_CBK_FLM.SIP_NO = '" & sip_No & "'"

    '            DbConn.RaporWhile(SQL)
    '            Dim i As Int16 = 0
    '            fpSiparisGetir.Sheets(0).RowCount = 0
    '            While DbConn.MyDataReader.Read
    '                fpSiparisGetir.Sheets(0).RowCount += 1
    '                fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
    '                fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
    '                fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.Item("ULKE")
    '                fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("DURUM")
    '                If Len(DbConn.MyDataReader.Item("MRKSIPGIR") & "") > 0 Then
    '                    s1 = Mid(DbConn.MyDataReader.Item("MRKSIPGIR"), 1, 10)
    '                Else
    '                    s1 = ""
    '                End If

    '                If Len(DbConn.MyDataReader.Item("MRKSIPKONTROL") & "") > 0 Then
    '                    s2 = Mid(DbConn.MyDataReader.Item("MRKSIPKONTROL"), 1, 10)
    '                Else
    '                    s2 = ""
    '                End If

    '                If Len(DbConn.MyDataReader.Item("MRKSIPONAY") & "") > 0 Then
    '                    s3 = Mid(DbConn.MyDataReader.Item("MRKSIPONAY"), 1, 12)
    '                Else
    '                    s3 = ""
    '                End If
    '                If Len(DbConn.MyDataReader.Item("URTPLNONAY") & "") > 0 Then
    '                    s4 = Mid(DbConn.MyDataReader.Item("URTPLNONAY"), 1, 12)
    '                Else
    '                    s4 = ""
    '                End If
    '                If Len(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI") & "") > 0 Then
    '                    s5 = Mid(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI"), 1, 15)
    '                Else
    '                    s5 = ""
    '                End If


    '                fpSiparisGetir.Sheets(0).Cells(i, 4).Text = s1
    '                fpSiparisGetir.Sheets(0).Cells(i, 5).Text = s2
    '                fpSiparisGetir.Sheets(0).Cells(i, 6).Text = s3
    '                fpSiparisGetir.Sheets(0).Cells(i, 7).Text = s4
    '                fpSiparisGetir.Sheets(0).Cells(i, 8).Text = s5


    '                i += 1
    '            End While
    '            DbConn.Kapat()
    '            txtKayitDurumu.BackColor = Drawing.Color.Green
    '            txtKayitDurumu.Text = "İlgili sipariş ayrıntısı getirildi."
    '        End If

    '    Catch ex As Exception
    '        txtKayitDurumu.BackColor = Drawing.Color.Red
    '        txtKayitDurumu.Text = "İlgili sipariş ayrıntısı getirilirken hata ile karşılaşıldı."
    '    End Try

    'End Sub

    Private Sub revizyonYap()
        Dim sip_no, reviz_no
        Dim DbConn As New ConnectGiris

        If dateSipTar.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Lütfen sipariş numarası giriniz');", True)
        ElseIf Session("AktifSiparisDurumu") < 3 Then
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş onaylanmadan revizyon numarası alınamaz.');", True)
        Else
            sip_no = txtUretimSipNo.Text
            SQL = "SELECT MAX(REVIZ_NO) REVIZ_NO FROM MRKSIP_CBK_FLM " _
            & " WHERE sip_no = '" & sip_no & "'" _
            & " ORDER BY REVIZ_NO"
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                If IsDBNull(DbConn.MyDataReader.Item("REVIZ_NO")) Then
                    reviz_no = 0
                Else
                    reviz_no = DbConn.MyDataReader.Item("REVIZ_NO") + 1
                End If
            End While
            DbConn.Kapat()
            txtRevizyon.Text = reviz_no
            dateSipTar.Text = Date.Today.ToString("dd/MM/yyyy")
            txtKopyalaBasildimi.Text = "Hayır"
            'Sipariş kütük ise analiz aktarılacak. 
            If fpEbatMiktar.Sheets(0).RowCount > 0 Then
                If fpEbatMiktar.Sheets(0).Cells(0, 3).Text = "Kutuk" Then
                    revizyonAnalizAktar(sip_no, reviz_no - 1)
                End If
            End If

            alanlariBeyazlat()
            txtUretimSipNo.Enabled = False
            BtnSakla.Enabled = True

            If PrgKod = "ICPIYS" Then
                Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)
                spreadDilerCapDoldur()
                drpRotorTip.Items.Clear()
                dhhstandartGetir()
            End If
        End If
    End Sub

    Private Sub Sil()

        Dim sip_no, reviz_no
        Dim silmeDurum As Integer
        Dim DbConnYedek As New ConnectGiris
        Dim DbConn As New ConnectGiris
        reviz_no = Convert.ToInt32(txtRevizyon.Text)
        sip_no = txtUretimSipNo.Text
        SQL = " SELECT DURUM FROM MRKSIP_CBK_FLM" _
                & " WHERE SIP_NO='" & sip_no & "'" _
                & " AND REVIZ_NO=" & reviz_no
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            silmeDurum = DbConn.MyDataReader.Item("DURUM")
        End While
        DbConn.Kapat()

        'silmeDurum < 1 ise kayıt silinebilir. Yani giriş ve kontrol seviyesindeki sipariş silinebilir.
        If silmeDurum < 1 Then
            Dim DbConnSil As New ConnectGiris
            SQL = "DELETE FROM MRKSIP_CBK_FLM" _
            & " WHERE SIP_NO='" & sip_no & "'" _
            & " AND REVIZ_NO=" & reviz_no
            DbConnSil.Sil(SQL)
                DbConnSil.Kapat()

                SQL = "DELETE FROM MRKSIP_CBK_FLM_ALT" _
                            & " WHERE SIP_NO='" & sip_no & "'" _
                            & " AND REVIZ_NO=" & reviz_no
                DbConnSil.Sil(SQL)
                DbConnSil.Kapat()
                Try
                    alanlariBeyazlat()
                    temizle()
                    txtKayitDurumu.Text = "Sipariş başarıyla silindi."
                Catch ex As Exception
                    txtKayitDurumu.BackColor = Drawing.Color.Red
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Silme işlemi basarısız oldu.');", True)
                txtKayitDurumu.BackColor = Drawing.Color.Red
                txtKayitDurumu.Text = "Silme işlemi basarısız oldu. Sipariş No:" & sip_no & " Revizyon No:" & reviz_no
            End Try

                DbConn.Kapat()
        Else
            'ShowMessage("Onaylanmış sipariş silinemez. Sipariş No:" & sip_no & " Revizyon No:" & reviz_no)
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Onaylanmış sipariş silinemez.');", True)
            txtKayitDurumu.BackColor = Drawing.Color.Red
            txtKayitDurumu.Text = "Onaylanmış sipariş silinemez. Sipariş No:" & sip_no & " Revizyon No:" & reviz_no
        End If
    End Sub
    Dim bosAlanlarAna As String
    Dim bosAlanlarAlt As String
    Private Sub alankontrol()
        '        fpEbatMiktar.SaveChanges()
        bosAlanlarAna = ""
        bosAlanlarAlt = ""
        If dateSipTar.Text = "" Then
            dateSipTar.BackColor = Drawing.Color.Red
            bosAlanlarAna += "SipNo "
            kayitKontrol = False
        Else
            dateSipTar.BackColor = Drawing.Color.FromArgb(&H66, &HFF, &HCC)
        End If

        If txtRevizyon.Text = "" Then
            txtRevizyon.BackColor = Drawing.Color.Red
            bosAlanlarAna += "RevNo "
            kayitKontrol = False
        Else
            txtRevizyon.BackColor = Drawing.Color.FromArgb(&H66, &HFF, &HCC)
        End If

        If txtUretimSipNo.Text = "" Then
            txtUretimSipNo.BackColor = Drawing.Color.Red
            bosAlanlarAna += "Sipariş No "
            kayitKontrol = False
        Else
            txtUretimSipNo.BackColor = Drawing.Color.FromArgb(&H66, &HFF, &HCC)
        End If

        If txtMamul.Text = "" Then
            txtMamul.BackColor = Drawing.Color.Red
            kayitKontrol = False
            bosAlanlarAna += "Mamul "
        Else
            txtMamul.BackColor = Drawing.Color.White
        End If
        Dim secili
        secili = rdFaturalama.SelectedIndex

        'Faturalama iç piyasada zorunlu alan değil
        If PrgKod <> "ICPIYS" Then
            If secili = 0 Or secili = 1 Then
                rdFaturalama.BackColor = Drawing.Color.FromArgb(&HEF, &HEF, &HEF)
                txtKayitDurumu.ForeColor = Drawing.Color.FromArgb(&HD6, &HDF, &HEF)
            Else
                rdFaturalama.ForeColor = Drawing.Color.Red
                kayitKontrol = False
                bosAlanlarAna += "Faturalama "
            End If
        End If


    End Sub
    Dim kayitKontrol As Boolean = True

    Private Sub sakla()


        ' Timer1.Enabled = True
        alankontrol()

        txtKayitDurumu.Text = "0"

        If kayitKontrol Then
            Dim sip_tar, sip_no, reviz_no
            reviz_no = Convert.ToInt32(txtRevizyon.Text)
            CEVIR(dateSipTar.Text)
            sip_tar = DonenTarih
            sip_no = txtUretimSipNo.Text
            txtKayitDurumu.Text = "1"
            siparisSakla(reviz_no, sip_no, sip_tar)
            'txtKayitDurumu.Text = "2"
            txtKayitDurumu.ForeColor = Drawing.Color.White
        Else
            If bosAlanlarAna <> "" Then
                txtKayitDurumu.BackColor = Drawing.Color.Red
                txtKayitDurumu.Text = bosAlanlarAna + " Ana tablo alan(lar)ını boş bırakamazsınız."
            End If
        End If
    End Sub

    Private Sub alanlariBeyazlat()
        dateSipTar.BackColor = Drawing.Color.White
        txtMamul.BackColor = Drawing.Color.White
        txtFirma.BackColor = Drawing.Color.White
        txtCapMikTolPoz.BackColor = Drawing.Color.White
        txtCapMikTolNeg.BackColor = Drawing.Color.White
        txtTopMikTolPoz.BackColor = Drawing.Color.White
        txtTopMikTolNeg.BackColor = Drawing.Color.White
        rdFaturalama.BackColor = Drawing.Color.White
        txtPaketleme.BackColor = Drawing.Color.White
        txtEtiket.BackColor = Drawing.Color.White
        txtToplamMik.BackColor = Drawing.Color.White
        txtOzelSart.BackColor = Drawing.Color.White
        txtGozetim.BackColor = Drawing.Color.White
        drpUlke.BackColor = Drawing.Color.White

        txtCapMikTolMin.BackColor = Drawing.Color.White
        txtCapMikTolMax.BackColor = Drawing.Color.White
        txtTopMikTolMin.BackColor = Drawing.Color.White
        txtTopMikTolMax.BackColor = Drawing.Color.White

        For satir As Integer = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
            For sutun As Integer = 0 To fpEbatMiktar.Sheets(0).ColumnCount - 1
                If sutun = 0 Or sutun = 4 Or sutun = 6 Or sutun = 9 Then
                    fpEbatMiktar.Sheets(0).Cells(satir, sutun).BackColor = Drawing.Color.White
                Else
                    fpEbatMiktar.Sheets(0).Cells(satir, sutun).BackColor = Drawing.ColorTranslator.FromHtml("#E3FDFD")
                End If
            Next
        Next
    End Sub
    Private Sub temizle()

        Session("EskiRevNo") = ""

        'Siparis_Sahibi.Text = ""

        fpEbatMiktar.Sheets(0).RowCount = 0
        fpEbatMiktarOnay.Sheets(0).RowCount = 0

        dateSipTar.Text = Date.Today.ToString("dd/MM/yyyy")
        'dateSipTar.Text = ""
        txtUretimSipNo.Text = ""
        txtRevizyon.Text = "0"
        txtMamul.Text = ""
        txtFirma.Text = ""
        txtCapMikTolPoz.Text = ""
        txtCapMikTolNeg.Text = ""
        txtTopMikTolPoz.Text = ""
        txtTopMikTolNeg.Text = ""
        rdFaturalama.ClearSelection()
        rdFaturalama.BackColor = Drawing.Color.FromArgb(&HEF, &HEF, &HEF)
        txtPaketleme.Text = ""
        txtEtiket.Text = ""
        txtToplamMik.Text = ""
        txtOzelSart.Text = ""
        txtGozetim.Text = ""
        drpUlke.SelectedIndex = 0
        'txtBosaltma.Text = ""
        txtKayitDurumu.Text = "Kayıt Durumu:"
        txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")



        txtLotNo.Text = ""
        drpStandart.Items.Add("-")
        drpStandart.Text = "-"

        drpKalite.Items.Clear()
        ' drpKalite.Text = ""


        drpCap.Text = ""
        drpND.Text = ""
        drpBoy.Text = ""
        txtBoyTolPoz.Text = ""
        txtBoyTolNeg.Text = ""
        txtMiktar.Text = ""
        txtBoyama.Text = ""
        txtCubukSayisi.Text = ""
        txtBirimAgirlik.Text = ""
        txtPaketAgirlik.Text = ""
        drpMarka.Text = ""
        drpRotorTip.Items.Clear()
        txtBosLiman.Text = ""
        drpUrunBilgi.Text = ""
        drpKutukTedarikci.Text = ""
        txtKutukKalite.Text = ""
        txtMusteriAdi.Text = ""
        dateTerminBas.Text = ""
        dateTerminBit.Text = ""
        txtHadde_Tol_N.Text = ""
        txtHadde_Tol_P.Text = ""
        txtEbatTolNeg.Text = ""
        txtEbatTolPoz.Text = ""
        '   lblEk.Text = ""

        txtKoseRadyusu.Text = ""
        txtRombiklik.Text = ""
        txtDogSapma.Text = ""
        txtBurulma.Text = ""
        txtKesmeSekli.Text = ""

        txtCapMikTolMin.Text = ""
        txtCapMikTolMax.Text = ""

        txtTopMikTolMin.Text = ""
        txtTopMikTolMax.Text = ""

        raporgrd.Sheets(0).Cells(11, 1).Text = ""
        raporgrd.Sheets(0).Cells(15, 1).Text = ""
    End Sub
    Private Sub alankontrolAlt()

        If Session("PRGKOD") = "KTKTLP" Then
            txtTopMikTolMin.Text = 0
            txtTopMikTolMax.Text = 0
            txtCapMikTolMin.Text = 0
            txtCapMikTolMax.Text = 0
        End If

        'For index As Integer = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
        If txtLotNo.Text = "" Then
            txtLotNo.Text = "0"
        End If
        If drpMamulTip.Text = "-" Then
            kayitKontrol = False
            bosAlanlarAlt += "Mamul tipi, "
        End If

        If drpMamulTip.Text <> "Kutuk" And drpStandart.Text = "" Then
            kayitKontrol = False
            bosAlanlarAlt += "Standart, "
        End If
        If drpMamulTip.Text <> "Kutuk" And drpND.Text = "" Then
            kayitKontrol = False
            bosAlanlarAlt += "ND, "
        End If
        If drpMamulTip.Text <> "Kutuk" And drpKalite.Text = "" Then
            kayitKontrol = False
            bosAlanlarAlt += "Kalite, "
        End If
        If drpCap.Text = "" Then
            kayitKontrol = False
            bosAlanlarAlt += "Çap, "
        End If
        If drpBoy.Text = "" And (drpMamulTip.Text = "Çubuk" Or drpMamulTip.Text = "Kutuk") Then
            kayitKontrol = False
            bosAlanlarAlt += "Boy, "
        End If

        If dateTerminBas.Text = "" Then
            kayitKontrol = False
            bosAlanlarAlt += "Termin Başlangıç, "
        End If
        If dateTerminBit.Text = "" Then
            kayitKontrol = False
            bosAlanlarAlt += "Termin Bitiş, "
        End If

        If PrgKod <> "ICPIYS" And PrgKod <> "OZLCLK" Then

            If txtCapMikTolMin.Text.Trim = "" Then
                If txtCapMikTolNeg.Text.Trim = "" Then
                    kayitKontrol = False
                    bosAlanlarAlt += "Çap Miktar Toleransı Min, "
                End If
            End If

            If txtCapMikTolMax.Text.Trim = "" Then
                If txtCapMikTolPoz.Text.Trim = "" Then
                    kayitKontrol = False
                    bosAlanlarAlt += "Çap Miktar Toleransı Max, "
                End If
            End If

            If txtTopMikTolMin.Text.Trim = "" Then
                If txtTopMikTolNeg.Text.Trim = "" Then
                    kayitKontrol = False
                End If
                bosAlanlarAlt += "Toplam Miktar Toleransı Min, "
            End If

            If txtTopMikTolMax.Text.Trim = "" Then
                If txtTopMikTolPoz.Text.Trim = "" Then
                    kayitKontrol = False

                    bosAlanlarAlt += "Toplam Miktar Toleransı Max, "
                End If
            End If

        End If


        'If drpBoy.Text <> "0" And drpMamulTip.Text <> "Çubuk" Then
        '    kayitKontrol = False
        '    bosAlanlarAlt += "Boy "
        'End If
        'If drpMamulTip.Text = "Kangal" And drpBoy.Text <> "0" Then
        '    kayitKontrol = False
        '    bosAlanlarAlt += "Boy Tolerans - "
        'End If
        'If drpMamulTip.Text = "Kangal" And txtBoyTolNeg.Text.Trim <> "" Then
        '    kayitKontrol = False
        '    bosAlanlarAlt += "Boy Tolerans - "
        'End If
        'If drpMamulTip.Text = "Kangal" And txtBoyTolPoz.Text <> "" Then
        '    kayitKontrol = False
        '    bosAlanlarAlt += "Boy Tolerans + "
        'End If

        If txtMiktar.Text.Trim = "" Then
            kayitKontrol = False
            bosAlanlarAlt += "Miktar, "
        End If


        If PrgKod <> "ICPIYS" Then

            If drpMamulTip.Text = "Çubuk" And txtBoyTolPoz.Text = "" Then
                kayitKontrol = False
                bosAlanlarAlt += "Boy Tolerans +, "
            End If
            If drpMamulTip.Text = "Çubuk" And txtBoyTolNeg.Text = "" Then
                kayitKontrol = False
                bosAlanlarAlt += "Boy Tolerans -, "
            End If
        End If

        If PrgKod = "OZLCLK" Then
            If drpRotorTip.Text = "" Then
                drpRotorTip.BackColor = Drawing.Color.Red
                kayitKontrol = False
                bosAlanlarAna += "ROTOR TIP "
            Else
                drpRotorTip.BackColor = Drawing.Color.White
            End If
        End If


        If PrgKod = "OZEL" Then
            If dateTerminBas.Text = "" Then
                kayitKontrol = False
                bosAlanlarAlt += "Termin Başlangıç, "
            End If
            If dateTerminBit.Text = "" Then
                kayitKontrol = False
                bosAlanlarAlt += "Termin Bitiş, "
            End If
            If dateTerminBas.Text <> "" Or dateTerminBit.Text <> "" Then
                'Çubuk seçildiyse iki tarih aynı olması gerekiyor.
                If drpMamulTip.Text = "Çubuk" And dateTerminBas.Text <> dateTerminBit.Text Then
                    'ShowMessage("Mamül tipi çubuksa Termin Başlangıcı Bitiş ile aynı olmalıdır.")
                    bosAlanlarAlt += " --Mamül tipi çubuksa Termin Başlangıcı Bitiş ile aynı olmalıdır.-- "
                    kayitKontrol = False
                End If
                'Bitiş tarihi başlangıç tarihinden önce olamaz

                Dim termin_bas, termin_bit As String
                CEVIRconvert(dateTerminBas.Text)
                termin_bas = DonenTarih
                CEVIRconvert(dateTerminBit.Text)
                termin_bit = DonenTarih
                If termin_bas > termin_bit Then
                    'ShowMessage("Bitiş tarihi başlangıç tarihinden önce olamaz")
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Bitiş tarihi başlangıç tarihinden önce olamaz.');", True)
                    kayitKontrol = False
                End If
            End If
        Else
            'If dateSonYukTar.Text = "" Then
            '    kayitKontrol = False
            '    bosAlanlarAlt += "Son yükleme termini "
            'End If
        End If

        'Next
        Dim Satirsayisi = fpEbatMiktar.Sheets(0).RowCount
        If Satirsayisi > 0 Then
            txtKayitDurumu.ForeColor = Drawing.Color.White
            Dim i, AnaToplam
            For i = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                AnaToplam = CDec(AnaToplam) + CDec(fpEbatMiktar.Sheets(0).Cells(i, 9).Value)
            Next
            'Else
            '    'lblKayitDurumu.ForeColor = Drawing.Color.Red
            '    'lblKayitDurumu.Text = "Herhangi bir LOT bilgisi girmediniz...."
            '    bosAlanlarAlt += "Bütün "
            '    kayitKontrol = False
        End If
    End Sub

    Protected Sub btnSatirEkle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSatirEkle.Click

        Try
            'mamtipi kontrol
            ' bir siparişte kütük varsa başka birsey olamaz
            Dim i, Bak, Sip_Kutuk_Count, Sip_Other_Count
            Sip_Kutuk_Count = 0
            Sip_Other_Count = 0



            Dim MamTipiKOntrol As Boolean

            For i = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                Bak = fpEbatMiktar.Sheets(0).Cells(i, 3).Text
                If Bak = "Kutuk" Then Sip_Kutuk_Count = Sip_Kutuk_Count + 1
                If Bak <> "Kutuk" Then Sip_Other_Count = Sip_Other_Count + 1
            Next
            If drpMamulTip.Text = "Kutuk" Then Sip_Kutuk_Count = Sip_Kutuk_Count + 1
            If drpMamulTip.Text <> "Kutuk" Then Sip_Other_Count = Sip_Other_Count + 1

            If Sip_Kutuk_Count > 0 And Sip_Other_Count > 0 Then
                MamTipiKOntrol = False
            Else
                MamTipiKOntrol = True
            End If

            If MamTipiKOntrol = False Then
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Kütük Siparişleri, tek başına girilmelidir.....!.');", True)
                txtKayitDurumu.BackColor = Drawing.Color.Red
                txtKayitDurumu.Text = "Kütük Siparişleri, tek başına girilmelidir.....!"
            Else

                alankontrolAlt()

                If kayitKontrol Then


                    Dim standart, kalite, satir
                    Dim kal_standart As Boolean = True
                    fpEbatMiktar.Sheets(0).RowCount = fpEbatMiktar.Sheets(0).RowCount + 1
                    satir = fpEbatMiktar.Sheets(0).RowCount - 1
                    standart = drpStandart.Text
                    kalite = drpKalite.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 2).Text = txtLotNo.Text.Replace("'", " ")
                    fpEbatMiktar.Sheets(0).Cells(satir, 3).Text = drpMamulTip.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 4).Text = standart
                    fpEbatMiktar.Sheets(0).Cells(satir, 5).Text = kalite
                    fpEbatMiktar.Sheets(0).Cells(satir, 6).Text = drpCap.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 7).Text = drpND.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 8).Text = drpBoy.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 9).Text = txtBoyTolNeg.Text.Replace("'", " ")
                    fpEbatMiktar.Sheets(0).Cells(satir, 10).Text = txtBoyTolPoz.Text.Replace("'", " ")
                    fpEbatMiktar.Sheets(0).Cells(satir, 11).Text = txtMiktar.Text.Replace("'", " ")

                    fpEbatMiktar.Sheets(0).Cells(satir, 12).Text = txtCubukSayisi.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 13).Text = txtBirimAgirlik.Text.Replace(".", ",")
                    fpEbatMiktar.Sheets(0).Cells(satir, 14).Text = txtPaketAgirlik.Text.Replace(".", ",")

                    fpEbatMiktar.Sheets(0).Cells(satir, 15).Text = txtHadde_Tol_N.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 16).Text = txtHadde_Tol_P.Text

                    fpEbatMiktar.Sheets(0).Cells(satir, 17).Text = drpRotorTip.Text

                    fpEbatMiktar.Sheets(0).Cells(satir, 18).Text = drpUrunBilgi.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 19).Text = drpKutukTedarikci.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 20).Text = txtKutukKalite.Text

                    If dateTerminBas.Text.Replace(".", "/") <> "" And dateTerminBit.Text.Replace(".", "/") <> "" Then
                        fpEbatMiktar.Sheets(0).Cells(satir, 21).Text = dateTerminBas.Text.Replace(".", "/")
                        fpEbatMiktar.Sheets(0).Cells(satir, 22).Text = dateTerminBit.Text.Replace(".", "/")
                    ElseIf dateTerminBas.Text.Replace(".", "/") <> "" And dateTerminBit.Text.Replace(".", "/") = "" Then
                        fpEbatMiktar.Sheets(0).Cells(satir, 21).Text = dateTerminBas.Text.Replace(".", "/")
                        fpEbatMiktar.Sheets(0).Cells(satir, 22).Text = dateTerminBas.Text.Replace(".", "/")
                    ElseIf dateTerminBas.Text.Replace(".", "/") = "" And dateTerminBit.Text.Replace(".", "/") <> "" Then
                        fpEbatMiktar.Sheets(0).Cells(satir, 21).Text = dateTerminBit.Text.Replace(".", "/")
                        fpEbatMiktar.Sheets(0).Cells(satir, 22).Text = dateTerminBit.Text.Replace(".", "/")
                    End If

                    fpEbatMiktar.Sheets(0).Cells(satir, 23).Text = txtBosLiman.Text.Replace("'", " ")
                    fpEbatMiktar.Sheets(0).Cells(satir, 24).Text = txtBoyama.Text.Replace("'", " ")

                    fpEbatMiktar.Sheets(0).Cells(satir, 25).Text = txtKoseRadyusu.Text.Replace("'", " ")
                    fpEbatMiktar.Sheets(0).Cells(satir, 26).Text = txtRombiklik.Text.Replace("'", " ")
                    fpEbatMiktar.Sheets(0).Cells(satir, 27).Text = txtDogSapma.Text.Replace("'", " ")
                    fpEbatMiktar.Sheets(0).Cells(satir, 28).Text = txtBurulma.Text.Replace("'", " ")
                    fpEbatMiktar.Sheets(0).Cells(satir, 29).Text = txtKesmeSekli.Text.Replace("'", " ")

                    fpEbatMiktar.Sheets(0).Cells(satir, 30).Text = txtEbatTolNeg.Text.Replace("'", " ").Replace(".", ",").Trim
                    fpEbatMiktar.Sheets(0).Cells(satir, 31).Text = txtEbatTolPoz.Text.Replace("'", " ").Replace(".", ",").Trim



                    If txtCapMikTolMin.Text.Trim = "" Then
                        fpEbatMiktar.Sheets(0).Cells(satir, 32).Text = txtCapMikTolNeg.Text.Replace("'", " ").Replace(".", ",").Trim
                    Else
                        fpEbatMiktar.Sheets(0).Cells(satir, 32).Text = txtCapMikTolMin.Text.Replace("'", " ").Replace(".", ",").Trim
                    End If

                    If txtCapMikTolMax.Text.Trim = "" Then
                        fpEbatMiktar.Sheets(0).Cells(satir, 33).Text = txtCapMikTolPoz.Text.Replace("'", " ").Replace(".", ",").Trim
                    Else
                        fpEbatMiktar.Sheets(0).Cells(satir, 33).Text = txtCapMikTolMax.Text.Replace("'", " ").Replace(".", ",").Trim
                    End If

                    If txtTopMikTolMin.Text.Trim = "" Then
                        fpEbatMiktar.Sheets(0).Cells(satir, 34).Text = txtTopMikTolNeg.Text.Replace("'", " ").Replace(".", ",").Trim
                    Else
                        fpEbatMiktar.Sheets(0).Cells(satir, 34).Text = txtTopMikTolMin.Text.Replace("'", " ").Replace(".", ",").Trim
                    End If

                    If txtTopMikTolMax.Text.Trim = "" Then
                        fpEbatMiktar.Sheets(0).Cells(satir, 35).Text = txtTopMikTolPoz.Text.Replace("'", " ").Replace(".", ",").Trim
                    Else
                        fpEbatMiktar.Sheets(0).Cells(satir, 35).Text = txtTopMikTolMax.Text.Replace("'", " ").Replace(".", ",").Trim
                    End If


                    If txtMusteriAdi.Text.Trim = "" Then
                        fpEbatMiktar.Sheets(0).Cells(satir, 36).Text = txtMusteriAdi.Text.Replace("'", " ").Trim
                    Else
                        fpEbatMiktar.Sheets(0).Cells(satir, 36).Text = txtMusteriAdi.Text.Replace("'", " ").Trim
                    End If



                    Dim toplamMiktar = 0
                    For index As Integer = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                        toplamMiktar += fpEbatMiktar.Sheets(0).Cells(index, 11).Text
                    Next
                    txtToplamMik.Text = toplamMiktar
                    txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
                    txtKayitDurumu.Text = "Satır eklendi."
                Else
                    txtKayitDurumu.BackColor = Drawing.Color.Red
                    txtKayitDurumu.Text = Mid(bosAlanlarAlt, 1, Len(bosAlanlarAlt) - 2) & " alan(lar)ı boş bırakılamaz!"
                End If

            End If



            If CheckBox1.Checked = True Then
                altTabloSakla(txtUretimSipNo.Text, txtRevizyon.Text)
                siparisleriAlanaGetir(txtUretimSipNo.Text, txtRevizyon.Text, SiparisinDurumu)
            End If

        Catch ex As Exception
            txtKayitDurumu.BackColor = Drawing.Color.Red
            txtKayitDurumu.Text = "Hatalı bir işlem yaptınız....!"
        End Try
    End Sub

    Protected Sub BtnYeni_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnYeni.Click


        YeniBtn("YENI")

    End Sub
    Protected Sub YeniBtn(GelenYer)

        '    Timer1.Enabled = False


        spreadCapDoldur() ' eger kutuk sıp cagırmıssam ve yenı butonuna basmıssam ve kutuk harıcı bır sıp gıreceksem caplar hatalı gelıyor
        alanlariBeyazlat()
        temizle()
        Soldaki_Tum_alanları_Ac()

        If KullanıcıSipYetki = 0 Or KullanıcıSipYetki = 1 Then
            ' kullanıcının sisitemdeki yeri ile seçtiği siparişin yeri tutmaz ise
            'alanlariAc()
            Buton_SIP_GIRIS.Enabled = True
            btnSatirEkle.Enabled = True
            'Buton_SIP_GIRIS.BackColor = Drawing.Color.SteelBlue
            btnSatirEkle.BackColor = Drawing.Color.SteelBlue
            'BtnSil.Enabled = True
            'BtnSil.BackColor = Drawing.Color.SteelBlue
            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = " Yeni Sipariş Bilgilerini Girip Sakla Butonuna basınız"


            BtnSakla.Enabled = True
            ' bunları yeni demeden açamaz saha once kapatmıstık
            ' o yuzden actık
            'txtUretimSipNo.Enabled = True
            txtLotNo.Enabled = True
            drpMamulTip.Enabled = True
            drpStandart.Enabled = True
            drpKalite.Enabled = True
            drpCap.Enabled = True
            drpND.Enabled = True
            drpBoy.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtMiktar.Enabled = True
            txtBoyama.Enabled = True
            txtCubukSayisi.Enabled = True
            txtBirimAgirlik.Enabled = True
            txtPaketAgirlik.Enabled = True
            drpMarka.Enabled = True
            drpRotorTip.Enabled = True
            txtBosLiman.Enabled = True
            Siparis_Sahibi.Enabled = True

            txtCapMikTolMin.Enabled = True
            txtCapMikTolMax.Enabled = True
            txtTopMikTolMin.Enabled = True
            txtTopMikTolMax.Enabled = True




            If Session("PRGKOD") = "ICPIYS" Then
                Dim sipNo
                sipNo = "SP" & Date.Now.ToString("yy") & Date.Now.ToString("MM")
                Dim DbConn As New ConnectGiris
                txtUretimSipNo.Enabled = False
                SQL = " SELECT MAX(SUBSTR(SIP_NO,7,2)) SIPNO " _
                & " FROM MRKSIP_CBK_FLM " _
                & " WHERE SUBSTR(SIP_NO,1,6)='" & sipNo & "'" _
                & " AND REVIZ_NO='0'"
                DbConn.Sayac(SQL)
                Dim sayi As String = DbConn.GeriDonenRakam
                DbConn.Kapat()
                txtMamul.Text = "İç Piyasa Sipariş"
                If Len(sayi) = 1 Then
                    txtUretimSipNo.Text = sipNo & sayi + 1
                Else
                    txtUretimSipNo.Text = sipNo & "0" & sayi + 1
                End If
                drpMamulTip.Text = "Çubuk"
                drpUlke.Text = "Türkiye"
                Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)
                dhhstandartGetir()
                rdFaturalama.SelectedIndex = 0
            Else
                rdFaturalama.SelectedIndex = 0
                txtUretimSipNo.Enabled = True
            End If

            If Session("PRGKOD") = "OZLCLK" Then
                'Siparis_Sahibi.Items.Add(Kullanıcı)
                'Siparis_Sahibi.Text = Kullanıcı


                Dim DbConn As New ConnectGiris
                txtUretimSipNo.Enabled = False
                If GelenYer = "YENI" Then
                    SQL = " SELECT MAX(SUBSTR(SIP_NO,2,LENGTH(SIP_NO)-1)) SIPNO " _
                          & " FROM MRKSIP_CBK_FLM " _
                         & " WHERE SUBSTR(SIP_NO,1,1)='V'" _
                          & " AND REVIZ_NO='0'"
                    DbConn.Sayac(SQL)
                    Dim sayi As String = DbConn.GeriDonenRakam
                    DbConn.Kapat()

                    If Len(sayi) = 1 Then
                        txtUretimSipNo.Text = "V" + sayi + 1
                    Else
                        txtUretimSipNo.Text = "V" & sayi + 1
                    End If
                End If
                If GelenYer = "TAVLI" Then

                    Dim sipNo
                    sipNo = "TAV" & Date.Now.ToString("yy") & Date.Now.ToString("MM")
                    txtUretimSipNo.Enabled = False
                    SQL = " SELECT MAX(SUBSTR(SIP_NO,8,2)) SIPNO " _
                    & " FROM MRKSIP_CBK_FLM " _
                    & " WHERE SUBSTR(SIP_NO,1,7)='" & sipNo & "'" _
                    & " AND REVIZ_NO='0'"
                    DbConn.Sayac(SQL)
                    Dim sayi As String = DbConn.GeriDonenRakam
                    DbConn.Kapat()
                    txtMamul.Text = "Tavlanacak Mlz Sipariş"

                    If Len(sayi) = 1 Then
                        txtUretimSipNo.Text = sipNo & sayi + 1
                    Else
                        txtUretimSipNo.Text = sipNo & "0" & sayi + 1
                    End If

                    SiparisSahibiGetir_IHR()

                End If

                varmı = 0
                For gg = 0 To Siparis_Sahibi.Items.Count - 1
                    If gg > 0 Then
                        If Siparis_Sahibi.Items(gg).Text = Kullanıcı Then
                            varmı = 1
                            GoTo son2
                        End If
                    End If
                Next
                If varmı = 0 Then
                    Siparis_Sahibi.Items.Add(NullToString(Kullanıcı) & "")
                End If
son2:

                Siparis_Sahibi.Text = NullToString(Kullanıcı) & ""

                Siparis_Sahibi.Enabled = True
                drpUlke.Text = "Türkiye"

            End If


        End If

        If Session("PRGKOD") = "KTKTLP" Then

            Dim sipNo
            sipNo = "KTK" & Date.Now.ToString("yy") & Date.Now.ToString("MM")
            Dim DbConn As New ConnectGiris
            txtUretimSipNo.Enabled = False
            SQL = " Select MAX(SUBSTR(SIP_NO,8,3)) SIPNO " _
            & " FROM MRKSIP_CBK_FLM " _
            & " WHERE SUBSTR(SIP_NO,1,7)='" & sipNo & "'" _
            & " AND REVIZ_NO='0'"
            DbConn.Sayac(SQL)
            Dim sayi As String = DbConn.GeriDonenRakam
            DbConn.Kapat()

            If Len(sayi + 1) = 1 Then
                txtUretimSipNo.Text = sipNo & "0" & sayi + 1
            Else
                txtUretimSipNo.Text = sipNo & sayi + 1
            End If

            'dhhstandartGetir()
            txtMamul.Text = "Kütük Demir"
            Siparis_Sahibi.Items.Clear()
            Siparis_Sahibi.Text = ""
            txtLotNo.Text = 0
        End If

        If Session("PRGKOD") = "KTKTLP" Then
            If Strings.Mid(Ipadresi, 9, 3) = "189" Then
                If drpMamulTip.Text = "-" Or drpMamulTip.Text = "Kutuk" Then
                    txtUretimSipNo.Enabled = False
                Else
                    txtUretimSipNo.Enabled = True
                End If
            End If
        End If

        If Session("PRGKOD") = "DISTIC" Then
            SiparisSahibiGetir_IHR()
        End If

    End Sub
    Public Sub SipNoOtomatikGetir()

        txtUretimSipNo.Text = "otm"

    End Sub
    Public Sub CEVIRconvert(ByVal gelen As String)
        Dim provider As System.Globalization.CultureInfo = System.Globalization.CultureInfo.InvariantCulture
        Dim result As Date
        result = Date.ParseExact(gelen, "dd/MM/yyyy", provider)

        Dim YIL, AY, GUN As String
        YIL = Microsoft.VisualBasic.Year(result)
        AY = Microsoft.VisualBasic.Month(result)
        If Microsoft.VisualBasic.Len(AY.ToString) = 1 Then AY = "0" & AY
        GUN = Microsoft.VisualBasic.Day(result)
        If Microsoft.VisualBasic.Len(GUN) = 1 Then GUN = "0" & GUN
        DonenTarih = YIL & AY & GUN
    End Sub
    Sub spreadUrunBilgiDoldur()
        Dim UrunBilgi As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim UrunBilgiList As New ArrayList
        Dim DbConn As New ConnectOracleFilmasin

        SQL = " SELECT DISTINCT KALITESINIFI FROM FILMASIN.KALITESINIF " _
            & " WHERE KALITESINIFI IS NOT NULL" _
                & " ORDER BY KALITESINIFI "
        DbConn.RaporWhile(SQL)
        UrunBilgiList.Add("")
        drpUrunBilgi.Items.Clear()
        drpUrunBilgi.Items.Add("")
        While DbConn.MyDataReader.Read
            If IsDBNull(DbConn.MyDataReader.Item("KALITESINIFI")) Then

            Else
                UrunBilgiList.Add(DbConn.MyDataReader.Item("KALITESINIFI"))
                drpUrunBilgi.Items.Add(DbConn.MyDataReader.Item("KALITESINIFI"))
            End If
        End While

        DbConn.Kapat()

        Dim s As String()
        s = UrunBilgiList.ToArray(GetType(String))
        cb.Items = s

        fpEbatMiktar.Sheets(0).Columns(18).CellType = cb

    End Sub
    Sub MustaeriAdıDoldur()
        Dim KutukTedarikci As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim KutukTedarikciList As New ArrayList
        Dim DbConn As New ConnectOracleFilmasin
        SQL = " SELECT DISTINCT MUSTERI FROM FILMASIN.FLM_MUSTERI_SERTIFIKA " _
            & " WHERE MUSTERI IS NOT NULL" _
                & " ORDER BY MUSTERI "
        DbConn.RaporWhile(SQL)
        txtMusteriAdi.Items.Add("")
        txtMusteriAdi.Items.Clear()
        txtMusteriAdi.Items.Add("")
        While DbConn.MyDataReader.Read
            txtMusteriAdi.Items.Add(DbConn.MyDataReader.Item("MUSTERI"))
        End While
        DbConn.Kapat()


    End Sub
    Sub spreadKutukTedarikciDoldur()
        Dim KutukTedarikci As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim KutukTedarikciList As New ArrayList
        Dim DbConn As New ConnectOracleFilmasin
        SQL = " SELECT DISTINCT TEDARIKCI FROM FILMASIN.KALITESINIF " _
            & " WHERE TEDARIKCI IS NOT NULL" _
                & " ORDER BY TEDARIKCI "
        DbConn.RaporWhile(SQL)
        KutukTedarikciList.Add("")
        drpKutukTedarikci.Items.Clear()
        drpKutukTedarikci.Items.Add("")
        While DbConn.MyDataReader.Read
            KutukTedarikciList.Add(DbConn.MyDataReader.Item("TEDARIKCI"))
            drpKutukTedarikci.Items.Add(DbConn.MyDataReader.Item("TEDARIKCI"))
        End While
        DbConn.Kapat()
        Dim s As String()
        s = KutukTedarikciList.ToArray(GetType(String))
        cb.Items = s
        fpEbatMiktar.Sheets(0).Columns(19).CellType = cb
    End Sub

    Sub spreadKutukKaliteDoldur()

        Dim KutukKalite As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim KutukKaliteList As New ArrayList
        Dim DbConn As New ConnectOracleFilmasin
        SQL = " SELECT DISTINCT KTK_KALITE FROM FILMASIN.KALITESINIF " _
            & " WHERE KTK_KALITE IS NOT NULL" _
                & " ORDER BY KTK_KALITE "
        DbConn.RaporWhile(SQL)
        KutukKaliteList.Add("")
        drpKalite.Items.Clear()
        txtKutukKalite.Items.Add("")
        While DbConn.MyDataReader.Read
            KutukKaliteList.Add(DbConn.MyDataReader.Item("KTK_KALITE"))
            txtKutukKalite.Items.Add(DbConn.MyDataReader.Item("KTK_KALITE"))
        End While
        DbConn.Kapat()
        Dim s As String()
        s = KutukKaliteList.ToArray(GetType(String))
        cb.Items = s
        fpEbatMiktar.Sheets(0).Columns(20).CellType = cb

    End Sub

    Sub spreadBoyDoldur()
        Dim Boy As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim BoyList As New ArrayList
        Dim DbConn As New ConnectGiris
        SQL = " SELECT DISTINCT ACK FROM URTTNM.BOY" _
                & " ORDER BY ACK "

        DbConn.RaporWhile(SQL)
        drpBoy.Items.Clear()
        BoyList.Add("0")
        drpBoy.Items.Add("")
        'drpBoy.Items.Add("FİRKETE")
        'BoyList.Add("FİRKETE")
        drpBoy.Items.Add("6")
        drpBoy.Items.Add("12")
        While DbConn.MyDataReader.Read
            BoyList.Add(DbConn.MyDataReader.Item("ACK"))
            drpBoy.Items.Add(DbConn.MyDataReader.Item("ACK"))
        End While
        DbConn.Kapat()
        Dim s As String()
        s = BoyList.ToArray(GetType(String))
        cb.Items = s
        fpEbatMiktar.Sheets(0).Columns(8).CellType = cb

    End Sub
    Sub spreadDilerCapDoldur()

        drpCap.Items.Clear()
        drpCap.Items.Add("")
        Dim DbConn As New ConnectGiris

        OncekiCap = "-"
        SQL = " SELECT ACK FROM URTTNM.CAP" _
                & " ORDER BY SIRALAMA"
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            If OncekiCap <> DbConn.MyDataReader.Item("ACK") Then
                drpCap.Items.Add(DbConn.MyDataReader.Item("ACK"))
            End If
            OncekiCap = DbConn.MyDataReader.Item("ACK")
        End While
        DbConn.Kapat()

    End Sub
    Sub spreadFilmasinCapDoldur()

        drpCap.Items.Clear()
        drpCap.Items.Add("")
        Dim DbConn As New ConnectOracleFilmasin
        SQL = " SELECT DISTINCT(ACK),SIRALAMA FROM FILMASIN.CAP  " _
                & " ORDER BY SIRALAMA "
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            drpCap.Items.Add(DbConn.MyDataReader.Item("ACK"))
        End While
        DbConn.Kapat()

    End Sub

    Sub spreadCapDoldur()

        'Filmasin ve dilerin caplarını birlikte dolduruyor. Hangi siparişden satıra gelebileceğini bilemeyeceğimiz için
        Dim Cap As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        Dim CapList As New ArrayList
        Dim DbConn As New ConnectGiris
        SQL = " SELECT DISTINCT ACK FROM BUTUNCAPLAR " _
                & " ORDER BY ACK "
        DbConn.RaporWhile(SQL)
        'CapList.Add("")
        While DbConn.MyDataReader.Read
            CapList.Add(DbConn.MyDataReader.Item("ACK"))
        End While
        DbConn.Kapat()

        Dim s As String()
        s = CapList.ToArray(GetType(String))
        cb.Items = s
        fpEbatMiktar.Sheets(0).Columns(6).CellType = cb

    End Sub

    Sub kutukCapDoldur()

        Dim Cap As String
        drpCap.Items.Clear()
        drpCap.Items.Add("")
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim CapList As New ArrayList
        Dim DbConn As New ConnectGiris
        SQL = " SELECT DISTINCT ACK FROM URTTNM.ebat where TESIS='DCH' ORDER BY ACK "
        DbConn.RaporWhile(SQL)
        CapList.Add("")
        While DbConn.MyDataReader.Read
            CapList.Add(DbConn.MyDataReader.Item("ACK") & "x" & DbConn.MyDataReader.Item("ACK"))
            drpCap.Items.Add(DbConn.MyDataReader.Item("ACK") & "x" & DbConn.MyDataReader.Item("ACK"))
        End While
        DbConn.Kapat()

        'Dim s As String()
        's = CapList.ToArray(GetType(String))
        'cb.Items = s
        'fpEbatMiktar.Sheets(0).Columns(6).CellType = cb

    End Sub

    Sub kutukCapDoldur_Gridli()

        Dim Cap As String
        drpCap.Items.Clear()
        drpCap.Items.Add("")
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim CapList As New ArrayList
        Dim DbConn As New ConnectGiris
        SQL = " SELECT DISTINCT ACK FROM URTTNM.ebat where TESIS='DCH' ORDER BY ACK "
        DbConn.RaporWhile(SQL)
        CapList.Add("")
        While DbConn.MyDataReader.Read
            CapList.Add(DbConn.MyDataReader.Item("ACK") & "x" & DbConn.MyDataReader.Item("ACK"))
            drpCap.Items.Add(DbConn.MyDataReader.Item("ACK") & "x" & DbConn.MyDataReader.Item("ACK"))
        End While
        DbConn.Kapat()

        Dim s As String()
        s = CapList.ToArray(GetType(String))
        cb.Items = s
        fpEbatMiktar.Sheets(0).Columns(6).CellType = cb

    End Sub
    Private Sub sipnogetir()

        Dim sipNo = txtUretimSipNo.Text
        Dim revNo = txtRevizyon.Text
        siparisleriAlanaGetir(sipNo, revNo, "0")

    End Sub


    Protected Sub drpMamulTip_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpMamulTip.SelectedIndexChanged

        ' SagTarafı_Temizle()
        drpKalite.Items.Clear()
        drpStandart.Items.Clear()
        'drpMarka.Items.Clear()
        drpND.SelectedIndex = 0
        If drpMamulTip.Text = "Kutuk" Then

            Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)
            Label1.Text = "Ebat / Tol(-/+) "
            dchstandartGetir()
            dchkalitegetir()
            kutukCapDoldur_Gridli()

            'If PrgKod = "ICPIYS" Then
            '    drpStandart.Text = "BS 4449:2005"
            '    CHStdKalitebul()
            '    drpKalite.Text = "S 220"
            'End If

            If PrgKod = "ICPIYS" Then
                drpStandart.Text = "TS 708"
                CHStdKalitebul()
                drpKalite.Text = "S 220"
            End If

            If PrgKod = "KTKTLP" Then
                drpStandart.Items.Clear()
                drpStandart.Items.Add("-")
                drpStandart.Text = "-"
                '   flmKalitebul()' dchkalitegetir YAPILDI 20151219_Kalite gelmiyordu
            End If



        End If

        If drpMamulTip.Text = "Kangal" Then
            Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)
            filmasinStandartGetir()

            drpBoy.Text = ""
            txtBoyTolNeg.Text = ""
            txtBoyTolPoz.Text = ""
            drpRotorTip.Items.Clear()
            drpRotorTip.Items.Add("")
            drpRotorTip.Items.Add("Büyük Rotor")
            drpRotorTip.Items.Add("Küçük Rotor")
            drpRotorTip.Text = ""

            spreadFilmasinCapDoldur()
            Label1.Text = "Çap/Tol(-/+)"
        ElseIf drpMamulTip.Text = "Kangal Doğrultma" Then

            Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)
            drpRotorTip.Items.Clear()
            filmasinStandartGetir()

            spreadFilmasinCapDoldur()
            Label1.Text = "Çap/Tol(-/+)"
        ElseIf drpMamulTip.Text = "Çubuk" Then

            Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)
            spreadDilerCapDoldur()
            drpRotorTip.Items.Clear()
            dhhstandartGetir()
            Label1.Text = "Çap"
        End If

        If Strings.Mid(Ipadresi, 9, 3) = "189" Then
            If drpMamulTip.Text <> "Kutuk" Then
                txtUretimSipNo.Text = ""
                txtMamul.Text = ""
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert( 'Kütük üretimi harici Siparişleriniz için Sipariş Numarasını Elle Yazmalısınız....');", True)
            End If
        Else
            txtUretimSipNo.Enabled = True
        End If



        If Session("PRGKOD") = "KTKTLP" Then
            If Strings.Mid(Ipadresi, 9, 3) = "189" Then
                If drpMamulTip.Text = "-" Or drpMamulTip.Text = "Kutuk" Then
                    txtUretimSipNo.Enabled = False
                Else
                    txtUretimSipNo.Enabled = True
                End If
            End If
        End If

    End Sub

    Protected Sub drpStandart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpStandart.SelectedIndexChanged

        drpKalite.Items.Clear()
        'drpMarka.Items.Clear()
        drpND.SelectedIndex = 0

        If drpMamulTip.Text = "Kangal" Then
            filmasinKaliteGetir()

            drpBoy.Text = ""
            txtBoyTolNeg.Text = ""
            txtBoyTolPoz.Text = ""
            'drpBoy.Enabled = False
            'txtBoyTolNeg.Enabled = False
            'txtBoyTolPoz.Enabled = False
        End If

        If drpMamulTip.Text = "Kangal Doğrultma" Then
            filmasinKaliteGetir()
        End If

        If drpMamulTip.Text = "Çubuk" Then
            dhhStdKalitebul()
        End If

        If drpMamulTip.Text = "Kutuk" Then

            CHStdKalitebul()
        End If

    End Sub


    Sub KutukKalite_Filtreli_getir()

        Dim KutukKalite As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim KutukKaliteList As New ArrayList
        Dim DbConn As New ConnectOracleFilmasin
        SQL = " SELECT DISTINCT KTK_KALITE FROM FILMASIN.KALITESINIF " _
            & " WHERE MAM_KALITE ='" & drpKalite.Text & "'" _
                & " ORDER BY KTK_KALITE "

        DbConn.RaporWhile(SQL)
        txtKutukKalite.Items.Clear()
        txtKutukKalite.Items.Add("")
        While DbConn.MyDataReader.Read
            txtKutukKalite.Items.Add(DbConn.MyDataReader.Item("KTK_KALITE"))
        End While
        DbConn.Kapat()

    End Sub

    Protected Sub drpKalite_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpKalite.SelectedIndexChanged


        If drpMamulTip.Text = "Kangal" Then
            drpBoy.Text = ""
            txtBoyTolNeg.Text = ""
            txtBoyTolPoz.Text = ""
            drpBoy.Enabled = False
            txtBoyTolNeg.Enabled = False
            txtBoyTolPoz.Enabled = False
            KutukKalite_Filtreli_getir()
            TEDARIKCI_OZEL()
            URUNBILGI_OZEL()
        End If

        If drpMamulTip.Text = "Kangal Doğrultma" Then
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
        End If

        If drpMamulTip.Text = "Çubuk" Then
            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
        End If

        If drpMamulTip.Text = "Kutuk" Then
            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtKoseRadyusu.Enabled = True
            txtRombiklik.Enabled = True
            txtDogSapma.Enabled = True
            txtBurulma.Enabled = True
            txtKesmeSekli.Enabled = True
            'Analiz_getir_kalite()
        Else
            'txtt1.Enabled = False
            'txtt2.Enabled = False
            'txtt3.Enabled = False
            'txtt4.Enabled = False
            'txtt5.Enabled = False

        End If

        '    drpMarka.Items.Clear()
        drpND.SelectedIndex = 0

    End Sub

    Private Sub Analiz_getir_kalite(ByVal SipNo_analiz, ByVal RevizNo_analiz, ByVal LotNo_analiz, ByVal Kalite_analiz)

        Dim Sql As String
        Dim DbConn As New ConnectGiris
        Dim sayi As String

        Sql = " SELECT COUNT(SIP_NO) FROM MRKSIP_KUTUK_ANALIZ  " _
            & " WHERE SIP_NO='" & SipNo_analiz & "'" _
            & " AND REVIZ_NO='" & RevizNo_analiz & "'"
        '& " AND LOT_NO='" & LotNo_analiz & "'"
        DbConn.Sayac(Sql)
        sayi = DbConn.GeriDonenRakam
        DbConn.Kapat()

        If sayi = 0 Then
            'SET TABLOSUNDAN KALİTEYE GÖRE VERİ GETİRECEZ..
            analileriGetir_kalite_set(Kalite_analiz)
        Else
            'İÇERDE KAYIT VARSA VERİLERİ GETİRECEGİZ..
            analileriGetir(SipNo_analiz, RevizNo_analiz, LotNo_analiz)
        End If




    End Sub
    Sub dhhstandartGetir()

        Dim DbConn As New ConnectGiris
        drpStandart.Items.Clear()
        SQL = " SELECT DISTINCT ACK FROM URTTNM.STANDART where AYRILMA='DHH'" _
            & " ORDER BY ACK "
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            drpStandart.Items.Add(DbConn.MyDataReader.Item("ACK"))
        End While
        DbConn.Kapat()
        drpStandart.Items.Insert(0, New System.Web.UI.WebControls.ListItem(String.Empty, String.Empty))
        drpStandart.SelectedIndex = 0
        If PrgKod = "ICPIYS" Then
            drpStandart.Items.Add("-")
            drpStandart.Text = "-"
            drpStandart.Text = "TS 708"
            dhhStdKalitebul()
            spreadDilerCapDoldur()
        End If
    End Sub
    Sub dchstandartGetir()

        Dim DbConn As New ConnectGiris
        drpStandart.Items.Clear()
        drpStandart.Items.Add("-")
        drpStandart.Text = "-"
        SQL = " SELECT DISTINCT ACK FROM URTTNM.STANDART where AYRILMA='DCH'" _
            & " ORDER BY ACK "
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            drpStandart.Items.Add(DbConn.MyDataReader.Item("ACK"))
        End While
        DbConn.Kapat()



        drpStandart.Items.Insert(0, New System.Web.UI.WebControls.ListItem(String.Empty, String.Empty))
        drpStandart.SelectedIndex = 0

    End Sub
    Sub filmasinStandartGetir()
        Dim DbConn As New ConnectOracleFilmasin
        drpStandart.Items.Clear()
        SQL = " SELECT DISTINCT STANDART FROM FILMASIN.KALITESINIF " _
            & " ORDER BY STANDART "
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            drpStandart.Items.Add(DbConn.MyDataReader.Item("STANDART"))
        End While
        DbConn.Kapat()
        drpStandart.Items.Insert(0, New System.Web.UI.WebControls.ListItem(String.Empty, String.Empty))
        drpStandart.SelectedIndex = 0
        If PrgKod = "ICPIYS" Then
            drpStandart.Text = "TS 708"
            'drpStandart.Text = "-"
            filmasinKaliteGetir()
        End If
    End Sub
    Sub filmasinKaliteGetir()

        Dim DbConn As New ConnectOracleFilmasin
        drpKalite.Items.Clear()
        drpKalite.Items.Insert(0, New System.Web.UI.WebControls.ListItem(String.Empty, String.Empty))

        SQL = " SELECT DISTINCT MAM_KALITE FROM FILMASIN.KALITESINIF " _
            & " WHERE STANDART='" & drpStandart.Text & "'" _
            & " ORDER BY MAM_KALITE "

        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            drpKalite.Items.Add(DbConn.MyDataReader.Item("MAM_KALITE"))
        End While
        DbConn.Kapat()
        drpKalite.SelectedIndex = 0

    End Sub
    Sub dhhkalitegetir()
        Dim DbConn As New ConnectGiris
        drpKalite.Items.Clear()
        'drpKalite.Items.Add("-")
        drpKalite.Items.Insert(0, New System.Web.UI.WebControls.ListItem(String.Empty, String.Empty))
        SQL = " SELECT ACK FROM URTTNM.KALITE where AYRILMA='DHH'" _
            & " ORDER BY ACK "
        DbConn.RaporWhile(SQL)
        Dim i As Int16 = 0
        While DbConn.MyDataReader.Read
            drpKalite.Items.Add(DbConn.MyDataReader.Item("ACK"))
            i += 1
        End While
        DbConn.Kapat()
        drpKalite.SelectedIndex = 0
    End Sub
    Sub dchkalitegetir()
        Dim DbConn As New ConnectGiris
        drpKalite.Items.Clear()
        'drpKalite.Items.Add("-")
        drpKalite.Items.Insert(0, New System.Web.UI.WebControls.ListItem(String.Empty, String.Empty))
        SQL = " SELECT ACK FROM URTTNM.KALITE where AYRILMA='DCH'" _
            & " ORDER BY ACK "
        DbConn.RaporWhile(SQL)
        Dim i As Int16 = 0
        While DbConn.MyDataReader.Read
            drpKalite.Items.Add(DbConn.MyDataReader.Item("ACK"))

            i += 1
        End While
        DbConn.Kapat()
        drpKalite.SelectedIndex = 0
    End Sub
    Private Sub dhhStdKalitebul()
        Dim StandartKodu = 0
        Dim sql, i
        Dim DbConn As New ConnectGiris

        sql = "SELECT DISTINCT URTTNM.STANDART.KOD FROM URTTNM.STANDART  " _
                & " WHERE URTTNM.STANDART.FRMNUM='D'" _
                & " AND URTTNM.STANDART.AYRILMA='DHH'" _
                & " AND URTTNM.STANDART.ACK='" & drpStandart.Text & "'"

        DbConn.RaporWhile(sql)
        While DbConn.MyDataReader.Read
            StandartKodu = DbConn.MyDataReader.GetString(0).ToString()
        End While
        DbConn.Kapat()

        drpKalite.Items.Clear()
        'drpKalite.Items.Add("-")
        drpKalite.Items.Insert(0, New System.Web.UI.WebControls.ListItem(String.Empty, String.Empty))
        sql = "SELECT URTTNM.STDKLT.KALITEKOD FROM URTTNM.STDKLT WHERE URTTNM.STDKLT.STDKOD=" & StandartKodu
        DbConn.RaporWhile(sql)

        i = 1
        While DbConn.MyDataReader.Read
            KaliteAckBul(DbConn.MyDataReader.GetString(0).ToString())
            drpKalite.Items.Add(KaliteAck)
            i = i + 1
        End While
        DbConn.Kapat()
        drpKalite.SelectedIndex = 0
    End Sub
    Private Sub flmKalitebul()
        Dim StandartKodu = 0
        Dim sql, i
        Dim DbConn As New ConnectGiris
        drpKalite.Items.Clear()
        sql = "SELECT DISTINCT URTTNM.KALITE.ACK FROM URTTNM.KALITE  " _
                & " WHERE URTTNM.KALITE.FRMNUM='F'" _
                & " AND URTTNM.KALITE.AYRILMA='FLM'" _
                & " ORDER BY URTTNM.KALITE.ACK "

        DbConn.RaporWhile(sql)
        drpKalite.Items.Add("")
        While DbConn.MyDataReader.Read
            drpKalite.Items.Add(DbConn.MyDataReader.GetString(0).ToString())
        End While
        DbConn.Kapat()
        drpKalite.SelectedIndex = 0

    End Sub
    Private Sub CHStdKalitebul()
        Dim StandartKodu = 0
        Dim sql, i
        Dim DbConn As New ConnectGiris
        drpKalite.Items.Clear()
        sql = "SELECT DISTINCT URTTNM.KALITE.ACK FROM URTTNM.KALITE  " _
                & " WHERE URTTNM.KALITE.FRMNUM='D'" _
                & " AND URTTNM.KALITE.AYRILMA='DCH'" _
                & " ORDER BY URTTNM.KALITE.ACK "

        DbConn.RaporWhile(sql)
        drpKalite.Items.Add("")
        While DbConn.MyDataReader.Read
            drpKalite.Items.Add(DbConn.MyDataReader.GetString(0).ToString())
        End While
        DbConn.Kapat()
        drpKalite.SelectedIndex = 0

    End Sub


    Protected Sub fpEbatMiktar_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles fpEbatMiktar.ButtonCommand

        If e.CommandArgument.X = 0 And e.CommandArgument.y = 2 And e.CommandName = "SatirEkle" Then
            fpEbatMiktar.Sheets(0).RowCount += 1
        ElseIf e.CommandName = "YUKARI" And e.CommandArgument.X <> "-1" Then
            'alanlariAcKapatMamulTip(fpEbatMiktar.Sheets(0).Cells(e.CommandArgument.X, 3).Text)
            Dim satir = e.CommandArgument.X
            fpEbatMiktar.Sheets(0).RemoveRows(Convert.ToInt32(satir), 1)
            Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)

            Dim toplamMiktar = 0
            For index As Integer = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                toplamMiktar += fpEbatMiktar.Sheets(0).Cells(index, 11).Text
            Next
            txtToplamMik.Text = toplamMiktar

        ElseIf e.CommandName = "SIL" And e.CommandArgument.X <> "-1" Then
            'alanlariAcKapatMamulTip(fpEbatMiktar.Sheets(0).Cells(e.CommandArgument.X, 3).Text)
            Dim satir = e.CommandArgument.X
            satirlarYukari(satir)
            fpEbatMiktar.Sheets(0).RemoveRows(Convert.ToInt32(satir), 1)
            Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)

            Dim toplamMiktar = 0
            For index As Integer = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                toplamMiktar += fpEbatMiktar.Sheets(0).Cells(index, 11).Text
            Next
            txtToplamMik.Text = toplamMiktar

        ElseIf e.CommandName = "Incele" And e.CommandArgument.X <> "-1" Then
            Dim satir = e.CommandArgument.X
            'alanlariAcKapatMamulTip(fpEbatMiktar.Sheets(0).Cells(e.CommandArgument.X, 3).Text)
            satirlarYukari(satir)
            'fpEbatMiktar.Sheets(0).RemoveRows(Convert.ToInt32(satir), 1)
            Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)
        End If
    End Sub
    Sub alanlariAcKapatMamulTip(ByVal gelenMamulTip As String)

        If gelenMamulTip = "Kutuk" Then
            txtEbatTolNeg.Enabled = True
            txtEbatTolPoz.Enabled = True

            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtKoseRadyusu.Enabled = True
            txtRombiklik.Enabled = True
            txtDogSapma.Enabled = True
            txtBurulma.Enabled = True
            txtKesmeSekli.Enabled = True

            drpUrunBilgi.Enabled = False
            drpKutukTedarikci.Enabled = False
            txtKutukKalite.Enabled = False
            txtMusteriAdi.Enabled = False
            drpRotorTip.Enabled = False

            txtKoseRadyusu.Enabled = True
            txtRombiklik.Enabled = True
            txtDogSapma.Enabled = True
            txtBurulma.Enabled = True
            txtKesmeSekli.Enabled = True

        ElseIf gelenMamulTip = "Kangal" Then
            drpBoy.Enabled = False
            txtBoyTolNeg.Enabled = False
            txtBoyTolPoz.Enabled = False
            txtEbatTolNeg.Enabled = True
            txtEbatTolPoz.Enabled = True

            drpUrunBilgi.Enabled = True
            drpKutukTedarikci.Enabled = True
            txtKutukKalite.Enabled = True
            txtMusteriAdi.Enabled = True
            drpRotorTip.Enabled = True

            txtKoseRadyusu.Enabled = False
            txtRombiklik.Enabled = False
            txtDogSapma.Enabled = False
            txtBurulma.Enabled = False
            txtKesmeSekli.Enabled = False

        ElseIf gelenMamulTip = "Kangal Doğrultma" Then
            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtEbatTolNeg.Enabled = True
            txtEbatTolPoz.Enabled = True

            drpUrunBilgi.Enabled = True
            drpKutukTedarikci.Enabled = True
            txtKutukKalite.Enabled = True
            txtMusteriAdi.Enabled = True
            drpRotorTip.Enabled = True

            txtKoseRadyusu.Enabled = False
            txtRombiklik.Enabled = False
            txtDogSapma.Enabled = False
            txtBurulma.Enabled = False
            txtKesmeSekli.Enabled = False
        ElseIf gelenMamulTip = "Çubuk" Then
            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtEbatTolNeg.Enabled = False
            txtEbatTolPoz.Enabled = False
            drpUrunBilgi.Enabled = False
            drpKutukTedarikci.Enabled = False
            txtKutukKalite.Enabled = False
            txtMusteriAdi.Enabled = False
            drpRotorTip.Enabled = False

            txtKoseRadyusu.Enabled = False
            txtRombiklik.Enabled = False
            txtDogSapma.Enabled = False
            txtBurulma.Enabled = False
            txtKesmeSekli.Enabled = False
        End If
    End Sub

    Private Sub satirlarYukari(ByVal satir As String)


        txtLotNo.Text = fpEbatMiktar.Sheets(0).Cells(satir, 2).Text




        If drpMamulTip.Text = "Kangal" Then
            If drpStandart.Text = "-" Then filmasinStandartGetir()
            drpBoy.Text = ""
            drpRotorTip.Items.Clear()
            drpRotorTip.Items.Add("")
            drpRotorTip.Items.Add("Büyük Rotor")
            drpRotorTip.Items.Add("Küçük Rotor")
            drpRotorTip.Text = ""
        ElseIf drpMamulTip.Text = "Kangal Doğrultma" Then
            drpRotorTip.Items.Clear()
            If drpStandart.Text = "-" Then filmasinStandartGetir()
        ElseIf drpMamulTip.Text = "Çubuk" Then
            drpRotorTip.Items.Clear()
            If drpStandart.Text = "-" Then dhhstandartGetir()
        ElseIf drpMamulTip.Text = "Kutuk" Then


            dchstandartGetir()
            If drpCap.Text = "" Then kutukCapDoldur()

            'If drpStandart.Text = "-" Then dchstandartGetir()
            'dchkalitegetir()
            'kutukCapDoldur()

            'CHStdKalitebul() ' buna belkı gerek yok


            txtKoseRadyusu.Enabled = True
            txtRombiklik.Enabled = True
            txtDogSapma.Enabled = True
            txtBurulma.Enabled = True
            txtKesmeSekli.Enabled = True
        End If




        '**************************** GRID BILGILERINI COMBOLARA YAZDIR ************************************

        drpMamulTip.Text = fpEbatMiktar.Sheets(0).Cells(satir, 3).Text

        drpStandart.Items.Add(fpEbatMiktar.Sheets(0).Cells(satir, 4).Text)
        drpStandart.Text = fpEbatMiktar.Sheets(0).Cells(satir, 4).Text

        drpKalite.Items.Add(fpEbatMiktar.Sheets(0).Cells(satir, 5).Text)
        drpKalite.Text = fpEbatMiktar.Sheets(0).Cells(satir, 5).Text


        drpCap.Items.Add(fpEbatMiktar.Sheets(0).Cells(satir, 6).Text)
        drpCap.Text = fpEbatMiktar.Sheets(0).Cells(satir, 6).Text


        drpND.Text = fpEbatMiktar.Sheets(0).Cells(satir, 7).Text

        drpBoy.Items.Add(fpEbatMiktar.Sheets(0).Cells(satir, 8).Text)
        drpBoy.Text = fpEbatMiktar.Sheets(0).Cells(satir, 8).Text
        '**************************** ************************************


        txtBoyTolNeg.Text = fpEbatMiktar.Sheets(0).Cells(satir, 9).Text
        txtBoyTolPoz.Text = fpEbatMiktar.Sheets(0).Cells(satir, 10).Text
        txtMiktar.Text = fpEbatMiktar.Sheets(0).Cells(satir, 11).Text

        txtCubukSayisi.Text = fpEbatMiktar.Sheets(0).Cells(satir, 12).Text
        txtBirimAgirlik.Text = fpEbatMiktar.Sheets(0).Cells(satir, 13).Text
        txtPaketAgirlik.Text = fpEbatMiktar.Sheets(0).Cells(satir, 14).Text

        txtHadde_Tol_N.Text = fpEbatMiktar.Sheets(0).Cells(satir, 15).Text
        txtHadde_Tol_P.Text = fpEbatMiktar.Sheets(0).Cells(satir, 16).Text

        drpRotorTip.Text = fpEbatMiktar.Sheets(0).Cells(satir, 17).Text

        drpUrunBilgi.Text = fpEbatMiktar.Sheets(0).Cells(satir, 18).Text
        drpKutukTedarikci.Text = fpEbatMiktar.Sheets(0).Cells(satir, 19).Text
        txtKutukKalite.Text = fpEbatMiktar.Sheets(0).Cells(satir, 20).Text

        dateTerminBas.Text = fpEbatMiktar.Sheets(0).Cells(satir, 21).Text
        dateTerminBit.Text = fpEbatMiktar.Sheets(0).Cells(satir, 22).Text

        txtBosLiman.Text = fpEbatMiktar.Sheets(0).Cells(satir, 23).Text
        txtBoyama.Text = fpEbatMiktar.Sheets(0).Cells(satir, 24).Text

        txtKoseRadyusu.Text = fpEbatMiktar.Sheets(0).Cells(satir, 25).Text
        txtRombiklik.Text = fpEbatMiktar.Sheets(0).Cells(satir, 26).Text
        txtDogSapma.Text = fpEbatMiktar.Sheets(0).Cells(satir, 27).Text
        txtBurulma.Text = fpEbatMiktar.Sheets(0).Cells(satir, 28).Text
        txtKesmeSekli.Text = fpEbatMiktar.Sheets(0).Cells(satir, 29).Text

        txtEbatTolNeg.Text = fpEbatMiktar.Sheets(0).Cells(satir, 30).Text
        txtEbatTolPoz.Text = fpEbatMiktar.Sheets(0).Cells(satir, 31).Text

        txtCapMikTolMin.Text = fpEbatMiktar.Sheets(0).Cells(satir, 32).Text
        txtCapMikTolMax.Text = fpEbatMiktar.Sheets(0).Cells(satir, 33).Text

        txtTopMikTolMin.Text = fpEbatMiktar.Sheets(0).Cells(satir, 34).Text
        txtTopMikTolMax.Text = fpEbatMiktar.Sheets(0).Cells(satir, 35).Text


        If fpEbatMiktar.Sheets(0).Cells(satir, 36).Text = "0" Then fpEbatMiktar.Sheets(0).Cells(satir, 36).Text = ""

        txtMusteriAdi.Text = fpEbatMiktar.Sheets(0).Cells(satir, 36).Text 'zafer

    End Sub

    Protected Sub drpND_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpND.SelectedIndexChanged
        If drpND.Text = "N" Then
            drpMarka.Items.Clear()
            drpMarka.Items.Add("")
            If drpMamulTip.Text = "Çubuk" Then
                '    'Dim markaAdi() As String
                '    Try
                '        Dim DbConn As New ConnectGiris
                '        SQL = " SELECT MARKA_ADI FROM URTTNM.MARKA " _
                '            & " WHERE STANDART ='" & drpStandart.Text & "'" _
                '            & " AND MAMKALITE ='" & drpKalite.Text & "'"
                '        DbConn.RaporWhile(SQL)
                '        While DbConn.MyDataReader.Read
                '            'markaAdi = Split(DbConn.MyDataReader.Item("MARKA"), "\")
                '            'drpMarka.Items.Add(Left(markaAdi(9), markaAdi(9).Length - 4).ToString())
                '            drpMarka.Items.Add(DbConn.MyDataReader.Item("MARKA_ADI") & "")
                '        End While
                '        DbConn.Kapat()
                '    Catch ex As Exception
                '        'ShowMessage("Standart ve Kaliteye uygun Markalar getirilirken hata oluştu")
                '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Standart ve Kaliteye uygun Markalar getirilirken hata oluştu.');", True)
                '        txtKayitDurumu.BackColor = Drawing.Color.Red
                '        txtKayitDurumu.Text = "Standart ve Kaliteye uygun Markalar getirilirken hata oluştu"
                '    End Try
                'Else
                '    Try
                '        Dim DbConn As New ConnectOracleFilmasin
                '        SQL = " SELECT MARKA_ADI FROM FILMASIN.MARKA " _
                '            & " WHERE STANDART ='" & drpStandart.Text & "'" _
                '            & " AND MAMKALITE ='" & drpKalite.Text & "'"
                '        DbConn.RaporWhile(SQL)
                '        While DbConn.MyDataReader.Read
                '            'markaAdi = Split(DbConn.MyDataReader.Item("MARKA"), "\")
                '            'drpMarka.Items.Add(Left(markaAdi(9), markaAdi(9).Length - 4).ToString())
                '            drpMarka.Items.Add(DbConn.MyDataReader.Item("MARKA_ADI") & "")
                '        End While
                '        DbConn.Kapat()
                '    Catch ex As Exception
                '        'ShowMessage("Standart ve Kaliteye uygun Markalar getirilirken hata oluştu")
                '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Standart ve Kaliteye uygun Markalar getirilirken hata oluştu.');", True)
                '        txtKayitDurumu.BackColor = Drawing.Color.Red
                '        txtKayitDurumu.Text = "Standart ve Kaliteye uygun Markalar getirilirken hata oluştu"
                '    End Try
            End If
        ElseIf drpND.Text = "D" Then
            drpMarka.Items.Clear()
        End If
        If drpMamulTip.Text = "Kangal" Then
            drpBoy.Text = ""
            txtBoyTolNeg.Text = ""
            txtBoyTolPoz.Text = ""
            drpBoy.Enabled = False
            txtBoyTolNeg.Enabled = False
            txtBoyTolPoz.Enabled = False
        ElseIf drpMamulTip.Text = "Kangal Doğrultma" Then
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
        ElseIf drpMamulTip.Text = "Çubuk" Then
            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        fpSiparisGetir.Rows.Count = 0
        If drpSiparisDurum1.Text = "Tümü" Then
            Rapor_New3()
        Else
            If txtSipNoRapor.Text = "" Then Rapor_New()
            If txtSipNoRapor.Text <> "" Then Rapor_New2()
        End If
    End Sub

    Public Shared Sub MailGonder_Attach(ByVal IslemiYapanKısi As String, ByVal MAIL_ATILCAK_ADRES As String, ByVal MailDurumu As String, ByVal Sipno As String, ByVal RevizyonNo As String, ByVal ProgramGrubu As String)
        Dim MESAJ1
        Dim mailack, MailGittimi
        Dim BAslıkMesajı, SubjectMesajı, mailsmtp

        MailGittimi = "H"

        Dim Attachment As System.Web.Mail.MailAttachment
        Dim message As New System.Web.Mail.MailMessage

        Dim resource As LinkedResource
        Dim View As AlternateView


        Try
            mailack = "Onaylanan " & Sipno & "/" & RevizyonNo & "'lu Siparişin PDF Dosyası"


            If ProgramGrubu = "ICPIYS" Then
                MESAJ1 = "<body>" _
                                    & "<font FACE='Agency FB'>" _
                                    & "<p></p>" _
                                    & "</font><font FACE='Agency FB' SIZE='4' >" _
                                    & "<p>" & "Sayın Yetkili," & "</p>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p ALIGN='JUSTIFY'>" _
                                    & " Aşağıda belirtilen sipariş sistem tarafından onaylanmış ve tarafınıza bir sonraki işlem için gönderilmiştir." _
                                    & "<b>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p ALIGN='JUSTIFY'>" _
                                    & "<p>" & "İşlemi Yapan Kullanıcı=" & IslemiYapanKısi & "</p>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p ALIGN='JUSTIFY'>" _
                                    & "<font color=red><p></font> " & "Durumu : " & MailDurumu & "</p>" _
                                    & "<p></p>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p ALIGN='JUSTIFY'>" _
                                    & "<p>" & "SipNo=" & Sipno & " Revizyon No:" & RevizyonNo & "</p>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p>&nbsp</p>" _
                                    & "<p>&nbsp</p>" _
                                    & "</font>" _
                                    & "</body>"

            Else
                MESAJ1 = "<body>" _
                               & "<font FACE='Agency FB'>" _
                               & "<p></p>" _
                               & "</font><font FACE='Agency FB' SIZE='4' >" _
                               & "<p>" & "Sayın Yetkili," & "</p>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p ALIGN='JUSTIFY'>" _
                               & " Aşağıda belirtilen sipariş sistem tarafından onaylanmış ve tarafınıza bir sonraki işlem için gönderilmiştir." _
                               & "<b>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p ALIGN='JUSTIFY'>" _
                               & "<p>" & "İşlemi Yapan Kullanıcı=" & IslemiYapanKısi & "</p>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p ALIGN='JUSTIFY'>" _
                               & "<font color=red><p></font> " & "Durumu : " & MailDurumu & "</p>" _
                               & "<p></p>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p ALIGN='JUSTIFY'>" _
                               & "<p>" & "SipNo=" & Sipno & " Revizyon No:" & RevizyonNo & "</p>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p>&nbsp</p>" _
                               & "<p>&nbsp</p>" _
                               & "<a href='http://192.168.198.8'> Onaylamak İçin Sisteme Burdan Girebilirsiniz</a> </p>" _
                               & "</font>" _
                               & "</body>"
            End If


            With message

                Dim dosyası = Sipno & "_" & RevizyonNo & ".pdf"
                Dim FilePath As String
                FilePath = System.Web.HttpContext.Current.Server.MapPath("~/PDF/" & dosyası)
                'FilePath = ("//192.168.198.8/PDF/" & dosyası)
                Attachment = New MailAttachment(FilePath)
                message.Attachments.Add(Attachment)


                .From = "Diler_Uretim_Planlama@dilerhld.com"
                '.To = "adnanguler@dilerhld.com"  
                .To = MAIL_ATILCAK_ADRES
                .Subject = mailack
                .Body = MESAJ1


                .BodyFormat = Web.Mail.MailFormat.Html
                ' For authentication...
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "DILEREXCH.dilerhld.com")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "Dilerplanlama")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "planlama2014")
                '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "turgayener")
                '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "denver")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 specifies NTLM, 1 for basic, 0 for none
            End With

            Dim smtp As System.Web.Mail.SmtpMail
            smtp.SmtpServer = mailsmtp
            smtp.Send(message)
            MailGittimi = "E"


        Catch


            '*************************** hataya dustu MALI EKDOSY OLMAN GONDER ********************************
            MailGittimi = "H"

            With message

                .From = "Diler_Uretim_Planlama@dilerhld.com"
                .To = MAIL_ATILCAK_ADRES
                .Subject = mailack
                .Body = MESAJ1

                .BodyFormat = Web.Mail.MailFormat.Html
                ' For authentication...
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "DILEREXCH.dilerhld.com")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "Dilerplanlama")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "planlama2014")
                '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "turgayener")
                '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "denver")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 specifies NTLM, 1 for basic, 0 for none
            End With
            Dim smtp As System.Web.Mail.SmtpMail
            smtp.SmtpServer = mailsmtp
            smtp.Send(message)
            MailGittimi = "E"

        End Try

    End Sub

    Public Shared Sub MailGonder(ByVal IslemiYapanKısi As String, ByVal MAIL_ATILCAK_ADRES As String, ByVal MailDurumu As String, ByVal Sipno As String, ByVal RevizyonNo As String, ByVal ProgramGrubu As String)

        Dim mailack, MailGittimi
        Dim BAslıkMesajı, SubjectMesajı, mailsmtp
        MailGittimi = "H"

        Dim Attachment As System.Web.Mail.MailAttachment
        Dim message As New System.Web.Mail.MailMessage

        Dim resource As LinkedResource
        Dim View As AlternateView

        Try
            mailack = "SİPARİŞ PROGRAMI BILDIRIM MAILI"
            Dim MESAJ1

            If ProgramGrubu = "ICPIYS" Then
                MESAJ1 = "<body>" _
                                    & "<font FACE='Agency FB'>" _
                                    & "<p></p>" _
                                    & "</font><font FACE='Agency FB' SIZE='4' >" _
                                    & "<p>" & "Sayın Yetkili," & "</p>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p ALIGN='JUSTIFY'>" _
                                    & " Aşağıda belirtilen sipariş sistem tarafından onaylanmış ve tarafınıza bir sonraki işlem için gönderilmiştir." _
                                    & "<b>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p ALIGN='JUSTIFY'>" _
                                    & "<p>" & "İşlemi Yapan Kullanıcı=" & IslemiYapanKısi & "</p>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p ALIGN='JUSTIFY'>" _
                                    & "<font color=red><p></font> " & "Durumu : " & MailDurumu & "</p>" _
                                    & "<p></p>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p ALIGN='JUSTIFY'>" _
                                    & "<p>" & "SipNo=" & Sipno & " Revizyon No:" & RevizyonNo & "</p>" _
                                    & "<p ALIGN='JUSTIFY'></p>" _
                                    & "<p>&nbsp</p>" _
                                    & "<p>&nbsp</p>" _
                                    & "</font>" _
                                    & "</body>"

            Else
                MESAJ1 = "<body>" _
                               & "<font FACE='Agency FB'>" _
                               & "<p></p>" _
                               & "</font><font FACE='Agency FB' SIZE='4' >" _
                               & "<p>" & "Sayın Yetkili," & "</p>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p ALIGN='JUSTIFY'>" _
                               & " Aşağıda belirtilen sipariş sistem tarafından onaylanmış ve tarafınıza bir sonraki işlem için gönderilmiştir." _
                               & "<b>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p ALIGN='JUSTIFY'>" _
                               & "<p>" & "İşlemi Yapan Kullanıcı=" & IslemiYapanKısi & "</p>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p ALIGN='JUSTIFY'>" _
                               & "<font color=red><p></font> " & "Durumu : " & MailDurumu & "</p>" _
                               & "<p></p>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p ALIGN='JUSTIFY'>" _
                               & "<p>" & "SipNo=" & Sipno & " Revizyon No:" & RevizyonNo & "</p>" _
                               & "<p ALIGN='JUSTIFY'></p>" _
                               & "<p>&nbsp</p>" _
                               & "<p>&nbsp</p>" _
                               & "<a href='http://192.168.198.8'> Onaylamak İçin Sisteme Burdan Girebilirsiniz</a> </p>" _
                               & "</font>" _
                               & "</body>"
            End If


            With message

                'Dim dosyası = Sipno & "_" & RevizyonNo & ".pdf"
                'Dim FilePath As String
                'FilePath = System.Web.HttpContext.Current.Server.MapPath("~/PDF/" & dosyası)
                'Attachment = New MailAttachment(FilePath)
                'message.Attachments.Add(Attachment)




                .From = "Diler_Uretim_Planlama@dilerhld.com"
                '.To = "adnanguler@dilerhld.com"  
                .To = MAIL_ATILCAK_ADRES
                .Subject = mailack
                .Body = MESAJ1


                .BodyFormat = Web.Mail.MailFormat.Html
                ' For authentication...
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "DILEREXCH.dilerhld.com")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "Dilerplanlama")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "planlama2014")
                '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "turgayener")
                '.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "denver")
                .Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) '2 specifies NTLM, 1 for basic, 0 for none
            End With

            Dim smtp As System.Web.Mail.SmtpMail
            smtp.SmtpServer = mailsmtp
            smtp.Send(message)
            MailGittimi = "E"
        Catch
            MailGittimi = "H"

            'MessageBox.Show("E-mail gönderilemedi", "Smtp Mail", MessageBoxButtons.OK)
            'ShowMessage("E-mail gönderilemedi", "Smtp Mail")
        End Try

    End Sub
    Sub MUSTERIADI_BUL(ByVal gelenSipNo, ByVal gelenRevizNo)

        MUSTERIADI_RAPOR = ""

        Dim DbConn As New ConnectGiris
        Dim DbConnEski As New ConnectGiris
        Dim AnaToplam = 0
        Dim SQL1, SQL2

        SQL = " SELECT * FROM MRKSIP_CBK_FLM_ALT " _
            & " WHERE SIP_NO= '" & gelenSipNo & "'" _
            & " AND REVIZ_NO= " & gelenRevizNo

        DbConn.RaporWhile(SQL)
        Dim i = 0
        While DbConn.MyDataReader.Read
            MUSTERIADI_RAPOR = DbConn.MyDataReader.Item("MUSTERIADI")
        End While
        DbConn.Kapat()

    End Sub
    Private Sub Rapor_New()


        Try
            'tabAnaliz.ActiveTab = TabPanel1

            Dim s1, s2, s3, s4, s5
            Dim ToplamKayitSayisi
            Dim sip_No As String = ""
            sip_No = txtSipNoRapor.Text.Trim

            If PrgKod = "DISTIC" Or PrgKod = "OZLCLK" Or PrgKod = "DISOZL" Or PrgKod = "KTKTLP" Then
                If drpSiparisDurum1.Text = "Yeni Sipariş" Then GelecekDrm = -1
                If drpSiparisDurum1.Text = "Giriş Onayı Bekleyen" Then GelecekDrm = 0
                If drpSiparisDurum1.Text = "Kontrol Bekleyen" Then GelecekDrm = 1
                If drpSiparisDurum1.Text = "Müdür Onayı Bekleyen" Then GelecekDrm = 2
                If drpSiparisDurum1.Text = "Planlamaya Yönlendirilen Siparişler" Then GelecekDrm = 3
                If drpSiparisDurum1.Text = "Uretilecek Siparisler" Then GelecekDrm = 4
                If drpSiparisDurum1.Text = "Uretimi Tamamlanmıs Siparisler" Then GelecekDrm = 90
                If drpSiparisDurum1.Text = "Iptal Edilen Siparisler" Then GelecekDrm = 88
                If drpSiparisDurum1.Text = "Revize Edilen Siparisler" Then GelecekDrm = 99
            End If
            If PrgKod = "ICPIYS" Then
                If drpSiparisDurum1.Text = "Yeni Sipariş" Then GelecekDrm = -1
                If drpSiparisDurum1.Text = "Giriş Onayı Bekleyen" Then GelecekDrm = 0
                If drpSiparisDurum1.Text = "Kontrol Bekleyen" Then GelecekDrm = 0
                If drpSiparisDurum1.Text = "Müdür Onayı Bekleyen" Then GelecekDrm = 2
                If drpSiparisDurum1.Text = "Planlamaya Yönlendirilen Siparişler" Then GelecekDrm = 3
                If drpSiparisDurum1.Text = "Uretilecek Siparisler" Then GelecekDrm = 4
                If drpSiparisDurum1.Text = "Uretimi Tamamlanmıs Siparisler" Then GelecekDrm = 90
                If drpSiparisDurum1.Text = "Iptal Edilen Siparisler" Then GelecekDrm = 88
                If drpSiparisDurum1.Text = "Revize Edilen Siparisler" Then GelecekDrm = 99
            End If


            Dim DbConn As New ConnectGiris


            If PrgKod = "URTPLN" Then
                GelecekDrm = 4
                If drpSiparisDurum1.Text = "Yeni Sipariş" Then GelecekDrm = -1
                If drpSiparisDurum1.Text = "Giriş Onayı Bekleyen" Then GelecekDrm = 0
                If drpSiparisDurum1.Text = "Kontrol Bekleyen" Then GelecekDrm = 1
                If drpSiparisDurum1.Text = "Müdür Onayı Bekleyen" Then GelecekDrm = 2
                If drpSiparisDurum1.Text = "Planlamaya Yönlendirilen Siparişler" Then GelecekDrm = 3
                If drpSiparisDurum1.Text = "Uretilecek Siparisler" Then GelecekDrm = 4
                If drpSiparisDurum1.Text = "Uretimi Tamamlanmıs Siparisler" Then GelecekDrm = 90
                If drpSiparisDurum1.Text = "Iptal Edilen Siparisler" Then GelecekDrm = 88
                If drpSiparisDurum1.Text = "Revize Edilen Siparisler" Then GelecekDrm = 99

                SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "' " _
                & " ORDER BY KAYIT_TAR DESC, SIP_NO, REVIZ_NO"
            Else
                'DISOZL
                If PrgKod = "DISOZL" Then
                    SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                       & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "' " _
                       & " AND SIPARIS_GRUBU <>'ICPIYS'" _
                        & " ORDER BY KAYIT_TAR DESC, SIP_NO, REVIZ_NO"

                Else
                    If (PrgKod = "OZLCLK") Then
                        SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                           & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "' " _
                           & " AND ((SIPARIS_GRUBU ='" & "DISTIC" & "'" & " AND SIPARIS_SAHIBI ='" & Kullanıcı & "')" _
                           & " OR (SIPARIS_GRUBU ='" & "OZLCLK" & "'))" _
                           & " ORDER BY KAYIT_TAR DESC, SIP_NO, REVIZ_NO"

                    Else
                        If (PrgKod = "DISTIC" And Program_YetkNumarasi = 2) Then
                            ' yani dış ticarette kontrolcu gırmışse sadece kendine yonlenen siparişleri gorsun
                            SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                            & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "' " _
                            & " AND SIPARIS_GRUBU ='" & PrgKod & "'" _
                            & " AND SIPARIS_SAHIBI ='" & Kullanıcı & "'" _
                            & " ORDER BY KAYIT_TAR DESC, SIP_NO, REVIZ_NO"
                        Else

                            SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                                 & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "' " _
                                & " AND SIPARIS_GRUBU ='" & PrgKod & "'" _
                                & " ORDER BY KAYIT_TAR DESC, SIP_NO, REVIZ_NO"
                        End If

                    End If

                End If

            End If

            DbConn.RaporWhile(SQL)

            Dim i As Int16 = 0
            fpSiparisGetir.Sheets(0).RowCount = 0
            Dim kacıncı, SipGir, SipGirOnay, SipKontrol, SipOnay, SipUrtonay
            Dim DbConnToplam As New ConnectGiris

            While DbConn.MyDataReader.Read

                fpSiparisGetir.Sheets(0).RowCount += 1
                fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")


                If PrgKod = "OZLCLK" Then
                    MUSTERIADI_BUL(DbConn.MyDataReader.Item("SIP_NO"), DbConn.MyDataReader.Item("REVIZ_NO"))

                    If IsDBNull(MUSTERIADI_RAPOR) Then
                    Else
                        fpSiparisGetir.Sheets(0).Cells(i, 3).Text = MUSTERIADI_RAPOR
                        fpSiparisGetir.Sheets(0).Columns(5).Visible = False
                        fpSiparisGetir.Sheets(0).Columns(6).Visible = False
                        fpSiparisGetir.Sheets(0).Columns(7).Visible = False
                        fpSiparisGetir.Sheets(0).Columns(3).Width = 300
                        fpSiparisGetir.Sheets(0).Columns(2).Width = 70
                        fpSiparisGetir.Sheets(0).Columns(4).Width = 60
                        fpSiparisGetir.Sheets(0).Columns(0).Width = 80

                    End If
                Else

                    If IsDBNull(DbConn.MyDataReader.Item("ULKE")) Then
                    Else
                        fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("ULKE")

                    End If
                End If




                fpSiparisGetir.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.Item("DURUM")

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS")) Then
                Else

                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), "-")
                    If kacıncı <> 0 Then
                        SipGir = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 5).Text = SipGir & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipGirOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 6).Text = SipGirOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_KONTROL")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), "-")
                    If kacıncı <> 0 Then
                        SipKontrol = Mid(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 7).Text = SipKontrol & ""
                    End If
                End If
                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_ONAY"), "-")
                    If kacıncı <> 0 Then


                        SipOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 8).Text = SipOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipUrtonay = Mid(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 9).Text = SipUrtonay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARISI_GIREN")) Then
                Else
                    fpSiparisGetir.Sheets(0).Cells(i, 10).Text = DbConn.MyDataReader.Item("SIPARISI_GIREN") & ""
                    fpSiparisGetir.Sheets(0).Cells(i, 11).Text = DbConn.MyDataReader.Item("SIPARIS_SAHIBI") & ""
                    fpSiparisGetir.Sheets(0).Cells(i, 11).Row.Height = 30
                End If
                Try

                    SQL = " SELECT SUM(MIKTAR) TOPLAM FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO= '" & DbConn.MyDataReader.Item("SIP_NO") & "'" _
                    & " AND REVIZ_NO= " & DbConn.MyDataReader.Item("REVIZ_NO")
                    DbConnToplam.RaporWhile(SQL)
                    While DbConnToplam.MyDataReader.Read
                        fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbConnToplam.MyDataReader.Item("TOPLAM") & ""
                    End While
                    DbConnToplam.Kapat()



                Catch ex As Exception
                    fpSiparisGetir.Sheets(0).Cells(i, 2).Text = "0"
                End Try


                Dim drmx
                If DbConn.MyDataReader.Item("DURUM") = -1 Then drmx = "Yeni" ' Sipariş Girildi"
                If DbConn.MyDataReader.Item("DURUM") = 0 Then drmx = "Giriş Onay" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 1 Then drmx = "Kontrol" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 2 Then drmx = "Müdür Onay" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 3 Then drmx = "Planlamada" ' Yönlendirilen Sipariş"
                If DbConn.MyDataReader.Item("DURUM") = 4 Then drmx = "Uretilecek Sip." ' Siparisler"
                If DbConn.MyDataReader.Item("DURUM") = 88 Then drmx = "Iptal" ' Edilen Siparis"
                If DbConn.MyDataReader.Item("DURUM") = 90 Then drmx = "Uretildi" ' Edilen Siparis"
                If DbConn.MyDataReader.Item("DURUM") = 99 Then drmx = "Revize" ' Edilen Siparis"
                fpSiparisGetir.Sheets(0).Cells(i, 14).Text = DbConn.MyDataReader.Item("DURUM") & "-" & drmx

                i += 1
            End While

            DbConn.Kapat()

            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
            'lblMsg.Text = " Bulunan Toplam Kayıt=" & i


            txtSipNoRapor.Text = ""

        Catch ex As Exception
            ' txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
        End Try

    End Sub

    Sub rapor()
        If drpSiparisDurum1.Text = "Yeni Sipariş" Then GelecekDrm = -1
        If drpSiparisDurum1.Text = "Siparis Giris" Then GelecekDrm = 0
        If drpSiparisDurum1.Text = "Giriş Onayı Bekleyen" Then GelecekDrm = 1
        If drpSiparisDurum1.Text = "Kontrol Bekleyen" Then GelecekDrm = 2
        If drpSiparisDurum1.Text = "Onay Bekleyen" Then GelecekDrm = 3
        If drpSiparisDurum1.Text = "Uretilecek Siparisler" Then GelecekDrm = 4
        If drpSiparisDurum1.Text = "Uretimi Tamamlanmıs Siparisler" Then GelecekDrm = 90
        If drpSiparisDurum1.Text = "İptal Edilen Siparisler" Then GelecekDrm = 88
        If drpSiparisDurum1.Text = "Revize Edilen Siparisler" Then GelecekDrm = 99

        Try
            Dim s1, s2, s3, s4, s5
            Dim ToplamKayitSayisi
            Dim sip_No As String = ""
            sip_No = txtSipNoRapor.Text.Trim

            If sip_No = "" Then
                Dim DbConn As New ConnectGiris


                SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                        & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "' " _
                        & " ORDER BY KAYIT_TAR DESC, SIP_NO, REVIZ_NO"

                DbConn.RaporWhile(SQL)

                Dim i As Int16 = 0
                fpSiparisGetir.Sheets(0).RowCount = 0

                While DbConn.MyDataReader.Read

                    If Len(DbConn.MyDataReader.Item("MRKSIPGIR") & "") > 0 Then
                        s1 = Split(DbConn.MyDataReader.Item("MRKSIPGIR"), "-")
                    Else
                        s1 = ""
                    End If

                    If Len(DbConn.MyDataReader.Item("MRKSIPKONTROL") & "") > 0 Then
                        s2 = Split(DbConn.MyDataReader.Item("MRKSIPKONTROL"), "-")
                    Else
                        s2 = ""
                    End If

                    If Len(DbConn.MyDataReader.Item("MRKSIPONAY") & "") > 0 Then
                        s3 = Split(DbConn.MyDataReader.Item("MRKSIPONAY"), "-")
                    Else
                        s3 = ""
                    End If
                    If Len(DbConn.MyDataReader.Item("URTPLNONAY") & "") > 0 Then
                        s4 = Split(DbConn.MyDataReader.Item("URTPLNONAY"), "-")
                    Else
                        s4 = ""
                    End If
                    If Len(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI") & "") > 0 Then
                        s5 = Mid(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI"), 1, 15)
                    Else
                        s5 = ""
                    End If
                    If PrgKod = "OZEL" And s1(0) = "OZEL" Then
                        fpSiparisGetir.Sheets(0).RowCount += 1
                        fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                        fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                        fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.Item("ULKE")
                        fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("DURUM")

                        If s1.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 4).Text = s1(1)
                        If s2.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 5).Text = s2(1)
                        If s3.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 6).Text = s3(1)
                        If s4.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 7).Text = s4(1)
                        fpSiparisGetir.Sheets(0).Cells(i, 8).Text = s5
                        i += 1
                    ElseIf PrgKod <> "OZEL" And s1(0) <> "OZEL" Then
                        fpSiparisGetir.Sheets(0).RowCount += 1
                        fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                        fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                        fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.Item("ULKE")
                        fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("DURUM")

                        If s1.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 4).Text = s1(1)
                        If s2.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 5).Text = s2(1)
                        If s3.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 6).Text = s3(1)
                        If s4.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 7).Text = s4(1)
                        fpSiparisGetir.Sheets(0).Cells(i, 8).Text = s5
                        i += 1
                    End If
                End While
                DbConn.Kapat()

                txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
                txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
                'lblMsg.Text = " Bulunan Toplam Kayıt=" & i

            Else
                Dim DbConn As New ConnectGiris
                SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                    & " WHERE MRKSIP_CBK_FLM.SIP_NO = '" & sip_No & "'"

                DbConn.RaporWhile(SQL)
                Dim i As Int16 = 0
                fpSiparisGetir.Sheets(0).RowCount = 0
                While DbConn.MyDataReader.Read

                    If Len(DbConn.MyDataReader.Item("MRKSIPGIR") & "") > 0 Then
                        s1 = Split(DbConn.MyDataReader.Item("MRKSIPGIR"), "-")
                    Else
                        s1 = ""
                    End If

                    If Len(DbConn.MyDataReader.Item("MRKSIPKONTROL") & "") > 0 Then
                        s2 = Split(DbConn.MyDataReader.Item("MRKSIPKONTROL"), "-")
                    Else
                        s2 = ""
                    End If

                    If Len(DbConn.MyDataReader.Item("MRKSIPONAY") & "") > 0 Then
                        s3 = Split(DbConn.MyDataReader.Item("MRKSIPONAY"), "-")
                    Else
                        s3 = ""
                    End If
                    If Len(DbConn.MyDataReader.Item("URTPLNONAY") & "") > 0 Then
                        s4 = Split(DbConn.MyDataReader.Item("URTPLNONAY"), "-")
                    Else
                        s4 = ""
                    End If
                    If Len(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI") & "") > 0 Then
                        s5 = Mid(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI"), 1, 15)
                    Else
                        s5 = ""
                    End If

                    If PrgKod = "OZEL" And s1(0) = "OZEL" Then
                        fpSiparisGetir.Sheets(0).RowCount += 1
                        fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                        fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                        fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.Item("ULKE")
                        fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("DURUM")

                        If s1.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 4).Text = s1(1)
                        If s2.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 5).Text = s2(1)
                        If s3.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 6).Text = s3(1)
                        If s4.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 7).Text = s4(1)
                        fpSiparisGetir.Sheets(0).Cells(i, 8).Text = s5
                        i += 1
                    ElseIf PrgKod <> "OZEL" And s1(0) <> "OZEL" Then
                        fpSiparisGetir.Sheets(0).RowCount += 1
                        fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                        fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                        fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.Item("ULKE")
                        fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("DURUM")

                        If s1.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 4).Text = s1(1)
                        If s2.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 5).Text = s2(1)
                        If s3.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 6).Text = s3(1)
                        If s4.Length > 1 Then fpSiparisGetir.Sheets(0).Cells(i, 7).Text = s4(1)
                        fpSiparisGetir.Sheets(0).Cells(i, 8).Text = s5
                        i += 1
                    End If
                    'fpSiparisGetir.Sheets(0).RowCount += 1
                    'fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                    'fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                    'fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbConn.MyDataReader.Item("ULKE")
                    'fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("DURUM")
                    'If Len(DbConn.MyDataReader.Item("MRKSIPGIR") & "") > 0 Then
                    '    s1 = Mid(DbConn.MyDataReader.Item("MRKSIPGIR"), 1, 10)
                    'Else
                    '    s1 = ""
                    'End If

                    'If Len(DbConn.MyDataReader.Item("MRKSIPKONTROL") & "") > 0 Then
                    '    s2 = Mid(DbConn.MyDataReader.Item("MRKSIPKONTROL"), 1, 10)
                    'Else
                    '    s2 = ""
                    'End If

                    'If Len(DbConn.MyDataReader.Item("MRKSIPONAY") & "") > 0 Then
                    '    s3 = Mid(DbConn.MyDataReader.Item("MRKSIPONAY"), 1, 12)
                    'Else
                    '    s3 = ""
                    'End If
                    'If Len(DbConn.MyDataReader.Item("URTPLNONAY") & "") > 0 Then
                    '    s4 = Mid(DbConn.MyDataReader.Item("URTPLNONAY"), 1, 12)
                    'Else
                    '    s4 = ""
                    'End If
                    'If Len(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI") & "") > 0 Then
                    '    s5 = Mid(DbConn.MyDataReader.Item("SIPARIS_RED_NEDENI"), 1, 15)
                    'Else
                    '    s5 = ""
                    'End If


                    'fpSiparisGetir.Sheets(0).Cells(i, 4).Text = s1
                    'fpSiparisGetir.Sheets(0).Cells(i, 5).Text = s2
                    'fpSiparisGetir.Sheets(0).Cells(i, 6).Text = s3
                    'fpSiparisGetir.Sheets(0).Cells(i, 7).Text = s4
                    'fpSiparisGetir.Sheets(0).Cells(i, 8).Text = s5


                    'i += 1
                End While
                DbConn.Kapat()
                txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
                txtKayitDurumu.Text = "İlgili sipariş ayrıntısı getirildi."
            End If

        Catch ex As Exception
            txtKayitDurumu.BackColor = Drawing.Color.Red
            txtKayitDurumu.Text = "İlgili sipariş ayrıntısı getirilirken hata ile karşılaşıldı."
        End Try

    End Sub

    Protected Sub fpSiparisGetir_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles fpSiparisGetir.ButtonCommand

        If e.CommandName = "ONAY" Then

            ' Dim Siparisin_ = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 10).Text

            Dim sip_no, reviz_no



            reviz_no = Convert.ToInt32(fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 1).Text)
            sip_no = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 0).Text
            txtUretimSipNo.Text = sip_no
            txtRevizyon.Text = reviz_no
            siparisDurumu = GetSiparisDurumu(reviz_no, sip_no)


            If Program_YetkNumarasi - siparisDurumu = 1 Then
                SipSahipOnay()
                Rapor_New()
            Else
                ' ShowMessage("Onay Sıralamanız henüz gelmediği için, Onaylama işlemini yapamazsınız.")
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Onay Sıralamanız henüz gelmediği için, Onaylama işlemini yapamazsınız.');", True)
            End If

        End If

        If e.CommandName = "EbatMiktarGetir" Then

            Dim sip_no, reviz_no
            reviz_no = Convert.ToInt32(fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 1).Text)
            sip_no = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 0).Text
            txtUretimSipNo.Text = sip_no
            txtRevizyon.Text = reviz_no


            txtLotAnaliz.Text = ""
            For index As Integer = 0 To fpLotKimyasal.Sheets(0).RowCount - 1

                fpLotKimyasal.Sheets(0).Cells(index, 1).Text = ""
                fpLotKimyasal.Sheets(0).Cells(index, 2).Text = ""

                fpLotKimyasal.Sheets(0).Cells(index, 1).BackColor = Drawing.Color.White
                fpLotKimyasal.Sheets(0).Cells(index, 2).BackColor = Drawing.Color.White
            Next

            txtUretimSipNoAnaliz.Text = txtUretimSipNo.Text
            txtRevizyonAnaliz.Text = txtRevizyon.Text

            lotlariListele()



            alanlariBeyazlat()
            temizle()
            alanlariKapat()



            Session("Siparisin_sahibi_Kim_Mail") = ""
            Session("Siparisi_Giren_Kim_Mail") = ""

            Dim Siparisin_sahibi_Kim = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 11).Text
            MailAdresiBul(Siparisin_sahibi_Kim)
            Session("Siparisin_sahibi_Kim_Mail") = MailAdresi

            Dim Siparisi_Giren_Kim = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 5).Text
            MailAdresiBul(Siparisi_Giren_Kim)
            Session("Siparisi_Giren_Kim_Mail") = MailAdresi


            If Session("PRGKOD") = "OZLCLK" Then

                varmı = 0
                For gg = 0 To Siparis_Sahibi.Items.Count - 1
                    If gg > 0 Then
                        If Siparis_Sahibi.Items(gg).Text = Kullanıcı Then
                            varmı = 1
                            GoTo son2
                        End If
                    End If
                Next
                If varmı = 0 Then
                    Siparis_Sahibi.Items.Add(NullToString(Siparisin_sahibi_Kim) & "")
                End If
son2:

                ' Siparis_Sahibi.Items.Add(Siparisin_sahibi_Kim)
            End If

            If Session("KULLANICI") = Siparisin_sahibi_Kim Then
                Buton_SIP_IPTAL.Visible = True
            Else
                Buton_SIP_IPTAL.Visible = False
            End If

            If Btn_EKRAN_GIRIS = 1 Then
                tabAnaliz.ActiveTab = TabPanel2
            End If

            If Btn_EKRAN_ONAY = 1 Then
                tabAnaliz.ActiveTab = TabPanel3
            End If

            If UserName = "OPR1A11" Or UserName = "OPR1912" Then
                TabPanel3.Enabled = True
                tabAnaliz.ActiveTab = TabPanel3
            End If


            Dim sip_nox, reviz_nox
            reviz_nox = Convert.ToInt32(fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 1).Text)
            sip_nox = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 0).Text

            SipDrm_Getir(sip_nox, reviz_nox)


            If Filtre_Drm = 0 Then
                txtUretimSipNo.Text = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 0).Text
                txtRevizyon.Text = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 1).Text
                Session("EskiRevNo") = txtRevizyon.Text
                BtnSakla.Enabled = False
                txtUretimSipNo.Enabled = False
                GETIR()
                ' eger sipariş üretime gitmişsse sip iptal veya iade olmaz bu butonları kapat

            End If


            If Filtre_Drm = 1 Then
                If Siparisin_sahibi_Kim = Kullanıcı Then
                    txtUretimSipNo.Text = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 0).Text
                    txtRevizyon.Text = fpSiparisGetir.Sheets(0).Cells(e.CommandArgument.X, 1).Text
                    Session("EskiRevNo") = txtRevizyon.Text
                    BtnSakla.Enabled = False
                    txtUretimSipNo.Enabled = False
                    GETIR()
                Else
                    txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
                    txtKayitDurumu.Text = "Siparişi Sadece Listelenebilir. İnceleme Yetkiniz yok."
                    'ShowMessage("Sipariş Sadece Listelenebilir. İnceleme Yetkiniz yok.")
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş Sadece Listelenebilir. İnceleme Yetkiniz yok.');", True)

                    tabAnaliz.ActiveTab = TabPanel1

                End If

            End If



        End If


        Soldaki_Tum_alanları_Ac()
        Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)

    End Sub




    'Protected Sub btnRedSakla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRedSakla.Click
    '    ' Session("REDNDN") = REDNDN.Text
    '    Dim sip_no, rev_no, prgkod, SQL, NewDurum
    '    sip_no = txtUretimSipNo.Text
    '    rev_no = txtRevizyon.Text
    '    Dim DbConn As New ConnectGiris

    '    Try

    '        'txtRedUretimSipNo.Text = ""
    '        'txtRedRevizyon.Text = ""
    '        'dateRedSipTar.Text = ""
    '        'REDNDN.Text = ""
    '        'tabAnaliz.ActiveTab = TabPanel3
    '        'tabAnaliz.ActiveTab.Visible = False
    '        'tabAnaliz.ActiveTab = TabPanel1

    '        Dim kayityap As Boolean = False
    '        Kullanıcı = Session("KULLANICI")
    '        prgkod = Session("PRGKOD")

    '        NewDurum = 88
    '        SQL = "update MRKSIP_CBK_FLM " _
    '              & " set SIPARIS_URETIM_ONAY='" & Kullanıcı & "-" & "_IPTAL_" & Date.Now & "'," _
    '                & " DURUM='" & NewDurum & "'," _
    '                & " SIPARIS_RED_NEDENI='" & REDNDN.Text & "'" _
    '                & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
    '                & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
    '        DbConn.SaveUpdate(SQL)
    '        DbConn.Kapat()
    '        txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
    '        txtKayitDurumu.Text = "Sipariş İptal Edildi."
    '        'ShowMessage("Sipariş İptal Edildi.")
    '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş İptal Edildi.');", True)


    '        REDNDN.Text = ""
    '        tabAnaliz.ActiveTab = TabPanel3

    '        MailGonder(Session("KULLANICI"), Btn_SIP_IPTAL_MAIL, "Sipariş İptal Edildi", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))


    '    Catch ex As Exception
    '        ShowMessage("Kayıt gerçekleştirilemedi.")
    '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Kayıt gerçekleştirilemedi.');", True)
    '        txtKayitDurumu.BackColor = Drawing.Color.Red
    '        txtKayitDurumu.Text = "Red nedeni kaydı bir hata sebebiyle kayıt edilemedi."
    '    End Try
    'End Sub

    Private Sub GETIR()
        Dim SipNo As String
        Dim RevizNo As Integer
        SipNo = txtUretimSipNo.Text
        RevizNo = txtRevizyon.Text

        If SipNo <> "" Then
            SiparisinDurumu = -1
            Dim DbConn As New ConnectGiris
            SQL = " SELECT DURUM,SIPARIS_GRUBU FROM MRKSIP_CBK_FLM" _
                & " WHERE SIP_NO= '" & SipNo & "'" _
                & " AND REVIZ_NO= " & RevizNo
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                SiparisinDurumu = DbConn.MyDataReader.Item("DURUM")
                SIPARISIN_GRUBU = DbConn.MyDataReader.Item("SIPARIS_GRUBU")
            End While
            DbConn.Kapat()
            If SiparisinDurumu >= -1 Then
                'alanlariAc()
                'alanlariKapat()
                siparisleriAlanaGetir(SipNo, RevizNo, SiparisinDurumu)
                Session("AktifSiparisDurumu") = SiparisinDurumu
            Else
                txtKayitDurumu.BackColor = Drawing.Color.Red
                txtKayitDurumu.Text = "Sipariş numarısı bulunamadı"
            End If
        Else
            txtKayitDurumu.BackColor = Drawing.Color.Red
            txtKayitDurumu.Text = "Sipariş numarası boş olamaz."
        End If

        If SiparisinDurumu = 4 Then
            Buton_SIP_IADE.Enabled = False
            'Buton_SIP_IPTAL.Enabled = False
        End If
    End Sub
    Sub revizyon()

        Dim sip_no, reviz_no
        Dim DbConn As New ConnectGiris

        If dateSipTar.Text = "" Then
            MsgBox("Lütfen sipariş numarası giriniz")
        Else
            sip_no = txtUretimSipNo.Text
            SQL = "SELECT MAX(REVIZ_NO) REVIZ_NO FROM MRKSIP_CBK_FLM " _
            & " WHERE sip_no = '" & sip_no & "'" _
            & " ORDER BY REVIZ_NO"
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                If IsDBNull(DbConn.MyDataReader.Item("REVIZ_NO")) Then
                    reviz_no = 0
                Else
                    reviz_no = DbConn.MyDataReader.Item("REVIZ_NO") + 1
                End If
            End While
            DbConn.Kapat()
            txtRevizyon.Text = reviz_no
        End If
    End Sub


    Private Sub Onay()

        Dim Sql, NewDurum
        Dim kayityap As Boolean = False
        Dim DbConn As New ConnectGiris
        Kullanıcı = Session("KULLANICI")
        PrgKod = Session("PRGKOD")


        Siparisin_sahibi_Kim_Mail = Session("Siparisin_sahibi_Kim_Mail")
        Siparisi_Giren_Kim_Mail = Session("Siparisi_Giren_Kim_Mail")


        NewDurum = 1
        If PrgKod = "DISTIC" Or PrgKod = "OZLCLK" Then NewDurum = 1
        If PrgKod = "ICPIYS" Then NewDurum = 2
        If PrgKod = "KTKTLP" Then NewDurum = 2


        Sql = "update MRKSIP_CBK_FLM " _
              & " set SIPARIS_GIRIS_ONAY='" & Kullanıcı & "-" & Date.Now & "'," _
                & " DURUM='" & NewDurum & "'" _
                & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
        DbConn.SaveUpdate(Sql)
        DbConn.Kapat()


        If PrgKod = "DISTIC" And Session("Program_YetkNumarasi") = 1 Then
            Btn_SIP_GIR_ONAY_MAIL = Btn_SIP_GIR_ONAY_MAIL & ";" & Siparisin_sahibi_Kim_Mail
        End If

        If PrgKod = "ICPIYS" And Session("Program_YetkNumarasi") = 1 Then
            Btn_SIP_GIR_ONAY_MAIL = Btn_SIP_GIR_ONAY_MAIL
        End If

        If PrgKod = "OZLCLK" And Session("Program_YetkNumarasi") = 1 Then
            Btn_SIP_GIR_ONAY_MAIL = Btn_SIP_GIR_ONAY_MAIL
        End If

        If PrgKod = "KTKTLP" And Session("Program_YetkNumarasi") = 1 Then
            Btn_SIP_GIR_ONAY_MAIL = Btn_SIP_GIR_ONAY_MAIL
        End If

        txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
        txtKayitDurumu.Text = " Sipariş Girişi Kontol edilmek üzere Onaylandı"
        'ShowMessage("Sipariş Girişi Kontol edilmek üzere Onaylandı.")
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş Girişi Kontol edilmek üzere Onaylandı.');", True)
        MailGonder(Session("KULLANICI"), Btn_SIP_GIR_ONAY_MAIL, "Sipariş Girişi Onaylandı", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))


        '   MAILHAZIRLA("Sipariş Girişi Kontrol Edilmek üzere Onaylandı.", txtUretimSipNo.Text, txtRevizyon.Text, PrgKod, "1")

        ''DURUM güncellemesini if içerisindeki updatelerin yanına aldım. 
        'If PrgYer = "MRKSIPONAY" And (AktifSiparisinDurumu <= 2) Then
        '    NewDurum = 2
        '    Sql = "update MRKSIP_CBK_FLM " _
        '        & " set MRKSIPONAY='" & Kullanıcı & Date.Now & "'," _
        '        & " DURUM='" & NewDurum & "'" _
        '        & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
        '        & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
        '    DbConn.SaveUpdate(Sql)
        '    DbConn.Kapat()

        '    txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
        '    txtKayitDurumu.Text = " Sipariş Bilgilerini Onaylandı"
        '    ShowMessage("Sipariş onaylandı.")
        'ElseIf PrgYer = "URTPLNONAY" And (AktifSiparisinDurumu = 2 Or AktifSiparisinDurumu = 3) Then
        '    NewDurum = 3
        '    Sql = "update MRKSIP_CBK_FLM " _
        '        & " set URTPLNONAY='" & Kullanıcı & Date.Now & "'," _
        '        & " DURUM='" & NewDurum & "'" _
        '        & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
        '        & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
        '    DbConn.SaveUpdate(Sql)
        '    DbConn.Kapat()
        '    txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
        '    txtKayitDurumu.Text = " Sipariş Bilgilerini Onaylandı"
        '    ShowMessage("Sipariş onaylandı.")
        'ElseIf PrgYer = "URTPLNONAY" And AktifSiparisinDurumu < 2 Then
        '    ShowMessage("Sipariş Kontrol'den geçmediği için onaylayamazsınız")
        '    txtKayitDurumu.Text = "Sipariş Kontrol'den geçmediği için onaylayamazsınız"
        'ElseIf PrgYer = "MRKSIPONAY" And AktifSiparisinDurumu > 2 Then
        '    ShowMessage("Sipariş Kontrol'den geçtiği için onaylayamazsınız")
        '    txtKayitDurumu.Text = "Sipariş Kontrol'den geçtiği için onaylayamazsınız"
        'Else
        '    ShowMessage("Onay gerçekleştirilemedi")
        '    txtKayitDurumu.Text = "Onay gerçekleştirilemedi"
        '    'Bilinmeyen bir durumda anlaşılması için
        'End If

        'rapor()
    End Sub
    Protected Sub Buton_SIP_REVIZYON_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buton_SIP_REVIZYON.Click

        Soldaki_Tum_alanları_Ac()
        Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)

        revizyonYap()

        tabAnaliz.ActiveTab = TabPanel2

    End Sub
    Dim analizSayisi As Integer 'Lot sayısı ile analiz sayısı arasında fark olursa analizde eksik cikabilir.
    Sub analizDurumKontrol(ByVal gelenSip, ByVal gelenRev, ByVal lotNo)
        analiziOlmayanLot = ""
        analizSayisi = 0
        Dim flag As Boolean = False ' Bayrak true ise analiz var
        Dim dizi(59) As String
        Dim dbconnAnaliz As New ConnectGiris
        SQL = " SELECT * FROM MRKSIP_KUTUK_ANALIZ " _
            & " WHERE SIP_NO= '" & gelenSip & "'" _
            & " AND REVIZ_NO= '" & gelenRev & "'" _
            & " AND LOT_NO= '" & lotNo & "'"
        dbconnAnaliz.RaporWhile(SQL)
        While dbconnAnaliz.MyDataReader.Read
            analizSayisi += 1
            flag = False
            dizi(0) = dbconnAnaliz.MyDataReader.Item("C_MIN")
            dizi(1) = dbconnAnaliz.MyDataReader.Item("C_MAX")
            dizi(2) = dbconnAnaliz.MyDataReader.Item("SI_MIN")
            dizi(3) = dbconnAnaliz.MyDataReader.Item("SI_MAX")
            dizi(4) = dbconnAnaliz.MyDataReader.Item("S_MIN")
            dizi(5) = dbconnAnaliz.MyDataReader.Item("S_MAX")
            dizi(6) = dbconnAnaliz.MyDataReader.Item("P_MIN")
            dizi(7) = dbconnAnaliz.MyDataReader.Item("P_MAX")
            dizi(8) = dbconnAnaliz.MyDataReader.Item("MN_MIN")
            dizi(9) = dbconnAnaliz.MyDataReader.Item("MN_MAX")
            dizi(10) = dbconnAnaliz.MyDataReader.Item("NI_MIN")
            dizi(11) = dbconnAnaliz.MyDataReader.Item("NI_MAX")
            dizi(12) = dbconnAnaliz.MyDataReader.Item("CR_MIN")
            dizi(13) = dbconnAnaliz.MyDataReader.Item("CR_MAX")
            dizi(14) = dbconnAnaliz.MyDataReader.Item("MO_MIN")
            dizi(15) = dbconnAnaliz.MyDataReader.Item("MO_MAX")
            dizi(16) = dbconnAnaliz.MyDataReader.Item("V_MIN")
            dizi(17) = dbconnAnaliz.MyDataReader.Item("V_MAX")
            dizi(18) = dbconnAnaliz.MyDataReader.Item("CU_MIN")
            dizi(19) = dbconnAnaliz.MyDataReader.Item("CU_MAX")
            dizi(20) = dbconnAnaliz.MyDataReader.Item("W_MIN")
            dizi(21) = dbconnAnaliz.MyDataReader.Item("W_MAX")
            dizi(22) = dbconnAnaliz.MyDataReader.Item("TI_MIN")
            dizi(23) = dbconnAnaliz.MyDataReader.Item("TI_MAX")
            dizi(24) = dbconnAnaliz.MyDataReader.Item("SN_MIN")
            dizi(25) = dbconnAnaliz.MyDataReader.Item("SN_MAX")
            dizi(26) = dbconnAnaliz.MyDataReader.Item("CO_MIN")
            dizi(27) = dbconnAnaliz.MyDataReader.Item("CO_MAX")
            dizi(28) = dbconnAnaliz.MyDataReader.Item("AL_MIN")
            dizi(29) = dbconnAnaliz.MyDataReader.Item("AL_MAX")
            dizi(30) = dbconnAnaliz.MyDataReader.Item("ALSOL_MIN")
            dizi(31) = dbconnAnaliz.MyDataReader.Item("ALSOL_MAX")
            dizi(32) = dbconnAnaliz.MyDataReader.Item("ALOXY_MIN")
            dizi(33) = dbconnAnaliz.MyDataReader.Item("ALOXY_MAX")
            dizi(34) = dbconnAnaliz.MyDataReader.Item("PB_MIN")
            dizi(35) = dbconnAnaliz.MyDataReader.Item("PB_MAX")
            dizi(36) = dbconnAnaliz.MyDataReader.Item("B_MIN")
            dizi(37) = dbconnAnaliz.MyDataReader.Item("B_MAX")
            dizi(38) = dbconnAnaliz.MyDataReader.Item("SB_MIN")
            dizi(39) = dbconnAnaliz.MyDataReader.Item("SB_MAX")
            dizi(40) = dbconnAnaliz.MyDataReader.Item("NB_MIN")
            dizi(41) = dbconnAnaliz.MyDataReader.Item("NB_MAX")
            dizi(42) = dbconnAnaliz.MyDataReader.Item("CA_MIN")
            dizi(43) = dbconnAnaliz.MyDataReader.Item("CA_MAX")
            dizi(44) = dbconnAnaliz.MyDataReader.Item("ZN_MIN")
            dizi(45) = dbconnAnaliz.MyDataReader.Item("ZN_MAX")
            dizi(46) = dbconnAnaliz.MyDataReader.Item("N_MIN")
            dizi(47) = dbconnAnaliz.MyDataReader.Item("N_MAX")
            dizi(48) = dbconnAnaliz.MyDataReader.Item("FE_MIN")
            dizi(49) = dbconnAnaliz.MyDataReader.Item("FE_MAX")
            dizi(50) = dbconnAnaliz.MyDataReader.Item("F_MIN")
            dizi(51) = dbconnAnaliz.MyDataReader.Item("F_MAX")
            dizi(52) = dbconnAnaliz.MyDataReader.Item("CEQ_MIN")
            dizi(53) = dbconnAnaliz.MyDataReader.Item("CEQ_MAX")
            dizi(54) = dbconnAnaliz.MyDataReader.Item("Y1MIN")
            dizi(55) = dbconnAnaliz.MyDataReader.Item("Y1MAX")
            dizi(56) = dbconnAnaliz.MyDataReader.Item("Y2MIN")
            dizi(57) = dbconnAnaliz.MyDataReader.Item("Y2MAX")
            dizi(58) = dbconnAnaliz.MyDataReader.Item("LOT_NO")
            For Each letter As String In dizi
                If letter Is Nothing Then
                Else
                    If letter.Contains("-") Then
                    Else
                        flag = True
                    End If
                End If
            Next
            If flag Then
            Else
                analiziOlmayanLot = dizi(58)
                GoTo son
            End If
        End While
son:
        dbconnAnaliz.Kapat()
    End Sub
    Dim analiziOlmayanLot As String = ""
    Protected Sub Buton_SIP_GIRIS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buton_SIP_GIRIS.Click
        Dim I
        Dim siparisKutukMu As Boolean
        If fpEbatMiktar.Sheets(0).Cells(0, 3).Text = "Kutuk" Then
            For I = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                siparisKutukMu = True
            Next I
        End If
        Dim YokVArmı
        For I = 0 To fpLotListe.Sheets(0).RowCount - 1
            YokVArmı = fpLotListe.Sheets(0).Cells(I, 2).Text
            If YokVArmı = "Yok" Then
                GoTo son
            End If
        Next
son:
        siparisiOnaylaMailAt()
        GETIR()
        'If siparisKutukMu = True Then

        '    'If YokVArmı = "Yok" Then
        '    '    'ShowMessage("Analiz Girmediğiniz Lot(lar) var, SAKLAMA İŞLEMİ GERÇEKLEŞMEYECEK....")
        '    '    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Analiz Girmediğiniz Lot(lar) var, SAKLAMA İŞLEMİ GERÇEKLEŞMEYECEK....');", True)
        '    '    txtKayitDurumu.Text = "Analiz Girmediğiniz Lot(lar) var"
        '    '    txtKayitDurumu.BackColor = Drawing.Color.Red
        '    'Else
        '    '    siparisiOnaylaMailAt()
        '    '    GETIR()
        '    'End If
        'Else
        '    siparisiOnaylaMailAt()
        '    GETIR()
        'End If
    End Sub
    Sub siparisiOnaylaMailAt()

        Dim Sql, NewDurum
        Dim DbConn As New ConnectGiris
        sakla()

        NewDurum = 0

        If PrgKod = "ICPIYS" Then
            If Program_YetkNumarasi = -1 Then
                NewDurum = 1
            End If
        End If
        If PrgKod = "KTKTLP" Then
            If Program_YetkNumarasi = -1 Then
                NewDurum = 2
            End If
            If Program_YetkNumarasi = 3 Then
                NewDurum = 2
            End If
        End If

        Sql = "update MRKSIP_CBK_FLM " _
            & " SET DURUM='" & NewDurum & "'" _
            & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
            & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
        DbConn.SaveUpdate(Sql)
        DbConn.Kapat()


        If Iade_Durumu = 1 Then ' yanı bu sipariş zaten vardı kullanıcı sadece kend ıcınde kayıt yenıledi **Sipariş yeni açıldıysa yada iade durumu 1 ise(yani iade edildiyse) mail kesin gidecek. Else girmesi için iade durumu mutlaka 0 olmalı
            MailGonder(Session("KULLANICI"), Btn_SIP_GIRIS_MAIL, "Yeni bir Sipariş Girildi", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş Onaya Gönderildi.');", True)
        Else
            If Session("EskiRevNo") <> txtRevizyon.Text And Session("EskiRevNo") <> "" Then

                Session("EskiRevNo") = txtRevizyon.Text
                MailGonder(Session("KULLANICI"), Btn_SIP_REVIZYON_MAIL, "Sipariş Revizyon Edilmiştir", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş Onaya Gönderildi.');", True)

            Else

                MailGonder(Session("KULLANICI"), Btn_SIP_GIRIS_MAIL, "Yeni bir Sipariş Girildi", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))

                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş Onaya Gönderildi.');", True)

            End If
        End If

        'mail at
    End Sub

    Protected Sub Buton_SIP_SIL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buton_SIP_SIL.Click
        Sil()
    End Sub

    Protected Sub Buton_SIP_GIR_ONAY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buton_SIP_GIR_ONAY.Click

        Dim sip_tar, sip_no, reviz_no
        reviz_no = Convert.ToInt32(txtRevizyon.Text)
        CEVIR(dateSipTar.Text)
        sip_tar = DonenTarih
        sip_no = txtUretimSipNo.Text
        siparisDurumu = GetSiparisDurumu(reviz_no, sip_no)

        If Program_YetkNumarasi >= siparisDurumu Then
            Onay()
        Else
            'ShowMessage("Üst onay aldığı için saklama gerçekleştiremezsiniz.")
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Üst onay aldığı için saklama gerçekleştiremezsiniz....');", True)
            'txtKayitDurumu.Text = "Üst onay aldığı için saklama gerçekleştiremezsiniz."
            'txtKayitDurumu.BackColor = Drawing.Color.Red
        End If


    End Sub

    Protected Sub buton_SIP_KONTROL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buton_SIP_KONTROL.Click


        Dim sip_no, reviz_no
        reviz_no = Convert.ToInt32(txtRevizyon.Text)
        sip_no = txtUretimSipNo.Text
        siparisDurumu = GetSiparisDurumu(reviz_no, sip_no)


        If PrgKod = "ICPIYS" Then
            If Program_YetkNumarasi = 3 Then ' YANI OYA HANIM VE AYNI YETKIYE SAHIP OLANLAR BIR BASAMAK ATLATMAK ICIN
                siparisDurumu = 2
            End If
        End If
        If PrgKod = "OZLCLK" Then
            If Program_YetkNumarasi = 3 Then ' YANI OYA HANIM VE AYNI YETKIYE SAHIP OLANLAR BIR BASAMAK ATLATMAK ICIN
                siparisDurumu = 2
            End If
        End If


        If Program_YetkNumarasi >= siparisDurumu Then
            If Program_YetkNumarasi - siparisDurumu <= 1 Then
                KONTROL()
            Else
                'ShowMessage("Onay Sıralamanız henüz gelmediği için, saklama işlemini yapamazsınız.")
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Onay Sıralamanız henüz gelmediği için, saklama işlemini yapamazsınız..');", True)
            End If

        Else
            'ShowMessage("Üst onay aldığı için saklama gerçekleştiremezsiniz.")
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Üst onay aldığı için saklama gerçekleştiremezsiniz..');", True)
            'txtKayitDurumu.Text = "Üst onay aldığı için saklama gerçekleştiremezsiniz."
            'txtKayitDurumu.BackColor = Drawing.Color.Red
        End If


    End Sub
    Private Sub KONTROL()

        Dim Sql, NewDurum
        Dim kayityap As Boolean = False
        Dim DbConn As New ConnectGiris
        Kullanıcı = Session("KULLANICI")
        PrgKod = Session("PRGKOD")

        'If PrgKod = "DISTIC" Then NewDurum = 2
        'If PrgKod = "ICPIYS" Then NewDurum = 3



        NewDurum = 2

        Sql = "update MRKSIP_CBK_FLM " _
              & " set SIPARIS_KONTROL='" & Kullanıcı & "-" & Date.Now & "'," _
                & " DURUM='" & NewDurum & "'" _
                & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"

        DbConn.SaveUpdate(Sql)
        DbConn.Kapat()
        txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
        txtKayitDurumu.Text = "Sipariş Onaylanabilir. Kontol Edildi"
        '        ShowMessage("Sipariş Onaylanabilir. Kontol Edildi.")
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş Onaylanabilir. Kontol Edildi..');", True)



        If PrgKod = "ICPIYS" Then
            If Program_YetkNumarasi = 3 Then ' YANI OYA HANIM VE AYNI YETKIYE SAHIP OLANLAR BIR BASAMAK ATLATMAK ICIN
            Else
                MailGonder(Session("KULLANICI"), Btn_SIP_KONTROL_MAIL, "Sipariş Girişi Kontrol Edildi", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))
            End If
        End If




    End Sub

    Protected Sub Buton_SIP_ONAY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buton_SIP_ONAY.Click



        Dim sip_no, reviz_no
        reviz_no = Convert.ToInt32(txtRevizyon.Text)
        sip_no = txtUretimSipNo.Text
        siparisDurumu = GetSiparisDurumu(reviz_no, sip_no)

        If Program_YetkNumarasi >= siparisDurumu Then

            If Program_YetkNumarasi - siparisDurumu <= 1 Then
                SipSahipOnay()
            Else
                'ShowMessage("Onay Sıralamanız henüz gelmediği için, saklama işlemini yapamazsınız.")
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Onay Sıralamanız henüz gelmediği için, saklama işlemini yapamazsınız.');", True)
            End If
        Else
            'ShowMessage("Üst onay aldığı için saklama gerçekleştiremezsiniz.")
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Üst onay aldığı için saklama gerçekleştiremezsiniz');", True)
        End If



    End Sub

    Private Sub SipSahipOnay()

        Dim Sql, NewDurum
        Dim kayityap As Boolean = False
        Dim DbConn As New ConnectGiris
        Kullanıcı = Session("KULLANICI")
        PrgKod = Session("PRGKOD")


        Siparisin_sahibi_Kim_Mail = Session("Siparisin_sahibi_Kim_Mail")
        Siparisi_Giren_Kim_Mail = Session("Siparisi_Giren_Kim_Mail")


        ' bu sıparısı onaylamadan once gır ve kontrol kısmına bak eger kontrol kısmı bos ıse 
        ' mesaj ver once kontrol tusuna bastırt
        Dim SIPARIS_KONTROL_DRM = ""

        If PrgKod = "KTKTLP" Then
            NewDurum = 3
            Sql = "update MRKSIP_CBK_FLM " _
                  & " set SIPARIS_ONAY='" & Kullanıcı & "-" & Date.Now & "'," _
                    & " DURUM='" & NewDurum & "'" _
                    & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                    & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
            DbConn.SaveUpdate(Sql)
            DbConn.Kapat()

        Else

            Sql = "select SIPARIS_KONTROL from  MRKSIP_CBK_FLM " _
                    & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                    & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
            DbConn.RaporWhile(Sql)
            While DbConn.MyDataReader.Read
                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_KONTROL")) Then
                    SIPARIS_KONTROL_DRM = DbConn.MyDataReader.Item("SIPARIS_KONTROL") & ""
                Else
                    SIPARIS_KONTROL_DRM = ""
                End If

            End While
            DbConn.Kapat()

        End If
        'If SIPARIS_KONTROL_DRM = "" And PrgKod = "OZLCLK" Then
        'SIPARIS_KONTROL_DRM = "-"
        'End If
        'If SIPARIS_KONTROL_DRM = "" And PrgKod = "DISTIC" Then
        ' SIPARIS_KONTROL_DRM = "-"
        ' End If

        If SIPARIS_KONTROL_DRM = "" Then
            SIPARIS_KONTROL_DRM = "-"
        End If

        If SIPARIS_KONTROL_DRM <> "" Then
            NewDurum = 3
            Sql = "update MRKSIP_CBK_FLM " _
                  & " set SIPARIS_ONAY='" & Kullanıcı & "-" & Date.Now & "'," _
                    & " DURUM='" & NewDurum & "'" _
                    & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                    & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
            DbConn.SaveUpdate(Sql)
            DbConn.Kapat()



            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = "Sipariş Onaylandı ve Planlamaya gönderildi. Kontol Edildi"
            'ShowMessage("Sipariş Onaylandı ve Planlamaya gönderildi. Kontol Edildi.")
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş Onaylandı ve Planlamaya gönderildi. Kontol Edildi.');", True)

        Else
            If PrgKod <> "KTKTLP" Then
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Hata Önce Siparişin Kontrol Edildiğini Onaylayın.');", True)
            End If

        End If


        If PrgKod = "DISTIC" And Session("Program_YetkNumarasi") >= 2 Then
            Btn_SIP_ONAY_MAIL = Btn_SIP_ONAY_MAIL & ";" & Siparisi_Giren_Kim_Mail
        End If
        If PrgKod = "ICPIYS" And Session("Program_YetkNumarasi") >= 2 Then
            Btn_SIP_ONAY_MAIL = Btn_SIP_ONAY_MAIL & ";" & Siparisi_Giren_Kim_Mail
        End If
        If PrgKod = "OZLCLK" And Session("Program_YetkNumarasi") >= 2 Then
            Btn_SIP_ONAY_MAIL = Btn_SIP_ONAY_MAIL & ";" & Siparisi_Giren_Kim_Mail
        End If
        If PrgKod = "KTKTLP" And Session("Program_YetkNumarasi") >= 2 Then
            Btn_SIP_ONAY_MAIL = Btn_SIP_ONAY_MAIL & ";" & Siparisi_Giren_Kim_Mail
        End If

        If Not IsDBNull(Btn_SIP_ONAY_MAIL) Then

            If Strings.Mid(txtUretimSipNo.Text, 1, 3) = "IHR" Then
                MailGonder_Attach(Session("KULLANICI"), Siparisin_sahibi_Kim_Mail, "Sipariş Onaylandı ", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))
            Else
                MailGonder(Session("KULLANICI"), Btn_SIP_ONAY_MAIL, "Sipariş Onaylandı ", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))
                If PrgKod = "DISTIC" Then
                    MailGonder_Attach(Session("KULLANICI"), Siparisi_Giren_Kim_Mail + ";" + "export@dilerhld.com", "Sipariş Onaylandı ", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))
                Else
                    MailGonder_Attach(Session("KULLANICI"), Siparisi_Giren_Kim_Mail, "Sipariş Onaylandı ", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))
                End If


            End If

        Else
            txtKayitDurumu.BackColor = Drawing.Color.Red
            txtKayitDurumu.Text = "Onaya yönlenecek mail adresi yok"
        End If


    End Sub
    Protected Sub Buton_SIP_IADE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buton_SIP_IADE.Click


        Dim sip_no, reviz_no
        reviz_no = Convert.ToInt32(txtRevizyon.Text)
        sip_no = txtUretimSipNo.Text
        siparisDurumu = GetSiparisDurumu(reviz_no, sip_no)

        If PrgKod = "OZLCLK" Then siparisDurumu = 3

        If Program_YetkNumarasi >= siparisDurumu Then

            If Program_YetkNumarasi - siparisDurumu <= 1 Then

                SiparisIadeEt()
            Else
                'ShowMessage("Onay Sıralamanız henüz gelmediği için, İADE işlemini yapamazsınız.")
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Onay Sıralamanız henüz gelmediği için, İADE işlemini yapamazsınız.');", True)
            End If


        Else
            'ShowMessage("Üst onay aldığı için iade işlemini gerçekleştiremezsiniz.")
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Üst onay aldığı için iade işlemini gerçekleştiremezsiniz.');", True)
        End If


    End Sub


    Private Sub SiparisIadeEt()

        Dim User_YetkNumarası = Program_YetkNumarasi

        Dim Sql, NewDurum
        Dim kayityap As Boolean = False
        Dim DbConn As New ConnectGiris
        Kullanıcı = Session("KULLANICI")
        PrgKod = Session("PRGKOD")



        Siparisin_sahibi_Kim_Mail = Session("Siparisin_sahibi_Kim_Mail")
        Siparisi_Giren_Kim_Mail = Session("Siparisi_Giren_Kim_Mail")





        'NewDurum = User_YetkNumarası - 1
        NewDurum = -1


        Sql = "update MRKSIP_CBK_FLM " _
              & " set SIPARIS_GIRIS_ONAY='" & Kullanıcı & "-" & "_IADE_" & Date.Now & "'," _
              & " IADE_DURUM ='1', " _
                & " DURUM='" & NewDurum & "'" _
                & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
        DbConn.SaveUpdate(Sql)
        DbConn.Kapat()

        If PrgKod = "DISTIC" And Session("Program_YetkNumarasi") >= 1 Then
            Btn_SIP_IADE_MAIL = Btn_SIP_IADE_MAIL & ";" & Siparisi_Giren_Kim_Mail
            If Session("Program_YetkNumarasi") = 3 Then Btn_SIP_IADE_MAIL = Btn_SIP_IADE_MAIL & ";" & Siparisin_sahibi_Kim_Mail
        End If

        If PrgKod = "ICPIYS" And Session("Program_YetkNumarasi") >= 1 Then
            Btn_SIP_IADE_MAIL = Btn_SIP_IADE_MAIL
        End If

        If PrgKod = "OZLCLK" And Session("Program_YetkNumarasi") >= 1 Then
            Btn_SIP_IADE_MAIL = Btn_SIP_IADE_MAIL
        End If

        txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
        txtKayitDurumu.Text = "Sipariş Kontrol için geri gönderildi."
        'ShowMessage("Sipariş Kontrol için geri gönderildi.")
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş Kontrol için geri gönderildi.');", True)

        MailGonder(Session("KULLANICI"), Btn_SIP_IADE_MAIL, "Sipariş Kontrol Edilmek üzere geri gönderildi", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))

    End Sub
    Protected Sub Buton_SIP_URT_CEVIR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buton_SIP_URT_CEVIR.Click


        Dim sip_no, reviz_no
        reviz_no = Convert.ToInt32(txtRevizyon.Text)
        sip_no = txtUretimSipNo.Text
        siparisDurumu = GetSiparisDurumu(reviz_no, sip_no)

        If Program_YetkNumarasi >= siparisDurumu Then

            If Program_YetkNumarasi - siparisDurumu <= 1 Then
                UretimeCevir()
            Else
                'ShowMessage("Onay Sıralamanız henüz gelmediği için, saklama işlemini yapamazsınız.")
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Onay Sıralamanız henüz gelmediği için, saklama işlemini yapamazsınız.');", True)
            End If
        Else
            'ShowMessage("Üst onay aldığı için saklama gerçekleştiremezsiniz.")
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Üst onay aldığı için saklama gerçekleştiremezsiniz.');", True)
        End If


    End Sub
    Private Sub UretimeCevir()

        Dim Sql, NewDurum
        Dim kayityap As Boolean = False
        Dim DbConn As New ConnectGiris
        Kullanıcı = Session("KULLANICI")
        PrgKod = Session("PRGKOD")

        NewDurum = 4
        Sql = "update MRKSIP_CBK_FLM " _
              & " set SIPARIS_URETIM_ONAY='" & Kullanıcı & Date.Now & "'," _
                & " DURUM='" & NewDurum & "'" _
                & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
        DbConn.SaveUpdate(Sql)
        DbConn.Kapat()
        txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
        txtKayitDurumu.Text = "Sipariş Üretim Planlamaya gönderildi."
        '        ShowMessage(" Sipariş üretime çevrildi.")
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert(' Sipariş üretime çevrildi.');", True)

        MailGonder(Session("KULLANICI"), Btn_SIP_URT_CEVIR_MAIL, "Sipariş Üretim Planlamaya Alınmıştır.", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))

    End Sub
    Protected Sub Buton_SIP_IPTAL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buton_SIP_IPTAL.Click



        Dim sip_no, reviz_no
        reviz_no = Convert.ToInt32(txtRevizyon.Text)
        sip_no = txtUretimSipNo.Text
        siparisDurumu = GetSiparisDurumu(reviz_no, sip_no)

        Siparis_Iptal_Et()

        'If Program_YetkNumarasi >= siparisDurumu Then

        '    If Program_YetkNumarasi - siparisDurumu <= 1 Then
        '        tabAnaliz.ActiveTab = TabPanel4
        '        Siparis_Iptal_Et()
        '    Else
        '        'ShowMessage("Onay Sıralamanız henüz gelmediği için, İptal işlemini yapamazsınız.")
        '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Onay Sıralamanız henüz gelmediği için, İptal işlemini yapamazsınız.');", True)
        '    End If


        'Else
        '    'ShowMessage("Üst onay aldığı için İptal işlemini gerçekleştiremezsiniz.")
        '    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Üst onay aldığı için İptal işlemini gerçekleştiremezsiniz.');", True)
        'End If

    End Sub

    Private Sub Siparis_Iptal_Et()

        Dim Sql, NewDurum
        Dim kayityap As Boolean = False
        Dim DbConn As New ConnectGiris
        Kullanıcı = Session("KULLANICI")
        PrgKod = Session("PRGKOD")

        NewDurum = 88
        Sql = "update MRKSIP_CBK_FLM " _
              & " set SIPARIS_GIRIS_ONAY='" & Kullanıcı & "-" & "_IPTAL_" & Date.Now & "'," _
                & " DURUM='" & NewDurum & "'" _
                & " WHERE SIP_NO= '" & txtUretimSipNo.Text & "'" _
                & " AND REVIZ_NO= '" & txtRevizyon.Text & "'"
        DbConn.SaveUpdate(Sql)
        DbConn.Kapat()
        txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
        txtKayitDurumu.Text = "Sipariş İptal Edildi."
        'ShowMessage("Sipariş İptal Edildi.")

        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Sipariş İptal Edildi.');", True)

        If Session("PRGKOD") = "DISTIC" Then
            Btn_SIP_IPTAL_MAIL = "SULEYEGEN@DILERHLD.COM;OMERBAYRAKTAR@DILERHLD.COM;elifakyurek@dilerhld.com;mehmetpolat@dilerhld.com;Dileksunar@dilerhld.com;tanfergokalp@dilerhld.com;celalozgundogan@dilerhld.com;semihozkaya@dilerhld.com;damlaisik@dilerhld.com"
        End If

        If Session("PRGKOD") = "ICPIYS" Then
            Btn_SIP_IPTAL_MAIL = "SULEYEGEN@DILERHLD.COM;OMERBAYRAKTAR@DILERHLD.COM;metinsener@dilerhld.com;ErkanAda@dilerhld.com;OnderYilmaz@dilerhld.com;OyaTorunoglu@dilerhld.com;SinemGencay@dilerhld.com;semihozkaya@dilerhld.com;damlaisik@dilerhld.com"
        End If

        If Session("PRGKOD") = "OZLCLK" Then
            Btn_SIP_IPTAL_MAIL = "SULEYEGEN@DILERHLD.COM;OMERBAYRAKTAR@DILERHLD.COM;CANGERCEKER@dilerhld.com;kaanozulu@dilerhld.com;ozgurakkanat@dilerhld.com;celalozgundogan@dilerhld.com;semihozkaya@dilerhld.com;damlaisik@dilerhld.com"
        End If

        'Btn_SIP_IPTAL_MAIL = "ADNANGULER@DILERHLD.COM"

        MailGonder(Session("KULLANICI"), Btn_SIP_IPTAL_MAIL, "Sipariş İptal Edildi", txtUretimSipNo.Text, txtRevizyon.Text, Session("PRGKOD"))

    End Sub

    Protected Sub btnSatirEkle0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSatirCogalt.Click

        fpEbatMiktar.SaveChanges()

        If fpEbatMiktar.Sheets(0).RowCount > 0 Then
            Dim satir = fpEbatMiktar.Sheets(0).RowCount
            For index As Integer = 0 To satir - 1
                If fpEbatMiktar.Sheets(0).Cells(index, 2).Text = txtKaynakLotNo.Text Then
                    fpEbatMiktar.Sheets(0).RowCount += 1
                    fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 2).Text = txtYeniLotNo.Text
                    For index1 As Integer = 3 To 35
                        fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, index1).Text = fpEbatMiktar.Sheets(0).Cells(index, index1).Text
                    Next


                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 3).Text = fpEbatMiktar.Sheets(0).Cells(index, 3).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 4).Text = fpEbatMiktar.Sheets(0).Cells(index, 4).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 5).Text = fpEbatMiktar.Sheets(0).Cells(index, 5).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 6).Text = fpEbatMiktar.Sheets(0).Cells(index, 6).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 7).Text = fpEbatMiktar.Sheets(0).Cells(index, 7).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 8).Text = fpEbatMiktar.Sheets(0).Cells(index, 8).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 9).Text = fpEbatMiktar.Sheets(0).Cells(index, 9).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 10).Text = fpEbatMiktar.Sheets(0).Cells(index, 10).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 11).Text = fpEbatMiktar.Sheets(0).Cells(index, 11).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 12).Text = fpEbatMiktar.Sheets(0).Cells(index, 12).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 13).Text = fpEbatMiktar.Sheets(0).Cells(index, 13).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 14).Text = fpEbatMiktar.Sheets(0).Cells(index, 14).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 15).Text = fpEbatMiktar.Sheets(0).Cells(index, 15).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 16).Text = fpEbatMiktar.Sheets(0).Cells(index, 16).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 17).Text = fpEbatMiktar.Sheets(0).Cells(index, 17).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 18).Text = fpEbatMiktar.Sheets(0).Cells(index, 18).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 19).Text = fpEbatMiktar.Sheets(0).Cells(index, 19).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 20).Text = fpEbatMiktar.Sheets(0).Cells(index, 20).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 21).Text = fpEbatMiktar.Sheets(0).Cells(index, 21).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 22).Text = fpEbatMiktar.Sheets(0).Cells(index, 22).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 23).Text = fpEbatMiktar.Sheets(0).Cells(index, 23).Text
                    'fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 24).Text = fpEbatMiktar.Sheets(0).Cells(index, 24).Text
                    '   fpEbatMiktar.Sheets(0).Cells(fpEbatMiktar.Sheets(0).RowCount - 1, 25).Text = fpEbatMiktar.Sheets(0).Cells(index, 25).Text
                End If
            Next
        End If
    End Sub


    Private Function GetSiparisDurumu(ByVal gelenRevizyonNo As Integer, ByVal gelenSipNo As String) As Integer

        Dim DbConnKontrol As New ConnectGiris

        SQL = "SELECT DURUM FROM MRKSIP_CBK_FLM" _
        & " WHERE SIP_NO='" & gelenSipNo & "'" _
        & " AND REVIZ_NO=" & gelenRevizyonNo


        DbConnKontrol.RaporWhile(SQL)
        siparisDurumu = -1
        While DbConnKontrol.MyDataReader.Read
            siparisDurumu = DbConnKontrol.MyDataReader.Item("DURUM")
        End While

        DbConnKontrol.Kapat()
        Return siparisDurumu

    End Function
    Private Function GetSiparisNoVarmı(ByVal gelenRevizyonNo As Integer, ByVal gelenSipNo As String) As Integer

        'kullaniciDurumu As Integer
        Dim DbConnKontrol As New ConnectGiris
        SQL = "SELECT DURUM FROM MRKSIP_CBK_FLM" _
            & " WHERE SIP_NO='" & gelenSipNo & "'" _
            & " AND SIPARIS_GRUBU='" & PrgKod & "'"
        DbConnKontrol.RaporWhile(SQL)
        While DbConnKontrol.MyDataReader.Read
            SiparisNoZatenVar = True
        End While
        DbConnKontrol.Kapat()
        Return SiparisNoDurumu

    End Function



    Protected Sub BtnYeni0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnKopyala.Click

        'Timer1.Enabled = False

        Soldaki_Tum_alanları_Ac()
        Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)

        txtRevizyon.Text = "0"
        lblEk.Text = ""
        dateSipTar.Text = Date.Now
        txtKopyalaBasildimi.Text = "Evet"
        Buton_SIP_GIRIS.Enabled = True
        BtnSakla.Enabled = True
        txtUretimSipNo.Enabled = True


    End Sub
    Protected Sub dateTerminBas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateTerminBas.TextChanged

        dateTerminBit.Text = dateTerminBas.Text

    End Sub

    Protected Sub BtnYeni3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnYeni3.Click

        'Siparişin düzeltilebilmesi için sipariş durumunun -1 olması gerekmekte

        If Session("AktifSiparisDurumu") = "-1" Then
            'Timer1.Enabled = False
            txtKopyalaBasildimi.Text = "Hayır"
            ' alanlariAc()
            txtUretimSipNo.Enabled = False
            Buton_SIP_GIRIS.Enabled = True
            BtnSakla.Enabled = True
            Soldaki_Tum_alanları_Ac()
            Siparis_Tipinden_Alan_AcKapat(drpMamulTip.Text)
        Else
            txtKayitDurumu.Text = "Siparişin düzeltilebilmesi için onaylanmamış olması gerekmektedir!"
            txtKayitDurumu.BackColor = Drawing.Color.Red
        End If

    End Sub



    Sub Rapor_New2()

        'Kullanıcı
        Dim kacıncı, SipGir, SipGirOnay, SipKontrol, SipOnay, SipUrtonay
        Dim DbConn As New ConnectGiris
        Try
            tabAnaliz.ActiveTab = TabPanel1
            Dim SIPARISIN_GRUBU, SIPARISIN_SAHIBI, KULLANICI_YETKISI, SIPARISI_GIREN
            Dim s1, s2, s3, s4, s5
            Dim ToplamKayitSayisi
            Dim sip_No As String = ""
            sip_No = txtSipNoRapor.Text.Trim
            SQL = " SELECT * FROM MRKSIP_CBK_FLM  WHERE SIP_NO ='" & sip_No & "'"
            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                SIPARISIN_SAHIBI = DbConn.MyDataReader.Item("SIPARIS_SAHIBI")
            End While
            DbConn.Kapat()

            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                SIPARISIN_GRUBU = DbConn.MyDataReader.Item("SIPARIS_GRUBU")
            End While
            DbConn.Kapat()

            DbConn.RaporWhile(SQL)
            While DbConn.MyDataReader.Read
                SIPARISI_GIREN = DbConn.MyDataReader.Item("SIPARISI_GIREN")
            End While
            DbConn.Kapat()

            KULLANICI_YETKISI = Program_YetkNumarasi

            If PrgKod = "URTPLN" Then
                SQL = " SELECT * FROM MRKSIP_CBK_FLM  WHERE SIP_NO ='" & sip_No & "' "
            End If

            If SIPARISIN_GRUBU = PrgKod Or PrgKod = "URTPLN" Then
                If PrgKod = "DISTIC" Then
                    If KULLANICI_YETKISI = 1 Or KULLANICI_YETKISI = 3 Or KULLANICI_YETKISI = 4 Or KULLANICI_YETKISI = -1 Then
                        SQL = " SELECT * FROM MRKSIP_CBK_FLM  WHERE SIP_NO ='" & sip_No & "'"
                    Else
                        If (SIPARISIN_SAHIBI = Kullanıcı Or SIPARISI_GIREN = Kullanıcı) Then
                            SQL = " SELECT * FROM MRKSIP_CBK_FLM  WHERE SIP_NO ='" & sip_No & "'"
                        Else
                            'ShowMessage("Siparişi Açma Yetkiniz Yok.")
                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Siparişi Açma Yetkiniz Yok.');", True)
                            GoTo son
                        End If
                    End If

                Else
                    SQL = " SELECT * FROM MRKSIP_CBK_FLM  WHERE SIP_NO ='" & sip_No & "' "
                End If
            Else
                'ShowMessage("Siparişi Açma Yetkiniz Yok.")
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Siparişi Sistemde bulunamadı.');", True)
                GoTo son
            End If

            DbConn.RaporWhile(SQL)
            Dim i As Int16 = 0
            fpSiparisGetir.Sheets(0).RowCount = 0

            Dim DbconnToplam As New ConnectGiris

            While DbConn.MyDataReader.Read

                fpSiparisGetir.Sheets(0).RowCount += 1
                fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("ULKE")
                fpSiparisGetir.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.Item("DURUM")

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS")) Then
                Else

                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), "-")
                    If kacıncı <> 0 Then
                        SipGir = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 5).Text = SipGir & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipGirOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 6).Text = SipGirOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_KONTROL")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), "-")
                    If kacıncı <> 0 Then
                        SipKontrol = Mid(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 7).Text = SipKontrol & ""
                    End If
                End If
                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 8).Text = SipOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipUrtonay = Mid(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 9).Text = SipUrtonay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARISI_GIREN")) Then
                Else
                    fpSiparisGetir.Sheets(0).Cells(i, 10).Text = DbConn.MyDataReader.Item("SIPARISI_GIREN") & ""
                    fpSiparisGetir.Sheets(0).Cells(i, 11).Text = DbConn.MyDataReader.Item("SIPARIS_SAHIBI") & ""
                    fpSiparisGetir.Sheets(0).Cells(i, 11).Row.Height = 30
                End If

                Try
                    SQL = " SELECT SUM(MIKTAR) TOPLAM FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO= '" & DbConn.MyDataReader.Item("SIP_NO") & "'" _
                    & " AND REVIZ_NO= " & DbConn.MyDataReader.Item("REVIZ_NO")
                    DbconnToplam.RaporWhile(SQL)
                    While DbconnToplam.MyDataReader.Read
                        fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbconnToplam.MyDataReader.Item("TOPLAM") & ""
                    End While
                    DbconnToplam.Kapat()
                Catch ex As Exception
                    fpSiparisGetir.Sheets(0).Cells(i, 2).Text = "0"
                End Try

                Dim drmx
                If DbConn.MyDataReader.Item("DURUM") = -1 Then drmx = "Yeni" ' Sipariş Girildi"
                If DbConn.MyDataReader.Item("DURUM") = 0 Then drmx = "Giriş Onay" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 1 Then drmx = "Kontrol" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 2 Then drmx = "Müdür Onay" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 3 Then drmx = "Planlamada" ' Yönlendirilen Sipariş"
                If DbConn.MyDataReader.Item("DURUM") = 4 Then drmx = "Uretilecek Sip." ' Siparisler"
                If DbConn.MyDataReader.Item("DURUM") = 88 Then drmx = "Iptal" ' Edilen Siparis"
                If DbConn.MyDataReader.Item("DURUM") = 90 Then drmx = "Uretildi" ' Edilen Siparis"
                If DbConn.MyDataReader.Item("DURUM") = 99 Then drmx = "Revize" ' Edilen Siparis"
                fpSiparisGetir.Sheets(0).Cells(i, 14).Text = DbConn.MyDataReader.Item("DURUM") & "-" & drmx
                i += 1
            End While
            DbConn.Kapat()
            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
            'lblMsg.Text = " Bulunan Toplam Kayıt=" & i
            txtSipNoRapor.Text = ""
son:
        Catch ex As Exception
            ' txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
        End Try
    End Sub

    Protected Sub BtnYeni4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IhrKaySip_Yeni.Click

        'Timer1.Enabled = False
        temizle()
        Soldaki_Tum_alanları_Ac()

        If KullanıcıSipYetki = 0 Or KullanıcıSipYetki = 1 Then
            ' kullanıcının sisitemdeki yeri ile seçtiği siparişin yeri tutmaz ise
            'alanlariAc()
            Buton_SIP_GIRIS.Enabled = True
            btnSatirEkle.Enabled = True
            ' Buton_SIP_GIRIS.BackColor = Drawing.Color.SteelBlue
            ' btnSatirEkle.BackColor = Drawing.Color.SteelBlue
            'BtnSil.Enabled = True
            'BtnSil.BackColor = Drawing.Color.SteelBlue
            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = " Yeni Sipariş Bilgilerini Girip Sakla Butonuna basınız"

            BtnSakla.Enabled = True

            ' bunları yeni demeden açamaz saha once kapatmıstık
            ' o yuzden actık
            'txtUretimSipNo.Enabled = True
            txtLotNo.Enabled = True
            drpMamulTip.Enabled = True
            drpStandart.Enabled = True
            drpKalite.Enabled = True
            drpCap.Enabled = True
            drpND.Enabled = True
            drpBoy.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtMiktar.Enabled = True
            txtBoyama.Enabled = True
            txtCubukSayisi.Enabled = True
            txtBirimAgirlik.Enabled = True
            txtPaketAgirlik.Enabled = True
            drpMarka.Enabled = True
            drpRotorTip.Enabled = True
            txtBosLiman.Enabled = True

            Siparis_Sahibi.Enabled = True

            txtCapMikTolMin.Enabled = True
            txtCapMikTolMax.Enabled = True
            txtTopMikTolMin.Enabled = True
            txtTopMikTolMax.Enabled = True


            ' If Session("PRGKOD") = "OZLCLK" Then
            Dim sipNo
            sipNo = "IHR" & Date.Now.ToString("yy") & Date.Now.ToString("MM")
            Dim DbConn As New ConnectGiris
            txtUretimSipNo.Enabled = False
            SQL = " SELECT MAX(SUBSTR(SIP_NO,8,2)) SIPNO " _
            & " FROM MRKSIP_CBK_FLM " _
            & " WHERE SUBSTR(SIP_NO,1,7)='" & sipNo & "'" _
            & " AND REVIZ_NO='0'"
            DbConn.Sayac(SQL)
            Dim sayi As String = DbConn.GeriDonenRakam
            DbConn.Kapat()
            txtMamul.Text = "İhraç Kayıtlı Sipariş"

            If Len(sayi) = 1 Then
                txtUretimSipNo.Text = sipNo & sayi + 1
            Else
                txtUretimSipNo.Text = sipNo & "0" & sayi + 1
            End If

            SiparisSahibiGetir_IHR()

            'End If

        End If

    End Sub
    Dim C_MIN, C_MAX, SI_MIN, SI_MAX, S_MIN, S_MAX, P_MIN, P_MAX, MN_MIN, MN_MAX, NI_MIN, NI_MAX, CR_MIN, CR_MAX, MO_MIN, MO_MAX, V_MIN, V_MAX, CU_MIN, CU_MAX, W_MIN, W_MAX, TI_MIN, TI_MAX, SN_MIN, SN_MAX, CO_MIN, CO_MAX, AL_MIN, AL_MAX, ALSOL_MIN, ALSOL_MAX, ALOXY_MIN, ALOXY_MAX, PB_MIN, PB_MAX, B_MIN, B_MAX, SB_MIN, SB_MAX, NB_MIN, NB_MAX, CA_MIN, CA_MAX, ZN_MIN, ZN_MAX, N_MIN, N_MAX, FE_MIN, FE_MAX, F_MIN, F_MAX, CEQ_MIN, CEQ_MAX, Y1, Y1MIN, Y1MAX, Y2, Y2MIN, Y2MAX, S_PMIN, S_PMAX

    Protected Sub TavlıSip_Click(sender As Object, e As EventArgs) Handles TavlıSip.Click

        YeniBtn("TAVLI")
        '' If Session("PRGKOD") = "OZLCLK" Then
        'Dim sipNo
        'sipNo = "TAV" & Date.Now.ToString("yy") & Date.Now.ToString("MM")
        'Dim DbConn As New ConnectGiris
        'txtUretimSipNo.Enabled = False
        'SQL = " SELECT MAX(SUBSTR(SIP_NO,8,2)) SIPNO " _
        '& " FROM MRKSIP_CBK_FLM " _
        '& " WHERE SUBSTR(SIP_NO,1,7)='" & sipNo & "'" _
        '& " AND REVIZ_NO='0'"
        'DbConn.Sayac(SQL)
        'Dim sayi As String = DbConn.GeriDonenRakam
        'DbConn.Kapat()
        'txtMamul.Text = "Tavlanacak Mlz Sipariş"

        'If Len(sayi) = 1 Then
        '    txtUretimSipNo.Text = sipNo & sayi + 1
        'Else
        '    txtUretimSipNo.Text = sipNo & "0" & sayi + 1
        'End If

        'SiparisSahibiGetir_IHR()

    End Sub

    Protected Sub btnAnalizKaydet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnalizKaydet.Click


        If txtLotAnaliz.Text <> "" Then


            Dim DbConn As New ConnectGiris
            Dim Lot_No
            'Analiz içeride var mı?
            analizDegerAtama()

            Dim analizDurum As Integer = 0
            Dim dbconnSayac As New ConnectGiris

            Try
                SQL = "SELECT COUNT(SIP_NO) FROM MRKSIP_KUTUK_ANALIZ" _
                & " WHERE SIP_NO='" & txtUretimSipNoAnaliz.Text & "'" _
                & " AND REVIZ_NO='" & txtRevizyonAnaliz.Text & "'" _
                & " AND LOT_NO='" & txtLotAnaliz.Text & "'"
                dbconnSayac.Sayac(SQL)
                analizDurum = dbconnSayac.GeriDonenRakam
                dbconnSayac.Kapat()
            Catch ex As Exception

            End Try

            If analizDurum = 0 Then
                'Analiz içeride yoksa
                analizInsert(txtUretimSipNoAnaliz.Text, txtRevizyonAnaliz.Text, txtLotAnaliz.Text)
                'analizAlanlariniTemizle()
            Else
                'Analiz içeride varsa
                analizUpdate(txtUretimSipNoAnaliz.Text, txtRevizyonAnaliz.Text, txtLotAnaliz.Text)
                'analizAlanlariniTemizle()
            End If
            lotAnalizVarYok()
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Analizler Kayıt Edildi.');", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Once Lot seçimi yapınız.');", True)

        End If

    End Sub
    Private Sub analizDegerAtama()

        C_MIN = fpLotKimyasal.Sheets(0).Cells(0, 1).Text
        C_MAX = fpLotKimyasal.Sheets(0).Cells(0, 2).Text
        SI_MIN = fpLotKimyasal.Sheets(0).Cells(1, 1).Text
        SI_MAX = fpLotKimyasal.Sheets(0).Cells(1, 2).Text
        S_MIN = fpLotKimyasal.Sheets(0).Cells(2, 1).Text
        S_MAX = fpLotKimyasal.Sheets(0).Cells(2, 2).Text
        P_MIN = fpLotKimyasal.Sheets(0).Cells(3, 1).Text
        P_MAX = fpLotKimyasal.Sheets(0).Cells(3, 2).Text
        MN_MIN = fpLotKimyasal.Sheets(0).Cells(4, 1).Text
        MN_MAX = fpLotKimyasal.Sheets(0).Cells(4, 2).Text
        NI_MIN = fpLotKimyasal.Sheets(0).Cells(5, 1).Text
        NI_MAX = fpLotKimyasal.Sheets(0).Cells(5, 2).Text
        CR_MIN = fpLotKimyasal.Sheets(0).Cells(6, 1).Text
        CR_MAX = fpLotKimyasal.Sheets(0).Cells(6, 2).Text
        MO_MIN = fpLotKimyasal.Sheets(0).Cells(7, 1).Text
        MO_MAX = fpLotKimyasal.Sheets(0).Cells(7, 2).Text
        V_MIN = fpLotKimyasal.Sheets(0).Cells(8, 1).Text
        V_MAX = fpLotKimyasal.Sheets(0).Cells(8, 2).Text
        CU_MIN = fpLotKimyasal.Sheets(0).Cells(9, 1).Text
        CU_MAX = fpLotKimyasal.Sheets(0).Cells(9, 2).Text
        W_MIN = fpLotKimyasal.Sheets(0).Cells(10, 1).Text
        W_MAX = fpLotKimyasal.Sheets(0).Cells(10, 2).Text
        TI_MIN = fpLotKimyasal.Sheets(0).Cells(11, 1).Text
        TI_MAX = fpLotKimyasal.Sheets(0).Cells(11, 2).Text
        SN_MIN = fpLotKimyasal.Sheets(0).Cells(12, 1).Text
        SN_MAX = fpLotKimyasal.Sheets(0).Cells(12, 2).Text
        CO_MIN = fpLotKimyasal.Sheets(0).Cells(13, 1).Text
        CO_MAX = fpLotKimyasal.Sheets(0).Cells(13, 2).Text
        AL_MIN = fpLotKimyasal.Sheets(0).Cells(14, 1).Text
        AL_MAX = fpLotKimyasal.Sheets(0).Cells(14, 2).Text
        ALSOL_MIN = fpLotKimyasal.Sheets(0).Cells(15, 1).Text
        ALSOL_MAX = fpLotKimyasal.Sheets(0).Cells(15, 2).Text
        ALOXY_MIN = fpLotKimyasal.Sheets(0).Cells(16, 1).Text
        ALOXY_MAX = fpLotKimyasal.Sheets(0).Cells(16, 2).Text
        PB_MIN = fpLotKimyasal.Sheets(0).Cells(17, 1).Text
        PB_MAX = fpLotKimyasal.Sheets(0).Cells(17, 2).Text
        B_MIN = fpLotKimyasal.Sheets(0).Cells(18, 1).Text
        B_MAX = fpLotKimyasal.Sheets(0).Cells(18, 2).Text
        SB_MIN = fpLotKimyasal.Sheets(0).Cells(19, 1).Text
        SB_MAX = fpLotKimyasal.Sheets(0).Cells(19, 2).Text
        NB_MIN = fpLotKimyasal.Sheets(0).Cells(20, 1).Text
        NB_MAX = fpLotKimyasal.Sheets(0).Cells(20, 2).Text
        CA_MIN = fpLotKimyasal.Sheets(0).Cells(21, 1).Text
        CA_MAX = fpLotKimyasal.Sheets(0).Cells(21, 2).Text
        ZN_MIN = fpLotKimyasal.Sheets(0).Cells(22, 1).Text
        ZN_MAX = fpLotKimyasal.Sheets(0).Cells(22, 2).Text
        N_MIN = fpLotKimyasal.Sheets(0).Cells(23, 1).Text
        N_MAX = fpLotKimyasal.Sheets(0).Cells(23, 2).Text
        FE_MIN = fpLotKimyasal.Sheets(0).Cells(24, 1).Text
        FE_MAX = fpLotKimyasal.Sheets(0).Cells(24, 2).Text
        F_MIN = fpLotKimyasal.Sheets(0).Cells(25, 1).Text
        F_MAX = fpLotKimyasal.Sheets(0).Cells(25, 2).Text
        CEQ_MIN = fpLotKimyasal.Sheets(0).Cells(26, 1).Text
        CEQ_MAX = fpLotKimyasal.Sheets(0).Cells(26, 2).Text
        'Y1 = fpLotKimyasal.Sheets(0).Cells(27, 0).Text
        'Y1MIN = fpLotKimyasal.Sheets(0).Cells(27, 1).Text
        'Y1MAX = fpLotKimyasal.Sheets(0).Cells(27, 2).Text
        'Y2 = fpLotKimyasal.Sheets(0).Cells(28, 0).Text
        'Y2MIN = fpLotKimyasal.Sheets(0).Cells(28, 1).Text
        'Y2MAX = fpLotKimyasal.Sheets(0).Cells(28, 2).Text
        S_PMIN = fpLotKimyasal.Sheets(0).Cells(27, 1).Text
        S_PMAX = fpLotKimyasal.Sheets(0).Cells(27, 2).Text
        'Y1,Y1MIN,Y1MAX,Y2,Y2MIN,Y2MAX



        C_MIN = IIf(C_MIN Is Nothing Or C_MIN = "", "-", C_MIN)
        C_MAX = IIf(C_MAX Is Nothing Or C_MAX = "", "-", C_MAX)
        SI_MIN = IIf(SI_MIN Is Nothing Or SI_MIN = "", "-", SI_MIN)
        SI_MAX = IIf(SI_MAX Is Nothing Or SI_MAX = "", "-", SI_MAX)
        S_MIN = IIf(S_MIN Is Nothing Or S_MIN = "", "-", S_MIN)
        S_MAX = IIf(S_MAX Is Nothing Or S_MAX = "", "-", S_MAX)
        P_MIN = IIf(P_MIN Is Nothing Or P_MIN = "", "-", P_MIN)
        P_MAX = IIf(P_MAX Is Nothing Or P_MAX = "", "-", P_MAX)
        MN_MIN = IIf(MN_MIN Is Nothing Or MN_MIN = "", "-", MN_MIN)
        MN_MAX = IIf(MN_MAX Is Nothing Or MN_MAX = "", "-", MN_MAX)
        NI_MIN = IIf(NI_MIN Is Nothing Or NI_MIN = "", "-", NI_MIN)
        NI_MAX = IIf(NI_MAX Is Nothing Or NI_MAX = "", "-", NI_MAX)
        CR_MIN = IIf(CR_MIN Is Nothing Or CR_MIN = "", "-", CR_MIN)
        CR_MAX = IIf(CR_MAX Is Nothing Or CR_MAX = "", "-", CR_MAX)
        MO_MIN = IIf(MO_MIN Is Nothing Or MO_MIN = "", "-", MO_MIN)
        MO_MAX = IIf(MO_MAX Is Nothing Or MO_MAX = "", "-", MO_MAX)
        V_MIN = IIf(V_MIN Is Nothing Or V_MIN = "", "-", V_MIN)
        V_MAX = IIf(V_MAX Is Nothing Or V_MAX = "", "-", V_MAX)
        CU_MIN = IIf(CU_MIN Is Nothing Or CU_MIN = "", "-", CU_MIN)
        CU_MAX = IIf(CU_MAX Is Nothing Or CU_MAX = "", "-", CU_MAX)
        W_MIN = IIf(W_MIN Is Nothing Or W_MIN = "", "-", W_MIN)
        W_MAX = IIf(W_MAX Is Nothing Or W_MAX = "", "-", W_MAX)
        TI_MIN = IIf(TI_MIN Is Nothing Or TI_MIN = "", "-", TI_MIN)
        TI_MAX = IIf(TI_MAX Is Nothing Or TI_MAX = "", "-", TI_MAX)
        SN_MIN = IIf(SN_MIN Is Nothing Or SN_MIN = "", "-", SN_MIN)
        SN_MAX = IIf(SN_MAX Is Nothing Or SN_MAX = "", "-", SN_MAX)
        CO_MIN = IIf(CO_MIN Is Nothing Or CO_MIN = "", "-", CO_MIN)
        CO_MAX = IIf(CO_MAX Is Nothing Or CO_MAX = "", "-", CO_MAX)
        AL_MIN = IIf(AL_MIN Is Nothing Or AL_MIN = "", "-", AL_MIN)
        AL_MAX = IIf(AL_MAX Is Nothing Or AL_MAX = "", "-", AL_MAX)
        ALSOL_MIN = IIf(ALSOL_MIN Is Nothing Or ALSOL_MIN = "", "-", ALSOL_MIN)
        ALSOL_MAX = IIf(ALSOL_MAX Is Nothing Or ALSOL_MAX = "", "-", ALSOL_MAX)
        ALOXY_MIN = IIf(ALOXY_MIN Is Nothing Or ALOXY_MIN = "", "-", ALOXY_MIN)
        ALOXY_MAX = IIf(ALOXY_MAX Is Nothing Or ALOXY_MAX = "", "-", ALOXY_MAX)
        PB_MIN = IIf(PB_MIN Is Nothing Or PB_MIN = "", "-", PB_MIN)
        PB_MAX = IIf(PB_MAX Is Nothing Or PB_MAX = "", "-", PB_MAX)
        B_MIN = IIf(B_MIN Is Nothing Or B_MIN = "", "-", B_MIN)
        B_MAX = IIf(B_MAX Is Nothing Or B_MAX = "", "-", B_MAX)
        SB_MIN = IIf(SB_MIN Is Nothing Or SB_MIN = "", "-", SB_MIN)
        SB_MAX = IIf(SB_MAX Is Nothing Or SB_MAX = "", "-", SB_MAX)
        NB_MIN = IIf(NB_MIN Is Nothing Or NB_MIN = "", "-", NB_MIN)
        NB_MAX = IIf(NB_MAX Is Nothing Or NB_MAX = "", "-", NB_MAX)
        CA_MIN = IIf(CA_MIN Is Nothing Or CA_MIN = "", "-", CA_MIN)
        CA_MAX = IIf(CA_MAX Is Nothing Or CA_MAX = "", "-", CA_MAX)
        ZN_MIN = IIf(ZN_MIN Is Nothing Or ZN_MIN = "", "-", ZN_MIN)
        ZN_MAX = IIf(ZN_MAX Is Nothing Or ZN_MAX = "", "-", ZN_MAX)
        N_MIN = IIf(N_MIN Is Nothing Or N_MIN = "", "-", N_MIN)
        N_MAX = IIf(N_MAX Is Nothing Or N_MAX = "", "-", N_MAX)
        FE_MIN = IIf(FE_MIN Is Nothing Or FE_MIN = "", "-", FE_MIN)
        FE_MAX = IIf(FE_MAX Is Nothing Or FE_MAX = "", "-", FE_MAX)
        F_MIN = IIf(F_MIN Is Nothing Or F_MIN = "", "-", F_MIN)
        F_MAX = IIf(F_MAX Is Nothing Or F_MAX = "", "-", F_MAX)
        CEQ_MIN = IIf(CEQ_MIN Is Nothing Or CEQ_MIN = "", "-", CEQ_MIN)
        CEQ_MAX = IIf(CEQ_MAX Is Nothing Or CEQ_MAX = "", "-", CEQ_MAX)
        'Y1 = IIf(Y1 Is Nothing Or Y1 = "", "-", Y1)
        'Y1MIN = IIf(Y1MIN Is Nothing Or Y1MIN = "", "-", Y1MIN)
        'Y1MAX = IIf(Y1MAX Is Nothing Or Y1MAX = "", "-", Y1MAX)
        'Y2 = IIf(Y2 Is Nothing Or Y2 = "", "-", Y2)
        'Y2MIN = IIf(Y2MIN Is Nothing Or Y2MIN = "", "-", Y2MIN)
        'Y2MAX = IIf(Y2MAX Is Nothing Or Y2MAX = "", "-", Y2MAX)
        S_PMIN = IIf(S_PMIN Is Nothing Or S_PMIN = "", "-", S_PMIN)
        S_PMAX = IIf(S_PMAX Is Nothing Or S_PMAX = "", "-", S_PMAX)
        'Y1,Y1MIN,Y1MAX,Y2,Y2MIN,Y2MAX
    End Sub
    Private Sub analizInsert(ByVal gelenSipNo, ByVal gelenRevNo, ByVal gelenLotNo)
        Dim DbconnInsert As New ConnectGiris

        Try
            SQL = " INSERT INTO MRKSIP_KUTUK_ANALIZ(SIP_NO, REVIZ_NO, LOT_NO,C_MIN,C_MAX,SI_MIN,SI_MAX,S_MIN,S_MAX,P_MIN,P_MAX,MN_MIN,MN_MAX,NI_MIN,NI_MAX,CR_MIN,CR_MAX,MO_MIN,MO_MAX,V_MIN,V_MAX,CU_MIN,CU_MAX,W_MIN,W_MAX,TI_MIN,TI_MAX,SN_MIN,SN_MAX,CO_MIN,CO_MAX,AL_MIN,AL_MAX,ALSOL_MIN,ALSOL_MAX,ALOXY_MIN,ALOXY_MAX,PB_MIN,PB_MAX,B_MIN,B_MAX,SB_MIN,SB_MAX,NB_MIN,NB_MAX,CA_MIN,CA_MAX,ZN_MIN,ZN_MAX,N_MIN,N_MAX,FE_MIN,FE_MAX,F_MIN,F_MAX,CEQ_MIN,CEQ_MAX,Y1,Y1MIN,Y1MAX,Y2,Y2MIN,Y2MAX,S_PMIN,S_PMAX) VALUES(" _
                 & "'" & gelenSipNo & "'," _
                 & "'" & gelenRevNo & "'," _
                 & "'" & gelenLotNo & "'," _
                 & "'" & C_MIN & "'," _
                 & "'" & C_MAX & "'," _
                 & "'" & SI_MIN & "'," _
                 & "'" & SI_MAX & "'," _
                 & "'" & S_MIN & "'," _
                 & "'" & S_MAX & "'," _
                 & "'" & P_MIN & "'," _
                 & "'" & P_MAX & "'," _
                 & "'" & MN_MIN & "'," _
                 & "'" & MN_MAX & "'," _
                 & "'" & NI_MIN & "'," _
                 & "'" & NI_MAX & "'," _
                 & "'" & CR_MIN & "'," _
                 & "'" & CR_MAX & "'," _
                 & "'" & MO_MIN & "'," _
                 & "'" & MO_MAX & "'," _
                 & "'" & V_MIN & "'," _
                 & "'" & V_MAX & "'," _
                 & "'" & CU_MIN & "'," _
                 & "'" & CU_MAX & "'," _
                 & "'" & W_MIN & "'," _
                 & "'" & W_MAX & "'," _
                 & "'" & TI_MIN & "'," _
                 & "'" & TI_MAX & "'," _
                 & "'" & SN_MIN & "'," _
                 & "'" & SN_MAX & "'," _
                 & "'" & CO_MIN & "'," _
                 & "'" & CO_MAX & "'," _
                 & "'" & AL_MIN & "'," _
                 & "'" & AL_MAX & "'," _
                 & "'" & ALSOL_MIN & "'," _
                 & "'" & ALSOL_MAX & "'," _
                 & "'" & ALOXY_MIN & "'," _
                 & "'" & ALOXY_MAX & "'," _
                 & "'" & PB_MIN & "'," _
                 & "'" & PB_MAX & "'," _
                 & "'" & B_MIN & "'," _
                 & "'" & B_MAX & "'," _
                 & "'" & SB_MIN & "'," _
                 & "'" & SB_MAX & "'," _
                 & "'" & NB_MIN & "'," _
                 & "'" & NB_MAX & "'," _
                 & "'" & CA_MIN & "'," _
                 & "'" & CA_MAX & "'," _
                 & "'" & ZN_MIN & "'," _
                 & "'" & ZN_MAX & "'," _
                 & "'" & N_MIN & "'," _
                 & "'" & N_MAX & "'," _
                 & "'" & FE_MIN & "'," _
                 & "'" & FE_MAX & "'," _
                 & "'" & F_MIN & "'," _
                 & "'" & F_MAX & "'," _
                 & "'" & CEQ_MIN & "'," _
                 & "'" & CEQ_MAX & "'," _
                 & "'" & Y1 & "'," _
                 & "'" & Y1MIN & "'," _
                 & "'" & Y1MAX & "'," _
                 & "'" & Y2 & "'," _
                 & "'" & Y2MIN & "'," _
                 & "'" & Y2MAX & "'," _
                 & "'" & S_PMIN & "'," _
                 & "'" & S_PMAX & "')"

            DbconnInsert.SaveUpdate(SQL)
            DbconnInsert.Kapat()



        Catch ex As Exception
            DbconnInsert.Kapat()
        End Try

    End Sub
    Private Sub analizUpdate(ByVal gelenSipNo, ByVal gelenRevNo, ByVal gelenLotNo)
        Dim DbConnUpdate As New ConnectGiris

        Try
            SQL = " UPDATE MRKSIP_KUTUK_ANALIZ" _
            & " SET " _
            & " C_MIN='" & C_MIN & "'," _
            & " C_MAX='" & C_MAX & "'," _
            & " SI_MIN='" & SI_MIN & "'," _
            & " SI_MAX='" & SI_MAX & "'," _
            & " S_MIN='" & S_MIN & "'," _
            & " S_MAX='" & S_MAX & "'," _
            & " P_MIN='" & P_MIN & "'," _
            & " P_MAX='" & P_MAX & "'," _
            & " MN_MIN='" & MN_MIN & "'," _
            & " MN_MAX='" & MN_MAX & "'," _
            & " NI_MIN='" & NI_MIN & "'," _
            & " NI_MAX='" & NI_MAX & "'," _
            & " CR_MIN='" & CR_MIN & "'," _
            & " CR_MAX='" & CR_MAX & "'," _
            & " MO_MIN='" & MO_MIN & "'," _
            & " MO_MAX='" & MO_MAX & "'," _
            & " V_MIN='" & V_MIN & "'," _
            & " V_MAX='" & V_MAX & "'," _
            & " CU_MIN='" & CU_MIN & "'," _
            & " CU_MAX='" & CU_MAX & "'," _
            & " W_MIN='" & W_MIN & "'," _
            & " W_MAX='" & W_MAX & "'," _
            & " TI_MIN='" & TI_MIN & "'," _
            & " TI_MAX='" & TI_MAX & "'," _
            & " SN_MIN='" & SN_MIN & "'," _
            & " SN_MAX='" & SN_MAX & "'," _
            & " CO_MIN='" & CO_MIN & "'," _
            & " CO_MAX='" & CO_MAX & "'," _
            & " AL_MIN='" & AL_MIN & "'," _
            & " AL_MAX='" & AL_MAX & "'," _
            & " ALSOL_MIN='" & ALSOL_MIN & "'," _
            & " ALSOL_MAX='" & ALSOL_MAX & "'," _
            & " ALOXY_MIN='" & ALOXY_MIN & "'," _
            & " ALOXY_MAX='" & ALOXY_MAX & "'," _
            & " PB_MIN='" & PB_MIN & "'," _
            & " PB_MAX='" & PB_MAX & "'," _
            & " B_MIN='" & B_MIN & "'," _
            & " B_MAX='" & B_MAX & "'," _
            & " SB_MIN='" & SB_MIN & "'," _
            & " SB_MAX='" & SB_MAX & "'," _
            & " NB_MIN='" & NB_MIN & "'," _
            & " NB_MAX='" & NB_MAX & "'," _
            & " CA_MIN='" & CA_MIN & "'," _
            & " CA_MAX='" & CA_MAX & "'," _
            & " ZN_MIN='" & ZN_MIN & "'," _
            & " ZN_MAX='" & ZN_MAX & "'," _
            & " N_MIN='" & N_MIN & "'," _
            & " N_MAX='" & N_MAX & "'," _
            & " FE_MIN='" & FE_MIN & "'," _
            & " FE_MAX='" & FE_MAX & "'," _
            & " F_MIN='" & F_MIN & "'," _
            & " F_MAX='" & F_MAX & "'," _
            & " CEQ_MIN='" & CEQ_MIN & "'," _
            & " CEQ_MAX='" & CEQ_MAX & "'," _
            & " Y1='" & Y1 & "'," _
            & " Y1MIN='" & Y1MIN & "'," _
            & " Y1MAX='" & Y1MAX & "'," _
            & " Y2='" & Y2 & "'," _
            & " Y2MIN='" & Y2MIN & "'," _
            & " Y2MAX='" & Y2MAX & "'," _
            & " S_PMIN='" & S_PMIN & "'," _
            & " S_PMAX='" & S_PMAX & "'" _
            & " WHERE SIP_NO ='" & gelenSipNo & "'" _
            & " AND REVIZ_NO='" & gelenRevNo & "'" _
            & " AND LOT_NO='" & gelenLotNo & "'"
            'Y1,Y1MIN,Y1MAX,Y2,Y2MIN,Y2MAX

            DbConnUpdate.SaveUpdate(SQL)
            DbConnUpdate.Kapat()
            'LblKayitDurum.Text = "Kayıt başarı ile tamamlandı."
            'LblKayitDurum.BackColor = Drawing.Color.Green
        Catch ex As Exception

        End Try
    End Sub
    Private Sub lotlariListele()
        'fpEbatMiktar.Sheets(0).SortRows(2, True, True)
        fpLotListe.Sheets(0).RowCount = 0
        Dim i = 0

        For index As Integer = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
            ' If index = 0 Then
            fpLotListe.Sheets(0).RowCount = fpLotListe.Sheets(0).RowCount + 1

            fpLotListe.Sheets(0).Cells(index, 1).Text = fpEbatMiktar.Sheets(0).Cells(index, 2).Text
            fpLotListe.Sheets(0).Cells(index, 3).Text = fpEbatMiktar.Sheets(0).Cells(index, 5).Text

            'Else
            '            If fpLotListe.Sheets(0).Cells(fpLotListe.Sheets(0).RowCount - 1, 1).Text <> fpEbatMiktar.Sheets(0).Cells(index, 2).Text Then
            'fpLotListe.Sheets(0).RowCount = fpLotListe.Sheets(0).RowCount + 1
            'fpLotListe.Sheets(0).Cells(fpLotListe.Sheets(0).RowCount - 1, 1).Text = fpEbatMiktar.Sheets(0).Cells(index, 2).Text
            '     fpLotListe.Sheets(0).Cells(fpLotListe.Sheets(0).RowCount - 1, 3).Text = fpEbatMiktar.Sheets(0).Cells(index, 4).Text


            'Else

            'End If


            'End If
        Next
        lotAnalizVarYok()

    End Sub
    Private Sub lotAnalizVarYok()
        Dim analizDurum As Boolean
        Dim dizi(58) As String
        Dim dbconnAnaliz As New ConnectGiris
        For index As Integer = 0 To fpLotListe.Sheets(0).RowCount - 1
            analizDurum = False
            For index1 As Integer = 0 To dizi.Length - 1
                dizi(index1) = "-"
            Next
            Try
                SQL = "SELECT * FROM MRKSIP_KUTUK_ANALIZ" _
                & " WHERE SIP_NO='" & txtUretimSipNoAnaliz.Text & "'" _
                & " AND REVIZ_NO='" & txtRevizyonAnaliz.Text & "'" _
                & " AND LOT_NO='" & fpLotListe.Sheets(0).Cells(index, 1).Text & "'"
                dbconnAnaliz.RaporWhile(SQL)
                While dbconnAnaliz.MyDataReader.Read
                    dizi(0) = dbconnAnaliz.MyDataReader.Item("C_MIN")
                    dizi(1) = dbconnAnaliz.MyDataReader.Item("C_MAX")
                    dizi(2) = dbconnAnaliz.MyDataReader.Item("SI_MIN")
                    dizi(3) = dbconnAnaliz.MyDataReader.Item("SI_MAX")
                    dizi(4) = dbconnAnaliz.MyDataReader.Item("S_MIN")
                    dizi(5) = dbconnAnaliz.MyDataReader.Item("S_MAX")
                    dizi(6) = dbconnAnaliz.MyDataReader.Item("P_MIN")
                    dizi(7) = dbconnAnaliz.MyDataReader.Item("P_MAX")
                    dizi(8) = dbconnAnaliz.MyDataReader.Item("MN_MIN")
                    dizi(9) = dbconnAnaliz.MyDataReader.Item("MN_MAX")
                    dizi(10) = dbconnAnaliz.MyDataReader.Item("NI_MIN")
                    dizi(11) = dbconnAnaliz.MyDataReader.Item("NI_MAX")
                    dizi(12) = dbconnAnaliz.MyDataReader.Item("CR_MIN")
                    dizi(13) = dbconnAnaliz.MyDataReader.Item("CR_MAX")
                    dizi(14) = dbconnAnaliz.MyDataReader.Item("MO_MIN")
                    dizi(15) = dbconnAnaliz.MyDataReader.Item("MO_MAX")
                    dizi(16) = dbconnAnaliz.MyDataReader.Item("V_MIN")
                    dizi(17) = dbconnAnaliz.MyDataReader.Item("V_MAX")
                    dizi(18) = dbconnAnaliz.MyDataReader.Item("CU_MIN")
                    dizi(19) = dbconnAnaliz.MyDataReader.Item("CU_MAX")
                    dizi(20) = dbconnAnaliz.MyDataReader.Item("W_MIN")
                    dizi(21) = dbconnAnaliz.MyDataReader.Item("W_MAX")
                    dizi(22) = dbconnAnaliz.MyDataReader.Item("TI_MIN")
                    dizi(23) = dbconnAnaliz.MyDataReader.Item("TI_MAX")
                    dizi(24) = dbconnAnaliz.MyDataReader.Item("SN_MIN")
                    dizi(25) = dbconnAnaliz.MyDataReader.Item("SN_MAX")
                    dizi(26) = dbconnAnaliz.MyDataReader.Item("CO_MIN")
                    dizi(27) = dbconnAnaliz.MyDataReader.Item("CO_MAX")
                    dizi(28) = dbconnAnaliz.MyDataReader.Item("AL_MIN")
                    dizi(29) = dbconnAnaliz.MyDataReader.Item("AL_MAX")
                    dizi(30) = dbconnAnaliz.MyDataReader.Item("ALSOL_MIN")
                    dizi(31) = dbconnAnaliz.MyDataReader.Item("ALSOL_MAX")
                    dizi(32) = dbconnAnaliz.MyDataReader.Item("ALOXY_MIN")
                    dizi(33) = dbconnAnaliz.MyDataReader.Item("ALOXY_MAX")
                    dizi(34) = dbconnAnaliz.MyDataReader.Item("PB_MIN")
                    dizi(35) = dbconnAnaliz.MyDataReader.Item("PB_MAX")
                    dizi(36) = dbconnAnaliz.MyDataReader.Item("B_MIN")
                    dizi(37) = dbconnAnaliz.MyDataReader.Item("B_MAX")
                    dizi(38) = dbconnAnaliz.MyDataReader.Item("SB_MIN")
                    dizi(39) = dbconnAnaliz.MyDataReader.Item("SB_MAX")
                    dizi(40) = dbconnAnaliz.MyDataReader.Item("NB_MIN")
                    dizi(41) = dbconnAnaliz.MyDataReader.Item("NB_MAX")
                    dizi(42) = dbconnAnaliz.MyDataReader.Item("CA_MIN")
                    dizi(43) = dbconnAnaliz.MyDataReader.Item("CA_MAX")
                    dizi(44) = dbconnAnaliz.MyDataReader.Item("ZN_MIN")
                    dizi(45) = dbconnAnaliz.MyDataReader.Item("ZN_MAX")
                    dizi(46) = dbconnAnaliz.MyDataReader.Item("N_MIN")
                    dizi(47) = dbconnAnaliz.MyDataReader.Item("N_MAX")
                    dizi(48) = dbconnAnaliz.MyDataReader.Item("FE_MIN")
                    dizi(49) = dbconnAnaliz.MyDataReader.Item("FE_MAX")
                    dizi(50) = dbconnAnaliz.MyDataReader.Item("F_MIN")
                    dizi(51) = dbconnAnaliz.MyDataReader.Item("F_MAX")
                    dizi(52) = dbconnAnaliz.MyDataReader.Item("CEQ_MIN")
                    dizi(53) = dbconnAnaliz.MyDataReader.Item("CEQ_MAX")
                    dizi(54) = dbconnAnaliz.MyDataReader.Item("Y1MIN")
                    dizi(55) = dbconnAnaliz.MyDataReader.Item("Y1MAX")
                    dizi(56) = dbconnAnaliz.MyDataReader.Item("Y2MIN")
                    dizi(57) = dbconnAnaliz.MyDataReader.Item("Y2MAX")
                    dizi(58) = dbconnAnaliz.MyDataReader.Item("S_PMIN")
                    dizi(59) = dbconnAnaliz.MyDataReader.Item("S_PMAX")
                End While
                dbconnAnaliz.Kapat()
                For Each letter As String In dizi
                    If letter Is Nothing Then
                    Else
                        If letter.Contains("-") Then
                        Else
                            analizDurum = True
                        End If
                    End If
                Next
                If analizDurum Then
                    fpLotListe.Sheets(0).Cells(index, 2).Text = "Var"
                Else
                    fpLotListe.Sheets(0).Cells(index, 2).Text = "Yok"
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Sub analizGetir(ByVal gelenLot, ByVal Durum, ByVal Kalite)
        analizAlanlariniTemizle()
        Dim rev1C_MIN, rev1C_MAX, rev1SI_MIN, rev1SI_MAX, rev1S_MIN, rev1S_MAX, rev1P_MIN, rev1P_MAX, rev1MN_MIN, rev1MN_MAX, rev1NI_MIN, rev1NI_MAX, rev1CR_MIN, rev1CR_MAX, rev1MO_MIN, rev1MO_MAX, rev1V_MIN, rev1V_MAX, rev1CU_MIN, rev1CU_MAX, rev1W_MIN, rev1W_MAX, rev1TI_MIN, rev1TI_MAX, rev1SN_MIN, rev1SN_MAX, rev1CO_MIN, rev1CO_MAX, rev1AL_MIN, rev1AL_MAX, rev1ALSOL_MIN, rev1ALSOL_MAX, rev1ALOXY_MIN, rev1ALOXY_MAX, rev1PB_MIN, rev1PB_MAX, rev1B_MIN, rev1B_MAX, rev1SB_MIN, rev1SB_MAX, rev1NB_MIN, rev1NB_MAX, rev1CA_MIN, rev1CA_MAX, rev1ZN_MIN, rev1ZN_MAX, rev1N_MIN, rev1N_MAX, rev1FE_MIN, rev1FE_MAX, rev1F_MIN, rev1F_MAX, rev1CEQ_MIN, rev1CEQ_MAX, revY1, revY1MIN, revY1MAX, revY2, revY2MIN, revY2MAX, REVS_PMIN, REVS_PMAX, REV1S_PMIN, REV1S_PMAX
        Dim SQL As String

        If Durum > 0 Then
            SQL = " SELECT * FROM MRKSIP_KUTUK_ANALIZ" _
              & " WHERE SIP_NO='" & txtUretimSipNoAnaliz.Text & "'" _
              & " AND REVIZ_NO=" & txtRevizyonAnaliz.Text _
              & " AND LOT_NO='" & gelenLot & "'"
        Else
            SQL = " SELECT * FROM (SELECT * FROM MRKSIP_KUTUK_ANALIZ_SET" _
              & " WHERE KALITE='" & Kalite & "' ORDER BY OZELNO DESC) WHERE ROWNUM=1"

        End If


        Dim DbConn As New ConnectGiris
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            rev1C_MIN = DbConn.MyDataReader.Item("C_MIN")
            rev1C_MAX = DbConn.MyDataReader.Item("C_MAX")
            rev1SI_MIN = DbConn.MyDataReader.Item("SI_MIN")
            rev1SI_MAX = DbConn.MyDataReader.Item("SI_MAX")
            rev1S_MIN = DbConn.MyDataReader.Item("S_MIN")
            rev1S_MAX = DbConn.MyDataReader.Item("S_MAX")
            rev1P_MIN = DbConn.MyDataReader.Item("P_MIN")
            rev1P_MAX = DbConn.MyDataReader.Item("P_MAX")
            rev1MN_MIN = DbConn.MyDataReader.Item("MN_MIN")
            rev1MN_MAX = DbConn.MyDataReader.Item("MN_MAX")
            rev1NI_MIN = DbConn.MyDataReader.Item("NI_MIN")
            rev1NI_MAX = DbConn.MyDataReader.Item("NI_MAX")
            rev1CR_MIN = DbConn.MyDataReader.Item("CR_MIN")
            rev1CR_MAX = DbConn.MyDataReader.Item("CR_MAX")
            rev1MO_MIN = DbConn.MyDataReader.Item("MO_MIN")
            rev1MO_MAX = DbConn.MyDataReader.Item("MO_MAX")
            rev1V_MIN = DbConn.MyDataReader.Item("V_MIN")
            rev1V_MAX = DbConn.MyDataReader.Item("V_MAX")
            rev1CU_MIN = DbConn.MyDataReader.Item("CU_MIN")
            rev1CU_MAX = DbConn.MyDataReader.Item("CU_MAX")
            rev1W_MIN = DbConn.MyDataReader.Item("W_MIN")
            rev1W_MAX = DbConn.MyDataReader.Item("W_MAX")
            rev1TI_MIN = DbConn.MyDataReader.Item("TI_MIN")
            rev1TI_MAX = DbConn.MyDataReader.Item("TI_MAX")
            rev1SN_MIN = DbConn.MyDataReader.Item("SN_MIN")
            rev1SN_MAX = DbConn.MyDataReader.Item("SN_MAX")
            rev1CO_MIN = DbConn.MyDataReader.Item("CO_MIN")
            rev1CO_MAX = DbConn.MyDataReader.Item("CO_MAX")
            rev1AL_MIN = DbConn.MyDataReader.Item("AL_MIN")
            rev1AL_MAX = DbConn.MyDataReader.Item("AL_MAX")
            rev1ALSOL_MIN = DbConn.MyDataReader.Item("ALSOL_MIN")
            rev1ALSOL_MAX = DbConn.MyDataReader.Item("ALSOL_MAX")
            rev1ALOXY_MIN = DbConn.MyDataReader.Item("ALOXY_MIN")
            rev1ALOXY_MAX = DbConn.MyDataReader.Item("ALOXY_MAX")
            rev1PB_MIN = DbConn.MyDataReader.Item("PB_MIN")
            rev1PB_MAX = DbConn.MyDataReader.Item("PB_MAX")
            rev1B_MIN = DbConn.MyDataReader.Item("B_MIN")
            rev1B_MAX = DbConn.MyDataReader.Item("B_MAX")
            rev1SB_MIN = DbConn.MyDataReader.Item("SB_MIN")
            rev1SB_MAX = DbConn.MyDataReader.Item("SB_MAX")
            rev1NB_MIN = DbConn.MyDataReader.Item("NB_MIN")
            rev1NB_MAX = DbConn.MyDataReader.Item("NB_MAX")
            rev1CA_MIN = DbConn.MyDataReader.Item("CA_MIN")
            rev1CA_MAX = DbConn.MyDataReader.Item("CA_MAX")
            rev1ZN_MIN = DbConn.MyDataReader.Item("ZN_MIN")
            rev1ZN_MAX = DbConn.MyDataReader.Item("ZN_MAX")
            rev1N_MIN = DbConn.MyDataReader.Item("N_MIN")
            rev1N_MAX = DbConn.MyDataReader.Item("N_MAX")
            rev1FE_MIN = DbConn.MyDataReader.Item("FE_MIN")
            rev1FE_MAX = DbConn.MyDataReader.Item("FE_MAX")
            rev1F_MIN = DbConn.MyDataReader.Item("F_MIN")
            rev1F_MAX = DbConn.MyDataReader.Item("F_MAX")
            rev1CEQ_MIN = DbConn.MyDataReader.Item("CEQ_MIN")
            rev1CEQ_MAX = DbConn.MyDataReader.Item("CEQ_MAX")
            revY1 = DbConn.MyDataReader.Item("Y1")
            revY1MIN = DbConn.MyDataReader.Item("Y1MIN")
            revY1MAX = DbConn.MyDataReader.Item("Y1MAX")
            revY2 = DbConn.MyDataReader.Item("Y2")
            revY2MIN = DbConn.MyDataReader.Item("Y2MIN")
            revY2MAX = DbConn.MyDataReader.Item("Y2MAX")
            REV1S_PMIN = DbConn.MyDataReader.Item("S_PMIN")
            REV1S_PMAX = DbConn.MyDataReader.Item("S_PMAX")
            'End While


            'SQL = " SELECT * FROM MRKSIP_KUTUK_ANALIZ" _
            '      & " WHERE SIP_NO='" & txtUretimSipNoAnaliz.Text & "'" _
            '      & " AND REVIZ_NO=" & txtRevizyonAnaliz.Text _
            '      & " AND LOT_NO='" & gelenLot & "'"
            'DbConn.RaporWhile(SQL)
            'While DbConn.MyDataReader.Read
            For index As Integer = 0 To fpLotKimyasal.Sheets(0).RowCount - 1

                fpLotKimyasal.Sheets(0).Cells(index, 1).BackColor = Drawing.Color.White
                fpLotKimyasal.Sheets(0).Cells(index, 2).BackColor = Drawing.Color.White
            Next

            fpLotKimyasal.Sheets(0).Cells(0, 1).Text = IIf(DbConn.MyDataReader.Item("C_MIN") = "-", "", DbConn.MyDataReader.Item("C_MIN"))
            fpLotKimyasal.Sheets(0).Cells(0, 2).Text = IIf(DbConn.MyDataReader.Item("C_MAX") = "-", "", DbConn.MyDataReader.Item("C_MAX"))
            fpLotKimyasal.Sheets(0).Cells(1, 1).Text = IIf(DbConn.MyDataReader.Item("SI_MIN") = "-", "", DbConn.MyDataReader.Item("SI_MIN"))
            fpLotKimyasal.Sheets(0).Cells(1, 2).Text = IIf(DbConn.MyDataReader.Item("SI_MAX") = "-", "", DbConn.MyDataReader.Item("SI_MAX"))
            fpLotKimyasal.Sheets(0).Cells(2, 1).Text = IIf(DbConn.MyDataReader.Item("S_MIN") = "-", "", DbConn.MyDataReader.Item("S_MIN"))
            fpLotKimyasal.Sheets(0).Cells(2, 2).Text = IIf(DbConn.MyDataReader.Item("S_MAX") = "-", "", DbConn.MyDataReader.Item("S_MAX"))
            fpLotKimyasal.Sheets(0).Cells(3, 1).Text = IIf(DbConn.MyDataReader.Item("P_MIN") = "-", "", DbConn.MyDataReader.Item("P_MIN"))
            fpLotKimyasal.Sheets(0).Cells(3, 2).Text = IIf(DbConn.MyDataReader.Item("P_MAX") = "-", "", DbConn.MyDataReader.Item("P_MAX"))
            fpLotKimyasal.Sheets(0).Cells(4, 1).Text = IIf(DbConn.MyDataReader.Item("MN_MIN") = "-", "", DbConn.MyDataReader.Item("MN_MIN"))
            fpLotKimyasal.Sheets(0).Cells(4, 2).Text = IIf(DbConn.MyDataReader.Item("MN_MAX") = "-", "", DbConn.MyDataReader.Item("MN_MAX"))
            fpLotKimyasal.Sheets(0).Cells(5, 1).Text = IIf(DbConn.MyDataReader.Item("NI_MIN") = "-", "", DbConn.MyDataReader.Item("NI_MIN"))
            fpLotKimyasal.Sheets(0).Cells(5, 2).Text = IIf(DbConn.MyDataReader.Item("NI_MAX") = "-", "", DbConn.MyDataReader.Item("NI_MAX"))
            fpLotKimyasal.Sheets(0).Cells(6, 1).Text = IIf(DbConn.MyDataReader.Item("CR_MIN") = "-", "", DbConn.MyDataReader.Item("CR_MIN"))
            fpLotKimyasal.Sheets(0).Cells(6, 2).Text = IIf(DbConn.MyDataReader.Item("CR_MAX") = "-", "", DbConn.MyDataReader.Item("CR_MAX"))
            fpLotKimyasal.Sheets(0).Cells(7, 1).Text = IIf(DbConn.MyDataReader.Item("MO_MIN") = "-", "", DbConn.MyDataReader.Item("MO_MIN"))
            fpLotKimyasal.Sheets(0).Cells(7, 2).Text = IIf(DbConn.MyDataReader.Item("MO_MAX") = "-", "", DbConn.MyDataReader.Item("MO_MAX"))
            fpLotKimyasal.Sheets(0).Cells(8, 1).Text = IIf(DbConn.MyDataReader.Item("V_MIN") = "-", "", DbConn.MyDataReader.Item("V_MIN"))
            fpLotKimyasal.Sheets(0).Cells(8, 2).Text = IIf(DbConn.MyDataReader.Item("V_MAX") = "-", "", DbConn.MyDataReader.Item("V_MAX"))
            fpLotKimyasal.Sheets(0).Cells(9, 1).Text = IIf(DbConn.MyDataReader.Item("CU_MIN") = "-", "", DbConn.MyDataReader.Item("CU_MIN"))
            fpLotKimyasal.Sheets(0).Cells(9, 2).Text = IIf(DbConn.MyDataReader.Item("CU_MAX") = "-", "", DbConn.MyDataReader.Item("CU_MAX"))
            fpLotKimyasal.Sheets(0).Cells(10, 1).Text = IIf(DbConn.MyDataReader.Item("W_MIN") = "-", "", DbConn.MyDataReader.Item("W_MIN"))
            fpLotKimyasal.Sheets(0).Cells(10, 2).Text = IIf(DbConn.MyDataReader.Item("W_MAX") = "-", "", DbConn.MyDataReader.Item("W_MAX"))
            fpLotKimyasal.Sheets(0).Cells(11, 1).Text = IIf(DbConn.MyDataReader.Item("TI_MIN") = "-", "", DbConn.MyDataReader.Item("TI_MIN"))
            fpLotKimyasal.Sheets(0).Cells(11, 2).Text = IIf(DbConn.MyDataReader.Item("TI_MAX") = "-", "", DbConn.MyDataReader.Item("TI_MAX"))
            fpLotKimyasal.Sheets(0).Cells(12, 1).Text = IIf(DbConn.MyDataReader.Item("SN_MIN") = "-", "", DbConn.MyDataReader.Item("SN_MIN"))
            fpLotKimyasal.Sheets(0).Cells(12, 2).Text = IIf(DbConn.MyDataReader.Item("SN_MAX") = "-", "", DbConn.MyDataReader.Item("SN_MAX"))
            fpLotKimyasal.Sheets(0).Cells(13, 1).Text = IIf(DbConn.MyDataReader.Item("CO_MIN") = "-", "", DbConn.MyDataReader.Item("CO_MIN"))
            fpLotKimyasal.Sheets(0).Cells(13, 2).Text = IIf(DbConn.MyDataReader.Item("CO_MAX") = "-", "", DbConn.MyDataReader.Item("CO_MAX"))
            fpLotKimyasal.Sheets(0).Cells(14, 1).Text = IIf(DbConn.MyDataReader.Item("AL_MIN") = "-", "", DbConn.MyDataReader.Item("AL_MIN"))
            fpLotKimyasal.Sheets(0).Cells(14, 2).Text = IIf(DbConn.MyDataReader.Item("AL_MAX") = "-", "", DbConn.MyDataReader.Item("AL_MAX"))
            fpLotKimyasal.Sheets(0).Cells(15, 1).Text = IIf(DbConn.MyDataReader.Item("ALSOL_MIN") = "-", "", DbConn.MyDataReader.Item("ALSOL_MIN"))
            fpLotKimyasal.Sheets(0).Cells(15, 2).Text = IIf(DbConn.MyDataReader.Item("ALSOL_MAX") = "-", "", DbConn.MyDataReader.Item("ALSOL_MAX"))
            fpLotKimyasal.Sheets(0).Cells(16, 1).Text = IIf(DbConn.MyDataReader.Item("ALOXY_MIN") = "-", "", DbConn.MyDataReader.Item("ALOXY_MIN"))
            fpLotKimyasal.Sheets(0).Cells(16, 2).Text = IIf(DbConn.MyDataReader.Item("ALOXY_MAX") = "-", "", DbConn.MyDataReader.Item("ALOXY_MAX"))
            fpLotKimyasal.Sheets(0).Cells(17, 1).Text = IIf(DbConn.MyDataReader.Item("PB_MIN") = "-", "", DbConn.MyDataReader.Item("PB_MIN"))
            fpLotKimyasal.Sheets(0).Cells(17, 2).Text = IIf(DbConn.MyDataReader.Item("PB_MAX") = "-", "", DbConn.MyDataReader.Item("PB_MAX"))
            fpLotKimyasal.Sheets(0).Cells(18, 1).Text = IIf(DbConn.MyDataReader.Item("B_MIN") = "-", "", DbConn.MyDataReader.Item("B_MIN"))
            fpLotKimyasal.Sheets(0).Cells(18, 2).Text = IIf(DbConn.MyDataReader.Item("B_MAX") = "-", "", DbConn.MyDataReader.Item("B_MAX"))
            fpLotKimyasal.Sheets(0).Cells(19, 1).Text = IIf(DbConn.MyDataReader.Item("SB_MIN") = "-", "", DbConn.MyDataReader.Item("SB_MIN"))
            fpLotKimyasal.Sheets(0).Cells(19, 2).Text = IIf(DbConn.MyDataReader.Item("SB_MAX") = "-", "", DbConn.MyDataReader.Item("SB_MAX"))
            fpLotKimyasal.Sheets(0).Cells(20, 1).Text = IIf(DbConn.MyDataReader.Item("NB_MIN") = "-", "", DbConn.MyDataReader.Item("NB_MIN"))
            fpLotKimyasal.Sheets(0).Cells(20, 2).Text = IIf(DbConn.MyDataReader.Item("NB_MAX") = "-", "", DbConn.MyDataReader.Item("NB_MAX"))
            fpLotKimyasal.Sheets(0).Cells(21, 1).Text = IIf(DbConn.MyDataReader.Item("CA_MIN") = "-", "", DbConn.MyDataReader.Item("CA_MIN"))
            fpLotKimyasal.Sheets(0).Cells(21, 2).Text = IIf(DbConn.MyDataReader.Item("CA_MAX") = "-", "", DbConn.MyDataReader.Item("CA_MAX"))
            fpLotKimyasal.Sheets(0).Cells(22, 1).Text = IIf(DbConn.MyDataReader.Item("ZN_MIN") = "-", "", DbConn.MyDataReader.Item("ZN_MIN"))
            fpLotKimyasal.Sheets(0).Cells(22, 2).Text = IIf(DbConn.MyDataReader.Item("ZN_MAX") = "-", "", DbConn.MyDataReader.Item("ZN_MAX"))
            fpLotKimyasal.Sheets(0).Cells(23, 1).Text = IIf(DbConn.MyDataReader.Item("N_MIN") = "-", "", DbConn.MyDataReader.Item("N_MIN"))
            fpLotKimyasal.Sheets(0).Cells(23, 2).Text = IIf(DbConn.MyDataReader.Item("N_MAX") = "-", "", DbConn.MyDataReader.Item("N_MAX"))
            fpLotKimyasal.Sheets(0).Cells(24, 1).Text = IIf(DbConn.MyDataReader.Item("FE_MIN") = "-", "", DbConn.MyDataReader.Item("FE_MIN"))
            fpLotKimyasal.Sheets(0).Cells(24, 2).Text = IIf(DbConn.MyDataReader.Item("FE_MAX") = "-", "", DbConn.MyDataReader.Item("FE_MAX"))
            fpLotKimyasal.Sheets(0).Cells(25, 1).Text = IIf(DbConn.MyDataReader.Item("F_MIN") = "-", "", DbConn.MyDataReader.Item("F_MIN"))
            fpLotKimyasal.Sheets(0).Cells(25, 2).Text = IIf(DbConn.MyDataReader.Item("F_MAX") = "-", "", DbConn.MyDataReader.Item("F_MAX"))
            fpLotKimyasal.Sheets(0).Cells(26, 1).Text = IIf(DbConn.MyDataReader.Item("CEQ_MIN") = "-", "", DbConn.MyDataReader.Item("CEQ_MIN"))
            fpLotKimyasal.Sheets(0).Cells(26, 2).Text = IIf(DbConn.MyDataReader.Item("CEQ_MAX") = "-", "", DbConn.MyDataReader.Item("CEQ_MAX"))
            'fpLotKimyasal.Sheets(0).Cells(27, 0).Text = IIf(DbConn.MyDataReader.Item("Y1") = "-", "", DbConn.MyDataReader.Item("Y1"))
            'fpLotKimyasal.Sheets(0).Cells(27, 1).Text = IIf(DbConn.MyDataReader.Item("Y1MIN") = "-", "", DbConn.MyDataReader.Item("Y1MIN"))
            'fpLotKimyasal.Sheets(0).Cells(27, 2).Text = IIf(DbConn.MyDataReader.Item("Y1MAX") = "-", "", DbConn.MyDataReader.Item("Y1MAX"))
            'fpLotKimyasal.Sheets(0).Cells(28, 0).Text = IIf(DbConn.MyDataReader.Item("Y2") = "-", "", DbConn.MyDataReader.Item("Y2"))
            'fpLotKimyasal.Sheets(0).Cells(28, 1).Text = IIf(DbConn.MyDataReader.Item("Y2MIN") = "-", "", DbConn.MyDataReader.Item("Y2MIN"))
            'fpLotKimyasal.Sheets(0).Cells(28, 2).Text = IIf(DbConn.MyDataReader.Item("Y2MAX") = "-", "", DbConn.MyDataReader.Item("Y2MAX"))
            fpLotKimyasal.Sheets(0).Cells(27, 1).Text = IIf(DbConn.MyDataReader.Item("S_PMIN") = "-", "", DbConn.MyDataReader.Item("S_PMIN"))
            fpLotKimyasal.Sheets(0).Cells(27, 2).Text = IIf(DbConn.MyDataReader.Item("S_PMAX") = "-", "", DbConn.MyDataReader.Item("S_PMAX"))

            If txtRevizyonAnaliz.Text > 0 Then
                If rev1C_MIN <> DbConn.MyDataReader.Item("C_MIN") Then fpLotKimyasal.Sheets(0).Cells(0, 1).BackColor = Drawing.Color.Red
                If rev1SI_MIN <> DbConn.MyDataReader.Item("SI_MIN") Then fpLotKimyasal.Sheets(0).Cells(1, 1).BackColor = Drawing.Color.Red
                If rev1S_MIN <> DbConn.MyDataReader.Item("S_MIN") Then fpLotKimyasal.Sheets(0).Cells(2, 1).BackColor = Drawing.Color.Red
                If rev1P_MIN <> DbConn.MyDataReader.Item("P_MIN") Then fpLotKimyasal.Sheets(0).Cells(3, 1).BackColor = Drawing.Color.Red
                If rev1MN_MIN <> DbConn.MyDataReader.Item("MN_MIN") Then fpLotKimyasal.Sheets(0).Cells(4, 1).BackColor = Drawing.Color.Red
                If rev1NI_MIN <> DbConn.MyDataReader.Item("NI_MIN") Then fpLotKimyasal.Sheets(0).Cells(5, 1).BackColor = Drawing.Color.Red
                If rev1CR_MIN <> DbConn.MyDataReader.Item("CR_MIN") Then fpLotKimyasal.Sheets(0).Cells(6, 1).BackColor = Drawing.Color.Red
                If rev1MO_MIN <> DbConn.MyDataReader.Item("MO_MIN") Then fpLotKimyasal.Sheets(0).Cells(7, 1).BackColor = Drawing.Color.Red
                If rev1V_MIN <> DbConn.MyDataReader.Item("V_MIN") Then fpLotKimyasal.Sheets(0).Cells(8, 1).BackColor = Drawing.Color.Red
                If rev1CU_MIN <> DbConn.MyDataReader.Item("CU_MIN") Then fpLotKimyasal.Sheets(0).Cells(9, 1).BackColor = Drawing.Color.Red
                If rev1W_MIN <> DbConn.MyDataReader.Item("W_MIN") Then fpLotKimyasal.Sheets(0).Cells(10, 1).BackColor = Drawing.Color.Red
                If rev1TI_MIN <> DbConn.MyDataReader.Item("TI_MIN") Then fpLotKimyasal.Sheets(0).Cells(11, 1).BackColor = Drawing.Color.Red
                If rev1SN_MIN <> DbConn.MyDataReader.Item("SN_MIN") Then fpLotKimyasal.Sheets(0).Cells(12, 1).BackColor = Drawing.Color.Red
                If rev1CO_MIN <> DbConn.MyDataReader.Item("CO_MIN") Then fpLotKimyasal.Sheets(0).Cells(13, 1).BackColor = Drawing.Color.Red
                If rev1AL_MIN <> DbConn.MyDataReader.Item("AL_MIN") Then fpLotKimyasal.Sheets(0).Cells(14, 1).BackColor = Drawing.Color.Red
                If rev1ALSOL_MIN <> DbConn.MyDataReader.Item("ALSOL_MIN") Then fpLotKimyasal.Sheets(0).Cells(15, 1).BackColor = Drawing.Color.Red
                If rev1ALOXY_MIN <> DbConn.MyDataReader.Item("ALOXY_MIN") Then fpLotKimyasal.Sheets(0).Cells(16, 1).BackColor = Drawing.Color.Red
                If rev1PB_MIN <> DbConn.MyDataReader.Item("PB_MIN") Then fpLotKimyasal.Sheets(0).Cells(17, 1).BackColor = Drawing.Color.Red
                If rev1B_MIN <> DbConn.MyDataReader.Item("B_MIN") Then fpLotKimyasal.Sheets(0).Cells(18, 1).BackColor = Drawing.Color.Red
                If rev1SB_MIN <> DbConn.MyDataReader.Item("SB_MIN") Then fpLotKimyasal.Sheets(0).Cells(19, 1).BackColor = Drawing.Color.Red
                If rev1NB_MIN <> DbConn.MyDataReader.Item("NB_MIN") Then fpLotKimyasal.Sheets(0).Cells(20, 1).BackColor = Drawing.Color.Red
                If rev1CA_MIN <> DbConn.MyDataReader.Item("CA_MIN") Then fpLotKimyasal.Sheets(0).Cells(21, 1).BackColor = Drawing.Color.Red
                If rev1ZN_MIN <> DbConn.MyDataReader.Item("ZN_MIN") Then fpLotKimyasal.Sheets(0).Cells(22, 1).BackColor = Drawing.Color.Red
                If rev1N_MIN <> DbConn.MyDataReader.Item("N_MIN") Then fpLotKimyasal.Sheets(0).Cells(23, 1).BackColor = Drawing.Color.Red
                If rev1FE_MIN <> DbConn.MyDataReader.Item("FE_MIN") Then fpLotKimyasal.Sheets(0).Cells(24, 1).BackColor = Drawing.Color.Red
                If rev1F_MIN <> DbConn.MyDataReader.Item("F_MIN") Then fpLotKimyasal.Sheets(0).Cells(25, 1).BackColor = Drawing.Color.Red
                If rev1CEQ_MIN <> DbConn.MyDataReader.Item("CEQ_MIN") Then fpLotKimyasal.Sheets(0).Cells(26, 1).BackColor = Drawing.Color.Red
                If REV1S_PMIN <> DbConn.MyDataReader.Item("S_PMIN") Then fpLotKimyasal.Sheets(0).Cells(27, 1).BackColor = Drawing.Color.Red



                'If revY1 <> DbConn.MyDataReader.Item("Y1") Then fpLotKimyasal.Sheets(0).Cells(27, 0).BackColor = Drawing.Color.Red
                'If revY1MIN <> DbConn.MyDataReader.Item("Y1MIN") Then fpLotKimyasal.Sheets(0).Cells(27, 1).BackColor = Drawing.Color.Red
                'If revY1MAX <> DbConn.MyDataReader.Item("Y1MAX") Then fpLotKimyasal.Sheets(0).Cells(27, 2).BackColor = Drawing.Color.Red
                'If revY2 <> DbConn.MyDataReader.Item("Y2") Then fpLotKimyasal.Sheets(0).Cells(28, 0).BackColor = Drawing.Color.Red
                'If revY2MIN <> DbConn.MyDataReader.Item("Y2MIN") Then fpLotKimyasal.Sheets(0).Cells(28, 1).BackColor = Drawing.Color.Red
                'If revY2MAX <> DbConn.MyDataReader.Item("Y2MAX") Then fpLotKimyasal.Sheets(0).Cells(28, 2).BackColor = Drawing.Color.Red

                If rev1C_MAX <> DbConn.MyDataReader.Item("C_MAX") Then fpLotKimyasal.Sheets(0).Cells(0, 2).BackColor = Drawing.Color.Red
                If rev1SI_MAX <> DbConn.MyDataReader.Item("SI_MAX") Then fpLotKimyasal.Sheets(0).Cells(1, 2).BackColor = Drawing.Color.Red
                If rev1S_MAX <> DbConn.MyDataReader.Item("S_MAX") Then fpLotKimyasal.Sheets(0).Cells(2, 2).BackColor = Drawing.Color.Red
                If rev1P_MAX <> DbConn.MyDataReader.Item("P_MAX") Then fpLotKimyasal.Sheets(0).Cells(3, 2).BackColor = Drawing.Color.Red
                If rev1MN_MAX <> DbConn.MyDataReader.Item("MN_MAX") Then fpLotKimyasal.Sheets(0).Cells(4, 2).BackColor = Drawing.Color.Red
                If rev1NI_MAX <> DbConn.MyDataReader.Item("NI_MAX") Then fpLotKimyasal.Sheets(0).Cells(5, 2).BackColor = Drawing.Color.Red
                If rev1CR_MAX <> DbConn.MyDataReader.Item("CR_MAX") Then fpLotKimyasal.Sheets(0).Cells(6, 2).BackColor = Drawing.Color.Red
                If rev1MO_MAX <> DbConn.MyDataReader.Item("MO_MAX") Then fpLotKimyasal.Sheets(0).Cells(7, 2).BackColor = Drawing.Color.Red
                If rev1V_MAX <> DbConn.MyDataReader.Item("V_MAX") Then fpLotKimyasal.Sheets(0).Cells(8, 2).BackColor = Drawing.Color.Red
                If rev1CU_MAX <> DbConn.MyDataReader.Item("CU_MAX") Then fpLotKimyasal.Sheets(0).Cells(9, 2).BackColor = Drawing.Color.Red
                If rev1W_MAX <> DbConn.MyDataReader.Item("W_MAX") Then fpLotKimyasal.Sheets(0).Cells(10, 2).BackColor = Drawing.Color.Red
                If rev1TI_MAX <> DbConn.MyDataReader.Item("TI_MAX") Then fpLotKimyasal.Sheets(0).Cells(11, 2).BackColor = Drawing.Color.Red
                If rev1SN_MAX <> DbConn.MyDataReader.Item("SN_MAX") Then fpLotKimyasal.Sheets(0).Cells(12, 2).BackColor = Drawing.Color.Red
                If rev1CO_MAX <> DbConn.MyDataReader.Item("CO_MAX") Then fpLotKimyasal.Sheets(0).Cells(13, 2).BackColor = Drawing.Color.Red
                If rev1AL_MAX <> DbConn.MyDataReader.Item("AL_MAX") Then fpLotKimyasal.Sheets(0).Cells(14, 2).BackColor = Drawing.Color.Red
                If rev1ALSOL_MAX <> DbConn.MyDataReader.Item("ALSOL_MAX") Then fpLotKimyasal.Sheets(0).Cells(15, 2).BackColor = Drawing.Color.Red
                If rev1ALOXY_MAX <> DbConn.MyDataReader.Item("ALOXY_MAX") Then fpLotKimyasal.Sheets(0).Cells(16, 2).BackColor = Drawing.Color.Red
                If rev1PB_MAX <> DbConn.MyDataReader.Item("PB_MAX") Then fpLotKimyasal.Sheets(0).Cells(17, 2).BackColor = Drawing.Color.Red
                If rev1B_MAX <> DbConn.MyDataReader.Item("B_MAX") Then fpLotKimyasal.Sheets(0).Cells(18, 2).BackColor = Drawing.Color.Red
                If rev1SB_MAX <> DbConn.MyDataReader.Item("SB_MAX") Then fpLotKimyasal.Sheets(0).Cells(19, 2).BackColor = Drawing.Color.Red
                If rev1NB_MAX <> DbConn.MyDataReader.Item("NB_MAX") Then fpLotKimyasal.Sheets(0).Cells(20, 2).BackColor = Drawing.Color.Red
                If rev1CA_MAX <> DbConn.MyDataReader.Item("CA_MAX") Then fpLotKimyasal.Sheets(0).Cells(21, 2).BackColor = Drawing.Color.Red
                If rev1ZN_MAX <> DbConn.MyDataReader.Item("ZN_MAX") Then fpLotKimyasal.Sheets(0).Cells(22, 2).BackColor = Drawing.Color.Red
                If rev1N_MAX <> DbConn.MyDataReader.Item("N_MAX") Then fpLotKimyasal.Sheets(0).Cells(23, 2).BackColor = Drawing.Color.Red
                If rev1FE_MAX <> DbConn.MyDataReader.Item("FE_MAX") Then fpLotKimyasal.Sheets(0).Cells(24, 2).BackColor = Drawing.Color.Red
                If rev1F_MAX <> DbConn.MyDataReader.Item("F_MAX") Then fpLotKimyasal.Sheets(0).Cells(25, 2).BackColor = Drawing.Color.Red
                If rev1CEQ_MAX <> DbConn.MyDataReader.Item("CEQ_MAX") Then fpLotKimyasal.Sheets(0).Cells(26, 2).BackColor = Drawing.Color.Red

                If REV1S_PMAX <> DbConn.MyDataReader.Item("S_PMAX") Then fpLotKimyasal.Sheets(0).Cells(27, 2).BackColor = Drawing.Color.Red




            End If
        End While
        DbConn.Kapat()
    End Sub

    Private Sub analileriGetir(ByVal sIP_NO As Object, ByVal rEVIZ_NO As Object, ByVal param1 As Object)

        lotlariListele()

        Dim I
        Dim SQL As String

        SQL = " SELECT * FROM MRKSIP_KUTUK_ANALIZ" _
              & " WHERE SIP_NO='" & sIP_NO & "'" _
              & " AND REVIZ_NO=" & rEVIZ_NO _
              & " AND LOT_NO='" & param1 & "'"


        Dim DbConn As New ConnectGiris
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            GrdAnaliz.Sheets(0).ColumnCount = GrdAnaliz.Sheets(0).ColumnCount + 1
            GrdAnaliz.Sheets(0).ColumnHeader.Cells(0, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = "Lot:" & param1
            GrdAnaliz.Sheets(0).Cells(0, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(3) & " × " & DbConn.MyDataReader.Item(4)
            GrdAnaliz.Sheets(0).Cells(1, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(5) & " × " & DbConn.MyDataReader.Item(6)
            GrdAnaliz.Sheets(0).Cells(2, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(7) & " × " & DbConn.MyDataReader.Item(8)
            GrdAnaliz.Sheets(0).Cells(3, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(9) & " × " & DbConn.MyDataReader.Item(10)
            GrdAnaliz.Sheets(0).Cells(4, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(11) & " × " & DbConn.MyDataReader.Item(12)
            GrdAnaliz.Sheets(0).Cells(5, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(13) & " × " & DbConn.MyDataReader.Item(14)
            GrdAnaliz.Sheets(0).Cells(6, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(15) & " × " & DbConn.MyDataReader.Item(16)
            GrdAnaliz.Sheets(0).Cells(7, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(17) & " × " & DbConn.MyDataReader.Item(18)
            GrdAnaliz.Sheets(0).Cells(8, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(19) & " × " & DbConn.MyDataReader.Item(20)
            GrdAnaliz.Sheets(0).Cells(9, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(21) & " × " & DbConn.MyDataReader.Item(22)
            GrdAnaliz.Sheets(0).Cells(10, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(23) & " × " & DbConn.MyDataReader.Item(24)
            GrdAnaliz.Sheets(0).Cells(11, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(25) & " × " & DbConn.MyDataReader.Item(26)
            GrdAnaliz.Sheets(0).Cells(12, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(27) & " × " & DbConn.MyDataReader.Item(28)
            GrdAnaliz.Sheets(0).Cells(13, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(29) & " × " & DbConn.MyDataReader.Item(30)
            GrdAnaliz.Sheets(0).Cells(14, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(31) & " × " & DbConn.MyDataReader.Item(32)
            GrdAnaliz.Sheets(0).Cells(15, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(33) & " × " & DbConn.MyDataReader.Item(34)
            GrdAnaliz.Sheets(0).Cells(16, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(35) & " × " & DbConn.MyDataReader.Item(36)
            GrdAnaliz.Sheets(0).Cells(17, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(37) & " × " & DbConn.MyDataReader.Item(38)
            GrdAnaliz.Sheets(0).Cells(18, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(39) & " × " & DbConn.MyDataReader.Item(40)
            GrdAnaliz.Sheets(0).Cells(19, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(41) & " × " & DbConn.MyDataReader.Item(42)
            GrdAnaliz.Sheets(0).Cells(20, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(43) & " × " & DbConn.MyDataReader.Item(44)
            GrdAnaliz.Sheets(0).Cells(21, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(45) & " × " & DbConn.MyDataReader.Item(46)
            GrdAnaliz.Sheets(0).Cells(22, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(47) & " × " & DbConn.MyDataReader.Item(48)
            GrdAnaliz.Sheets(0).Cells(23, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(49) & " × " & DbConn.MyDataReader.Item(50)
            GrdAnaliz.Sheets(0).Cells(24, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(51) & " × " & DbConn.MyDataReader.Item(52)
            GrdAnaliz.Sheets(0).Cells(25, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(53) & " × " & DbConn.MyDataReader.Item(54)
            GrdAnaliz.Sheets(0).Cells(26, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(55) & " × " & DbConn.MyDataReader.Item(56)
            GrdAnaliz.Sheets(0).Cells(27, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(63) & " × " & DbConn.MyDataReader.Item(64)
            'GrdAnaliz.Sheets(0).Cells(28, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(59) & " × " & DbConn.MyDataReader.Item(60)
            '  GrdAnaliz.Sheets(0).Cells(29, GrdAnaliz.Sheets(0).ColumnCount - 1).Text = DbConn.MyDataReader.Item(61) & " × " & DbConn.MyDataReader.Item(62)

        End While
        DbConn.Kapat()
    End Sub

    Private Sub analileriGetir_kalite_set(ByVal kalite As Object)
        Dim I = 0
        Dim SQL As String
        SQL = " SELECT * FROM MRKSIP_KUTUK_ANALIZ_SET" _
              & " WHERE KALITE='" & kalite & "'"
        Dim DbConn As New ConnectGiris
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read

            fpLotKimyasal.Sheets(0).Cells(I, 1).Text = DbConn.MyDataReader.Item(3)
            fpLotKimyasal.Sheets(0).Cells(I, 2).Text = DbConn.MyDataReader.Item(4)
            fpLotKimyasal.Sheets(0).Cells(I, 1).Text = DbConn.MyDataReader.Item(3)
            fpLotKimyasal.Sheets(0).Cells(I, 2).Text = DbConn.MyDataReader.Item(4)

            I += 1

        End While
        DbConn.Kapat()
    End Sub

    Private Sub SatirKapat()
        Dim bak, j, i
        Dim r As FarPoint.Web.Spread.Row
basa:

        For i = 1 To GrdAnaliz.Sheets(0).RowCount - 1 'satir

            For j = 1 To GrdAnaliz.Sheets(0).Columns.Count - 1 'sutun
                bak = Left(GrdAnaliz.Sheets(0).Cells(i, j).Text, 1)
                If bak <> "-" Then GoTo cık
            Next j
cık:
            If bak = "-" Then
                r = GrdAnaliz.ActiveSheetView.Rows(i)
                r.Remove()
                GoTo basa
            End If

        Next i
    End Sub
    Sub analizGetirOnayEkrani(ByVal gelenSipNo As String, ByVal gelenRevizNo As String)

        Dim rev1C_MIN, rev1C_MAX, rev1SI_MIN, rev1SI_MAX, rev1S_MIN, rev1S_MAX, rev1P_MIN, rev1P_MAX, rev1MN_MIN, rev1MN_MAX, rev1NI_MIN, rev1NI_MAX, rev1CR_MIN, rev1CR_MAX, rev1MO_MIN, rev1MO_MAX, rev1V_MIN, rev1V_MAX, rev1CU_MIN, rev1CU_MAX, rev1W_MIN, rev1W_MAX, rev1TI_MIN, rev1TI_MAX, rev1SN_MIN, rev1SN_MAX, rev1CO_MIN, rev1CO_MAX, rev1AL_MIN, rev1AL_MAX, rev1ALSOL_MIN, rev1ALSOL_MAX, rev1ALOXY_MIN, rev1ALOXY_MAX, rev1PB_MIN, rev1PB_MAX, rev1B_MIN, rev1B_MAX, rev1SB_MIN, rev1SB_MAX, rev1NB_MIN, rev1NB_MAX, rev1CA_MIN, rev1CA_MAX, rev1ZN_MIN, rev1ZN_MAX, rev1N_MIN, rev1N_MAX, rev1FE_MIN, rev1FE_MAX, rev1F_MIN, rev1F_MAX, rev1CEQ_MIN, rev1CEQ_MAX, revY1, revY1MIN, revY1MAX, revY2, revY2MIN, revY2MAX
        Dim SQL As String
        SQL = " SELECT * FROM MRKSIP_KUTUK_ANALIZ" _
              & " WHERE SIP_NO='" & gelenSipNo & "'" _
              & " AND REVIZ_NO=" & gelenRevizNo - 1

        Dim DbConn As New ConnectGiris
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            rev1C_MIN = DbConn.MyDataReader.Item("C_MIN")
            rev1C_MAX = DbConn.MyDataReader.Item("C_MAX")
            rev1SI_MIN = DbConn.MyDataReader.Item("SI_MIN")
            rev1SI_MAX = DbConn.MyDataReader.Item("SI_MAX")
            rev1S_MIN = DbConn.MyDataReader.Item("S_MIN")
            rev1S_MAX = DbConn.MyDataReader.Item("S_MAX")
            rev1P_MIN = DbConn.MyDataReader.Item("P_MIN")
            rev1P_MAX = DbConn.MyDataReader.Item("P_MAX")
            rev1MN_MIN = DbConn.MyDataReader.Item("MN_MIN")
            rev1MN_MAX = DbConn.MyDataReader.Item("MN_MAX")
            rev1NI_MIN = DbConn.MyDataReader.Item("NI_MIN")
            rev1NI_MAX = DbConn.MyDataReader.Item("NI_MAX")
            rev1CR_MIN = DbConn.MyDataReader.Item("CR_MIN")
            rev1CR_MAX = DbConn.MyDataReader.Item("CR_MAX")
            rev1MO_MIN = DbConn.MyDataReader.Item("MO_MIN")
            rev1MO_MAX = DbConn.MyDataReader.Item("MO_MAX")
            rev1V_MIN = DbConn.MyDataReader.Item("V_MIN")
            rev1V_MAX = DbConn.MyDataReader.Item("V_MAX")
            rev1CU_MIN = DbConn.MyDataReader.Item("CU_MIN")
            rev1CU_MAX = DbConn.MyDataReader.Item("CU_MAX")
            rev1W_MIN = DbConn.MyDataReader.Item("W_MIN")
            rev1W_MAX = DbConn.MyDataReader.Item("W_MAX")
            rev1TI_MIN = DbConn.MyDataReader.Item("TI_MIN")
            rev1TI_MAX = DbConn.MyDataReader.Item("TI_MAX")
            rev1SN_MIN = DbConn.MyDataReader.Item("SN_MIN")
            rev1SN_MAX = DbConn.MyDataReader.Item("SN_MAX")
            rev1CO_MIN = DbConn.MyDataReader.Item("CO_MIN")
            rev1CO_MAX = DbConn.MyDataReader.Item("CO_MAX")
            rev1AL_MIN = DbConn.MyDataReader.Item("AL_MIN")
            rev1AL_MAX = DbConn.MyDataReader.Item("AL_MAX")
            rev1ALSOL_MIN = DbConn.MyDataReader.Item("ALSOL_MIN")
            rev1ALSOL_MAX = DbConn.MyDataReader.Item("ALSOL_MAX")
            rev1ALOXY_MIN = DbConn.MyDataReader.Item("ALOXY_MIN")
            rev1ALOXY_MAX = DbConn.MyDataReader.Item("ALOXY_MAX")
            rev1PB_MIN = DbConn.MyDataReader.Item("PB_MIN")
            rev1PB_MAX = DbConn.MyDataReader.Item("PB_MAX")
            rev1B_MIN = DbConn.MyDataReader.Item("B_MIN")
            rev1B_MAX = DbConn.MyDataReader.Item("B_MAX")
            rev1SB_MIN = DbConn.MyDataReader.Item("SB_MIN")
            rev1SB_MAX = DbConn.MyDataReader.Item("SB_MAX")
            rev1NB_MIN = DbConn.MyDataReader.Item("NB_MIN")
            rev1NB_MAX = DbConn.MyDataReader.Item("NB_MAX")
            rev1CA_MIN = DbConn.MyDataReader.Item("CA_MIN")
            rev1CA_MAX = DbConn.MyDataReader.Item("CA_MAX")
            rev1ZN_MIN = DbConn.MyDataReader.Item("ZN_MIN")
            rev1ZN_MAX = DbConn.MyDataReader.Item("ZN_MAX")
            rev1N_MIN = DbConn.MyDataReader.Item("N_MIN")
            rev1N_MAX = DbConn.MyDataReader.Item("N_MAX")
            rev1FE_MIN = DbConn.MyDataReader.Item("FE_MIN")
            rev1FE_MAX = DbConn.MyDataReader.Item("FE_MAX")
            rev1F_MIN = DbConn.MyDataReader.Item("F_MIN")
            rev1F_MAX = DbConn.MyDataReader.Item("F_MAX")
            rev1CEQ_MIN = DbConn.MyDataReader.Item("CEQ_MIN")
            rev1CEQ_MAX = DbConn.MyDataReader.Item("CEQ_MAX")
            revY1 = DbConn.MyDataReader.Item("Y1")
            revY1MIN = DbConn.MyDataReader.Item("Y1MIN")
            revY1MAX = DbConn.MyDataReader.Item("Y1MAX")
            revY2 = DbConn.MyDataReader.Item("Y2")
            revY2MIN = DbConn.MyDataReader.Item("Y2MIN")
            revY2MAX = DbConn.MyDataReader.Item("Y2MAX")
        End While

        Dim analizGrupla As String

        SQL = " SELECT * FROM MRKSIP_KUTUK_ANALIZ" _
              & " WHERE SIP_NO='" & gelenSipNo & "'" _
              & " AND REVIZ_NO=" & gelenRevizNo
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            ' For index As Integer = 0 To fpLotKimyasal.Sheets(0).RowCount - 1
            '    fpLotKimyasal.Sheets(0).Cells(index, 1).BackColor = Drawing.Color.White
            '    fpLotKimyasal.Sheets(0).Cells(index, 2).BackColor = Drawing.Color.White
            ' Next

            If analizGrupla = "" Then
                analizGrupla = "LOT NO:" & DbConn.MyDataReader.Item("LOT_NO") & " "
            Else
                analizGrupla = analizGrupla & " --- LOT NO:" & DbConn.MyDataReader.Item("LOT_NO") & " "
            End If
            If DbConn.MyDataReader.Item("C_MIN") <> "-" Or DbConn.MyDataReader.Item("C_MAX") <> "-" Then
                analizGrupla = analizGrupla & " C " & DbConn.MyDataReader.Item("C_MIN") & "/" & DbConn.MyDataReader.Item("C_MAX")
            End If
            If DbConn.MyDataReader.Item("SI_MIN") <> "-" Or DbConn.MyDataReader.Item("SI_MAX") <> "-" Then
                analizGrupla = analizGrupla & " SI " & DbConn.MyDataReader.Item("SI_MIN") & "/" & DbConn.MyDataReader.Item("SI_MAX")
            End If
            If DbConn.MyDataReader.Item("S_MIN") <> "-" Or DbConn.MyDataReader.Item("S_MAX") <> "-" Then
                analizGrupla = analizGrupla & " S " & DbConn.MyDataReader.Item("S_MIN") & "/" & DbConn.MyDataReader.Item("S_MAX")
            End If
            If DbConn.MyDataReader.Item("P_MIN") <> "-" Or DbConn.MyDataReader.Item("P_MAX") <> "-" Then
                analizGrupla = analizGrupla & " P " & DbConn.MyDataReader.Item("P_MIN") & "/" & DbConn.MyDataReader.Item("P_MAX")
            End If
            If DbConn.MyDataReader.Item("MN_MIN") <> "-" Or DbConn.MyDataReader.Item("MN_MAX") <> "-" Then
                analizGrupla = analizGrupla & " MN " & DbConn.MyDataReader.Item("MN_MIN") & "/" & DbConn.MyDataReader.Item("MN_MAX")
            End If
            If DbConn.MyDataReader.Item("NI_MIN") <> "-" Or DbConn.MyDataReader.Item("NI_MAX") <> "-" Then
                analizGrupla = analizGrupla & " NI " & DbConn.MyDataReader.Item("NI_MIN") & "/" & DbConn.MyDataReader.Item("NI_MAX")
            End If
            If DbConn.MyDataReader.Item("CR_MIN") <> "-" Or DbConn.MyDataReader.Item("CR_MAX") <> "-" Then
                analizGrupla = analizGrupla & " CR " & DbConn.MyDataReader.Item("CR_MIN") & "/" & DbConn.MyDataReader.Item("CR_MAX")
            End If
            If DbConn.MyDataReader.Item("MO_MIN") <> "-" Or DbConn.MyDataReader.Item("MO_MAX") <> "-" Then
                analizGrupla = analizGrupla & " MO " & DbConn.MyDataReader.Item("MO_MIN") & "/" & DbConn.MyDataReader.Item("MO_MAX")
            End If
            If DbConn.MyDataReader.Item("V_MIN") <> "-" Or DbConn.MyDataReader.Item("V_MAX") <> "-" Then
                analizGrupla = analizGrupla & " V " & DbConn.MyDataReader.Item("V_MIN") & "/" & DbConn.MyDataReader.Item("V_MAX")
            End If
            If DbConn.MyDataReader.Item("CU_MIN") <> "-" Or DbConn.MyDataReader.Item("CU_MAX") <> "-" Then
                analizGrupla = analizGrupla & " CU " & DbConn.MyDataReader.Item("CU_MIN") & "/" & DbConn.MyDataReader.Item("CU_MAX")
            End If
            If DbConn.MyDataReader.Item("W_MIN") <> "-" Or DbConn.MyDataReader.Item("W_MAX") <> "-" Then
                analizGrupla = analizGrupla & " W " & DbConn.MyDataReader.Item("W_MIN") & "/" & DbConn.MyDataReader.Item("W_MAX")
            End If
            If DbConn.MyDataReader.Item("TI_MIN") <> "-" Or DbConn.MyDataReader.Item("TI_MAX") <> "-" Then
                analizGrupla = analizGrupla & " TI " & DbConn.MyDataReader.Item("TI_MIN") & "/" & DbConn.MyDataReader.Item("TI_MAX")
            End If
            If DbConn.MyDataReader.Item("SN_MIN") <> "-" Or DbConn.MyDataReader.Item("SN_MAX") <> "-" Then
                analizGrupla = analizGrupla & " SN " & DbConn.MyDataReader.Item("SN_MIN") & "/" & DbConn.MyDataReader.Item("SN_MAX")
            End If
            If DbConn.MyDataReader.Item("CO_MIN") <> "-" Or DbConn.MyDataReader.Item("CO_MAX") <> "-" Then
                analizGrupla = analizGrupla & " CO " & DbConn.MyDataReader.Item("CO_MIN") & "/" & DbConn.MyDataReader.Item("CO_MAX")
            End If
            If DbConn.MyDataReader.Item("AL_MIN") <> "-" Or DbConn.MyDataReader.Item("AL_MAX") <> "-" Then
                analizGrupla = analizGrupla & " AL " & DbConn.MyDataReader.Item("AL_MIN") & "/" & DbConn.MyDataReader.Item("AL_MAX")
            End If
            If DbConn.MyDataReader.Item("ALSOL_MIN") <> "-" Or DbConn.MyDataReader.Item("ALSOL_MAX") <> "-" Then
                analizGrupla = analizGrupla & " ALSOL " & DbConn.MyDataReader.Item("ALSOL_MIN") & "/" & DbConn.MyDataReader.Item("ALSOL_MAX")
            End If
            If DbConn.MyDataReader.Item("ALOXY_MIN") <> "-" Or DbConn.MyDataReader.Item("ALOXY_MAX") <> "-" Then
                analizGrupla = analizGrupla & " ALOXY " & DbConn.MyDataReader.Item("ALOXY_MIN") & "/" & DbConn.MyDataReader.Item("ALOXY_MAX")
            End If
            If DbConn.MyDataReader.Item("PB_MIN") <> "-" Or DbConn.MyDataReader.Item("PB_MAX") <> "-" Then
                analizGrupla = analizGrupla & " PB " & DbConn.MyDataReader.Item("PB_MIN") & "/" & DbConn.MyDataReader.Item("PB_MAX")
            End If
            If DbConn.MyDataReader.Item("B_MIN") <> "-" Or DbConn.MyDataReader.Item("B_MAX") <> "-" Then
                analizGrupla = analizGrupla & " B " & DbConn.MyDataReader.Item("B_MIN") & DbConn.MyDataReader.Item("B_MAX")
            End If
            If DbConn.MyDataReader.Item("SB_MIN") <> "-" Or DbConn.MyDataReader.Item("SB_MAX") <> "-" Then
                analizGrupla = analizGrupla & " SB " & DbConn.MyDataReader.Item("SB_MIN") & DbConn.MyDataReader.Item("SB_MAX")
            End If
            If DbConn.MyDataReader.Item("NB_MIN") <> "-" Or DbConn.MyDataReader.Item("NB_MAX") <> "-" Then
                analizGrupla = analizGrupla & " NB " & DbConn.MyDataReader.Item("NB_MIN") & DbConn.MyDataReader.Item("NB_MAX")
            End If
            If DbConn.MyDataReader.Item("CA_MIN") <> "-" Or DbConn.MyDataReader.Item("CA_MAX") <> "-" Then
                analizGrupla = analizGrupla & " CA " & DbConn.MyDataReader.Item("CA_MIN") & DbConn.MyDataReader.Item("CA_MAX")
            End If
            If DbConn.MyDataReader.Item("ZN_MIN") <> "-" Or DbConn.MyDataReader.Item("ZN_MAX") <> "-" Then
                analizGrupla = analizGrupla & " ZN " & DbConn.MyDataReader.Item("ZN_MIN") & DbConn.MyDataReader.Item("ZN_MAX")
            End If
            If DbConn.MyDataReader.Item("N_MIN") <> "-" Or DbConn.MyDataReader.Item("N_MAX") <> "-" Then
                analizGrupla = analizGrupla & " N " & DbConn.MyDataReader.Item("N_MIN") & DbConn.MyDataReader.Item("N_MAX")
            End If
            If DbConn.MyDataReader.Item("FE_MIN") <> "-" Or DbConn.MyDataReader.Item("FE_MAX") <> "-" Then
                analizGrupla = analizGrupla & " FE " & DbConn.MyDataReader.Item("FE_MIN") & DbConn.MyDataReader.Item("FE_MAX")
            End If
            If DbConn.MyDataReader.Item("F_MIN") <> "-" Or DbConn.MyDataReader.Item("F_MAX") <> "-" Then
                analizGrupla = analizGrupla & " F " & DbConn.MyDataReader.Item("F_MIN") & DbConn.MyDataReader.Item("F_MAX")
            End If
            If DbConn.MyDataReader.Item("CEQ_MIN") <> "-" Or DbConn.MyDataReader.Item("CEQ_MAX") <> "-" Then
                analizGrupla = analizGrupla & " CEQ " & DbConn.MyDataReader.Item("CEQ_MIN") & DbConn.MyDataReader.Item("CEQ_MAX")
            End If
            'If DbConn.MyDataReader.Item("Y1MIN") <> "-" Or DbConn.MyDataReader.Item("Y1MAX") <> "-" Then
            '    analizGrupla = analizGrupla & DbConn.MyDataReader.Item("Y1") & DbConn.MyDataReader.Item("Y1MIN") & DbConn.MyDataReader.Item("Y1MAX")
            'End If
            'If DbConn.MyDataReader.Item("Y2MIN") <> "-" Or DbConn.MyDataReader.Item("Y2MAX") <> "-" Then
            '    analizGrupla = analizGrupla & " " & DbConn.MyDataReader.Item("Y2") & " " & DbConn.MyDataReader.Item("Y2MIN") & DbConn.MyDataReader.Item("Y2MAX")
            'End If

            'If txtRevizyonAnaliz.Text > 0 Then
            '    If rev1C_MIN <> DbConn.MyDataReader.Item("C_MIN") Then fpLotKimyasal.Sheets(0).Cells(0, 1).BackColor = Drawing.Color.Red
            '    If rev1SI_MIN <> DbConn.MyDataReader.Item("SI_MIN") Then fpLotKimyasal.Sheets(0).Cells(1, 1).BackColor = Drawing.Color.Red
            '    If rev1S_MIN <> DbConn.MyDataReader.Item("S_MIN") Then fpLotKimyasal.Sheets(0).Cells(2, 1).BackColor = Drawing.Color.Red
            '    If rev1P_MIN <> DbConn.MyDataReader.Item("P_MIN") Then fpLotKimyasal.Sheets(0).Cells(3, 1).BackColor = Drawing.Color.Red
            '    If rev1MN_MIN <> DbConn.MyDataReader.Item("MN_MIN") Then fpLotKimyasal.Sheets(0).Cells(4, 1).BackColor = Drawing.Color.Red
            '    If rev1NI_MIN <> DbConn.MyDataReader.Item("NI_MIN") Then fpLotKimyasal.Sheets(0).Cells(5, 1).BackColor = Drawing.Color.Red
            '    If rev1CR_MIN <> DbConn.MyDataReader.Item("CR_MIN") Then fpLotKimyasal.Sheets(0).Cells(6, 1).BackColor = Drawing.Color.Red
            '    If rev1MO_MIN <> DbConn.MyDataReader.Item("MO_MIN") Then fpLotKimyasal.Sheets(0).Cells(7, 1).BackColor = Drawing.Color.Red
            '    If rev1V_MIN <> DbConn.MyDataReader.Item("V_MIN") Then fpLotKimyasal.Sheets(0).Cells(8, 1).BackColor = Drawing.Color.Red
            '    If rev1CU_MIN <> DbConn.MyDataReader.Item("CU_MIN") Then fpLotKimyasal.Sheets(0).Cells(9, 1).BackColor = Drawing.Color.Red
            '    If rev1W_MIN <> DbConn.MyDataReader.Item("W_MIN") Then fpLotKimyasal.Sheets(0).Cells(10, 1).BackColor = Drawing.Color.Red
            '    If rev1TI_MIN <> DbConn.MyDataReader.Item("TI_MIN") Then fpLotKimyasal.Sheets(0).Cells(11, 1).BackColor = Drawing.Color.Red
            '    If rev1SN_MIN <> DbConn.MyDataReader.Item("SN_MIN") Then fpLotKimyasal.Sheets(0).Cells(12, 1).BackColor = Drawing.Color.Red
            '    If rev1CO_MIN <> DbConn.MyDataReader.Item("CO_MIN") Then fpLotKimyasal.Sheets(0).Cells(13, 1).BackColor = Drawing.Color.Red
            '    If rev1AL_MIN <> DbConn.MyDataReader.Item("AL_MIN") Then fpLotKimyasal.Sheets(0).Cells(14, 1).BackColor = Drawing.Color.Red
            '    If rev1ALSOL_MIN <> DbConn.MyDataReader.Item("ALSOL_MIN") Then fpLotKimyasal.Sheets(0).Cells(15, 1).BackColor = Drawing.Color.Red
            '    If rev1ALOXY_MIN <> DbConn.MyDataReader.Item("ALOXY_MIN") Then fpLotKimyasal.Sheets(0).Cells(16, 1).BackColor = Drawing.Color.Red
            '    If rev1PB_MIN <> DbConn.MyDataReader.Item("PB_MIN") Then fpLotKimyasal.Sheets(0).Cells(17, 1).BackColor = Drawing.Color.Red
            '    If rev1B_MIN <> DbConn.MyDataReader.Item("B_MIN") Then fpLotKimyasal.Sheets(0).Cells(18, 1).BackColor = Drawing.Color.Red
            '    If rev1SB_MIN <> DbConn.MyDataReader.Item("SB_MIN") Then fpLotKimyasal.Sheets(0).Cells(19, 1).BackColor = Drawing.Color.Red
            '    If rev1NB_MIN <> DbConn.MyDataReader.Item("NB_MIN") Then fpLotKimyasal.Sheets(0).Cells(20, 1).BackColor = Drawing.Color.Red
            '    If rev1CA_MIN <> DbConn.MyDataReader.Item("CA_MIN") Then fpLotKimyasal.Sheets(0).Cells(21, 1).BackColor = Drawing.Color.Red
            '    If rev1ZN_MIN <> DbConn.MyDataReader.Item("ZN_MIN") Then fpLotKimyasal.Sheets(0).Cells(22, 1).BackColor = Drawing.Color.Red
            '    If rev1N_MIN <> DbConn.MyDataReader.Item("N_MIN") Then fpLotKimyasal.Sheets(0).Cells(23, 1).BackColor = Drawing.Color.Red
            '    If rev1FE_MIN <> DbConn.MyDataReader.Item("FE_MIN") Then fpLotKimyasal.Sheets(0).Cells(24, 1).BackColor = Drawing.Color.Red
            '    If rev1F_MIN <> DbConn.MyDataReader.Item("F_MIN") Then fpLotKimyasal.Sheets(0).Cells(25, 1).BackColor = Drawing.Color.Red
            '    If rev1CEQ_MIN <> DbConn.MyDataReader.Item("CEQ_MIN") Then fpLotKimyasal.Sheets(0).Cells(26, 1).BackColor = Drawing.Color.Red

            '    If revY1 <> DbConn.MyDataReader.Item("Y1") Then fpLotKimyasal.Sheets(0).Cells(27, 0).BackColor = Drawing.Color.Red
            '    If revY1MIN <> DbConn.MyDataReader.Item("Y1MIN") Then fpLotKimyasal.Sheets(0).Cells(27, 1).BackColor = Drawing.Color.Red
            '    If revY1MAX <> DbConn.MyDataReader.Item("Y1MAX") Then fpLotKimyasal.Sheets(0).Cells(27, 2).BackColor = Drawing.Color.Red
            '    If revY2 <> DbConn.MyDataReader.Item("Y2") Then fpLotKimyasal.Sheets(0).Cells(28, 0).BackColor = Drawing.Color.Red
            '    If revY2MIN <> DbConn.MyDataReader.Item("Y2MIN") Then fpLotKimyasal.Sheets(0).Cells(28, 1).BackColor = Drawing.Color.Red
            '    If revY2MAX <> DbConn.MyDataReader.Item("Y2MAX") Then fpLotKimyasal.Sheets(0).Cells(28, 2).BackColor = Drawing.Color.Red

            '    If rev1C_MAX <> DbConn.MyDataReader.Item("C_MAX") Then fpLotKimyasal.Sheets(0).Cells(0, 2).BackColor = Drawing.Color.Red
            '    If rev1SI_MAX <> DbConn.MyDataReader.Item("SI_MAX") Then fpLotKimyasal.Sheets(0).Cells(1, 2).BackColor = Drawing.Color.Red
            '    If rev1S_MAX <> DbConn.MyDataReader.Item("S_MAX") Then fpLotKimyasal.Sheets(0).Cells(2, 2).BackColor = Drawing.Color.Red
            '    If rev1P_MAX <> DbConn.MyDataReader.Item("P_MAX") Then fpLotKimyasal.Sheets(0).Cells(3, 2).BackColor = Drawing.Color.Red
            '    If rev1MN_MAX <> DbConn.MyDataReader.Item("MN_MAX") Then fpLotKimyasal.Sheets(0).Cells(4, 2).BackColor = Drawing.Color.Red
            '    If rev1NI_MAX <> DbConn.MyDataReader.Item("NI_MAX") Then fpLotKimyasal.Sheets(0).Cells(5, 2).BackColor = Drawing.Color.Red
            '    If rev1CR_MAX <> DbConn.MyDataReader.Item("CR_MAX") Then fpLotKimyasal.Sheets(0).Cells(6, 2).BackColor = Drawing.Color.Red
            '    If rev1MO_MAX <> DbConn.MyDataReader.Item("MO_MAX") Then fpLotKimyasal.Sheets(0).Cells(7, 2).BackColor = Drawing.Color.Red
            '    If rev1V_MAX <> DbConn.MyDataReader.Item("V_MAX") Then fpLotKimyasal.Sheets(0).Cells(8, 2).BackColor = Drawing.Color.Red
            '    If rev1CU_MAX <> DbConn.MyDataReader.Item("CU_MAX") Then fpLotKimyasal.Sheets(0).Cells(9, 2).BackColor = Drawing.Color.Red
            '    If rev1W_MAX <> DbConn.MyDataReader.Item("W_MAX") Then fpLotKimyasal.Sheets(0).Cells(10, 2).BackColor = Drawing.Color.Red
            '    If rev1TI_MAX <> DbConn.MyDataReader.Item("TI_MAX") Then fpLotKimyasal.Sheets(0).Cells(11, 2).BackColor = Drawing.Color.Red
            '    If rev1SN_MAX <> DbConn.MyDataReader.Item("SN_MAX") Then fpLotKimyasal.Sheets(0).Cells(12, 2).BackColor = Drawing.Color.Red
            '    If rev1CO_MAX <> DbConn.MyDataReader.Item("CO_MAX") Then fpLotKimyasal.Sheets(0).Cells(13, 2).BackColor = Drawing.Color.Red
            '    If rev1AL_MAX <> DbConn.MyDataReader.Item("AL_MAX") Then fpLotKimyasal.Sheets(0).Cells(14, 2).BackColor = Drawing.Color.Red
            '    If rev1ALSOL_MAX <> DbConn.MyDataReader.Item("ALSOL_MAX") Then fpLotKimyasal.Sheets(0).Cells(15, 2).BackColor = Drawing.Color.Red
            '    If rev1ALOXY_MAX <> DbConn.MyDataReader.Item("ALOXY_MAX") Then fpLotKimyasal.Sheets(0).Cells(16, 2).BackColor = Drawing.Color.Red
            '    If rev1PB_MAX <> DbConn.MyDataReader.Item("PB_MAX") Then fpLotKimyasal.Sheets(0).Cells(17, 2).BackColor = Drawing.Color.Red
            '    If rev1B_MAX <> DbConn.MyDataReader.Item("B_MAX") Then fpLotKimyasal.Sheets(0).Cells(18, 2).BackColor = Drawing.Color.Red
            '    If rev1SB_MAX <> DbConn.MyDataReader.Item("SB_MAX") Then fpLotKimyasal.Sheets(0).Cells(19, 2).BackColor = Drawing.Color.Red
            '    If rev1NB_MAX <> DbConn.MyDataReader.Item("NB_MAX") Then fpLotKimyasal.Sheets(0).Cells(20, 2).BackColor = Drawing.Color.Red
            '    If rev1CA_MAX <> DbConn.MyDataReader.Item("CA_MAX") Then fpLotKimyasal.Sheets(0).Cells(21, 2).BackColor = Drawing.Color.Red
            '    If rev1ZN_MAX <> DbConn.MyDataReader.Item("ZN_MAX") Then fpLotKimyasal.Sheets(0).Cells(22, 2).BackColor = Drawing.Color.Red
            '    If rev1N_MAX <> DbConn.MyDataReader.Item("N_MAX") Then fpLotKimyasal.Sheets(0).Cells(23, 2).BackColor = Drawing.Color.Red
            '    If rev1FE_MAX <> DbConn.MyDataReader.Item("FE_MAX") Then fpLotKimyasal.Sheets(0).Cells(24, 2).BackColor = Drawing.Color.Red
            '    If rev1F_MAX <> DbConn.MyDataReader.Item("F_MAX") Then fpLotKimyasal.Sheets(0).Cells(25, 2).BackColor = Drawing.Color.Red
            '    If rev1CEQ_MAX <> DbConn.MyDataReader.Item("CEQ_MAX") Then fpLotKimyasal.Sheets(0).Cells(26, 2).BackColor = Drawing.Color.Red

            'End If

        End While

        '        raporgrd.Sheets(0).AddRows(14, 1)
        'raporgrd.Sheets(0).Cells(14, 1).Text = analizGrupla
        DbConn.Kapat()

    End Sub
    Protected Sub fpLotListe_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles fpLotListe.ButtonCommand
        Dim sayi = 0
        Dim DbConn As New ConnectGiris
        Dim Sql As String
        Dim Kalite As String

        If e.CommandArgument.Y = 0 Then
            Dim lot = fpLotListe.Sheets(0).Cells(e.CommandArgument.X, 1).Text
            txtLotAnaliz.Text = lot


            Sql = " SELECT COUNT(SIP_NO) FROM MRKSIP_KUTUK_ANALIZ  " _
          & " WHERE SIP_NO='" & txtUretimSipNoAnaliz.Text & "'" _
          & " AND REVIZ_NO='" & txtRevizyonAnaliz.Text & "'" _
            & " AND LOT_NO='" & txtLotAnaliz.Text & "'"
            DbConn.Sayac(Sql)
            sayi = DbConn.GeriDonenRakam
            DbConn.Kapat()

            'spread üzerinden kalitebuluyoruz
            If sayi = 0 Then
                For index As Integer = 0 To fpEbatMiktar.Sheets(0).ColumnCount - 1
                    If lot = fpEbatMiktar.Sheets(0).Cells(index, 2).Text Then
                        Kalite = fpEbatMiktar.Sheets(0).Cells(index, 5).Text
                        GoTo çık
                    End If
                Next
            End If
çık:

            analizGetir(lot, sayi, Kalite)
        End If

    End Sub

    Private Sub analizAlanlariniTemizle()

        '  fpLotKimyasal.Sheets(0).Cells(27, 0).Text = ""
        '  fpLotKimyasal.Sheets(0).Cells(28, 0).Text = ""

        For index As Integer = 0 To fpLotKimyasal.Sheets(0).RowCount - 1
            fpLotKimyasal.Sheets(0).Cells(index, 1).Text = ""
            fpLotKimyasal.Sheets(0).Cells(index, 2).Text = ""
            fpLotKimyasal.Sheets(0).Cells(index, 1).BackColor = Drawing.Color.White
            fpLotKimyasal.Sheets(0).Cells(index, 2).BackColor = Drawing.Color.White
        Next

    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnalizGir.Click

        'Timer1.Enabled = False
        txtLotAnaliz.Text = ""
        For index As Integer = 0 To fpLotKimyasal.Sheets(0).RowCount - 1

            fpLotKimyasal.Sheets(0).Cells(index, 1).Text = ""
            fpLotKimyasal.Sheets(0).Cells(index, 2).Text = ""

            fpLotKimyasal.Sheets(0).Cells(index, 1).BackColor = Drawing.Color.White
            fpLotKimyasal.Sheets(0).Cells(index, 2).BackColor = Drawing.Color.White
        Next

        txtUretimSipNoAnaliz.Text = txtUretimSipNo.Text
        txtRevizyonAnaliz.Text = txtRevizyon.Text

        lotlariListele()
        tabAnaliz.ActiveTab = TabPanel5


    End Sub

    Protected Sub Button2_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        analizAlanlariniTemizle()
    End Sub


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        tabAnaliz.ActiveTab = TabPanel2
    End Sub
    Private Sub GrdAnaliz_Hazırla()

        GrdAnaliz.Sheets(0).ColumnCount = 1
        GrdAnaliz.Sheets(0).RowCount = 28
        GrdAnaliz.Sheets(0).Cells(0, 0).Text = "C"
        GrdAnaliz.Sheets(0).Cells(1, 0).Text = "Si"
        GrdAnaliz.Sheets(0).Cells(2, 0).Text = "S"
        GrdAnaliz.Sheets(0).Cells(3, 0).Text = "P"
        GrdAnaliz.Sheets(0).Cells(4, 0).Text = "Mn"
        GrdAnaliz.Sheets(0).Cells(5, 0).Text = "Ni"
        GrdAnaliz.Sheets(0).Cells(6, 0).Text = "Cr"
        GrdAnaliz.Sheets(0).Cells(7, 0).Text = "Mo"
        GrdAnaliz.Sheets(0).Cells(8, 0).Text = "V"
        GrdAnaliz.Sheets(0).Cells(9, 0).Text = "Cu"
        GrdAnaliz.Sheets(0).Cells(10, 0).Text = "W"
        GrdAnaliz.Sheets(0).Cells(11, 0).Text = "Ti"
        GrdAnaliz.Sheets(0).Cells(12, 0).Text = "Sn"
        GrdAnaliz.Sheets(0).Cells(13, 0).Text = "Co"
        GrdAnaliz.Sheets(0).Cells(14, 0).Text = "AL"
        GrdAnaliz.Sheets(0).Cells(15, 0).Text = "AlSol"
        GrdAnaliz.Sheets(0).Cells(16, 0).Text = "Aloxy"
        GrdAnaliz.Sheets(0).Cells(17, 0).Text = "Pb"
        GrdAnaliz.Sheets(0).Cells(18, 0).Text = "B ppm"
        GrdAnaliz.Sheets(0).Cells(19, 0).Text = "Sb"
        GrdAnaliz.Sheets(0).Cells(20, 0).Text = "Nb"
        GrdAnaliz.Sheets(0).Cells(21, 0).Text = "Ca"
        GrdAnaliz.Sheets(0).Cells(22, 0).Text = "Zn"
        GrdAnaliz.Sheets(0).Cells(23, 0).Text = "N ppm"
        GrdAnaliz.Sheets(0).Cells(24, 0).Text = "Fe"
        GrdAnaliz.Sheets(0).Cells(25, 0).Text = "F"
        GrdAnaliz.Sheets(0).Cells(26, 0).Text = "CeQ"
        GrdAnaliz.Sheets(0).Cells(27, 0).Text = "S+P"
        'GrdAnaliz.Sheets(0).Cells(28, 0).Text = "'Y2"
    End Sub

    Sub grdcelalbey_getir()

        Try

            Dim s1, s2, s3, s4, s5
            Dim ToplamKayitSayisi
            Dim sip_No As String = ""
            sip_No = txtSipNoRapor.Text.Trim

            GelecekDrm = 4

            Dim DbConn As New ConnectGiris
            Dim DbConnFilmasin As New ConnectOracleFilmasin

            'Dim raporBasTar, raporBitTar
            'CEVIR(dateRaporBas0.Value)
            'raporBasTar = DonenTarih
            'CEVIR(dateRaporBit0.Value)
            'raporBitTar = DonenTarih



            If PrgKod = "ICPIYS" Then

                SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                     & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "'" _
                     & " and SIPARIS_GRUBU='ICPIYS'"
            Else


                SQL = " SELECT * FROM MRKSIP_CBK_FLM" _
                     & " WHERE MRKSIP_CBK_FLM.DURUM ='" & GelecekDrm & "'" _
                     & " and SIPARIS_GRUBU<>'ICPIYS'"
            End If



            DbConn.RaporWhile(SQL)

            Dim i As Int16 = 0
            grdcelalbey.Sheets(0).RowCount = 0
            Dim kacinci, SipGir, SipGirOnay, SipKontrol, SipOnay, SipUrtonay
            Dim DbConnToplam As New ConnectGiris



            While DbConn.MyDataReader.Read

                grdcelalbey.Sheets(0).RowCount += 1
                grdcelalbey.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                grdcelalbey.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                grdcelalbey.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("ULKE")
                grdcelalbey.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.Item("DURUM")

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS")) Then
                Else

                    kacinci = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), "-")
                    If kacinci <> 0 Then
                        SipGir = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), 1, kacinci - 1)
                        grdcelalbey.Sheets(0).Cells(i, 5).Text = SipGir & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY")) Then
                Else
                    kacinci = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), "-")
                    If kacinci <> 0 Then
                        SipGirOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), 1, kacinci - 1)
                        grdcelalbey.Sheets(0).Cells(i, 6).Text = SipGirOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_KONTROL")) Then
                Else
                    kacinci = InStr(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), "-")
                    If kacinci <> 0 Then
                        SipKontrol = Mid(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), 1, kacinci - 1)
                        grdcelalbey.Sheets(0).Cells(i, 7).Text = SipKontrol & ""
                    End If
                End If
                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_ONAY")) Then
                Else
                    kacinci = InStr(DbConn.MyDataReader.Item("SIPARIS_ONAY"), "-")
                    If kacinci <> 0 Then


                        SipOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_ONAY"), 1, kacinci - 1)
                        grdcelalbey.Sheets(0).Cells(i, 8).Text = SipOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY")) Then
                Else
                    kacinci = InStr(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), "-")
                    If kacinci <> 0 Then
                        SipUrtonay = Mid(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), 1, kacinci - 1)
                        grdcelalbey.Sheets(0).Cells(i, 9).Text = SipUrtonay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARISI_GIREN")) Then
                Else
                    grdcelalbey.Sheets(0).Cells(i, 10).Text = DbConn.MyDataReader.Item("SIPARISI_GIREN") & ""
                    grdcelalbey.Sheets(0).Cells(i, 11).Text = DbConn.MyDataReader.Item("SIPARIS_SAHIBI") & ""
                    grdcelalbey.Sheets(0).Cells(i, 11).Row.Height = 30
                End If
                Try

                    'toplam URETILENI BUL
                    Dim URETILENTNJ
                    URETILENTNJ = 0
                    SQL = "SELECT  SUM(TONAJ) from PAKETLEME_TNJ WHERE SIPNUM='" & DbConn.MyDataReader.Item("SIP_NO") & "'"
                    DbConnToplam.Sayac(SQL)
                    URETILENTNJ = DbConnToplam.GeriDonenRakam
                    DbConnToplam.Kapat()

                    If URETILENTNJ = 0 Then
                        Dim newsipnum = Mid(DbConn.MyDataReader.Item("SIP_NO"), 6, Len(DbConn.MyDataReader.Item("SIP_NO")) - 5)
                        SQL = "SELECT  SUM(TONAJ) from PAKETLEME_TNJ WHERE SIPNUM='" & newsipnum & "'"
                        DbConnToplam.Sayac(SQL)
                        URETILENTNJ = DbConnToplam.GeriDonenRakam
                        DbConnToplam.Kapat()
                    End If



                    'eger FILMASIN DE VARSA BU SIPARIS ORDADA TONAJINI BUL
                    If DbConn.MyDataReader.Item("SIP_NO") = "2014-4958" Then
                        Dim C = 0
                    End If

                    Dim URETILENTNJFILMASIN
                    URETILENTNJFILMASIN = 0
                    SQL = "SELECT  SUM(TONAJ) from PAKETLEME_TNJ WHERE SIPNUM='" & DbConn.MyDataReader.Item("SIP_NO") & "'"

                    SQL = "SELECT SIPNO,SUM(GERCEK_TARTIM) from" _
                    & " (SELECT U.SIPNO,U.DURUM,K.YEDEK_ALAN AS  GERCEK_TARTIM,K.SIPARIS_DURUMU_SONRA FROM FILMASIN.URETIM U, " _
                    & " FILMASIN.KONVEYOR K WHERE U.KTKID=K.KTKID AND DURUM IN (1) AND SIPNO='" & DbConn.MyDataReader.Item("SIP_NO") & "')" _
                    & " HAVING (SIPARIS_DURUMU_SONRA IS NULL OR SIPARIS_DURUMU_SONRA NOT IN ('Hurda','Piyasa','PIYASA','Standart Dışı'))" _
                    & " GROUP BY SIPNO,SIPARIS_DURUMU_SONRA"

                    DbConnFilmasin.RaporWhile(SQL)
                    While DbConnFilmasin.MyDataReader.Read
                        URETILENTNJFILMASIN = CDec(URETILENTNJFILMASIN) + CDec(DbConnFilmasin.MyDataReader.Item(1))
                    End While
                    DbConnFilmasin.Kapat()

                    If URETILENTNJFILMASIN = 0 Then
                        Dim newsipnum = Mid(DbConn.MyDataReader.Item("SIP_NO"), 6, Len(DbConn.MyDataReader.Item("SIP_NO")) - 5)
                        SQL = "SELECT SIPNO,SUM(GERCEK_TARTIM) from" _
                         & " (SELECT U.SIPNO,U.DURUM,K.YEDEK_ALAN AS  GERCEK_TARTIM,K.SIPARIS_DURUMU_SONRA FROM FILMASIN.URETIM U, " _
                         & " FILMASIN.KONVEYOR K WHERE U.KTKID=K.KTKID AND DURUM IN (1) AND SIPNO='" & newsipnum & "')" _
                         & " HAVING (SIPARIS_DURUMU_SONRA IS NULL OR SIPARIS_DURUMU_SONRA NOT IN ('Hurda','Piyasa','PIYASA','Standart Dışı'))" _
                         & " GROUP BY SIPNO,SIPARIS_DURUMU_SONRA"
                        DbConnFilmasin.RaporWhile(SQL)
                        While DbConnFilmasin.MyDataReader.Read
                            URETILENTNJFILMASIN = CDec(URETILENTNJFILMASIN) + CDec(DbConnFilmasin.MyDataReader.Item(1))
                        End While
                        DbConnFilmasin.Kapat()

                    End If

                    URETILENTNJ = CDec(URETILENTNJ) + CDec(URETILENTNJFILMASIN)

                    grdcelalbey.Sheets(0).Cells(i, 12).Text = URETILENTNJ / 1000

                    SQL = " SELECT SUM(MIKTAR) TOPLAM FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO= '" & DbConn.MyDataReader.Item("SIP_NO") & "'" _
                    & " AND REVIZ_NO= " & DbConn.MyDataReader.Item("REVIZ_NO")
                    DbConnToplam.RaporWhile(SQL)
                    While DbConnToplam.MyDataReader.Read
                        grdcelalbey.Sheets(0).Cells(i, 2).Text = DbConnToplam.MyDataReader.Item("TOPLAM") & ""
                    End While
                    DbConnToplam.Kapat()
                Catch ex As Exception
                    grdcelalbey.Sheets(0).Cells(i, 2).Text = "0"
                End Try

                i += 1
            End While

            DbConn.Kapat()

            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
            'lblMsg.Text = " Bulunan Toplam Kayıt=" & i

        Catch ex As Exception
            ' txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
        End Try

    End Sub

    Protected Sub grdcelalbey_ButtonCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles grdcelalbey.ButtonCommand

        If e.CommandName = "Getir" Then
            txtUretimSipNo.Text = grdcelalbey.Sheets(0).Cells(e.CommandArgument.X, 0).Text
            txtRevizyon.Text = grdcelalbey.Sheets(0).Cells(e.CommandArgument.X, 1).Text
            TabPanel3.Enabled = True
            GETIR()
            tabAnaliz.ActiveTab = TabPanel3
            Session("drm") = "bos"
        End If

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        grdcelalbey_getir()
    End Sub

    Protected Sub tabAnaliz_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabAnaliz.PreRender
        '   If Session("drm") <> "bos" Then
        'TabPanel3.Visible = False
        'End If
    End Sub
    Sub revizyonAnalizAktar(ByVal gelenSipNo As String, ByVal gelenRevizyon As Integer)
        Try
            Dim DbConn As New ConnectGiris
            SQL = "DELETE FROM MRKSIP_KUTUK_ANALIZ" _
            & " WHERE SIP_NO ='" & gelenSipNo & "'" _
            & " AND REVIZ_NO ='" & gelenRevizyon + 1 & "'"
            DbConn.Sil(SQL)
            DbConn.Kapat()
            Try
                SQL = " INSERT INTO MRKSIP_KUTUK_ANALIZ(" _
                & " SIP_NO, REVIZ_NO, LOT_NO, C_MIN, C_MAX, SI_MIN, SI_MAX, S_MIN, S_MAX, P_MIN, P_MAX, MN_MIN, MN_MAX, NI_MIN," _
                & " NI_MAX, CR_MIN, CR_MAX, MO_MIN, MO_MAX, V_MIN, V_MAX, CU_MIN, CU_MAX, W_MIN, W_MAX, TI_MIN, TI_MAX, SN_MIN," _
                & " SN_MAX, CO_MIN, CO_MAX, AL_MIN, AL_MAX, ALSOL_MIN, ALSOL_MAX, ALOXY_MIN, ALOXY_MAX, PB_MIN, PB_MAX, B_MIN, B_MAX," _
                & " SB_MIN, SB_MAX, NB_MIN, NB_MAX, CA_MIN, CA_MAX, ZN_MIN, ZN_MAX, N_MIN, N_MAX, FE_MIN, FE_MAX, F_MIN, F_MAX, CEQ_MIN," _
                & " CEQ_MAX, Y1, Y1MIN, Y1MAX, Y2, Y2MIN, Y2MAX,S_PMIN,S_PMAX )" _
                & " SELECT SIP_NO," _
                & "'" & gelenRevizyon + 1 & "'," _
                & " LOT_NO, C_MIN, C_MAX, SI_MIN, SI_MAX, S_MIN, S_MAX, P_MIN, P_MAX, MN_MIN, MN_MAX, NI_MIN, NI_MAX, CR_MIN, CR_MAX," _
                & " MO_MIN, MO_MAX, V_MIN, V_MAX, CU_MIN, CU_MAX, W_MIN, W_MAX, TI_MIN, TI_MAX, SN_MIN, SN_MAX, CO_MIN, CO_MAX, AL_MIN," _
                & " AL_MAX, ALSOL_MIN, ALSOL_MAX, ALOXY_MIN, ALOXY_MAX, PB_MIN, PB_MAX, B_MIN, B_MAX, SB_MIN, SB_MAX, NB_MIN, NB_MAX," _
                & " CA_MIN, CA_MAX, ZN_MIN, ZN_MAX, N_MIN, N_MAX, FE_MIN, FE_MAX, F_MIN, F_MAX, CEQ_MIN, CEQ_MAX, Y1, Y1MIN, Y1MAX, Y2, Y2MIN, Y2MAX ,S_PMIN,S_PMAX" _
                & " FROM(MRKSIP_KUTUK_ANALIZ) " _
                & " WHERE SIP_NO='" & gelenSipNo & "' " _
                & " AND REVIZ_NO='" & gelenRevizyon & "'"
                DbConn.SaveUpdate(SQL)
                DbConn.Kapat()
            Catch ex As Exception
                txtKayitDurumu.Text = "Revizyonlu sipariş için analiz aktarımı gerçekleşmedi!"
                txtKayitDurumu.BackColor = Drawing.Color.Red
            End Try
        Catch ex As Exception
            txtKayitDurumu.Text = "Revizyonlu sipariş için analiz silinemedi!"
            txtKayitDurumu.BackColor = Drawing.Color.Red
        End Try

    End Sub

    Private Sub Siparis_Tipinden_Alan_AcKapat(ByVal gelenMamulTip)

        If gelenMamulTip = "Kutuk" Then
            drpStandart.Enabled = True 'ömer beyin 27/01/2014 tarihili talebi üzerine true yapılmıştır
            drpKalite.Enabled = True
            drpCap.Enabled = True
            txtEbatTolNeg.Enabled = True 'ömer beyin 18/03/2015 tarihili talebi üzerine true yapılmıştır :)
            txtEbatTolPoz.Enabled = True 'ömer beyin 18/03/2015 tarihili talebi üzerine true yapılmıştır :)
            drpND.Enabled = False
            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtMiktar.Enabled = True
            txtBoyama.Enabled = True
            txtCubukSayisi.Enabled = False
            txtBirimAgirlik.Enabled = False
            txtPaketAgirlik.Enabled = True
            txtHadde_Tol_N.Enabled = False
            txtHadde_Tol_P.Enabled = False

            dateTerminBas.Enabled = True
            dateTerminBit.Enabled = True

            drpUrunBilgi.Enabled = False
            drpKutukTedarikci.Enabled = False
            txtKutukKalite.Enabled = False
            txtMusteriAdi.Enabled = False

            drpRotorTip.Enabled = False
            txtBosLiman.Enabled = True

            txtKoseRadyusu.Enabled = True
            txtRombiklik.Enabled = True
            txtDogSapma.Enabled = True
            txtBurulma.Enabled = True
            txtKesmeSekli.Enabled = True


            txtCapMikTolMin.Enabled = True
            txtCapMikTolMax.Enabled = True
            txtTopMikTolMin.Enabled = True
            txtTopMikTolMax.Enabled = True

            txtCapMikTolMin.BackColor = Drawing.Color.White
            txtCapMikTolMax.BackColor = Drawing.Color.White
            txtTopMikTolMin.BackColor = Drawing.Color.White
            txtTopMikTolMax.BackColor = Drawing.Color.White

            txtEbatTolNeg.BackColor = Drawing.Color.White
            txtEbatTolPoz.BackColor = Drawing.Color.White

            'drpStandart.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            drpStandart.BackColor = Drawing.Color.White
            drpKalite.BackColor = Drawing.Color.White
            drpCap.BackColor = Drawing.Color.White

            drpND.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            drpBoy.BackColor = Drawing.Color.White
            txtBoyTolNeg.BackColor = Drawing.Color.White
            txtBoyTolPoz.BackColor = Drawing.Color.White
            txtMiktar.BackColor = Drawing.Color.White
            txtBoyama.BackColor = Drawing.Color.White
            txtCubukSayisi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBirimAgirlik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtPaketAgirlik.BackColor = Drawing.Color.White
            txtHadde_Tol_N.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtHadde_Tol_P.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

            dateTerminBas.BackColor = Drawing.Color.White
            dateTerminBit.BackColor = Drawing.Color.White

            drpUrunBilgi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            drpKutukTedarikci.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtKutukKalite.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtMusteriAdi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")


            drpRotorTip.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBosLiman.BackColor = Drawing.Color.White

            txtKoseRadyusu.BackColor = Drawing.Color.White
            txtRombiklik.BackColor = Drawing.Color.White
            txtDogSapma.BackColor = Drawing.Color.White
            txtBurulma.BackColor = Drawing.Color.White
            txtKesmeSekli.BackColor = Drawing.Color.White

            fpEbatMiktar.Sheets(0).Columns(2).Visible = True
            fpEbatMiktar.Sheets(0).Columns(3).Visible = True
            fpEbatMiktar.Sheets(0).Columns(4).Visible = False
            fpEbatMiktar.Sheets(0).Columns(5).Visible = True
            fpEbatMiktar.Sheets(0).Columns(6).Visible = True
            fpEbatMiktar.Sheets(0).Columns(7).Visible = False
            fpEbatMiktar.Sheets(0).Columns(8).Visible = True
            fpEbatMiktar.Sheets(0).Columns(9).Visible = True
            fpEbatMiktar.Sheets(0).Columns(10).Visible = True
            fpEbatMiktar.Sheets(0).Columns(11).Visible = True
            fpEbatMiktar.Sheets(0).Columns(12).Visible = False
            fpEbatMiktar.Sheets(0).Columns(13).Visible = False
            fpEbatMiktar.Sheets(0).Columns(14).Visible = True
            fpEbatMiktar.Sheets(0).Columns(15).Visible = False
            fpEbatMiktar.Sheets(0).Columns(16).Visible = False
            fpEbatMiktar.Sheets(0).Columns(17).Visible = False
            fpEbatMiktar.Sheets(0).Columns(18).Visible = False
            fpEbatMiktar.Sheets(0).Columns(19).Visible = False
            fpEbatMiktar.Sheets(0).Columns(20).Visible = False
            fpEbatMiktar.Sheets(0).Columns(21).Visible = True
            fpEbatMiktar.Sheets(0).Columns(22).Visible = True
            fpEbatMiktar.Sheets(0).Columns(23).Visible = True
            fpEbatMiktar.Sheets(0).Columns(24).Visible = True
            fpEbatMiktar.Sheets(0).Columns(25).Visible = True
            fpEbatMiktar.Sheets(0).Columns(26).Visible = True
            fpEbatMiktar.Sheets(0).Columns(27).Visible = True
            fpEbatMiktar.Sheets(0).Columns(28).Visible = True
            fpEbatMiktar.Sheets(0).Columns(29).Visible = True
            fpEbatMiktar.Sheets(0).Columns(30).Visible = True
            fpEbatMiktar.Sheets(0).Columns(31).Visible = True
        End If


        If gelenMamulTip = "Kangal" Then

            drpStandart.Enabled = True
            drpKalite.Enabled = True
            drpCap.Enabled = True
            txtEbatTolNeg.Enabled = True
            txtEbatTolPoz.Enabled = True
            drpND.Enabled = True

            drpBoy.Enabled = False
            txtBoyTolNeg.Enabled = False
            txtBoyTolPoz.Enabled = False
            txtMiktar.Enabled = True
            txtBoyama.Enabled = True
            txtCubukSayisi.Enabled = False

            txtPaketAgirlik.Enabled = True

            dateTerminBas.Enabled = True
            dateTerminBit.Enabled = True

            drpUrunBilgi.Enabled = True
            drpKutukTedarikci.Enabled = True
            txtKutukKalite.Enabled = True
            txtMusteriAdi.Enabled = True

            drpRotorTip.Enabled = True
            txtBosLiman.Enabled = True

            txtKoseRadyusu.Enabled = False
            txtRombiklik.Enabled = False
            txtDogSapma.Enabled = False
            txtBurulma.Enabled = False
            txtKesmeSekli.Enabled = False




            If PrgKod = "OZLCLK" Or PrgKod = "KTKTLP" Then
                txtTopMikTolMin.Enabled = False
                txtTopMikTolMax.Enabled = False

                txtCapMikTolMin.Enabled = False
                txtCapMikTolMax.Enabled = False

                txtCapMikTolMin.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
                txtCapMikTolMax.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
                txtTopMikTolMin.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
                txtTopMikTolMax.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

                txtBirimAgirlik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
                txtBirimAgirlik.Enabled = False

                txtHadde_Tol_N.Enabled = False
                txtHadde_Tol_P.Enabled = False

                txtHadde_Tol_N.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
                txtHadde_Tol_P.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

            Else

                txtTopMikTolMin.Enabled = True
                txtTopMikTolMax.Enabled = True
                txtCapMikTolMin.Enabled = True
                txtCapMikTolMax.Enabled = True


                txtCapMikTolMin.BackColor = Drawing.Color.White
                txtCapMikTolMax.BackColor = Drawing.Color.White
                txtTopMikTolMin.BackColor = Drawing.Color.White
                txtTopMikTolMax.BackColor = Drawing.Color.White

                txtBirimAgirlik.Enabled = True
                txtBirimAgirlik.BackColor = Drawing.Color.White


                txtHadde_Tol_N.Enabled = True
                txtHadde_Tol_P.Enabled = True


                txtHadde_Tol_N.BackColor = Drawing.Color.White
                txtHadde_Tol_P.BackColor = Drawing.Color.White

            End If





            txtEbatTolNeg.BackColor = Drawing.Color.White
            txtEbatTolPoz.BackColor = Drawing.Color.White


            drpStandart.BackColor = Drawing.Color.White
            drpKalite.BackColor = Drawing.Color.White
            drpCap.BackColor = Drawing.Color.White
            drpND.BackColor = Drawing.Color.White

            drpBoy.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBoyTolNeg.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBoyTolPoz.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtMiktar.BackColor = Drawing.Color.White
            txtBoyama.BackColor = Drawing.Color.White
            txtCubukSayisi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

            txtPaketAgirlik.BackColor = Drawing.Color.White

            dateTerminBas.BackColor = Drawing.Color.White
            dateTerminBit.BackColor = Drawing.Color.White

            drpUrunBilgi.BackColor = Drawing.Color.White
            drpKutukTedarikci.BackColor = Drawing.Color.White
            txtKutukKalite.BackColor = Drawing.Color.White
            txtMusteriAdi.BackColor = Drawing.Color.White

            drpRotorTip.BackColor = Drawing.Color.White
            txtBosLiman.BackColor = Drawing.Color.White

            txtKoseRadyusu.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtRombiklik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtDogSapma.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBurulma.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtKesmeSekli.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")


            If PrgKod = "OZLCLK" Or PrgKod = "KTKTLP" Then
                fpEbatMiktar.Sheets(0).Columns(12).Visible = False
                fpEbatMiktar.Sheets(0).Columns(13).Visible = False
                fpEbatMiktar.Sheets(0).Columns(15).Visible = False
                fpEbatMiktar.Sheets(0).Columns(16).Visible = False
                fpEbatMiktar.Sheets(0).Columns(32).Visible = False
                fpEbatMiktar.Sheets(0).Columns(33).Visible = False
                fpEbatMiktar.Sheets(0).Columns(34).Visible = False
                fpEbatMiktar.Sheets(0).Columns(35).Visible = False

            Else

                fpEbatMiktar.Sheets(0).Columns(12).Visible = True
                fpEbatMiktar.Sheets(0).Columns(13).Visible = True
                fpEbatMiktar.Sheets(0).Columns(15).Visible = True
                fpEbatMiktar.Sheets(0).Columns(16).Visible = True
                fpEbatMiktar.Sheets(0).Columns(32).Visible = True
                fpEbatMiktar.Sheets(0).Columns(33).Visible = True
                fpEbatMiktar.Sheets(0).Columns(34).Visible = False
                fpEbatMiktar.Sheets(0).Columns(35).Visible = False

            End If

            fpEbatMiktar.Sheets(0).Columns(2).Visible = True
            fpEbatMiktar.Sheets(0).Columns(3).Visible = True
            fpEbatMiktar.Sheets(0).Columns(4).Visible = True
            fpEbatMiktar.Sheets(0).Columns(5).Visible = True
            fpEbatMiktar.Sheets(0).Columns(6).Visible = True
            fpEbatMiktar.Sheets(0).Columns(7).Visible = True
            fpEbatMiktar.Sheets(0).Columns(8).Visible = True
            fpEbatMiktar.Sheets(0).Columns(9).Visible = True
            fpEbatMiktar.Sheets(0).Columns(10).Visible = True
            fpEbatMiktar.Sheets(0).Columns(11).Visible = True
            fpEbatMiktar.Sheets(0).Columns(14).Visible = True


            fpEbatMiktar.Sheets(0).Columns(17).Visible = True
            fpEbatMiktar.Sheets(0).Columns(18).Visible = True
            fpEbatMiktar.Sheets(0).Columns(19).Visible = True
            fpEbatMiktar.Sheets(0).Columns(20).Visible = True
            fpEbatMiktar.Sheets(0).Columns(21).Visible = True
            fpEbatMiktar.Sheets(0).Columns(22).Visible = True
            fpEbatMiktar.Sheets(0).Columns(23).Visible = True
            fpEbatMiktar.Sheets(0).Columns(24).Visible = True
            fpEbatMiktar.Sheets(0).Columns(25).Visible = False
            fpEbatMiktar.Sheets(0).Columns(26).Visible = False
            fpEbatMiktar.Sheets(0).Columns(27).Visible = False
            fpEbatMiktar.Sheets(0).Columns(28).Visible = False
            fpEbatMiktar.Sheets(0).Columns(29).Visible = False
            fpEbatMiktar.Sheets(0).Columns(30).Visible = True
            fpEbatMiktar.Sheets(0).Columns(31).Visible = True

        End If

        If gelenMamulTip = "Kangal Doğrultma" Then

            drpStandart.Enabled = True
            drpKalite.Enabled = True
            drpCap.Enabled = True
            txtEbatTolNeg.Enabled = True
            txtEbatTolPoz.Enabled = True
            drpND.Enabled = True

            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtMiktar.Enabled = True
            txtBoyama.Enabled = True
            txtCubukSayisi.Enabled = True
            txtBirimAgirlik.Enabled = True
            txtPaketAgirlik.Enabled = True
            txtHadde_Tol_N.Enabled = True
            txtHadde_Tol_P.Enabled = True

            dateTerminBas.Enabled = True
            dateTerminBit.Enabled = True

            drpUrunBilgi.Enabled = True
            drpKutukTedarikci.Enabled = True
            txtKutukKalite.Enabled = True
            txtMusteriAdi.Enabled = True

            drpRotorTip.Enabled = False
            txtBosLiman.Enabled = True

            txtKoseRadyusu.Enabled = False
            txtRombiklik.Enabled = False
            txtDogSapma.Enabled = False
            txtBurulma.Enabled = False
            txtKesmeSekli.Enabled = False

            txtCapMikTolMin.Enabled = True
            txtCapMikTolMax.Enabled = True
            txtTopMikTolMin.Enabled = True
            txtTopMikTolMax.Enabled = True

            txtCapMikTolMin.BackColor = Drawing.Color.White
            txtCapMikTolMax.BackColor = Drawing.Color.White
            txtTopMikTolMin.BackColor = Drawing.Color.White
            txtTopMikTolMax.BackColor = Drawing.Color.White


            txtEbatTolNeg.BackColor = Drawing.Color.White
            txtEbatTolPoz.BackColor = Drawing.Color.White

            drpStandart.BackColor = Drawing.Color.White
            drpKalite.BackColor = Drawing.Color.White
            drpCap.BackColor = Drawing.Color.White


            drpND.BackColor = Drawing.Color.White

            drpBoy.BackColor = Drawing.Color.White
            txtBoyTolNeg.BackColor = Drawing.Color.White
            txtBoyTolPoz.BackColor = Drawing.Color.White
            txtMiktar.BackColor = Drawing.Color.White
            txtBoyama.BackColor = Drawing.Color.White
            txtCubukSayisi.BackColor = Drawing.Color.White
            txtBirimAgirlik.BackColor = Drawing.Color.White
            txtPaketAgirlik.BackColor = Drawing.Color.White
            txtHadde_Tol_N.BackColor = Drawing.Color.White
            txtHadde_Tol_P.BackColor = Drawing.Color.White

            dateTerminBas.BackColor = Drawing.Color.White
            dateTerminBit.BackColor = Drawing.Color.White

            drpUrunBilgi.BackColor = Drawing.Color.White
            drpKutukTedarikci.BackColor = Drawing.Color.White
            txtKutukKalite.BackColor = Drawing.Color.White
            txtMusteriAdi.BackColor = Drawing.Color.White

            drpRotorTip.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBosLiman.BackColor = Drawing.Color.White

            txtKoseRadyusu.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtRombiklik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtDogSapma.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBurulma.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtKesmeSekli.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")


            fpEbatMiktar.Sheets(0).Columns(2).Visible = True
            fpEbatMiktar.Sheets(0).Columns(3).Visible = True
            fpEbatMiktar.Sheets(0).Columns(4).Visible = True
            fpEbatMiktar.Sheets(0).Columns(5).Visible = True
            fpEbatMiktar.Sheets(0).Columns(6).Visible = True
            fpEbatMiktar.Sheets(0).Columns(7).Visible = True
            fpEbatMiktar.Sheets(0).Columns(8).Visible = True
            fpEbatMiktar.Sheets(0).Columns(9).Visible = True
            fpEbatMiktar.Sheets(0).Columns(10).Visible = True
            fpEbatMiktar.Sheets(0).Columns(11).Visible = True
            fpEbatMiktar.Sheets(0).Columns(12).Visible = True
            fpEbatMiktar.Sheets(0).Columns(13).Visible = True
            fpEbatMiktar.Sheets(0).Columns(14).Visible = True
            fpEbatMiktar.Sheets(0).Columns(15).Visible = True
            fpEbatMiktar.Sheets(0).Columns(16).Visible = True
            fpEbatMiktar.Sheets(0).Columns(17).Visible = True
            fpEbatMiktar.Sheets(0).Columns(18).Visible = True
            fpEbatMiktar.Sheets(0).Columns(19).Visible = True
            fpEbatMiktar.Sheets(0).Columns(20).Visible = True
            fpEbatMiktar.Sheets(0).Columns(21).Visible = True
            fpEbatMiktar.Sheets(0).Columns(22).Visible = True
            fpEbatMiktar.Sheets(0).Columns(23).Visible = True
            fpEbatMiktar.Sheets(0).Columns(24).Visible = True
            fpEbatMiktar.Sheets(0).Columns(25).Visible = False
            fpEbatMiktar.Sheets(0).Columns(26).Visible = False
            fpEbatMiktar.Sheets(0).Columns(27).Visible = False
            fpEbatMiktar.Sheets(0).Columns(28).Visible = False
            fpEbatMiktar.Sheets(0).Columns(29).Visible = False
            fpEbatMiktar.Sheets(0).Columns(30).Visible = True
            fpEbatMiktar.Sheets(0).Columns(31).Visible = True


        End If


        If gelenMamulTip = "Çubuk" Then

            drpStandart.Enabled = True
            drpKalite.Enabled = True
            drpCap.Enabled = True
            txtEbatTolNeg.Enabled = False
            txtEbatTolPoz.Enabled = False
            drpND.Enabled = True

            drpBoy.Enabled = True
            txtBoyTolNeg.Enabled = True
            txtBoyTolPoz.Enabled = True
            txtMiktar.Enabled = True
            txtBoyama.Enabled = True
            txtCubukSayisi.Enabled = True
            txtBirimAgirlik.Enabled = True
            txtPaketAgirlik.Enabled = True
            txtHadde_Tol_N.Enabled = True
            txtHadde_Tol_P.Enabled = True

            dateTerminBas.Enabled = True
            dateTerminBit.Enabled = True

            drpUrunBilgi.Enabled = False
            drpKutukTedarikci.Enabled = False
            txtKutukKalite.Enabled = False
            txtMusteriAdi.Enabled = False

            drpRotorTip.Enabled = False
            txtBosLiman.Enabled = True

            txtKoseRadyusu.Enabled = False
            txtRombiklik.Enabled = False
            txtDogSapma.Enabled = False
            txtBurulma.Enabled = False
            txtKesmeSekli.Enabled = False

            txtCapMikTolMin.Enabled = True
            txtCapMikTolMax.Enabled = True
            txtTopMikTolMin.Enabled = True
            txtTopMikTolMax.Enabled = True

            txtCapMikTolMin.BackColor = Drawing.Color.White
            txtCapMikTolMax.BackColor = Drawing.Color.White
            txtTopMikTolMin.BackColor = Drawing.Color.White
            txtTopMikTolMax.BackColor = Drawing.Color.White



            drpStandart.BackColor = Drawing.Color.White
            drpKalite.BackColor = Drawing.Color.White
            drpCap.BackColor = Drawing.Color.White
            txtEbatTolNeg.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtEbatTolPoz.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            drpND.BackColor = Drawing.Color.White

            drpBoy.BackColor = Drawing.Color.White
            txtBoyTolNeg.BackColor = Drawing.Color.White
            txtBoyTolPoz.BackColor = Drawing.Color.White
            txtMiktar.BackColor = Drawing.Color.White
            txtBoyama.BackColor = Drawing.Color.White
            txtCubukSayisi.BackColor = Drawing.Color.White
            txtBirimAgirlik.BackColor = Drawing.Color.White
            txtPaketAgirlik.BackColor = Drawing.Color.White
            txtHadde_Tol_N.BackColor = Drawing.Color.White
            txtHadde_Tol_P.BackColor = Drawing.Color.White

            dateTerminBas.BackColor = Drawing.Color.White
            dateTerminBit.BackColor = Drawing.Color.White

            drpUrunBilgi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            drpKutukTedarikci.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtKutukKalite.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtMusteriAdi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

            drpRotorTip.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBosLiman.BackColor = Drawing.Color.White

            txtKoseRadyusu.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtRombiklik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtDogSapma.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtBurulma.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
            txtKesmeSekli.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")


            fpEbatMiktar.Sheets(0).Columns(2).Visible = True
            fpEbatMiktar.Sheets(0).Columns(3).Visible = True
            fpEbatMiktar.Sheets(0).Columns(4).Visible = True
            fpEbatMiktar.Sheets(0).Columns(5).Visible = True
            fpEbatMiktar.Sheets(0).Columns(6).Visible = True
            fpEbatMiktar.Sheets(0).Columns(7).Visible = True
            fpEbatMiktar.Sheets(0).Columns(8).Visible = True
            fpEbatMiktar.Sheets(0).Columns(9).Visible = True
            fpEbatMiktar.Sheets(0).Columns(10).Visible = True
            fpEbatMiktar.Sheets(0).Columns(11).Visible = True
            fpEbatMiktar.Sheets(0).Columns(12).Visible = True
            fpEbatMiktar.Sheets(0).Columns(13).Visible = True
            fpEbatMiktar.Sheets(0).Columns(14).Visible = True
            fpEbatMiktar.Sheets(0).Columns(15).Visible = True
            fpEbatMiktar.Sheets(0).Columns(16).Visible = True
            fpEbatMiktar.Sheets(0).Columns(17).Visible = True
            fpEbatMiktar.Sheets(0).Columns(18).Visible = True
            fpEbatMiktar.Sheets(0).Columns(19).Visible = True
            fpEbatMiktar.Sheets(0).Columns(20).Visible = True
            fpEbatMiktar.Sheets(0).Columns(21).Visible = True
            fpEbatMiktar.Sheets(0).Columns(22).Visible = True
            fpEbatMiktar.Sheets(0).Columns(23).Visible = True
            fpEbatMiktar.Sheets(0).Columns(24).Visible = True
            fpEbatMiktar.Sheets(0).Columns(25).Visible = False '
            fpEbatMiktar.Sheets(0).Columns(26).Visible = False '
            fpEbatMiktar.Sheets(0).Columns(27).Visible = False '
            fpEbatMiktar.Sheets(0).Columns(28).Visible = False
            fpEbatMiktar.Sheets(0).Columns(29).Visible = False
            fpEbatMiktar.Sheets(0).Columns(30).Visible = False
            fpEbatMiktar.Sheets(0).Columns(31).Visible = False


        End If


    End Sub
    Private Sub Secilirken_Tum_alanları_Kapat()

        Siparis_Sahibi.Enabled = False
        txtMamul.Enabled = False
        txtTopMikTolNeg.Enabled = False
        txtTopMikTolPoz.Enabled = False
        txtCapMikTolNeg.Enabled = False
        txtCapMikTolPoz.Enabled = False
        rdFaturalama.Enabled = False
        drpUlke.Enabled = False
        txtPaketleme.Enabled = False
        txtEtiket.Enabled = False
        txtGozetim.Enabled = False
        txtOzelSart.Enabled = False

        ' sag taraf
        drpStandart.Enabled = False
        drpKalite.Enabled = False
        drpCap.Enabled = False
        txtEbatTolNeg.Enabled = False
        txtEbatTolPoz.Enabled = False
        drpND.Enabled = False
        drpBoy.Enabled = False
        txtBoyTolNeg.Enabled = False
        txtBoyTolPoz.Enabled = False
        txtMiktar.Enabled = False
        txtBoyama.Enabled = False
        txtCubukSayisi.Enabled = False
        txtBirimAgirlik.Enabled = False
        txtPaketAgirlik.Enabled = False
        txtHadde_Tol_N.Enabled = False
        txtHadde_Tol_P.Enabled = False

        dateTerminBas.Enabled = False
        dateTerminBit.Enabled = False

        drpUrunBilgi.Enabled = False
        drpKutukTedarikci.Enabled = False
        txtKutukKalite.Enabled = False
        txtMusteriAdi.Enabled = False

        drpRotorTip.Enabled = False
        txtBosLiman.Enabled = False

        txtKoseRadyusu.Enabled = False
        txtRombiklik.Enabled = False
        txtDogSapma.Enabled = False
        txtBurulma.Enabled = False
        txtKesmeSekli.Enabled = False


        txtCapMikTolMin.Enabled = False
        txtCapMikTolMax.Enabled = False
        txtTopMikTolMin.Enabled = False
        txtTopMikTolMax.Enabled = False

        txtCapMikTolMin.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtCapMikTolMax.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtTopMikTolMin.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtTopMikTolMax.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")


        drpStandart.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        drpKalite.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        drpCap.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtEbatTolNeg.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtEbatTolPoz.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        drpND.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

        drpBoy.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtBoyTolNeg.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtBoyTolPoz.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtMiktar.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtBoyama.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtCubukSayisi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtBirimAgirlik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtPaketAgirlik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtHadde_Tol_N.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtHadde_Tol_P.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

        dateTerminBas.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        dateTerminBit.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

        drpUrunBilgi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        drpKutukTedarikci.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtKutukKalite.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtMusteriAdi.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

        drpRotorTip.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtBosLiman.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

        txtKoseRadyusu.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtRombiklik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtDogSapma.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtBurulma.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")
        txtKesmeSekli.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

    End Sub
    Private Sub Soldaki_Tum_alanları_Ac()

        'txtUretimSipNo.Enabled = True

        Siparis_Sahibi.Enabled = True
        txtMamul.Enabled = True

        txtToplamMik.Enabled = False
        txtToplamMik.BackColor = Drawing.ColorTranslator.FromHtml("#D4D0C8")

        txtTopMikTolNeg.Enabled = True
        txtTopMikTolPoz.Enabled = True
        txtCapMikTolNeg.Enabled = True
        txtCapMikTolPoz.Enabled = True
        rdFaturalama.Enabled = True
        drpUlke.Enabled = True
        txtPaketleme.Enabled = True
        txtEtiket.Enabled = True
        txtGozetim.Enabled = True
        txtOzelSart.Enabled = True

    End Sub

    Private Sub SagTarafı_Temizle()

        'txtLotNo.Text = ""
        'drpMamulTip.Text = "-"
        'drpStandart.Text = "-"
        drpKalite.Text = ""
        'drpCap.Text = ""
        drpND.Text = ""

        txtBoyTolPoz.Text = ""
        txtBoyTolNeg.Text = ""
        txtMiktar.Text = ""
        txtBoyama.Text = ""
        txtCubukSayisi.Text = ""
        txtBirimAgirlik.Text = ""
        txtPaketAgirlik.Text = ""
        drpMarka.Text = ""
        drpRotorTip.Items.Clear()
        txtBosLiman.Text = ""
        drpUrunBilgi.Text = ""
        drpKutukTedarikci.Text = ""
        txtKutukKalite.Text = ""
        txtMusteriAdi.Text = ""
        dateTerminBas.Text = ""
        dateTerminBit.Text = ""
        txtHadde_Tol_N.Text = ""
        txtHadde_Tol_P.Text = ""
        drpBoy.Text = ""
        drpCap.Text = ""


        'lblEk.Text = ""

        txtKoseRadyusu.Text = ""
        txtRombiklik.Text = ""
        txtDogSapma.Text = ""
        txtBurulma.Text = ""
        txtKesmeSekli.Text = ""

        txtCapMikTolMin.Text = ""
        txtCapMikTolMax.Text = ""
        txtTopMikTolMin.Text = ""
        txtTopMikTolMax.Text = ""


    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim I As Integer
        Dim BAK

        For I = 0 To fpLotKimyasal.Sheets(0).RowCount - 1
            BAK = fpLotKimyasal.Sheets(0).Cells(I, 0).Text
            If BAK = DropDownList1.Text Then
                fpLotKimyasal.Sheets(0).Cells(I, 1).Text = txtLotAnaliz0.Text
                fpLotKimyasal.Sheets(0).Cells(I, 2).Text = txtLotAnaliz1.Text
            End If
        Next

    End Sub


    Private Sub ShowMessage(ByVal GelenText As String)
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "", "alert('Siparişi Açma Yetkiniz Yok.');", True)
    End Sub

    Public Sub AspNetMsgFunc(ByVal sMsg As String)

        ' ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Record saved successfully');", True)

        'Dim message = New JavaScriptSerializer().Serialize(sMsg)
        'Dim script = String.Format("alert({0});", message)

        'ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), sMsg, "alert('" + sMsg + "');", True)

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
    Private Sub MailAdresiBul(ByVal USer)
        MailAdresi = ""
        Dim DbConn As New ConnectGiris

        SQL = " SELECT * FROM URTTNM.USRSIPARIS" _
        & " WHERE TANIMI='" & USer & "'"

        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read
            MailAdresi = DbConn.MyDataReader.Item("USER_MAIL_ADRESI")

        End While
        DbConn.Kapat()

    End Sub
    Sub Rapor_New3()


        'Kullanıcı
        Dim kacıncı, SipGir, SipGirOnay, SipKontrol, SipOnay, SipUrtonay
        Dim DbConn As New ConnectGiris
        Try

            fpSiparisGetir.Sheets(0).Columns(14).Visible = True
            tabAnaliz.ActiveTab = TabPanel1

            Dim SIPARISIN_GRUBU, SIPARISIN_SAHIBI, KULLANICI_YETKISI, SIPARISI_GIREN

            Dim s1, s2, s3, s4, s5
            Dim ToplamKayitSayisi


            If PrgKod = "ICPIYS" Then
                SQL = "SELECT * FROM MRKSIP_CBK_FLM WHERE  SIPARIS_GRUBU='ICPIYS' AND DURUM<>999  ORDER BY DURUM"
            End If

            DbConn.RaporWhile(SQL)

            Dim i As Int16 = 0
            fpSiparisGetir.Sheets(0).RowCount = 0

            Dim DbconnToplam As New ConnectGiris

            While DbConn.MyDataReader.Read

                fpSiparisGetir.Sheets(0).RowCount += 1
                fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("ULKE")
                fpSiparisGetir.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.Item("DURUM")

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS")) Then
                Else

                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), "-")
                    If kacıncı <> 0 Then
                        SipGir = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 5).Text = SipGir & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipGirOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 6).Text = SipGirOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_KONTROL")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), "-")
                    If kacıncı <> 0 Then
                        SipKontrol = Mid(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 7).Text = SipKontrol & ""
                    End If
                End If
                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 8).Text = SipOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipUrtonay = Mid(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 9).Text = SipUrtonay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARISI_GIREN")) Then
                Else
                    fpSiparisGetir.Sheets(0).Cells(i, 10).Text = DbConn.MyDataReader.Item("SIPARISI_GIREN") & ""
                    fpSiparisGetir.Sheets(0).Cells(i, 11).Text = DbConn.MyDataReader.Item("SIPARIS_SAHIBI") & ""
                    fpSiparisGetir.Sheets(0).Cells(i, 11).Row.Height = 30
                End If

                Try
                    SQL = " SELECT SUM(MIKTAR) TOPLAM FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO= '" & DbConn.MyDataReader.Item("SIP_NO") & "'" _
                    & " AND REVIZ_NO= " & DbConn.MyDataReader.Item("REVIZ_NO")
                    DbconnToplam.RaporWhile(SQL)
                    While DbconnToplam.MyDataReader.Read
                        fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbconnToplam.MyDataReader.Item("TOPLAM") & ""
                    End While
                    DbconnToplam.Kapat()
                Catch ex As Exception
                    fpSiparisGetir.Sheets(0).Cells(i, 2).Text = "0"
                End Try

                Dim drmx
                If DbConn.MyDataReader.Item("DURUM") = -1 Then drmx = "Yeni" ' Sipariş Girildi"
                If DbConn.MyDataReader.Item("DURUM") = 0 Then drmx = "Giriş Onay" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 1 Then drmx = "Kontrol" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 2 Then drmx = "Müdür Onay" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 3 Then drmx = "Planlamada" ' Yönlendirilen Sipariş"
                If DbConn.MyDataReader.Item("DURUM") = 4 Then drmx = "Uretilecek Sip." ' Siparisler"
                If DbConn.MyDataReader.Item("DURUM") = 88 Then drmx = "Iptal" ' Edilen Siparis"
                If DbConn.MyDataReader.Item("DURUM") = 90 Then drmx = "Uretildi" ' 
                If DbConn.MyDataReader.Item("DURUM") = 99 Then drmx = "Revize" ' Edilen Siparis"
                fpSiparisGetir.Sheets(0).Cells(i, 14).Text = DbConn.MyDataReader.Item("DURUM") & "-" & drmx
                i += 1
            End While

            DbConn.Kapat()

            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
            'lblMsg.Text = " Bulunan Toplam Kayıt=" & i
            txtSipNoRapor.Text = ""
son:
        Catch ex As Exception
            ' txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
        End Try
    End Sub

    Protected Sub btnListele_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnListele.Click

        'Kullanıcı
        Dim kacıncı, SipGir, SipGirOnay, SipKontrol, SipOnay, SipUrtonay
        Dim DbConn As New ConnectGiris
        Try

            fpSiparisGetir.Sheets(0).Columns(14).Visible = True
            tabAnaliz.ActiveTab = TabPanel1

            Dim SIPARISIN_GRUBU, SIPARISIN_SAHIBI, KULLANICI_YETKISI, SIPARISI_GIREN

            Dim s1, s2, s3, s4, s5
            Dim ToplamKayitSayisi
            Dim TARX1, TARX2
            CEVIR(dateRaporBas.Text)
            TARX1 = DonenTarih
            CEVIR(dateRaporBit.Text)
            TARX2 = DonenTarih
            If PrgKod = "ICPIYS" Then
                SQL = "SELECT * FROM MRKSIP_CBK_FLM WHERE  SIPARIS_GRUBU='ICPIYS' AND DURUM<>999 " _
                & " and SIP_TAR BETWEEN " & TARX1 & " AND " & TARX2 _
                & " ORDER BY SIP_TAR"
            Else
                SQL = "SELECT * FROM MRKSIP_CBK_FLM WHERE  SIPARIS_GRUBU<>'ICPIYS' AND DURUM<>999 " _
                & " and SIP_TAR BETWEEN " & TARX1 & " AND " & TARX2 _
                & " ORDER BY SIP_TAR"
            End If
            DbConn.RaporWhile(SQL)
            Dim i As Int16 = 0
            fpSiparisGetir.Sheets(0).RowCount = 0

            Dim DbconnToplam As New ConnectGiris

            While DbConn.MyDataReader.Read

                fpSiparisGetir.Sheets(0).RowCount += 1
                fpSiparisGetir.Sheets(0).Cells(i, 0).Text = DbConn.MyDataReader.Item("SIP_NO")
                fpSiparisGetir.Sheets(0).Cells(i, 1).Text = DbConn.MyDataReader.Item("REVIZ_NO")
                fpSiparisGetir.Sheets(0).Cells(i, 3).Text = DbConn.MyDataReader.Item("ULKE")
                fpSiparisGetir.Sheets(0).Cells(i, 4).Text = DbConn.MyDataReader.Item("DURUM")

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS")) Then
                Else

                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), "-")
                    If kacıncı <> 0 Then
                        SipGir = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 5).Text = SipGir & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipGirOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_GIRIS_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 6).Text = SipGirOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_KONTROL")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), "-")
                    If kacıncı <> 0 Then
                        SipKontrol = Mid(DbConn.MyDataReader.Item("SIPARIS_KONTROL"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 7).Text = SipKontrol & ""
                    End If
                End If
                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipOnay = Mid(DbConn.MyDataReader.Item("SIPARIS_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 8).Text = SipOnay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY")) Then
                Else
                    kacıncı = InStr(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), "-")
                    If kacıncı <> 0 Then
                        SipUrtonay = Mid(DbConn.MyDataReader.Item("SIPARIS_URETIM_ONAY"), 1, kacıncı - 1)
                        fpSiparisGetir.Sheets(0).Cells(i, 9).Text = SipUrtonay & ""
                    End If
                End If

                If IsDBNull(DbConn.MyDataReader.Item("SIPARISI_GIREN")) Then
                Else
                    fpSiparisGetir.Sheets(0).Cells(i, 10).Text = DbConn.MyDataReader.Item("SIPARISI_GIREN") & ""
                    fpSiparisGetir.Sheets(0).Cells(i, 11).Text = DbConn.MyDataReader.Item("SIPARIS_SAHIBI") & ""
                    fpSiparisGetir.Sheets(0).Cells(i, 11).Row.Height = 30
                End If

                Try
                    SQL = " SELECT SUM(MIKTAR) TOPLAM FROM MRKSIP_CBK_FLM_ALT " _
                    & " WHERE SIP_NO= '" & DbConn.MyDataReader.Item("SIP_NO") & "'" _
                    & " AND REVIZ_NO= " & DbConn.MyDataReader.Item("REVIZ_NO")
                    DbconnToplam.RaporWhile(SQL)
                    While DbconnToplam.MyDataReader.Read
                        fpSiparisGetir.Sheets(0).Cells(i, 2).Text = DbconnToplam.MyDataReader.Item("TOPLAM") & ""
                    End While
                    DbconnToplam.Kapat()
                Catch ex As Exception
                    fpSiparisGetir.Sheets(0).Cells(i, 2).Text = "0"
                End Try

                Dim drmx
                If DbConn.MyDataReader.Item("DURUM") = -1 Then drmx = "Yeni" ' Sipariş Girildi"
                If DbConn.MyDataReader.Item("DURUM") = 0 Then drmx = "Giriş Onay" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 1 Then drmx = "Kontrol" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 2 Then drmx = "Müdür Onay" ' Bekleyen"
                If DbConn.MyDataReader.Item("DURUM") = 3 Then drmx = "Planlamada" ' Yönlendirilen Sipariş"
                If DbConn.MyDataReader.Item("DURUM") = 4 Then drmx = "Uretilecek Sip." ' Siparisler"
                If DbConn.MyDataReader.Item("DURUM") = 88 Then drmx = "Iptal" ' Edilen Siparis"
                If DbConn.MyDataReader.Item("DURUM") = 99 Then drmx = "Revize" ' Edilen Siparis"
                If DbConn.MyDataReader.Item("DURUM") = 90 Then drmx = "Uretildi" ' Edilen Siparis"
                fpSiparisGetir.Sheets(0).Cells(i, 14).Text = DbConn.MyDataReader.Item("DURUM") & "-" & drmx
                i += 1
            End While

            DbConn.Kapat()
            txtKayitDurumu.BackColor = Drawing.ColorTranslator.FromHtml("#AABE74")
            txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
            'lblMsg.Text = " Bulunan Toplam Kayıt=" & i
son:


            GRIDLERI_TOPARLA()
        Catch ex As Exception
            ' txtKayitDurumu.Text = "Durumu AÇIK olan siparişler getirildi."
        End Try
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        dosyaUpload(txtUretimSipNo.Text, txtRevizyon.Text)
    End Sub
    Sub dosyaUpload(ByVal gelenSipNo, ByVal gelenRevNo)
        Try
            If FileUpload1.HasFile Then
                Dim filenanmme As String = System.IO.Path.GetFileName(FileUpload1.FileName)
                filenanmme = gelenSipNo & "_" & gelenRevNo & "_" & filenanmme
                'FileUpload1.SaveAs(Server.MapPath("~/upload/" + filenanmme))
                FileUpload1.SaveAs("\\192.168.198.8\upload\" & filenanmme)
                lblmessage.Text = "Dosya Yüklendi."
                lblEk.Text = filenanmme

            Else
                lblmessage.Text = "Lütfen dosya seçin!"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim hedef = "\\192.168.198.8\Upload\"
            Response.Clear()
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & lblEk.Text)
            'Response.TransmitFile(hedef & lblEk.Text)
            Response.WriteFile(hedef & lblEk.Text)
            Response.End()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click

        Sil()

    End Sub



    Protected Sub btnTarihDegistir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTarihDegistir.Click
        Dim degerUzunlugu1 = Len(txtLotYeniDegeri1.Text.Trim)
        Dim degerUzunlugu2 = Len(txtLotYeniDegeri2.Text.Trim)
        If degerUzunlugu1 = 10 And degerUzunlugu2 = 10 Then
            If Mid(txtLotYeniDegeri1.Text.Trim, 3, 1) = "/" And Mid(txtLotYeniDegeri1.Text.Trim, 6, 1) = "/" And Mid(txtLotYeniDegeri1.Text.Trim, 1, 2) < 32 And Mid(txtLotYeniDegeri1.Text.Trim, 4, 2) < 13 And Mid(txtLotYeniDegeri2.Text.Trim, 3, 1) = "/" And Mid(txtLotYeniDegeri2.Text.Trim, 6, 1) = "/" And Mid(txtLotYeniDegeri2.Text.Trim, 1, 2) < 32 And Mid(txtLotYeniDegeri2.Text.Trim, 4, 2) < 13 Then
                Dim lotDegisecek
                Dim i
                For i = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                    lotDegisecek = fpEbatMiktar.Sheets(0).Cells(i, 2).Text.Trim
                    If lotDegisecek = txtDegisecekLot.Text Then
                        fpEbatMiktar.Sheets(0).Cells(i, 21).Text = txtLotYeniDegeri1.Text.Trim
                        fpEbatMiktar.Sheets(0).Cells(i, 22).Text = txtLotYeniDegeri2.Text.Trim
                        txtKayitDurumu.Text = "Satırların tarihleri değiştirildi."
                        txtKayitDurumu.BackColor = Drawing.Color.Green
                    End If
                Next
            End If
        Else
            txtKayitDurumu.Text = "Satırlara eklenmek istenen tarih biçimi uyumsuz. Uygun biçim gg/aa/yyyy."
            txtKayitDurumu.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub btnTopMikDegistir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTopMikDegistir.Click
        Dim lotDegisecek
        Dim i

        If txtLotYeniDegeri1.Text.Trim <> "" And txtLotYeniDegeri2.Text.Trim <> "" Then
            For i = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                lotDegisecek = fpEbatMiktar.Sheets(0).Cells(i, 2).Text.Trim
                If lotDegisecek = txtDegisecekLot.Text Then
                    fpEbatMiktar.Sheets(0).Cells(i, 34).Text = txtLotYeniDegeri1.Text.Trim.Replace(",", ".")
                    fpEbatMiktar.Sheets(0).Cells(i, 35).Text = txtLotYeniDegeri2.Text.Trim.Replace(",", ".")
                    txtKayitDurumu.Text = "Satırların Toplam Miktar Toleransları değiştirildi."
                    txtKayitDurumu.BackColor = Drawing.Color.Green
                End If
            Next
        Else
            txtKayitDurumu.Text = "Alanlar boş olmamalıdır."
            txtKayitDurumu.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub btnCapMikDegistir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCapMikDegistir.Click

        Dim lotDegisecek
        Dim i
        If txtLotYeniDegeri1.Text.Trim <> "" And txtLotYeniDegeri2.Text.Trim <> "" Then
            For i = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
                lotDegisecek = fpEbatMiktar.Sheets(0).Cells(i, 2).Text
                If lotDegisecek = txtDegisecekLot.Text Then
                    fpEbatMiktar.Sheets(0).Cells(i, 32).Text = txtLotYeniDegeri1.Text.Trim.Replace(",", ".")
                    fpEbatMiktar.Sheets(0).Cells(i, 33).Text = txtLotYeniDegeri2.Text.Trim.Replace(",", ".")
                    txtKayitDurumu.Text = "Satırların Çap Miktar Toleransları değiştirildi."
                    txtKayitDurumu.BackColor = Drawing.Color.Green
                End If
            Next
        Else
            txtKayitDurumu.Text = "Alanlar boş olmamalıdır."
            txtKayitDurumu.BackColor = Drawing.Color.Red
        End If
    End Sub

    Private Sub UrunAgacıEkle(ByVal Gelen)
        Dim BAK
        Dim DbConn As New ConnectOracleFilmasin
        Dim EKLE = "EVET"

        SQL = " SELECT DISTINCT OZLKOD FROM FILMASIN.KALITESINIF " _
            & " WHERE KALITESINIFI='" & Gelen & "'"
        DbConn.RaporWhile(SQL)
        While DbConn.MyDataReader.Read

            For index As Integer = 0 To UrunAgacListesi.Count - 1
                BAK = UrunAgacListesi(index)
                If BAK = DbConn.MyDataReader.Item("OZLKOD") & "-" & Gelen Then
                    EKLE = "HAYIR"
                    KALITESINIFACK_EKLENECEK = DbConn.MyDataReader.Item("OZLKOD")
                    GoTo SON
                Else
                    EKLE = "EVET"
                End If
            Next

            KALITESINIFACK_EKLENECEK = DbConn.MyDataReader.Item("OZLKOD")

            If EKLE = "EVET" Then
                UrunAgacListesi.Add(DbConn.MyDataReader.Item("OZLKOD") & "-" & Gelen)
            End If



        End While
SON:


        DbConn.Kapat()


        'If PrgKod = "OZLCLK" Then
        '    Dim BAK
        '    For index As Integer = 0 To UrunAgacListesi.Count - 1
        '        BAK = BAK & UrunAgacListesi(index)
        '    Next


        '    raporgrd.Sheets(0).RowCount = 18
        '    raporgrd.Sheets(0).Cells(16, 0).Text = KALITESINIFACK
        '    raporgrd.Sheets(0).Cells(17, 0).Text = "Form No: 05.10.1-2/R-3"

        'Else
        '    raporgrd.Sheets(0).RowCount = 17
        'End If

    End Sub
    Private Sub SipDrm_Getir(ByVal Sipnox, ByVal RevNox)
        Try

            Dim SipNo As String
            Dim RevizNo As Integer
            SipNo = Sipnox
            RevizNo = RevNox

            If SipNo <> "" Then
                SiparisinDurumu = -1
                Dim DbConn As New ConnectGiris
                SQL = " SELECT DURUM,SIPARIS_GRUBU FROM MRKSIP_CBK_FLM" _
                    & " WHERE SIP_NO= '" & SipNo & "'" _
                    & " AND REVIZ_NO= " & RevizNo
                DbConn.RaporWhile(SQL)
                While DbConn.MyDataReader.Read
                    SIPARISIN_GRUBU = DbConn.MyDataReader.Item("SIPARIS_GRUBU")
                End While
                DbConn.Kapat()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub fpEbatMiktarOnay_UpdateCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles fpEbatMiktarOnay.UpdateCommand

    End Sub

    Protected Sub txtMamul_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMamul.TextChanged

    End Sub

    Protected Sub BtnYeni_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnYeni.Load

    End Sub

    Protected Sub fpLotListe_UpdateCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles fpLotListe.UpdateCommand

    End Sub

    Protected Sub txtLotNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLotNo.TextChanged

    End Sub

    Protected Sub txtKutukKalite_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKutukKalite.SelectedIndexChanged

    End Sub

    Sub TEDARIKCI_OZEL()
        Dim KutukTedarikci As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim KutukTedarikciList As New ArrayList
        Dim DbConn As New ConnectOracleFilmasin
        SQL = " SELECT DISTINCT TEDARIKCI FROM FILMASIN.KALITESINIF " _
            & " WHERE MAM_KALITE='" & drpKalite.Text & "'" _
                & " ORDER BY TEDARIKCI "
        DbConn.RaporWhile(SQL)
        drpKutukTedarikci.Items.Clear()
        drpKutukTedarikci.Items.Add("")
        While DbConn.MyDataReader.Read
            drpKutukTedarikci.Items.Add(DbConn.MyDataReader.Item("TEDARIKCI"))
        End While
        DbConn.Kapat()

    End Sub

    Protected Sub drpUrunBilgi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpUrunBilgi.SelectedIndexChanged

    End Sub

    Sub URUNBILGI_OZEL()

        Dim UrunBilgi As String
        Dim cb As New FarPoint.Web.Spread.ComboBoxCellType
        'Dim kalitelist As New System.Web.Form.ComboBox
        Dim UrunBilgiList As New ArrayList
        Dim DbConn As New ConnectOracleFilmasin

        SQL = " SELECT DISTINCT KALITESINIFI FROM FILMASIN.KALITESINIF " _
            & " WHERE MAM_KALITE='" & drpKalite.Text & "'" _
                & " ORDER BY KALITESINIFI "
        DbConn.RaporWhile(SQL)
        drpUrunBilgi.Items.Clear()
        drpUrunBilgi.Items.Add("")
        While DbConn.MyDataReader.Read
            If IsDBNull(DbConn.MyDataReader.Item("KALITESINIFI")) Then

            Else
                drpUrunBilgi.Items.Add(DbConn.MyDataReader.Item("KALITESINIFI"))
            End If
        End While
        DbConn.Kapat()

    End Sub



    Protected Sub BtnSakla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSakla.Click





        'If Session("AktifSiparisDurumu") = "-1" Or Session("AktifSiparisDurumu") = "88" Then
        '    sakla()
        'Else
        '    txtKayitDurumu.Text = "Onaylanan Siparişte kayıt değiştiremezsiniz..!!!"
        '    txtKayitDurumu.BackColor = Drawing.Color.Red
        'End If



        ' ESKISI
        If txtKopyalaBasildimi.Text = "Evet" Then

            Dim dahaOnceKullanildimi As Boolean = False
            Dim DbConnKontrol As New ConnectGiris
            SQL = " SELECT DURUM FROM MRKSIP_CBK_FLM" _
                & " WHERE SIP_NO='" & txtUretimSipNo.Text & "'"

            DbConnKontrol.RaporWhile(SQL)
            While DbConnKontrol.MyDataReader.Read
                dahaOnceKullanildimi = True
            End While
            DbConnKontrol.Kapat()

            If dahaOnceKullanildimi Then
                txtKayitDurumu.Text = "Aynı sipariş numarasıyla daha önce kayıt gerçekleştirilmiş."
                txtKayitDurumu.BackColor = Drawing.Color.Red
            Else
                sakla()
                txtKopyalaBasildimi.Text = "Hayır"
            End If
        Else

            sakla()

        End If



    End Sub

    Protected Sub fpSiparisGetir_UpdateCommand(ByVal sender As Object, ByVal e As FarPoint.Web.Spread.SpreadCommandEventArgs) Handles fpSiparisGetir.UpdateCommand

    End Sub

    Protected Sub SecilenUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecilenUpdate.Click

        Dim satir, bak
        For satir = 0 To fpEbatMiktar.Sheets(0).RowCount - 1
            bak = fpEbatMiktar.Sheets(0).Cells(satir, 37).Value
            If bak = True Or bak = 1 Then
                If DropDownList2.Text = "Mam Kalite" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 5).Text = drpKalite.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 4).Text = drpStandart.Text
                End If

                If DropDownList2.Text = "Ürün Bilgisi" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 18).Text = drpUrunBilgi.Text
                End If

                If DropDownList2.Text = "Ktk Menşei" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 19).Text = drpKutukTedarikci.Text
                End If
                If DropDownList2.Text = "Ktk Kalite" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 20).Text = txtKutukKalite.Text
                End If
                If DropDownList2.Text = "Rotor Tipi" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 17).Text = drpRotorTip.Text
                End If

                If DropDownList2.Text = "Bas.Termin" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 21).Text = dateTerminBas.Text
                End If
                If DropDownList2.Text = "Bit.Termin" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 22).Text = dateTerminBit.Text
                End If
                If DropDownList2.Text = "Paket Agırlık" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 14).Text = txtPaketAgirlik.Text
                End If
                If DropDownList2.Text = "Boyama" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 24).Text = txtBoyama.Text
                End If
                If DropDownList2.Text = "Miktar(Ton)" Then
                    fpEbatMiktar.Sheets(0).Cells(satir, 11).Text = txtMiktar.Text
                    fpEbatMiktar.Sheets(0).Cells(satir, 11).Text = txtMiktar.Text.Replace("'", " ")
                End If


            End If
        Next

    End Sub


    Protected Sub btnNewEntry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewEntry.Click

        ' ASAGIDAKILERIN CALISMASI ICIN FORM LOAD DA 2 SATIRI KOYMALISIN
        'Dim scriptManager As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        'scriptManager.RegisterPostBackControl(Me.btnNewEntry)


        Try
            Dim hedef = "\\192.168.198.8\Upload\"
            Response.Clear()
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & raporgrd.Sheets(0).Cells(12, 1).Text)
            'Response.TransmitFile(hedef & lblEk.Text)
            Response.WriteFile(hedef & raporgrd.Sheets(0).Cells(12, 1).Text)
            Response.End()
        Catch ex As Exception
            Response.Write("ASDASD")
        End Try




    End Sub

    Private Sub SetStream(ByVal stream As Stream)
        Dim bytes() As Byte = New Byte((CType(stream.Length, Integer)) - 1) {}
        stream.Read(bytes, 0, CType(stream.Length, Integer))
        Response.Buffer = True
        Response.Clear()
        Response.AddHeader("content-disposition", ("attachment; filename=" + Server.UrlDecode(Request.QueryString("name"))))
        Response.BinaryWrite(bytes)
        Response.Flush()
    End Sub


    Protected Sub Image_home_Click(sender As Object, e As ImageClickEventArgs) Handles Image_home.Click
        'Response.Redirect("../../LOG.aspx")
        Response.Redirect("../../Login.aspx")

    End Sub
    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged

    End Sub

    Private Sub drpKutukTedarikci_TextChanged(sender As Object, e As EventArgs) Handles drpKutukTedarikci.TextChanged

    End Sub

End Class
Friend Class ConnectGiris

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

Friend Class ConnectOracleFilmasin

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
                & "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.189.191)(PORT=1521)))" _
                & "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=FLMORA)));" _
                & "User Id=FILMASIN;Password=FILMASIN;"
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