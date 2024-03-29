@Imports System.Web.Http
@Imports System.Web.Http.Controllers
@Imports System.Web.Http.Description
@Imports System.Collections.ObjectModel
@Imports DadJokes.Areas.HelpPage
@ModelType Collection(Of ApiDescription)

@Code
    ViewData("Title") = "DadJoke Web API Help Page"

    ' Group APIs by controller
    Dim apiGroups As ILookup(Of HttpControllerDescriptor, ApiDescription) = Model.ToLookup(Function(api) api.ActionDescriptor.ControllerDescriptor)
End Code

<link type="text/css" href="~/Areas/HelpPage/HelpPage.css" rel="stylesheet" />
<header class="help-page">
    <div class="content-wrapper">
        <div class="float-left">
            <h1>@ViewData("Title")</h1>
        </div>
    </div>
</header>
<div id="body" class="help-page">
    <section class="featured">
        <div class="content-wrapper">
            <h2>Introduction</h2>
            <p>
                We know no one will read these.
            </p>
        </div>
    </section>
    <section class="content-wrapper main-content clear-fix">
        @For Each group As IGrouping(Of HttpControllerDescriptor, ApiDescription) In apiGroups
            @Html.DisplayFor(Function(m) group, "ApiGroup")
        Next
    </section>
</div>
