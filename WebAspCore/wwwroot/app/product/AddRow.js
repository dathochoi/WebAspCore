var AddRow = function () {
    this.init = function () {
        console.log("add row");
        
        var arrHead = new Array();	// array for header.
         arrHead = ['','Đơn vị', 'Giá gốc', 'Giá Bán', 'Giá khuyến mãi','Tình trạng'];
        createTable();
        $('#addRow').on("click", function () {
            addRow();
        });

        $('#empTable').on("click",".btnremove" ,function () {
            removeRow(this);
        });
        // first create TABLE structure with the headers. 
        function createTable() {
            var empTable = document.createElement('table');
            empTable.setAttribute('id', 'empTable'); // table id.
            empTable.setAttribute('class', 'table ');
            //empTable.style.width = "70%";

            
            var tr = empTable.insertRow(-1);
            for (var h = 0; h < arrHead.length; h++) {
                var th = document.createElement('th'); // create table headers
                th.setAttribute('class', 'col-sm-2');
                th.innerHTML = arrHead[h];
                tr.appendChild(th);
            }
            var rowCnt = empTable.rows.length;
            tr = empTable.insertRow(rowCnt);
            for(var c = 0; c < arrHead.length; c++) {
                var td = document.createElement('td'); // table definition.
                td = tr.insertCell(c);

                if (c == 0) {      // the first column.
                    // add a button in every new row in the first column.
                    var button = document.createElement('input');
                    button.setAttribute('scope', 'row');
                    button.setAttribute('class', 'btnremove btn btn-danger');
                    // set input attributes.
                    button.setAttribute('type', 'button');
                    button.setAttribute('value', 'Remove');

                    // add button's 'onclick' event.
                    //button.setAttribute('onclick', 'removeRow(this)');

                    td.appendChild(button);
                }
                else if (c == 1) {      // the first column.
                    // add a button in every new row in the first column.
                    var text = document.createElement('input');

                    // set input attributes.
                    
                    text.setAttribute('type', 'text');
                    text.setAttribute('class', 'form-control eleTableT');

                    td.appendChild(text);
                }
                else if (c == 5) {      // the first column.
                    // add a button in every new row in the first column.
                    var checkbox = document.createElement('input');

                    // set input attributes.
                    tr.setAttribute('style', 'text-align:center; vertical-align:middle;');
                    checkbox.setAttribute('type', 'checkbox');
                    checkbox.setAttribute("checked", "checked");
                    checkbox.setAttribute('class', 'form-check-input eleTableC');

                    td.appendChild(checkbox);
                }
                else {
                    // 2nd, 3rd and 4th column, will have textbox.
                    var ele = document.createElement('input');
                    ele.setAttribute('type', 'number');
                    ele.setAttribute('value', '0');
                    ele.setAttribute('class', 'form-control eleTableN');
                    td.appendChild(ele);
                }
            }

            var div = document.getElementById('cont');
            div.appendChild(empTable);  // add the TABLE to the container.
        }

        // now, add a new to the TABLE.
        function addRow() {
            var empTab = document.getElementById('empTable');

            var rowCnt = empTab.rows.length;   // table row count.
            var tr = empTab.insertRow(rowCnt); // the table row.
           // tr = empTab.insertRow(rowCnt);

            for (var c = 0; c < arrHead.length; c++) {
                var td = document.createElement('td'); // table definition.
                td = tr.insertCell(c);

                if (c == 0) {      // the first column.
                    // add a button in every new row in the first column.
                    var button = document.createElement('input');
                    button.setAttribute('class', 'btnremove btn btn-danger');
                    // set input attributes.
                    button.setAttribute('scope', 'row');
                    button.setAttribute('type', 'button');
                    button.setAttribute('value', 'Remove');

                    // add button's 'onclick' event.
                    //button.setAttribute('onclick', 'removeRow(this)');

                    td.appendChild(button);
                }
                else if (c == 1) {      // the first column.
                    // add a button in every new row in the first column.
                    var text = document.createElement('input');

                    // set input attributes.
                    text.setAttribute('class', 'form-control eleTableT');
                    text.setAttribute('type', 'text');

                    td.appendChild(text);
                }
                else if (c == 5) {      // the first column.
                    // add a button in every new row in the first column.
                    var checkbox = document.createElement('input');
                    
                    // set input attributes.
                    tr.setAttribute('style', 'text-align:center; vertical-align:middle;');
                    checkbox.setAttribute('type', 'checkbox');
                    checkbox.setAttribute("checked", "checked");
                    checkbox.setAttribute('class', 'form-check-input eleTableC');
                    td.appendChild(checkbox);
                }
                else {
                    // 2nd, 3rd and 4th column, will have textbox.
                    var ele = document.createElement('input');
                    ele.setAttribute('type', 'number');
                    ele.setAttribute('value', '0');
                    ele.setAttribute('class', 'form-control eleTableN');
                    td.appendChild(ele);
                }
            }
        }

        // delete TABLE row function.
        function removeRow(oButton) {
            var empTab = document.getElementById('empTable');
            empTab.deleteRow(oButton.parentNode.parentNode.rowIndex); // button -> td -> tr.
        }

        // function to extract and submit table data.
        //function submit() {
        //    var myTab = document.getElementById('empTable');
        //    var arrValues = new Array();

        //    // loop through each row of the table.
        //    for (row = 1; row < myTab.rows.length - 1; row++) {
        //        // loop through each cell in a row.
        //        for (c = 0; c < myTab.rows[row].cells.length; c++) {
        //            var element = myTab.rows.item(row).cells[c];
        //            if (element.childNodes[0].getAttribute('type') == 'number' || element.childNodes[0].getAttribute('checkbox')) {
        //                arrValues.push( element.childNodes[0].value );
        //            }
        //        }
        //    }
        //    console.log(arrValues);
        //    // The final output.
        //    document.getElementById('output').innerHTML = arrValues;
        //    //console.log (arrValues);   // you can see the array values in your browsers console window. Thanks :-) 
        //}
    }
}