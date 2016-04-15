<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="WebApplication2.Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<ul  class="nav nav-pills">
<% foreach(string tag in tags) {

           if (tag == Request.QueryString["tag"])
           {
           %>
           <li class="active"><a href="Questions.aspx?tag=<%=tag %>"><%=tag %></a></li>
           <%
           
       }else{
       %>
<li><a href="Questions.aspx?tag=<%=tag %>"><%=tag %></a></li>
<% }
   } %>
</ul>
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    </form>
</asp:Content>
