<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Options.ascx.cs" Inherits="Controls_Options" %>

<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title">Set options and filters</h3>
    </div>
    <div class="panel-body">
        <div class="form-group">
            <label>
                College selection dropdown?
            </label>
            <select class="form-control">
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
            </select>
        </div>

        <!-- TODO Enable when college is selected. -->
        <div class="form-group">
            <label>
                Degree selection dropdown?
            </label>
            <select class="form-control" disabled>
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
            </select>
        </div>
                        
        <div class="form-group">
            <label>
                Concentration options?
            </label>
            <div class="checkbox">
                <label>
                    <input type="checkbox" value="">
                    Option one is this and that&mdash;be sure to include why it's great
                </label>
            </div>
            <div class="checkbox disabled">
                <label>
                    <input type="checkbox" value="" disabled>
                    Option two is disabled
                </label>
            </div>
        </div>
                        
        <div class="form-group">
            <label>
                Elective options?
            </label>
            <div class="radio">
                <label>
                    <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked>
                    Option one is this and that&mdash;be sure to include why it's great
                </label>
            </div>
            <div class="radio">
                <label>
                    <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
                    Option two can be something else and selecting it will deselect option one
                </label>
            </div>
            <div class="radio disabled">
                <label>
                    <input type="radio" name="optionsRadios" id="optionsRadios3" value="option3" disabled>
                    Option three is disabled
                </label>
            </div>
        </div>

        <!-- TODO Display callouts where necessary. -->
        <div class="bs-callout bs-callout-warning">
            <h4>Important note</h4>
            <p>Because you selected <code>this option</code>, your outcome may be...</p>
        </div>

        <!-- TODO: Update progress bar when required step is completed. -->
        <div class="row grad-progress">
            <div class="col-sm-10">
                <div class="progress">
                    <div class="progress-bar progress-bar-striped" role="progressbar"
                        aria-valuenow="60"
                        aria-valuemin="0"
                        aria-valuemax="100"
                        style="width: 60%">
                        <span class="sr-only">60% Complete</span>
                    </div>
                </div>
            </div>
            <div class="col-sm-2">
                <span class="badge">6 / 10 Steps complete.</span>
            </div>
        </div>

        <!-- TODO: If required steps are complete, enable button. -->
        <button id="btnSubmit" runat="server" class="btn btn-default" 
            onserverclick="btnSubmit_Click">Get my path!</button>

    </div>
</div>