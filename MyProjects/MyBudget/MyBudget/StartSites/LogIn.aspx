<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="MyBudget.StartSites.LogIn" %>

<!DOCTYPE htm>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Styles/LogStyle.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainLogContener">
        <div class="logBox box">
            <asp:Label ID="logLabel" Text="Login" runat="server"></asp:Label>
            <asp:TextBox ID="userLogin" runat="server" ></asp:TextBox>
            <asp:Label ID="passwordLabel" Text="Hasło" runat="server"></asp:Label>
            <asp:TextBox ID="userPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Button ID="logButton" runat="server" Text="Zaloguj" OnClick="logButton_Click" />
            <asp:Label ID="msgLabel" runat ="server" Text="" Visible ="false" />
            <asp:CheckBox ID="DebugMode" runat="server" Text="Debug mode" />
         </div>       
    </div>
    </form>
</body>
</html>
