
function getEmployeeByCompany(e) {

    window.location.href = "/employee?id=" + e.value;
}



function editEmployee(id) {

    $("#employeeSave_" + id).show();
    $("#employeeCancel_" + id).show();
    $("#employeeEdit_" + id).hide();
    $("#employeeDetail_" + id).hide();
    $("#employeeDelete_" + id).hide();

    $("#spanEmployeeNameLast_" + id).hide();
    var inputEmployeeNameLast_ = $("#inputEmployeeNameLast_" + id);
    inputEmployeeNameLast_.show();

    $("#spanEmployeeNameFirst_" + id).hide();
    var inputEmployeeNameFirst_ = $("#inputEmployeeNameFirst_" + id);
    inputEmployeeNameFirst_.show();

    var chkEmployeeActive_ = $("#chkEmployeeActive_" + id);
    chkEmployeeActive_.removeAttr("disabled");

    var grossPayId;
    var hdfGrossPay_ = $("#hdfGrossPay_" + id);
    if (hdfGrossPay_.val() != undefined) {
        grossPayId = hdfGrossPay_.val();
        $("#spanGrossPay_" + grossPayId).hide();

        var inputGrossPay_ = $("#inputGrossPay_" + grossPayId);
        inputGrossPay_.show();
    }
    else {
        var inputEmployeeGrossPay_ = $("#inputEmployeeGrossPay_" + id);
        inputEmployeeGrossPay_.show();
    }

}
function updateEmployee(e, id) {

    var spanEmployeeNameLast_ = $("#spanEmployeeNameLast_" + id);
    spanEmployeeNameLast_.show();
    var inputEmployeeNameLast_ = $("#inputEmployeeNameLast_" + id);
    spanEmployeeNameLast_.text(inputEmployeeNameLast_.val());
    inputEmployeeNameLast_.hide();

    var spanEmployeeNameFirst_ = $("#spanEmployeeNameFirst_" + id);
    spanEmployeeNameFirst_.show();
    var inputEmployeeNameFirst_ = $("#inputEmployeeNameFirst_" + id);
    spanEmployeeNameFirst_.text(inputEmployeeNameFirst_.val());
    inputEmployeeNameFirst_.hide();


    var grossPayId;
    var grossAmount;
    var hdfGrossPay_ = $("#hdfGrossPay_" + id);
    if (hdfGrossPay_.val() != undefined) {
        var spanGrossPay_ = $("#spanGrossPay_" + hdfGrossPay_.val());
        spanGrossPay_.show();

        var inputGrossPay_ = $("#inputGrossPay_" + hdfGrossPay_.val());
        inputGrossPay_.hide();

        grossAmount = inputGrossPay_.val();
        spanGrossPay_.text(inputGrossPay_.val());
    }
    else {
        var inputEmployeeGrossPay_ = $("#inputEmployeeGrossPay_" + id);
        grossAmount = inputEmployeeGrossPay_.val();
        inputEmployeeGrossPay_.hide();
    }

    var chkEmployeeActive_ = $("#chkEmployeeActive_" + id);
    chkEmployeeActive_.attr("disabled", "disabled");

    var data = {};
    var request = [];
    var employee = [];
    var name = [];
    request["id"] = grossPayId;
    employee["id"] = id;
    name["first"] = inputEmployeeNameFirst_.val();
    name["last"] = inputEmployeeNameLast_.val();
    employee["name"] = name;
    request["employee"] = employee;
    request["amount"] = grossAmount;

    $.ajax({
        type: "POST",
        url: '/employee/OnAdd',
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            cancelEmployee(id);
        //    $("#employeeSave_" + id).show();
        //    $("#employeeCancel_" + id).show();
        //    $("#employeeEdit_" + id).hide();
        //    $("#employeeDetail_" + id).hide();
        //    $("#employeeDelete_" + id).hide();
        }
    });

    //$("#employeeSave_" + id).hide();
    //$("#employeeCancel_" + id).hide();
    //$("#employeeEdit_" + id).show();
    //$("#employeeDetail_" + id).show();
    //$("#employeeDelete_" + id).show();

}
function detailEmployee(id) {
    $(".trEmployeeDetail_").hide();//hide all the detail controls

    var trEmployeeDetail = $("#trEmployeeDetail_" + id);
    trEmployeeDetail.show();

    var detail_ = $("#employeeDetail_" + id);
    detail_.hide();

    var detailHide_ = $("#detaiEmployeelHide_" + id);
    detailHide_.show();
}
function detailHideEmployee(id) {
    var detail_ = $("#employeeDetail_" + id);
    detail_.show();

    var detailHide_ = $("#detaiEmployeelHide_" + id);
    detailHide_.hide();

    var trEmployeeDetail = $("#trEmployeeDetail_" + id);
    trEmployeeDetail.hide();
}
function cancelEmployee(id) {
    $("#trAddEmployee").hide();
    $("#employeeSave").show();

    $("#employeeSave_" + id).hide();
    $("#employeeCancel_" + id).hide();
    $("#employeeEdit_" + id).show();
    $("#employeeDetail_" + id).show();
    $("#employeeDelete_" + id).show(); 

    $("#spanEmployeeNameLast_" + id).show();
    $("#inputEmployeeNameLast_" + id).hide();
    $("#spanEmployeeNameFirst_" + id).show();
    $("#inputEmployeeNameFirst_" + id).hide();

    var hdfGrossPay_ = $("#hdfGrossPay_" + id);
    if (hdfGrossPay_.val() != undefined)  {
        var hdfGrossPayId = hdfGrossPay_.val();
        $("#spanGrossPay_" + hdfGrossPayId).show();
        $("#inputGrossPay_" + hdfGrossPayId).hide();
    }
    else { 
        $("#inputEmployeeGrossPay_" + id).hide();
    }
    $("#chkEmployeeActive_" + id).attr("disabled", "disabled");

    clearAddEmployeeControls();
}
function deleteEmployee(id) {
    $.ajax({
        type: "POST",
        url: '/employee/OnDelete',
        data: id,
        contentType: "application/json",
        dataType: "json",
        success: function (resp) {
            cancelEmployee(id);
        }
    });
}

function clearAddEmployeeControls() {
    var EmployeeName = $("#employeeName");
    EmployeeName.text('');
}
function addEmployee(e) {
    $("#employeeSave").hide();

    $("#trAddEmployee").show();

    $(".trEmployeeDetail_").hide();
    clearAddEmployeeControls();
}
function saveEmployee(e, id) {
    
    var employeeFirstName = $("#employeeFirstName");
    var employeeLastName = $("#employeeLastName");
    var employeeGrossPay = $("#employeeGrossPay");
    var employeeActive = $("#employeeActive");

    var data = {};
    var request = [];
    var employee = [];
    var name = [];
    employee["id"] = id;
    employee["active"] = employeeActive.val()=="on";
    name["first"] = employeeFirstName.val();
    name["last"] = employeeLastName.val();
    employee["name"] = name;
    request["employee"] = employee;
    request["amount"] = employeeGrossPay.val();

    $.ajax({
        type: "POST",
        url: '/employee/OnAdd',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val())
        },
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "json",
        success: function (resp) {
            $("#trAddEmployee").hide(); 
            $("#employeeSave").show(); 
            //window.location.href = "/employee?id=" + id;
        }
    });
}
