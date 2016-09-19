<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="GradPath" TagName="Options" Src="~/Controls/Options.ascx" %>
<%@ Register TagPrefix="GradPath" TagName="CourseList" Src="~/Controls/CourseList.ascx" %>

<asp:Content ID="content_default" ContentPlaceHolderID="content_master" Runat="Server">

    <div class="container" role="main">

        <!-- TODO: Move 'Graduation Path' to separate file. -->
        <div class="page-header">
            <h1>Graduation Path</h1>
        </div>

        <div class="alert alert-info" role="alert">
            <strong>Heads up!</strong>
            This tool will help you find the fastest graduation path at DePaul.
            Start by making selections below!
        </div>

        <div class="row">
            <div class="col-sm-12">
                <GradPath:Options id="default_options" runat="server" />
            </div>
        </div>

        <GradPath:CourseList id="default_courses" runat="server" />

    </div>

</asp:Content>

