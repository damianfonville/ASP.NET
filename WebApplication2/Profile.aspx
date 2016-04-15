<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication2.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <h1>Profile</h1>
    <hr />

    <hr />
    <h3>Change password</h3>
    <asp:ChangePassword ID="ChangePassword1" runat="server">
        </asp:ChangePassword>
    </form>
</asp:Content>
