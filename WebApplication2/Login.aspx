<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Login ID="LoginForm" runat="server" EnableTheming="False" 
        TextLayout="TextOnTop" Width="100%">
        <LabelStyle HorizontalAlign="Left" />
        <LoginButtonStyle  CssClass="btn btn-primary" />
        <TextBoxStyle CssClass="form-control" />
        <ValidatorTextStyle ForeColor="White" />
    </asp:Login>
</form>
</asp:Content>
