<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PathOptions.aspx.cs" Inherits="Courses_PathOptions" %>
<%@ Register TagPrefix="GradPath" TagName="Options" Src="~/Controls/Options.ascx" %>

<asp:Content ID="pathoptions_content" ContentPlaceHolderID="content_master" Runat="Server">

    <!-- TODO: Complete options:
        	§ Degree program (MS CS or MS IS only)
			§ Concentration
			§ Entering quarter
			§ Number of courses per quarter
			§ Delivery choice– online, classroom, both 
			§ AND from the course descriptions and online syllabus info quarter offered (look at last 2 years)
    -->
    
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

</asp:Content>

