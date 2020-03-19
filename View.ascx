<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Neps.Cooperations.View" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" FilePath="~/DesktopModules/Neps.Cooperations/css/bootstrap_rows.css" />
<dnn:DnnCssInclude runat="server" FilePath="~/DesktopModules/Neps.Cooperations/css/map.css" />


<script src="<%=SelfPath%>/js/modernizr.custom.51966.js"></script>


<div class="map container">
	<div data-bind="foreach: Institutes" class="institutes">
        <a data-bind="attr: { href: url, target: '_blank' },
                      event: { mouseover: $root.showLocation, mouseout: $root.unshowLocations }">
            <img data-bind="attr: { src: controlPath + 'images/' + logo, title: name },
                        css: { highlight: $root.highlightedLocation() == location || $root.highlightedInstitutes.indexOf(id) > -1 },
                        style: { display: logo ? '' : 'none' }" class="logo" />
        </a>
    </div>
</div>
<div class="map container">
<div class="row">
    <div id="chart" class="col-md-6"></div>
    <div class="col-md-6 projects">
        <h3 data-bind="text: ProjectsHeadline"></h3>
        <ul data-bind="foreach: Projects">
            <a data-bind="attr: { href: url ? url : '#', target: url ? '_blank' : '' },
                                css: { highlight: $root.highlightedProject() == id },
                                event: { mouseover: $root.showProject, mouseout: $root.unshowProject }">
                <li data-bind="text: name"></li>
            </a>
        </ul>
    </div>
</div>
</div>      

<!-- TEST IF SVG IS AVAILABLE -->
<script>
    var controlPath = "<%=SelfPath%>";
    var language = "<%=Language%>";

    Modernizr.load({
        test: Modernizr.svg && Modernizr.inlinesvg,
        yep: ['<%=SelfPath%>/coopmap_view.js']

    });
</script>

