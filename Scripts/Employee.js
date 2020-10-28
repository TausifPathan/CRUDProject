$(document).ready(function () {      
    LoadData();
});

function LoadData() {  
   $.ajax({
        type: 'GET',
        url: "../Employee/EmployeeIndex",
        success: function (data) {
            debugger;
           
            $("#getEmployee").html(data);
        },
        error: function (ex) {
            
        }
   });
}

function addEmployee() {

    alert("test");
    if (!Validate())
        return false;
    var formdata = new FormData($("#form")[0]);
    debugger;

    $.ajax({
        method: "POST",
        dataType: "json",
        url: "/Employee/Create",
        data: formdata,
        success: function (data) {
            debugger;

            if (data.flag) {
                alert(data.msg)
                window.location.href = "/Employee/Create";
            }
        },
        error: function (err) {
            alert("Error while inserting data");
        },
    })
}
//function addEmployee() {
//    alert("ajax called");
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
    
//    $.ajax({
//        url: "/Employee/Create",        
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            alert("data saved(ajax)");
//            //$('#myModal').modal('hide');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}  
//function addEmployee(url) {
//    if (!Validate())
//        return false;
//    debugger;
//    $.ajax({
//        method: "POST",
//        data: $("#form").serialize(),
//        dataType: "json",
//        url : url,
//        success: function (data) {
//            debugger;
//            //if (data.flag) {
//            //    alert(data.msg)
//            //    window.location.href = "/Employee/Create";
//            alert(data);
//            LoadData();

//            }
//        },
        
//    });
//}



function Validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Street1').val().trim() == "") {
        $('#Street1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Street1').css('border-color', 'lightgrey');
    }
    if ($('#Street2').val().trim() == "") {
        $('#Street2').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Street2').css('border-color', 'lightgrey');
    }
    if ($('#Area').val().trim() == "") {
        $('#Area').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Area').css('border-color', 'lightgrey');
    }
    if ($('#City').val().trim() == "") {
        $('#City').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#City').css('border-color', 'lightgrey');
    }
    if ($('#Pincode').val().trim() == "") {
        $('#Pincode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Pincode').css('border-color', 'lightgrey');
    }
    return isValid;
}  

function clearTextBox() {
    $('#Name').val("");
    $('#Street1').val("");
    $('#Street2').val("");
    $('#Area').val("");
    $('#City').val("");
    $('#Pincode').val("");
} 

function deleteEmployee(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Employee/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                debugger
                loadData();
                window.Location.href = "/Employee/Create";
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}  

function editEmployee() {
    var res = Validate();
    if (res == false) {
        return false;
    }
    
    $.ajax({
        url: "/Employee/Edit",        
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) { 
            alert("inside success");
            $('#myModal').modal('hide');
            $('#Name').val("");
            $('#Street1').val("");
            $('#Street1').val("");
            $('#Area').val("");
            $('#City').val("");
            $('#Pincode').val("");
            alert(data.msg)
            window.location.href = "/Employee/Create";
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  

