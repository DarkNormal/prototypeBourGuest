/* enable strict mode */
"use strict";


function deleteTable() {
    $(document).ready(function () {
        $("#table2").remove();

    });
}
var showContent,
    getContent,
    redipsInit;

function enableDrag() {
    deleteTable();
    var size = document.getElementById("floorsize");
    var floorsize = size.options[size.selectedIndex].value;
    var table = document.createElement('TABLE');
    table.id = 'table2';
    var cgroup = document.createElement('COLGROUP');
    var tablebod = document.createElement('TBODY');
    cgroup.width = '100';
    table.appendChild(tablebod);
    if (floorsize == "Pick restaurant size") {
        alert("Pick a value from the dropdown list");
    }
    else {

        var width;
        var height;
        var tabHeight, tabWidth;
        if (floorsize == "small") {
            width = 5;
            height = 5;

        }
        else if (floorsize == "medium") {
            width = 10;
            height = 10;
        }
        else if (floorsize == "large") {
            width = 20;
            height = 20;
        }
        else {
            alert("oh dear, please dont pick XL again, I'm fragile");
            width = 35;
            height = 35;
        }
        tabHeight = document.getElementById("tableHeight");
        tabHeight.value = height;
        tabWidth = document.getElementById("tableWidth");
        tabWidth.value = width;

        for (var i = 0; i < width; i++) {
            var tr = document.createElement('TR');
            tablebod.appendChild(tr);

            for (var j = 0; j < height; j++) {
                var td = document.createElement('TD');
                td.id = 'td' + i + j;
                td.width = '100';
                td.height = '50';
                tr.appendChild(td);
            }
        }
        right.appendChild(table);
        REDIPS.drag.initTables();
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
    $("#message").empty();
    var table = document.getElementById("table2");
    var message = document.getElementById("message");

    for (var i = 0; i < table.rows.length; i++) {
        var row = table.rows[i];
        //iterate through rows
        //rows would be accessed using the "row" variable assigned in the for loop
        for (var j = 0, col; col = row.cells[j]; j++) {
            var tdContent = getContent('td' + i + j);
            if (tdContent != "") {
                var content = tdContent + '_c' + (j + 1) + '_r' + (i + 1);
                message.innerHTML = message.innerHTML + '<br />' + tdContent + '_c' + (j + 1) + '_r' + (i + 1);
                var tabObj = document.getElementById("tableObjects");
                tabObj.value = content;
            }
            //iterate through columns
            //columns would be accessed using the "col" variable assigned in the for loop
        }
    }
}
