<%@ Page Culture="fr-FR" Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Answers.aspx.cs" Inherits="WebApplication2.admin.Answers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:connectionstring %>" 
    SelectCommand="SELECT * FROM [answers]" 
        DeleteCommand="DELETE FROM [answers] WHERE [answerid] = @answerid" 
        InsertCommand="INSERT INTO [answers] ([text], [userid], [date], [questionid]) VALUES (@text, @userid, @date, @questionid)" 
        UpdateCommand="UPDATE [answers] SET [text] = @text, [userid] = @userid, [date] = @date, [questionid] = @questionid WHERE [answerid] = @answerid">
        <DeleteParameters>
            <asp:Parameter Name="answerid" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="text" Type="String" />
            <asp:Parameter Name="userid" Type="String" />
            <asp:Parameter DbType="Date" Name="date" />
            <asp:Parameter Name="questionid" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="text" Type="String" />
            <asp:Parameter Name="userid" Type="String" />
            <asp:Parameter DbType="Date" Name="date" />
            <asp:Parameter Name="questionid" Type="Int32" />
            <asp:Parameter Name="answerid" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CssClass="table table-hover" 
        DataKeyNames="answerid" DataSourceID="SqlDataSource1" GridLines="None">
        <Columns>
            <asp:BoundField DataField="answerid" HeaderText="answerid" 
                InsertVisible="False" ReadOnly="True" SortExpression="answerid" />
            <asp:BoundField DataField="text" HeaderText="text" SortExpression="text" />
            <asp:BoundField DataField="userid" HeaderText="userid" 
                SortExpression="userid" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            <asp:BoundField DataField="questionid" HeaderText="questionid" 
                SortExpression="questionid" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

</asp:Content>
