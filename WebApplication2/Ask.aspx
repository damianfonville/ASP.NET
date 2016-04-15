<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ask.aspx.cs" Inherits="WebApplication2.Ask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
    <h1>Ask a question</h1>
    <asp:Panel ID="Panel3" CssClass="alert alert-success" runat="server" 
        Visible="False">
          <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
  <span class="sr-only">Well done:</span>
  Thank you for your question!
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" CssClass="alert alert-danger" 
        role="alert" Visible="False">
      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
  <span class="sr-only">Error:</span>
  Please fill in the form right  </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
    
    <asp:TextBox ID="tbTitle" placeholder="Title" runat="server" CssClass="form-control"></asp:TextBox>

    &nbsp;<asp:TextBox ID="tbQuestion" TextMode="multiline" Columns="50" Rows="5" 
        runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
    </asp:DropDownList>
    <br />
<asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" 
    Text="Ask!" onclick="Button1_Click" />
    </asp:Panel>
</form>
</asp:Content>
