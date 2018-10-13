<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="diler.Web.Hata" %>

<!DOCTYPE html>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ERROR</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Hata.gif"
            
            Style="left: 536px; position: absolute; top: 176px; height: 231px; width: 236px;" />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Height="32px"
            Text="Sistem teknik bir hata ile karşılaştı.Lütfen bilgi işlem bölümü ile irtibata geçiniz."
            Width="976px"></asp:Label>
   <%--     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx" Style="left: 112px;
            position: absolute; top: 208px">Şifremi Yanlış Girdim Tekrar Giriş Sayfasına Dön</asp:HyperLink>--%>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/HataGif.gif" Style="left: 72px;
            position: absolute; top: 200px" />
    
    </div>
    </form>
</body>
    
</html>
