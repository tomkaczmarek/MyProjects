<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="MyBudget.Controls.Header" %>
<link rel="stylesheet" href="../Styles/Style.css" type="text/css" />

<div class="headMenuControlClass">
    <ul class="ulPointer" style="display:inline">
        <li>           
             <asp:Label ID="logLabel" Text="Zalogowany jako: " runat="server"></asp:Label>
             <asp:Label ID="userLogin" Text="Login użytkownika" runat="server"></asp:Label>           
        </li>
        <li>
             <asp:LinkButton ID="LinkButton" text="Wyloguj"  OnClick="logOut_Click" runat="server"></asp:LinkButton>
        </li>

    </ul>
</div>