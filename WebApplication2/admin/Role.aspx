<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="WebApplication2.admin.Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ASPNETDB.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT aspnet_Users.UserName, aspnet_Roles.RoleName FROM aspnet_Users INNER JOIN aspnet_UsersInRoles ON aspnet_Users.UserId = aspnet_UsersInRoles.UserId INNER JOIN aspnet_Roles ON aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover"
        DataSourceID="SqlDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" GridLines="None">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />
            <asp:BoundField DataField="RoleName" HeaderText="RoleName" 
                SortExpression="RoleName" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <hr />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
    <table class="table">
    <tr>
    <td><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
    <td>     <asp:DropDownList
            ID="DropDownList1" runat="server">
        </asp:DropDownList></td>
    <td><asp:Button ID="Button1" runat="server" Text="set role" 
            onclick="Button1_Click" /></td>
   
        </tr>
        </table>
    </asp:Panel>
</asp:Content>
