"use strict";

$(document).ready(function () {
    $.get("People/PersonPartialView", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);
        $("#peoplePartial").html(data);
    });
});



$("#CreateBtnPartial").click(function () {
    $.get("People/CreatePerson", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);
        $("#createPartial").html(data);
    });
});


//$(".RemoveBtnPartial").click(function () {
//    $.get("People/RemovePerson/1", function (data, status) {
//        console.log("Data: " + data + "\nStatus: " + status);
//        $("#peoplePartial").html(data);
//    });
//});



$("#RemoveBtnPartial").click(function (remove) {
    remove.preventDefault(); var _this = $(this);
    $.get(_this.attr("href"), function (res) {
        $('#' + _this.data("peoplePartial")).html(res);
    });
});


//$("aCreate").click(function (remove) {
//    var _this = $(this);
//    $.get("Cars/PartialCar/1", function (data, status) {
//        console.log("Data: " + data + "\nStatus: " + status);

//        $("#targetPartial").html(data);
//    });
//});



//Example
//$(document).ready(function () {
//    $("#btnPartial").click(function () {
//        $.get("Cars/PartialCar/1", function (data, status) {
//            console.log("Data: " + data + "\nStatus: " + status);

//            $("#targetPartial").html(data);
//        });
//    });
//});
