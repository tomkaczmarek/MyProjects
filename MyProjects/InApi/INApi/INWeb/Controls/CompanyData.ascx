<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyData.ascx.cs" Inherits="INWeb.Controls.CompanyData" %>

<div class="container">    
    <div class="form-group">
        <asp:Label id="label1" class="col-sm-8 control-label" runat="server" Text="Wprowadź numer" Font-Size="Medium" Font-Bold="true" />
        <div class="col-sm-10">
            <asp:TextBox ID="Number" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-10">
            <asp:Button ID="CompanyButton" Text="Pobierz dane" OnClick="GetData_Click" runat="server" CssClass="btn btn-default" />
            <asp:Label ID="ErrorMessage" runat="server" Visible="true" Font-Size="Small" ForeColor="Red"></asp:Label>
        </div>      
    </div>
        <div ID="MainFieldContent">
            <div class="form-group">
                <asp:Label class="col-sm-8 control-label" runat="server" Font-Size="Small">Nazwa </asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="Name" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
             <div class="form-group">
                 <asp:Label runat="server" class="col-sm-8 control-label" Font-Size="Small">Ulica </asp:Label>
                 <div class="col-sm-10">
                     <asp:TextBox ID="Street" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                 </div>
             </div>
            <div class="form-group">
                <asp:Label runat="server" class="col-sm-8 control-label" Font-Size="Small">Nr. </asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="Street_number" runat="server" CssClass="form-control" Width="50" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" class="col-sm-8 control-label" Font-Size="Small">Kod pocztowy </asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="PostCode" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" class="col-sm-8 control-label" Font-Size="Small">Miasto </asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="City" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>              
</div>

