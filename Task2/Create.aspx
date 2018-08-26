<%@ Page Title="Student" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Task2.Create" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <Label>Name:</Label>
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
       <Label>Surname:</Label>
        <asp:TextBox ID="surname" runat="server"></asp:TextBox>
        <Label>Date Of Birth:</Label>
        <asp:Calendar ID="dob" runat="server"></asp:Calendar>
        <Label>Age:</Label>
        <asp:TextBox ID="age" runat="server"></asp:TextBox>
        <Label>Is Full Time?:</Label>
        <asp:CheckBox ID="fulltime" runat="server" />
        <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" />
    </div>
</asp:Content>
