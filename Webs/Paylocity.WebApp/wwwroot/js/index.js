

function editCompany(id) {

}
function detailCompany(id) {
    $("#trCompanyDetail_").hide();//hide all the detail controls

    var _recordDeductions = $("#hdfDeductions");
    var trCompanyDetail = $("#trCompanyDetail_" + id);
    trCompanyDetail.show();

    var detail_ = $("#detail_" + id);
    detail_.hide();

    var detailHide_ = $("#detailHide_" + id);
    detailHide_.show();

}
function detailHideCompany(id) {
    var detail_ = $("#detail_" + id);
    detail_.show();

    var detailHide_ = $("#detailHide_" + id);
    detailHide_.hide();

    var trCompanyDetail = $("#trCompanyDetail_" + id);
    trCompanyDetail.hide();

}
function cancelCompany(e) {
    var trAddCompany = $("#trAddCompany");
    trAddCompany.hide();

    var companySave = $("#companySave");
    companySave.show();

    clearAddCompanyControls();
}
function deleteCompany(id) {

}

function clearAddCompanyControls() {
    var companyName = $("#companyName");
    companyName.text('');
}
function addCompany(e) {
    var companySave = $("#companySave");
    companySave.hide();

    var trAddCompany = $("#trAddCompany");
    trAddCompany.show();

    var trCompanyDetail = $("#trCompanyDetail_");
    trCompanyDetail.hide();

    
    clearAddCompanyControls();
}
function saveCompany(e) {

}
function runCompanyReport(id) {

}