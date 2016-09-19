<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<asp:Content ID="content_default" ContentPlaceHolderID="content_master" Runat="Server">

    <div class="container" role="main">

        <!-- TODO: Move 'Graduation Path' to separate file. -->
        <div class="page-header">
            <h1>Oops! Something went wrong.</h1>
        </div>

        <div class="alert alert-danger" role="alert">
            <p><strong>Sorry! :(</strong></p>
            <p>Click <a href="/Default.aspx">here</a> to go back to the homepage.</p>
        </div>

    </div>

</asp:Content>
