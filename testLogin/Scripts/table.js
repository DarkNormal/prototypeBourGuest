/* enable strict mode */
"use strict";

function deleteTable() {
    $(document).ready(function () {
        $("#table2").remove();  //deletes table if it exists
        $("#message").empty();  //clears message div text

    });
}
var showContent,
    getContent,
    redipsInit,
    width,
    height,
    pName;

function enableDrag() {
    deleteTable();                                              //calls delete function
    var size = document.getElementById("floorsize");
    var floorsize = size.options[size.selectedIndex].value;     //gets floorsize from selected drop down menu
    var table = document.createElement('TABLE');                //create floorplan table
    table.id = 'table2';                                        //assigns table2 as ID for table
    var cgroup = document.createElement('COLGROUP');
    var tablebod = document.createElement('TBODY');
    cgroup.width = '200';
    table.appendChild(tablebod);
    if (floorsize == "Pick restaurant size") {                  //checks if size has been selected
        alert("Pick a value from the dropdown list");           //alert to inform user a choice must be made
    }
    else {
        alert("JS create plan enabled")
        var tabHeight,
            tabWidth;
        if (floorsize == "small") {         //small floorplan size
            width = 5;
            height = 5;

        }
        else{                               //medium floorplan size
            width = 10;
            height = 10;
        }

        for (var i = 0; i < width; i++) {               //creation of rows and columns,uses for loops to loop through based on specified size
            var tr = document.createElement('TR');
            tablebod.appendChild(tr);

            for (var j = 0; j < height; j++) {
                var td = document.createElement('TD');
                td.id = 'td' + i + j;
                td.width = '100';           //set width and height of each cell
                td.height = '25';
                tr.appendChild(td);         //add td to tr, which is part of table
            }
        }
        right.appendChild(table);
        REDIPS.drag.initTables();
        REDIPS.drag.dropMode = "single";


    }

}
// get content (DIV elements in TD)
getContent = function (id) {
    var td = document.getElementById(id),
		content = '',
		cn, i;
    // TD can contain many DIV elements
    for (i = 0; i < td.childNodes.length; i++) {
        // set reference to the child node
        cn = td.childNodes[i];
        // childNode should be DIV with containing "drag" class name
        if (cn.nodeName === 'DIV' && cn.className.indexOf('drag') > -1) { // and yes, it should be uppercase
            // append DIV id to the result string
            content += cn.id + '_';
        }
    }
    // cut last '_' from string
    content = content.substring(0, content.length - 1);
    // return result
    return content;

};


function saveLayout() {
    $("#message").empty(); //clears the message div text
    var table = document.getElementById("table2");              //gets table floorplan
    var message = document.getElementById("message");
    var counter = 0;
    var $objArray = [];     //floorplan object array
    var objType;            //identifies type of object

    var active = $("#active").is(":checked");
    pName = document.getElementById("planName").value;

    if (document.getElementById("table2")) {
        if (pName == "") {
            Log("Floorplan name must be entered");
        }
        else{

            var objCreate = function (tableObjectID, xcoord, ycoord, objType, available) {
                this.tableObjectID = tableObjectID;
                this.xcoord = xcoord;
                this.ycoord = ycoord;
                this.objType = objType;
                this.available = available;
            }
            for (var i = 0; i < table.rows.length; i++) {           //iterate through rows
                var row = table.rows[i];                            //rows would be accessed using the "row" variable assigned in the for loop 
                for (var j = 0, col; col = row.cells[j]; j++) {     //iterates through coloumns
                    var tdContent = getContent('td' + i + j);       //gets the type of object(s) within the current td

                    if (tdContent != "") {                          //checks if td is empty
                        counter++;                                  //counter for numObjects
                        //counter = counter + (str.split('_').length - 1);    //if multiple elements are allowed in each cell use this
                        if (tdContent.indexOf("fourRnd") > -1) {
                            objType = 4;                            //regular round table, capacity is 4, type is 4 (4 - 0 = 4, capacity)
                        }
                        else if (tdContent.indexOf("fourRoundRot") > -1) {
                            objType = 14;                           //rotated round table, capaicty is 4, type is 14 (14-10 = 4, capacity)
                        }
                        else if (tdContent.indexOf("fourSqt") > -1) {
                            objType = 24;                           //regular square table, capacity is 4, type is 24 (24-20 = 4, capacity)
                        }
                        else if (tdContent.indexOf("fourSquareRot") > -1) {
                            objType = 34;                           //rotated square table, capacity is 4, type is 34 (34-30 = 4, capacity)
                        }
                        else if (tdContent.indexOf("sixSqt") > -1) {
                            objType = 6;                            //regular square table, capacity is 6, type is 6 (6-0 = 6, capacity)
                        }
                        else if (tdContent.indexOf("sixSquareRot") > -1) {
                            objType = 16;                           //rotated square table, capacity is 6, type is 16 (16-10 = 6, capacity)
                        }
                        else if (tdContent.indexOf("twoSqt") > -1) {
                            objType = 2;                            //regular square table, capacity is 2, type is 2 (2-0 = 2, capacity)
                        }
                        else if (tdContent.indexOf("twoSquareRot") > -1) {
                            objType = 12;                           //rotated square table, capacity is 2, type is 12 (12-10 = 2, capacity)
                        }
                        else if (tdContent.indexOf("twoRnd") > -1) {
                            objType = 22;                           //regular round table, capacity is 2, type is 22 (22-20 = 2, capacity)
                        }
                        else if(tdContent.indexOf("twoRoundRot") > -1){
                            objType = 32;                           //rotated round table, capacity is 2, type is 32 (32-30 = 2, capacity)
                        }
                        //object types go up in 10s, so in application:
                        // if(objType > 30){ capacity = objtype - 30;} to get max number of people able to fit.
                        //objtype should be left as 4, 14,24 etc to identify what type of image resource to add to floorplan

                        $objArray.push(new objCreate("001", j, i, objType, "true"));
                    }
                    //sets message div text to include any objects added to the table
                    //message.innerHTML = message.innerHTML + '<br />' + j + "," + i + " " + tdContent;
                    //use the above line for testing purposes, prints all objects to message div on page
                }
            }

            var $floorplan = {      //floorplan object to be inserted
                height: height,
                width: width,
                numObjects: counter,
                planName: pName,
                active: active
            };
            if ($objArray.length > 0) {
                $.ajax({
                    url: "/Floorplans/Create",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify($floorplan),
                    success: function (result) {
                        if (result.success) {           //if it was successful, then do the table objects too
                            Log("Floor plan created successfully, adding plan objects...");
                            $.ajax({
                                url: "/tableObjects/Create",
                                type: "POST",
                                contentType: "application/json",
                                data: JSON.stringify($objArray),
                                success: function (result2) {
                                    if (result2.success) {
                                        Log("Plan objects created successfully");
                                    } else {
                                        Log("Failed to create plan objects");
                                    }
                                }

                            });
                        }

                    }

                });
            }
            else {
                Log("Empty floorplan detected");
            }

        }
    }
    else {
        Log("You need to create a floorplan first")
    }
    //window.location.href = '/Floorplans/Index/';
}
function Log(data) { //alerts and logs information for testing purposes
    alert(data);
    console.log(data);
}