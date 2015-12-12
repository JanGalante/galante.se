//$(document).ready(function(){
//    CreatePointsChart();
//});


//$(function () {
function CreatePointsChart()
{
    //variabler
    var dDaniel =  [[0,0], [1,6], [2,12], [3,14], [4,19], [5,21], [6,23], [7,27], [8,33], [9,34], 
                    [10,37], [11,42], [12,43], [13,46], [14,48], [15,53], [16,56], [17,64], [18,64], 
                   [19,64], [20,64], [21,80], [22,80], [23,80]];
    var dDenise =  [[0,0], [1,5], [2,12], [3,13], [4,19], [5,22], [6,22], [7,24], [8,28], [9,28],
                    [10,31], [11,35], [12,37], [13,40], [14,41], [15,42], [16,45], [17,53], [18,53],
                    [19,53], [20,61], [21,77], [22,93], [23,125]];
    var dGustav =  [[0,0], [1,3], [2,10], [3,11], [4,18], [5,21], [6,22], [7,23], [8,28], [9,28],
                    [10,30], [11,34], [12,37], [13,38], [14,39], [15,42], [16,45], [17,53], [18,53],
                    [19,53], [20,61], [21,77], [22,93], [23,125]];
    var dJanne =   [[0,0], [1,4], [2,12], [3,13], [4,18], [5,20], [6,21], [7,21], [8,27], [9,27],
                    [10,35], [11,41], [12,44], [13,47], [14,49], [15,50], [16,53], [17,61], [18,61],
                    [19,61], [20,69], [21,85], [22,101], [23,133]];
    var dRickard = [[0,0], [1,3], [2,13], [3,14], [4,20], [5,27], [6,32], [7,40], [8,43], [9,43],
                    [10,47], [11,50], [12,53], [13,58], [14,59], [15,62], [16,65], [17,73], [18,73],
                    [19,73], [20,81], [21,81], [22,81], [23,81]];

    //var plot = $.plot(placeholder, data, options)
    //$.plot($("#pointChart"), [dDaniel, dDenise, dGustav, dJanne, dRickard]);
    $.plot($("#pointChart"), [
            {label: "Daniel", data: dDaniel}, 
            {label: "Denise", data: dDenise, lines:{lineWidth: 4}}, 
            {label: "Gustav", data: dGustav}, 
            {label: "Janne", data: dJanne, lines:{fill: false, show: false}, bars: {show: false} }, //color: "rgb(255, 255, 203)"
            {label: "Rickard", data: dRickard, lines:{fill: false}}
        ],
        {grid: {color: "#D3D3D3", borderWidth: 0.5, tickColor: "#111111", hoverable: true},
         legend: {position: "nw"}
        }
    );
}

function CreateIndoorChart(dDaniel, dGustav, d3, d4, d5, d6, d7, d8)
{
    //alert('sdf');
    $.plot($("#emChart"), [
            {label: "Daniel", data: dDaniel}, 
            {label: "Gustav", data: dGustav},
            {label: "D3", data: d3},
            {label: "D4", data: d4},
            {label: "D5", data: d5},
            {label: "D6", data: d6},
            {label: "D7", data: d7},
            {label: "D8", data: d8}
        ],
        {grid: {color: "#D3D3D3", borderWidth: 0.5, tickColor: "#111111", hoverable: true},
         legend: {position: "nw"}
        }
    );
    
}