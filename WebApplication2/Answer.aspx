<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Answer.aspx.cs" Inherits="WebApplication2.Answer" %>
<%@ PreviousPageType VirtualPath="~/questions.aspx" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
    <div class="panel panel-default">
		<div class="panel-heading clearfix">
			<h4 class="panel-title pull-left" style="padding-top: 7.5px;">Answer</h4>
		</div><div class="panel-body">
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:LinkButton ID="LinkButton1" OnClick="submitanswer" runat="server" CssClass="btn btn-primary">Answer</asp:LinkButton>
		</div>
	</div>
    </asp:Panel>
    </form>
</asp:Content>
