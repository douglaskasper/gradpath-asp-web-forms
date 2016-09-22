<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CourseList.ascx.cs" Inherits="Controls_CourseList" %>

<div class="well">

    <h5>Example database retrieval, courses.</h5>

    <asp:Repeater ID="repeater_courses" runat="server">
        <HeaderTemplate>
            <table class="table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Department</th>
                        <th>People Soft Number</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Units</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Id") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Department.Code") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "PeopleSoftNumber") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Title") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Description") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Units") %>
                    </td>
                </tr>                     
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</div>