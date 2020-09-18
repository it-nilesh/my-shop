$(document).ready(function () {
    showItem();
})
var id = 0;
function _addCart(id) {
    var options = {};
    options.url = "/Home/addproduct";
    options.type = "POST";
    options.data = JSON.stringify({ pId: id });
    options.dataType = "json";
    options.contentType = "application/json";
    options.success = function (msg) {
        $("#cartItem").text(msg);
    }
    options.error = function () { alert("Error retrieving sttes!"); };
    $.ajax(options);
}
function showItem() {
    var options = {};
    options.url = "/Home/showItem";
    options.type = "POST";
    options.dataType = "json";
    options.contentType = "application/json";
    options.success = function (msg) {
        $("#cartItem").text(msg);
    }
    options.error = function () { alert("Error retrieving sttes!"); };
    $.ajax(options);
}