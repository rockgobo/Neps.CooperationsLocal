var width = 800, height = 600;

var color = //d3.scale.category20();
    function (group) {
        switch (group) {
            case 0:
                return "#FE9A2E";
            case 1:
                return "#084B8A";
            default:
                return "#A9D0F5";
        }
    }

var force = d3.layout.force()
    .linkDistance(80)
    .linkStrength(0.05)
    .friction(0.9)
    .distance(100)
    .charge(-200)
    .gravity(0.05)
    .theta(0.8)
    .alpha(0.1)
    .size([width, height]);

var svg = d3.select("#container_logos").append("svg")
    .attr("width", width)
    .attr("height", height);

var startForce, startGeo;



d3.json("data/links.json", function (error, graph) {
    if (error) {
        log(error);
    }

    graph.nodes.map(function(d) {
        if (d.group == 0) {
            d.x = width / 2;
            d.y = height / 2;
            d.fixed = true;
        }
    });

    force
        .links(graph.links)
        .nodes(graph.nodes)
        .start();

    var link = svg.selectAll(".link")
        .data(graph.links)
        .enter().append("line")
        .attr("class", "link")
        .style("stroke-width", function (d) { return Math.sqrt(d.value + 2); });

    var node = svg.selectAll(".node")
        .data(graph.nodes)
        .enter().append("g")
        .attr("class", "node")
        .attr("id", function (d) { return "node_" + d.id; })
        //.style("fill", function (d) { return color(d.group); })
        .on("mouseover", function (d) {
            //log(d.id + " mouseover");
            svg.selectAll("#node_" + d.id).style("fill", "#F00");
            svg.selectAll("#nodelink_" + d.id).style("fill", "#F00");
        })
        .on("mouseout", function (d) {
            //log(d.id + " mouseover");
            svg.selectAll("#node_" + d.id).style("fill", color(d.group));
            svg.selectAll("#nodelink_" + d.id).style("fill", color(d.group));
        })
        .call(force.drag);

    node.append("circle")
        .attr("class", "node")
        .attr("r", function (d) { return d.logo ? 15 : 5; })
        .style("fill", function (d) { return d.logo? "#FFF" : color(d.group); });

    //Icons - Logos
    node.append("image")
        .attr("xlink:href", function (d) {
            return d.logo ?
            "images/" + d.logo :
            "";
        })
        .attr("x", -32)
        .attr("y", -32)
        .attr("width", 120)
        .attr("height", 64);

    node.append("text")
      .attr("dx", 12)
      .attr("dy", ".35em")
      .text(function (d) { return d.name; });

    node.append("title")
        .text(function (d) { return d.name; });

    force.on("tick", function () {

        link.attr("x1", function (d) { return d.source.x; })
            .attr("y1", function (d) { return d.source.y; })
            .attr("x2", function (d) { return d.target.x; })
            .attr("y2", function (d) { return d.target.y; });
            
            
        node.attr("cx", function (d) { return d.x; })
            .attr("cy", function (d) { return d.y; });
        node.attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; });
            
    });

    force.start();
   
});
