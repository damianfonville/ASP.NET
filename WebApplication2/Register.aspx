<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication2.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
        ContinueDestinationPageUrl="~/Default.aspx" >
        <CreateUserButtonStyle CssClass="btn btn-primary" />
        <LabelStyle HorizontalAlign="Left" Wrap="False" />
        <TextBoxStyle CssClass="form-control" />
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
        <FinishPreviousButtonStyle CssClass="btn btn-primary" />
        
    </asp:CreateUserWizard>
    </form>
</asp:Content>
