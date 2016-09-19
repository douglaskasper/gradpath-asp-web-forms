<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Path.aspx.cs" Inherits="Path" %>
<%@ Register TagPrefix="GradPath" TagName="CourseList" Src="~/Controls/CourseList.ascx" %>

<asp:Content ID="content_path" ContentPlaceHolderID="content_master" Runat="Server">
    
    <!-- TODO: Complete path algorithm:
            § Plot optimum shortest path to graduation based on degree, prereqs, quarters classes are offered
			§ If multiple possible courses choices at any point (e.g. choose 1 of the following electives – list them)
			§ If no possible course for a quarter (e.g. 2 course per quarter choice and critical path prereq constraint allows only 1 course Then list the course and flag that student can see advisor for permission.)
			§ SAVE path generated
    -->

    <div class="container" role="main">
        
        <div class="page-header">
            <h1>Graduation Path</h1>
        </div>

        <!-- TODO: If multiple choices in quarters, notify to make selection. -->
        <div class="alert alert-warning" role="alert">
            <strong>Almost there!</strong>
            There are some quarters that need your input! Select a course where there are multiple possibilities.
        </div>

        <GradPath:CourseList id="default_courses" runat="server" />
        
        
        <p>
            <button id="btnGoBackBottom" runat="server" class="btn btn-default" 
                onserverclick="btnGoBack_Click">Go back to options</button>
        </p>
        
    </div>

</asp:Content>
