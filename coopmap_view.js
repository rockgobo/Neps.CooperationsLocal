function Viewmodel() {
    var self = this;
    self.Institutes = ko.observableArray([]);
    self.Projects = ko.observableArray([]);
    self.ProjectsHeadline = ko.observable("");
    self.Links = ko.observableArray([]);
    self.highlightedInstitutes = ko.observableArray([]);
    self.highlightedLocations = ko.observableArray([]);
    self.highlightedLocation = ko.observable(false);
    self.highlightedProject = ko.observable(false);

    self.showLocation = function (institute) {
        svg.selectAll(".node").style("fill", "");
        svg.selectAll("#node_" + institute.location).style("fill", "#f6a849");
    };
    self.unshowLocations = function () {
        svg.selectAll(".node").style("fill", "");
    };
    self.showProject = function (project) {
        svg.selectAll(".link").style("stroke", "").style("opacity", "").style("stroke-width", 2.0);
        svg.selectAll(".project_" + project.id).style("stroke", "#f6a849").style("opacity", 1.0).style("stroke-width", 4.0);

        self.highlightedLocations.removeAll();
        self.highlightedInstitutes.removeAll();

        self.Links().forEach(function (l) {
            if (l.project == project.id) {
                self.Institutes().forEach(function(p) {
                    if (l.source + 1 == p.id || l.target + 1 == p.id) {
                        self.highlightedLocations.push(p.location);
                        self.highlightedInstitutes.push(p.id);
                        svg.selectAll("#node_" + p.location).style("fill", "#f6a849");
                    }
                });
            }
        });
    };
    self.unshowProject = function () {
        svg.selectAll(".node").style("fill", "");
        svg.selectAll(".link").style("stroke", "").style("opacity", "").style("stroke-width", 2.0);
        self.highlightedLocations.removeAll();
        self.highlightedInstitutes.removeAll();
    };
};

var model = new Viewmodel();

//dimensions
var width = 550;
var height = 800;

var colors = d3.scale.category20();

var svg = d3.select("#chart").append("svg")
    .attr("width", width)
    .attr("height", height);

var projection = d3.geo.albers()
    .center([14.7, 50.5])
    .rotate([4.4, 0])
    //.parallels([50, 60])
    .scale(5000)
    .translate([width / 2, height / 2]);


d3.json(controlPath+"data/germany_1.js", function (json) {
    var path = d3.geo.path()
        .projection(projection);

    var regions = svg.append("g")
        .attr("class", "region")
        .selectAll("path")
        .data(json.features)
        .enter()
        .append("path")
        .attr("class", function (d) { return "subunit " + d.properties.HASC_1.replace(".", "_"); })
        .attr("d", path);


    d3.json(controlPath + "data/network." + language + ".js", function (graph) {

        //LINKS
        graph.nodes.map(function (l, i, nodes) {
            var pro = projection([l.lon, l.lat]);
            l.x = pro[0];
            l.y = pro[1];
            return l;
        });

        graph.nodes.getLocationById = function (id) {
            var i = 0;
            for (i = 0; i < this.length; ++i) {
                if (id + 1 == this[i].id) {
                    return this[i];
                }
            }
        };
        var link = svg.selectAll(".link")
                .data(graph.links)
                .enter().append("line")
                .attr("class", function (d) { return "link project_" + d.project; })
                //.style("stroke-width", function (d) { return Math.sqrt(d.value + 2); })
                .style("stroke-width", 2 )
                .attr("x1", function (d) { return graph.nodes.getLocationById(d.source).x; })
                .attr("y1", function (d) { return graph.nodes.getLocationById(d.source).y; })
                .attr("x2", function (d) { return graph.nodes.getLocationById(d.target).x; })
                .attr("y2", function (d) { return graph.nodes.getLocationById(d.target).y; });

        //Locations
        var locations = svg.selectAll(".locations")
            .data(graph.locations)
            .enter().append("circle")
            .attr("class", "node")
            .attr("id", function (d) { return "node_" + d.id; })
            .attr("title", function (d) { return d.name; })
            .attr("r", 8)
            .attr("cx", function (d) { return projection([d.lon, d.lat])[0]; })
            .attr("cy", function (d) { return projection([d.lon, d.lat])[1]; })
            .on("mouseover", function (d) {
                model.highlightedLocation(d.id);
            })
            .on("mouseout", function (d) {
                model.highlightedLocation(false);
            });

        model.Institutes(graph.nodes);
        model.Projects(graph.projects);
        model.Links(graph.links);
        model.ProjectsHeadline(graph.headline);

        svg.selectAll(".place-label")
            .data(graph.locations).enter().append("text").attr("class", "place-label")
            .attr("transform", function (d) { return "translate(" + projection([d.lon, d.lat]) + ")"; })
            .attr("dy", ".35em")
            .text(function (d) { return d.name; });

        var labelDistance = 12;
        svg.selectAll(".place-label")
            .attr("x", function (d) { return d.lon > 10 ? labelDistance : -1 * labelDistance; })
            .style("text-anchor", function (d) { return d.lon > 10 ? "start" : "end"; });


        


    });
});



ko.applyBindings(model);